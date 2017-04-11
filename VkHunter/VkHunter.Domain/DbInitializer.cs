using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using VkHunter.Common.Helpers;
using VkHunter.Domain.Constants;
using VkHunter.Domain.Entities;

namespace VkHunter.Domain
{
    internal class DbInitializer : DropCreateDatabaseIfModelChanges<VkDbContext> // DropCreateDatabaseIfModelChanges  CreateDatabaseIfNotExists
    {
        public override void InitializeDatabase(VkDbContext context)
        {
            base.InitializeDatabase(context);
            
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (userManager.Users.Any())
                return;

            var userName = CommonHelper.GetConfigOrDefault(DefaultSetting.AdminUserNameKey, DefaultSetting.AdminUserName);
            var password = CommonHelper.GetConfigOrDefault(DefaultSetting.AdminPasswordKey, DefaultSetting.AdminPassword);

            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
                EmailConfirmed = true
            };
            userManager.Create(user, password);

            var project = new Project
            {
                Name = "TestProject",
                Active = true
            };
            
            var search = new Search
            {
                Query = "Test",
                Active = true
            };

            project.Searches.Add(search);
            context.Projects.Add(project);

            context.SaveChanges();
        }
    }
}
