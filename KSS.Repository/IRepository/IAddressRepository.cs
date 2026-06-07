using KSS.Entity;

namespace KSS.Repository.IRepository
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<IEnumerable<Address>> ToListByPersonAsync(Guid personId);
    }
}
