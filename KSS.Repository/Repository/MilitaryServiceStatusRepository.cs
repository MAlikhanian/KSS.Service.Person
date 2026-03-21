using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class MilitaryServiceStatusRepository : BaseRepository<PersonDbContext, MilitaryServiceStatus>, IMilitaryServiceStatusRepository
    {
        public MilitaryServiceStatusRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
