using FluentValidation;
using TailorWebApp.Application.Dtos.Products.Product;

namespace TailorWebApp.Application.Validators.Product
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        private const int MAX_NAME_LENGTH = 128;
        private const int MAX_DESCRIPTION_LENGTH = 512;

        public ProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty()
                .MinimumLength(4)
                .MaximumLength(MAX_NAME_LENGTH);

            RuleFor(product => product.Description)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(MAX_DESCRIPTION_LENGTH);

            RuleFor(product => product.Price)
                .NotEmpty();

            RuleFor(product => product.Material)
                .NotEmpty();

            RuleFor(product => product.Color)
                .NotEmpty();
        }
    }
}