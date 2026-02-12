using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class RelationshipRepository : BaseRepository<PersonDbContext, Relationship>, IRelationshipRepository
    {
        public RelationshipRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
