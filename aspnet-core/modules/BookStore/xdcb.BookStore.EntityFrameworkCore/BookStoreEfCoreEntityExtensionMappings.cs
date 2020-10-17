using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Threading;

namespace xdcb.BookStore
{
    public static class BookStoreEfCoreEntityExtensionMappings
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                
            });
        }
    }
}
