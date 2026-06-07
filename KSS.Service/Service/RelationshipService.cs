using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Helper;
using KSS.Helper.Enum.Base;
using KSS.Helper.Model;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class RelationshipService : BaseService<Relationship, RelationshipDto, RelationshipDto, RelationshipDto>, IRelationshipService
    {
        private readonly IRelationshipRepository _repository;
        private readonly IPersonAccessChecker _accessChecker;

        public RelationshipService(
            IMapper mapper,
            IRelationshipRepository repository,
            IPersonAccessChecker accessChecker) : base(mapper, repository)
        {
            _repository = repository;
            _accessChecker = accessChecker;
        }

        // Filtered by PersonId (the subject of the relation). The "related"
        // side is reached via the RelatedPersonId nav property when needed.
        public override async Task<IEnumerable<Relationship>> ToListAsync(Filter filter)
        {
            if (filter?.DataType == DataType.Guid)
            {
                var personId = (Guid)KSS.Helper.Assistant.FilterGetValue(filter);
                await _accessChecker.EnsureCanSeeAsync(personId);
                return await _repository.ToListAsync(e => e.PersonId == personId);
            }
            return await base.ToListAsync(filter);
        }
    }
}
