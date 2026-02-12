using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class RelationshipTypeTranslationRepository : BaseRepository<PersonDbContext, RelationshipTypeTranslation>, IRelationshipTypeTranslationRepository
    {
        public RelationshipTypeTranslationRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
