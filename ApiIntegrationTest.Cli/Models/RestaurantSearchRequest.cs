namespace ApiIntegrationTest.Cli.Models
{
    public record RestaurantSearchRequest
    {
        public string Outcome { get; }

        public RestaurantSearchRequest(string outcode)
        {
            this.Outcome = outcode;
        }
    }
}
