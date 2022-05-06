using ApiIntegrationTest.Cli.Models;
using ApiIntegrationTest.Cli.Output;
using ApiIntegrationTest.Cli.Services;
using CommandLine;
using System.Text.Json;

namespace ApiIntegrationTest.Cli
{
    internal class RestaurantSearchApplication
    {
        private readonly IConsoleWritter _consoleWritter;
        private readonly IRestaurantSearchService _restaurantSearchService;

        public RestaurantSearchApplication(IConsoleWritter consoleWritter, IRestaurantSearchService restaurantSearchService)
        {
            _consoleWritter = consoleWritter;
            _restaurantSearchService = restaurantSearchService;
        }

        public async Task RunAsync(string[] args)
        {
            await Parser.Default
                .ParseArguments<RestaurantSearchApplicationOption>(args)
                .WithParsedAsync(async o =>
                {
                    var request = new RestaurantSearchRequest(o.Outcode);
                    var result = await _restaurantSearchService.SearchByOutcodeAsync(request);
                    var responseText = JsonSerializer.Serialize(result, new JsonSerializerOptions
                    {
                        WriteIndented = true,
                    });

                    _consoleWritter.WriteLine(responseText);
                });
        }
    }
}
