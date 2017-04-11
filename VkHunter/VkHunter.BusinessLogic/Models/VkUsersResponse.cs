using System.Collections.Generic;
using Newtonsoft.Json;

namespace VkHunter.BusinessLogic.Models
{
    public class VkUsersResponse
    {
        [JsonProperty("response")]
        public IEnumerable<VkOriginUser> Users { get; set; }
    }

    public class VkOriginUser
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("first_name")]
        public string Name { get; set; }

        [JsonProperty("last_name")]
        public string SecondName { get; set; }

        [JsonProperty("photo_max_orig")]
        public string Ava { get; set; }

        [JsonProperty("followers_count")]
        public int? MembersCount { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("domain")]
        public string Uri { get; set; }

        [JsonProperty("site")]
        public string Site { get; set; }

        [JsonProperty("interests")]
        public string Interests { get; set; }

        [JsonProperty("about")]
        public string About { get; set; }

        [JsonProperty("activities")]
        public string Activities { get; set; }
    }
}
