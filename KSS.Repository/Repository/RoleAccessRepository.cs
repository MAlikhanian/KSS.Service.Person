using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class RoleAccessRepository : BaseRepository<PersonDbContext, RoleAccess>, IRoleAccessRepository
    {
        public RoleAccessRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
