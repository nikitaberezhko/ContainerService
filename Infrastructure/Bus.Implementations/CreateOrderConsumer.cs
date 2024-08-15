using BusModels;
using Domain;
using MassTransit;
using Microsoft.Extensions.Logging;
using Services.Repositories.Interfaces;

namespace Infrastructure.Bus.Implementations;

public class CreateOrderConsumer(
    IContainerRepository containerRepository,
    ILogger<CreateOrderConsumer> logger) : IConsumer<OrderCreatedMessage>
{
    public async Task Consume(ConsumeContext<OrderCreatedMessage> context)
    {
        await containerRepository.UpdateEngagedStatusAsync(
            containers: context.Message.ContainerIds.Select(id => new Container { Id = id }).ToList(),
            orderId: context.Message.OrderId,
            isEngaged: true,
            engagedUntil: context.Message.EngagedUntil);
        
        logger.LogInformation("\"Order created message\" received for order with id: {id}", context.Message.OrderId);
    }
}