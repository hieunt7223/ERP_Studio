using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Users;
using xdcb.Common.DanhMuc.ChuDauTuDtos;
using xdcb.Common.DanhMuc.ChuDauTus;
using xdcb.Common.DanhMuc.LoaiHoSos;
using xdcb.HoSoCongTrinh.Dtos;
using xdcb.HoSoCongTrinh.Services;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace xdcb.HoSoCongTrinhs.ListView
{
    public class IndexModel : HoSoCongTrinh.CommonBasePageModel

    {
        [BindProperty(SupportsGet = false)]
        public HoSoCongTrinhSearchInput SearchInputs { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<HoSoCongTrinhViewModel> HoSoCongTrinhs { get; set; }

        public List<TrangThaiHoSoSelectItem> TrangThaiHoSoSelectItems { get; set; }

        public List<LoaiHoSoSelectItem> LoaiHoSoSelectItems { get; set; }

        public List<ChuDauTuDto> ChuDauTuSelectItems { get; set; }

        public List<NamThucHienCongTrinhSelectItem> NamThucHienCongTrinhSelectItems { get; set; }

        public List<LoaiHoSoOptionSelectItem> LoaiHoSoOptionSelectItems { get; set; }

        public readonly IHoSoCongTrinhAppService _hoSoCongTrinhAppService;

        public readonly ILoaiHoSoAppService _loaiHoSoAppService;

        public readonly IChuDauTuAppService _chuDauTuAppService;

        private readonly ICurrentUser _currentUser;

        public Guid? ChuDauTuId { get; set; }

        public IndexModel(IHoSoCongTrinhAppService hoSoCongTrinhAppService, ILoaiHoSoAppService loaiHoSoAppService, IChuDauTuAppService chuDauTuAppService, ICurrentUser currentUser)
        {
            _hoSoCongTrinhAppService = hoSoCongTrinhAppService ?? throw new ArgumentNullException(nameof(hoSoCongTrinhAppService));
            _loaiHoSoAppService = loaiHoSoAppService;
            LoaiHoSoSelectItems = new List<LoaiHoSoSelectItem>();
            _chuDauTuAppService = chuDauTuAppService;
            _currentUser = currentUser;
        }

        public async Task OnGetAsync()
        {
            Guid? userId = _currentUser.Id;
            if (userId != null)
            {
                ChuDauTuId = await _chuDauTuAppService.CheckChuDauTuAsync((Guid)userId);
            }
            var filter = new HoSoCongTrinhSearchInput();
            if (ChuDauTuId != null)
            {
                filter.ChuDauTuId = ChuDauTuId;
            }
            var hoSoCongTrinhs = await _hoSoCongTrinhAppService.GetHoSoCongTrinhsAsync(filter);
            HoSoCongTrinhs = hoSoCongTrinhs.Items.ToList();

            var loaiHoSos = await _loaiHoSoAppService.GetLoaiHoSoDuocApDungAsync();

            foreach (var item in loaiHoSos)
            {
                LoaiHoSoSelectItems.Add(new LoaiHoSoSelectItem
                {
                    Id = item.Id,
                    Name = item.TenLoaiHoSo
                });
            }
            
            ChuDauTuSelectItems = (List<ChuDauTuDto>)(await _chuDauTuAppService.GetChuDauTuListAsync() ?? new List<ChuDauTuDto>());
        }
    }
}