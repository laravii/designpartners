using BadPractices.Domain.Interfaces;
using BadPractices.Domain.Results;
using MediatR;

namespace BadPractices.Domain.Decorates
{
    public class SeasonHandlerDecorate : IPipelineBehavior<SeasonWrapper, SeasonsResult>
    {
        private readonly ISeasonIdentificator _seasonIdentificator;


        public SeasonHandlerDecorate(ISeasonIdentificator seasonIdentificator)
        {
            _seasonIdentificator = seasonIdentificator;
        }

        public async Task<SeasonsResult> Handle(SeasonWrapper request, CancellationToken cancellationToken, RequestHandlerDelegate<SeasonsResult> next)
        {
            var result = new SeasonsResult() { Season = "Hello World!" };
            var season = await _seasonIdentificator.GetSeason(request.Command.Date, request.Command.Country);

            if (season.Equals("Sem informacoes de estacao para esse local"))
            {
                result.Season = season;
                return result;
            }
            request.Season = season;
            return await next();
        }
    }
}