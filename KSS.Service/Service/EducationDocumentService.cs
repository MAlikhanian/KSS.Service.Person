using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class EducationDocumentService : BaseService<EducationDocument, EducationDocumentListDto, EducationDocumentAddDto, EducationDocumentAddDto>, IEducationDocumentService
    {
        public EducationDocumentService(IMapper mapper, IEducationDocumentRepository repository) : base(mapper, repository) { }
    }
}
