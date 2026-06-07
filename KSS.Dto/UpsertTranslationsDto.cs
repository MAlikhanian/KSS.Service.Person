namespace KSS.Dto
{
    /// <summary>
    /// DTO for upserting translations on an existing person.
    /// Used by PersonService.UpsertTranslationsAsync — determines add vs update per language.
    /// </summary>
    public class UpsertTranslationsDto
    {
        public Guid PersonId { get; set; }
        public List<TranslationDto> Translations { get; set; } = new();
    }
}
