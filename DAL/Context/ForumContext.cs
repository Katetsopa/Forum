using System.Data.Entity;
using DAL.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL
{
    public class ForumContext : IdentityDbContext<ApplicationUser>
    {
        public ForumContext() : base("ForumContext")
        {
        }

        public ForumContext(string nameOrConnectionString) 
            : base(nameOrConnectionString)
        {
        }

        public static ForumContext Create()
        {
            return new ForumContext();
        }

        public virtual DbSet<Theme> Themes { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
    }


    class ContextInitializer : DropCreateDatabaseAlways<ForumContext>
    {
        protected override void Seed(ForumContext context)
        {
             base.Seed(context);
        }
    }
}
