using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class EmploymentDocumentRepository : BaseRepository<PersonDbContext, EmploymentDocument>, IEmploymentDocumentRepository
    {
        public EmploymentDocumentRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
