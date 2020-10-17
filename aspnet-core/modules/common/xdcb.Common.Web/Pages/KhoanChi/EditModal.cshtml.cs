using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.KhoanChiDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.KhoanChis
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateKhoanChiPageModel KhoanChi { get; set; }

        private readonly IKhoanChiAppService _khoanChiAppService;
        private readonly IAuthorizationService _authorization;

        public EditModalModel(IKhoanChiAppService khoanChiAppService, IAuthorizationService authorization)
        {
            _khoanChiAppService = khoanChiAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task OnGetAsync()
        {
            var khoanChiDto = await _khoanChiAppService.GetAsync(Id);
            KhoanChi = ObjectMapper.Map<KhoanChiDto, CreateUpdateKhoanChiPageModel>(khoanChiDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.KhoanChiPermission.Update))
            {
                await _khoanChiAppService.UpdateAsync(Id, KhoanChi);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }
    }
}