using Application.Products.Dtos;
using Application.Products.Handlers.Queries;
using Application.Products.Mapping;
using Application.Products.Queries;
using AutoMapper;
using Products.Test.Services;

namespace Products.Test.Queries;

public class GetProductByIdTest
{
    [Fact]
    public async Task ShouldGetProductById()
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductMappingProfile>();
        });

        var mapper = new Mapper(mapperConfig);
        var mockedService = ProductTestService.GetProductByIdMockTest();
        var query = new GetProductByIdQuery() { Id = 1 };
        var handler = new GetProductByIdQueryHandler(mockedService.Object, mapper);
        var result = await handler.Handle(query, CancellationToken.None);

        Assert.NotNull(result);
        Assert.IsType<ProductDto>(result);
        Assert.Equal(1, result.Id);
    }
}
