using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using xdcb.Common.DanhMuc.DonViBanHanhDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.DonViBanHanhs
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateUpdateDonViBanHanhDto DonViBanHanh { get; set; }

        private readonly IDonViBanHanhAppService _donViBanHanhAppService;

        private readonly IAuthorizationService _authorization;

        public CreateModalModel(IDonViBanHanhAppService donViBanHanhAppService, IAuthorizationService authorization)
        {
            _donViBanHanhAppService = donViBanHanhAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.LoaiCongTrinhPermission.Create))
            {
                await _donViBanHanhAppService.CreateAsync(DonViBanHanh);
                return Redirect("/");
            }

            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }

    }
}