using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class JobPositionRepository : BaseRepository<PersonDbContext, JobPosition>, IJobPositionRepository
    {
        public JobPositionRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
