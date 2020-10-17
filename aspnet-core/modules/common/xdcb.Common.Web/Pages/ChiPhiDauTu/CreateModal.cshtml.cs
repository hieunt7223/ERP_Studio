using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.ChiPhiDauTuDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.ChiPhiDauTus
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateUpdateChiPhiDauTuDto ChiPhiDauTu { get; set; }

        private readonly IChiPhiDauTuAppService _chiPhiDauTuAppService;
        private readonly IAuthorizationService _authorization;

        public CreateModalModel(IChiPhiDauTuAppService chiPhiDauTuAppService, IAuthorizationService authorization)
        {
            _chiPhiDauTuAppService = chiPhiDauTuAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.ChiPhiDauTuPermission.Create))
            {
                await _chiPhiDauTuAppService.CreateAsync(ChiPhiDauTu);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }
    }
}