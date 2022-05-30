using ApiIntegrationTest.Cli.Models;
using FluentValidation;

namespace ApiIntegrationTest.Cli.Validators
{
    public class RestaurantSearchRequestValdiator : AbstractValidator<RestaurantSearchRequest>
    {
        public RestaurantSearchRequestValdiator()
        {
            RuleFor(request => request.Outcome)
                .Matches("^([A-Za-z][0-9]{1,2})$")
                .WithMessage("Please provide correct postcode");
        }
    }
}
