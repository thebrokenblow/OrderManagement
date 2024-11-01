using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Orders.Commands.CreateOrder;
using OrderManagement.Application.Orders.Commands.UpdateStatusOrder;
using OrderManagement.Application.Orders.Commands.UpdateStatusOrderBackground;
using OrderManagement.Domain;

namespace OrderManagement.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;
    public OrderController(IMediator mediator) =>
        _mediator = mediator;
    
    [HttpPost]
    [ActionName(nameof(InitProcessBackgroundChangeStatusOrders))]
    public async Task<ActionResult> InitProcessBackgroundChangeStatusOrders()
    {
        var updateStatusOrderBackgroundCommand = new UpdateStatusOrderBackgroundCommand
        {
            Status = StatusOrder.Processing
        };
        
        await _mediator.Send(updateStatusOrderBackgroundCommand);

        return NoContent();
    }
    
    [HttpPost]
    [ActionName(nameof(Create))]
    public async Task<ActionResult<int>> Create([FromBody] CreateOrderCommand createOrderCommand)
    {
        var orderId = await _mediator.Send(createOrderCommand);

        return Ok(orderId);
    }
    
    [HttpPut]
    [ActionName(nameof(Cancelled))]
    public async Task<ActionResult> Cancelled(int id)
    {
        var updateStatusOrderCommand = new UpdateStatusOrderCommand
        {
            Id = id,
            Status = StatusOrder.Cancelled
        };
        
        await _mediator.Send(updateStatusOrderCommand);

        return NoContent();
    }
}