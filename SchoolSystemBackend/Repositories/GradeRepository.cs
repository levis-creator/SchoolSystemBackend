using SchoolSystemBackend.Data;
using SchoolSystemBackend.Models.Dtos.Grade;
using SchoolSystemBackend.Models.Entities;
using SchoolSystemBackend.Repositories.Interface;

namespace SchoolSystemBackend.Repositories
{
    public class GradeRepository : IGradesRepository
    {
        private AppDbContext _appDbContext;
        public GradeRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public Grade CreateGrade(AddGradeDto gradeDto)
        {
            var grade = new Grade() { 
                GradeName = gradeDto.GradeName,
                Description = gradeDto.Description, 
                StreamId = gradeDto.StreamId };
            _appDbContext.Grades.Add(grade);
            _appDbContext.SaveChanges();
            return grade;
        }

        public bool DeleteGrade(Guid id)
        {
            var grade = GetGradeById(id);
            if (grade != null)
            {
                _appDbContext.Grades.Remove(grade);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Grade> GetAllGrades()
        {
            return _appDbContext.Grades.ToList();
        }

        public Grade? GetGradeById(Guid id)
        {
            var grade = _appDbContext.Grades.Find(id);
            if (grade != null)
            {
                return grade;
            }
            return null;
        }

        public Grade? UpdateGrade(Guid id, UpdateGradeDto gradeDto)
        {
            var currentGrade = GetGradeById(id);
            if (currentGrade != null)
            {
                currentGrade.GradeName = gradeDto.GradeName;
                currentGrade.Description = gradeDto.Description;
                currentGrade.StreamId = currentGrade.StreamId;
                currentGrade.LastUpdatedAt = DateTime.Now;
                _appDbContext.SaveChanges();
                return currentGrade;
            }
            return null;
        }
    }
}
