using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class EducationLevelTranslationRepository : BaseRepository<PersonDbContext, EducationLevelTranslation>, IEducationLevelTranslationRepository
    {
        public EducationLevelTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
