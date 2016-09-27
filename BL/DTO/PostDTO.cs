using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PostDTO
    {
        public int PostId { get; set; }
        public string MainText { get; set; }
       // public DateTime Date { get; set; }
        public string UserId { get; set; }
        public int ThemeId { get; set; }
    }
}
