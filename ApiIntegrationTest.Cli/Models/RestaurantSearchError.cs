namespace ApiIntegrationTest.Cli.Models
{
    public class RestaurantSearchError
    {
        public IReadOnlyList<string> ErrorMessages { get; }

        public RestaurantSearchError(IReadOnlyList<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}
