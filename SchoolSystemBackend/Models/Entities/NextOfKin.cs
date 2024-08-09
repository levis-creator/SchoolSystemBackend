namespace SchoolSystemBackend.Models.Entities
{
    public class NextOfKin
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string EmailAddress { get; set; }=string.Empty;
        public required string PhoneNumber { get; set; }
        public required string Relationship { get; set; }
    }
}
