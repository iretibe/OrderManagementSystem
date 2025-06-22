using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Application.Commands;
using OrderManagementSystem.Application.Queries;

namespace OrderManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/customers/GetAllCustomers
        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _mediator.Send(new GetAllCustomersQuery());
            return Ok(result);
        }

        // GET: api/customers/GetCustomerById/{id}
        [HttpGet("GetCustomerById/{id}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var result = await _mediator.Send(new GetCustomerByIdQuery { Id = id });
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/customers/CreateCustomer
        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCustomerById), new { id }, new { id });
        }

        // PUT: api/customers/UpdateCustomer/{id}
        [HttpPut("UpdateCustomer/{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] UpdateCustomerCommand command)
        {
            if (id != command.Id) return BadRequest("ID mismatch");
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/customers/{id}
        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            await _mediator.Send(new DeleteCustomerCommand { Id = id });
            return NoContent();
        }
    }
}
