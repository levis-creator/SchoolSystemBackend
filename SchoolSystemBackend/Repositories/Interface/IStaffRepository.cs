using SchoolSystemBackend.Models.Dtos.Staff;
using SchoolSystemBackend.Models.Entities;

namespace SchoolSystemBackend.Repositories.Interface
{
    public interface IStaffRepository
    {
        IEnumerable<Staff> GetAllStaff();
        //create data
        Staff CreateStaff(AddStaffDto addStaffDto);
        //get singledata
        Staff? GetStaffById(int id);
        //update
        Staff? UpdateStaffById(int id, UpdateStaffDto updateStaffDto);
        //delete
        void DeleteStaffById(int id);
    }
}
