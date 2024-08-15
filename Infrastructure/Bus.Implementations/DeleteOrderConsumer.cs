using BusModels;
using Domain;
using MassTransit;
using Microsoft.Extensions.Logging;
using Services.Repositories.Interfaces;

namespace Infrastructure.Bus.Implementations;

public class DeleteOrderConsumer(
    IContainerRepository containerRepository,
    ILogger<DeleteOrderConsumer> logger) : IConsumer<OrderDeletedMessage>
{
    public async Task Consume(ConsumeContext<OrderDeletedMessage> context)
    {
        await containerRepository.UpdateEngagedStatusAsync(
            containers: context.Message.ContainerIds.Select(id => new Container { Id = id }).ToList(),
            orderId: context.Message.OrderId,
            isEngaged: false,
            engagedUntil: DateTime.UtcNow);
        
        logger.LogInformation("\"Order deleted message\" received with containers: {ids}", 
            string.Join(", ", context.Message.ContainerIds));
    }
}