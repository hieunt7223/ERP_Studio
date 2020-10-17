using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.LoaiCongTrinhDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.LoaiCongTrinhs
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateUpdateLoaiCongTrinhPageModel LoaiCongTrinh { get; set; }

        private readonly ILoaiCongTrinhAppService _loaiCongTrinhAppService;

        private readonly IAuthorizationService _authorization;

        public CreateModalModel(ILoaiCongTrinhAppService loaiCongTrinhAppService, IAuthorizationService authorization)
        {
            _loaiCongTrinhAppService = loaiCongTrinhAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.LoaiCongTrinhPermission.Create))
            {
                await _loaiCongTrinhAppService.CreateAsync(LoaiCongTrinh);
                return Redirect("/");
            }

            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }

    }
}