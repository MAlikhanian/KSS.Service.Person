using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class EmploymentPositionTranslationRepository : BaseRepository<PersonDbContext, EmploymentPositionTranslation>, IEmploymentPositionTranslationRepository
    {
        public EmploymentPositionTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
