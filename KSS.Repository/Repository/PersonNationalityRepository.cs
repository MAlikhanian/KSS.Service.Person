using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class PersonNationalityRepository : BaseRepository<PersonDbContext, PersonNationality>, IPersonNationalityRepository
    {
        public PersonNationalityRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
