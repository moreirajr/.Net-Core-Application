using EventBus.Integration.Events;
using System;
using System.Threading.Tasks;

namespace Pedidos.Application.IntegrationEvents.Interfaces
{
    public interface IPedidoIntegrationService
    {
        Task PublishEventsThroughEventBusAsync(IntegrationEvent @event);
    }
}