using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.LoaiVanBanDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.LoaiVanBans
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateUpdateLoaiVanBanPageModel LoaiVanBan { get; set; }

        private readonly ILoaiVanBanAppService _loaiVanBanAppService;

        private readonly IAuthorizationService _authorization;

        public CreateModalModel(ILoaiVanBanAppService loaiVanBanAppService, IAuthorizationService authorization)
        {
            _loaiVanBanAppService = loaiVanBanAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.LoaiVanBanPermission.Create))
            {
                await _loaiVanBanAppService.CreateAsync(LoaiVanBan);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }

    }
}