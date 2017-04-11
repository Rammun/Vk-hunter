using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VkHunter.BusinessLogic.Models.Execute
{
    public class VkExGroup
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("screen_name")]
        public string Domain { get; set; }

        [JsonProperty("members_count")]
        public int? MembersCount { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("photo_max_orig")]
        public string Ava { get; set; }
    }
}
