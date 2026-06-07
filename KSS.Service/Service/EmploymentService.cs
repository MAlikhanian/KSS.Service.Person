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
    public class EmploymentService : BaseService<Employment, EmploymentDto, EmploymentDto, EmploymentDto>, IEmploymentService
    {
        private readonly IEmploymentRepository _repository;
        private readonly IPersonAccessChecker _accessChecker;

        public EmploymentService(
            IMapper mapper,
            IEmploymentRepository repository,
            IPersonAccessChecker accessChecker) : base(mapper, repository)
        {
            _repository = repository;
            _accessChecker = accessChecker;
        }

        // Calls repo's ToListByPersonAsync which eager-loads EmploymentDocuments
        // (and after F.1, EmploymentDocumentType + Translations).
        public override async Task<IEnumerable<Employment>> ToListAsync(Filter filter)
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
