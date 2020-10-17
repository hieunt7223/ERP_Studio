using Volo.Abp.Threading;

namespace xdcb.QuanLyVon
{
    public static class QuanLyVonDtoExtensions
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