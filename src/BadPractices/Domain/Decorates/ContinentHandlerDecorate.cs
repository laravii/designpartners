using BadPractices.Domain.Interfaces;
using BadPractices.Domain.Results;
using MediatR;

namespace BadPractices.Domain.Decorates
{
    public class ContinentHandlerDecorate : IPipelineBehavior<SeasonWrapper, SeasonsResult>
    {
        private readonly IContinentIdentificator _continentIdentificator;

        public ContinentHandlerDecorate(IContinentIdentificator continentIdentificator)
        {
            _continentIdentificator = continentIdentificator;
        }

        public async Task<SeasonsResult> Handle(SeasonWrapper request, CancellationToken cancellationToken, RequestHandlerDelegate<SeasonsResult> next)
        {
            var result = new SeasonsResult() { Season = "Hello World!" };
            var continent = await _continentIdentificator.FindContinent(request.Command.Country);
            if (continent.Equals("Pais não cadastrado"))
            {
                result.Season = continent;
                return result;
            }

            return await next();
        }
    }
}