using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class MilitaryServiceLocationRepository : BaseRepository<PersonDbContext, MilitaryServiceLocation>, IMilitaryServiceLocationRepository
    {
        public MilitaryServiceLocationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
