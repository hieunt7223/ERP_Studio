using Volo.Abp.Threading;

namespace xdcb.FormServices
{
    public static class FormServicesDtoExtensions
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