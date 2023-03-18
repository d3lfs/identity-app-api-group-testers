namespace Identity.Responses
{
    /// <summary>
    /// The response of the consumed API from the IdentityService.
    /// </summary>
    public class IdentityResponse
    {
        /// <summary>
        /// The name of the person from the API.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The gender of the person.
        /// </summary>
        public string? Gender { get; set; }

        /// <summary>
        /// The country of the person from the API.
        /// </summary>
        public string? Country { get; set; }

        /// <summary>
        /// The age of the person from the API.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// The age bracket of the person's age.
        /// </summary>
        public string? AgeBracket { get; set; }
    }
}
