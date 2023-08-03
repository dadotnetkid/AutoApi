# AutoApi
`Auto Api is where you dont need to create controller. 
It transform the services into Api Endpoint
`


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
using AutoApi.Core.Services;
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

```


#### Interface
```c#
using AutoApi.Core.Services;
using AutoApi.Example1Services.Models;

namespace AutoApi.Example1Services.Services;

public interface IWeatherForecastService : IApplicationService
{
    public string Get();
    string Post(WeatherForecast model);
    string Modify(WeatherForecast model);
}

```

