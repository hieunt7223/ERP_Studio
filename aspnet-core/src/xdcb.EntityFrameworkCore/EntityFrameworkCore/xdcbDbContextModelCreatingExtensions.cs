using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace xdcb.EntityFrameworkCore
{
    public static class xdcbDbContextModelCreatingExtensions
    {
        public static void Configurexdcb(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */
     
        }
    }
}