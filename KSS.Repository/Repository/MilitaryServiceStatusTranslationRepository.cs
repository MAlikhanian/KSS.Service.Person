using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class MilitaryServiceStatusTranslationRepository : BaseRepository<PersonDbContext, MilitaryServiceStatusTranslation>, IMilitaryServiceStatusTranslationRepository
    {
        public MilitaryServiceStatusTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
