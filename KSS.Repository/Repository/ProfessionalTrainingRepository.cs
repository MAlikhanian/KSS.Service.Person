using Microsoft.EntityFrameworkCore;
using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class ProfessionalTrainingRepository : BaseRepository<PersonDbContext, ProfessionalTraining>, IProfessionalTrainingRepository
    {
        public ProfessionalTrainingRepository(PersonDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<ProfessionalTraining>> ToListByPersonAsync(Guid personId)
        {
            return await InitialIQueryable()
                .Where(e => e.PersonId == personId)
                .Include(e => e.ProfessionalTrainingDocuments)
                    .ThenInclude(ed => ed.ProfessionalTrainingDocumentType)
                        .ThenInclude(t => t.Translations)
                .ToListAsync();
        }
    }
}
