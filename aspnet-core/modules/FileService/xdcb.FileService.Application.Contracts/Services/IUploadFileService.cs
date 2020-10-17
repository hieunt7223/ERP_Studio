using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.FileService.DocumentStoreDtos;

namespace xdcb.FileService
{
    public interface IUploadFileService: 
        ICrudAppService<
            DocumentStoreDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateDocumentStoreDto,
            CreateUpdateDocumentStoreDto>
    {
        Task<Guid?> UploadFileAsync(IFormFile file);
        Task<string> UploadFileTestAsync(string file);
        
    }
}
