namespace KSS.Dto
{
    public class ProfessionalTrainingListDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ProfessionalTrainingTypeId { get; set; }
        public int ProfessionalTrainingCertificateIssuerId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
