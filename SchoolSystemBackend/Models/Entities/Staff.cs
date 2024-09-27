namespace SchoolSystemBackend.Models.Entities
{
    public class Staff : AppUser
    {
        public int NationalId { get; set; }
        public DateOnly EntranceDate { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
