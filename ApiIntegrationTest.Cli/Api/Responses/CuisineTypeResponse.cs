using System.Text.Json.Serialization;

namespace ApiIntegrationTest.Cli.Api.Responses
{
    public class CuisineTypeResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}