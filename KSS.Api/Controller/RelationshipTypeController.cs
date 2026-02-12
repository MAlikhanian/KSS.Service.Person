using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class RelationshipTypeController : BaseController<RelationshipType, RelationshipTypeDto, RelationshipTypeDto, RelationshipTypeDto>
    {
        public RelationshipTypeController(IRelationshipTypeService service) : base(service) { }
    }
}
