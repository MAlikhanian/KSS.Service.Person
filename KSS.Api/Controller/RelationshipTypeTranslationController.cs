using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;

namespace KSS.Api.Controller
{
    public class RelationshipTypeTranslationController : BaseController<RelationshipTypeTranslation, RelationshipTypeTranslationDto, RelationshipTypeTranslationDto, RelationshipTypeTranslationDto>
    {
        public RelationshipTypeTranslationController(IRelationshipTypeTranslationService service) : base(service) { }
    }
}
