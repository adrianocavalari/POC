using ApiIntegrationTest.Cli.Models;
using OneOf;

namespace ApiIntegrationTest.Cli.Services
{
    public interface IRestaurantSearchService
    {
        Task<OneOf<RestaurantSearchResult, RestaurantSearchError>> SearchByOutcodeAsync(RestaurantSearchRequest request);
    }
}
