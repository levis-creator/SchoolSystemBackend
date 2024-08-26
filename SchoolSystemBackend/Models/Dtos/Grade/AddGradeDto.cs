namespace SchoolSystemBackend.Models.Dtos.Grade
{
    public class AddGradeDto
    {
        public required string GradeName { get; set; }
        public string Description { get; set; } = string.Empty;
        public Guid? StreamId { get; set; }
    }
}
