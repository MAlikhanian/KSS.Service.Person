using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class ReligionTranslationRepository : BaseRepository<PersonDbContext, ReligionTranslation>, IReligionTranslationRepository
    {
        public ReligionTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
