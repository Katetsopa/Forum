using System.Collections.Generic;

namespace BLL.DTO
{
    public class ThemeDTO
    {
        public int ThemeId { get; set; }
        public string Header { get; set; }
        public string MainText { get; set; }
        public virtual List<PostDTO> Posts { get; set; }
    }
}
