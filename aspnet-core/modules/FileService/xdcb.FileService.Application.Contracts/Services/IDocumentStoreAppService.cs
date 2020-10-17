using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.FileService.DocumentStoreDtos;

namespace xdcb.FileService.DocumentStores
{
    public interface IDocumentStoreAppService :
        ICrudAppService<
            DocumentStoreDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateDocumentStoreDto,
            CreateUpdateDocumentStoreDto>
    {
        Task<DocumentStoreModel> UploadFileAsync(IFormFile file);
        Task<byte[]> GetFileAsync(string url);

        /// <summary>
        /// get list file theo ids
        /// </summary>
        /// <param name="ids">list id của file cần lấy</param>
        /// <returns></returns>
        Task<List<DocumentStoreDto>> GetFilesInfoByIdsAsync(List<Guid> ids);

        /// <summary>
        /// upload multifile
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        Task<List<DocumentStoreDto>> UploadMultiFilesAsync(List<IFormFile> files);
    }
}