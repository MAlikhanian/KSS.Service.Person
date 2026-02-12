using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class SexTranslationRepository : BaseRepository<PersonDbContext, SexTranslation>, ISexTranslationRepository
    {
        public SexTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
