using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.ChuDauTus;
using xdcb.Common.DanhMuc.LoaiVanBans;
using xdcb.Common.DanhMuc.PhongBanDtos;
using xdcb.Common.DanhMuc.ThanhPhanHoSoDtos;
using xdcb.Common.Permissions;
using static xdcb.Common.DanhMuc.ViewTextConsts;

namespace xdcb.Common.DanhMuc.PhongBans
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public PhongBanViewModel PhongBan { get; set; }

        public List<SelectListItem> PhongBanList { get; set; }

        private readonly IPhongBanAppService _phongBanAppService;

        private readonly IChuDauTuAppService _chuDauTuAppService;

        private readonly IAuthorizationService _authorization;

        public EditModalModel(IPhongBanAppService phongBanAppService, IChuDauTuAppService chuDauTuAppService, IAuthorizationService authorization)
        {
            _phongBanAppService = phongBanAppService;
            _chuDauTuAppService = chuDauTuAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task OnGetAsync()
        {
            var phongBanDto = await _phongBanAppService.GetAsync(Id);
            var oldPhongBanDto = ObjectMapper.Map<PhongBanDto, CreateUpdatePhongBanDto>(phongBanDto);
            var chuDauTuList = await _chuDauTuAppService.GetChuDauTuListAsync();
            PhongBanList = new List<SelectListItem>();

            foreach (var item in chuDauTuList)
            {
                PhongBanList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Ten.ToString() });
            }

            PhongBan = new PhongBanViewModel
            {
                ChuDauTuId = oldPhongBanDto.ChuDauTuId,
                TenPhongBan = oldPhongBanDto.TenPhongBan,
                MaPhongBan = oldPhongBanDto.MaPhongBan,
                ChucNangNhiemVu = oldPhongBanDto.ChucNangNhiemVu,
                SoDienThoai = oldPhongBanDto.SoDienThoai
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var phongBanDto = new CreateUpdatePhongBanDto
            {
                ChuDauTuId = PhongBan.ChuDauTuId,
                TenPhongBan = PhongBan.TenPhongBan,
                MaPhongBan = PhongBan.MaPhongBan,
                ChucNangNhiemVu = PhongBan.ChucNangNhiemVu,
                SoDienThoai = PhongBan.SoDienThoai,
            };
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.PhongBanPermission.Create))
            {
                await _phongBanAppService.UpdateAsync(Id, phongBanDto);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }

        public class PhongBanViewModel
        {
            [SelectItems(nameof(PhongBanList))]
            [Required(ErrorMessage = Messages.MSG_Requied)]
            [DisplayName(Phongban.ChuDauTu)]
            [Placeholder(ViewTextConsts.PlaceholderPhongban.ChuDauTu)]
            public Guid ChuDauTuId { get; set; }

            [StringLength(10)]
            [DisplayName(Phongban.MaPhongBan)]
            [Placeholder(ViewTextConsts.PlaceholderPhongban.MaPhongBan)]
            public string MaPhongBan { get; set; }

            [Required(ErrorMessage = Messages.MSG_Requied)]
            [StringLength(100)]
            [DisplayName(Phongban.TenPhongBan)]
            [Placeholder(ViewTextConsts.PlaceholderPhongban.TenPhongBan)]
            public string TenPhongBan { get; set; }

            [StringLength(255)]
            [DisplayName(Phongban.ChucNangNhiemVu)]
            [Placeholder(ViewTextConsts.PlaceholderPhongban.ChucNangNhiemVu)]
            public string ChucNangNhiemVu { get; set; }

            [StringLength(24)]
            [DisplayName(Phongban.SoDienThoai)]
            [Placeholder(ViewTextConsts.PlaceholderPhongban.SoDienThoai)]
            public string SoDienThoai { get; set; }
        }
    }
}