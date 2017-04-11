using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VkHunter.BusinessLogic.Models.Execute
{
    public class VkExecuteResponse
    {
        [JsonProperty("response")]
        public VkOrginExecute Response { get; set; }

        [JsonProperty("error")]
        public ErrorMessage ErrorMessage { get; set; }
    }

    public class VkOrginExecute
    {
        [JsonProperty("posts")]
        public IEnumerable<VkExPost> Posts { get; set; }

        [JsonProperty("users")]
        public IEnumerable<VkExUser> Users { get; set; }

        [JsonProperty("groups")]
        public IEnumerable<VkExGroup> Groups { get; set; }
    }

    public class ErrorMessage
    {
        [JsonProperty("error_code")]
        public int Code { get; set; }

        [JsonProperty("error_msg")]
        public string Message { get; set; }
    }
}
