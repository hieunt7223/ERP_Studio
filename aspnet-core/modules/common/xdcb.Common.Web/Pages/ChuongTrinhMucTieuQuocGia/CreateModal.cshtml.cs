using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGiaDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGias
{
    public class CreateModalModel : AbpPageModel
    {
        private List<ChuongTrinhMucTieuQuocGiaDto> parentChuongTrinhMucTieuQuocGia;
        private readonly IChuongTrinhMucTieuQuocGiaAppService _chuongTrinhMucTieuQuocGiaAppService;
        private readonly IAuthorizationService _authorization;

        [BindProperty]
        public ChuongTrinhMucTieuQuocGiaViewModel ChuongTrinhMucTieuQuocGia { get; set; }

        public List<SelectListItem> SelectParentList { get; set; }

        public CreateModalModel(IChuongTrinhMucTieuQuocGiaAppService chuongTrinhMucTieuQuocGiaAppService, IAuthorizationService authorization)
        {
            _chuongTrinhMucTieuQuocGiaAppService = chuongTrinhMucTieuQuocGiaAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task OnGetAsync()
        {
            parentChuongTrinhMucTieuQuocGia = (List<ChuongTrinhMucTieuQuocGiaDto>)await _chuongTrinhMucTieuQuocGiaAppService.GetMaChuongTrinhQuocGia() ?? new List<ChuongTrinhMucTieuQuocGiaDto>(); ;
            SelectParentList = new List<SelectListItem>();
            SelectParentList.Add(new SelectListItem { Value = "", Text = ViewTextConsts.PlaceholderChuongTrinhMucTieuQuocGia.ChuongTrinhMucTieuQuocGiaCha, Selected = true, Disabled = true });
            foreach (var item in parentChuongTrinhMucTieuQuocGia)
            {
                SelectParentList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Select+ item.MaChuongTrinhMucTieuQuocGia.ToString() });
            }
        }

        public class ChuongTrinhMucTieuQuocGiaViewModel
        {
            [System.ComponentModel.DisplayName(ViewTextConsts.ChuongTrinhMucTieuQuocGia.MaChuongTrinhMucTieuQuocGia)]
            [StringLength(16)]
            [Placeholder(ViewTextConsts.PlaceholderChuongTrinhMucTieuQuocGia.MaChuongTrinhMucTieuQuocGia)]
            public string MaChuongTrinhMucTieuQuocGia { get; set; }

            [System.ComponentModel.DisplayName(ViewTextConsts.ChuongTrinhMucTieuQuocGia.TenChuongTrinhMucTieuQuocGia)]
            [StringLength(255)]
            [Required(ErrorMessage = Messages.MSG_Requied)]
            [Placeholder(ViewTextConsts.PlaceholderChuongTrinhMucTieuQuocGia.TenChuongTrinhMucTieuQuocGia)]
            public string TenChuongTrinhMucTieuQuocGia { get; set; }

            [SelectItems(nameof(SelectParentList))]
            [System.ComponentModel.DisplayName(ViewTextConsts.ChuongTrinhMucTieuQuocGia.MaChuongTrinhMucTieuQuocGiaCha)]
            public Guid? ParentId { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.ChuongTrinhMucTieuVaDuAnQuocGiaPermission.Create))
            {
                var thuVienVanBanDto = ObjectMapper.Map<ChuongTrinhMucTieuQuocGiaViewModel, CreateUpdateChuongTrinhMucTieuQuocGiaDto>(ChuongTrinhMucTieuQuocGia);
                await _chuongTrinhMucTieuQuocGiaAppService.CreateAsync(thuVienVanBanDto);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }
    }
}