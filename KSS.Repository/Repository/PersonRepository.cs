using Microsoft.EntityFrameworkCore;
using KSS.Entity;
using KSS.Helper;
using KSS.Helper.Model;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class PersonRepository : BaseRepository<PersonDbContext, Person>, IPersonRepository
    {
        public PersonRepository(PersonDbContext dbContext) : base(dbContext)
        {
        }

        // List path — kept light. Only Translations join, used by the selector
        // (shows id + nationalId + names). Sub-collections are fetched on demand
        // via the per-section endpoints (Email/Phone/Address/Education/etc.).
        public override async Task<IEnumerable<Person>> ToListAsync()
        {
            return await InitialIQueryable()
                .Include(p => p.Translations)
                .ToListAsync();
        }

        // Detail path — used by the form's scalar hydration and any caller
        // that needs a single Person by id. Includes Translations so the name
        // grid populates immediately. All other sub-collections (emails, phones,
        // addresses, educations, employments, …) are fetched separately by
        // their section components via the per-section endpoints.
        public override async Task<Person?> FindAsync(Filter id)
        {
            var personId = (Guid)Assistant.FilterGetValue(id);
            return await InitialIQueryable()
                .Include(p => p.Translations)
                .SingleOrDefaultAsync(p => p.Id == personId);
        }
    }
}
