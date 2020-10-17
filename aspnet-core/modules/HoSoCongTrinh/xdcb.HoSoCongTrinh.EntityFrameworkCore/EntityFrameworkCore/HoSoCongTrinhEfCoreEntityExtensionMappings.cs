using Volo.Abp.Threading;

namespace xdcb.HoSoCongTrinh.EntityFrameworkCore
{
    public static class HoSoCongTrinhEfCoreEntityExtensionMappings
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