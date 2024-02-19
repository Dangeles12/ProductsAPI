using Application.Common.Enums;
using Application.Common.GenericHandler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Products_API.Controllers
{
    [ApiController]
    [Route("api/Skills/[controller]")]
    public class BaseController<TBaseCommand, TResponse> : ControllerBase
            where TBaseCommand : BaseCommand<TResponse>, new()
            where TResponse : class
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TBaseCommand command)
        {
            try
            {
                command.ActionType = ActionTypes.Create;
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.InnerException });
            }
        }
        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody] TBaseCommand command)
        {
            try
            {
                command.ActionType = ActionTypes.Update;
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var command = new TBaseCommand() { Id = id};
                command.ActionType = ActionTypes.Delete;
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
