using System.ComponentModel.DataAnnotations;

namespace ACME_Web.Models.ViewModels
{
    public class RegisterUser
    {
        [Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage = "Must match the initial Password")]
        public string ConfirmPassword { get; set; }
    }
}
