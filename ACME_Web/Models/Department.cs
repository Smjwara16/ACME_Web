using System.ComponentModel.DataAnnotations;

namespace ACME_Web.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
