using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class TranslationRepository : BaseRepository<PersonDbContext, Translation>, ITranslationRepository
    {
        public TranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
