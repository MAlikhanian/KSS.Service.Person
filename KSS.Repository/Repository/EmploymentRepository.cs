using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class EmploymentRepository : BaseRepository<PersonDbContext, Employment>, IEmploymentRepository
    {
        public EmploymentRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
