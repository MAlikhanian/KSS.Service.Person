using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class JobDepartmentTranslationRepository : BaseRepository<PersonDbContext, JobDepartmentTranslation>, IJobDepartmentTranslationRepository
    {
        public JobDepartmentTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
