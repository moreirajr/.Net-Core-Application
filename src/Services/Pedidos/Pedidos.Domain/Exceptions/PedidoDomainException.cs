using System;

namespace Pedidos.Domain.Exceptions
{
    public class PedidoDomainException : Exception
    {
        public PedidoDomainException()
        { }

        public PedidoDomainException(string message)
            : base(message)
        { }
    }
}