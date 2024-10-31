using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Orders.Commands.CreateOrder;

namespace OrderManagement.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;
    public OrderController(IMediator mediator) =>
        _mediator = mediator;
    
    [HttpPost]
    [ActionName(nameof(Create))]
    public async Task<ActionResult<int>> Create([FromBody] CreateOrderCommand createOrderCommand)
    {
        var orderId = await _mediator.Send(createOrderCommand);

        return Ok(orderId);
    }
}