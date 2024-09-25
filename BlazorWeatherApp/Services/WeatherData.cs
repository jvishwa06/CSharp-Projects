namespace BlazorWeatherApp.Services
{
        public class WeatherData
    {
        public Main? main { get; set; } // Nullable Main
        public string? name { get; set; } // Nullable string

        public class Main
        {
            public float temp { get; set; }
            public float feels_like { get; set; }
            public int humidity { get; set; }
        }
    }
}
