using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class DocumentTypeService : BaseService<DocumentType, DocumentTypeDto, DocumentTypeDto, DocumentTypeDto>, IDocumentTypeService
    {
        public DocumentTypeService(IMapper mapper, IDocumentTypeRepository repository) : base(mapper, repository) { }
    }
}
