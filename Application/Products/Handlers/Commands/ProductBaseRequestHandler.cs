using Application.Common.GenericHandler;
using Application.Common.Interfaces.Products;
using Application.Products.Commands;
using Application.Products.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Products.Handlers.Commands
{
    public class ProductBaseRequestHandler : BaseCommandHandler<ProductBaseCommand, Product, ProductDto>
    {
        public ProductBaseRequestHandler(IProductService productService, IMapper mapper) : base(productService, mapper)
        {

        }
    }
}
