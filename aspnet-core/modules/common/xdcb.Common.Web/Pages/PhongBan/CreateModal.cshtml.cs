using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.ChuDauTus;
using xdcb.Common.DanhMuc.PhongBanDtos;
using xdcb.Common.Permissions;
using static xdcb.Common.DanhMuc.ViewTextConsts;

namespace xdcb.Common.DanhMuc.PhongBans
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public PhongBanViewModel PhongBan { get; set; }

        public List<SelectListItem> PhongBanList { get; set; }

        private readonly IPhongBanAppService _phongBanAppService;

        private readonly IChuDauTuAppService _chuDauTuAppService;

        private readonly IAuthorizationService _authorization;

        public CreateModalModel(IPhongBanAppService phongBanAppService, IChuDauTuAppService chuDauTuAppService, IAuthorizationService authorization)
        {
            _phongBanAppService = phongBanAppService;
            _chuDauTuAppService = chuDauTuAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task OnGetAsync()
        {
            var chuDauTuList = await _chuDauTuAppService.GetChuDauTuListAsync();
            PhongBanList = new List<SelectListItem>();
            foreach (var item in chuDauTuList)
            {
                PhongBanList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Ten.ToString() });
            }
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
                await _phongBanAppService.CreateAsync(phongBanDto);
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