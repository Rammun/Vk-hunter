using System;
using System.Collections.Generic;

namespace VkHunter.BusinessLogic.Models
{
    public class VkPost
    {
        public long Id { get; set; }

        public long OwnerId { get; set; }

        public long FromId { get; set; }

        public string Text { get; set; }

        public DateTime DateTime { get; set; }

        public IEnumerable<string> PhotoUri { get; set; } 
    }
}
