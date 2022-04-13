using System.ComponentModel.DataAnnotations;

namespace DotnetCoreIdentity.ViewModel
{
#nullable disable
    public class Register
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Password and Confirm Password didn't match")]
        public string ConfirmPassword { get; set; }
    }
}
