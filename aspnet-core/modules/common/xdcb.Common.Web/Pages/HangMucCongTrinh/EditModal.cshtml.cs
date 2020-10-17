using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.HangMucCongTrinhDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.HangMucCongTrinhs
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateHangMucCongTrinhDto HangMucCongTrinh { get; set; }

        private readonly IHangMucCongTrinhAppService _hangMucCongTrinhAppService;
        private readonly IAuthorizationService _authorization;

        public EditModalModel(IHangMucCongTrinhAppService hangMucCongTrinhAppService, IAuthorizationService authorization)
        {
            _hangMucCongTrinhAppService = hangMucCongTrinhAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task OnGetAsync()
        {
            var hangMucCongTrinhDto = await _hangMucCongTrinhAppService.GetAsync(Id);
            HangMucCongTrinh = ObjectMapper.Map<HangMucCongTrinhDto, CreateUpdateHangMucCongTrinhDto>(hangMucCongTrinhDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.HangMucCongTrinhPermission.Update))
            {
                await _hangMucCongTrinhAppService.UpdateAsync(Id, HangMucCongTrinh);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }
    }
}