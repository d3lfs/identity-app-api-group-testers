using Identity.Models;

namespace Identity.Responses
{
    /// <summary>
    /// The response from the Country endpoint.
    /// </summary>
    public class CountryResponse
    {
        /// <summary>
        /// This property will automap the countries from the API.
        /// </summary>
        public List<Country>? Country { get; set; }
    }
}
