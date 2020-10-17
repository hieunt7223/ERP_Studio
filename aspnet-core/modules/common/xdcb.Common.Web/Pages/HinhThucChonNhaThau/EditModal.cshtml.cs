using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.HinhThucChonNhaThauDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.HinhThucChonNhaThaus
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateHinhThucChonNhaThauDto HinhThucChonNhaThau { get; set; }

        private readonly IHinhThucChonNhaThauAppService _hinhThucChonNhaThauAppService;
        private readonly IAuthorizationService _authorization;

        public EditModalModel(IHinhThucChonNhaThauAppService hinhThucChonNhaThauAppService, IAuthorizationService authorization)
        {
            _hinhThucChonNhaThauAppService = hinhThucChonNhaThauAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task OnGetAsync()
        {
            var hinhThucChonNhaThauDto = await _hinhThucChonNhaThauAppService.GetAsync(Id);
            HinhThucChonNhaThau = ObjectMapper.Map<HinhThucChonNhaThauDto, CreateUpdateHinhThucChonNhaThauDto>(hinhThucChonNhaThauDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.HinhThucLuaChonNhaThauPermission.Update))
            {
                await _hinhThucChonNhaThauAppService.UpdateAsync(Id, HinhThucChonNhaThau);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }
    }
}