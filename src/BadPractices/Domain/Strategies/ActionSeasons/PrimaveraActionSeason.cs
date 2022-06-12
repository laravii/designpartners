using BadPractices.Domain.Constants;
using BadPractices.Domain.Strategies.Interfaces;

namespace BadPractices.Domain.Strategies.ActionSeasons
{
    public class PrimaveraActionSeason : IActionSeason
    {
        public Seasons Season { get { return Seasons.Primavera; } }

        public Task<string> MessageGenerate(string temperature, string country)
        {
            var message = $"Oba esta primavera";

            if (temperature.Equals("Frio"))
            {
                return Task.FromResult($"{message}, uma pena estar {temperature} no {country}, que tal um jogo");
            }

            return Task.FromResult($"{message}, e faz {temperature} {country}, vai uma piscina?");
        }
    }
}