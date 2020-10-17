using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.NghiQuyetDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.NghiQuyets
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateUpdateNghiQuyetDto NghiQuyet { get; set; }

        private readonly INghiQuyetAppService _nghiQuyetAppService;
        private readonly IAuthorizationService _authorization;

        public CreateModalModel(INghiQuyetAppService nghiQuyetAppService, IAuthorizationService authorization)
        {
            _nghiQuyetAppService = nghiQuyetAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.NghiQuyetPermission.Create))
            {
                await _nghiQuyetAppService.CreateAsync(NghiQuyet);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }
    }
}