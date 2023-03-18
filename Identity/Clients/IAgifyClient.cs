using Identity.Responses;
using Refit;

namespace Identity.Clients
{
    /// <summary>
    /// Client for the Age API
    /// </summary>
    public interface IAgifyClient
    {
        /// <summary>
        /// Get age of the client with the parameter <paramref name="name"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>
        /// <see cref="Task{AgeResponse}"/> AgeResponse
        /// </returns>
        [Get("/")]
        Task<AgeResponse> GetAge(string name);
    }
}
