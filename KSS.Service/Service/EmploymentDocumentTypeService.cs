using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class EmploymentDocumentTypeService : BaseService<EmploymentDocumentType, EmploymentDocumentTypeDto, EmploymentDocumentTypeDto, EmploymentDocumentTypeDto>, IEmploymentDocumentTypeService
    {
        public EmploymentDocumentTypeService(IMapper mapper, IEmploymentDocumentTypeRepository repository) : base(mapper, repository) { }
    }
}
