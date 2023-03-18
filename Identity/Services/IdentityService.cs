using Identity.Clients;
using Identity.Factories;
using Identity.Responses;

namespace Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IAgifyClient _agifyClient;
        private readonly IGenderizeClient _genderizeClient;
        private readonly INationalizeClient _nationalizeClient;
        private readonly IAgeBracketFactory _ageBracketFactory;

        public IdentityService(IAgifyClient agifyClient, IGenderizeClient genderizeClient, INationalizeClient nationalizeClient, IAgeBracketFactory ageBracketFactory)
        {
            _agifyClient = agifyClient;
            _genderizeClient = genderizeClient;
            _nationalizeClient = nationalizeClient;
            _ageBracketFactory = ageBracketFactory;
        }

        public async Task<IdentityResponse> GetIdentity(string name)
        {
            var ageResponse = await _agifyClient.GetAge(name);
            var genderResponse = await _genderizeClient.GetGender(name);
            var ageBracketRespnose = _ageBracketFactory.GetAgeGeneration(ageResponse.Age);
            var countryResponse = await _nationalizeClient.GetCountry(name);

            return new IdentityResponse
            {
                Name = name,
                Age = ageResponse.Age,
                Gender = genderResponse.Gender,
                Country = countryResponse.Country?.First().Country_Id,
                AgeBracket = ageBracketRespnose.Render()
            };
        }
    }
}