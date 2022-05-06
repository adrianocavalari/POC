namespace ApiIntegrationTest.Cli.Models
{
    public record RestaurantSearchResult
    {
        public IReadOnlyList<RestaurantResult> Restaurants { get; init; }
    }
}
