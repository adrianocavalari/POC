using ApiIntegrationTest.Cli.Models;

namespace ApiIntegrationTest.Cli.Services
{
    public interface IRestaurantSearchService
    {
        Task<RestaurantSearchResult> SearchByOutcodeAsync(RestaurantSearchRequest request);
    }
}
