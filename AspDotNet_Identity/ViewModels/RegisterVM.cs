using System.ComponentModel.DataAnnotations;

namespace AspDotNet_Identity.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="*")]
        [MinLength(5,ErrorMessage ="username must be greater than 5 letter")]
        public string Username { get; set; }
        [Required(ErrorMessage ="*")]
        public string Address { get; set; }
        [Required(ErrorMessage ="*")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password must match Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
