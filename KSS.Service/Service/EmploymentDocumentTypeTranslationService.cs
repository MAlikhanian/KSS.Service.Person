using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class EmploymentDocumentTypeTranslationService : BaseService<EmploymentDocumentTypeTranslation, EmploymentDocumentTypeTranslationDto, EmploymentDocumentTypeTranslationDto, EmploymentDocumentTypeTranslationDto>, IEmploymentDocumentTypeTranslationService
    {
        public EmploymentDocumentTypeTranslationService(IMapper mapper, IEmploymentDocumentTypeTranslationRepository repository) : base(mapper, repository) { }
    }
}
