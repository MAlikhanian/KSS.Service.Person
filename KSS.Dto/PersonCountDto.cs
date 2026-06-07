namespace KSS.Dto
{
    /// <summary>
    /// Minimal DTO returned by GET /Api/Person/Count. The dashboard "All
    /// Persons" tile fetches this — no entity rows are exposed, only the
    /// scalar count.
    /// </summary>
    public class PersonCountDto
    {
        public int Count { get; set; }
    }
}
