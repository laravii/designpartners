using BadPractices;
using BadPractices.Domain.Decorates;
using BadPractices.Domain.Interfaces;
using BadPractices.Domain.Results;
using BadPractices.Domain.Strategies;
using BadPractices.Domain.Strategies.ActionSeasons;
using BadPractices.Domain.Strategies.Interfaces;
using MediatR;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        builder.Services
        .AddScoped<IContinentIdentificator, ContinentIdentificator>()
        .AddScoped<IWeatherValidator, WeatherValidator>()
        .AddScoped<ISeasonIdentificator, SeasonIdentificator>()
        .AddScoped<IActionBySeasonStrategy, ActionBySeasonStrategy>()
        .AddScoped<IActionSeason, PrimaveraActionSeason>()
        .AddScoped<IActionSeason, VeraoActionSeason>()
        .AddScoped<IActionSeason, OutonoActionSeason>()
        .AddScoped<IActionSeason, InvernoActionSeason>();

        builder.Services
        .AddScoped<IPipelineBehavior<SeasonWrapper, SeasonsResult>, ContinentHandlerDecorate>()
        .AddScoped<IPipelineBehavior<SeasonWrapper, SeasonsResult>, SeasonHandlerDecorate>();

        builder.Services.AddMediatR(typeof(SeasonCommand));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                // opt.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                // opt.RoutePrefix = string.Empty;
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
