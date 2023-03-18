using Identity.Responses;

namespace Identity.Services
{
    /// <summary>
    /// This interface service is use to get the identity of the user.
    /// </summary>
    public interface IIdentityService
    {
        /// <summary>
        /// Gets the identity of a person with the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>
        /// <see cref="Task{AgeGenerationResponse}"/> IdentityResponse.
        /// </returns>
        Task<IdentityResponse> GetIdentity(string name);
    }
}
