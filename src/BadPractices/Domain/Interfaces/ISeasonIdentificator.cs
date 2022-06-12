using System.Net.Http.Headers;
using System.Linq.Expressions;
using BadPractices.Domain.Handlers;
using BadPractices.Domain.Constants;

namespace BadPractices.Domain.Interfaces
{
    public interface ISeasonIdentificator
    {
        Task<string> GetSeason(DateTime date, string country);
    }

    public class SeasonIdentificator : ISeasonIdentificator
    {
        private string? _season;
        public Task<string> GetSeason(DateTime date, string country)
        {
            if (!country.Equals("Brasil"))
            {
                return Task.FromResult("Sem informacoes de estacao para esse local");
            }

            switch (date.Month)
            {
                case int month when month >= 3 && month < 6:
                    _season = Seasons.Outono.ToString();
                    break;
                case int month when month >= 6 && month < 9:
                    _season = Seasons.Inverno.ToString();
                    break;
                case int month when month >= 9 && month < 12:
                    _season = Seasons.Primavera.ToString();
                    break;
                default:
                    _season = Seasons.Verao.ToString();
                    break;
            }
            return Task.FromResult(_season);

        }
    }
}