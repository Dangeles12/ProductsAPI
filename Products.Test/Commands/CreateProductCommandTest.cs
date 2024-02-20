using Application.Common.Enums;
using Application.Products.Commands;
using Application.Products.Dtos;
using Application.Products.Handlers.Commands;
using Application.Products.Mapping;
using AutoMapper;
using Products.Test.Services;

namespace Products.Test.Commands;

public class CreateProductCommandTest
{
    [Fact]
    public async Task ShouldCreateProduct()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductMappingProfile>();
        });
        var mapper = new Mapper(config);
        var command = new ProductBaseCommand()
        {
            Name = "PS4",
            Description = "PLAY games",
            Price = 20000,
            Quantity = 1,
            Image = "TestImage.jpg",
            ActionType = ActionTypes.Create
        };

        var mockServices = ProductTestService.CreateProductMockTest();
        var handler = new ProductBaseRequestHandler(mockServices.Object, mapper);
        var result = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
        Assert.IsType<ProductDto>(result);
        Assert.Equal(2, result.Id);
    }
}
