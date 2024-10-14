using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        private const string apiKey = "2a4196ee6b0e779548ceaa014894a13b"; // Replace with your OpenWeatherMap API key

        public Form1()
        {
            InitializeComponent();
        }

        private async void GetWeatherButton_Click(object sender, EventArgs e)
        {
            string city = cityTextBox.Text; // Assuming you have a TextBox named cityTextBox
            string weatherInfo = await GetWeatherAsync(city);
            weatherLabel.Text = weatherInfo; // Assuming you have a Label named weatherLabel
        }

        private async Task<string> GetWeatherAsync(string city)
        {
            using (HttpClient client = new HttpClient())
            {
                // Construct the API URL
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={Uri.EscapeDataString(city)}&appid={apiKey}&units=metric";
                
                try
                {
                    // Send the request and get the response
                    var response = await client.GetStringAsync(url);
                    var weatherData = JObject.Parse(response);

                    // Extract necessary data
                    var main = weatherData["main"];
                    var weather = weatherData["weather"]?[0];

                    // Ensure these fields are not null
                    string temperature = main?["temp"]?.ToString() ?? "N/A";
                    string description = weather?["description"]?.ToString() ?? "N/A";

                    return $"Temperature: {temperature}°C\nCondition: {description}";
                }
                catch (HttpRequestException e)
                {
                    return $"Error fetching data: {e.Message}";
                }
            }
        }
    }
}
