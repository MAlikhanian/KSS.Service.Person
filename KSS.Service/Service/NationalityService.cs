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
    public class NationalityService : BaseService<Nationality, NationalityDto, NationalityDto, NationalityDto>, INationalityService
    {
        private readonly INationalityRepository _repository;
        private readonly IPersonAccessChecker _accessChecker;

        public NationalityService(
            IMapper mapper,
            INationalityRepository repository,
            IPersonAccessChecker accessChecker) : base(mapper, repository)
        {
            _repository = repository;
            _accessChecker = accessChecker;
        }

        public override async Task<IEnumerable<Nationality>> ToListAsync(Filter filter)
        {
            if (filter?.DataType == DataType.Guid)
            {
                var personId = (Guid)KSS.Helper.Assistant.FilterGetValue(filter);
                await _accessChecker.EnsureCanSeeAsync(personId);
                return await _repository.ToListAsync(e => e.PersonId == personId);
            }
            return await base.ToListAsync(filter);
        }

        public override async Task AddAsync(Nationality item, bool saveChanges = true)
        {
            var existing = SingleOrDefault(x => x.PersonId == item.PersonId && x.CountryId == item.CountryId);
            if (existing != null)
                throw new BusinessRuleException("این تابعیت قبلاً برای این شخص ثبت شده است.");

            await base.AddAsync(item, saveChanges);
        }
    }
}
