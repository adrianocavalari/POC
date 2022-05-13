using ApiIntegrationTest.Cli.Api;
using ApiIntegrationTest.Cli.Mapping;
using ApiIntegrationTest.Cli.Models;
using FluentValidation;
using OneOf;

namespace ApiIntegrationTest.Cli.Services
{
    public class RestaurantSearchService : IRestaurantSearchService
    {
        private readonly IRestaurantApi _restaurantApi;
        private readonly IValidator<RestaurantSearchRequest> _validator;

        public RestaurantSearchService(IRestaurantApi restaurantApi, IValidator<RestaurantSearchRequest> validator)
        {
            _restaurantApi = restaurantApi;
            _validator = validator;
        }

        public async Task<OneOf<RestaurantSearchResult, RestaurantSearchError>> SearchByOutcodeAsync(RestaurantSearchRequest request)
        {
            var validator = _validator.Validate(request);
            if (!validator.IsValid)
            {
                var errorMessages = validator.Errors.Select(s => s.ErrorMessage).ToList();
                return new RestaurantSearchError(errorMessages);
            }

            var response = await _restaurantApi.SearchPostcodeAsync(request.Outcome);

            return new RestaurantSearchResult
            {
                Restaurants = response.Restaurants.Select(r => r.ToRestaurantSearchResult()).ToList(),
            };
        }
    }
}
