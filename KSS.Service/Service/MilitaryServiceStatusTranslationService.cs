using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class MilitaryServiceStatusTranslationService : BaseService<MilitaryServiceStatusTranslation, MilitaryServiceStatusTranslationDto, MilitaryServiceStatusTranslationDto, MilitaryServiceStatusTranslationDto>, IMilitaryServiceStatusTranslationService
    {
        public MilitaryServiceStatusTranslationService(IMapper mapper, IMilitaryServiceStatusTranslationRepository repository) : base(mapper, repository) { }
    }
}
