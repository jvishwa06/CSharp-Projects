using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace BlazorWeatherApp.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "2a4196ee6b0e779548ceaa014894a13b";
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherData> GetWeatherAsync(string city)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}?q={city}&appid={ApiKey}&units=metric");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<WeatherData>(json);
        }
    }
}
