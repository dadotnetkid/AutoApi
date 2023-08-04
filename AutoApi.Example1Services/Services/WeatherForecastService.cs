using Developworx.AutoApi.Core.Services;
using Developworx.AutoApi.Example1Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Developworx.AutoApi.Example1Services.Services
{
    public class WeatherForecastService : ApplicationService, IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public string UploadFile1(IFormFile file)
        {
            throw new NotImplementedException();
        }
        public string UploadFile2(IFormFileCollection file)
        {
            throw new NotImplementedException();
        }
    }
}
