using Application.Common.Enums;
using Application.Products.Commands;
using Application.Products.Dtos;
using Application.Products.Handlers.Commands;
using Application.Products.Mapping;
using AutoMapper;
using Products.Test.Services;

namespace Products.Test.Commands;

public class UpdateProductCommandTest
{
    [Fact]
    public async Task ShouldUpdateProduct()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductMappingProfile>();
        });

        var mapper = new Mapper(config);
        var command = new ProductBaseCommand()
        {
            Id = 1,
            Name = "PS3",
            Description = "PLAY games",
            Price = 5000,
            Quantity = 2,
            Image = "TestImage.jpg",
            ActionType = ActionTypes.Update
        };

        var mockServices = ProductTestService.PutProductMockTest();
        var handler = new ProductBaseRequestHandler(mockServices.Object, mapper);
        var result = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
        Assert.IsType<ProductDto>(result);
    }
}
