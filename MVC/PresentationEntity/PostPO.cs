﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.PresentationEntity
{
    public class PostPO
    {
        public int PostId { get; set; }
        public string MainText { get; set; }

        //[DataType (DataType.DateTime)]
        //public DateTime Date { get; set; }
        public string UserId { get; set; }
        public int ThemeId { get; set; }
    }

}