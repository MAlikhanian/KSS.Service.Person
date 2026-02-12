using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class PersonTranslationRepository : BaseRepository<PersonDbContext, PersonTranslation>, IPersonTranslationRepository
    {
        public PersonTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
