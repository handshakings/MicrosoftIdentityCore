using System.ComponentModel.DataAnnotations;

namespace DotnetCoreMVCIdentity.Models
{
#nullable disable
    public class LoginUserModel
    {
        [Required(ErrorMessage ="Email is required"), Display(Name = "Email : "), DataType(DataType.EmailAddress)]
        public string Email { get; set;}


        [Required(ErrorMessage = "Password is required"), Display(Name = "Password : "), DataType(DataType.Password)]
        public string Password { get; set;}

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set;}
    }
}
