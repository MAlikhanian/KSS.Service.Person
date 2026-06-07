using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class EducationDocumentTypeRepository : BaseRepository<PersonDbContext, EducationDocumentType>, IEducationDocumentTypeRepository
    {
        public EducationDocumentTypeRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
