namespace KSS.Dto
{
    /// <summary>
    /// Minimal employment row for cross-service reporting (e.g. the Members
    /// "personnel by position" report). Exposed by GET /Api/Person/Employments,
    /// which bypasses the per-caller access filter like /Api/Person/Directory.
    /// </summary>
    public class EmploymentDirectoryDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid CompanyId { get; set; }
        public short EmploymentPositionId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool IsActive { get; set; }
    }
}
