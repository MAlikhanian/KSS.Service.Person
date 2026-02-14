using Microsoft.EntityFrameworkCore;
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

        public override async Task<IEnumerable<Person>> ToListAsync()
        {
            return await InitialIQueryable()
                .Include(p => p.Translations)
                .Include(p => p.Emails)
                .Include(p => p.Phones)
                .Include(p => p.Addresses)
                .Include(p => p.Employments)
                .ToListAsync();
        }
    }
}
