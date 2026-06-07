using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSS.Entity
{
    [Table("Employment", Schema = "dbo")]
    public class Employment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid CompanyId { get; set; }
        public byte ContractTypeId { get; set; }
        public short BusinessSectorId { get; set; }
        public short BusinessUnitId { get; set; }
        public short JobPositionId { get; set; }
        [Column(TypeName = "date")]
        public DateTime FromDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ToDate { get; set; }
        public bool IsPrimary { get; set; }
        public byte SortOrder { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; } = true;

        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; } = null!;
        [ForeignKey(nameof(ContractTypeId))]
        public ContractType ContractType { get; set; } = null!;

        public ICollection<EmploymentDocument> EmploymentDocuments { get; set; } = new List<EmploymentDocument>();
    }
}
