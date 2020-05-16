using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SampleAngular.Application.Common.Interfaces;
using SampleAngular.Domain.Entities;

namespace SampleAngular.Infrastructure.Persistence
{
    public class SampleAngularContext : DbContext, ISampleAngularContext
    {
        private IDbContextTransaction _currentTransaction;

        public SampleAngularContext(DbContextOptions<SampleAngularContext> options) : base(options)
        {
        }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<ProductPhotos> ProductPhotos { get; set; }
        public DbSet<Product> Products { get; set; }

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null) return;

            _currentTransaction = await base.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted)
                .ConfigureAwait(false);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);

                await _currentTransaction.CommitAsync();
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SampleAngularContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}