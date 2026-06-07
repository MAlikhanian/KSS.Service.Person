using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class EmploymentDocumentTypeRepository : BaseRepository<PersonDbContext, EmploymentDocumentType>, IEmploymentDocumentTypeRepository
    {
        public EmploymentDocumentTypeRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
