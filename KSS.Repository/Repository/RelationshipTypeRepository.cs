using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class RelationshipTypeRepository : BaseRepository<PersonDbContext, RelationshipType>, IRelationshipTypeRepository
    {
        public RelationshipTypeRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
