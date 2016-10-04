using System.Collections.Generic;

namespace DAL.Entity
{
    public class Theme
    {
        public int ThemeId { get; set; }
        public string Header { get; set; }
        public string MainText { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
}
