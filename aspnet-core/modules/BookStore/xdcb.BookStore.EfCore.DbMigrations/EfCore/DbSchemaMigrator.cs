using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using xdcb.BookStore.Data;

namespace xdcb.EntityFrameworkCore
{
    public class DbSchemaMigrator
        : IBookStoreDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public DbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            await _serviceProvider
                .GetRequiredService<BookStore.EntityFrameworkCore.BookStoreMigrationDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}