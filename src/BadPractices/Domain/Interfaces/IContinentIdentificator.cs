using BadPractices.Domain.Constants;
using BadPractices.Domain.Models;

namespace BadPractices.Domain.Interfaces
{
    public interface IContinentIdentificator
    {
        Task<string> FindContinent(string country);
    }
    public class ContinentIdentificator : IContinentIdentificator
    {
        private CountriesPerContinent continents = new();

        public Task<string> FindContinent(string country)
        {
            if (continents.Africanountries.Any(c => c == country))
            {
                return Task.FromResult(ContinentsNames.AFICAN_CONTINENT);
            }

            if (continents.AntarticCountries.Any(c => c == country))
            {
                return Task.FromResult(ContinentsNames.ANTARTIC_CONTINENT);
            }

            if (continents.AsiaticsCountries.Any(c => c == country))
            {
                return Task.FromResult(ContinentsNames.ASIATIC_CONTINENT);
            }

            if (continents.EuropeCountries.Any(c => c == country))
            {
                return Task.FromResult(ContinentsNames.EUROPE_CONTINENT);
            }

            if (continents.OceanCountries.Any(c => c == country))
            {
                return Task.FromResult(ContinentsNames.OCEAN_CONTINENT);
            }

            if (continents.AmericanCountries.Any(c => c == country))
            {
                return Task.FromResult(ContinentsNames.AMERICAN_CONTINENT);
            }

            return Task.FromResult("Pais não cadastrado");

        }
    }
}