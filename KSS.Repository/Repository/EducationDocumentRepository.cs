using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class EducationDocumentRepository : BaseRepository<PersonDbContext, EducationDocument>, IEducationDocumentRepository
    {
        public EducationDocumentRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
