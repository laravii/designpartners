using BadPractices.Domain.Constants;
using BadPractices.Domain.Strategies.Interfaces;

namespace BadPractices.Domain.Strategies.ActionSeasons
{
    public class OutonoActionSeason : IActionSeason
    {
        public Seasons Season { get { return Seasons.Outono; } }

        public Task<string> MessageGenerate(string temperature, string country)
        {
            var message = $"Oba esta outono";

            if (temperature.Equals("Frio"))
            {
                return Task.FromResult($"{message}, nomalmente {temperature} no {country}, que tal um chocolate quente?");
            }

            return Task.FromResult($"{message}, e faz {temperature} {country}, ir ao parque");
        }
    }
}