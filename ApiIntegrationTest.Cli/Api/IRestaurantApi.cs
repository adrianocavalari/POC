using ApiIntegrationTest.Cli.Api.Responses;
using Refit;

namespace ApiIntegrationTest.Cli.Api
{
    public interface IRestaurantApi
    {
        [Get("/restaurants/bypostcode/{postcode}")]
        Task<RestaurantSearchResponse> SearchPostcodeAsync(string postcode);
    }
}
