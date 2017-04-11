using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using AutoMapper;
using Newtonsoft.Json;
using VkHunter.BusinessLogic.Interfaces;
using VkHunter.BusinessLogic.Mapping;
using VkHunter.BusinessLogic.Models;
using VkHunter.BusinessLogic.Models.Execute;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VkHunter.BusinessLogic.Implementations
{
    public class VkService : IVkService
    {
        protected const int GROUP_MAX_COUNT = 1000;  // Максимальное кол-во запросов для групп
        protected const int MARKET_MAX_COUNT = 200;  // Максимальное кол-во запросов для маркета
        protected const int NEWS_MAX_COUNT = 200;    // Максимальное кол-во запросов для новостей

        protected IMapper _maper;

        protected int _timeout;
        protected static DateTime _lastTime;

        protected ulong _appId;
        protected string _email;
        protected string _password;
        protected Settings _scope;

        protected VkApi _vkApi;

        public VkService(ulong appId, string email, string password, int queryCount)
        {
            _maper = AutoMapperConfiguration.CreateMappings();

            _timeout = 1000 / queryCount + 1;
            _lastTime = DateTime.Now;

            _appId = appId;
            _email = email;
            _password = password;
            _scope = Settings.All;

            _vkApi = new VkApi
            {
                RequestsPerSecond = queryCount
            };

            this.Autorize();
        }

        public virtual IEnumerable<VkGroup> GetGroups(string query)
        {
            Delay(_timeout);

            var groups = _vkApi.Groups.Search(new GroupsSearchParams
            {
                Query = query,
                Count = GROUP_MAX_COUNT
            });

            _lastTime = DateTime.Now;

            var result = _maper.Map<IEnumerable<Group>, IEnumerable<VkGroup>>(groups);
            return result;
        }

        public virtual IEnumerable<VkGroup> GetGroupsByIds(IEnumerable<string> ids)
        {
            Delay(_timeout);

            var groups = _vkApi.Groups.GetById(ids, string.Empty, GroupsFields.All);

            _lastTime = DateTime.Now;

            var result = _maper.Map<IEnumerable<Group>, IEnumerable<VkGroup>>(groups);
            return result;
        }

        public virtual IEnumerable<VkGroup> GetGroupsWithMarket(string query)   // Надо добавить параметр для поиска групп с маркетом
        {
            Delay(_timeout);

            var groups = _vkApi.Groups.Search(new GroupsSearchParams
            {
                Query = query,
                Count = GROUP_MAX_COUNT
            });

            _lastTime = DateTime.Now;

            var result = _maper.Map<IEnumerable<Group>, IEnumerable<VkGroup>>(groups);
            return result;
        }
        
        public virtual IEnumerable<VkUser> GetUsersByIds(IEnumerable<long> ids)
        {
            Delay(_timeout);

            // Ошибка в бибилиотеке, если ids.Count > 1 не возвращает счетчики пользователя
            var user = _vkApi.Users.Get(ids, ProfileFields.All);

            _lastTime = DateTime.Now;

            var result = _maper.Map<IEnumerable<User>, IEnumerable<VkUser>>(user);
            return result;
        }
        
        public virtual IEnumerable<VkMarket> GetMarkets(string query, long id)
        {
            Delay(_timeout);

            var markets = _vkApi.Markets.Search(new MarketSearchParams
            {
                OwnerId = id,
                Query = query,
                Count = MARKET_MAX_COUNT
            });

            _lastTime = DateTime.Now;

            var result = _maper.Map<IEnumerable<Market>, IEnumerable<VkMarket>>(markets);
            return result;
        }

        public virtual IEnumerable<VkPost> GetNewsfeeds(string query)
        {
            Delay(_timeout);

            var newsfeed = _vkApi.NewsFeed.Search(new NewsFeedSearchParams
            {
                Query = query,
                Extended = true,
                Fields = UsersFields.Photo200,
                Count = NEWS_MAX_COUNT
            });

            _lastTime = DateTime.Now;

            var result = _maper.Map<IEnumerable<NewsSearchResult>, IEnumerable<VkPost>>(newsfeed);
            return result;
        }

        public virtual VkExecute DataExecute(string search)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();

                var code = CodeExecute(search);

                var requestParams = new Dictionary<string, string>
                {
                    { "code", code },
                    { "access_token", _vkApi.Token },
                    { "v", "5.62" }
                };

                var content = new FormUrlEncodedContent(requestParams);
                var response = client.PostAsync(@"https://api.vk.com/method/execute", content).Result;
                var answer = response.Content.ReadAsAsync<VkExecuteResponse>().Result;

                if (answer.ErrorMessage != null)
                {
                    var errorMessage =
                        $"Ошибка выполнения запроса!\ncode={answer.ErrorMessage.Code}\nmessage: {answer.ErrorMessage.Message}\n";

                    Debug.WriteLine(errorMessage);
                    throw new Exception(errorMessage);
                }

                var result = _maper.Map<VkOrginExecute, VkExecute>(answer.Response);
                return result;
            }
        }

        protected void Autorize()
        {
            _vkApi.Authorize(new ApiAuthParams
            {
                ApplicationId = _appId,
                Login = _email,
                Password = _password,
                Settings = _scope
            });
        }

        // Оказался нужен, библиотека иногда кидает эксепшн о превышении лимита запросов в секунду.
        protected void Delay(int timeout)
        {
            var span = timeout - (DateTime.Now - _lastTime).Milliseconds;

            if(span > 0)
                Thread.Sleep(span);
        }

        private string CodeExecute(string search)
        {
            return @"
var posts=API.newsfeed.search({""q"":""" + search + @""",""count"":200}).items;
var ownerIds=posts@.from_id;
var i=0;
var gIds=[];
var uIds=[];
while(i<ownerIds.length)
{
  if(ownerIds[i]<0){gIds.push(-ownerIds[i]);};
  if(ownerIds[i]>0){uIds.push(ownerIds[i]);};
  i=i+1;
};
var groups=API.groups.search({""q"":""" + search + @""",""count"":200}).items;
var ids=groups@.id;
i=0;
while(i<ids.length)
{
  gIds.push(ids[i]);
  i=i+1;
};
var gResult=API.groups.getById({""group_ids"":gIds,""fields"":""members_count,photo_max_orig,status""});
var uResult=API.users.get({""user_ids"":uIds,""fields"":""followers_count,photo_max_orig,domain,status""});
return {""posts"":posts,""groups"":gResult,""users"":uResult};";

        }
    }
}
