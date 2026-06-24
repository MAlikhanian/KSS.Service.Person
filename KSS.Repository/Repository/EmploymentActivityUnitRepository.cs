using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class EmploymentActivityUnitRepository : BaseRepository<PersonDbContext, EmploymentActivityUnit>, IEmploymentActivityUnitRepository
    {
        public EmploymentActivityUnitRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
