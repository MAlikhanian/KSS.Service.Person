using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class ProfessionalTrainingDocumentTypeRepository : BaseRepository<PersonDbContext, ProfessionalTrainingDocumentType>, IProfessionalTrainingDocumentTypeRepository
    {
        public ProfessionalTrainingDocumentTypeRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
