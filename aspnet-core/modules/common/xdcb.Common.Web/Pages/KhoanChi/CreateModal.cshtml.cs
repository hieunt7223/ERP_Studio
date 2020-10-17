using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.KhoanChiDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.KhoanChis
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateUpdateKhoanChiPageModel KhoanChi { get; set; }

        private readonly IKhoanChiAppService _khoanChiAppService;
        private readonly IAuthorizationService _authorization;

        public CreateModalModel(IKhoanChiAppService khoanChiAppService, IAuthorizationService authorization)
        {
            _khoanChiAppService = khoanChiAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.KhoanChiPermission.Create))
            {
                await _khoanChiAppService.CreateAsync(KhoanChi);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }
    }
}