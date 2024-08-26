namespace SchoolSystemBackend.Models.Dtos.NextOfKins
{
    public class AddNextOfKinDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public required string PhoneNumber { get; set; }
        public required string Relationship { get; set; }
        public int NationalId { get; set; }
    }
}
