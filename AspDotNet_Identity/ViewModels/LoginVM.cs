using System.ComponentModel.DataAnnotations;

namespace AspDotNet_Identity.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="*")]
        public string username { get; set; }
        [Required(ErrorMessage ="*")]
        public string Password { get; set; }
        public bool IsPresistent { get; set; }
    }
}
