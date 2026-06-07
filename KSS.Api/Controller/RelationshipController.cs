using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class RelationshipController : BaseController<Relationship, RelationshipDto, RelationshipDto, RelationshipDto>
    {
        public RelationshipController(IRelationshipService service) : base(service) { }
    }
}
