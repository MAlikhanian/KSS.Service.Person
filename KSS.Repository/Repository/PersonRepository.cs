using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class PersonRepository : BaseRepository<PersonDbContext, Person>, IPersonRepository
    {
        public PersonRepository(PersonDbContext dbContext) : base(dbContext)
        {
        }
    }
}
