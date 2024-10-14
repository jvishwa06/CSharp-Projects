var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MongoWeatherService>();
builder.Services.AddSingleton<MongoUserService>(); 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
