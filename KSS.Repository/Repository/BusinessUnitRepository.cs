using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class BusinessUnitRepository : BaseRepository<PersonDbContext, BusinessUnit>, IBusinessUnitRepository
    {
        public BusinessUnitRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
