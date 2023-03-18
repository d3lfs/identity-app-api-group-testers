using Identity.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Identity.Responses;
using Identity.Services;

namespace IdentityTests.Controllers
{
    public class IdentityControllerTests
    {
        private IdentityController _controller;
        private Mock<IIdentityService> _mockIdentityService;
        private readonly Mock<ILogger<IdentityController>> _logger;

        public IdentityControllerTests()
        {
            _mockIdentityService = new Mock<IIdentityService>();
            _logger = new Mock<ILogger<IdentityController>>();
            _controller = new IdentityController(_logger.Object, _mockIdentityService.Object);
        }

        [Fact]
        public async Task GetIdentity_ValidName_ReturnsOk()
        {
            // Arrange
            var testName = "Brent";
            _mockIdentityService.Setup(service => service.GetIdentity(testName))
                .ReturnsAsync(new IdentityResponse());

            // Act
            var response = await _controller.GetIdentity(testName);

            // Assert
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetIdentity_Exception_ReturnsInternalServerError()
        {
            // Arrange
            var testName = "Brent";
            _mockIdentityService.Setup(service => service.GetIdentity(testName))
                .Throws(new Exception());

            // Act
            var response = await _controller.GetIdentity(testName);

            // Assert
            Assert.IsType<ObjectResult>(response);
            Assert.Equal(500, ((ObjectResult)response).StatusCode);
        }
    }
}