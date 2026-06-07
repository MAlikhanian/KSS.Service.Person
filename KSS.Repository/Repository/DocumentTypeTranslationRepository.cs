using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class DocumentTypeTranslationRepository : BaseRepository<PersonDbContext, DocumentTypeTranslation>, IDocumentTypeTranslationRepository
    {
        public DocumentTypeTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
