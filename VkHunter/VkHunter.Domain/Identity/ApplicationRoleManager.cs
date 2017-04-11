using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace VkHunter.Domain.Identity
{
    public class ApplicationRoleManager : RoleManager<IdentityRole<int, IdentityUserRole<int>>, int>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole<int, IdentityUserRole<int>>, int> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<IdentityRole<int, IdentityUserRole<int>>, int, IdentityUserRole<int>>(context.Get<VkDbContext>()));
        }
    }
}
