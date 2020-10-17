﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Users;
using xdcb.Common.DanhMuc.ChuDauTus;
using xdcb.QuanLyVon.NhuCauKeHoachVons;

namespace xdcb.BaoCaoNCVTrungHan.ListView
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
        private readonly INhuCauKeHoachVonAppService _nhuCauKeHoachVon;
        public IndexModel(IChuDauTuAppService chuDauTu, ICurrentUser currentUser, INhuCauKeHoachVonAppService nhuCauKeHoachVon)
        {
            _currentUser = currentUser;
            _chuDauTu = chuDauTu;
            _nhuCauKeHoachVon = nhuCauKeHoachVon;
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
                Year = await _nhuCauKeHoachVon.GetListNamByTrungHan((Guid)ChuDauTuId) ?? new List<int>();
            }
            else
            {
                Year = new List<int>();
            }


        }
    }
}