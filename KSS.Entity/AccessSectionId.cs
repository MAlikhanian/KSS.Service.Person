namespace KSS.Entity
{
    /// <summary>
    /// Byte ID constants for the AccessSection lookup. The actual rows live
    /// in dbo.AccessSection (seeded by migration 010). Use these in switch /
    /// comparison logic instead of magic numbers.
    /// </summary>
    public static class AccessSectionId
    {
        public const byte Information = 1;
        public const byte Assets      = 2;
        public const byte Access      = 3;
        public const byte Security    = 4;
    }
}
