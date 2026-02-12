using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class SexRepository : BaseRepository<PersonDbContext, Sex>, ISexRepository
    {
        public SexRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
