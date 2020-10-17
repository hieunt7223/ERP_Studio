using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.LinhVucVanBanDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.LinhVucVanBans
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateLinhVucVanBanPageModel LinhVucVanBan { get; set; }

        private readonly ILinhVucVanBanAppService _linhVucVanBanAppService;
        private readonly IAuthorizationService _authorization;

        public EditModalModel(ILinhVucVanBanAppService linhVucVanBanAppService, IAuthorizationService authorization)
        {
            _linhVucVanBanAppService = linhVucVanBanAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task OnGetAsync()
        {
            var linhVucVanBanDto = await _linhVucVanBanAppService.GetAsync(Id);
            LinhVucVanBan = ObjectMapper.Map<LinhVucVanBanDto, CreateUpdateLinhVucVanBanPageModel>(linhVucVanBanDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.LinhVucVanBanPermission.Update))
            {
                await _linhVucVanBanAppService.UpdateAsync(Id, LinhVucVanBan);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }

    }
}