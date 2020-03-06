using EventBus.Integration.Events;
using System.Threading.Tasks;

namespace EventBus.Integration.Abstractions
{
    public interface IIntegrationEventHandler { }

    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
        where TIntegrationEvent : IntegrationEvent
    {
        Task Handle(TIntegrationEvent @event);
    }
}