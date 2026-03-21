using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class BirthCertificateSeriesLetterTranslationService : BaseService<BirthCertificateSeriesLetterTranslation, BirthCertificateSeriesLetterTranslationDto, BirthCertificateSeriesLetterTranslationDto, BirthCertificateSeriesLetterTranslationDto>, IBirthCertificateSeriesLetterTranslationService
    {
        public BirthCertificateSeriesLetterTranslationService(IMapper mapper, IBirthCertificateSeriesLetterTranslationRepository repository) : base(mapper, repository) { }
    }
}
