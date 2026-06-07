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
    public class PhoneService : BaseService<Phone, PhoneDto, PhoneDto, PhoneDto>, IPhoneService
    {
        private readonly IPhoneRepository _repository;
        private readonly IPersonAccessChecker _accessChecker;

        public PhoneService(
            IMapper mapper,
            IPhoneRepository repository,
            IPersonAccessChecker accessChecker) : base(mapper, repository)
        {
            _repository = repository;
            _accessChecker = accessChecker;
        }

        public override async Task<IEnumerable<Phone>> ToListAsync(Filter filter)
        {
            if (filter?.DataType == DataType.Guid)
            {
                var personId = (Guid)KSS.Helper.Assistant.FilterGetValue(filter);
                await _accessChecker.EnsureCanSeeAsync(personId);
                return await _repository.ToListAsync(e => e.PersonId == personId);
            }
            return await base.ToListAsync(filter);
        }
    }
}
