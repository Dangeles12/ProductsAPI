using Application.Products.Handlers.Queries;
using Application.Products.Mapping;
using Application.Products.Queries;
using AutoMapper;
using Products.Test.Services;

namespace Products.Test.Queries;
public class GetAllProductsTest
{
    [Fact]
    public async Task ShouldGetAllProducts()
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductMappingProfile>();
        });

        var mapper = new Mapper(mapperConfig);
        var mockedService = ProductTestService.GetProductsMockTest();
        var query = new GetProductsQuery();
        var handler = new GetProductsQueryHandler(mockedService.Object, mapper);
        var result = await handler.Handle(query, CancellationToken.None);

        Assert.NotNull(result);
        Assert.True(result.Any());
        Assert.True(result.Count >= 1);
    }
}
