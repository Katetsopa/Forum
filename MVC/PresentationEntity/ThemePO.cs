using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.PresentationEntity
{
    public class ThemePO
    {
        public int ThemeId { get; set; }
        public string Header { get; set; }
        public string MainText { get; set; }
        //public DateTime date { get; set; }

        // public int UserId { get; set; }
        public virtual List<PostPO> Posts { get; set; }
    }
}