using ApiIntegrationTest.Cli;
using ApiIntegrationTest.Cli.Api;
using ApiIntegrationTest.Cli.Output;
using ApiIntegrationTest.Cli.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using FluentValidation;
using ApiIntegrationTest.Cli.Validators;
using ApiIntegrationTest.Cli.Models;

var configuration = BuildConfiguration();

var services = BuildServiceProvider(configuration);

var app = services.GetRequiredService<RestaurantSearchApplication>();

await app.RunAsync(args);

static IConfigurationRoot BuildConfiguration()
{
    return new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();
}

static ServiceProvider BuildServiceProvider(IConfigurationRoot configuration)
{
    var services = new ServiceCollection();
    ConfigureServices(configuration, services);
    return services.BuildServiceProvider();
}

static IHttpClientBuilder ConfigureServices(IConfigurationRoot configuration, ServiceCollection services)
{
    services.AddSingleton<RestaurantSearchApplication>();
    services.AddSingleton<IConsoleWritter, ConsoleWritter>();
    services.AddSingleton<IRestaurantSearchService, RestaurantSearchService>();
    services.AddScoped<IValidator<RestaurantSearchRequest>, RestaurantSearchRequestValdiator>();

    return services.AddRefitClient<IRestaurantApi>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(configuration["RestaurantApi:BaseAddress"]);
            });
}