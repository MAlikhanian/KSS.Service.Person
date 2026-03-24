using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class JobPositionTranslationRepository : BaseRepository<PersonDbContext, JobPositionTranslation>, IJobPositionTranslationRepository
    {
        public JobPositionTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
