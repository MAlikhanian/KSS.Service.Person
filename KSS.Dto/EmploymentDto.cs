namespace KSS.Dto
{
    public class EmploymentDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid CompanyId { get; set; }
        public byte ContractTypeId { get; set; }
        public short EmploymentActivityFieldId { get; set; }
        public short EmploymentActivityUnitId { get; set; }
        public short EmploymentPositionId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool IsPrimary { get; set; }
        public byte SortOrder { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
