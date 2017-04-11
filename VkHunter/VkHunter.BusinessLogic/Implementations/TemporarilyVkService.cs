using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using VkHunter.BusinessLogic.Models;

namespace VkHunter.BusinessLogic.Implementations
{
    public class TemporarilyVkService : VkService
    {
        public TemporarilyVkService(ulong appId, string email, string password, int queryCount)
            : base(appId, email, password, queryCount)
        {
        }

        // Возможно временно, пока не заработает правильно метод base.GetUsersByIds
        public override IEnumerable<VkUser> GetUsersByIds(IEnumerable<long> ids)
        {
            Delay(_timeout);

            var parameters = new Dictionary<string, string>
            {
                {"user_ids", $"{string.Join(",", ids.Select(x => x.ToString()))}"},
                {"access_token", _vkApi.Token },
                {"fields", "followers_count,photo_max_orig,domain,status,site,activities,interests,about" },
                {"v", "5.62" }
            };

            using (var client = new HttpClient())
            {
                var param = string.Join("&", parameters.Select(x => $"{x.Key}={x.Value}"));
                var uri = $"https://api.vk.com/method/users.get?{param}";

                var response = client.GetAsync(uri).Result;
                var answer = response.Content.ReadAsAsync<VkUsersResponse>().Result;

                _lastTime = DateTime.Now;

                var result = _maper.Map<IEnumerable<VkOriginUser>, IEnumerable<VkUser>>(answer.Users);
                return result;
            }
        }
    }
}
