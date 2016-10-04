using DAL.Entity;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class ClientManager : IClientManager
    { 

        public ForumContext Database { get; set; }

        public ClientManager(ForumContext db)
        {
            Database = db;
        }

        public void Create(ApplicationUser item)
        {
                Database.Users.Add(item);
                Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
