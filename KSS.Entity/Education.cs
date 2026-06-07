using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("Education", Schema = "dbo")]
    public class Education
    {
        [Key]
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
        public bool IsActive { get; set; } = true;

        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; } = null!;
        [ForeignKey(nameof(EducationLevelId))]
        public EducationLevel EducationLevel { get; set; } = null!;
        [ForeignKey(nameof(FieldOfStudyId))]
        public FieldOfStudy FieldOfStudy { get; set; } = null!;
        [ForeignKey(nameof(InstitutionId))]
        public Institution Institution { get; set; } = null!;
        public ICollection<EducationDocument> EducationDocuments { get; set; } = new List<EducationDocument>();
    }
}
