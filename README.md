[![Nuget](https://github.com/dadotnetkid/AutoApi/actions/workflows/main.yml/badge.svg)](https://github.com/dadotnetkid/AutoApi/actions/workflows/main.yml)
[![NuGet Download](https://img.shields.io/nuget/dt/Developworx.AutoApi.Core.svg?style=flat-square)](https://www.nuget.org/packages/Developworx.AutoApi.Core 
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
![image](https://github.com/dadotnetkid/AutoApi/assets/13300183/d6904057-c2f4-4045-a89e-f1e69f34c7e3)

