using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace xdcb.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class xdcbMigrationsDbContextFactory : IDesignTimeDbContextFactory<xdcbMigrationsDbContext>
    {
        public xdcbMigrationsDbContext CreateDbContext(string[] args)
        {
            xdcbEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<xdcbMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new xdcbMigrationsDbContext(builder.Options);
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
