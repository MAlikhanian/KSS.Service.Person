using KSS.Dto;
using KSS.Entity;
using KSS.Service.IService;
using KSS.API.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KSS.Api.Controller
{
    public class PersonController : BaseController<Person, PersonDto, PersonDto, PersonDto>
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService service) : base(service)
        {
            _personService = service;
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
    }
}
