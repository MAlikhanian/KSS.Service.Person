using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class JobTitleRepository : BaseRepository<PersonDbContext, JobTitle>, IJobTitleRepository
    {
        public JobTitleRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
