namespace KSS.Dto
{
    public class EmploymentDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid CompanyId { get; set; }
        public short JobTitleId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool IsPrimary { get; set; }
        public byte SortOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
