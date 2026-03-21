namespace KSS.Dto
{
    public class MaritalStatusTranslationDto
    {
        public byte MaritalStatusId { get; set; }
        public short LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
