using Application.Common.Interfaces.Products;
using Application.Products.Dtos;
using Application.Products.Queries;
using AutoMapper;
using MediatR;

namespace Application.Products.Handlers.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var items = _productService.Query().ToList();
            return _mapper.Map<List<ProductDto>>(items);
        }
    }
}
