using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class MilitaryServiceLocationTranslationRepository : BaseRepository<PersonDbContext, MilitaryServiceLocationTranslation>, IMilitaryServiceLocationTranslationRepository
    {
        public MilitaryServiceLocationTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
