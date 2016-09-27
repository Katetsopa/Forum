using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ThemeDTO
    {
        public int ThemeId { get; set; }
        public string Header { get; set; }
        public string MainText { get; set; }
      //  public DateTime date { get; set; }

        // public int UserId { get; set; }
        public virtual List<PostDTO> Posts { get; set; }
    }
}
