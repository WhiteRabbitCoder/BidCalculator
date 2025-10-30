using BidCalculatorAPI.Models;
using FluentValidation;

namespace BidCalculatorAPI.Validators
{
    public class VehicleValidator : AbstractValidator<Vehicle>
    {
        public VehicleValidator()
        {
            RuleFor(v => v.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(v => v.Type)
                .NotEmpty().WithMessage("Type is required.")
                .Must(t => t == "Common" || t == "Luxury")
                .WithMessage("Type must be either 'Common' or 'Luxury'.");
        }
    }
}