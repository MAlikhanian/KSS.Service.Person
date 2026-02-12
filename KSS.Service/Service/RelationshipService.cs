using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class RelationshipService : BaseService<Relationship, RelationshipDto, RelationshipDto, RelationshipDto>, IRelationshipService
    {
        public RelationshipService(IMapper mapper, IRelationshipRepository repository) : base(mapper, repository) { }
    }
}
