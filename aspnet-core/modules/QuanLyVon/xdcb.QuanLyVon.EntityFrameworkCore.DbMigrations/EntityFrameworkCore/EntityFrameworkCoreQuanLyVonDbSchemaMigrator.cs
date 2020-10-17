using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using xdcb.QuanLyVon.Data;

namespace xdcb.QuanLyVon.EntityFrameworkCore
{
    public class EntityFrameworkCoreQuanLyVonDbSchemaMigrator
        : IQuanLyVonDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreQuanLyVonDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the QuanLyVonMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<QuanLyVonMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}