using Newtonsoft.Json;

namespace VkHunter.BusinessLogic.Models.Execute
{
    public class VkExUser
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("followers_count")]
        public int? MembersCount { get; set; }

        [JsonProperty("status")]
        public string Description { get; set; }

        [JsonProperty("photo_max_orig")]
        public string Ava { get; set; }
    }
}
