using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;
using xdcb.FormServices.SDK;
using xdcb.Common.DanhMuc.CongTrinhDtos;
using xdcb.Common.DanhMuc.ChuDauTuDtos;
using xdcb.Common.DanhMuc.LoaiKhoanDtos;
using DevExpress.XtraGrid.Views.Grid;
using xdcb.Common.DanhMuc.NhomCongTrinhDtos;
using DevExpress.XtraSplashScreen;
using xdcb.FormServices.Component;
using Localization;
using xdcb.QuanLyVon.NhuCauKeHoachVonChiTiet.Dtos;
using xdcb.QuanLyVon.NhuCauKeHoachVon.Dtos;
using xdcb.FormQLV.NhuCauVonHangNam;

namespace xdcb.FormQLV.NhuCauVonDonVi
{
    public partial class frmNhuCauVonDonVi : GGScreen
    {
        private List<CongTrinhDto> _listCongTrinh = new List<CongTrinhDto>();
        private List<ChuDauTuDto> _listChuDauTu = new List<ChuDauTuDto>();
        private List<LoaiKhoanDto> _listLoaiKhoan = new List<LoaiKhoanDto>();
        private List<NhomCongTrinhDto> _listNhomCongTrinh = new List<NhomCongTrinhDto>();
        private List<int> _objectYear = new List<int>();
        private NhuCauKeHoachVonChiTietDto _moduleObject;
        public frmNhuCauVonDonVi()
        {
        }
        public frmNhuCauVonDonVi(string nam, string loaikehoach, string tenkehoach)
        {
            InitializeComponent();
            GetValueControl();
            cbb_TenKeHoach.EditValue = tenkehoach;
            cbb_LoaiKeHoach.EditValue = loaikehoach;
            cbe_Nam.EditValue = nam;
            cbb_ChuDauTu.EditValue = Guid.Empty.ToString();
            cbb_CongTrinh.EditValue = Guid.Empty.ToString();
            LoadBandedGridView(loaikehoach, tenkehoach);
            ReloadData();
        }

        #region LoadGiaoDien
        public void LoadBandedGridView(string LoaiKeHoach, string TenKeHoach)
        {
            grd_nhucauvondonvi.InitializeControl();

            string path = string.Empty;
            if (LoaiKeHoach == LoaiKeHoachNhuCauVon.DAU_NAM.ToString())
            {
                if (TenKeHoach == KeHoachNhuCauVon.HANG_NAM.ToString())
                {
                    path = ConfigManager.PathGridViewXML() + ModuleName.NhuCauVonDonVi + @"\" + TemplateDesignGrid.BandedGrid_NhuCauVonDauNamHangNam.ToString();
                }
                else if (TenKeHoach == KeHoachNhuCauVon.TRUNG_HAN.ToString())
                {
                    path = ConfigManager.PathGridViewXML() + ModuleName.NhuCauVonDonVi + @"\" + TemplateDesignGrid.BandedGrid_NhuCauVonDauNamTrungHan.ToString();
                }
            }
            else if (LoaiKeHoach == LoaiKeHoachNhuCauVon.DIEU_CHINH.ToString())
            {
                if (TenKeHoach == KeHoachNhuCauVon.HANG_NAM.ToString())
                {
                    path = ConfigManager.PathGridViewXML() + ModuleName.NhuCauVonDonVi + @"\" + TemplateDesignGrid.BandedGrid_NhuCauVonDieuChinhHangNam.ToString();
                }
                else if (TenKeHoach == KeHoachNhuCauVon.TRUNG_HAN.ToString())
                {
                    path = ConfigManager.PathGridViewXML() + ModuleName.NhuCauVonDonVi + @"\" + TemplateDesignGrid.BandedGrid_NhuCauVonDieuChinhTrungHan.ToString();
                }
            }
            grd_nhucauvondonvi.InitializeControlByDesign(path, CreateDesignGrid.NewBanded.ToString());
            GridView gridView = (GridView)grd_nhucauvondonvi.MainView;
            gridView.DoubleClick += GridView_DoubleClick;
        }

        private async void GridView_DoubleClick(object sender, EventArgs e)
        {
            ShowPopupUpdate();
        }

        private void ShowPopupUpdate()
        {
            GridView dgvResults = (GridView)grd_nhucauvondonvi.MainView;
            if (dgvResults.FocusedRowHandle >= 0)
            {
                _moduleObject = (NhuCauKeHoachVonChiTietDto)dgvResults.GetRow(dgvResults.FocusedRowHandle);
                if (_moduleObject != null)
                {
                    if (cbb_LoaiKeHoach.EditValue.ToString() == LoaiKeHoachNhuCauVon.DAU_NAM.ToString())
                    {
                        if (cbb_TenKeHoach.EditValue.ToString() == KeHoachNhuCauVon.HANG_NAM.ToString())
                        {
                            frmUpdateNhuCauVonHangNamDauNam gui = new frmUpdateNhuCauVonHangNamDauNam(_moduleObject);
                            gui.Text = GetTextPopup(_moduleObject);
                            gui.ShowDialog();
                        }
                        else if (cbb_TenKeHoach.EditValue.ToString() == KeHoachNhuCauVon.TRUNG_HAN.ToString())
                        {
                            frmUpdateNhuCauVonTrungHanDauNam gui = new frmUpdateNhuCauVonTrungHanDauNam(_moduleObject);
                            gui.Text = GetTextPopup(_moduleObject);
                            gui.ShowDialog();
                        }
                    }
                    else if (cbb_LoaiKeHoach.EditValue.ToString() == LoaiKeHoachNhuCauVon.DIEU_CHINH.ToString())
                    {
                        if (cbb_TenKeHoach.EditValue.ToString() == KeHoachNhuCauVon.HANG_NAM.ToString())
                        {
                            frmUpdateNhuCauVonHangNamDieuChinh gui = new frmUpdateNhuCauVonHangNamDieuChinh(_moduleObject);
                            gui.Text = GetTextPopup(_moduleObject);
                            gui.ShowDialog();
                        }
                        else if (cbb_TenKeHoach.EditValue.ToString() == KeHoachNhuCauVon.TRUNG_HAN.ToString())
                        {
                            frmUpdateNhuCauVonTrungHanDieuChinh gui = new frmUpdateNhuCauVonTrungHanDieuChinh(_moduleObject);
                            gui.Text = GetTextPopup(_moduleObject);
                            gui.ShowDialog();
                        }
                    }

                    GetObjectControl();
                    GetDataSearch();
                    SetFocusedRow();
                }
            }
        }

        public void SetFocusedRow()
        {
            if (_moduleObject != null && _moduleObject.Id != Guid.Empty)
            {
                var list = (List<NhuCauKeHoachVonChiTietDto>)grd_nhucauvondonvi.DataSource;
                if (list != null && list.Count > 0)
                {
                    GridView gridView = (GridView)grd_nhucauvondonvi.MainView;
                    gridView.BeginUpdate();
                    int id = GoToPositionOfEntity(list);
                    gridView.FocusedRowHandle = (id >= 0 ? id : 0);
                    gridView.EndUpdate();
                }
            }
        }

        private int GoToPositionOfEntity(List<NhuCauKeHoachVonChiTietDto> list)
        {
            int index = -1;
            if (_moduleObject != null && _moduleObject.Id != Guid.Empty)
            {
                if (list != null && list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        var obj = list[i];
                        if (obj.Id == _moduleObject.Id)
                        {
                            index = i;
                            break;
                        }
                    }
                }
            }

            return index;
        }
        #endregion


        #region GetValueControl
        public void GetObjectControl()
        {
            if (_listChuDauTu != null)
                _listChuDauTu.Clear();
            if (_listCongTrinh != null)
                _listCongTrinh.Clear();
            if (_listLoaiKhoan != null)
                _listLoaiKhoan.Clear();
            if (_listNhomCongTrinh != null)
                _listNhomCongTrinh.Clear();

            var apiChuDauTu = ConfigManager.GetAPIByService<IChuDauTusApi>();
            _listChuDauTu.Add(new ChuDauTuDto() { Id = Guid.Empty, Ten = "Tất cả" });
            _listChuDauTu.AddRange(apiChuDauTu.GetAll().GetAwaiter().GetResult());

            var apiCongTrinh = ConfigManager.GetAPIByService<ICongTrinhsApi>();
            _listCongTrinh.Add(new CongTrinhDto() { Id = Guid.Empty, TenCongTrinh = "Tất cả" });
            _listCongTrinh.AddRange(apiCongTrinh.GetListNotPageAsync().GetAwaiter().GetResult());

            var apiLoaiKhoan = ConfigManager.GetAPIByService<ILoaiKhoansApi>();
            _listLoaiKhoan = apiLoaiKhoan.GetAll().GetAwaiter().GetResult();

            var apiNhomCongTrinh = ConfigManager.GetAPIByService<INhomCongTrinhsApi>();
            _listNhomCongTrinh = apiNhomCongTrinh.GetAll().GetAwaiter().GetResult();

            //Nam
            var api = ConfigManager.GetAPIByService<INhuCauKeHoachVonsApi>();
            _objectYear = api.GetObjectYear().GetAwaiter().GetResult();
        }

        public void GetValueControl()
        {
            GetObjectControl();
            // Tên kế hoạch
            cbb_TenKeHoach.ColumnsCaption = new string[1] { ComboBaseControl.Value.GetDescription().ToString() };
            cbb_TenKeHoach.FieldsName = new string[1] { ComboBaseControl.Value.ToString() };
            cbb_TenKeHoach.ValueMember = ComboBaseControl.Key.ToString();
            cbb_TenKeHoach.DisplayMember = ComboBaseControl.Value.ToString();
            cbb_TenKeHoach.DataSource = typeof(KeHoachNhuCauVon).ToListModel().ToList();
            cbb_TenKeHoach.cboBase.CustomDisplayText += cbbTenKeHoach_CustomDisplayText;
            cbb_TenKeHoach.ShowData();


            cbe_Nam.Properties.Items.AddRange(_objectYear);

            //LoaiKeHoach
            cbb_LoaiKeHoach.ColumnsCaption = new string[1] { ComboBaseControl.Value.GetDescription().ToString() };
            cbb_LoaiKeHoach.FieldsName = new string[1] { ComboBaseControl.Value.ToString() };
            cbb_LoaiKeHoach.ValueMember = ComboBaseControl.Key.ToString();
            cbb_LoaiKeHoach.DisplayMember = ComboBaseControl.Value.ToString();
            cbb_LoaiKeHoach.DataSource = typeof(LoaiKeHoachNhuCauVon).ToListModel().ToList();
            cbb_LoaiKeHoach.cboBase.CustomDisplayText += cbb_LoaiKeHoach_CustomDisplayText;
            cbb_LoaiKeHoach.ShowData();

            // Công trình
            cbb_CongTrinh.ColumnsCaption = new string[2] { CongTrinhColumn.TenCongTrinh.GetDescription().ToString(), CongTrinhColumn.MaCongTrinh.GetDescription().ToString() };
            cbb_CongTrinh.FieldsName = new string[2] { CongTrinhColumn.TenCongTrinh.ToString(), CongTrinhColumn.MaCongTrinh.ToString() };
            cbb_CongTrinh.ValueMember = CongTrinhColumn.Id.ToString();
            cbb_CongTrinh.DisplayMember = CongTrinhColumn.TenCongTrinh.ToString();
            cbb_CongTrinh.DataSource = _listCongTrinh;
            cbb_CongTrinh.ShowData();

            // Chủ đầu tư
            cbb_ChuDauTu.ColumnsCaption = new string[1] { ChuDauTuColumn.Ten.GetDescription().ToString() };
            cbb_ChuDauTu.FieldsName = new string[1] { ChuDauTuColumn.Ten.ToString() };
            cbb_ChuDauTu.ValueMember = ChuDauTuColumn.Id.ToString();
            cbb_ChuDauTu.DisplayMember = ChuDauTuColumn.Ten.ToString();
            cbb_ChuDauTu.DataSource = _listChuDauTu;
            cbb_ChuDauTu.ShowData();

        }

        private void cbb_LoaiKeHoach_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.DisplayText != null)
            {
                LoaiKeHoachNhuCauVon status;
                Enum.TryParse(e.Value.ToString(), out status);
                e.DisplayText = typeof(LoaiKeHoachNhuCauVon).GetValueByKey(status);
            }
            else
            {
                e.DisplayText = null;
            }
        }

        private void cbbTenKeHoach_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.DisplayText != null)
            {
                KeHoachNhuCauVon status;
                Enum.TryParse(e.Value.ToString(), out status);
                e.DisplayText = typeof(KeHoachNhuCauVon).GetValueByKey(status);
            }
            else
            {
                e.DisplayText = null;
            }
        }

        #endregion

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Search

        public void ReloadData()
        {
            GetDataSearch();
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);

            string loaikehoach = cbb_LoaiKeHoach.EditValue == null ? string.Empty : cbb_LoaiKeHoach.EditValue.ToString();
            string tenKeHoach = cbb_TenKeHoach.EditValue == null ? string.Empty : cbb_TenKeHoach.EditValue.ToString();
            LoadBandedGridView(loaikehoach, tenKeHoach);
            GetDataSearch();

            SplashScreenManager.CloseForm();

        }
        public void GetDataSearch()
        {
            GetObjectControl();
            NhuCauKeHoachVonDto obj = SetObjectValueSearch();
            var data = new List<NhuCauKeHoachVonChiTietDto>();
            var api = ConfigManager.GetAPIByService<INhuCauKeHoachVonsApi>();
            var dataChung = api.GetSearchData(obj.DenNam, obj.LoaiKeHoach, obj.TenKeHoach, obj.ChuDauTuID).GetAwaiter().GetResult();
            if (dataChung != null && dataChung.Count > 0)
            {
                List<Guid> listGuid = dataChung.Where(x => x.TrangThai.ToLower().Trim() != TrangThaiKeHoachNhuCauVon.DANG_SOAN.ToString().ToLower().Trim()).Select(x => x.Id).Distinct().ToList();
                if (listGuid != null && listGuid.Count > 0)
                {
                    var apiChiTiet = ConfigManager.GetAPIByService<INhuCauKeHoachVonChiTietsApi>();
                    data = apiChiTiet.GetListDataByNhuCauVonIDAndCongTrinh(listGuid, obj.CongTrinhID).GetAwaiter().GetResult();
                    if (data != null && data.Count > 0)
                    {
                        if (obj.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachNhuCauVon.DAU_NAM.ToString().ToLower().Trim())
                        {
                            data = data.Where(x => x.IsSelectDieuChinh == false).ToList();
                        }
                        else if (obj.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachNhuCauVon.DIEU_CHINH.ToString().ToLower().Trim())
                        {
                            data = data.Where(x => x.IsDeleteDieuChinh == false).ToList();
                        }
                        data = data.OrderBy(x => x.OrderIndex).ToList();
                        int i = 1;
                        data.ForEach(o =>
                        {
                            o.STT = i++;
                            NhuCauKeHoachVonDto objNhuCauVon = dataChung.Where(x => x.Id == o.NhuCauKeHoachVonID).ToList().FirstOrDefault();
                            CongTrinhDto objCongTrinh = _listCongTrinh.Where(x => x.Id == o.CongTrinhID).ToList().FirstOrDefault();
                            if (objNhuCauVon != null && objCongTrinh != null && objCongTrinh.Id != Guid.Empty)
                            {
                                o.MaCongTrinh = objCongTrinh.MaCongTrinh;
                                o.MaSoDuAn = objCongTrinh.MaSoDuAn;
                                o.TenCongTrinh = objCongTrinh.TenCongTrinh;
                                o.SoQuyetDinh = objCongTrinh.SoQuyetDinhDauTu;
                                o.NgayBanHanh = objCongTrinh.NgayQuyetDinhDauTu;
                                o.LoaiCongTrinhId = objCongTrinh.LoaiCongTrinhId == null ? Guid.Empty : new Guid(objCongTrinh.LoaiCongTrinhId.ToString());
                                o.TongMucDauTu = objCongTrinh.TongMucDauTu == null ? 0 : Convert.ToDecimal(objCongTrinh.TongMucDauTu);
                                o.MucDauTuNST = objCongTrinh.NST == null ? 0 : Convert.ToDecimal(objCongTrinh.NST);
                                o.MucDauTuNSTW = objCongTrinh.NSTW == null ? 0 : Convert.ToDecimal(objCongTrinh.NSTW);
                                o.MucDauTuODA = objCongTrinh.ODA == null ? 0 : Convert.ToDecimal(objCongTrinh.ODA);
                                ChuDauTuDto objChuDauTu = _listChuDauTu.Where(x => x.Id == objNhuCauVon.ChuDauTuID).ToList().FirstOrDefault();
                                if (objChuDauTu != null && objChuDauTu.Id != Guid.Empty)
                                {
                                    o.MaSoChuong = objChuDauTu.MaSoChuong;
                                    o.TenChuDauTu = objChuDauTu.Ten;
                                    o.ChuDauTuID = objChuDauTu.Id;
                                }
                                LoaiKhoanDto objLoaiKhoan = _listLoaiKhoan.Where(x => x.Id == objCongTrinh.LoaiKhoanId).ToList().FirstOrDefault();
                                if (objLoaiKhoan != null && objLoaiKhoan.Id != Guid.Empty)
                                {
                                    o.MaLoaiKhoan = objLoaiKhoan.MaSo;
                                }
                                NhomCongTrinhDto objNhomCongTrinh = _listNhomCongTrinh.Where(x => x.Id == objCongTrinh.NhomCongTrinhId).ToList().FirstOrDefault();
                                if (objNhomCongTrinh != null && objNhomCongTrinh.Id != Guid.Empty)
                                {
                                    o.TenNhomCongTrinh = objNhomCongTrinh.TenNhomCongTrinh;
                                }
                            }
                        });
                    }
                }
            }
            grd_nhucauvondonvi.DataSource = data;
            grd_nhucauvondonvi.RefreshDataSource();

            NhuCauKeHoachVonDto objNhuCauKeHoachVon;
            if (dataChung != null && dataChung.Count > 0)
            {
                objNhuCauKeHoachVon = dataChung.FirstOrDefault();
            }
            else
            {
                objNhuCauKeHoachVon = new NhuCauKeHoachVonDto();
            }
            SetTextForm(objNhuCauKeHoachVon);
        }

        private NhuCauKeHoachVonDto SetObjectValueSearch()
        {
            NhuCauKeHoachVonDto obj = new NhuCauKeHoachVonDto();
            string namValue = cbe_Nam.EditValue == null ? string.Empty : cbe_Nam.EditValue.ToString();
            if (GGFunctions.IsNumber(namValue))
            {
                obj.DenNam = Convert.ToInt32(namValue);
            }
            else
            {
                cbe_Nam.EditValue = _objectYear[0];
                obj.DenNam = _objectYear[0];
            }
            obj.LoaiKeHoach = cbb_LoaiKeHoach.EditValue == null ? string.Empty : cbb_LoaiKeHoach.EditValue.ToString();
            obj.TenKeHoach = cbb_TenKeHoach.EditValue == null ? string.Empty : cbb_TenKeHoach.EditValue.ToString();
            if (cbb_ChuDauTu.EditValue == null)
            {
                obj.ChuDauTuID = Guid.Empty;
            }
            else if (_listChuDauTu.Where(x => x.Id.ToString() == cbb_ChuDauTu.EditValue.ToString()).ToList().Count > 0)
            {
                obj.ChuDauTuID = new Guid(cbb_ChuDauTu.EditValue.ToString());
            }
            else
            {
                obj.ChuDauTuID = Guid.Empty;
                cbb_ChuDauTu.EditValue = null;
            }

            if (cbb_CongTrinh.EditValue == null)
            {
                obj.CongTrinhID = Guid.Empty;
            }
            else if (_listCongTrinh.Where(x => x.Id.ToString() == cbb_CongTrinh.EditValue.ToString()).ToList().Count > 0)
            {
                obj.CongTrinhID = new Guid(cbb_CongTrinh.EditValue.ToString());
            }
            else
            {
                obj.CongTrinhID = Guid.Empty;
                cbb_CongTrinh.EditValue = null;
            }
            return obj;
        }

        public void SetTextForm(NhuCauKeHoachVonDto objNhuCauKeHoachVon)
        {
            string loaikehoach = cbb_LoaiKeHoach.EditValue == null ? string.Empty : cbb_LoaiKeHoach.EditValue.ToString();
            string tenKeHoach = cbb_TenKeHoach.EditValue == null ? string.Empty : cbb_TenKeHoach.EditValue.ToString();

            LoaiKeHoachTongNguon loaiKeHoachTongNguonEnum;
            Enum.TryParse(loaikehoach, out loaiKeHoachTongNguonEnum);

            KeHoachNhuCauVon keHoachNhuCauVonEnum;
            Enum.TryParse(tenKeHoach, out keHoachNhuCauVonEnum);

            string strLoai = typeof(LoaiKeHoachTongNguon).GetValueByKey(loaiKeHoachTongNguonEnum);

            string strTen = typeof(KeHoachNhuCauVon).GetValueByKey(keHoachNhuCauVonEnum);

            this.Text = string.Format(FormQLVLocalizedResources.TextGroupNhuCauVonChiTiet, strTen, strLoai, objNhuCauKeHoachVon.GiaiDoanNam);
            gcl_Chitiet.Text = string.Format(FormQLVLocalizedResources.TextGroupNhuCauVonChiTiet, strTen, strLoai, objNhuCauKeHoachVon.GiaiDoanNam);
        }

        public string GetTextPopup(NhuCauKeHoachVonChiTietDto objchiTiet)
        {
            string text = string.Empty;
            var api = ConfigManager.GetAPIByService<INhuCauKeHoachVonsApi>();
            if (objchiTiet.NhuCauKeHoachVonID != Guid.Empty)
            {
                NhuCauKeHoachVonDto obj = api.GetAsync(objchiTiet.NhuCauKeHoachVonID).GetAwaiter().GetResult();
                if (obj != null && obj.Id != Guid.Empty)
                {
                    string loaikehoach = cbb_LoaiKeHoach.EditValue == null ? string.Empty : cbb_LoaiKeHoach.EditValue.ToString();
                    LoaiKeHoachTongNguon loaiKeHoachTongNguonEnum;
                    Enum.TryParse(loaikehoach, out loaiKeHoachTongNguonEnum);

                    string strLoai = typeof(LoaiKeHoachTongNguon).GetValueByKey(loaiKeHoachTongNguonEnum);
                    text = string.Format(FormQLVLocalizedResources.TextFormNhuCauVonChiTiet, strLoai, obj.GiaiDoanNam);
                }
            }
            return text;
        }
        #endregion

        #region Chỉnh sửa
        private void btn_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowPopupUpdate();
        }
        #endregion

        #region Đóng
        private void btn_Cancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Export Excel
        private void btn_ExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NhuCauKeHoachVonDto obj = SetObjectValueSearch();
            NhuCauVonHangNamModule module = new NhuCauVonHangNamModule(obj.DenNam, obj.LoaiKeHoach, obj.TenKeHoach, obj.CongTrinhID, obj.ChuDauTuID);
            module.ExportExcel();
        }
        #endregion
    }
}