using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using Volo.Abp.Users;
using xdcb.Common.DanhMuc.ChuDauTuDtos;
using xdcb.Common.DanhMuc.ChuDauTus;
using xdcb.Common.DanhMuc.NhomCongTrinhDtos;
using xdcb.Common.DanhMuc.NhomCongTrinhs;

namespace xdcb.Common.DanhMuc.CongTrinhs
{
    public class IndexModel : xdcb.Common.Web.Pages.CommonBasePageModel
    {
        public readonly IChuDauTuAppService _chuDauTuAppService;

        public readonly INhomCongTrinhAppService _nhomCongTrinhAppService;

        private readonly ICurrentUser _currentUser;
        public Guid? ChuDauTuId { get; set; }
        public Guid? UserId { get; set; }

        public List<ChuDauTuDto> chuDauTuSelect { get; set; }
        public List<NhomCongTrinhDto> nhomCongTrinhSelect{ get; set; }

        public IndexModel(INhomCongTrinhAppService nhomCongTrinhAppService, IChuDauTuAppService chuDauTuAppService, ICurrentUser currentUser)
        {
            _nhomCongTrinhAppService = nhomCongTrinhAppService;
            _chuDauTuAppService = chuDauTuAppService;
            _currentUser = currentUser;
        }
        public async System.Threading.Tasks.Task OnGetAsync()
        {
            UserId = _currentUser.Id;
            if (UserId != null)
            {
                ChuDauTuId = await _chuDauTuAppService.CheckChuDauTuAsync((Guid)UserId);
            }

            chuDauTuSelect = (List<ChuDauTuDto>)await _chuDauTuAppService.GetChuDauTuListAsync()?? new List<ChuDauTuDto>();

            nhomCongTrinhSelect = await _nhomCongTrinhAppService.GetNhomCongTrinhsAsync();
        }
    }
}