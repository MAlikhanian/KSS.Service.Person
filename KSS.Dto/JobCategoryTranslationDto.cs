namespace KSS.Dto
{
    public class JobCategoryTranslationDto
    {
        public short JobCategoryId { get; set; }
        public short LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
