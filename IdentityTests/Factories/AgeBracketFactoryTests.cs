using Identity.Factories;

namespace IdentityTests.Factories
{
    public class AgeBracketFactoryTests
    {
        private readonly IAgeBracketFactory _ageBracketFactory;

        public AgeBracketFactoryTests()
        {
            _ageBracketFactory = new AgeBracketFactory();
        }

        [Fact]
        public void GetAgeGeneration_ValidAge_ReturnsAgeGeneration()
        {
            // Arrange
            var age = 54;
            var expectedAgeBracket = "Gen X";

            // Act
            var result = _ageBracketFactory.GetAgeGeneration(age).Render();

            // Assert
            Assert.Equal(expectedAgeBracket, result);
        }

    }
}
