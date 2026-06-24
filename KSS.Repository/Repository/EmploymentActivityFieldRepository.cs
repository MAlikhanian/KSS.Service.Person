using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class EmploymentActivityFieldRepository : BaseRepository<PersonDbContext, EmploymentActivityField>, IEmploymentActivityFieldRepository
    {
        public EmploymentActivityFieldRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
