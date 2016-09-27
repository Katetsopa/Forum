using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ErrorModel
    {
        [Required]
        public string ErrorMessge { get; set; }
    }
}