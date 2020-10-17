using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.LoaiCongTrinhDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.LoaiCongTrinhs
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateLoaiCongTrinhPageModel LoaiCongTrinh { get; set; }

        private readonly ILoaiCongTrinhAppService _loaiCongTrinhAppService;

        private readonly IAuthorizationService _authorization;

        public EditModalModel(ILoaiCongTrinhAppService loaiCongTrinhAppService, IAuthorizationService authorization)
        {
            _loaiCongTrinhAppService = loaiCongTrinhAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task OnGetAsync()
        {
            var loaiCongTrinhDto = await _loaiCongTrinhAppService.GetAsync(Id);
            LoaiCongTrinh = ObjectMapper.Map<LoaiCongTrinhDto, CreateUpdateLoaiCongTrinhPageModel>(loaiCongTrinhDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.LoaiCongTrinhPermission.Update))
            {
                await _loaiCongTrinhAppService.UpdateAsync(Id, LoaiCongTrinh);
                return Redirect("/");
            }

            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }

      
    }
}