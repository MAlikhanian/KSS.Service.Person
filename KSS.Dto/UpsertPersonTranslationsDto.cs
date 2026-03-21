namespace KSS.Dto
{
    /// <summary>
    /// DTO for upserting translations on an existing person.
    /// Used by PersonService.UpsertTranslationsAsync — determines add vs update per language.
    /// </summary>
    public class UpsertPersonTranslationsDto
    {
        public Guid PersonId { get; set; }
        public List<PersonTranslationDto> Translations { get; set; } = new();
    }
}
