using Developworx.AutoApi.Core.Services;
using Developworx.AutoApi.Example1Services.Models;

namespace Developworx.AutoApi.Example1Services.Services;

public interface IWeatherForecastService : IApplicationService
{
    string Get();
    string Post(WeatherForecast model);
    string Modify(WeatherForecast model);
}