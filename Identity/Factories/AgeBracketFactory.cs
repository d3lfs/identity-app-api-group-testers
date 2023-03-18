using Identity.Factories.AgeGenerations;

namespace Identity.Factories
{
    public class AgeBracketFactory : IAgeBracketFactory
    {
        public IAgeGeneration GetAgeGeneration(int age)
        {
            IAgeGeneration ageGeneration;

            if (age >= 0 && age <= 9)
                ageGeneration = new GenAlphaGeneration();
            else if (age >= 10 && age <= 25)
                ageGeneration = new GenZGeneration();
            else if (age >= 26 && age <= 41)
                ageGeneration = new MillennialsGeneration();
            else if (age >= 42 && age <= 57)
                ageGeneration = new GenXGeneration();
            else if (age >= 58 && age <= 67)
                ageGeneration = new BoomersIIGeneration();
            else if (age >= 68 && age <= 76)
                ageGeneration = new BoomersIGeneration();
            else if (age >= 77 && age <= 94)
                ageGeneration = new PostWarGeneration();
            else
                ageGeneration = new WWIIGeneration();

            return ageGeneration;
        }
    }
}
