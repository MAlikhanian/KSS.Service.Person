using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class StatusRepository : BaseRepository<PersonDbContext, Status>, IStatusRepository
    {
        public StatusRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
