namespace KSS.Dto
{
    public class JobTitleTranslationDto
    {
        public short JobTitleId { get; set; }
        public short LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
