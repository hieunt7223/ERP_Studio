using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.HinhThucHopDongDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.HinhThucHopDongs
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateUpdateHinhThucHopDongDto HinhThucHopDong { get; set; }

        private readonly IHinhThucHopDongAppService _hinhThucHopDongAppService;
        private readonly IAuthorizationService _authorization;

        public CreateModalModel(IHinhThucHopDongAppService hinhThucHopDongAppService, IAuthorizationService authorization)
        {
            _hinhThucHopDongAppService = hinhThucHopDongAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.HinhThucHopDongPermission.Update))
            {
                await _hinhThucHopDongAppService.CreateAsync(HinhThucHopDong);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }
    }
}