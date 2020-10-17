using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace xdcb.HoSoCongTrinh.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */

    public class HoSoCongTrinhMigrationsDbContextFactory : IDesignTimeDbContextFactory<HoSoCongTrinhMigrationsDbContext>
    {
        public HoSoCongTrinhMigrationsDbContext CreateDbContext(string[] args)
        {
            HoSoCongTrinhEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<HoSoCongTrinhMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new HoSoCongTrinhMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}