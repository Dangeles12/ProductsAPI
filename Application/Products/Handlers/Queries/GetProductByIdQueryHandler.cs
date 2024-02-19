using Application.Common.Interfaces.Products;
using Application.Products.Dtos;
using Application.Products.Queries;
using AutoMapper;
using MediatR;

namespace Application.Products.Handlers.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _productService.Get(request.Id);
            return _mapper.Map<ProductDto>(result);
        }
    }
}
