using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.NganhLinhVucSuDungDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.NganhLinhVucSuDungs
{
    [Authorize]
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateUpdateNganhLinhVucSuDungDto NganhLinhVucSuDung { get; set; }

        private readonly INganhLinhVucSuDungAppService _nganhLinhVucSuDungAppService;
        private readonly IAuthorizationService _authorization;

        public CreateModalModel(INganhLinhVucSuDungAppService nganhLinhVucSuDungAppService, IAuthorizationService authorization)
        {
            _nganhLinhVucSuDungAppService = nganhLinhVucSuDungAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!await _authorization.IsGrantedAsync(xdcbCommonPermissions.NganhLinhVucPermission.Create))
                throw new AbpAuthorizationException(Messages.MSG_NotPermission);
            await _nganhLinhVucSuDungAppService.CreateAsync(NganhLinhVucSuDung);
            return NoContent();
        }
    }
}