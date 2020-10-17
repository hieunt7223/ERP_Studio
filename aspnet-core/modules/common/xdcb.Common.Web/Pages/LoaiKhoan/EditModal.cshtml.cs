using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.LoaiKhoanDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.LoaiKhoans
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public LoaiKhoanViewModel LoaiKhoan { get; set; }

        private List<LoaiKhoanDto> loai;

        private readonly ILoaiKhoanAppService _loaiKhoanAppService;
        private readonly IAuthorizationService _authorization;
        public List<SelectListItem> SelectLoaiList { get; set; }

        public List<SelectListItem> SelectListLoaiKhoanType { get; set; }

        public EditModalModel(ILoaiKhoanAppService loaiKhoanAppService, IAuthorizationService authorization)
        {
            _loaiKhoanAppService = loaiKhoanAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public class LoaiKhoanViewModel
        {
            [System.ComponentModel.DisplayName(ViewTextConsts.LoaiKhoan.LoaiLoaiKhoan)]
            [SelectItems(nameof(SelectListLoaiKhoanType))]
            public int LoaiLoaiKhoan { get; set; }
            public string TenLoaiLoaiKhoan { get; set; }

            [System.ComponentModel.DisplayName(ViewTextConsts.LoaiKhoan.MaLoaiKhoan)]
            [Required(ErrorMessage = Messages.MSG_Requied)]
            public string MaSo { get; set; }

            [Required(ErrorMessage = Messages.MSG_Requied)]
            [System.ComponentModel.DisplayName(ViewTextConsts.LoaiKhoan.TenLoaiKhoan)]
            public string TenLoaiKhoan { get; set; }

            [SelectItems(nameof(SelectLoaiList))]
            [System.ComponentModel.DisplayName(ViewTextConsts.LoaiKhoan.LoaiKhoanCha)]
            public Guid? LoaiKhoanChaID { get; set; }
            
            [TextArea(Rows = 2)]
            [System.ComponentModel.DisplayName(ViewTextConsts.LoaiKhoan.GhiChu)]
            public string GhiChu { get; set; }
        }

        public async Task OnGetAsync()
        {
            loai = (List<LoaiKhoanDto>)await _loaiKhoanAppService.GetLoaiAsync() ?? new List<LoaiKhoanDto>();
            SelectLoaiList = new List<SelectListItem>();
            SelectLoaiList.Add(new SelectListItem { Value = null, Text = "" });
            foreach (var item in loai)
            {
                SelectLoaiList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.TenLoaiKhoan.ToString() });
            }
            var LoaiKhoanDto = await _loaiKhoanAppService.GetAsync(Id);
            LoaiKhoan = ObjectMapper.Map<LoaiKhoanDto, LoaiKhoanViewModel>(LoaiKhoanDto);

            SelectListLoaiKhoanType = new List<SelectListItem>();
            var loaiKhoanTypes = _loaiKhoanAppService.GetLoaiKhoanTypes();
            foreach (var item in loaiKhoanTypes)
            {
                SelectListLoaiKhoanType.Add(new SelectListItem() { Value = item.Key.ToString(), Text = item.Value });
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.LoaiKhoanPermission.Update))
            {
                var oldLoaiKhoan = ObjectMapper.Map<LoaiKhoanViewModel, CreateUpdateLoaiKhoanDto>(LoaiKhoan);
                await _loaiKhoanAppService.UpdateAsync(Id, oldLoaiKhoan);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }
    }
}