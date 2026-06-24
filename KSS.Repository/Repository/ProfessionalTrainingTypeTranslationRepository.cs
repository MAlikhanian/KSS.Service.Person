using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class ProfessionalTrainingTypeTranslationRepository : BaseRepository<PersonDbContext, ProfessionalTrainingTypeTranslation>, IProfessionalTrainingTypeTranslationRepository
    {
        public ProfessionalTrainingTypeTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
