using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class DocumentRepository : BaseRepository<PersonDbContext, Document>, IDocumentRepository
    {
        public DocumentRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
