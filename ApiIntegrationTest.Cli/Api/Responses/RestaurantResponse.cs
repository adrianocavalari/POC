using System.Text.Json.Serialization;

namespace ApiIntegrationTest.Cli.Api.Responses
{
    public class RestaurantResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("ratingStars")]
        public decimal Rating { get; set; }

        [JsonPropertyName("cuisineTypes")]
        public IReadOnlyList<CuisineTypeResponse>  CuisineTypes { get; set; }
    }
}