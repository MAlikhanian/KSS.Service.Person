namespace KSS.Dto
{
    /// <summary>
    /// Payload from the role-access grant dialog: the caller sets levels for all
    /// four sections in one shot, scoped to a specific person. Sections with
    /// Level == 0 are skipped (no row inserted).
    /// </summary>
    public class RoleAccessGrantDto
    {
        public Guid PersonId { get; set; }
        public Guid GrantedToRoleId { get; set; }
        public int InformationLevel { get; set; }
        public int AssetsLevel { get; set; }
        public int AccessLevel { get; set; }
        public int SecurityLevel { get; set; }
    }
}
