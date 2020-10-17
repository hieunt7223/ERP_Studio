using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.ChucVuDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.ChucVus
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateChucVuDto ChucVu { get; set; }

        private readonly IChucVuAppService _chucVuAppService;
        private readonly IAuthorizationService _authorization;

        public EditModalModel(IChucVuAppService chucVuAppService, IAuthorizationService authorization)
        {
            _chucVuAppService = chucVuAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task OnGetAsync()
        {
            var chucVuDto = await _chucVuAppService.GetAsync(Id);
            ChucVu = ObjectMapper.Map<ChucVuDto, CreateUpdateChucVuDto>(chucVuDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.DonViHanhChinhPermission.Update))
            {
                await _chucVuAppService.UpdateAsync(Id, ChucVu);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }
    }
}