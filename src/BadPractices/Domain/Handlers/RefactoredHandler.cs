using BadPractices.Domain.Interfaces;
using BadPractices.Domain.Results;
using BadPractices.Domain.Strategies.Interfaces;
using MediatR;

namespace BadPractices.Domain.Handlers
{
    public class RefactoredHandler : IRequestHandler<SeasonWrapper, SeasonsResult>
    {
        private readonly IWeatherValidator _weatherValidator;
        private readonly IActionBySeasonStrategy _actionBySeasonStrategy;

        public RefactoredHandler(IWeatherValidator weatherValidator, IActionBySeasonStrategy actionBySeasonStrategy)
        {
            _weatherValidator = weatherValidator;
            _actionBySeasonStrategy = actionBySeasonStrategy;
        }

        public async Task<SeasonsResult> Handle(SeasonWrapper request, CancellationToken cancellationToken)
        {
            var temperature = await _weatherValidator.GetWeather(request.Command.TemperatureC);
            var result = new SeasonsResult() { Season = "Hello World!" };

            var actionSeason = _actionBySeasonStrategy.ActionBySeason(request.Season);

            if (actionSeason == null)
            {
                throw new NotImplementedException();
            }

            result.Season = await actionSeason.MessageGenerate(temperature, request.Command.Country);

            return result;
        }
    }
}