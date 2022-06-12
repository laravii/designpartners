using BadPractices.Domain.Constants;
using BadPractices.Domain.Strategies.Interfaces;

namespace BadPractices.Domain.Strategies.ActionSeasons
{
    public class InvernoActionSeason : IActionSeason
    {
        public Seasons Season { get { return Seasons.Inverno; } }

        public Task<string> MessageGenerate(string temperature, string country)
        {
            var message = $"Oba esta inverno";

            if (temperature.Equals("Frio"))
            {
                return Task.FromResult($"{message}, e {temperature} no {country}, que tal se aquecer bem?");
            }

            return Task.FromResult($"{message}, e faz {temperature} {country}, jogar bola");
        }
    }
}