using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.DonViHanhChinhDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.DonViHanhChinhs
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public DonViHanhChinhViewModel DonViHanhChinh { get; set; }

        private readonly IDonViHanhChinhAppService _donViHanhChinhAppService;
        private readonly IAuthorizationService _authorization;

        private List<DonViHanhChinhDto> thuocDonViHanhChinh;

        public List<SelectListItem> SelectThuocDonViHanhChinh { get; set; }

        public List<SelectListItem> SelectListCapDonVi { get; set; }

        public CreateModalModel(IDonViHanhChinhAppService donViHanhChinhAppService, IAuthorizationService authorization)
        {
            _donViHanhChinhAppService = donViHanhChinhAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
            SelectThuocDonViHanhChinh = new List<SelectListItem>();
            SelectThuocDonViHanhChinh.Add(new SelectListItem { Value = null, Text = "" });
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.DonViHanhChinhPermission.Create))
            {
                var donViHanhChinhDto = ObjectMapper.Map<DonViHanhChinhViewModel, CreateUpdateDonViHanhChinhDto>(DonViHanhChinh);
                await _donViHanhChinhAppService.CreateAsync(donViHanhChinhDto);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }

        public async Task OnGetAsync()
        {
            thuocDonViHanhChinh = await _donViHanhChinhAppService.GetSelectAsync()??new List<DonViHanhChinhDto>();
            
            foreach (var item in thuocDonViHanhChinh)
            {
                SelectThuocDonViHanhChinh.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.TenDonViHanhChinh.ToString() });
            }

            SelectListCapDonVi = new List<SelectListItem>();
            var capDonVis = _donViHanhChinhAppService.GetCapDonVis();
            foreach (var item in capDonVis)
            {
                SelectListCapDonVi.Add(new SelectListItem() { Value = item.Key.ToString(), Text = item.Value });
            }
        }
        public class DonViHanhChinhViewModel
        {
            [System.ComponentModel.DisplayName(ViewTextConsts.DonViHanhChinh.MaDonViHanhChinh)]
            [StringLength(10)]
            [Required(ErrorMessage = Messages.MSG_Requied)]
            public string MaDonViHanhChinh { get; set; }

            [Required(ErrorMessage = Messages.MSG_Requied)]
            [System.ComponentModel.DisplayName(ViewTextConsts.DonViHanhChinh.TenDonViHanhChinh)]
            [StringLength(255)]
            public string TenDonViHanhChinh { get; set; }

            [System.ComponentModel.DisplayName(ViewTextConsts.DonViHanhChinh.CapDonViHanhChinh)]
            [SelectItems(nameof(SelectListCapDonVi))]
            public int CapDonViHanhChinh { get; set; }

            [SelectItems(nameof(SelectThuocDonViHanhChinh))]
            [System.ComponentModel.DisplayName(ViewTextConsts.DonViHanhChinh.ThuocCapDonViHanhChinh)]
            public Guid? ParentId { get; set; }
        }
    }
}