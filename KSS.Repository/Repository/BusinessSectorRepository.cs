using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class BusinessSectorRepository : BaseRepository<PersonDbContext, BusinessSector>, IBusinessSectorRepository
    {
        public BusinessSectorRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
