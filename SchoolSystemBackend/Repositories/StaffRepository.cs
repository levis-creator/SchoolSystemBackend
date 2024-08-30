using SchoolSystemBackend.Data;
using SchoolSystemBackend.Models.Dtos.Staff;
using SchoolSystemBackend.Models.Entities;
using SchoolSystemBackend.Repositories.Interface;

namespace SchoolSystemBackend.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly AppDbContext _context;

        public StaffRepository(AppDbContext context)
        {
            _context = context;
        }



        //Adding  data to db
        public Staff CreateStaff(AddStaffDto addStaffDto)
        {
            var staff = new Staff()
            {
                FirstName = addStaffDto.FirstName,
                LastName = addStaffDto.LastName,
                Gender = addStaffDto.Gender,
                DateOfBirth = addStaffDto.DateOfBirth,
                Department = addStaffDto.Department,
                NationalId = addStaffDto.NationalId,
                EntranceDate = addStaffDto.EntranceDate,
            };

            _context.Staff.Add(staff);
            _context.SaveChanges();
            return staff;
        }


        //deleting data from db
        public void DeleteStaffById(int id)
        {
            var staff = _context.Staff.Find(id);
            if (staff != null)
            {
                _context.Staff.Remove(staff);
                _context.SaveChanges();
            }
        }

        //fetching all data from db
        public IEnumerable<Staff> GetAllStaff()
        {
            var staffs = _context.Staff.ToList();
            return staffs;
        }

        //fetching single data from db
        public Staff? GetStaffById(int id)
        {
            var staff = _context.Staff.Find(id);
            if (staff != null)
            {
                return staff;
            }
            return null;
        }

        //updating data in db
        public Staff? UpdateStaffById(int id, UpdateStaffDto updateStaffDto)
        {
            var staff = _context.Staff.Find(id);
            if (staff != null)
            {
                staff.FirstName = updateStaffDto.FirstName;
                staff.LastName = updateStaffDto.LastName;
                staff.Gender = updateStaffDto.Gender;
                staff.DateOfBirth = updateStaffDto.DateOfBirth;
                staff.EntranceDate = updateStaffDto.EntranceDate;
                staff.Department = updateStaffDto.Department;
                staff.LastUpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return staff;
            }
            return null;
        }
    }
}
