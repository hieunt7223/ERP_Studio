using Volo.Abp.Threading;

namespace xdcb.HoSoCongTrinh
{
    public static class HoSoCongTrinhDtoExtensions
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