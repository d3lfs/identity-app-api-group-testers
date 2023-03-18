using Identity.Responses;
using Refit;

namespace Identity.Clients
{
    /// <summary>
    /// Client for the Gender API
    /// </summary>
    public interface IGenderizeClient
    {
        /// <summary>
        /// Get gender of the client.
        /// </summary>
        /// <param name="name">Name of the client</param>
        /// <returns>Gender</returns>
        [Get("/")]
        Task<GenderResponse> GetGender(string name);
    }
}
