using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VkHunter.Web.Models.DTO.Response
{
    [JsonObject(MemberSerialization.OptIn, Title = "login")]
    public class LoginResponseDTO
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
