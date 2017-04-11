using Newtonsoft.Json;

namespace VkHunter.DTO
{
    [JsonObject(MemberSerialization.OptIn, Title = "login")]
    public class LoginResponseDTO
    {
        [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }
    }
}
