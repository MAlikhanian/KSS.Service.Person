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
    public class AccessController : ControllerBase
    {
        private readonly IAccessService _service;

        public AccessController(IAccessService service)
        {
            _service = service;
        }

        /// <summary>GET /Api/Access/ByOwner/{personId} — list grants given out by personId, one entry per grantee.</summary>
        [HttpGet("{personId}")]
        public async Task<ActionResult<List<AccessGrantSummaryDto>>> ByOwner(Guid personId)
        {
            var caller = GetCallerPersonId();
            // Owner can always see their own grants. Non-owners need at least
            // View on the access section (level >= 1).
            if (personId != caller)
            {
                var levels = await _service.GetLevelsAsync(personId, caller);
                if (levels.Access < 1)
                    throw new BusinessRuleException("شما اجازه مشاهده دسترسی‌های این فرد را ندارید");
            }

            var data = await _service.ListGrantsByOwnerAsync(personId);
            return Ok(data);
        }

        /// <summary>POST /Api/Access/Grant — upsert a grant (3 section levels) for a (personId, grantedToPersonId) pair.</summary>
        [HttpPost]
        public async Task<ActionResult> Grant([FromBody] AccessGrantDto dto)
        {
            var caller = GetCallerPersonId();
            await _service.UpsertGrantAsync(dto, caller);
            return NoContent();
        }

        /// <summary>POST /Api/Access/RevokeByPair/{personId}/{grantedToPersonId} — owner-only revoke of all rows for the pair.</summary>
        [HttpPost("{personId}/{grantedToPersonId}")]
        public async Task<ActionResult> RevokeByPair(Guid personId, Guid grantedToPersonId)
        {
            var caller = GetCallerPersonId();
            await _service.RevokeByPairAsync(personId, grantedToPersonId, caller);
            return NoContent();
        }

        /// <summary>GET /Api/Access/MyLevels/{personId} — caller's per-section levels for personId.</summary>
        [HttpGet("{personId}")]
        public async Task<ActionResult<AccessLevelsDto>> MyLevels(Guid personId)
        {
            var levels = await _service.GetLevelsAsync(personId, GetCallerPersonId());
            return Ok(levels);
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
