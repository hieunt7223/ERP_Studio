using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using xdcb.Common.DanhMuc.FileCuaThuVienVanBanDtos;
using xdcb.FileService.DocumentStores;

namespace xdcb.Common.DanhMuc.FileCuaThuVienVanBans
{
    public class FileCuaThuVienVanBanAppService :
        CrudAppService<FileCuaThuVienVanBan,
            FileCuaThuVienVanBanDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateFileCuaThuVienVanBanDto, CreateUpdateFileCuaThuVienVanBanDto>,
        IFileCuaThuVienVanBanAppService
    {
        private readonly IFileCuaThuVienVanBanRepository _fileCuaThuVienVanBanRepository;
        private readonly IDocumentStoreAppService _documentStoreAppService;
        private readonly IGuidGenerator _guidGenerator;

        public FileCuaThuVienVanBanAppService(
            IRepository<FileCuaThuVienVanBan, Guid> repository, IFileCuaThuVienVanBanRepository fileCuaThuVienVanBanRepository,
            IGuidGenerator guidGenerator,
            IDocumentStoreAppService documentStoreAppService) : base(repository)
        {
            _fileCuaThuVienVanBanRepository = fileCuaThuVienVanBanRepository;
            _documentStoreAppService = documentStoreAppService;
            _guidGenerator = guidGenerator;
        }

        public async Task DeleteByFileIdAsync(Guid FileId)
        {
            Guid Id = await _fileCuaThuVienVanBanRepository.GetIdByFileIdAsync(FileId);
            this.DeleteByIdAsync(Id);
            _documentStoreAppService.DeleteAsync(FileId);
        }

        public Task<IList<Guid>> GetFileIdListAsync(Guid ThuVienVanBanId)
        {
            return _fileCuaThuVienVanBanRepository.GetFileIdListAsync(ThuVienVanBanId);
        }

        public async Task<List<FileCuaThuVienVanBanDto>> InsertMultiAsync(List<CreateUpdateFileCuaThuVienVanBanDto> listFiles)
        {
            foreach (var item in listFiles)
            {
                item.Id = _guidGenerator.Create();
            }
            var itemsInsert = ObjectMapper.Map<List<CreateUpdateFileCuaThuVienVanBanDto>, List<FileCuaThuVienVanBan>>(listFiles);
            var items = await _fileCuaThuVienVanBanRepository.InsertMultiAsync(itemsInsert);
            return ObjectMapper.Map<List<FileCuaThuVienVanBan>, List<FileCuaThuVienVanBanDto>>(items);
        }
    }
}