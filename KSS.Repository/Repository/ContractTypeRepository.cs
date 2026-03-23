using KSS.Entity;
using KSS.Repository.IRepository;
using PersonDbContext = KSS.Data.DbContexts.MainDbContext;

namespace KSS.Repository.Repository
{
    public class ContractTypeRepository : BaseRepository<PersonDbContext, ContractType>, IContractTypeRepository
    {
        public ContractTypeRepository(PersonDbContext dbContext) : base(dbContext) { }
    }
}
