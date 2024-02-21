using Application.Common.Enums;
using Application.Products.Commands;
using FluentValidation;

namespace Application.Products.Validators
{
    public class ProductsBaseCommandValidator : AbstractValidator<ProductBaseCommand>
    {
        public ProductsBaseCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("The Product's 'Id' should not be empty")
                .When(p => p.ActionType != ActionTypes.Create);

            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Product's 'Name' should not be empty")
                .When(p => p.ActionType != ActionTypes.Delete);


            RuleFor(p => p.Description)
                .Length(3, 200)
                .When(p => p.ActionType != ActionTypes.Delete);

            RuleFor(p => p.Quantity)
               .NotEmpty()
               .WithMessage("Product's 'Quantity' should not be empty")
               .When(p => p.ActionType != ActionTypes.Delete);

            RuleFor(p => p.Price)
               .NotEmpty()
               .WithMessage("Product's 'Price' should not be empty")
               .When(p => p.ActionType != ActionTypes.Delete);

            RuleFor(p => p.Image)
               .NotEmpty()
               .Must(BeAValidUrl)
               .WithMessage("Product's 'Image' must be a valid url")
               .When(p => p.ActionType != ActionTypes.Delete);

        }

        private static bool BeAValidUrl(string url)
        {
            ProductBaseCommand command = new() { Image = url };
            var result = Uri.IsWellFormedUriString(command.Image, UriKind.Absolute);
            if (!result) { return false; }
            return true;
        }
    }
}
