using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class InsuranceTypeRepository : BaseRepository<PersonDbContext, InsuranceType>, IInsuranceTypeRepository
    {
        public InsuranceTypeRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
