using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.PhuongThucDauThauDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.PhuongThucDauThaus
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdatePhuongThucDauThauDto PhuongThucDauThau { get; set; }

        private readonly IPhuongThucDauThauAppService _phuongThucDauThauAppService;
        private readonly IAuthorizationService _authorization;

        public EditModalModel(IPhuongThucDauThauAppService phuongThucDauThauAppService, IAuthorizationService authorization)
        {
            _phuongThucDauThauAppService = phuongThucDauThauAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task OnGetAsync()
        {
            var phuongThucDauThauDto = await _phuongThucDauThauAppService.GetAsync(Id);
            PhuongThucDauThau = ObjectMapper.Map<PhuongThucDauThauDto, CreateUpdatePhuongThucDauThauDto>(phuongThucDauThauDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.PhuongThucDauThauPermission.Update))
            {
                await _phuongThucDauThauAppService.UpdateAsync(Id, PhuongThucDauThau);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }
    }
}