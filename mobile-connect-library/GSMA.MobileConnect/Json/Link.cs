namespace GSMA.MobileConnect.Json
{
    /// <summary>
    /// Object for deserialization of Discovery Response content
    /// </summary>
    public class Link
    {
        /// <summary>
        /// Parsed from JSON response
        /// </summary>
        public string href { get; set; }
        /// <summary>
        /// Parsed from JSON response
        /// </summary>
        public string rel { get; set; }
    }
}
