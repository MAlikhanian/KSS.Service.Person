using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class FieldOfStudyTranslationService : BaseService<FieldOfStudyTranslation, FieldOfStudyTranslationDto, FieldOfStudyTranslationDto, FieldOfStudyTranslationDto>, IFieldOfStudyTranslationService
    {
        public FieldOfStudyTranslationService(IMapper mapper, IFieldOfStudyTranslationRepository repository) : base(mapper, repository) { }
    }
}
