namespace KSS.Dto
{
    public class JobDepartmentTranslationDto
    {
        public short JobDepartmentId { get; set; }
        public short LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
