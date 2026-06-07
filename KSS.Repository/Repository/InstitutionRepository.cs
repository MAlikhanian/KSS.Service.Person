using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class InstitutionRepository : BaseRepository<PersonDbContext, Institution>, IInstitutionRepository
    {
        public InstitutionRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
