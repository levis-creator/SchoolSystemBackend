namespace SchoolSystemBackend.Models.Entities
{
    public class Staff:AppUser
    {
        public int NationalId { get; set; }
        public DateOnly EntranceDate { get; set; }
        public string Department { get; set; }=string.Empty;
    }
}
