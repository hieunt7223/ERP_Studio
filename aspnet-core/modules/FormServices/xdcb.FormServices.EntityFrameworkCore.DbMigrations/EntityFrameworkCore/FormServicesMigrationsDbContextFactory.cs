using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace xdcb.FormServices.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */

    public class FormServicesMigrationsDbContextFactory : IDesignTimeDbContextFactory<FormServicesMigrationsDbContext>
    {
        public FormServicesMigrationsDbContext CreateDbContext(string[] args)
        {
            FormServicesEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<FormServicesMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new FormServicesMigrationsDbContext(builder.Options);
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