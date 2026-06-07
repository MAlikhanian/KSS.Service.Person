using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class EducationDocumentTypeService : BaseService<EducationDocumentType, EducationDocumentTypeDto, EducationDocumentTypeDto, EducationDocumentTypeDto>, IEducationDocumentTypeService
    {
        public EducationDocumentTypeService(IMapper mapper, IEducationDocumentTypeRepository repository) : base(mapper, repository) { }
    }
}
