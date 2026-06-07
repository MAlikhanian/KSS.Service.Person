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
    public class EmailService : BaseService<Email, EmailDto, EmailDto, EmailDto>, IEmailService
    {
        private readonly IEmailRepository _repository;
        private readonly IPersonAccessChecker _accessChecker;

        public EmailService(
            IMapper mapper,
            IEmailRepository repository,
            IPersonAccessChecker accessChecker) : base(mapper, repository)
        {
            _repository = repository;
            _accessChecker = accessChecker;
        }

        // Person-scoped list — enforces row-level visibility before returning.
        // Called via POST /Api/Email/ToListByFilter { value: personId, dataType: Guid }.
        public override async Task<IEnumerable<Email>> ToListAsync(Filter filter)
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
