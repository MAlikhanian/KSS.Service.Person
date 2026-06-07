using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class EmploymentDocumentService : BaseService<EmploymentDocument, EmploymentDocumentListDto, EmploymentDocumentAddDto, EmploymentDocumentAddDto>, IEmploymentDocumentService
    {
        public EmploymentDocumentService(IMapper mapper, IEmploymentDocumentRepository repository) : base(mapper, repository) { }
    }
}
