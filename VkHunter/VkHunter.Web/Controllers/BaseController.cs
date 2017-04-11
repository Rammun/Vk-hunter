using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using VkHunter.Common.Logger;
using VkHunter.Domain;
using VkHunter.Domain.Identity;
using VkHunter.Domain.Interfaces;
using VkHunter.Web.Mapping;

namespace VkHunter.Web.Controllers
{
    public class BaseController : ApiController
    {
        private readonly ILogService _loger;
        private readonly IMapper _mapper;
        private readonly IDataManager _dataManager;

        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public BaseController()
        {
            _loger = new LogService();
            _mapper = AutoMapperConfiguration.CreateMappings();
            _dataManager = new DataManager();
        }

        protected ApplicationUserManager UserManager =>
            _userManager ?? (_userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>());

        protected ApplicationRoleManager RoleManager =>
            _roleManager ?? (_roleManager = Request.GetOwinContext().Get<ApplicationRoleManager>());

        protected ILogService Logger => _loger;
        protected IMapper Mapper => _mapper;
        protected IDataManager DataManager => _dataManager;

        #region DISPOSE
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dataManager?.Dispose();
            }
            base.Dispose(disposing);
        }
        
        #endregion
    }
}
