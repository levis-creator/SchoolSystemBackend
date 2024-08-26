namespace SchoolSystemBackend.Models.Dtos.Stream
{
    public class AddClassStreamDto
    {
        public required string StreamName { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
