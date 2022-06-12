using BadPractices.Domain.Constants;
using BadPractices.Domain.Strategies.Interfaces;

namespace BadPractices.Domain.Strategies.ActionSeasons
{
    public class VeraoActionSeason : IActionSeason
    {
        public Seasons Season { get { return Seasons.Verao; } }

        public Task<string> MessageGenerate(string temperature, string country)
        {
            var message = $"Oba esta verão";

            if (temperature.Equals("Frio"))
            {
                return Task.FromResult($"{message}, uma pena estar {temperature} no {country}, aproveita pra ficar em casa");

            }

            return Task.FromResult($"{message}, e faz {temperature} {country}, aproveita para tomar um sorvete");
        }
    }
}