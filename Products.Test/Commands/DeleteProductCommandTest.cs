using Application.Common.Enums;
using Application.Products.Commands;
using Application.Products.Dtos;
using Application.Products.Handlers.Commands;
using Application.Products.Mapping;
using AutoMapper;
using Products.Test.Services;

namespace Products.Test.Commands;

public class DeleteProductCommandTest
{
    [Fact]
    public async Task ShouldDeleteProductById()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductMappingProfile>();
        });

        var command = new ProductBaseCommand()
        {
            Id = 1,
            ActionType = ActionTypes.Delete
        };

        var mapper = new Mapper(config);
        var mockServices = ProductTestService.DeleteProductByIdMockTest();
        var handler = new ProductBaseRequestHandler(mockServices.Object, mapper);
        var result = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
        Assert.IsType<ProductDto>(result);
        Assert.Equal(1, result.Id);
    }
}
