namespace SchoolSystemBackend.Models.Dtos.Stream
{
    public class UpdateClassStreamDto
    {
        public required string StreamName { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
