using Application.Common.Interfaces.Products;
using MockQueryable.Moq;
using Moq;
using ProductEntity = Domain.Entities.Product;

namespace Products.Test.Services;

public class ProductTestService
{
    public static List<ProductEntity> Products { get; set; } = new List<ProductEntity>()
    {
        new ProductEntity()
        {
            Id = 1,
            Name = "PS5",
            Description = "PLAY games",
            Price = 40000,
            Quantity = 1,
            Image = "TestImage.jpg",
        },

         new ProductEntity()
         {
            Id = 2,
            Name = "Nintendo Switch",
            Description = "PLAY games",
            Price = 10000,
            Quantity = 1,
            Image = "TestImage.jpg",
         }
    };

    public struct MockService
    {
        public IQueryable<ProductEntity> productEntity;
        public Mock<IProductService> mockedService;
        public MockService(IQueryable<ProductEntity> entities)
        {
            productEntity = entities.AsQueryable().BuildMock();
            mockedService = new Mock<IProductService>();
        }
    }

    private static MockService Mocks = new(Products.AsQueryable().BuildMock());

    public static Mock<IProductService> GetProductsMockTest()
    {
        Mocks.mockedService.Setup(q => q.Query()).Returns(Mocks.productEntity);
        return Mocks.mockedService;
    }

    public static Mock<IProductService> GetProductByIdMockTest()
    {
        Mocks.mockedService.Setup(x => x.Get(1))
         .Returns(Task.FromResult(Products.FirstOrDefault(find => find.Id == 1))!);
        Mocks.mockedService.Setup(x => x.Query()).Returns(Products.AsQueryable().BuildMock());

        return Mocks.mockedService;
    }

    public static Mock<IProductService> CreateProductMockTest()
    {
        Mocks.mockedService.Setup(x => x.Add(It.IsAny<ProductEntity>()))
           .Callback((ProductEntity app) => Products.Add(app))
           .Returns(Task.FromResult(Products.LastOrDefault())!);

        Mocks.mockedService.Setup(x => x.Query()).Returns(Mocks.productEntity);
        return Mocks.mockedService;
    }

    public static Mock<IProductService> PutProductMockTest()
    {
        Mocks.mockedService.Setup(x => x.Update(It.IsAny<ProductEntity>()))
            .Callback((ProductEntity entity) =>
            {
                var user = Products.FirstOrDefault(find => find.Id == entity.Id);
                user!.Name = entity.Name;
                user.Price = entity.Price;
                user.Description = entity.Description;
                user.Quantity = entity.Quantity;
                user.Image = entity.Image;
            })
            .Returns(Task.FromResult(Products.LastOrDefault())!);

        Mocks.mockedService.Setup(x => x.Query()).Returns(Mocks.productEntity);
        return Mocks.mockedService;
    }

    public static Mock<IProductService> DeleteProductByIdMockTest()
    {
        Mocks.mockedService.Setup(x => x.Delete(1))
        .Returns(Task.FromResult(Products.FirstOrDefault(find => find.Id == 1))!);

        Mocks.mockedService.Setup(x => x.Query()).Returns(Products.AsQueryable().BuildMock());
        return Mocks.mockedService;
    }
}
