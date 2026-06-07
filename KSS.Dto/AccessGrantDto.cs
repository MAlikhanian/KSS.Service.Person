namespace KSS.Dto
{
    /// <summary>
    /// Payload from the frontend grant dialog: the owner sets levels for all
    /// four sections in one shot. Sections with Level == 0 are skipped (no row
    /// inserted) — absence of a row means "no access".
    /// </summary>
    public class AccessGrantDto
    {
        public Guid PersonId { get; set; }
        public Guid GrantedToPersonId { get; set; }
        public int InformationLevel { get; set; }
        public int AssetsLevel { get; set; }
        public int AccessLevel { get; set; }
        public int SecurityLevel { get; set; }
    }
}
