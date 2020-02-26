using Pedidos.Domain.Pagination;
using Pedidos.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.Domain.Produtos
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Produto Add(Produto produto);
        Task AddAsync(Produto produto);

        Produto Update(Produto produto);

        Produto FindById(int id);
        Task<Produto> FindByIdAsync(int id);

        Task<IEnumerable<Produto>> FindAllAsync();

        Task<PaginatedAggregateRootResult<Produto>> FindAllPaginatedAsync(PaginationOptions pagingOptions);
    }
}