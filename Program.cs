using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EmployeeApi.Repositories;
using EmployeeApi.CQRS.Handlers;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Azure.Cosmos;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using EmployeeApi.Configuration;
using System.Reflection;


public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);


        // Add services to the container.
        builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        // Add Swagger services
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Configure Cosmos DB
        builder.Services.Configure<CosmosDbSettings>(builder.Configuration.GetSection("CosmosDb"));
        builder.Services.AddSingleton(sp =>
        {
            var cosmosDbSettings = sp.GetRequiredService<IOptions<CosmosDbSettings>>().Value;
            return new CosmosClient(cosmosDbSettings.AccountEndpoint, cosmosDbSettings.AccountKey);
        });


        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API V1");
            });
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        //var summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //app.MapGet("/weatherforecast", () =>
        //{
        //    var forecast =  Enumerable.Range(1, 5).Select(index =>
        //        new WeatherForecast
        //        (
        //            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //            Random.Shared.Next(-20, 55),
        //            summaries[Random.Shared.Next(summaries.Length)]
        //        ))
        //        .ToArray();
        //    return forecast;
        //})
        //.WithName("GetWeatherForecast")
        //.WithOpenApi();

        app.Run();

        //record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
        //{
        //    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        //}

    }
}