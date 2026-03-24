using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class BusinessSectorTranslationRepository : BaseRepository<PersonDbContext, BusinessSectorTranslation>, IBusinessSectorTranslationRepository
    {
        public BusinessSectorTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
