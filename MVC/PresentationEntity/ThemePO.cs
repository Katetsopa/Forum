﻿using System.Collections.Generic;

namespace MVC.PresentationEntity
{
    public class ThemePO
    {
        public int ThemeId { get; set; }
        public string Header { get; set; }
        public string MainText { get; set; }
        public virtual List<PostPO> Posts { get; set; }
    }
}