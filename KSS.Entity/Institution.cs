using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KSS.Entity
{
    [Table("Institution", Schema = "dbo")]
    public class Institution
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Unicode(false)]
        public string Code { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public int RegionId { get; set; }
        public int CityId { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<InstitutionTranslation> Translations { get; set; } = new List<InstitutionTranslation>();
        public ICollection<Education> Educations { get; set; } = new List<Education>();
    }
}
