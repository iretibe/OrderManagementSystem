using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Application.Commands;
using OrderManagementSystem.Application.Queries;

namespace OrderManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/orders/CreateOrder
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var orderId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetOrderById), new { id = orderId }, new { orderId });
        }

        // PUT: api/orders/UpdateOrder/{id}
        [HttpPut("UpdateOrder/{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] UpdateOrderCommand command)
        {
            if (id != command.OrderId)
                return BadRequest("Order ID mismatch");

            await _mediator.Send(command);
            return NoContent();
        }

        // PATCH: api/orders/UpdateOrderStatus/{id}
        [HttpPatch("UpdateOrderStatus/{id}")]
        public async Task<IActionResult> UpdateOrderStatus(Guid id, [FromBody] UpdateOrderStatusCommand command)
        {
            if (id != command.OrderId)
                return BadRequest("Order ID mismatch");

            await _mediator.Send(command);
            return NoContent();
        }

        // POST: api/orders/ApplyDiscount/{id}
        [HttpPost("ApplyDiscount/{id}")]
        public async Task<IActionResult> ApplyDiscount(Guid id)
        {
            var result = await _mediator.Send(new ApplyDiscountCommand { OrderId = id });
            return Ok(new { discountedTotal = result });
        }

        // GET: api/orders/GetAnalytics
        [HttpGet("GetAnalytics")]
        public async Task<IActionResult> GetAnalytics()
        {
            var analytics = await _mediator.Send(new GetOrderAnalyticsQuery());
            return Ok(analytics);
        }

        // GET: api/GetOrderById/{id}
        [HttpGet("GetOrderById/{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery { OrderId = id });
            if (order == null) return NotFound();
            return Ok(order);
        }
    }
}
