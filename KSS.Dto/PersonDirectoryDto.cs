namespace KSS.Dto
{
    /// <summary>
    /// Minimal person record returned by the Directory endpoint.
    /// Returns ALL persons (bypasses access filter) but exposes only the bare
    /// minimum needed to render a "pick a person" dropdown — Id, NationalId
    /// and translation names. NO profile details (sex, birthdate, addresses,
    /// etc.) are included; reading those still requires PersonAccess.
    /// </summary>
    public class PersonDirectoryDto
    {
        public Guid Id { get; set; }
        public string NationalId { get; set; } = string.Empty;
        // The account/person that inserted this row (Person.CreatedBy). In
        // practice this matches a Person.Id, so consumers can resolve it back
        // to a name via the directory itself.
        public Guid CreatedBy { get; set; }
        // When this person row was created (Person.CreatedAt) — lets consumers
        // find the most-recently-created person in a set.
        public DateTime CreatedAt { get; set; }
        public List<PersonDirectoryTranslationDto> Translations { get; set; } = new();
    }

    public class PersonDirectoryTranslationDto
    {
        public short LanguageId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
