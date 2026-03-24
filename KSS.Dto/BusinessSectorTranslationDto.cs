namespace KSS.Dto
{
    public class BusinessSectorTranslationDto
    {
        public short BusinessSectorId { get; set; }
        public short LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
