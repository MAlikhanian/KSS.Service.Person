namespace KSS.Dto
{
    /// <summary>
    /// One entry per (PersonId, GrantedToPersonId) pair, with all four section
    /// levels rolled up. Powers the grant table on the access management page.
    /// </summary>
    public class AccessGrantSummaryDto
    {
        public Guid PersonId { get; set; }
        public Guid GrantedToPersonId { get; set; }
        public int InformationLevel { get; set; }
        public int AssetsLevel { get; set; }
        public int AccessLevel { get; set; }
        public int SecurityLevel { get; set; }

        // Earliest CreatedAt across the section rows (when this grant was first issued).
        public DateTime CreatedAt { get; set; }
        // Latest UpdatedAt across the section rows; null if no row has been updated.
        public DateTime? UpdatedAt { get; set; }
    }
}
