namespace ApiIntegrationTest.Cli.Models
{
    public record RestaurantResult
    {
        public string Name { get; init; }

        public decimal Rating { get; init; }

        public IReadOnlyList<string> CuisineTypes { get; set; }
    }
}