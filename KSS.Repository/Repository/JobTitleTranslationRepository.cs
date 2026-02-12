using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class JobTitleTranslationRepository : BaseRepository<PersonDbContext, JobTitleTranslation>, IJobTitleTranslationRepository
    {
        public JobTitleTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
