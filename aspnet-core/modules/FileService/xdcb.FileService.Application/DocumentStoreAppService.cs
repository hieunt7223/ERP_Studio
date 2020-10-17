using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using xdcb.FileService.DocumentStoreDtos;
using xdcb.FileService.Domain.Entities;

namespace xdcb.FileService.DocumentStores
{
    public class DocumentStoreAppService :
        CrudAppService<DocumentStore,
            DocumentStoreDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateDocumentStoreDto, CreateUpdateDocumentStoreDto>,
        IDocumentStoreAppService
    {
        private readonly IBlobContainer _blobContainer;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IDocumentStoreRepository _documentStoreRepository;

        public DocumentStoreAppService(
            IDocumentStoreRepository documentStoreRepository, IBlobContainer blobContainer, IGuidGenerator guidGenerator) : base(documentStoreRepository)
        {
            _blobContainer = blobContainer;
            _guidGenerator = guidGenerator;
            _documentStoreRepository = documentStoreRepository;
        }

        [HttpPost, Route("api/app/document")]
        public async Task<DocumentStoreModel> UploadFileAsync(IFormFile file)
        {
            try
            {
                var arrFile = file.FileName.Split(".");
                string kieuFile = arrFile[arrFile.Length - 1];
                CreateUpdateDocumentStoreDto newItem = new CreateUpdateDocumentStoreDto
                {
                    Id = _guidGenerator.Create(),
                    TenFile = file.FileName,
                    KieuFile = file.ContentType,
                    KichThuoc = file.Length,
                    FullName = file.FileName
                };

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    var fileName = newItem.Id.ToString() + "." + kieuFile;
                    newItem.Url = FileServiceDBConsts.FolderSaveFile + "/host/Default/" + fileName;
                    await _blobContainer.SaveAsync(fileName, memoryStream);
                }
                var documentStore = ObjectMapper.Map<CreateUpdateDocumentStoreDto, DocumentStore>(newItem);
                var item = await _documentStoreRepository.InsertAsync(documentStore);

                return  ObjectMapper.Map<DocumentStore, DocumentStoreModel>(item);
            }
            catch (Exception)
            {
                throw new BusinessException("Error");
            }
        }

        [HttpPost("/api/app/document/multiupload")]
        [RequestSizeLimit(52428800)] // 50MB
        public async Task<List<DocumentStoreDto>> UploadMultiFilesAsync(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                throw new BusinessException("file not selected");
            var createUpdateDocumentStoreDtos = new List<CreateUpdateDocumentStoreDto>();
            try
            {
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        var arrFile = formFile.FileName.Split(".");
                        string kieuFile = arrFile[arrFile.Length - 1];
                        var documentStoreDto = new CreateUpdateDocumentStoreDto
                        {
                            Id = _guidGenerator.Create(),
                            TenFile = formFile.FileName,
                            KieuFile = formFile.ContentType,
                            KichThuoc = formFile.Length,
                            FullName = formFile.FileName
                        };

                        using (var memoryStream = new MemoryStream())
                        {
                            await formFile.CopyToAsync(memoryStream);
                            var fileName = documentStoreDto.Id.ToString() + "." + kieuFile;
                            documentStoreDto.Url = FileServiceDBConsts.FolderSaveFile + "/host/Default/" + fileName;
                            await _blobContainer.SaveAsync(fileName, memoryStream);
                            createUpdateDocumentStoreDtos.Add(documentStoreDto);
                        }
                    }
                }
                var documentStores = ObjectMapper.Map<List<CreateUpdateDocumentStoreDto>, List<DocumentStore>>(createUpdateDocumentStoreDtos);
                var results = await _documentStoreRepository.InsertMultiAsync(documentStores);
                return ObjectMapper.Map<List<DocumentStore>, List<DocumentStoreDto>>(results);
            }
            catch (Exception)
            {
                throw new BusinessException("Error");
            }
        }

        public override Task DeleteAsync(Guid id)
        {
            var Document = this.GetAsync(id).Result;
            _blobContainer.DeleteAsync(Document.FullName);
            return this.DeleteByIdAsync(id);
        }

        public async Task<byte[]> GetFileAsync(string url)
        {
            string folder = FileServiceDBConsts.FolderSaveFile + "/host/Default/";
            string name = url.Substring(folder.Length, url.Length - folder.Length);
            return await _blobContainer.GetAllBytesOrNullAsync(name);
        }

        public async Task<List<DocumentStoreDto>> GetFilesInfoByIdsAsync(List<Guid> ids)
        {
            var items = await Repository.Where(s => !s.IsDeleted && ids.Contains(s.Id)).AsNoTracking().ToListAsync();
            return ObjectMapper.Map<List<DocumentStore>, List<DocumentStoreDto>>(items);
        }

        [HttpGet]
        [Route("/api/app/documentStore/download/{id}")]
        public async Task<IActionResult> DownloadAsync(Guid id)
        {
            var document = await this.GetAsync(id);
            if (document != null)
            {
                string folder = FileServiceDBConsts.FolderSaveFile + "/host/Default/";
                string name = document.Url.Substring(folder.Length, document.Url.Length - folder.Length);
                byte[] bytes = await _blobContainer.GetAllBytesOrNullAsync(name);
                return new FileContentResult(bytes, document.KieuFile)
                {
                    FileDownloadName = document.FullName
                };
            }
            return null;
        }
    }
}