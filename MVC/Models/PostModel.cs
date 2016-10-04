using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class PostModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string MainText { get; set; }

        [Required]
        public int ThemeId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}