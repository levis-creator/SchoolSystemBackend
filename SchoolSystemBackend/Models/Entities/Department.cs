using System.ComponentModel.DataAnnotations;

namespace SchoolSystemBackend.Models.Entities
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; } = "";
        public IEnumerable<Staff> Staffs { get; set; } = [];
    }
}
