using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xdcb.QuanLyVon.KeHoachVonNQ.Dtos;

namespace xdcb.QuanLyVon.KeHoachVonNQs
{
    /// <summary>
    /// Generated AppService for Table : KeHoachVonNQ.
    /// </summary>
    public class KeHoachVonNQAppService : QuanLyVonAppServiceBase, IKeHoachVonNQAppService
    {
        #region Generated By Column

        private readonly IKeHoachVonNQRepository _iKeHoachVonNQRepository;

        public KeHoachVonNQAppService(IKeHoachVonNQRepository iKeHoachVonNQRepository)
        {
            _iKeHoachVonNQRepository = iKeHoachVonNQRepository;
        }

        public async Task<List<KeHoachVonNQDto>> GetListAsync()
        {
            var items = await _iKeHoachVonNQRepository.GetListAsync();
            if (items != null && items.Count > 0)
            {
                items = items.Where(x => x.IsDeleted == false).ToList();
            }
            return new List<KeHoachVonNQDto>(ObjectMapper.Map<List<KeHoachVonNQ>, List<KeHoachVonNQDto>>(items));
        }

        public async Task<KeHoachVonNQDto> GetAsync(Guid id)
        {
            var items = await _iKeHoachVonNQRepository.GetAsync(id);
            if (items != null && items.IsDeleted == true)
            {
                items = null;
            }
            return ObjectMapper.Map<KeHoachVonNQ, KeHoachVonNQDto>(items);
        }

        public async Task<KeHoachVonNQDto> Create(CreateUpdateKeHoachVonNQDto input)
        {
            var item = ObjectMapper.Map<CreateUpdateKeHoachVonNQDto, KeHoachVonNQ>(input);
            var data = await _iKeHoachVonNQRepository.InsertAsync(item, true);
            return ObjectMapper.Map<KeHoachVonNQ, KeHoachVonNQDto>(data);
        }

        public async Task<KeHoachVonNQDto> Update(Guid id, CreateUpdateKeHoachVonNQDto input)
        {
            var item = await _iKeHoachVonNQRepository.GetAsync(id);
            if (item != null && item.IsDeleted == false)
            {
                item.Nam = input.Nam;
                item.KeHoachVonDauNam = input.KeHoachVonDauNam;
                item.KeHoachVonDauNamDuocDuyet = input.KeHoachVonDauNamDuocDuyet;
                item.KeHoachVonDieuChinh = input.KeHoachVonDieuChinh;
                item.KeHoachVonDieuChinhDuocDuyet = input.KeHoachVonDieuChinhDuocDuyet;
                item.TrangThaiDauNam = input.TrangThaiDauNam;
                item.TrangThaiDieuChinh = input.TrangThaiDieuChinh;
                item.NgayBanHanhDauNam = input.NgayBanHanhDauNam;
                item.NgayBanHanhDieuChinh = input.NgayBanHanhDieuChinh;
                item.SoQuyetDinhDauNam = input.SoQuyetDinhDauNam;
                item.SoQuyetDinhDieuChinh = input.SoQuyetDinhDieuChinh;
                item.DinhKemFileDauNam = input.DinhKemFileDauNam;
                item.DinhKemFileDieuChinh = input.DinhKemFileDieuChinh;
                var data = await _iKeHoachVonNQRepository.UpdateAsync(item, true);
                return ObjectMapper.Map<KeHoachVonNQ, KeHoachVonNQDto>(data);
            }
            return ObjectMapper.Map<KeHoachVonNQ, KeHoachVonNQDto>(item);
        }

        public async Task Delete(Guid id)
        {
            var item = await _iKeHoachVonNQRepository.GetAsync(id);
            if (item != null && item.IsDeleted == false)
            {
                item.IsDeleted = true;
                await _iKeHoachVonNQRepository.UpdateAsync(item, true);
            }
        }

        #endregion

        #region Property
        public async Task<List<KeHoachVonNQDto>> GetSearchData(int nam, string loaikehoach, string trangthai)
        {
            List<KeHoachVonNQDto> list = new List<KeHoachVonNQDto>();

            if (string.IsNullOrWhiteSpace(loaikehoach))
            {
                loaikehoach = "";
            }
            if (string.IsNullOrWhiteSpace(trangthai))
            {
                trangthai = "";
            }
            var item = _iKeHoachVonNQRepository.GetListAsync().GetAwaiter().GetResult().ToList();
            if (item != null && item.Count > 0)
            {
                //daunam
                item.Where(x => !string.IsNullOrWhiteSpace(x.TrangThaiDauNam)
                            && (nam == 0 || x.Nam == nam)
                ).ToList().ForEach(o =>
                {
                    var dto = ObjectMapper.Map<KeHoachVonNQ, KeHoachVonNQDto>(o);
                    dto.TrangThai = dto.TrangThaiDauNam;
                    dto.DinhKemFile = dto.DinhKemFileDauNam;
                    dto.NgayBanHanh = dto.NgayBanHanhDauNam;
                    dto.DinhKemFile = dto.DinhKemFileDauNam;
                    dto.SoQuyetDinh = dto.SoQuyetDinhDauNam;
                    dto.KeHoachVonDieuChinh = 0;
                    dto.KeHoachVonDieuChinhDuocDuyet = 0;
                    dto.LoaiKeHoach = "DAU_NAM";
                    list.Add(dto);
                });
                //dieuchinh
                item.Where(x => !string.IsNullOrWhiteSpace(x.TrangThaiDieuChinh)
                            && (nam == 0 || x.Nam == nam)
                ).ToList().ForEach(o =>
                {
                    var dto = ObjectMapper.Map<KeHoachVonNQ, KeHoachVonNQDto>(o);
                    dto.TrangThai = dto.TrangThaiDieuChinh;
                    dto.DinhKemFile = dto.DinhKemFileDieuChinh;
                    dto.NgayBanHanh = dto.NgayBanHanhDieuChinh;
                    dto.DinhKemFile = dto.DinhKemFileDieuChinh;
                    dto.SoQuyetDinh = dto.SoQuyetDinhDieuChinh;
                    dto.LoaiKeHoach = "DIEU_CHINH";
                    list.Add(dto);
                });

                list = list.Where(x => !string.IsNullOrWhiteSpace(x.LoaiKeHoach)
                                && (loaikehoach == "" || x.LoaiKeHoach == loaikehoach)
                                && (trangthai == "" || x.TrangThai == trangthai)).ToList();
            }
            return list;
        }
        [HttpPut]
        [Route("/api/app/KeHoachVonNQDieuChinh/{id}")]
        public async Task DeleteKeHoachVonNQDieuChinh(Guid id)
        {
            var item = await _iKeHoachVonNQRepository.GetAsync(id);
            if (item != null && item.IsDeleted == false)
            {
                item.TrangThaiDieuChinh = string.Empty;
                item.DinhKemFileDieuChinh = string.Empty;
                item.KeHoachVonDieuChinh = 0;
                item.KeHoachVonDieuChinhDuocDuyet = 0;
                item.NgayBanHanhDieuChinh = null;
                await _iKeHoachVonNQRepository.UpdateAsync(item, true);
            }
        }
        #endregion
    }
}