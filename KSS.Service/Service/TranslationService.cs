using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Helper;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class TranslationService : BaseService<Translation, TranslationDto, TranslationDto, TranslationDto>, ITranslationService
    {
        private readonly ITranslationRepository _repository;

        public TranslationService(IMapper mapper, ITranslationRepository repository) : base(mapper, repository)
        {
            _repository = repository;
        }

        public override void UpdateDto(TranslationDto item, bool saveChanges = true)
        {
            // English (LanguageId == 10) is locked after the first insert.
            if (item.LanguageId == 10)
            {
                var existing = _repository.SingleOrDefault(
                    t => t.PersonId == item.PersonId && t.LanguageId == item.LanguageId);
                if (existing != null)
                    throw new BusinessRuleException("نام انگلیسی پس از ثبت قابل تغییر نیست");
            }

            base.UpdateDto(item, saveChanges);
        }
    }
}
