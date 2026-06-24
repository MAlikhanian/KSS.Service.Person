namespace KSS.Dto
{
    /// <summary>
    /// Request body for POST /Api/Person/Names — resolves display names for a
    /// specific set of person ids in one call. Sent by other services (e.g. the
    /// Company stakeholder view) so they don't have to pull the full directory.
    /// </summary>
    public class PersonNamesRequestDto
    {
        public List<Guid> Ids { get; set; } = new();
        public short LanguageId { get; set; } = 12;
    }
}
