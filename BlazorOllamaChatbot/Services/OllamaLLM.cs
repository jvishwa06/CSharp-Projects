using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OllamaChatbot.Services
{
    public class OllamaLLM
    {
        private readonly string _model;
        private readonly HttpClient _httpClient;

        public OllamaLLM(string model)
        {
            // Ensure model is not null or empty
            _model = string.IsNullOrWhiteSpace(model) 
                ? throw new ArgumentException("Model cannot be null or empty.", nameof(model)) 
                : model;

            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:11434/") };
        }

        public async Task<string> InvokeAsync(string? input)
        {
            // Ensure input is not null
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input cannot be null or empty.", nameof(input));
            }

            var request = new { model = _model, prompt = input };
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            // Use HttpResponseMessage to capture streamed responses
            using var response = await _httpClient.PostAsync("api/generate", content);
            response.EnsureSuccessStatusCode(); // Throw if not a success code.

            var result = new StringBuilder(); // Use StringBuilder for performance

            using (var reader = new System.IO.StreamReader(await response.Content.ReadAsStreamAsync()))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    try
                    {
                        // Deserialize each JSON object separately
                        using var jsonDoc = JsonSerializer.Deserialize<JsonDocument>(line);
                        if (jsonDoc != null && jsonDoc.RootElement.GetProperty("done").GetBoolean())
                        {
                            break; // Stop when we hit the final response
                        }

                        result.Append(jsonDoc?.RootElement.GetProperty("response").GetString());
                    }
                    catch (JsonException ex)
                    {
                        Console.WriteLine($"Deserialization error: {ex.Message}");
                    }
                }
            }

            return result.ToString(); // Return the final result as a string
        }
    }
}
