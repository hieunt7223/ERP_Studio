using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Volo.Abp.Users;
using xdcb.Common.DanhMuc.ChuDauTus;
using xdcb.QuanLyVon.NhuCauKeHoachVons;

namespace xdcb.BaoCaoNCVTrungHan.DetailView
{
    public class IndexModel : HoSoCongTrinh.CommonBasePageModel
    {
        [BindProperty]
        public Guid? ChuDauTuId { get; set; }

        [BindProperty]
        public Guid KeHoachNhuCauVonId { get; set; }

        [BindProperty]
        public string LoaiKeHoach { get; set; }
        [BindProperty]
        public string Year { get; set; }
        [BindProperty]
        public string GiaiDoanNam { get; set; }
        public Guid? UserId { get; set; }
        private readonly ICurrentUser _currentUser;
        private readonly IChuDauTuAppService _chuDauTu;
        private readonly INhuCauKeHoachVonAppService _nhuCauKeHoachVon;
        public IndexModel(IChuDauTuAppService chuDauTu, ICurrentUser currentUser, INhuCauKeHoachVonAppService nhuCauKeHoachVon)
        {
            _currentUser = currentUser;
            _chuDauTu = chuDauTu;
            _nhuCauKeHoachVon = nhuCauKeHoachVon;
        }

        public async Task OnGetAsync(Guid keHoachNhuCauVonId,string loaiKeHoach,string giaiDoanNam)
        {
            KeHoachNhuCauVonId = keHoachNhuCauVonId;
            UserId = _currentUser.Id;
            if (UserId != null)
            {
                ChuDauTuId = await _chuDauTu.CheckChuDauTuAsync((Guid)UserId);
                if (loaiKeHoach!= "DAU_NAM")
                {
                    var item = await _nhuCauKeHoachVon.GetDataTrungHanDauNam(Convert.ToInt32(giaiDoanNam), (Guid)ChuDauTuId);
                    Year = item.GiaiDoanNam ?? "";
                }
                else
                {
                    Year =  "";
                }
                
            }
            LoaiKeHoach = loaiKeHoach;
            GiaiDoanNam = giaiDoanNam;
        }
    }
}
