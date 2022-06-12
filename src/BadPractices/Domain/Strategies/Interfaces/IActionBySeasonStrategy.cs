namespace BadPractices.Domain.Strategies.Interfaces
{
    public interface IActionBySeasonStrategy
    {
        IActionSeason ActionBySeason(string season);
    }
}