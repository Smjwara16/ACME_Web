using System.ComponentModel.DataAnnotations;

namespace ACME_Web.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Details { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;


    }
}
