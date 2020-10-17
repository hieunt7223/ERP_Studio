using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.PhuongThucDauThauDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.PhuongThucDauThaus
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateUpdatePhuongThucDauThauDto PhuongThucDauThau { get; set; }

        private readonly IPhuongThucDauThauAppService _phuongThucDauThauAppService;
        private readonly IAuthorizationService _authorization;

        public CreateModalModel(IPhuongThucDauThauAppService phuongThucDauThauAppService, IAuthorizationService authorization)
        {
            _phuongThucDauThauAppService = phuongThucDauThauAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.PhuongThucDauThauPermission.Create))
            {
                await _phuongThucDauThauAppService.CreateAsync(PhuongThucDauThau);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }
    }
}