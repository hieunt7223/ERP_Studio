using Volo.Abp.Threading;

namespace xdcb.FormServices.EntityFrameworkCore
{
    public static class FormServicesEfCoreEntityExtensionMappings
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