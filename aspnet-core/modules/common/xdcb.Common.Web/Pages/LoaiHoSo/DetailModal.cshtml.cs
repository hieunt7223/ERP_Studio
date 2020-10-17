using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.LoaiHoSoDtos;
using xdcb.Common.DanhMuc.ThanhPhanHoSoDtos;
using xdcb.Common.DanhMuc.ThanhPhanHoSos;
using xdcb.Common.DanhMuc.ThuVienVanBanDtos;
using xdcb.Common.DanhMuc.ThuVienVanBans;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.LoaiHoSos
{
    public class DetailModal : Web.Pages.CommonBaseAbpPageModel
    {
        [BindProperty]
        public CreateUpdateLoaiHoSoDto LoaiHoSo { get; set; }

        //public List<BieuMauDto> BieuMaus { get; set; }

        public List<ThuVienVanBanDto> CoSoPhapLys { get; set; }

        //public List<ChiPhiDauTuDto> ChiPhiDauTuDtos { get; set; }

        public List<ThanhPhanHoSoDto> ThanhPhanHoSoDtos { get; set; }

        private readonly ILoaiHoSoAppService _loaiHoSoAppService;
        private readonly IThanhPhanHoSoAppService _thanhPhanHoSoAppService;
        private readonly IThuVienVanBanAppService _thuVienVanBanAppService;

        private readonly IAuthorizationService _authorization;

        public DetailModal(
            ILoaiHoSoAppService loaiHoSoAppService,
            IThanhPhanHoSoAppService thanhPhanHoSoAppService,
            IThuVienVanBanAppService thuVienVanBanAppService,
            IAuthorizationService authorization)
        {
            _loaiHoSoAppService = loaiHoSoAppService;
            _thanhPhanHoSoAppService = thanhPhanHoSoAppService;
            _thuVienVanBanAppService = thuVienVanBanAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task OnGetAsync(Guid loaiHoSoId)
        {
            if (!await _authorization.IsGrantedAsync(xdcbCommonPermissions.LoaiHoSoPermission.Default))
            {
                throw new AbpAuthorizationException(Messages.MSG_NotPermission);
            }
            var loaiHoSoDto = await _loaiHoSoAppService.GetLoaiHoSoByIdAsync(loaiHoSoId);
            LoaiHoSo = ObjectMapper.Map<LoaiHoSoDto, CreateUpdateLoaiHoSoDto>(loaiHoSoDto);
            ThanhPhanHoSoDtos = await _thanhPhanHoSoAppService.GetThanhPhanHoSoByIds(loaiHoSoDto.LoaiHoSoThanhPhanHoSos.Select(s => s.ThanhPhanHoSoId).ToList());
            foreach (var item in ThanhPhanHoSoDtos)
            {
                var thanhPhanDto = loaiHoSoDto.LoaiHoSoThanhPhanHoSos.FirstOrDefault(s => s.ThanhPhanHoSoId == item.Id);
                if (thanhPhanDto != null)
                {
                    item.IsBatBuoc = thanhPhanDto.BatBuoc;
                }
            }

            CoSoPhapLys = await _thuVienVanBanAppService.GetCoSoPhapLyByIds(loaiHoSoDto.LoaiHoSoCoSoPhapLys.Select(s => s.ThuVienVanBanId).Distinct().ToList());
        }
    }
}