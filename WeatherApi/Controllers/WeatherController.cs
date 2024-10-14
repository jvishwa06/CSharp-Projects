using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// Controller for managing weather data
[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly MongoWeatherService _mongoWeatherService;

    // Inject MongoWeatherService through the constructor
    public WeatherController(MongoWeatherService mongoWeatherService)
    {
        _mongoWeatherService = mongoWeatherService;
    }

    // POST endpoint to add weather data
    [HttpPost("add")]
    public async Task<IActionResult> AddWeatherData([FromBody] WeatherResponse weatherData)
    {
        if (weatherData == null)
        {
            return BadRequest("Invalid weather data");
        }

        await _mongoWeatherService.AddWeatherData(weatherData);
        return Ok("Weather data added successfully");
    }
}
