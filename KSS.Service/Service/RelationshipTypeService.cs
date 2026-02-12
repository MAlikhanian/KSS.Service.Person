using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class RelationshipTypeService : BaseService<RelationshipType, RelationshipTypeDto, RelationshipTypeDto, RelationshipTypeDto>, IRelationshipTypeService
    {
        public RelationshipTypeService(IMapper mapper, IRelationshipTypeRepository repository) : base(mapper, repository) { }
    }
}
