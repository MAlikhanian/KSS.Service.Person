using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class EmploymentDocumentTypeTranslationRepository : BaseRepository<PersonDbContext, EmploymentDocumentTypeTranslation>, IEmploymentDocumentTypeTranslationRepository
    {
        public EmploymentDocumentTypeTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
