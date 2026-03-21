using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class MaritalStatusRepository : BaseRepository<PersonDbContext, MaritalStatus>, IMaritalStatusRepository
    {
        public MaritalStatusRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
