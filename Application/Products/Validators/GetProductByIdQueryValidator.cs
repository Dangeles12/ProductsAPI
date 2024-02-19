using Application.Products.Queries;
using FluentValidation;

namespace Application.Products.Validators
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("The 'Id' is necessary for search");
        }
    }
}
