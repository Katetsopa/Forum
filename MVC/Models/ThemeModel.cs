using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class ThemeModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Header { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string MainText { get; set; }
    }
}