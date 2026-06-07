using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class EducationDocumentTypeTranslationRepository : BaseRepository<PersonDbContext, EducationDocumentTypeTranslation>, IEducationDocumentTypeTranslationRepository
    {
        public EducationDocumentTypeTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
