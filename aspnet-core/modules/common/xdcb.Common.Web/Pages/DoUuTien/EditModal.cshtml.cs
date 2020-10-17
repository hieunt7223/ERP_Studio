using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.DoUuTienDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.DoUuTiens
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateDoUuTienPageModel DoUuTien { get; set; }

        public List<SelectListItem> SelectListMaDoUuTien { get; set; }

        private readonly IDoUuTienAppService _doUuTienAppService;
        private readonly IAuthorizationService _authorization;

        public EditModalModel(IDoUuTienAppService doUuTienAppService, IAuthorizationService authorization)
        {
            _doUuTienAppService = doUuTienAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task OnGetAsync()
        {
            var doUuTienDto = await _doUuTienAppService.GetAsync(Id);
            DoUuTien = ObjectMapper.Map<DoUuTienDto, CreateUpdateDoUuTienPageModel>(doUuTienDto);
            SelectListMaDoUuTien = new List<SelectListItem>();
            var maDoUuTiens = _doUuTienAppService.GetMaDoUuTiens();
            foreach (var item in maDoUuTiens)
            {
                SelectListMaDoUuTien.Add(new SelectListItem() { Value = item.Key.ToString(), Text = item.Value });
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.DoUuTienPermission.Update))
            {
                await _doUuTienAppService.UpdateAsync(Id, DoUuTien);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }

        public class CreateUpdateDoUuTienPageModel : CreateUpdateDoUuTienDto
        {
            [TextArea(Rows = 2)]
            [DisplayOrder(10005)]
            public override string MoTa { get; set; }

            [SelectItems(nameof(SelectListMaDoUuTien))]
            public override int MaDoUuTien { get; set; }


        }


    }
}