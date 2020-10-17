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
using xdcb.Common.DanhMuc.LoaiVanBans;
using xdcb.Common.DanhMuc.ThanhPhanHoSoDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.ThanhPhanHoSos
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public ThanhPhanHoSoViewModel ThanhPhanHoSo { get; set; }

        public List<SelectListItem> LoaiVanBanList { get; set; }

        private readonly IThanhPhanHoSoAppService _thanhPhanHoSoAppService;

        private readonly ILoaiVanBanAppService _loaiVanBanAppService;
        private readonly IAuthorizationService _authorization;

        public EditModalModel(IThanhPhanHoSoAppService thanhPhanHoSoAppService, ILoaiVanBanAppService loaiVanBanAppService, IAuthorizationService authorization)
        {
            _thanhPhanHoSoAppService = thanhPhanHoSoAppService;
            _loaiVanBanAppService = loaiVanBanAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task OnGetAsync()
        {
            var thanhPhanHoSoDto = await _thanhPhanHoSoAppService.GetAsync(Id);
            ThanhPhanHoSo = ObjectMapper.Map<ThanhPhanHoSoDto, ThanhPhanHoSoViewModel>(thanhPhanHoSoDto);
            var loaiVanBanList = await _loaiVanBanAppService.GetLoaiVanBanListAsync();
            LoaiVanBanList = new List<SelectListItem>();
            foreach (var item in loaiVanBanList)
            {
                LoaiVanBanList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.TenLoaiVanBan.ToString() });
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.ThanhPhanHoSoPermission.Update))
            {
                var thanhPhanHoSoDto = ObjectMapper.Map<ThanhPhanHoSoViewModel, CreateUpdateThanhPhanHoSoDto>(ThanhPhanHoSo);
                await _thanhPhanHoSoAppService.UpdateAsync(Id, thanhPhanHoSoDto);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }

        public class ThanhPhanHoSoViewModel
        {
            [Required(ErrorMessage = Messages.MSG_Requied)]
            [DisplayName(ViewTextConsts.ThanhPhanHoSo.TenThanhPhanHoSo)]
            [Placeholder(ViewTextConsts.PlaceholderThanhPhanHoSo.TenThanhPhanHoSo)]
            public string TenThanhPhanHoSo { get; set; }

            [SelectItems(nameof(LoaiVanBanList))]
            [DisplayName(ViewTextConsts.ThanhPhanHoSo.LoaiVanBan)]
            public Guid? LoaiVanBanId { get; set; }
        }
    }
}