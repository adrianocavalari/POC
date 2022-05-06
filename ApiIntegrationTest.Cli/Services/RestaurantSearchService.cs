using ApiIntegrationTest.Cli.Api;
using ApiIntegrationTest.Cli.Mapping;
using ApiIntegrationTest.Cli.Models;

namespace ApiIntegrationTest.Cli.Services
{
    public class RestaurantSearchService : IRestaurantSearchService
    {
        private readonly IRestaurantApi _restaurantApi;

        public RestaurantSearchService(IRestaurantApi restaurantApi)
        {
            _restaurantApi = restaurantApi;
        }

        public async Task<RestaurantSearchResult> SearchByOutcodeAsync(RestaurantSearchRequest request)
        {
            var response = await _restaurantApi.SearchPostcodeAsync(request.Outcome);

            return new RestaurantSearchResult
            {
                Restaurants = response.Restaurants.Select(r => r.ToRestaurantSearchResult()).ToList(),
            };
        }
    }
}
