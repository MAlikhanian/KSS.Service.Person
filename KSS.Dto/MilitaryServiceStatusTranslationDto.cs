namespace KSS.Dto
{
    public class MilitaryServiceStatusTranslationDto
    {
        public byte MilitaryServiceStatusId { get; set; }
        public short LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
