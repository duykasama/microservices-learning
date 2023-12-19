using Microsoft.AspNetCore.Mvc;
using NetCore.WebApiCommon.Api.Controllers;
using NetCore.WebApiCommon.Api.Models;

namespace NetCore.Microservices.Services.CouponApi.Controllers;

[Route("[controller]")]
public class WeatherForecastController : BaseController
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get()
    {
        var apiActionResult = new ApiActionResult(true){Data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray()};

        return await ExecuteApiAsync(
            () => Task.FromResult(apiActionResult)
        ).ConfigureAwait(false);
    }
}