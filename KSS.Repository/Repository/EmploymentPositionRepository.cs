using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class EmploymentPositionRepository : BaseRepository<PersonDbContext, EmploymentPosition>, IEmploymentPositionRepository
    {
        public EmploymentPositionRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
