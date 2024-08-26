using SchoolSystemBackend.Models.Dtos.Grade;
using SchoolSystemBackend.Models.Entities;

namespace SchoolSystemBackend.Repositories.Interface
{
    public interface IGradesRepository
    {
        IEnumerable<Grade> GetAllGrades();
        Grade CreateGrade(AddGradeDto gradeDto);
        Grade? GetGradeById(Guid id);
        Grade? UpdateGrade(Guid id, UpdateGradeDto gradeDto);
        bool DeleteGrade(Guid id);
    }
}
