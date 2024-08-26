using SchoolSystemBackend.Models.Dtos.Stream;
using SchoolSystemBackend.Models.Entities;

namespace SchoolSystemBackend.Repositories.Interface
{
    public interface IClassStreamRepository
    {
        IEnumerable<ClassStream> GetAllClassStreams();
        ClassStream CreateClassStream(AddClassStreamDto classStreamDto);
        ClassStream? GetClassStreamById(Guid id);
        ClassStream? UpdateClassStream(Guid id, UpdateClassStreamDto updateClassStreamDto);
        bool DeleteClassStream(Guid id);
    }
}
