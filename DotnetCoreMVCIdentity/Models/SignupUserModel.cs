using System.ComponentModel.DataAnnotations;

namespace DotnetCoreMVCIdentity.Models
{
#nullable disable
    public class SignupUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please Enter your email")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Pleasen Enter your password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage ="Please Confirm your password")]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and Confirm Password didn't match")]
        public string ConfirmPassword { get; set; }
    }
}
