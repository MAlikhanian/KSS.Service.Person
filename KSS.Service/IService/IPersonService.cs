using KSS.Dto;
using KSS.Entity;

namespace KSS.Service.IService
{
    public interface IPersonService : IBaseService<Person, PersonDto, PersonDto, PersonDto>
    {
        Task<PersonDto> CreatePersonWithTranslationAsync(CreatePersonWithTranslationDto request);
    }
}
