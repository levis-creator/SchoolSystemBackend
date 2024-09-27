using System.ComponentModel.DataAnnotations;

namespace SchoolSystemBackend.Models.Dtos.Departments
{
    public class DepartmentListDto
    {
     
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = "";
    }
}
