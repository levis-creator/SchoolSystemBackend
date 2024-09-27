using SchoolSystemBackend.Data;
using SchoolSystemBackend.Models.Dtos.Departments;
using SchoolSystemBackend.Models.Entities;
using SchoolSystemBackend.Repositories.Interface;

namespace SchoolSystemBackend.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly  AppDbContext context;

        public DepartmentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Department? CreateDepartment(AddDepartmentDto department)
        {
            Department departmentNew = new Department()
           {
               DepartmentName=department.DepartmentName
           };
            context.Add(departmentNew);
            context.SaveChanges();
            return departmentNew;
        }

        public IEnumerable<DepartmentListDto> GetAllDepartments()
        {
            return context.Departments
                .Select(d=>new DepartmentListDto() {DepartmentId=d.DepartmentId,
                    DepartmentName = d.DepartmentName
                })
                .ToList();
        }

        public Department GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
