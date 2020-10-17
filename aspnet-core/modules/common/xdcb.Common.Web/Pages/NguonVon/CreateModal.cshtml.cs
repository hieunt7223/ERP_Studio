using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.NguonVonDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.NguonVons
{
    public class CreateModalModel : AbpPageModel
    {
        private readonly INguonVonAppService _nguonVonAppService;
        private readonly IAuthorizationService _authorization;

        [BindProperty]
        public NguonVonViewModel NguonVon { get; set; }

        private List<NguonVonDto> nguonVonMes;

        public List<SelectListItem> SelectNguonVonMeList { get; set; }

        public CreateModalModel(INguonVonAppService nguonVonAppService, IAuthorizationService authorization)
        {
            _nguonVonAppService = nguonVonAppService;
            SelectNguonVonMeList = new List<SelectListItem>();
            SelectNguonVonMeList.Add(new SelectListItem { Value = "", Text = ViewTextConsts.PlaceholderNguonVon.MaNguonVonMe, Selected = true, Disabled = true });
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.NguonVonPermission.Create))
            {
                var nguonVonDto = ObjectMapper.Map<NguonVonViewModel, CreateUpdateNguonVonDto>(NguonVon);
                await _nguonVonAppService.CreateAsync(nguonVonDto);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }

        public async Task OnGetAsync()
        {
            nguonVonMes = await _nguonVonAppService.GetListNguonVonMeAsync() ?? new List<NguonVonDto>();
            foreach (var item in nguonVonMes)
            {
                SelectNguonVonMeList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.MaNguonVon.ToString() });
            }
        }

        public class NguonVonViewModel
        {
            [SelectItems(nameof(SelectNguonVonMeList))]
            [DisplayName(ViewTextConsts.NguonVon.MaNguonVonMe)]
            public Guid? ParentId { get; set; }

            [StringLength(16)]
            [DisplayName(ViewTextConsts.NguonVon.MaNguonVon)]
            [Placeholder(ViewTextConsts.PlaceholderNguonVon.MaNguonVon)]
            public string MaNguonVon { get; set; }

            [Required(ErrorMessage = Messages.MSG_Requied)]
            [StringLength(255)]
            [DisplayName(ViewTextConsts.NguonVon.TenNguonVon)]
            [Placeholder(ViewTextConsts.PlaceholderNguonVon.TenNguonVon)]
            public string TenNguonVon { get; set; }

            [StringLength(20)]
            [DisplayName(ViewTextConsts.NguonVon.ThuTuHienThi)]
            [Placeholder(ViewTextConsts.PlaceholderNguonVon.ThuTuHienThi)]
            public string ThuTuHienThi { get; set; }
        }
    }
}