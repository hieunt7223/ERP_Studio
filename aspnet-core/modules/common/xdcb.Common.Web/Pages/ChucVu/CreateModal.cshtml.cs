using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.ChucVuDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.ChucVus
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateUpdateChucVuDto ChucVu { get; set; }

        private readonly IChucVuAppService _chucVuAppService;
        private readonly IAuthorizationService _authorization;

        public CreateModalModel(IChucVuAppService chucVuAppService, IAuthorizationService authorization)
        {
            _chucVuAppService = chucVuAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.DonViHanhChinhPermission.Create))
            {
                await _chucVuAppService.CreateAsync(ChucVu);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }
    }
}