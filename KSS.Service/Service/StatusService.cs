using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Helper;
using KSS.Helper.Model;
using KSS.Repository.IRepository;
using KSS.Service.IService;
// Alias only DataType from Enum.Base — bringing the whole namespace in
// collides with the Status entity (there's also a Status enum there).
using DataType = KSS.Helper.Enum.Base.DataType;

namespace KSS.Service.Service
{
    public class StatusService : BaseService<Status, StatusDto, StatusDto, StatusDto>, IStatusService
    {
        private readonly IStatusRepository _repository;
        private readonly IPersonAccessChecker _accessChecker;

        public StatusService(
            IMapper mapper,
            IStatusRepository repository,
            IPersonAccessChecker accessChecker) : base(mapper, repository)
        {
            _repository = repository;
            _accessChecker = accessChecker;
        }

        public override async Task<IEnumerable<Status>> ToListAsync(Filter filter)
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
