using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.NhomCongTrinhDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.NhomCongTrinhs
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateNhomCongTrinhPageModel NhomCongTrinh { get; set; }

        private readonly INhomCongTrinhAppService _nhomCongTrinhAppService;
        private readonly IAuthorizationService _authorization;

        public EditModalModel(INhomCongTrinhAppService nhomCongTrinhAppService, IAuthorizationService authorization)
        {
            _nhomCongTrinhAppService = nhomCongTrinhAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task OnGetAsync()
        {
            var nhomCongTrinhDto = await _nhomCongTrinhAppService.GetAsync(Id);
            NhomCongTrinh = ObjectMapper.Map<NhomCongTrinhDto, CreateUpdateNhomCongTrinhPageModel>(nhomCongTrinhDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.NhomCongTrinhPermission.Update))
            {
                await _nhomCongTrinhAppService.UpdateAsync(Id, NhomCongTrinh);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }
    }
}