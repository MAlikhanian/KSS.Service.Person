using Microsoft.EntityFrameworkCore;
using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class EmploymentRepository : BaseRepository<PersonDbContext, Employment>, IEmploymentRepository
    {
        public EmploymentRepository(PersonDbContext dbContext) : base(dbContext) { }

        // Eager-loads child documents (and after F.1, the new
        // EmploymentDocumentType + its translations).
        public async Task<IEnumerable<Employment>> ToListByPersonAsync(Guid personId)
        {
            return await InitialIQueryable()
                .Where(e => e.PersonId == personId)
                .Include(e => e.EmploymentDocuments)
                    .ThenInclude(ed => ed.EmploymentDocumentType)
                        .ThenInclude(t => t.Translations)
                .ToListAsync();
        }
    }
}
