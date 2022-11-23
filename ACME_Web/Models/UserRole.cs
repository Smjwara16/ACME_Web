using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ACME_Web.Models
{
    public class UserRole
    {
        [Key]
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? Description { get; set; }
    }
}
