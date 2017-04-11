using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using Microsoft.Owin.Hosting;
using VkHunter.BusinessLogic.Implementations;
using VkHunter.Common.Helpers;
using VkHunter.Common.Logger;
using VkHunter.Domain;
using VkHunter.Domain.Entities;
using VkHunter.Domain.Interfaces;
using VkHunter.Web.Constants;

namespace VkHunter.Web
{
    class Program
    {
        private static ILogService _logger = new LogService();

        static void Main(string[] args)
        {
            var baseAddress = CommonHelper.GetConfigOrDefault(ParamName.BaseUrlKey, DefaultSetting.BaseUrl);

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("Begin...");

                var queryResult = TestQuery();
                var dbResult = TestDB();

                if (queryResult && dbResult)
                {
                    Console.WriteLine("\nПриложение запущено...");

                    #region DATA AUTO UPDATE

                    var updateTime = CommonHelper.GetConfigOrDefault(ParamName.TimeUpdateKey, DefaultSetting.TimeUpdate);

                    //Task.Run(() => Worker(updateTime));  // Для разработки

                    var callback = new TimerCallback(Worker);
                    var timer = new Timer(callback, updateTime, new TimeSpan(0, 1, 0), new TimeSpan(0, 1, 0));

                    #endregion
                }

                Console.ReadLine();
            }
        }

        private static void Worker(object updateTime)
        {
            var dateTimeNow = DateTime.Now;
            
            if (dateTimeNow.ToShortTimeString() != updateTime.ToString())
                return;

            var message = $"{dateTimeNow}: сбор данных из vk...";

            Console.WriteLine(message);
            _logger.Debug(message);

            var attemp = 0;
            var fSuccess = false;

            do
            {
                try
                {
                    var appId = ulong.Parse(CommonHelper.GetConfigByKey(ParamName.VkAppId));
                    var email = CommonHelper.GetConfigByKey(ParamName.VkEmail);
                    var password = CommonHelper.GetConfigByKey(ParamName.VkPassword);
                    var queryCount = int.Parse(CommonHelper.GetConfigByKey(ParamName.QueryCount));

                    var vkService = new TemporarilyVkService(appId, email, password, queryCount);

                    using (IDataManager dataManager = new DataManager())
                    {
                        var vkHunter = new VkWorker(vkService, dataManager);
                        vkHunter.DataUpdate();

                        fSuccess = true;
                    }
                }
                catch (Exception ex)
                {
                    if (attemp < 3)
                    {
                        Thread.Sleep(500);
                        attemp++;
                        continue;
                    }

                    var errorMessage = $"{nameof(Program)} | {nameof(Worker)} | {ex}";
                    Console.WriteLine(errorMessage);
                    _logger.Debug(errorMessage);

                    var isSend = CommonHelper.SendEmail(CommonHelper.GetConfigOrDefault(ParamName.AdminUserName, string.Empty), errorMessage);
                    if (!isSend)
                        _logger.Debug(ErrorMessage.SentError);

                    return;
                }
            }
            while (!fSuccess);

            var endMsg = $"{DateTime.Now}: сбор данных из vk окончен.";

            _logger.Debug(endMsg);
            Console.WriteLine(endMsg);
        }

        #region TEST METHODS

        private static bool TestQuery()
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine("Тест запроса:");

                var baseAddress = CommonHelper.GetConfigOrDefault(ParamName.BaseUrlKey, DefaultSetting.BaseUrl);
                var response = client.GetAsync($"{baseAddress}api/test/getValues").Result;

                Console.WriteLine(response);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Тест не пройден!");
                    return false;
                }

                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine("OK");

                return true;
            }
        }

        private static bool TestDB()
        {
            using (var dbContext = new VkDbContext())
            {
                Console.WriteLine("\nТест БД (запись/чтение/удаление):");
                
                try
                {
                    var model = dbContext.TestModels.Add(new TestModel
                    {
                        Name = "Test DB"
                    });

                    var models = dbContext.TestModels.ToList();
                    foreach (var m in models)
                    {
                        Console.WriteLine($"{m.Id}   {m.Name}");
                        dbContext.TestModels.Remove(m);
                    }

                    Console.WriteLine("OK");
                    return true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Тест не пройден!");
                    return false;
                }
            }
        }

        #endregion
    }
}
