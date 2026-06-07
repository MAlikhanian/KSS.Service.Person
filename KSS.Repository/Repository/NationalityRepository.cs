using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class NationalityRepository : BaseRepository<PersonDbContext, Nationality>, INationalityRepository
    {
        public NationalityRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
