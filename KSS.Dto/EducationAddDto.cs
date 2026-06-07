namespace KSS.Dto
{
    public class EducationAddDto
    {
        public Guid PersonId { get; set; }
        public int EducationLevelId { get; set; }
        public int FieldOfStudyId { get; set; }
        public int InstitutionId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? GPA { get; set; }
        public bool IsCompleted { get; set; }
    }
}
