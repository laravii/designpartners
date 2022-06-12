namespace BadPractices.Domain.Interfaces
{
    public interface IWeatherValidator
    {
        Task<string> GetWeather(int temperatureC);
    }

    public class WeatherValidator : IWeatherValidator
    {
        public Task<string> GetWeather(int temperatureC)
        {
            if (temperatureC > 25)
            {
                return Task.FromResult("Quente");
            }

            return Task.FromResult("Frio");
        }
    }
}