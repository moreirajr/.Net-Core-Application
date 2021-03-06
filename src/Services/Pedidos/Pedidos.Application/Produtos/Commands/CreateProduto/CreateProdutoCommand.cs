﻿using MediatR;

namespace Pedidos.Application.Produtos.Commands.CreateProduto
{
    public class CreateProdutoCommand : IRequest<bool>
    {
        public string Descricao { get; }

        public double Valor { get; }

        public int QuantidadeEstoque { get; set; }

        public CreateProdutoCommand(CreateProdutoRequest request)
        {
            Descricao = request.Descricao;
            Valor = request.Valor;
            QuantidadeEstoque = request.QuantidadeEstoque;
        }
    }
}