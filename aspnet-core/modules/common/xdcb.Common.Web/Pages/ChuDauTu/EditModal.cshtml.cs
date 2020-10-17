using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Authorization;
using Volo.Abp.Identity;
using xdcb.Common.DanhMuc.ChuDauTuDtos;
using xdcb.Common.Permissions;

namespace xdcb.Common.DanhMuc.ChuDauTus
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateChuDauTuPageModel ChuDauTu { get; set; }

        [BindProperty]
        [DisplayName(ViewTextConsts.ChuDauTu.Users)]
        public List<Guid> NguoiDungs { get; set; }

        public List<SelectListItem> SelectList { get; set; }

        List<IdentityUser> userList;

        private readonly IChuDauTuAppService _chuDauTuAppService;
        private readonly IAuthorizationService _authorization;
        private readonly IIdentityUserRepository _identityUserRepository;

        public EditModalModel(IChuDauTuAppService chuDauTuAppService, IAuthorizationService authorization, IIdentityUserRepository identityUserRepository)
        {
            _chuDauTuAppService = chuDauTuAppService;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
            _identityUserRepository = identityUserRepository;
            SelectList = new List<SelectListItem>();
            userList = new List<IdentityUser>();
            NguoiDungs = new List<Guid>();
        }

        public async Task OnGetAsync()
        {
            var ChuDauTuDto = await _chuDauTuAppService.GetAsync(Id);
            ChuDauTu = ObjectMapper.Map<ChuDauTuDto, CreateUpdateChuDauTuPageModel>(ChuDauTuDto);
            if (ChuDauTu.NguoiDung != null)
            {
                List<NguoiDungDto> nguoiDungDtos = JsonConvert.DeserializeObject<List<NguoiDungDto>>(ChuDauTu.NguoiDung);
                if (nguoiDungDtos != null)
                {
                    foreach (var item in nguoiDungDtos)
                    {
                        NguoiDungs.Add(item.Id);
                    }
                }
            }
           
            
            userList = _identityUserRepository.GetListAsync().Result;
            if (userList != null)
            {

                foreach (var item in userList)
                {
                    SelectList.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.UserName.ToString() });
                }
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _authorization.IsGrantedAsync(xdcbCommonPermissions.MaChuongPermission.Update))
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
                await _chuDauTuAppService.UpdateAsync(Id, ChuDauTu);
                return NoContent();
            }
            throw new AbpAuthorizationException(Messages.MSG_NotPermission);
        }
    }
}