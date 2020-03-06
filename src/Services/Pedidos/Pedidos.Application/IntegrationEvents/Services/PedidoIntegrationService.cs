using EventBus.Integration.Abstractions;
using EventBus.Integration.Events;
using Pedidos.Application.IntegrationEvents.Interfaces;
using Pedidos.Domain.Produtos;
using System;
using System.Threading.Tasks;

namespace Pedidos.Application.IntegrationEvents.Services
{
    public class PedidoIntegrationService : IPedidoIntegrationService
    {
        private readonly IEventBus _eventBus;
        private readonly IProdutoRepository _produtoRepository;

        public PedidoIntegrationService(IEventBus eventBus, IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public Task PublishEventsThroughEventBusAsync(IntegrationEvent @event)
        {
            _eventBus.Publish(@event);

            return Task.CompletedTask;
        }
    }
}