using costumer.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace costumer.api.Infra.Data.Confuguration
{
    public class ApplicationDbContext : DbContext
    {
        private IDbContextTransaction _currentTransaction;
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString"),
                sqlServerOptionsAction: serverOptions =>
                {
                    serverOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(30), null);
                }
        );

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<CustomerEntity>().HasKey(customer => customer.Id);
        }

    }
}
