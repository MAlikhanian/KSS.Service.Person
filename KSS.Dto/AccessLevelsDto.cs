namespace KSS.Dto
{
    /// <summary>
    /// Returned to a caller asking "what are my levels for this person?".
    /// Each value is 0=None, 1=View, 2=Edit. Owners always see 2/2/2/2.
    /// </summary>
    public class AccessLevelsDto
    {
        public int Information { get; set; }
        public int Assets      { get; set; }
        public int Access      { get; set; }
        public int Security    { get; set; }
    }
}
