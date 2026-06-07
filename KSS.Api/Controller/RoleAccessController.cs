using System.Security.Claims;
using KSS.Dto;
using KSS.Helper;
using KSS.Helper.Authorization;
using KSS.Helper.CustomAttribute;
using KSS.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KSS.Api.Controller
{
    [ApiController]
    [Route("Api/[controller]/[action]")]
    [Authorize]
    [ServiceFilter(typeof(PermissionAuthorizationFilter))]
    [PermissionGroup("Access")]
    public class RoleAccessController : ControllerBase
    {
        private readonly IRoleAccessService _service;
        private readonly IAccessService _accessService;

        public RoleAccessController(IRoleAccessService service, IAccessService accessService)
        {
            _service = service;
            _accessService = accessService;
        }

        /// <summary>GET /Api/RoleAccess/ByPerson/{personId} — per-person + global role grants visible on this person's page.</summary>
        [HttpGet("{personId}")]
        public async Task<ActionResult<List<RoleAccessGrantSummaryDto>>> ByPerson(Guid personId)
        {
            var caller = GetCallerPersonId();
            if (personId != caller)
            {
                var levels = await _accessService.GetLevelsAsync(personId, caller);
                if (levels.Access < 1)
                    throw new BusinessRuleException("شما اجازه مشاهده دسترسی‌های این فرد را ندارید");
            }

            var data = await _service.ListGrantsByPersonAsync(personId);
            return Ok(data);
        }

        /// <summary>GET /Api/RoleAccess/All — every role grant in the system. Admin-only via permission filter.</summary>
        [HttpGet]
        public async Task<ActionResult<List<RoleAccessGrantSummaryDto>>> All()
        {
            var data = await _service.ListAllGrantsAsync();
            return Ok(data);
        }

        /// <summary>POST /Api/RoleAccess/Grant — upsert a role grant (4 section levels) for (personId|null, grantedToRoleId).</summary>
        [HttpPost]
        public async Task<ActionResult> Grant([FromBody] RoleAccessGrantDto dto)
        {
            var caller = GetCallerPersonId();
            await _service.UpsertGrantAsync(dto, caller);
            return NoContent();
        }

        /// <summary>POST /Api/RoleAccess/RevokeByPair — owner/admin revoke for the (personId|null, grantedToRoleId) pair.</summary>
        [HttpPost]
        public async Task<ActionResult> RevokeByPair([FromQuery] Guid? personId, [FromQuery] Guid grantedToRoleId)
        {
            var caller = GetCallerPersonId();
            await _service.RevokeByPairAsync(personId, grantedToRoleId, caller);
            return NoContent();
        }

        private Guid GetCallerPersonId()
        {
            var raw = User.FindFirstValue("personId")
                   ?? User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(raw) || !Guid.TryParse(raw, out var personId))
                throw new BusinessRuleException("Caller PersonId not found on the JWT.");
            return personId;
        }
    }
}
