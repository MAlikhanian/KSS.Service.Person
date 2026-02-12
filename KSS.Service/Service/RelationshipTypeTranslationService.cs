using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class RelationshipTypeTranslationService : BaseService<RelationshipTypeTranslation, RelationshipTypeTranslationDto, RelationshipTypeTranslationDto, RelationshipTypeTranslationDto>, IRelationshipTypeTranslationService
    {
        public RelationshipTypeTranslationService(IMapper mapper, IRelationshipTypeTranslationRepository repository) : base(mapper, repository) { }
    }
}
