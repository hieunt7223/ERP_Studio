using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using xdcb.FileService.Data;

namespace xdcb.EntityFrameworkCore
{
    public class DbSchemaMigrator
        : IFileServiceDbSchemaMigrator, ITransientDependency
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
                .GetRequiredService<FileService.EntityFrameworkCore.FileServiceMigrationDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}