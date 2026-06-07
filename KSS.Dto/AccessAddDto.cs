namespace KSS.Dto
{
    /// <summary>
    /// Single-row add DTO. Reflects the new (PersonId, GrantedToPersonId, Section, Level)
    /// row shape — used internally where a single section row needs to be created.
    /// External callers should prefer <see cref="AccessGrantDto"/>, which carries
    /// all three section levels in one payload.
    /// </summary>
    public class AccessAddDto
    {
        public Guid PersonId { get; set; }
        public Guid GrantedToPersonId { get; set; }
        public string Section { get; set; } = string.Empty;
        public int Level { get; set; }
    }
}
