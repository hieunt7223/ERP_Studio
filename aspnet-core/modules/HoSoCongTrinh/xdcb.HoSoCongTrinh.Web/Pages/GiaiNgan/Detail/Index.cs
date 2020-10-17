using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Threading.Tasks;
using Volo.Abp.Users;
using xdcb.Common.DanhMuc.ChuDauTus;
using xdcb.QuanLyVon.GiaiNgans;

namespace xdcb.GiaiNgan.DetailView
{
    public class IndexModel : HoSoCongTrinh.CommonBasePageModel
    {
        [BindProperty]
        public Guid? ChuDauTuId { get; set; }

        [BindProperty]
        public int Nam { get; set; }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string QuyThang { get; set; }

        [BindProperty]
        public Guid GiaiNganId { get; set; }

        public Guid? UserId { get; set; }
        private readonly ICurrentUser _currentUser;
        private readonly IChuDauTuAppService _chuDauTu;
        private readonly IGiaiNganAppService _giaiNgan;
        public IndexModel(IChuDauTuAppService chuDauTu, ICurrentUser currentUser, IGiaiNganAppService giaiNgan)
        {
            _currentUser = currentUser;
            _chuDauTu = chuDauTu;
            _giaiNgan = giaiNgan;
        }

        public async Task OnGetAsync(Guid giaiNganId)
        {
            GiaiNganId = giaiNganId;
            UserId = _currentUser.Id;
            if (UserId != null)
            {
                ChuDauTuId = await _chuDauTu.CheckChuDauTuAsync((Guid)UserId);
            }
            var item = _giaiNgan.GetAsync(giaiNganId).Result;
            var quyThang = "";
            switch (item.TenKeHoach)
            {
                case "THANG":
                    {
                        quyThang += "tháng " + item.QuyThang;
                        break;
                    }
                case "QUY":
                    {
                        switch(item.QuyThang){
                            case 1:
                                {
                                    quyThang += "quý I";
                                    break;
                                }
                            case 2:
                                {
                                    quyThang += "quý II";
                                    break;
                                }
                            case 3:
                                {
                                    quyThang += "quý III";
                                    break;
                                }
                            case 4:
                                {
                                    quyThang += "quý IV";
                                    break;
                                }
                        }
                        
                        break;
                    }
            }
            Nam = item.Nam;
            if (item.IsKeHoachKeoDai)
            {
                QuyThang = quyThang+"/";
                Title = "Giải ngân các dự án kế hoạch năm " + Nam+" và kế hoạch năm "+(Nam-1) +" đến hết " + quyThang + " năm "+Nam;

            }
            else
            {
                QuyThang = "";
                Title = "Giải ngân các dự án kế hoạch năm " + Nam;
            }
        }
    }
}
