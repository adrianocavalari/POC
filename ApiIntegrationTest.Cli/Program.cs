using ApiIntegrationTest.Cli;
using ApiIntegrationTest.Cli.Api;
using ApiIntegrationTest.Cli.Output;
using ApiIntegrationTest.Cli.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

var configuration = BuildConfiguration();

var services = BuildServiceProvider(configuration);

var app = services.GetRequiredService<RestaurantSearchApplication>();

await app.RunAsync(new[] { "E2" });

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

    return services.AddRefitClient<IRestaurantApi>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(configuration["RestaurantApi:BaseAddress"]);
            });
}