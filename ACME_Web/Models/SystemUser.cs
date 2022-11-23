using System.ComponentModel.DataAnnotations;

namespace ACME_Web.Models
{
    public class SystemUser
    {
        [Key]
        public int SystemUserId { get; set; }
        [Required, Display(Name = "User Name")]
        public string? UserName { get; set; }
        [Required, Display(Name = "Password")]
        public string? UserPassword { get; set; }
        [Required, EmailAddress, Display(Name = "Email Address")]
        public string? EmailAddress { get; set; }
        [Required, Phone, Display(Name = "Cellphone Number")]
        public string? CellPhoneNumber { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public int RoleId { get; set; }
    }
}
