using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Helper;
using KSS.Helper.Enum.Base;
using KSS.Helper.Model;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class AddressService : BaseService<Address, AddressDto, AddressDto, AddressDto>, IAddressService
    {
        private readonly IAddressRepository _repository;
        private readonly IPersonAccessChecker _accessChecker;

        public AddressService(
            IMapper mapper,
            IAddressRepository repository,
            IPersonAccessChecker accessChecker) : base(mapper, repository)
        {
            _repository = repository;
            _accessChecker = accessChecker;
        }

        // Calls repo's ToListByPersonAsync — handles the Translations eager
        // load that addresses need to render per-language labels.
        public override async Task<IEnumerable<Address>> ToListAsync(Filter filter)
        {
            if (filter?.DataType == DataType.Guid)
            {
                var personId = (Guid)KSS.Helper.Assistant.FilterGetValue(filter);
                await _accessChecker.EnsureCanSeeAsync(personId);
                return await _repository.ToListByPersonAsync(personId);
            }
            return await base.ToListAsync(filter);
        }
    }
}
