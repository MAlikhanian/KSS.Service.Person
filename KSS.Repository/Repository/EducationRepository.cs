using Microsoft.EntityFrameworkCore;
using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class EducationRepository : BaseRepository<PersonDbContext, Education>, IEducationRepository
    {
        public EducationRepository(PersonDbContext dbContext) : base(dbContext) { }

        // Eager-loads child documents so the Education section's edit dialog
        // sees the list immediately. After F.1, also includes the new
        // EducationDocumentType + its translations.
        public async Task<IEnumerable<Education>> ToListByPersonAsync(Guid personId)
        {
            return await InitialIQueryable()
                .Where(e => e.PersonId == personId)
                .Include(e => e.EducationDocuments)
                    .ThenInclude(ed => ed.EducationDocumentType)
                        .ThenInclude(t => t.Translations)
                .ToListAsync();
        }
    }
}
