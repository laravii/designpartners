using BadPractices.Domain.Constants;

namespace BadPractices.Domain.Strategies.Interfaces
{
    public interface IActionSeason
    {
        Seasons Season { get; }
        Task<string> MessageGenerate(string temperature, string country);
    }

}