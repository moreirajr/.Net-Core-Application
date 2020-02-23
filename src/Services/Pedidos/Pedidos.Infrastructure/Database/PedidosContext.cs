using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Pedidos.Domain.Produtos;
using Pedidos.Domain.SeedWork;
using Pedidos.Infrastructure.EntityConfigurations;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;


namespace Pedidos.Infrastructure.Database
{
    public class PedidosContext : DbContext, IUnitOfWork
    {
        public PedidosContext(DbContextOptions<PedidosContext> options) : base(options)
        {
            CreateDatabaseIfNotExists();
        }

        public const string DEFAULT_SCHEMA = "dbo";

        private IDbContextTransaction _currentTransaction;
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;


        private void CreateDatabaseIfNotExists()
        {
            if (!(Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
            {
                Database.EnsureCreated();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        #region Db Sets
        public DbSet<Produto> Produtos { get; set; }
        #endregion
    }
}