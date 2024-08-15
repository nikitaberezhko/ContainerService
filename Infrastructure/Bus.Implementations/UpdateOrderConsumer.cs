using BusModels;
using Domain;
using MassTransit;
using Microsoft.Extensions.Logging;
using Services.Repositories.Interfaces;

namespace Infrastructure.Bus.Implementations;

public class UpdateOrderConsumer(
    IContainerRepository containerRepository,
    ILogger<UpdateOrderConsumer> logger) : IConsumer<OrderUpdatedMessage>
{
    public async Task Consume(ConsumeContext<OrderUpdatedMessage> context)
    {
        await containerRepository.UpdateEngagedStatusAsync(
            containers: context.Message.ContainerIds.Select(id => new Container { Id = id }).ToList(),
            orderId: context.Message.OrderId,
            isEngaged: true,
            engagedUntil: context.Message.EngagedUntil);
        
        logger.LogInformation("\"Order updated message\" received for order with id: {id}", context.Message.OrderId);
    }
}