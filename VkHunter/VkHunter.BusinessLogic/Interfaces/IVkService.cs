using System.Collections.Generic;
using VkHunter.BusinessLogic.Models;

namespace VkHunter.BusinessLogic.Interfaces
{
    public interface IVkService
    {
        IEnumerable<VkGroup> GetGroups(string query);
        IEnumerable<VkPost> GetNewsfeeds(string query);
        IEnumerable<VkGroup> GetGroupsByIds(IEnumerable<string> ids);
        IEnumerable<VkUser> GetUsersByIds(IEnumerable<long> ids);
        IEnumerable<VkMarket> GetMarkets(string query, long id);
        IEnumerable<VkGroup> GetGroupsWithMarket(string query);
        VkExecute DataExecute(string search);
    }
}
