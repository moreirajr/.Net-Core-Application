using Pagamentos.Domain.Pagamentos;
using Pagamentos.Domain.SeedWork;
using Pagamentos.Infrastructure.Database;
using System;

namespace Pagamentos.Infrastructure.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly PagamentosContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public PagamentoRepository(PagamentosContext  pagamentosContext)
        {
            _context = pagamentosContext ?? throw new ArgumentNullException(nameof(pagamentosContext));
        }  
    }
}