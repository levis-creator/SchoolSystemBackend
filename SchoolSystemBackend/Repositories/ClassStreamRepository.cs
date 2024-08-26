using SchoolSystemBackend.Data;
using SchoolSystemBackend.Models.Dtos.Stream;
using SchoolSystemBackend.Models.Entities;
using SchoolSystemBackend.Repositories.Interface;

namespace SchoolSystemBackend.Repositories
{
    public class ClassStreamRepository : IClassStreamRepository
    {
        private AppDbContext _context;

        public ClassStreamRepository(AppDbContext context)
        {
            _context = context;
        }

        public ClassStream CreateClassStream(AddClassStreamDto classStreamDto)
        {
            var _classStream = new ClassStream()
            {
                StreamName = classStreamDto.StreamName,
                Description = classStreamDto.Description,
            };
            _context.ClassStreams.Add(_classStream);
            _context.SaveChanges();
            return _classStream;
        }

        public bool DeleteClassStream(Guid id)
        {
            var classStream = GetClassStreamById(id);
            if (classStream != null)
            {
                _context.ClassStreams.Remove(classStream);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<ClassStream> GetAllClassStreams()
        {
            var classStream = _context.ClassStreams.ToList();
            return classStream;
        }

        public ClassStream? GetClassStreamById(Guid id)
        {
            var classStream = _context.ClassStreams.Find(id);
            if (classStream != null)
            {
                return classStream;
            }
            return null;
        }

        public ClassStream? UpdateClassStream(Guid id, UpdateClassStreamDto updateClassStreamDto)
        {
            var currentClassStream = GetClassStreamById(id);
            if (currentClassStream != null)
            {
                currentClassStream.StreamName = updateClassStreamDto.StreamName;
                currentClassStream.Description = updateClassStreamDto.Description;
                currentClassStream.LastUpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return currentClassStream;
            }
            return null;
        }
    }
}
