using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;

namespace xdcb.FileService
{
    public class UploadFileService :
        ApplicationService
    {
        private readonly IBlobContainer _blobContainer;

        public UploadFileService(
           IBlobContainer blobContainer)
        {
            _blobContainer = blobContainer;
        }

        public async Task<string> UploadFileTestAsync(string file)
        {
            if (File.Exists(file))
            {
                byte[] fileData = null;

                FileStream fs = File.OpenRead(file);
                BinaryReader binaryReader = new BinaryReader(fs);

                fileData = binaryReader.ReadBytes((int)fs.Length);

                await _blobContainer.SaveAsync(Path.GetFileName(file).Trim(), fileData);
                return "upload file thành công";
            }
            else
            {
                return "file không tồn tại";
            }
        }
    }
}