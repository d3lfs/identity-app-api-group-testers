using Identity.Responses;
using Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly ILogger<IdentityController> _logger;

        public IdentityController(ILogger<IdentityController> logger, IIdentityService identityService)
        {
            _identityService = identityService;
            _logger = logger;
        }

        /// <summary>
        /// Gets the identity of the given name.
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>
        /// Returns the identity of the given name.
        /// </returns>
        /// <remarks>
        /// Sample request:
        ///  
        ///     GET /api/identity?name=John
        ///     
        /// </remarks>
        /// <response code="200">Returns identity of the given name</response>
        /// <response code="500">Something went wrong</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IdentityResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetIdentity(string name)
        {
            try
            {
                var identityResponse = await _identityService.GetIdentity(name);

                return Ok(identityResponse);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "Something went wrong.");
            }
        }
    }
}
