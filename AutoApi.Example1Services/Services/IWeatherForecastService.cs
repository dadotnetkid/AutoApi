using AutoApi.Core.Services;
using AutoApi.Example1Services.Models;

namespace AutoApi.Example1Services.Services;

public interface IWeatherForecastService : IApplicationService
{
    public string Get();
    string Post(WeatherForecast model);
    string Modify(WeatherForecast model);
}