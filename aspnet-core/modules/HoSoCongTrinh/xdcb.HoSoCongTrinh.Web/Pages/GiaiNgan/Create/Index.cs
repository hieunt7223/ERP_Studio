using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Volo.Abp.Users;
using xdcb.Common.DanhMuc.ChuDauTus;



namespace xdcb.GiaiNgan.CreateView
{
    public class IndexModel : HoSoCongTrinh.CommonBasePageModel
    {
        [BindProperty]
        public Guid? ChuDauTuId { get; set; }
        public Guid? UserId { get; set; }
        private readonly ICurrentUser _currentUser;
        private readonly IChuDauTuAppService _chuDauTu;
        public IndexModel(IChuDauTuAppService chuDauTu, ICurrentUser currentUser)
        {
            _currentUser = currentUser;
            _chuDauTu = chuDauTu;
        }

        public async Task OnGetAsync()
        {
            UserId = _currentUser.Id;
            if (UserId != null)
            {
                ChuDauTuId = await _chuDauTu.CheckChuDauTuAsync((Guid)UserId);
            }

        }
    }
}
