using Demo.RealestateApp.Application.Features.OrderProducts.Commands.CreateOrderProduct;
using Demo.RealestateApp.Application.Features.OrderProducts.Commands.DeleteOrderProduct;
using Demo.RealestateApp.Application.Features.OrderProducts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Demo.RealestateApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrederProductController : Controller
    {
        private readonly IMediator _mediator;
        public OrederProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetOrderProductDto>>> GetAllOrders()
        {
            var result = await _mediator.Send(new GetOrderProductListQuery());
            return Ok(result);
        }

        [HttpGet("input", Name = "GetAllAcceptedOrRefusedOrders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<GetOrderProductDto>>> GetAllAcceptedOrRefusedOrders(bool input = true)
        {
            var result = await _mediator.Send(new GetAllAcceptedOrRefusedOrdersQuery() { input = input });
            return Ok(result);
        }
        // Buy Or rent Order
        [HttpPost(Name = "AddOrder")]
        public async Task<ActionResult<bool>> Create([FromBody] CreateOrderProductCommand createOrderProductCommand)
        {
            var resulte = await _mediator.Send(createOrderProductCommand);
            return Ok(resulte);
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = new DeleteOrderProductCommand() { Id = id };
            await _mediator.Send(result);
            return NoContent();
        }



    }
}
