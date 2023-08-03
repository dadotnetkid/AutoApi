﻿using AutoApi.Core.Services;
using AutoApi.Example1Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoApi.Example1Services.Services
{
    public class WeatherForecastService : ApplicationService, IWeatherForecastService
    {

        [HttpGet]
        public string Get()
        {
            return "Hell World";
        }
        [HttpPost]
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
