using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class MaritalStatusTranslationRepository : BaseRepository<PersonDbContext, MaritalStatusTranslation>, IMaritalStatusTranslationRepository
    {
        public MaritalStatusTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
