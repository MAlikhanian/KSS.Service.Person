using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class ProfessionalTrainingDocumentRepository : BaseRepository<PersonDbContext, ProfessionalTrainingDocument>, IProfessionalTrainingDocumentRepository
    {
        public ProfessionalTrainingDocumentRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
