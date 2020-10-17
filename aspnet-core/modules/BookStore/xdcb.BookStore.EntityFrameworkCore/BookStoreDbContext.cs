using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.BookStore
{
    [ConnectionStringName("Default")]
    public class BookStoreDbContext : AbpDbContext<BookStoreDbContext>
    {
        public DbSet<Book> Books { get; set; }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {

        }
    }
}
