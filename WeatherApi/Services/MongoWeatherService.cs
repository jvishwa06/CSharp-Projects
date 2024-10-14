using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

// Service to interact with MongoDB
public class MongoWeatherService
{
    private readonly IMongoCollection<BsonDocument> _weatherCollection;

    // Constructor to initialize MongoDB connection and collection
    public MongoWeatherService()
    {
        var client = new MongoClient("mongodb://localhost:27017"); // MongoDB connection string
        var database = client.GetDatabase("WeatherDB"); // Replace with your DB name
        _weatherCollection = database.GetCollection<BsonDocument>("WeatherData"); // Replace with your collection name
    }

    // Method to add weather data to MongoDB
    public async Task AddWeatherData(WeatherResponse weatherData)
    {
        DateTime utcTime = DateTime.UtcNow;

        // Convert UTC time to Indian Standard Time (IST)
        TimeZoneInfo indiaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime istTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, indiaTimeZone);

        // Format the IST time as MM/dd/yyyy HH:mm
        string timestamp = istTime.ToString("MM/dd/yyyy HH:mm");

        var document = new BsonDocument
        {
            { "City", weatherData.Name },
            { "Temperature", weatherData.Main?.Temp },
            { "Humidity", weatherData.Main?.Humidity },
            { "Pressure", weatherData.Main?.Pressure },
            { "Timestamp", timestamp }
        };

        await _weatherCollection.InsertOneAsync(document);
    }
}

// Class to store weather data fetched from Blazor App 
public class WeatherResponse
{
    public Main? Main { get; set; }
    public string? Name { get; set; }
}

// Class to store main weather data (Temperature, Pressure, Humidity)
public class Main
{
    public float? Temp { get; set; }
    public float? Pressure { get; set; }
    public float? Humidity { get; set; }
}
