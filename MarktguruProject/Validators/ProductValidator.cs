using FluentValidation;
using MarktguruProject.DTOModels;

namespace MarktguruProject.Validators
{
    public class ProductValidator : AbstractValidator<ProductDetails>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Price).GreaterThan(0);
        }
    }
}
