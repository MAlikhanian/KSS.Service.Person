using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class JobCategoryTranslationRepository : BaseRepository<PersonDbContext, JobCategoryTranslation>, IJobCategoryTranslationRepository
    {
        public JobCategoryTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
