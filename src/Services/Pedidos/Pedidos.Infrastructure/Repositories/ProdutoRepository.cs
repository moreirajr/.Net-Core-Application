﻿using Microsoft.EntityFrameworkCore;
using Pedidos.Domain.Pagination;
using Pedidos.Domain.Produtos;
using Pedidos.Domain.SeedWork;
using Pedidos.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedidos.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PedidosContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public ProdutoRepository(PedidosContext pedidosContext)
        {
            _context = pedidosContext ?? throw new ArgumentNullException(nameof(pedidosContext));
        }

        public Produto Add(Produto produto)
        {
            return _context.Produtos.Add(produto).Entity;
        }

        public async Task AddAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
        }

        public Produto Update(Produto produto)
        {
            return _context.Produtos.Update(produto).Entity;
        }

        public Produto FindById(int id)
        {
            return _context.Produtos.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Produto> FindByIdAsync(int id)
        {
            var produto = await _context.Produtos.Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            return produto;
        }

        public async Task<IEnumerable<Produto>> FindAllAsync()
        {
            var produtos = await _context.Produtos.AsNoTracking().ToListAsync();

            return produtos;
        }

        public async Task<PaginatedAggregateRootResult<Produto>> FindAllPaginatedAsync(PaginationOptions pagingOptions)
        {
            var count = await _context.Produtos.AsNoTracking()
                .LongCountAsync();

            var produtos = await _context.Produtos.AsNoTracking()
                .Skip((pagingOptions.PageIndex - 1) * pagingOptions.PageSize)
                .Take(pagingOptions.PageSize)
                .ToListAsync();

            PaginatedAggregateRootResult<Produto> result = new PaginatedAggregateRootResult<Produto>(
                produtos,
                count,
                pagingOptions.PageIndex,
                pagingOptions.PageSize);

            return result;
        }

        public async Task<IEnumerable<Produto>> FindAllByIdAsync(params int[] ids)
        {
            if (ids == null || ids.Count() <= 0)
                return null;

            var produtos = await _context.Produtos
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            return produtos;
        }

    }
}