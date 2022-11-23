using System.ComponentModel.DataAnnotations;

namespace ACME_Web.Models
{
    public class EmployeeDetail
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public int SystemUserId { get; set; }
        [Required, Display(Name = "First Name")]
        public string? FullName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required, DataType(DataType.MultilineText)]
        public string? Address { get; set; }
        [Required]
        public int EmpAssignedProjectId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;


    }
}
