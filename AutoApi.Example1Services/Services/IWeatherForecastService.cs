using Developworx.AutoApi.Core.Services;
using Developworx.AutoApi.Example1Services.Models;
using Microsoft.AspNetCore.Http;

namespace Developworx.AutoApi.Example1Services.Services;

public interface IWeatherForecastService : IApplicationService
{
  
    string UploadFile1(IFormFile file);
}