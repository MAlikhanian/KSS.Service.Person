using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class FieldOfStudyTranslationRepository : BaseRepository<PersonDbContext, FieldOfStudyTranslation>, IFieldOfStudyTranslationRepository
    {
        public FieldOfStudyTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
