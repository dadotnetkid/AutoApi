using Developworx.AutoApi.Core.Services;
using Developworx.AutoApi.Example1Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Developworx.AutoApi.Example1Services.Services
{
    public class WeatherForecastService : ApplicationService, IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
        }
        public string Post(WeatherForecast model)
        {
            return "Hell World";
        }

        public string Modify(WeatherForecast model)
        {
            return model.Summary;
        }
    }
}
