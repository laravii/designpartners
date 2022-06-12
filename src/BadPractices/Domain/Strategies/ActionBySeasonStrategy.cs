using BadPractices.Domain.Strategies.Interfaces;

namespace BadPractices.Domain.Strategies
{
    public class ActionBySeasonStrategy : IActionBySeasonStrategy
    {
        private readonly IEnumerable<IActionSeason> _actionSeasons;

        public ActionBySeasonStrategy(IEnumerable<IActionSeason> actionSeasons)
        {
            _actionSeasons = actionSeasons;
        }

        public IActionSeason ActionBySeason(string season)
        {
            return _actionSeasons.FirstOrDefault(x => x.Season.ToString() == season);
        }
    }
}