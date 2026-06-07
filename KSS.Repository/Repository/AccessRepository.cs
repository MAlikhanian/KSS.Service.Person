using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class AccessRepository : BaseRepository<PersonDbContext, Access>, IAccessRepository
    {
        public AccessRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
