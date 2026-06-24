using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class EmploymentActivityFieldTranslationRepository : BaseRepository<PersonDbContext, EmploymentActivityFieldTranslation>, IEmploymentActivityFieldTranslationRepository
    {
        public EmploymentActivityFieldTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
