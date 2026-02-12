using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class RelationshipController : BaseController<Relationship, RelationshipDto, RelationshipDto, RelationshipDto>
    {
        public RelationshipController(IRelationshipService service) : base(service) { }
    }
}
