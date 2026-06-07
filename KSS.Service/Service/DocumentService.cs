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
    public class DocumentService : BaseService<Document, DocumentListDto, DocumentAddDto, DocumentUpdateDto>, IDocumentService
    {
        private readonly IDocumentRepository _repository;
        private readonly IPersonAccessChecker _accessChecker;

        public DocumentService(
            IMapper mapper,
            IDocumentRepository repository,
            IPersonAccessChecker accessChecker) : base(mapper, repository)
        {
            _repository = repository;
            _accessChecker = accessChecker;
        }

        public override async Task<IEnumerable<Document>> ToListAsync(Filter filter)
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
