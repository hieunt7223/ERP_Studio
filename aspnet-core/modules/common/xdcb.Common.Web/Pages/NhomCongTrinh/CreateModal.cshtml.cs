using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.NhomCongTrinhDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.NhomCongTrinhs
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateUpdateNhomCongTrinhPageModel NhomCongTrinh { get; set; }

        private readonly INhomCongTrinhAppService _nhomCongTrinhAppService;
        private readonly IAuthorizationService _authorization;

        public CreateModalModel(INhomCongTrinhAppService nhomCongTrinhAppService, IAuthorizationService authorization)
        {
            _nhomCongTrinhAppService = nhomCongTrinhAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.NhomCongTrinhPermission.Create))
            {
                await _nhomCongTrinhAppService.CreateAsync(NhomCongTrinh);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }

    }
}