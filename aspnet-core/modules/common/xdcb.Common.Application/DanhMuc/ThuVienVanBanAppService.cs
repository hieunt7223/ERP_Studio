using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.DonViBanHanhs;
using xdcb.Common.DanhMuc.FileCuaThuVienVanBanDtos;
using xdcb.Common.DanhMuc.FileCuaThuVienVanBans;
using xdcb.Common.DanhMuc.ThuVienVanBanDtos;
using xdcb.Common.Extensions;
using xdcb.FileService.DocumentStores;

namespace xdcb.Common.DanhMuc.ThuVienVanBans
{
    public class ThuVienVanBanAppService :
        CrudAppService<ThuVienVanBan,
            ThuVienVanBanDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateThuVienVanBanDto, CreateUpdateThuVienVanBanDto>,
        IThuVienVanBanAppService
    {
        private readonly IThuVienVanBanRepository _thuVienVanBanRepository;
        private readonly IFileCuaThuVienVanBanAppService _fileCuaThuVienVanBanAppService;
        private readonly IDocumentStoreAppService _documentStoreAppService;
        private readonly IDonViBanHanhAppService _donViBanHanhAppService;

        public ThuVienVanBanAppService(
            IThuVienVanBanRepository thuVienVanBanRepository,
            IFileCuaThuVienVanBanAppService fileCuaThuVienVanBanAppService,
            IDonViBanHanhAppService donViBanHanhAppService,
            IDocumentStoreAppService documentStoreAppService) : base(thuVienVanBanRepository)
        {
            _thuVienVanBanRepository = thuVienVanBanRepository;
            _fileCuaThuVienVanBanAppService = fileCuaThuVienVanBanAppService;
            _documentStoreAppService = documentStoreAppService;
            _donViBanHanhAppService = donViBanHanhAppService;
        }

        [HttpGet]
        public async Task<PagedResultDto<ThuVienVanBanDto>> SearchAsync(string conditionSearch)
        {
            ThuVienVanBanConditionSearch condition = JsonConvert.DeserializeObject<ThuVienVanBanConditionSearch>(conditionSearch, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
            condition.keyword = Common.ConvertToUnSign(condition.keyword).ToLower();
            PagedResultDto<ThuVienVanBan> items = await _thuVienVanBanRepository.SearchAsync(condition);
            var documentStoreDtos = await _documentStoreAppService.GetFilesInfoByIdsAsync(items.Items.SelectMany(s => s.FileCuaThuVienVanBans).Where(s => s.FileId != null).Select(s => s.FileId).Distinct().ToList());
            var donViBanHanhDtos = await _donViBanHanhAppService.GetListByIds(items.Items.Select(s => s.DonViBanHanhId).Distinct().ToList());
            List<ThuVienVanBanDto> thuVienVanBanDtos = new List<ThuVienVanBanDto>();
            foreach (var item in items.Items)
            {
                var thuVienVanBanDto = ObjectMapper.Map<ThuVienVanBan, ThuVienVanBanDto>(item);
                thuVienVanBanDto.TenLoaiVanBan = item.LoaiVanBan.TenLoaiVanBan;
                thuVienVanBanDto.DonViBanHanh = donViBanHanhDtos.FirstOrDefault(s => s.Id == item.DonViBanHanhId) == null ? string.Empty :
                                                donViBanHanhDtos.FirstOrDefault(s => s.Id == item.DonViBanHanhId).Ten;
                thuVienVanBanDto.Files = documentStoreDtos.Where(s => item.FileCuaThuVienVanBans.Select(f => f.FileId).Contains(s.Id))
                                             .Select(s => new FileCuaThuVienVanBanDto()
                                             {
                                                 ThuVienVanBanId = item.Id,
                                                 FileId = s.Id,
                                                 TenFile = s.TenFile,
                                                 LinkDownload = s.Url,
                                                 KieuFile = s.KieuFile,
                                                 KichThuoc = s.KichThuoc,
                                                 FullName = s.FullName
                                             })
                                             .ToList();
                thuVienVanBanDtos.Add(thuVienVanBanDto);
            }
            return new PagedResultDto<ThuVienVanBanDto>(items.TotalCount, thuVienVanBanDtos);
        }

        public override async Task<PagedResultDto<ThuVienVanBanDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            PagedResultDto<ThuVienVanBan> items = await _thuVienVanBanRepository.GetListAsync(input);
            var documentStoreDtos = await _documentStoreAppService.GetFilesInfoByIdsAsync(items.Items.SelectMany(s => s.FileCuaThuVienVanBans).Where(s => s.FileId != null).Select(s => s.FileId).Distinct().ToList());
            var donViBanHanhDtos = await _donViBanHanhAppService.GetListByIds(items.Items.Select(s => s.DonViBanHanhId).Distinct().ToList());
            List<ThuVienVanBanDto> thuVienVanBanDtos = new List<ThuVienVanBanDto>();
            foreach (var item in items.Items)
            {
                var thuVienVanBanDto = ObjectMapper.Map<ThuVienVanBan, ThuVienVanBanDto>(item);
                thuVienVanBanDto.TenLoaiVanBan = item.LoaiVanBan.TenLoaiVanBan;
                thuVienVanBanDto.NgayBanHanhFormat = item.NgayBanHanh.ToDateTimeDefault(DateTimeFormat.Date);
                thuVienVanBanDto.DonViBanHanh = donViBanHanhDtos.FirstOrDefault(s => s.Id == item.DonViBanHanhId) == null ? string.Empty :
                                                donViBanHanhDtos.FirstOrDefault(s => s.Id == item.DonViBanHanhId).Ten;
                thuVienVanBanDto.Files = documentStoreDtos.Where(s => item.FileCuaThuVienVanBans.Select(f => f.FileId).Contains(s.Id))
                                            .Select(s => new FileCuaThuVienVanBanDto()
                                            {
                                                ThuVienVanBanId = item.Id,
                                                FileId = s.Id,
                                                TenFile = s.TenFile,
                                                LinkDownload = s.Url,
                                                KieuFile = s.KieuFile,
                                                KichThuoc = s.KichThuoc,
                                                FullName = s.FullName
                                            })
                                            .ToList();
                thuVienVanBanDtos.Add(thuVienVanBanDto);
            }
            return new PagedResultDto<ThuVienVanBanDto>(items.TotalCount, thuVienVanBanDtos);
        }

        public Task DeleteThuVienVanBan(Guid id)
        {
            List<Guid> fileIds = _fileCuaThuVienVanBanAppService.GetFileIdListAsync(id).Result.ToList();
            foreach (var fileId in fileIds)
            {
                _fileCuaThuVienVanBanAppService.DeleteByFileIdAsync(fileId);
            }
            return this.DeleteAsync(id);
        }

        public async Task<List<ThuVienVanBanDto>> GetCoSoPhapLyByIds(List<Guid> ids)
        {
            var items = await _thuVienVanBanRepository.GetCoSoPhapLyByIds(ids);
            var thuVienVanBanDtos = new List<ThuVienVanBanDto>();
            foreach (var item in items)
            {
                var thuVienVanBanDto = ObjectMapper.Map<ThuVienVanBan, ThuVienVanBanDto>(item);
                thuVienVanBanDto.TenLoaiVanBan = item.LoaiVanBan.TenLoaiVanBan;
                thuVienVanBanDto.NgayBanHanhFormat = item.NgayBanHanh.ToDateTimeDefault(DateTimeFormat.Date);
                thuVienVanBanDtos.Add(thuVienVanBanDto);
            }
            return thuVienVanBanDtos;
        }

        public Dictionary<int, string> GetCapBanHanhs()
        {
            return Enum.GetValues(typeof(CapBanHanh))
                       .Cast<CapBanHanh>()
                       .ToDictionary(t => (int)t, t => t.GetDescription());
        }
    }
}