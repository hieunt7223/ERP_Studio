using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.LoaiVanBanDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.LoaiVanBans
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateLoaiVanBanPageModel LoaiVanBan { get; set; }

        private readonly ILoaiVanBanAppService _loaiVanBanAppService;

        private readonly IAuthorizationService _authorization;

        public EditModalModel(ILoaiVanBanAppService loaiVanBanAppService, IAuthorizationService authorization)
        {
            _loaiVanBanAppService = loaiVanBanAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task OnGetAsync()
        {
            var loaiVanBanDto = await _loaiVanBanAppService.GetAsync(Id);
            LoaiVanBan = ObjectMapper.Map<LoaiVanBanDto, CreateUpdateLoaiVanBanPageModel>(loaiVanBanDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.LoaiVanBanPermission.Update))
            {
                await _loaiVanBanAppService.UpdateAsync(Id, LoaiVanBan);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }

    }
}