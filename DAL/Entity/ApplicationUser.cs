using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace DAL.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
