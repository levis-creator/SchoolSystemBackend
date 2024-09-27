using System.ComponentModel.DataAnnotations;

namespace SchoolSystemBackend.Models.Dtos.Departments
{
    public class AddDepartmentDto
    {
        [Required]
        public string DepartmentName { get; set; } = "";
    }
}
