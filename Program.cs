using EffectiveMobile.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddScoped<IAdvertisementService, AdvertisementService>();

var app = builder.Build();

app.UseCors("AllowAll"); 

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
