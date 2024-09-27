using SchoolSystemBackend.Models.Dtos.Departments;
using SchoolSystemBackend.Models.Entities;

namespace SchoolSystemBackend.Repositories.Interface
{
    public interface IDepartmentRepository
    {
        IEnumerable<DepartmentListDto> GetAllDepartments();
        Department GetByName(string name);
        Department? CreateDepartment(AddDepartmentDto department);
    }
}
