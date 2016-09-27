using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
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
