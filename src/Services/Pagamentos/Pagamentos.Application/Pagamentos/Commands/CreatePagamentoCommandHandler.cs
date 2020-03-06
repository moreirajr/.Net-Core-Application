using MediatR;
using Pagamentos.Domain.Pagamentos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pagamentos.Application.Pagamentos.Commands
{
    public class CreatePagamentoCommandHandler : IRequestHandler<CreatePagamentoCommand, bool>
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public CreatePagamentoCommandHandler(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        public Task<bool> Handle(CreatePagamentoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}