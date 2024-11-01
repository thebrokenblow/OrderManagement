using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Orders.Commands.CreateOrder;
using OrderManagement.Application.Orders.Commands.DeleteOrder;
using OrderManagement.Application.Orders.Commands.UpdateStatusOrder;
using OrderManagement.Application.Orders.Commands.UpdateStatusOrderBackground;
using OrderManagement.Application.Orders.Queries.GetOrderById;
using OrderManagement.Application.Orders.Queries.GetOrderRange;
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
    
    [HttpGet]
    [ActionName(nameof(GetById))]
    public async Task<ActionResult> GetById(int id)
    {
        var getOrderByIdQuery = new GetOrderByIdQuery
        {
            Id = id
        };
        
        var order = await _mediator.Send(getOrderByIdQuery);
        return Ok(order);
    }
    
    [HttpGet]
    [ActionName(nameof(GetRange))]
    public async Task<ActionResult> GetRange(int countSkip, int countTake)
    {
        var getProductRangeQuery = new GetProductRangeQuery
        {
            CountSkip = countSkip,
            CountTake = countTake
        };
        
        var orders = await _mediator.Send(getProductRangeQuery);
        return Ok(orders);
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
    
    [HttpDelete]
    [ActionName(nameof(Delete))]
    public async Task<ActionResult> Delete(int id)
    {
        var deleteOrderCommand = new DeleteOrderCommand
        {
            Id = id
        };
        
        await _mediator.Send(deleteOrderCommand);

        return NoContent();
    }
}