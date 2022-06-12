using BadPractices.Domain.Interfaces;
using BadPractices.Domain.Results;
using MediatR;

namespace BadPractices.Domain.Handlers
{
    public class BadHandler : IRequestHandler<SeasonCommand, SeasonsResult>
    {
        private readonly IWeatherValidator _weatherValidator;
        private readonly ISeasonIdentificator _seasonIdentificator;
        private readonly IContinentIdentificator _continentIdentificator;

        public BadHandler(IWeatherValidator weatherValidator, ISeasonIdentificator seasonIdentificator, IContinentIdentificator continentIdentificator)
        {
            _weatherValidator = weatherValidator;
            _seasonIdentificator = seasonIdentificator;
            _continentIdentificator = continentIdentificator;
        }

        public async Task<SeasonsResult> Handle(SeasonCommand request, CancellationToken cancellationToken)
        {
            var result = new SeasonsResult() { Season = "Hello World!" };
            try
            {
                var temperature = await _weatherValidator.GetWeather(request.TemperatureC);
                var continent = await _continentIdentificator.FindContinent(request.Country);
                if (continent.Equals("Pais não cadastrado"))
                {
                    result.Season = continent;
                    return result;
                }

                var season = await _seasonIdentificator.GetSeason(request.Date, request.Country);
                if (season.Equals("Sem informacoes de estacao para esse local"))
                {
                    result.Season = season;
                    return result;
                }

                if (season.Equals("Verão"))
                {
                    var message = $"Oba esta verão no continente {continent}";

                    if (temperature.Equals("Frio"))
                    {
                        result.Season = $"{message}, uma pena estar {temperature} no {request.Country}, aproveita pra ficar em casa";
                    }

                    result.Season = $"{message}, e faz {temperature} {request.Country}, aproveita tomar um sorvete";

                    return result;

                }
                else if (season.Equals("Outono"))
                {
                    var message = $"Oba esta outono no continente {continent}";

                    if (temperature.Equals("Frio"))
                    {
                        result.Season = $"{message}, nomalmente {temperature} no {request.Country}, que tal um chocolate quente?";
                    }

                    result.Season = $"{message}, e faz {temperature} {request.Country}, ir ao parque";

                    return result;

                }
                else if (season.Equals("Inverno"))
                {
                    var message = $"Oba esta inverno no continente {continent}";

                    if (temperature.Equals("Frio"))
                    {
                        result.Season = $"{message}, e {temperature} no {request.Country}, que tal se aquecer bem?";
                    }

                    result.Season = $"{message}, e faz {temperature} {request.Country}, jogar bola";

                    return result;

                }
                else if (season.Equals("Primavera"))
                {
                    var message = $"Oba esta primavera no continente {continent}";

                    if (temperature.Equals("Frio"))
                    {
                        result.Season = $"{message}, uma pena estar {temperature} no {request.Country}, que tal um jogo";
                    }

                    result.Season = $"{message}, e faz {temperature} {request.Country}, vai uma piscina?";

                    return result;
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                result.Season = $"error {ex.Message}";
                return result;
            }
        }
    }
}