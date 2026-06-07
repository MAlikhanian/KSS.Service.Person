using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class InstitutionTranslationRepository : BaseRepository<PersonDbContext, InstitutionTranslation>, IInstitutionTranslationRepository
    {
        public InstitutionTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
