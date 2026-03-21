using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class ReligionRepository : BaseRepository<PersonDbContext, Religion>, IReligionRepository
    {
        public ReligionRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
