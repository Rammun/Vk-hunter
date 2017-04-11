using Newtonsoft.Json;

namespace VkHunter.BusinessLogic.Models
{
    public class VkUser
    {
        public long Id { get; set; }
        
        public string Name { get; set; }

        public string Ava { get; set; }

        public int? MembersCount { get; set; }

        public string Status { get; set; }

        public string About { get; set; }

        public string Interests { get; set; }

        public string Activities { get; set; }

        public string Site { get; set; }

        public string Uri { get; set; }

        public string Type { get; set; }
    }
}
