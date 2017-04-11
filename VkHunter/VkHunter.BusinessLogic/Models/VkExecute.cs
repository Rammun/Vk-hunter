using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkHunter.BusinessLogic.Models
{
    public class VkExecute
    {
        public IEnumerable<VkPost> Posts { get; set; }

        public IEnumerable<VkUser> Users { get; set; }

        public IEnumerable<VkGroup> Groups { get; set; }
    }
}
