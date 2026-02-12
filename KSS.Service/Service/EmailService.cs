using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class EmailService : BaseService<Email, EmailDto, EmailDto, EmailDto>, IEmailService
    {
        public EmailService(IMapper mapper, IEmailRepository repository) : base(mapper, repository) { }
    }
}
