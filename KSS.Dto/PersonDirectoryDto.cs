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
        public List<PersonDirectoryTranslationDto> Translations { get; set; } = new();
    }

    public class PersonDirectoryTranslationDto
    {
        public short LanguageId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
