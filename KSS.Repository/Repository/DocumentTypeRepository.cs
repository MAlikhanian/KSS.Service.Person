using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class DocumentTypeRepository : BaseRepository<PersonDbContext, DocumentType>, IDocumentTypeRepository
    {
        public DocumentTypeRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
