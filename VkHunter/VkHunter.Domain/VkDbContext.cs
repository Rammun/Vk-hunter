using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using VkHunter.Domain.Entities;

namespace VkHunter.Domain
{
    public class VkDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<TestModel> TestModels { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Search> Searches { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<History> Histories { get; set; }

        static VkDbContext()
        {
            Database.SetInitializer(new DbInitializer());
            using (var db = new VkDbContext())
                db.Database.Initialize(false);
        }

        public VkDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public VkDbContext(string connection)
             : base(connection)
        { }

        public static VkDbContext Create()
        {
            var dbContext = new VkDbContext();
            return dbContext;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Здесь подключаем настройки связей сущностей между собой

            //modelBuilder.Configurations.Add(new ProjectMapper());

            base.OnModelCreating(modelBuilder);
        }
    }
}
