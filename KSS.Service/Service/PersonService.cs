using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class PersonService : BaseService<Person, PersonDto, PersonDto, PersonDto>, IPersonService
    {
        public PersonService(IMapper mapper, IPersonRepository repository) : base(mapper, repository)
        {
        }
    }
}
