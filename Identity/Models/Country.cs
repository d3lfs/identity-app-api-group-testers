namespace Identity.Models
{
    /// <summary>
    /// A Country model that is used to deserialize the response from the Nationalize API.
    /// </summary>
    public class Country
    {
        /// <summary>
        /// This property is from the nationalize api object keys.
        /// </summary>
        public string? Country_Id { get; set; }
    }
}
