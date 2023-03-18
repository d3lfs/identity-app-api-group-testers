using Identity.Responses;
using Refit;

namespace Identity.Clients
{
    /// <summary>
    /// Client for the National API
    /// </summary>
    public interface INationalizeClient
    {
        /// <summary>
        /// Get country of the client
        /// </summary>
        /// <param name="name">Name of the client</param>
        /// <returns>Country</returns>
        [Get("/")]
        Task<CountryResponse> GetCountry(string name);
    }
}
