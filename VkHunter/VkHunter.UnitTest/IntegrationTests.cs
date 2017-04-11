using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using NUnit.Framework;
using VkHunter.BusinessLogic.Implementations;
using VkHunter.Domain;
using VkHunter.Web;
using VkNet;
using VkNet.Enums.Filters;

namespace VkHunter.UnitTest
{
    // Это не тесты, делались при разработке для удобства отладки запросов
    [TestFixture]
    public class IntegrationTests
    {
        [Test]
        public void TestDataUpdate()
        {
            ulong appId = 5852273;
            var email = "+79150344189";
            var password = "fmWpVwGfhACXippS";
            var timeout = 350;

            var dataManager = new DataManager();
            var vkService = new VkService(appId, email, password, timeout);

            var vkWorker = new VkWorker(vkService, dataManager);
            vkWorker.DataUpdate();
        }

        [Test]
        public void TestExecute()
        {
            ulong appId = 5852273;
            var email = "+79150344189";
            var password = "fmWpVwGfhACXippS";
            var queryCount = 3;

            var vkService = new VkService(appId, email, password, queryCount);
            var response = vkService.DataExecute("Test");
        }

        [Test]
        public void TestGetUsers()
        {
            ulong appId = 5852273;
            var email = "+79150344189";
            var password = "fmWpVwGfhACXippS";
            var requestCounter = 3;

            var dataManager = new DataManager();
            var vkService = new TemporarilyVkService(appId, email, password, requestCounter);

            var users = vkService.GetUsersByIds(new long[] { 348298852, 380272040, 403111540 });

            var result = users;
        }

        [Test]
        public void TestGroups()
        {
            var _vkApi = new VkApi
            {
                RequestsPerSecond = 3
            };

            _vkApi.Authorize(new ApiAuthParams
            {
                ApplicationId = 5852273,
                Login = "+79150344189",
                Password = "fmWpVwGfhACXippS",
                Settings = Settings.All
            });

            var ids = new long[] { 65772109, 106674541, 80452381 };

            var parameters = new Dictionary<string, string>
            {
                {"group_ids", $"{string.Join(",", ids.Select(x => x.ToString()))}"},
                {"access_token", _vkApi.Token},
                {"fields", "followers_count,photo_max_orig,domain,status"},
                {"v", "5.62"}
            };

            using (var client = new HttpClient())
            {
                var param = string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}"));
                var uri = $"https://api.vk.com/method/groups.getById?{param}";

                var response = client.GetAsync(uri).Result;
                var answer = response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
