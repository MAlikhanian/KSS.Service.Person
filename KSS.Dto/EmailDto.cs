namespace KSS.Dto
{
    public class EmailDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public byte LabelId { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
        public bool IsVerified { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
