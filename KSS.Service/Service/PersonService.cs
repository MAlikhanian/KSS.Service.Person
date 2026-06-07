using System.Security.Claims;
using AutoMapper;
using KSS.Dto;
using KSS.Entity;
using KSS.Helper.Model;
using KSS.Repository.IRepository;
using KSS.Service.IService;
using Microsoft.AspNetCore.Http;

namespace KSS.Service.Service
{
    public class PersonService : BaseService<Person, PersonDto, PersonDto, PersonDto>, IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ITranslationRepository _translationRepository;
        private readonly IAccessRepository _accessRepository;
        private readonly IRoleAccessRepository _roleAccessRepository;
        private readonly IAccessService _accessService;
        private readonly IPersonAccessChecker _accessChecker;
        private readonly IHttpContextAccessor? _httpContextAccessor;

        public PersonService(
            IMapper mapper,
            IPersonRepository repository,
            ITranslationRepository translationRepository,
            IAccessRepository accessRepository,
            IRoleAccessRepository roleAccessRepository,
            IAccessService accessService,
            IPersonAccessChecker accessChecker,
            IHttpContextAccessor? httpContextAccessor = null) : base(mapper, repository)
        {
            _personRepository = repository;
            _translationRepository = translationRepository;
            _accessRepository = accessRepository;
            _roleAccessRepository = roleAccessRepository;
            _accessService = accessService;
            _accessChecker = accessChecker;
            _httpContextAccessor = httpContextAccessor;
        }

        // FindAsync — row-level visibility guard. Mirrors the rules in
        // ToListAsync via the shared PersonAccessChecker so the visible set
        // is identical whether reached through list or detail. After the
        // guard, delegates to the repo (which now does the light include).
        public override async Task<Person> FindAsync(Filter id)
        {
            var personId = (Guid)KSS.Helper.Assistant.FilterGetValue(id);
            await _accessChecker.EnsureCanSeeAsync(personId);
            return await _personRepository.FindAsync(id);
        }

        private Guid? GetCallerPersonId()
        {
            var user = _httpContextAccessor?.HttpContext?.User;
            if (user?.Identity?.IsAuthenticated != true) return null;
            var raw = user.FindFirstValue("personId") ?? user.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.TryParse(raw, out var id) ? id : null;
        }

        private List<Guid> GetCallerRoleIds()
        {
            var user = _httpContextAccessor?.HttpContext?.User;
            if (user?.Identity?.IsAuthenticated != true) return new List<Guid>();
            return user.FindAll("roleId")
                .Select(c => Guid.TryParse(c.Value, out var id) ? id : Guid.Empty)
                .Where(id => id != Guid.Empty)
                .Distinct()
                .ToList();
        }

        // ─── Lock NationalId on update — preserve existing value ───
        public override void UpdateDto(PersonDto item, bool saveChanges = true)
        {
            var existing = _personRepository.Find(item.Id);
            if (existing == null) return;

            // ─── Enforce per-section information-level access ───
            var callerId = GetCallerPersonId();
            if (callerId.HasValue)
            {
                var levels = _accessService.GetLevelsAsync(existing.Id, callerId.Value)
                    .GetAwaiter().GetResult();
                if (levels.Information < 2)
                    throw new KSS.Helper.BusinessRuleException("شما اجازه ویرایش این شخص را ندارید");
            }

            // Selectively patch fields. NationalId is intentionally NOT copied — preserved from existing.
            existing.SexId = item.SexId;
            existing.PreferredLanguageId = item.PreferredLanguageId;
            existing.DateOfBirth = item.DateOfBirth;
            existing.BirthCountryId = item.BirthCountryId;
            existing.BirthRegionId = item.BirthRegionId;
            existing.BirthCityId = item.BirthCityId;
            existing.BirthCertificateNumber = item.BirthCertificateNumber;
            existing.BirthCertificateSeriesNumber = item.BirthCertificateSeriesNumber;
            existing.BirthCertificateSeriesLetterId = item.BirthCertificateSeriesLetterId;
            existing.BirthCertificateSerial = item.BirthCertificateSerial;
            existing.BirthCertificateIssueCountryId = item.BirthCertificateIssueCountryId;
            existing.BirthCertificateIssueRegionId = item.BirthCertificateIssueRegionId;
            existing.BirthCertificateIssueCityId = item.BirthCertificateIssueCityId;
            existing.MaritalStatusId = item.MaritalStatusId;
            existing.ReligionId = item.ReligionId;
            existing.PassportNumber = item.PassportNumber;
            existing.MilitaryServiceStatusId = item.MilitaryServiceStatusId;
            existing.MilitaryServiceLocationId = item.MilitaryServiceLocationId;
            existing.InsuranceTypeId = item.InsuranceTypeId;
            existing.InsuranceNumber = item.InsuranceNumber;
            // CreatedAt preserved; UpdatedAt set by ApplyEntityDefaults.

            if (saveChanges) _personRepository.SaveChanges();
        }

        // ─── Filter persons by caller's access ───
        // A person is visible to the caller if any of:
        //   • Person.Id == caller (always see yourself)
        //   • a personal Access row links caller → person
        //   • a RoleAccess row scoped to that person matches the caller's role
        //   • a RoleAccess row with PersonId == NULL (global) matches the caller's role
        //     → caller can see ALL persons (e.g. SuperAdmin, PersonAdmin)
        public override async Task<IEnumerable<Person>> ToListAsync()
        {
            var callerId = GetCallerPersonId();
            if (callerId == null) return new List<Person>();

            var roleIds = GetCallerRoleIds();
            var all = (await _personRepository.ToListAsync()).ToList();

            // Global role grants: any RoleAccess row with PersonId == NULL whose
            // role matches the caller — they can see everyone.
            if (roleIds.Count > 0)
            {
                var globalCount = await _roleAccessRepository.CountAsync(
                    ra => ra.PersonId == null && roleIds.Contains(ra.GrantedToRoleId));
                if (globalCount > 0) return all;
            }

            var allowedOwnerIds = (await _accessRepository.ToListAsync(pa => pa.GrantedToPersonId == callerId.Value))
                .Select(pa => pa.PersonId)
                .Distinct()
                .ToHashSet();
            allowedOwnerIds.Add(callerId.Value);

            // Per-person role grants — pulls in any person reachable via RoleAccess.
            if (roleIds.Count > 0)
            {
                var roleScoped = await _roleAccessRepository.ToListAsync(
                    ra => ra.PersonId != null && roleIds.Contains(ra.GrantedToRoleId));
                foreach (var row in roleScoped)
                    if (row.PersonId.HasValue) allowedOwnerIds.Add(row.PersonId.Value);
            }

            return all.Where(p => allowedOwnerIds.Contains(p.Id)).ToList();
        }

        public async Task<PersonDto> CreatePersonWithTranslationAsync(CreatePersonWithTranslationDto request)
        {
            // Reject duplicate national IDs up-front so signup retries (after a
            // previous run failed between Person insert and User insert in the
            // Auth service) surface a clean DUPLICATE_NATIONAL_ID code instead
            // of a unique-constraint exception out of EF.
            if (!string.IsNullOrWhiteSpace(request.NationalId))
            {
                var nationalId = request.NationalId;
                var existing = await _personRepository.SingleOrDefaultAsync(p => p.NationalId == nationalId);
                if (existing != null)
                    throw new KSS.Helper.BusinessRuleException("DUPLICATE_NATIONAL_ID");
            }

            var person = new Person
            {
                Id = Guid.CreateVersion7(),
                SexId = request.SexId,
                PreferredLanguageId = request.PreferredLanguageId,
                NationalId = request.NationalId ?? Guid.NewGuid().ToString("N")[..20],
                DateOfBirth = request.DateOfBirth ?? new DateTime(1990, 1, 1),
                BirthCountryId = request.BirthCountryId,
                BirthRegionId = request.BirthRegionId,
                BirthCityId = request.BirthCityId,
                BirthCertificateNumber = request.BirthCertificateNumber,
                BirthCertificateSeriesNumber = request.BirthCertificateSeriesNumber,
                BirthCertificateSeriesLetterId = request.BirthCertificateSeriesLetterId,
                BirthCertificateSerial = request.BirthCertificateSerial,
                BirthCertificateIssueCountryId = request.BirthCertificateIssueCountryId,
                BirthCertificateIssueRegionId = request.BirthCertificateIssueRegionId,
                BirthCertificateIssueCityId = request.BirthCertificateIssueCityId,
                MaritalStatusId = request.MaritalStatusId,
                ReligionId = request.ReligionId,
                PassportNumber = request.PassportNumber,
                MilitaryServiceStatusId = request.MilitaryServiceStatusId,
                MilitaryServiceLocationId = request.MilitaryServiceLocationId,
                InsuranceTypeId = request.InsuranceTypeId,
                InsuranceNumber = request.InsuranceNumber
                // CreatedAt, CreatedBy auto-set by ApplyEntityDefaults; UpdatedAt stays NULL on insert
            };

            // Save person without committing yet
            await _personRepository.AddAsync(person, false);

            // Create each translation (FA, EN) — save all without committing
            var validTranslations = request.Translations
                .Where(tr => !string.IsNullOrWhiteSpace(tr.FirstName) || !string.IsNullOrWhiteSpace(tr.LastName))
                .ToList();

            for (var i = 0; i < validTranslations.Count; i++)
            {
                var tr = validTranslations[i];
                var translation = new Translation
                {
                    PersonId = person.Id,
                    LanguageId = tr.LanguageId,
                    FirstName = tr.FirstName,
                    LastName = tr.LastName,
                    FatherName = tr.FatherName
                };

                // Don't commit here — we still need to add the access row.
                await _translationRepository.AddAsync(translation, false);
            }

            // Auto-grant Edit access on every section to creator (so they can see/edit the new person).
            // The creator is automatically the owner anyway via personId == callerId, but we also
            // emit explicit rows to keep the access table self-describing.
            var callerId = GetCallerPersonId();
            if (callerId.HasValue && callerId.Value != person.Id)
            {
                foreach (var sectionId in new byte[] { AccessSectionId.Information, AccessSectionId.Assets, AccessSectionId.Access, AccessSectionId.Security })
                {
                    var access = new Access
                    {
                        PersonId = person.Id,
                        GrantedToPersonId = callerId.Value,
                        SectionId = sectionId,
                        Level = 2, // Edit
                        // Id, CreatedAt, UpdatedAt, CreatedBy populated by ApplyEntityDefaults.
                    };
                    await _accessRepository.AddAsync(access, false);
                }
            }

            // Commit everything in one batch.
            await _personRepository.SaveChangesAsync();

            return _mapper.Map<PersonDto>(person);
        }

        /// <summary>
        /// Returns minimal info for ALL persons — bypasses the access filter.
        /// Only Id, NationalId, and translation names are exposed. Profile
        /// details still require PersonAccess via the regular endpoints.
        /// </summary>
        public async Task<IEnumerable<PersonDirectoryDto>> ListDirectoryAsync()
        {
            var persons = await _personRepository.ToListAsync();
            var translations = await _translationRepository.ToListAsync();
            var trByPerson = translations
                .GroupBy(t => t.PersonId)
                .ToDictionary(g => g.Key, g => g.ToList());

            return persons
                .Select(p => new PersonDirectoryDto
                {
                    Id = p.Id,
                    NationalId = p.NationalId ?? string.Empty,
                    Translations = trByPerson.TryGetValue(p.Id, out var trs)
                        ? trs.Select(t => new PersonDirectoryTranslationDto
                        {
                            LanguageId = t.LanguageId,
                            FirstName = t.FirstName ?? string.Empty,
                            LastName = t.LastName ?? string.Empty,
                        }).ToList()
                        : new List<PersonDirectoryTranslationDto>(),
                })
                .ToList();
        }

        public async Task<PersonDirectoryDto?> GetSelfAsync()
        {
            var callerId = GetCallerPersonId();
            if (callerId == null) return null;

            var person = await _personRepository.SingleOrDefaultAsync(p => p.Id == callerId.Value);
            if (person == null) return null;

            var translations = (await _translationRepository.ToListAsync(t => t.PersonId == callerId.Value))
                .Select(t => new PersonDirectoryTranslationDto
                {
                    LanguageId = t.LanguageId,
                    FirstName = t.FirstName ?? string.Empty,
                    LastName = t.LastName ?? string.Empty,
                })
                .ToList();

            return new PersonDirectoryDto
            {
                Id = person.Id,
                NationalId = person.NationalId ?? string.Empty,
                Translations = translations,
            };
        }

        /// <summary>
        /// Distinct list of UserIds that appear as Person.CreatedBy across the
        /// ENTIRE Person table. Calls the repository directly so it bypasses
        /// the overridden ToListAsync's per-user access filter — every caller
        /// gets the same global result. Empty Guids are excluded.
        /// </summary>
        public async Task<List<Guid>> GetDistinctCreatorIdsAsync()
        {
            var persons = await _personRepository.ToListAsync();
            return persons
                .Select(p => p.CreatedBy)
                .Where(id => id != Guid.Empty)
                .Distinct()
                .ToList();
        }

        /// <summary>
        /// Upsert translations for an existing person.
        /// Determines add vs update per language (like company pattern).
        /// </summary>
        public async Task UpsertTranslationsAsync(UpsertTranslationsDto dto)
        {
            var existing = _translationRepository.ToList(
                t => t.PersonId == dto.PersonId);
            var existingByLang = existing.ToDictionary(t => t.LanguageId);

            foreach (var tr in dto.Translations)
            {
                if (string.IsNullOrWhiteSpace(tr.FirstName) && string.IsNullOrWhiteSpace(tr.LastName))
                    continue;

                if (existingByLang.TryGetValue(tr.LanguageId, out var existingTranslation))
                {
                    // English (LanguageId == 10) is locked once a row exists.
                    if (tr.LanguageId == 10)
                        throw new KSS.Helper.BusinessRuleException("نام انگلیسی پس از ثبت قابل تغییر نیست");

                    // Update tracked entity properties — no need to call Update(),
                    // EF change tracker already detects the modifications
                    existingTranslation.FirstName = tr.FirstName;
                    existingTranslation.LastName = tr.LastName;
                    existingTranslation.FatherName = tr.FatherName;
                }
                else
                {
                    var entity = new Translation
                    {
                        PersonId = dto.PersonId,
                        LanguageId = tr.LanguageId,
                        FirstName = tr.FirstName,
                        LastName = tr.LastName,
                        FatherName = tr.FatherName
                    };
                    await _translationRepository.AddAsync(entity, false);
                }
            }

            // Save all changes in one batch
            await _translationRepository.SaveChangesAsync();
        }
    }
}
