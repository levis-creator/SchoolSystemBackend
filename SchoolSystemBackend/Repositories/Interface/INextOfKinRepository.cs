
using SchoolSystemBackend.Models.Entities;

namespace SchoolSystemBackend.Repositories.Interface
{
    public interface INextOfKinRepository
    {
        NextOfKin? GetByNationalId(int nationalId);
        IEnumerable<NextOfKin> GetAll();

    }
}
