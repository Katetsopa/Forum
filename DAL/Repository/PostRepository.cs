using DAL.Entity;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(ForumContext context) : base(context)
        {
        }
    }
}
