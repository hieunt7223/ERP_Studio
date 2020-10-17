using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Users;
using xdcb.Common.DanhMuc.ChuDauTus;
using xdcb.QuanLyVon.GiaiNgans;

namespace xdcb.GiaiNgan.ListView
{
    public class IndexModel : HoSoCongTrinh.CommonBasePageModel
    {
        [BindProperty]
        public Guid? ChuDauTuId { get; set; }
        [BindProperty]
        public List<int> Year { get; set; }
        public Guid? UserId { get; set; }
        private readonly ICurrentUser _currentUser;
        private readonly IChuDauTuAppService _chuDauTu;
        private readonly IGiaiNganAppService _giaiNgan;
        private readonly IAuthorizationService _authorization;

        public IndexModel(IChuDauTuAppService chuDauTu, ICurrentUser currentUser,
            IGiaiNganAppService giaiNgan, IAuthorizationService authorization)
        {
            _currentUser = currentUser;
            _chuDauTu = chuDauTu;
            _giaiNgan = giaiNgan;
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
        }

        public async Task OnGetAsync()
        {
            UserId = _currentUser.Id;
            if (UserId != null)
            {
                ChuDauTuId = await _chuDauTu.CheckChuDauTuAsync((Guid)UserId);
            }
            if (ChuDauTuId != null)
            {
                Year = await _giaiNgan.GetObjectYear() ?? new List<int>();
            }
            else
            {
                Year = new List<int>();
            }
        }
    }
}
