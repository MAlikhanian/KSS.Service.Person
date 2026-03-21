using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class BirthCertificateSeriesLetterService : BaseService<BirthCertificateSeriesLetter, BirthCertificateSeriesLetterDto, BirthCertificateSeriesLetterDto, BirthCertificateSeriesLetterDto>, IBirthCertificateSeriesLetterService
    {
        public BirthCertificateSeriesLetterService(IMapper mapper, IBirthCertificateSeriesLetterRepository repository) : base(mapper, repository) { }
    }
}
