using Application.Products.Dtos;
using MediatR;

namespace Application.Products.Queries
{
    public class GetProductsQuery : IRequest<List<ProductDto>>
    {
    }
}
