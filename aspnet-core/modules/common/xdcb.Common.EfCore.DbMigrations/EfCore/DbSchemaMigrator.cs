using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using xdcb.Common.Data;

namespace xdcb.Common.EfCore.DbMigrations
{
    public class DbSchemaMigrator
        : ICommonDbSchemaMigrator, ITransientDependency
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
                .GetRequiredService<CommonMigrationDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}