namespace KSS.Dto
{
    public class JobPositionTranslationDto
    {
        public short JobPositionId { get; set; }
        public short LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
