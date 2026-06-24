namespace KSS.Dto
{
    /// <summary>
    /// Minimal name record returned by POST /Api/Person/Names. Only the fields
    /// needed to render a person's display name — no profile details.
    /// </summary>
    public class PersonNameDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NationalId { get; set; } = string.Empty;
    }
}
