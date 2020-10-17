using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using xdcb.HoSoCongTrinh.Data;

namespace xdcb.HoSoCongTrinh.EntityFrameworkCore
{
    public class EfCoreHoSoCongTrinhDbSchemaMigrator
        : IHoSoCongTrinhDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EfCoreHoSoCongTrinhDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the HoSoCongTrinhMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<HoSoCongTrinhMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}