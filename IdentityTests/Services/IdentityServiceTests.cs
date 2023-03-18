using Identity.Clients;
using Identity.Factories;
using Identity.Factories.AgeGenerations;
using Identity.Models;
using Identity.Responses;
using Identity.Services;
using Moq;

namespace IdentityTests.Services
{
    public class IdentityServiceTests
    {
        private readonly IIdentityService _identityService;
        private Mock<IAgifyClient> _mockAgifyClient;
        private Mock<IGenderizeClient> _mockGenderizeClient;
        private Mock<INationalizeClient> _mockNationalizeClient;
        private Mock<IAgeBracketFactory> _mockAgeBracketFactory;

        public IdentityServiceTests()
        {
            _mockAgifyClient = new Mock<IAgifyClient>();
            _mockGenderizeClient = new Mock<IGenderizeClient>();
            _mockNationalizeClient = new Mock<INationalizeClient>();
            _mockAgeBracketFactory = new Mock<IAgeBracketFactory>();
            _identityService = new IdentityService(_mockAgifyClient.Object, _mockGenderizeClient.Object, _mockNationalizeClient.Object, _mockAgeBracketFactory.Object);
        }

        [Fact]
        public async Task GetIdentity_ValidName_ReturnsIdentityResponse()
        {
            // Arrange
            var testName = "Brent";
            var expectedGender = "male";
            var expectedCountry = "NZ";
            var expectedAge = 54;
            var expectedAgeBracket = "Gen X";
            List<Country> countryList = new List<Country>();
            countryList.Add(new Country { Country_Id = "NZ" });

            _mockGenderizeClient.Setup(c => c.GetGender(It.IsAny<string>()))
                .ReturnsAsync(new GenderResponse { Gender = "male" });
            _mockNationalizeClient.Setup(c => c.GetCountry(It.IsAny<string>()))
                .ReturnsAsync(new CountryResponse { Country = countryList });
            _mockAgifyClient.Setup(c => c.GetAge(It.IsAny<string>()))
                .ReturnsAsync(new AgeResponse { Age = 54 });
            _mockAgeBracketFactory.Setup(c => c.GetAgeGeneration(It.IsAny<int>()))
                .Returns(new GenXGeneration());

            // Act
            var result = await _identityService.GetIdentity(testName);

            // Assert
            Assert.IsType<IdentityResponse>(result);
            Assert.Equal(expectedGender, result!.Gender);
            Assert.Equal(expectedCountry, result!.Country);
            Assert.Equal(expectedAge, result!.Age);
            Assert.Equal(expectedAgeBracket, result!.AgeBracket);
        }
    }
}
