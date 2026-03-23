using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class PersonStatusRepository : BaseRepository<PersonDbContext, PersonStatus>, IPersonStatusRepository
    {
        public PersonStatusRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
