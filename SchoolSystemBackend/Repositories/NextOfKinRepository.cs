using SchoolSystemBackend.Data;
using SchoolSystemBackend.Models.Entities;
using SchoolSystemBackend.Repositories.Interface;

namespace SchoolSystemBackend.Repositories
{
    public class NextOfKinRepository : INextOfKinRepository
    {
        private AppDbContext context;
        public NextOfKinRepository(AppDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<NextOfKin> GetAll()
        {
            return context.NextOfKins.ToList();
        }


        public NextOfKin? GetByNationalId(int nationalId)
        {
            var nextofkin = context.NextOfKins.SingleOrDefault(n=>n.NationalId==nationalId);
            if (nextofkin == null) {
                return null;
            }
            return nextofkin;
        }
       
    }
}
