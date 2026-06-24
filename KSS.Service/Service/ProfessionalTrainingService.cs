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
    public class ProfessionalTrainingService : BaseService<ProfessionalTraining, ProfessionalTrainingListDto, ProfessionalTrainingAddDto, ProfessionalTrainingUpdateDto>, IProfessionalTrainingService
    {
        private readonly IProfessionalTrainingRepository _repository;
        private readonly IPersonAccessChecker _accessChecker;

        public ProfessionalTrainingService(IMapper mapper, IProfessionalTrainingRepository repository, IPersonAccessChecker accessChecker)
            : base(mapper, repository)
        {
            _repository = repository;
            _accessChecker = accessChecker;
        }

        public override async Task<IEnumerable<ProfessionalTraining>> ToListAsync(Filter filter)
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
