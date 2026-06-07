namespace KSS.Service.IService
{
    /// <summary>
    /// Shared visibility check used by Person.Find and every per-person sub-entity
    /// list endpoint (Email/Phone/Address/Education/Employment/etc.).
    ///
    /// Mirrors the rules in PersonService.ToListAsync — keeping a single source
    /// of truth means the "who can see person X" decision is identical whether
    /// you reach X through the list, the detail endpoint, or any sub-collection.
    ///
    /// Rules (any one passes):
    ///   1. Caller IS the person (self).
    ///   2. Caller has a global RoleAccess row (PersonId IS NULL) for any of
    ///      their roles — SuperAdmin / PersonAdmin pattern.
    ///   3. Per-person Access row links caller → target.
    ///   4. Per-person RoleAccess for one of caller's roles scoped to target.
    /// </summary>
    public interface IPersonAccessChecker
    {
        /// <summary>Returns true if the current caller may read the given person.</summary>
        Task<bool> CanSeeAsync(Guid personId);

        /// <summary>Throws BusinessRuleException with a Persian message if the caller may not read the given person.</summary>
        Task EnsureCanSeeAsync(Guid personId);
    }
}
