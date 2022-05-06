using System.Text.Json.Serialization;

namespace ApiIntegrationTest.Cli.Api.Responses
{
    public class RestaurantSearchResponse
    {
        [JsonPropertyName("restaurants")]
        public IReadOnlyList<RestaurantResponse> Restaurants { get; set; }
    }
}
