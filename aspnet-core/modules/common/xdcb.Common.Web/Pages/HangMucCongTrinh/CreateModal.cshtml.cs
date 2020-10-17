using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.HangMucCongTrinhDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.HangMucCongTrinhs
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateUpdateHangMucCongTrinhDto HangMucCongTrinh { get; set; }

        private readonly IHangMucCongTrinhAppService _hangMucCongTrinhAppService;
        private readonly IAuthorizationService _authorization;

        public CreateModalModel(IHangMucCongTrinhAppService hangMucCongTrinhAppService, IAuthorizationService authorization)
        {
            _hangMucCongTrinhAppService = hangMucCongTrinhAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.HangMucCongTrinhPermission.Create))
            {
                await _hangMucCongTrinhAppService.CreateAsync(HangMucCongTrinh);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }
    }
}