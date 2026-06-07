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
    public class EducationService : BaseService<Education, EducationListDto, EducationAddDto, EducationUpdateDto>, IEducationService
    {
        private readonly IEducationRepository _repository;
        private readonly IPersonAccessChecker _accessChecker;

        public EducationService(
            IMapper mapper,
            IEducationRepository repository,
            IPersonAccessChecker accessChecker) : base(mapper, repository)
        {
            _repository = repository;
            _accessChecker = accessChecker;
        }

        // Calls repo's ToListByPersonAsync which eager-loads EducationDocuments
        // (and after F.1, EducationDocumentType + Translations).
        public override async Task<IEnumerable<Education>> ToListAsync(Filter filter)
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
