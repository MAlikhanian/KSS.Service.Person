using KSS.Dto;
using KSS.Helper.CustomAttribute;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KSS.Api.Controller
{
    [PermissionGroup("Information")]
    public class PersonController : BaseController<Person, PersonDto, PersonDto, PersonDto>
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService service) : base(service)
        {
            _personService = service;
        }

        /// <summary>GET /Api/Person/Count — scalar total persons. Powers the dashboard tile.</summary>
        [HttpGet]
        public async Task<ActionResult<PersonCountDto>> Count()
        {
            var total = await _personService.CountAsync();
            return Ok(new PersonCountDto { Count = total });
        }

        /// <summary>
        /// GET /Api/Person/CreatorUserIds — distinct list of UserIds that
        /// appear as Person.CreatedBy. The dashboard frontend joins this list
        /// with access grants (Company) and the person→user map (Auth) to
        /// compute "companies with user-created persons". No names, no emails
        /// — UserIds only. Available to any authenticated user (PermissionFilter
        /// skips this action name).
        /// </summary>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<PersonCreatorUserIdsDto>> CreatorUserIds()
        {
            // Call the dedicated bypass-access service method — using
            // _personService.ToListAsync() here would apply the per-user
            // visibility filter and return different counts per caller.
            var userIds = await _personService.GetDistinctCreatorIdsAsync();
            return Ok(new PersonCreatorUserIdsDto { UserIds = userIds });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<PersonDto>> AddWithTranslation([FromBody] CreatePersonWithTranslationDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _personService.CreatePersonWithTranslationAsync(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpsertTranslations([FromBody] UpsertTranslationsDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _personService.UpsertTranslationsAsync(dto);
            return NoContent();
        }

        /// <summary>
        /// GET /Api/Person/Directory — returns ALL persons with minimal info
        /// (Id, NationalId, translation names) for use as a directory picker.
        /// Bypasses the access filter on purpose; auth is still required.
        /// Profile details remain access-protected via the other endpoints.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDirectoryDto>>> Directory()
        {
            var data = await _personService.ListDirectoryAsync();
            return Ok(data);
        }

        /// <summary>
        /// GET /Api/Person/Me — returns the caller's own minimal person info
        /// (Id, NationalId, translations) based on the personId claim in the JWT.
        /// Skips the Person.Information.Read section gate (action name "Me"
        /// is not mapped in PermissionAuthorizationFilter), so a user with
        /// no roles can still load the data needed to render their own
        /// name + national code in the topbar.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<PersonDirectoryDto>> Me()
        {
            var data = await _personService.GetSelfAsync();
            if (data == null) return NotFound();
            return Ok(data);
        }
    }
}
