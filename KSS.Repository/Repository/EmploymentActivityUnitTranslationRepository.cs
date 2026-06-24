using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class EmploymentActivityUnitTranslationRepository : BaseRepository<PersonDbContext, EmploymentActivityUnitTranslation>, IEmploymentActivityUnitTranslationRepository
    {
        public EmploymentActivityUnitTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
