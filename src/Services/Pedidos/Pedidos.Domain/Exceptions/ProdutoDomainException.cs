using System;

namespace Pedidos.Domain.Exceptions
{
    public class ProdutoDomainException : Exception
    {
        public ProdutoDomainException()
        { }

        public ProdutoDomainException(string message)
            : base(message)
        { }
    }
}