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
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateChiPhiDauTuDto ChiPhiDauTu { get; set; }

        private readonly IChiPhiDauTuAppService _chiPhiDauTuAppService;
        private readonly IAuthorizationService _authorization;

        public EditModalModel(IChiPhiDauTuAppService chiPhiDauTuAppService, IAuthorizationService authorization)
        {
            _chiPhiDauTuAppService = chiPhiDauTuAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task OnGetAsync()
        {
            var chiPhiDauTuDto = await _chiPhiDauTuAppService.GetAsync(Id);
            ChiPhiDauTu = ObjectMapper.Map<ChiPhiDauTuDto, CreateUpdateChiPhiDauTuDto>(chiPhiDauTuDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.ChiPhiDauTuPermission.Update))
            {
                await _chiPhiDauTuAppService.UpdateAsync(Id, ChiPhiDauTu);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }
    }
}