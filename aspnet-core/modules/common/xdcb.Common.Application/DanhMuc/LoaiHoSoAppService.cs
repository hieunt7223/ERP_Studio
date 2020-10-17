using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization;
using Volo.Abp.Domain.Entities;
using xdcb.Common.Application.Extensions;
using xdcb.Common.DanhMuc.LoaiHoSoCoSoPhapLyDtos;
using xdcb.Common.DanhMuc.LoaiHoSoDtos;
using xdcb.Common.DanhMuc.LoaiHoSoThanhPhanHoSoDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.LoaiHoSos
{
    public class LoaiHoSoAppService : CrudAppService<
            LoaiHoSo,
            LoaiHoSoDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateLoaiHoSoDto, CreateUpdateLoaiHoSoDto>,
        ILoaiHoSoAppService
    {
        private readonly ILoaiHoSoRepository _loaiHoSoRepository;
        private readonly IAuthorizationService _authorization;

        public LoaiHoSoAppService(ILoaiHoSoRepository loaiHoSoRepository, IAuthorizationService authorization)
            : base(loaiHoSoRepository)
        {
            _loaiHoSoRepository = loaiHoSoRepository;
            _authorization = authorization;
        }

        public async Task<LoaiHoSoDto> GetLoaiHoSoByIdAsync(Guid loaiHoSoId)
        {
            var item = await _loaiHoSoRepository.GetLoaiHoSoByIdAsync(loaiHoSoId);
            return ObjectMapper.Map<LoaiHoSo, LoaiHoSoDto>(item);
        }

        public async Task<List<LoaiHoSoDto>> GetLoaiHoSoDuocApDungAsync(bool apDung = true)
        {
            var items = await _loaiHoSoRepository.GetLoaiHoSoDuocApDungAsync(apDung);
            return ObjectMapper.Map<List<LoaiHoSo>, List<LoaiHoSoDto>>(items);
        }

        [HttpGet]
        public async Task<PagedResultDto<LoaiHoSoDto>> SearchAsync(ConditionSearch condition)
        {
            condition.keyword = Common.ConvertToUnSign(condition.keyword).ToLower();
            PagedResultDto<LoaiHoSo> items = await _loaiHoSoRepository.SearchAsync(condition);
            return new PagedResultDto<LoaiHoSoDto>(items.TotalCount, ObjectMapper.Map<List<LoaiHoSo>, List<LoaiHoSoDto>>(items.Items.ToList()));
        }

        [HttpGet, Route("api/LoaiHoSo/all")]
        public async Task<List<LoaiHoSoDto>> GetAllAsync()
        {
            var items = await _loaiHoSoRepository.GetAllAsync();
            var donViHanhChinhs = ObjectMapper.Map<List<LoaiHoSo>, List<LoaiHoSoDto>>(items);
            return donViHanhChinhs;
        }

        [HttpGet]
        public async Task<dynamic> ExportAsync()
        {
            var list = await Repository.Where(s => !s.IsDeleted).AsNoTracking().ToListAsync();
            var listReport = list.Select(s => new LoaiHoSoReport
            {
                TenLoaiHoSo = s.TenLoaiHoSo,
                TrangThai = s.IsTrangThai ? ViewTextConsts.LoaiHoSo.ApDung : ViewTextConsts.LoaiHoSo.KhongApDung
            });
            return ReportExcelExtensions.GetFileExcel(listReport, ExcelBorderStyle.Dotted, "Danh mục Loại hồ sơ", "LoaiHoSo");
        }

        #region crud

        public override async Task<LoaiHoSoDto> CreateAsync(CreateUpdateLoaiHoSoDto input)
        {
            //check permission
            var permission = await _authorization.IsGrantedAsync(xdcbCommonPermissions.LoaiHoSoPermission.Create);
            if (!permission) throw new AbpAuthorizationException(Messages.MSG_NotPermission);
            try
            {
                var loaiHoSo = ObjectMapper.Map<CreateUpdateLoaiHoSoDto, LoaiHoSo>(input);
                EntityHelper.TrySetId(loaiHoSo, GuidGenerator.Create);
                CreateMapLoaiHoSo(loaiHoSo, input);
                //loaiHoSo.BieuMau = JsonSerializer.Serialize(input.BieuMaus);
                await _loaiHoSoRepository.InsertAsync(loaiHoSo);
                return MapToGetOutputDto(loaiHoSo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<LoaiHoSoDto> UpdateAsync(Guid id, CreateUpdateLoaiHoSoDto input)
        {
            //check permission
            var permission = await _authorization.IsGrantedAsync(xdcbCommonPermissions.LoaiHoSoPermission.Update);
            if (!permission) throw new AbpAuthorizationException(Messages.MSG_NotPermission);
            try
            {
                var loaiHoSo = await _loaiHoSoRepository.GetLoaiHoSoByIdAsync(id);
                if (loaiHoSo == null) throw new BusinessException("Không tồn tại loại hồ sơ để cập nhật");
                MapToEntity(input, loaiHoSo);
                loaiHoSo.LoaiHoSoThanhPhanHoSos.Clear();
                loaiHoSo.LoaiHoSoChiPhiDauTus.Clear();
                loaiHoSo.LoaiHoSoCoSoPhapLys.Clear();

                CreateMapLoaiHoSo(loaiHoSo, input);
                await _loaiHoSoRepository.UpdateAsync(loaiHoSo);
                return MapToGetOutputDto(loaiHoSo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CreateMapLoaiHoSo(LoaiHoSo loaiHoSo, CreateUpdateLoaiHoSoDto input)
        {
            var thanhPhanHoSos = ObjectMapper.Map<List<CreateUpdateLoaiHoSoThanhPhanHoSoDto>, List<LoaiHoSoThanhPhanHoSo>>(input.ThanhPhanHoSos);
            var coSoPhapLys = ObjectMapper.Map<List<CreateUpdateLoaiHoSoCoSoPhapLyDto>, List<LoaiHoSoCoSoPhapLy>>(input.CoSoPhapLys);

            loaiHoSo.LoaiHoSoThanhPhanHoSos.AddRange(thanhPhanHoSos);
            loaiHoSo.LoaiHoSoCoSoPhapLys.AddRange(coSoPhapLys);
        }

        [HttpDelete("/api/app/loaiHoSo/{id}")]
        public async Task<LoaiHoSoDto> DeleteLoaiHoSoAsync(Guid id)
        {
            //check permission
            var permission = await _authorization.IsGrantedAsync(xdcbCommonPermissions.LoaiHoSoPermission.Delete);
            if (!permission) throw new AbpAuthorizationException(Messages.MSG_NotPermission);
            var loaiHoSo = await _loaiHoSoRepository.GetLoaiHoSoByIdAsync(id);
            if (loaiHoSo == null) throw new BusinessException("Không tồn tại loại hồ sơ để xóa");
            loaiHoSo.LoaiHoSoChiPhiDauTus.Clear();
            loaiHoSo.LoaiHoSoThanhPhanHoSos.Clear();
            loaiHoSo.LoaiHoSoCoSoPhapLys.Clear();
            await _loaiHoSoRepository.DeleteAsync(loaiHoSo);
            return MapToGetOutputDto(loaiHoSo);
        }

        [RemoteService(false)]
        public override Task DeleteAsync(Guid id)
        {
            throw new NotSupportedException();
        }

        [RemoteService(false)]
        public override Task<LoaiHoSoDto> GetAsync(Guid id)
        {
            throw new NotSupportedException();
        }

        #endregion crud
    }
}