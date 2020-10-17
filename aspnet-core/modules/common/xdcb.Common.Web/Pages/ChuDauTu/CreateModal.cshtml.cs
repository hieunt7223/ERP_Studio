using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Users;
using xdcb.Common.Permissions;


namespace xdcb.Common.DanhMuc.ChuDauTus
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateUpdateChuDauTuPageModel ChuDauTu { get; set; }

        [BindProperty]
        [DisplayName(ViewTextConsts.ChuDauTu.Users)]
        public List<Guid> NguoiDungs { get; set; }

        private readonly IChuDauTuAppService _chuDauTuAppService;
        private readonly IAuthorizationService _authorization;
        private readonly IIdentityUserRepository _identityUserRepository;

        public List<SelectListItem> SelectList { get; set; }

        List<Volo.Abp.Identity.IdentityUser> userList;

        public CreateModalModel(IChuDauTuAppService chuDauTuAppService, IAuthorizationService authorization,
            IIdentityUserRepository identityUserRepository
)
        {
            _chuDauTuAppService = chuDauTuAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
            _identityUserRepository = identityUserRepository;
            SelectList = new List<SelectListItem>();
            userList = new List<Volo.Abp.Identity.IdentityUser>();
        }
        public async Task OnGetAsync()
        {
            userList = _identityUserRepository.GetListAsync().Result;
            foreach (var item in userList)
            {
                SelectList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.UserName.ToString() });
            }

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.MaChuongPermission.Create))
            {
                userList = _identityUserRepository.GetListAsync().Result;
                List<NguoiDungDto> nguoiDungDtos = new List<NguoiDungDto>();
                foreach (var id in NguoiDungs)
                {
                    var item = userList.FirstOrDefault(x => x.Id == id);
                    if (item != null)
                    {
                        nguoiDungDtos.Add(new NguoiDungDto
                        {
                            Id = item.Id,
                            UserName = item.UserName,

                            Name = item.Name,

                            Surname = item.Surname,

                            Email = item.Email,

                            EmailConfirmed = item.EmailConfirmed,

                            PhoneNumber = item.PhoneNumber,

                            PhoneNumberConfirmed = item.PhoneNumberConfirmed
                        });
                    }
                }
                string nguoiDung = JsonConvert.SerializeObject(nguoiDungDtos);
                ChuDauTu.NguoiDung = nguoiDung;
                await _chuDauTuAppService.CreateAsync(ChuDauTu);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }


    }

}

