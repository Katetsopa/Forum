using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Theme
    {
        public int ThemeId { get; set; }
        public string Header { get; set; }
        public string MainText { get; set; }
     //   public DateTime date { get; set; }

       // public int UserId { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
}
