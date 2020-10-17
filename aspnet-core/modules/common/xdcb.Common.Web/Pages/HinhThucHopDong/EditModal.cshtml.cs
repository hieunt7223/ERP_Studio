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
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateHinhThucHopDongDto HinhThucHopDong { get; set; }

        private readonly IHinhThucHopDongAppService _hinhThucHopDongAppService;
        private readonly IAuthorizationService _authorization;

        public EditModalModel(IHinhThucHopDongAppService hinhThucHopDongAppService, IAuthorizationService authorization)
        {
            _hinhThucHopDongAppService = hinhThucHopDongAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task OnGetAsync()
        {
            var hinhThucHopDongDto = await _hinhThucHopDongAppService.GetAsync(Id);
            HinhThucHopDong = ObjectMapper.Map<HinhThucHopDongDto, CreateUpdateHinhThucHopDongDto>(hinhThucHopDongDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.HinhThucHopDongPermission.Create))
            {
                await _hinhThucHopDongAppService.UpdateAsync(Id, HinhThucHopDong);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }
    }
}