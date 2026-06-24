namespace KSS.Dto
{
    /// <summary>
    /// Minimal per-person demographics for cross-service reporting (e.g. the
    /// Members brokerage-profile age/gender distributions). Exposed by
    /// GET /Api/Person/Demographics — bypass-access like /Api/Person/Directory.
    /// </summary>
    public class PersonDemographicsDto
    {
        public Guid Id { get; set; }
        public byte SexId { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
