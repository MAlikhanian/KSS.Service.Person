using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class ProfessionalTrainingDocumentTypeTranslationRepository : BaseRepository<PersonDbContext, ProfessionalTrainingDocumentTypeTranslation>, IProfessionalTrainingDocumentTypeTranslationRepository
    {
        public ProfessionalTrainingDocumentTypeTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
