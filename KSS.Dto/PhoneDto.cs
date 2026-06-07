namespace KSS.Dto
{
    public class PhoneDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public byte LabelId { get; set; }
        public short CountryId { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
        public bool IsVerified { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
