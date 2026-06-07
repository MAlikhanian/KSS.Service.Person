namespace KSS.Dto
{
    public class EducationListDto
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public int EducationLevelId { get; set; }
        public int FieldOfStudyId { get; set; }
        public int InstitutionId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? GPA { get; set; }
        public bool IsCompleted { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
