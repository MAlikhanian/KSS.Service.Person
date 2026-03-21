using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Helper;
using KSS.Repository.IRepository;
using KSS.Service.IService;

namespace KSS.Service.Service
{
    public class PersonNationalityService : BaseService<PersonNationality, PersonNationalityDto, PersonNationalityDto, PersonNationalityDto>, IPersonNationalityService
    {
        public PersonNationalityService(IMapper mapper, IPersonNationalityRepository repository) : base(mapper, repository) { }

        public override async Task AddAsync(PersonNationality item, bool saveChanges = true)
        {
            var existing = SingleOrDefault(x => x.PersonId == item.PersonId && x.CountryId == item.CountryId);
            if (existing != null)
                throw new BusinessRuleException("این تابعیت قبلاً برای این شخص ثبت شده است.");

            await base.AddAsync(item, saveChanges);
        }
    }
}
