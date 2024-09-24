namespace BlazorWeatherApp.Services
{
    public class WeatherData
    {
        public Main main { get; set; }
        public string name { get; set; }

        public class Main
        {
            public float temp { get; set; }
            public float feels_like { get; set; }
            public int humidity { get; set; }
        }
    }
}
