using Application.Products.Commands;
using Application.Products.Dtos;
using Application.Products.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Products_API.Controllers
{
    [ApiController]
    [Route("api/Skills/[controller]")]
    public class ProductController : BaseController<ProductBaseCommand, ProductDto>
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> Get()
        {
            try
            {
                GetProductsQuery query = new();
                var queryResult = await Mediator.Send(query);
                return Ok(queryResult);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById([FromRoute] int id)
        {
            try
            {
                GetProductByIdQuery query = new GetProductByIdQuery() { Id = id };
                var queryResult = await Mediator.Send(query);
                return Ok(queryResult);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
