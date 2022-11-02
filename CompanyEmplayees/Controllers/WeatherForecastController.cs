using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmplayees.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        public WeatherForecastController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Here is LogInfo from WeatherForecast");
            _logger.LogDebug("Here is LogDebug from WeatherForecast");
            _logger.LogError("Here is LogError from WeatherForecast");
            _logger.LogWarn("Here is LogWarn from WeatherForecast");

            return new string[] { "value1, value2" };
        }
    }
}