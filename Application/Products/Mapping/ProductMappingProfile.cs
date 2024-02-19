using Application.Products.Commands;
using Application.Products.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Products.Mapping
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductBaseCommand, Product>().ReverseMap();
        }
    }
}
