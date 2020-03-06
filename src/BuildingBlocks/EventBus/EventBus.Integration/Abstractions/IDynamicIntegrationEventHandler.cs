using System.Threading.Tasks;

namespace EventBus.Integration.Abstractions
{
    public interface IDynamicIntegrationEventHandler
    {
        Task Handle(dynamic eventData);
    }
}