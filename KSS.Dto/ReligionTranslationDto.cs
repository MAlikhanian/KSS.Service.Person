namespace KSS.Dto
{
    public class ReligionTranslationDto
    {
        public short ReligionId { get; set; }
        public short LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
