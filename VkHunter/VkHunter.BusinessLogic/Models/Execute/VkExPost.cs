using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VkHunter.BusinessLogic.Models.Execute
{
    public class VkExPost
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("from_id")]
        public long FromId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("date")]
        public double DateTime { get; set; }

        [JsonProperty("attachments")]
        public IEnumerable<Attachment> Attachments { get; set; }
    }

    public class Attachment
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("photo")]
        public Photo Photos { get; set; }

        [JsonProperty("link")]
        public Link Link { get; set; }
    }

    public class Photo
    {
        [JsonProperty("photo_75")]
        public string Photo75 { get; set; }

        [JsonProperty("photo_130")]
        public string Photo130 { get; set; }

        [JsonProperty("photo_604")]
        public string Photo604 { get; set; }
    }

    public class Link
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("photo")]
        public Photo Photos { get; set; }
    }
}
