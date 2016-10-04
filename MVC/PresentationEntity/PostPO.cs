using System.ComponentModel.DataAnnotations;

namespace MVC.PresentationEntity
{
    public class PostPO
    {

        public int PostId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string MainText { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int ThemeId { get; set; }
    }

}