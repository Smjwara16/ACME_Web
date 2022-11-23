using System.ComponentModel.DataAnnotations;

namespace ACME_Web.Models
{
    public class BusinessProjects
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public bool IsValid { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

    }
}
