namespace SchoolSystemBackend.Models.Entities
{
    public class AppUserNextOfKin
    {
        public int AppUserId { get; set; }
        public int NextOfKinId { get; set; }
        public AppUser AppUser { get; set; }
        public NextOfKin NextOfKin { get; set; }
    }
}
