using AutoApi.Example1Services.Models;
using Developworx.AutoApi.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoApi.Example1Services.Services
{
    public class WeatherForecastService : ApplicationService, IWeatherForecastService
    {

        public string Get()
        {
            return "Hell World";
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
