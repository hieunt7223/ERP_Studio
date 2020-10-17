using Volo.Abp.Threading;

namespace xdcb.FileService
{
    public static class FileServiceEfCoreEntityExtensionMappings
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