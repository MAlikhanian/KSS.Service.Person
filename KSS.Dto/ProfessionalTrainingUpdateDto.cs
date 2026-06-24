namespace KSS.Dto
{
    public class ProfessionalTrainingUpdateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ProfessionalTrainingTypeId { get; set; }
        public int ProfessionalTrainingCertificateIssuerId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
