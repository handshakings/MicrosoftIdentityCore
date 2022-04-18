using System.ComponentModel.DataAnnotations;

namespace DotnetCoreMVCIdentity.Models
{
#nullable disable
    public class ChangePasswordModel
    {
        [Required, DataType(DataType.Password), Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required, DataType(DataType.Password), Display(Name ="New Password")]
        public string NewPassword { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Confirm New Password")]
        [Compare(nameof(NewPassword),ErrorMessage ="New Password and Confirm New Password does not match")]
        public string ConfirmNewPassword { get; set; }
    }
}
