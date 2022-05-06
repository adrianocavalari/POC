using ApiIntegrationTest.Cli.Api.Responses;
using ApiIntegrationTest.Cli.Models;

namespace ApiIntegrationTest.Cli.Mapping
{
    public static class ContractToModelMapping
    {
        public static RestaurantResult ToRestaurantSearchResult(this RestaurantResponse response)
        {
            return new()
            {
                Name = response.Name,
                Rating = response.Rating,
                CuisineTypes = response.CuisineTypes.Select(x => x.Name).ToList(),
            };
        }
    }
}
