using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class PostModel
    {
        // public int PostId { get; set; }
        [Required]
        public string MainText { get; set; }
        // public DateTime Date { get; set; }
       // public int UserId { get; set; }
        public int ThemeId { get; set; }
    }
}