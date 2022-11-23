using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACME_Web.Models
{
    public class EmployeeAssignedProject
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public DateTime DateAssigned { get; set; }

    }
}
