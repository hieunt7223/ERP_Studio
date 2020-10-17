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
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateNghiQuyetDto NghiQuyet { get; set; }

        private readonly INghiQuyetAppService _NghiQuyetAppService;
        private readonly IAuthorizationService _authorization;

        public EditModalModel(INghiQuyetAppService NghiQuyetAppService, IAuthorizationService authorization)
        {
            _NghiQuyetAppService = NghiQuyetAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task OnGetAsync()
        {
            var NghiQuyetDto = await _NghiQuyetAppService.GetAsync(Id);
            NghiQuyet = ObjectMapper.Map<NghiQuyetDto, CreateUpdateNghiQuyetDto>(NghiQuyetDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.NghiQuyetPermission.Update))
            {
                await _NghiQuyetAppService.UpdateAsync(Id, NghiQuyet);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }
    }
}