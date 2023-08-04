[![Nuget](https://github.com/dadotnetkid/AutoApi/actions/workflows/main.yml/badge.svg)](https://github.com/dadotnetkid/AutoApi/actions/workflows/main.yml)
[![NuGet Download](https://img.shields.io/nuget/dt/Developworx.AutoApi.Core.svg?style=flat-square)](https://www.nuget.org/packages/Developworx.AutoApi.Core)
# AutoApi
`Auto Api is where you dont need to create controller. 
It transform the services into Api Endpoint
`
> ## 1.0.1
> 
> - Added support for IFormFile and IFormCollection

## How To use

### In Program.cs

``` Program.cs
  builder.Services
      .AddAutoService()
      .AddAutoApi();
```
### In Services

#### Implementation
```c#
using Developworx.AutoApi.Core.Services;
using Developworx.AutoApi.Example1Services.Models;

namespace AutoApi.Example1Services.Services
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

```


#### Interface
```c#
using Developworx.AutoApi.Core.Services;
using Developworx.AutoApi.Example1Services.Models;

namespace AutoApi.Example1Services.Services;

public interface IWeatherForecastService : IApplicationService
{
    IEnumerable<WeatherForecast> Get();
    string Post(WeatherForecast model);
    string Modify(WeatherForecast model);
}

```
![image](https://github.com/dadotnetkid/AutoApi/assets/13300183/44f4c231-55c8-4775-a70b-e70d92ca66c6)

![image](https://github.com/dadotnetkid/AutoApi/assets/13300183/d6904057-c2f4-4045-a89e-f1e69f34c7e3)

