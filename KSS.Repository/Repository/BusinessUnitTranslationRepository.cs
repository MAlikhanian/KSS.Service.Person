using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class BusinessUnitTranslationRepository : BaseRepository<PersonDbContext, BusinessUnitTranslation>, IBusinessUnitTranslationRepository
    {
        public BusinessUnitTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
