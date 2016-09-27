using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL
{
    public class ForumContext : IdentityDbContext<ApplicationUser>
    {
        public ForumContext() : base("ForumContext")
        {
           // Database.SetInitializer<ForumContext>(new ContextInitializer());
        }

        public ForumContext(string nameOrConnectionString) : base(nameOrConnectionString)
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
            //ClientProfile user1 = new ClientProfile() { UserId = 1, Name = "Sergey",Email  = "serg@ukr.net", Password = "88888888"};
            //ClientProfile user2 = new ClientProfile() { UserId = 2, Name = "Kate", Email = "kate@ukr.net", Password = "88889999"};
            //ClientProfile user3 = new ClientProfile() { UserId = 3, Name = "Olya", Email = "olyoly@ukr.net", Password = "77777777"};
            //ClientProfile user4 = new ClientProfile() { UserId = 4, Name = "Dima", Email = "Dmitry@ukr.net", Password = "66666666"};

            //Theme t1 = new Theme() { ThemeId = 1, Header = "Внимание!!!", MainText = "Открытие нового магазина сантехники!", date = DateTime.Now };
            //Theme t2 = new Theme() { ThemeId = 2, Header = "Требуется менеджер", MainText = @"В компанию 'Рога и копыта' требуеться менеджер, за дополнительной информацией обращайтесь по телефону: 098 765 9821", date = DateTime.Now };


            //Post p1 = new Post() { PostId = 1, MainText = "Хочу купить новый унитаз!", ThemeId = 1, Date = DateTime.Now, UserId = 3 };
            //Post p2 = new Post() { PostId = 2, MainText = "Как жаль, что не хочу быть менеджером", ThemeId = 2, Date = DateTime.Now, UserId = 3 };
            //Post p3 = new Post() { PostId = 3, MainText = "Моя подруга как раз ищет себе работу", ThemeId = 2, Date = DateTime.Now, UserId = 2 };
            //Post p4 = new Post() { PostId = 4, MainText = "Интересно, а будут скидки в честь открытия?", ThemeId = 1, Date = DateTime.Now, UserId = 4 };

            //ApplicationUser ap1 = new ApplicationUser() { ClientProfile = user1  };
            //ApplicationUser ap2 = new ApplicationUser() { ClientProfile = user2 };
            //ApplicationUser ap3 = new ApplicationUser() { ClientProfile = user3 };
            //ApplicationUser ap4 = new ApplicationUser() { ClientProfile = user4 };

            //context.Users.Add(ap1);
            //context.Users.Add(ap2);
            //context.Users.Add(ap3);
            //context.Users.Add(ap4);

//            context.Themes.Add(t1);
 //           context.Themes.Add(t2);

            //context.Posts.Add(p1);
            //context.Posts.Add(p2);
            //context.Posts.Add(p3);
            //context.Posts.Add(p4);

   //         context.SaveChanges();

        }
    }
}
