namespace KSS.Dto
{
    public class InsuranceTypeTranslationDto
    {
        public byte InsuranceTypeId { get; set; }
        public short LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
