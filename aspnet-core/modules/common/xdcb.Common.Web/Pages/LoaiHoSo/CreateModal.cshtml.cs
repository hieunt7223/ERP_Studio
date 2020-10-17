using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.LoaiHoSoDtos;
using xdcb.Common.DanhMuc.ThanhPhanHoSoDtos;
using xdcb.Common.DanhMuc.ThuVienVanBanDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.LoaiHoSos
{
    public class CreateModalModel : Web.Pages.CommonBaseAbpPageModel
    {
        [BindProperty]
        public CreateUpdateLoaiHoSoDto LoaiHoSo { get; set; }

        public List<ThuVienVanBanDto> CoSoPhapLys { get; set; }

        public List<ThanhPhanHoSoDto> ThanhPhanHoSoDtos { get; set; }

        private readonly IAuthorizationService _authorization;

        public CreateModalModel(IAuthorizationService authorization)
        {
            _authorization = authorization;
        }

        public async Task OnGetAsync()
        {
            if (!await _authorization.IsGrantedAsync(xdcbCommonPermissions.LoaiHoSoPermission.Create))
            {
                throw new AbpAuthorizationException(Messages.MSG_NotPermission);
            }
            LoaiHoSo = new CreateUpdateLoaiHoSoDto();
            LoaiHoSo.ThoiGianXuLyQuyDinhNhomA = 15;
            LoaiHoSo.ThoiGianXuLyQuyDinhNhomB = 15;
            LoaiHoSo.ThoiGianXuLyQuyDinhNhomC = 15;
        }
    }
}