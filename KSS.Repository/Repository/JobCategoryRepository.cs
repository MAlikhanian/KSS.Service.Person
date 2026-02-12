using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class JobCategoryRepository : BaseRepository<PersonDbContext, JobCategory>, IJobCategoryRepository
    {
        public JobCategoryRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
