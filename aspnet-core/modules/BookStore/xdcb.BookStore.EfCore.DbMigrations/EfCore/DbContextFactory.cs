using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using xdcb.BookStore.EntityFrameworkCore;

namespace xdcb.BookStore.EfCore.DbMigrations
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class DbContextFactory : IDesignTimeDbContextFactory<BookStoreMigrationDbContext>
    {
        public BookStoreMigrationDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<EntityFrameworkCore.BookStoreMigrationDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new BookStoreMigrationDbContext(builder.Options);
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
