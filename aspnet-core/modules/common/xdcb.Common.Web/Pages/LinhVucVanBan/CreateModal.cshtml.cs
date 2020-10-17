using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.LinhVucVanBanDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.LinhVucVanBans
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateUpdateLinhVucVanBanPageModel LinhVucVanBan { get; set; }

        private readonly ILinhVucVanBanAppService _linhVucVanBanAppService;
        private readonly IAuthorizationService _authorization;

        public CreateModalModel(ILinhVucVanBanAppService linhVucVanBanAppService, IAuthorizationService authorization)
        {
            _linhVucVanBanAppService = linhVucVanBanAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.LinhVucVanBanPermission.Create))
            {
                await _linhVucVanBanAppService.CreateAsync(LinhVucVanBan);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }

    }
}