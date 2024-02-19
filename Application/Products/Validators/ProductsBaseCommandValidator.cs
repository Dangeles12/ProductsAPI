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
        }
    }
}
