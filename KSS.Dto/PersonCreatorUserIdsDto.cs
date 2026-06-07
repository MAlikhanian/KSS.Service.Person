namespace KSS.Dto
{
    /// <summary>
    /// Distinct list of UserIds that have inserted at least one Person row
    /// (Person.CreatedBy values). Powers the dashboard "Companies × User
    /// Created Persons" tile — the frontend joins this list with the access
    /// grants from Company and the person→user map from Auth.
    /// </summary>
    public class PersonCreatorUserIdsDto
    {
        public List<System.Guid> UserIds { get; set; } = new();
    }
}
