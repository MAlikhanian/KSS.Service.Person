using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class ProfessionalTrainingTypeRepository : BaseRepository<PersonDbContext, ProfessionalTrainingType>, IProfessionalTrainingTypeRepository
    {
        public ProfessionalTrainingTypeRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
