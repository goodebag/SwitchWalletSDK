using Microsoft.AspNetCore.Mvc;
using SwitchWalletSDK.Sdk.Services.Interfaces;

namespace SwitchWalletSDK.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ISwitchWalletClient _switchWalletClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ISwitchWalletClient switchWalletClient)
        {
            _logger = logger;
            _switchWalletClient = switchWalletClient;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
           var yfgj = _switchWalletClient.GetTimedTransactionRecordAsync().Result;
            return Ok(yfgj);
        }
    }
}