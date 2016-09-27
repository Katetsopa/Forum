using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ThemeModel
    {
        //public int ThemeId { get; set; }
        [Required]
        public string Header { get; set; }
        [Required]
        public string MainText { get; set; }
        //   public DateTime date { get; set; }

        // public int UserId { get; set; }
        //public virtual List<Post> Posts { get; set; }
    }
}