using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class InsuranceTypeTranslationRepository : BaseRepository<PersonDbContext, InsuranceTypeTranslation>, IInsuranceTypeTranslationRepository
    {
        public InsuranceTypeTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
