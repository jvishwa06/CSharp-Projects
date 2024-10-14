using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using vishu;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register HttpClient with the Web API base address
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5134/") });

// Register WeatherService and MudBlazor services
builder.Services.AddScoped<WeatherService>(); 
builder.Services.AddMudServices();
builder.Services.AddSingleton<AuthService>();


await builder.Build().RunAsync();
