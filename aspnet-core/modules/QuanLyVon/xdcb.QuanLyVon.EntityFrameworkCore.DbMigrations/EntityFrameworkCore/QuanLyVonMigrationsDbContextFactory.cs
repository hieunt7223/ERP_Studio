using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace xdcb.QuanLyVon.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */

    public class QuanLyVonMigrationsDbContextFactory : IDesignTimeDbContextFactory<QuanLyVonMigrationsDbContext>
    {
        public QuanLyVonMigrationsDbContext CreateDbContext(string[] args)
        {
            QuanLyVonEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<QuanLyVonMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new QuanLyVonMigrationsDbContext(builder.Options);
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