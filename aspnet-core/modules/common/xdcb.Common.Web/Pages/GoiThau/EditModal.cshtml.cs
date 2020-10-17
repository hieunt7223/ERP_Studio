﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.GoiThauDtos;
using xdcb.Common.Permissions;
using static xdcb.Common.DanhMuc.ViewTextConsts;

namespace xdcb.Common.DanhMuc.GoiThaus
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public GoiThauEditViewModel GoiThau { get; set; }

        private readonly IGoiThauAppService _goiThauAppService;
        private readonly IAuthorizationService _authorization;

        public List<SelectListItem> SelectListThuocGoiThau { get; set; }

        public EditModalModel(IGoiThauAppService goiThauAppService, IAuthorizationService authorization)
        {
            _goiThauAppService = goiThauAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
            SelectListThuocGoiThau = new List<SelectListItem>();
        }

        public async Task OnGetAsync()
        {
            var goiThauDtos = await _goiThauAppService.GetAsync(Id);
            GoiThau = ObjectMapper.Map<GoiThauDto, GoiThauEditViewModel>(goiThauDtos);
            var goiThauChas = await _goiThauAppService.GetListParentAsync();
            SelectListThuocGoiThau.Add(new SelectListItem { Value = null, Text = "" });
            foreach (var item in goiThauChas)
            {
                SelectListThuocGoiThau.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.TenGoiThau });
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!await _authorization.IsGrantedAsync(xdcbCommonPermissions.GoiThauPermission.Update))
                throw new AbpAuthorizationException(Messages.MSG_NotPermission);
            await _goiThauAppService.UpdateAsync(Id, ObjectMapper.Map<GoiThauEditViewModel, CreateUpdateGoiThauDto>(GoiThau));
            return NoContent();
        }

        public class GoiThauEditViewModel
        {
            [System.ComponentModel.DisplayName(GoiThauTextConst.Ten)]
            [StringLength(500)]
            [Display(Prompt = GoiThauTextConst.Ten)]
            public string TenGoiThau { get; set; }

            [SelectItems(nameof(SelectListThuocGoiThau))]
            [System.ComponentModel.DisplayName(GoiThauTextConst.ChonGoiThauCha)]
            public Guid? GoiThauParentId { get; set; }
        }
    }
}