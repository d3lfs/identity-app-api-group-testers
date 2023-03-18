namespace Identity.Responses
{
    /// <summary>
    /// The response of the Gender endpoint.
    /// </summary>
    public class GenderResponse
    {
        /// <summary>
        /// This property will automap the gender from the API.
        /// </summary>
        public string? Gender { get; set; }
    }
}
