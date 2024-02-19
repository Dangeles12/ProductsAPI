using Application.Common.Interfaces.Products;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Services.Generic;

namespace Infrastructure.Services.Products
{
    public class ProductService : BaseCrudService<Product>, IProductService
    {
        public ProductService(ProductsDbContext context) : base(context)
        {

        }
    }
}
