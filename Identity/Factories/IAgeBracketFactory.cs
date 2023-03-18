using Identity.Factories.AgeGenerations;

namespace Identity.Factories
{
    /// <summary>
    /// This interface is responsible for creating the correct IAgeGeneration object
    /// based on the age bracket.
    /// </summary>
    public interface IAgeBracketFactory
    {
        /// <summary>
        /// This method use to identify the age generation with the given.
        /// param <paramref name="age"/>.
        /// </summary>
        /// <param name="age"></param>
        /// <returns>
        /// <see cref="IAgeGeneration"/> IAgeGeneration
        /// </returns>
        IAgeGeneration GetAgeGeneration(int age);
    }
}
