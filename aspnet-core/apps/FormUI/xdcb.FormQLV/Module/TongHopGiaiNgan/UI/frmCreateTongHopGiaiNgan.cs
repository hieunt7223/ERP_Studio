using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Features;
using xdcb.Common.DanhMuc.ChuDauTuDtos;
using xdcb.Common.DanhMuc.CongTrinhDtos;
using xdcb.Common.DanhMuc.LoaiCongTrinhDtos;
using xdcb.Common.DanhMuc.LoaiKhoanDtos;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.SDK;
using xdcb.FormServices.Shared;
using xdcb.QuanLyVon.GiaiNgan.Dtos;
using xdcb.QuanLyVon.GiaiNganChiTiet.Dtos;

namespace xdcb.FormQLV.TongHopGiaiNgan
{
    public partial class frmCreateTongHopGiaiNgan : GGScreenDetail
    {
        #region Property
        private GiaiNganDto _mainObject;
        private List<GiaiNganChiTietDto> _moduleObject = new List<GiaiNganChiTietDto>();

        private List<CongTrinhDto> _listCongTrinh = new List<CongTrinhDto>();
        private List<ChuDauTuDto> _listChuDauTu = new List<ChuDauTuDto>();
        private List<LoaiKhoanDto> _listLoaiKhoan = new List<LoaiKhoanDto>();
        private List<int> _objectYear = new List<int>();
        private List<int> _objectQuy = new List<int>();
        private List<int> _objectThang = new List<int>();
        private List<LoaiCongTrinhDto> _listLoaiCongTrinh = new List<LoaiCongTrinhDto>();
        #endregion Property

        public frmCreateTongHopGiaiNgan(GiaiNganDto giaiNganDto, BaseModule module)
        {
            InitializeComponent();
            GetValueControl();
            this.Module = module;
            _mainObject = giaiNganDto;
            SetDefaultValueSearch();
            InitControl();
            ReloadData();
        }

        #region InitControl
        private void SetDefaultValueSearch()
        {
            cbe_Nam.EditValue = _mainObject.Nam;
            cbe_QuyThang.EditValue = _mainObject.QuyThang;
            cbb_TenKeHoach.EditValue = _mainObject.TenKeHoach;
            cbb_LoaiKeHoach.EditValue = _mainObject.LoaiKeHoach;
            SetVisibleQuyThang();
        }
        public void GetValueControl()
        {
            GetObjectControl();
            //Năm
            cbe_Nam.Properties.Items.AddRange(_objectYear);

            //LoaiKeHoach
            cbb_LoaiKeHoach.ColumnsCaption = new string[1] { ComboBaseControl.Value.GetDescription().ToString() };
            cbb_LoaiKeHoach.FieldsName = new string[1] { ComboBaseControl.Value.ToString() };
            cbb_LoaiKeHoach.ValueMember = ComboBaseControl.Key.ToString();
            cbb_LoaiKeHoach.DisplayMember = ComboBaseControl.Value.ToString();
            cbb_LoaiKeHoach.DataSource = typeof(LoaiKeHoachGiaiNgan).ToListModel().ToList();
            cbb_LoaiKeHoach.cboBase.CustomDisplayText += cbb_LoaiKeHoach_CustomDisplayText;
            cbb_LoaiKeHoach.ShowData();

            //TenKeHoach
            cbb_TenKeHoach.ColumnsCaption = new string[1] { ComboBaseControl.Value.GetDescription().ToString() };
            cbb_TenKeHoach.FieldsName = new string[1] { ComboBaseControl.Value.ToString() };
            cbb_TenKeHoach.ValueMember = ComboBaseControl.Key.ToString();
            cbb_TenKeHoach.DisplayMember = ComboBaseControl.Value.ToString();
            cbb_TenKeHoach.DataSource = typeof(TenKeHoachGiaiNgan).ToListModel().ToList();
            cbb_TenKeHoach.cboBase.CustomDisplayText += cbb_TenKeHoach_CustomDisplayText;
            cbb_TenKeHoach.ShowData();

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
                LoaiKeHoachGiaiNgan status;
                Enum.TryParse(e.Value.ToString(), out status);
                e.DisplayText = typeof(LoaiKeHoachGiaiNgan).GetValueByKey(status);
            }
            else
            {
                e.DisplayText = null;
            }
        }

        private void cbb_TenKeHoach_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.DisplayText != null)
            {
                TenKeHoachGiaiNgan status;
                Enum.TryParse(e.Value.ToString(), out status);
                e.DisplayText = typeof(TenKeHoachGiaiNgan).GetValueByKey(status);
            }
            else
            {
                e.DisplayText = null;
            }
        }
        public void GetObjectControl()
        {
            if (_listChuDauTu != null)
                _listChuDauTu.Clear();
            if (_listCongTrinh != null)
                _listCongTrinh.Clear();
            if (_listLoaiKhoan != null)
                _listLoaiKhoan.Clear();

            var apiChuDauTu = ConfigManager.GetAPIByService<IChuDauTusApi>();
            _listChuDauTu.Add(new ChuDauTuDto() { Id = Guid.Empty, Ten = "Tất cả" });
            _listChuDauTu.AddRange(apiChuDauTu.GetAll().GetAwaiter().GetResult());

            var apiCongTrinh = ConfigManager.GetAPIByService<ICongTrinhsApi>();
            _listCongTrinh.Add(new CongTrinhDto() { Id = Guid.Empty, TenCongTrinh = "Tất cả" });
            _listCongTrinh.AddRange(apiCongTrinh.GetListNotPageAsync().GetAwaiter().GetResult());

            var apiLoaiKhoan = ConfigManager.GetAPIByService<ILoaiKhoansApi>();
            _listLoaiKhoan = apiLoaiKhoan.GetAll().GetAwaiter().GetResult();

            var apiLoaiCongTrinh = ConfigManager.GetAPIByService<ILoaiCongTrinhsApi>();
            _listLoaiCongTrinh = apiLoaiCongTrinh.GetAll().GetAwaiter().GetResult();

            //Nam
            var api = ConfigManager.GetAPIByService<IGiaiNgansApi>();
            _objectYear = api.GetObjectYear().GetAwaiter().GetResult();

            //Quy
            _objectQuy.Clear();
            for (int i = 1; i <= 4; i++)
            {
                _objectQuy.Add(i);
            }

            //Thang
            _objectThang.Clear();
            for (int i = 1; i <= 12; i++)
            {
                _objectThang.Add(i);
            }
        }
        public void InitControl()
        {
            RefreshLayoutTreeList();
        }

        private void RefreshLayoutTreeList()
        {
            RefreshLayoutTreeListNST();
            RefreshLayoutTreeListNSTW();
            RefreshLayoutTreeListODA();
        }

        private void RefreshLayoutTreeListNST()
        {
            string path = ConfigManager.PathTreeListXML() + ModuleName.TongHopGiaiNgan + @"\" + TemplateDesignTreeList.TreeList_GiaiNgan_NST.ToString();
            tree_NST.Bands.Clear();
            tree_NST.Columns.Clear();
            tree_NST.InitializeControlByDesign(path, null);

            TreeListBand bandLuyKeVon = tree_NST.Bands["Band_LuyKeVon"];
            bandLuyKeVon.Caption += _mainObject.Nam.ToString();

            TreeListBand luyKeGiaiNgan = tree_NST.Bands["Band_LuyKeGiaiNgan"];
            luyKeGiaiNgan.Caption += _mainObject.Nam.ToString();

            TreeListBand keHoachVonKeoDai = tree_NST.Bands["Band_KeHoachVonKeoDai"];
            keHoachVonKeoDai.Caption = string.Format("Kế hoạch vốn ngân sách tỉnh năm {0} cho phép kéo dài (nếu có)", (_mainObject.Nam - 1).ToString());

            TreeListBand keHoachVon = tree_NST.Bands["Band_KeHoachVon"];
            keHoachVon.Caption += _mainObject.Nam.ToString();

            TreeListBand khoiLuong = tree_NST.Bands["Band_KhoiLuong"];
            if (khoiLuong != null)
            {
                khoiLuong.Caption = string.Format("Khối lượng thực hiện kế từ khởi công đến hết {0} năm {1}", "31/12", _mainObject.Nam.ToString());
            }

            TreeListBand giaiNgan = tree_NST.Bands["Band_GiaiNgan"];
            if (giaiNgan != null)
            {
                giaiNgan.Caption = string.Format("Giải ngân KH năm {0} (tính từ 01/01 năm {1}) và KH năm {2} kéo dài (nếu có) đến hết 31/01 năm {3}", _mainObject.Nam.ToString(), _mainObject.Nam.ToString(), (_mainObject.Nam - 1).ToString(), (_mainObject.Nam + 1).ToString());

                TreeListBand giaiNganNam = giaiNgan.Bands["Band_GiaiNganNam"];
                giaiNganNam.Caption += _mainObject.Nam.ToString();

                TreeListBand giaiNganKeoDai = giaiNgan.Bands["Band_GiaiNganKeoDai"];
                giaiNganKeoDai.Caption = string.Format("Kế hoạch năm {0} kéo dài", (_mainObject.Nam - 1).ToString());
            }
        }
        private void RefreshLayoutTreeListNSTW()
        {
            string path = ConfigManager.PathTreeListXML() + ModuleName.TongHopGiaiNgan + @"\" + TemplateDesignTreeList.TreeList_GiaiNgan_NSTW.ToString();
            tree_NSTW.Bands.Clear();
            tree_NSTW.Columns.Clear();
            tree_NSTW.InitializeControlByDesign(path, null);

            TreeListBand bandLuyKeVon = tree_NSTW.Bands["Band_LuyKeVon"];
            bandLuyKeVon.Caption += _mainObject.Nam.ToString();

            TreeListBand luyKeGiaiNgan = tree_NSTW.Bands["Band_LuyKeGiaiNgan"];
            luyKeGiaiNgan.Caption += _mainObject.Nam.ToString();

            TreeListBand keHoachVonKeoDai = tree_NSTW.Bands["Band_KeHoachVonKeoDai"];
            keHoachVonKeoDai.Caption = string.Format("Kế hoạch vốn ngân sách trung ương năm {0} cho phép kéo dài (nếu có)", (_mainObject.Nam - 1).ToString());

            TreeListBand keHoachVon = tree_NSTW.Bands["Band_KeHoachVon"];
            keHoachVon.Caption += _mainObject.Nam.ToString();

            TreeListBand khoiLuong = tree_NSTW.Bands["Band_KhoiLuong"];
            if (khoiLuong != null)
            {
                khoiLuong.Caption = string.Format("Khối lượng thực hiện kế từ khởi công đến hết {0} năm {1}", "31/12", _mainObject.Nam.ToString());
            }

            TreeListBand giaiNgan = tree_NSTW.Bands["Band_GiaiNgan"];
            if (giaiNgan != null)
            {
                giaiNgan.Caption = string.Format("Giải ngân KH năm {0} (tính từ 01/01 năm {1}) và KH năm {2} kéo dài (nếu có) đến hết 31/01 năm {3}", _mainObject.Nam.ToString(), _mainObject.Nam.ToString(), (_mainObject.Nam - 1).ToString(), (_mainObject.Nam + 1).ToString());

                TreeListBand giaiNganNam = giaiNgan.Bands["Band_GiaiNganNam"];
                giaiNganNam.Caption += _mainObject.Nam.ToString();

                TreeListBand giaiNganKeoDai = giaiNgan.Bands["Band_GiaiNganKeoDai"];
                giaiNganKeoDai.Caption = string.Format("Kế hoạch năm {0} kéo dài", (_mainObject.Nam - 1).ToString());
            }
        }
        private void RefreshLayoutTreeListODA()
        {
            string path = ConfigManager.PathTreeListXML() + ModuleName.TongHopGiaiNgan + @"\" + TemplateDesignTreeList.TreeList_GiaiNgan_ODA.ToString();
            tree_ODA.Bands.Clear();
            tree_ODA.Columns.Clear();
            tree_ODA.InitializeControlByDesign(path, null);

            TreeListBand bandLuyKeVon = tree_ODA.Bands["Band_LuyKeVon"];
            bandLuyKeVon.Caption += (_mainObject.Nam - 1).ToString();

            TreeListBand luyKeGiaiNgan = tree_ODA.Bands["Band_LuyKeGiaiNgan"];
            luyKeGiaiNgan.Caption += _mainObject.Nam.ToString();

            TreeListBand keHoachVonKeoDai = tree_ODA.Bands["Band_KeHoachVonKeoDai"];
            keHoachVonKeoDai.Caption = string.Format("Kế hoạch vốn đối ứng năm {0} cho phép kéo dài (nếu có)", (_mainObject.Nam - 1).ToString());

            TreeListBand keHoachVon = tree_ODA.Bands["Band_KeHoachVon"];
            keHoachVon.Caption += _mainObject.Nam.ToString();

            TreeListBand khoiLuong = tree_ODA.Bands["Band_KhoiLuong"];
            if (khoiLuong != null)
            {
                khoiLuong.Caption = string.Format("Khối lượng thực hiện kế từ khởi công đến hết {0} năm {1}", "31/12", _mainObject.Nam.ToString());
            }

            TreeListBand giaiNgan = tree_ODA.Bands["Band_GiaiNgan"];
            if (giaiNgan != null)
            {
                giaiNgan.Caption = string.Format("Giải ngân KH năm {0} (tính từ 01/01 năm {1}) và KH năm {2} kéo dài (nếu có) đến hết 31/01 năm {3}", _mainObject.Nam.ToString(), _mainObject.Nam.ToString(), (_mainObject.Nam - 1).ToString(), (_mainObject.Nam + 1).ToString());
            }
        }
        #endregion

        #region Search
        public void ReloadData()
        {
            GetDataSearch();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            GetDataSearch();
        }

        public void GetDataSearch()
        {
            SetObjectValueSearch();
            var apiChiTiet = ConfigManager.GetAPIByService<IGiaiNganChiTietsApi>();
            var data = apiChiTiet.GetDataDetailForTongHop(_mainObject.Nam, _mainObject.TenKeHoach, _mainObject.intQuyThang, _mainObject.IsKeHoachKeoDai, _mainObject.CongTrinhId).GetAwaiter().GetResult();
            data.ForEach(o =>
            {
                CongTrinhDto objCongTrinh = _listCongTrinh.Where(x => x.Id == o.CongTrinhId).ToList().FirstOrDefault();
                if (objCongTrinh != null && objCongTrinh.Id != Guid.Empty)
                {
                    o.ChuDauTuId = (objCongTrinh.ChuDauTuId == null ? Guid.Empty : new Guid(objCongTrinh.ChuDauTuId.ToString()));
                    ChuDauTuDto objChuDauTu = _listChuDauTu.Where(x => x.Id == o.ChuDauTuId).ToList().FirstOrDefault();
                    if (objChuDauTu != null && objChuDauTu.Id != Guid.Empty)
                    {
                        o.MaSoChuong = objChuDauTu.MaSoChuong;
                        o.TenChuDauTu = objChuDauTu.Ten;
                    }
                    LoaiKhoanDto objLoaiKhoan = _listLoaiKhoan.Where(x => x.Id == objCongTrinh.LoaiKhoanId).ToList().FirstOrDefault();
                    if (objLoaiKhoan != null && objLoaiKhoan.Id != Guid.Empty)
                    {
                        o.MaLoaiKhoan = objLoaiKhoan.MaSo;
                        o.TenLoaiKhoan = objLoaiKhoan.TenLoaiKhoan;
                        o.LoaiKhoanId = objLoaiKhoan.Id;
                    }

                    LoaiCongTrinhDto objLoaiCongTrinh = _listLoaiCongTrinh.Where(x => x.Id == objCongTrinh.LoaiCongTrinhId).ToList().FirstOrDefault();
                    if (objLoaiCongTrinh != null && objLoaiCongTrinh.Id != Guid.Empty)
                    {
                        o.MaLoaiKhoan = objLoaiKhoan.MaSo;
                        o.TenLoaiKhoan = objLoaiKhoan.TenLoaiKhoan;
                        o.LoaiKhoanId = objLoaiKhoan.Id;
                    }
                    o.MaSoDuAn = objCongTrinh.MaSoDuAn;
                    o.TenCongTrinh = objCongTrinh.TenCongTrinh;
                    o.TenDanhMuc = objCongTrinh.TenCongTrinh;
                    o.SoQuyetDinh = objCongTrinh.SoQuyetDinhDauTu;
                    o.NgayBanHanh = objCongTrinh.NgayQuyetDinhDauTu;
                    o.LoaiCongTrinhId = objCongTrinh.LoaiCongTrinhId == null ? Guid.Empty : new Guid(objCongTrinh.LoaiCongTrinhId.ToString());
                    o.MaSoDuAn = objCongTrinh.MaSoDuAn;
                    o.SoQuyetDinh = objCongTrinh.SoQuyetDinhDauTu;
                    o.TongMucDauTu = objCongTrinh.TongMucDauTu == null ? 0 : Convert.ToDecimal(objCongTrinh.TongMucDauTu);
                    o.MucDauTuNST = objCongTrinh.NST == null ? 0 : Convert.ToDecimal(objCongTrinh.NST);
                    o.MucDauTuNSTW = objCongTrinh.NSTW == null ? 0 : Convert.ToDecimal(objCongTrinh.NSTW);
                    o.MucDauTuODA = objCongTrinh.ODA == null ? 0 : Convert.ToDecimal(objCongTrinh.ODA);
                }
            });
            if (_mainObject.ChuDauTuId != Guid.Empty)
            {
                data = data.Where(x => x.ChuDauTuId == _mainObject.ChuDauTuId).ToList();
            }
            _moduleObject = data;

            RefreshDataSourceDetail();
        }

        private void SetObjectValueSearch()
        {
            string namValue = cbe_Nam.EditValue == null ? string.Empty : cbe_Nam.EditValue.ToString();
            if (GGFunctions.IsNumber(namValue))
            {
                _mainObject.Nam = Convert.ToInt32(namValue);
            }
            else
            {
                cbe_Nam.EditValue = _objectYear[0];
                _mainObject.Nam = _objectYear[0];
            }
            _mainObject.intQuyThang = null;
            string QuyThangValue = cbe_QuyThang.EditValue == null ? string.Empty : cbe_QuyThang.EditValue.ToString();
            if (GGFunctions.IsNumber(QuyThangValue))
            {
                _mainObject.intQuyThang = Convert.ToInt32(QuyThangValue);
            }
            _mainObject.LoaiKeHoach = cbb_LoaiKeHoach.EditValue == null ? string.Empty : cbb_LoaiKeHoach.EditValue.ToString();
            _mainObject.TenKeHoach = cbb_TenKeHoach.EditValue == null ? string.Empty : cbb_TenKeHoach.EditValue.ToString();

            _mainObject.IsKeHoachKeoDai = (_mainObject.LoaiKeHoach == LoaiKeHoachGiaiNgan.KEO_DAI.ToString() ? true : false);
            if (cbb_ChuDauTu.EditValue == null)
            {
                _mainObject.ChuDauTuId = Guid.Empty;
            }
            else if (_listChuDauTu.Where(x => x.Id.ToString() == cbb_ChuDauTu.EditValue.ToString()).ToList().Count > 0)
            {
                _mainObject.ChuDauTuId = new Guid(cbb_ChuDauTu.EditValue.ToString());
            }
            else
            {
                _mainObject.ChuDauTuId = Guid.Empty;
                cbb_ChuDauTu.EditValue = null;
            }

            if (cbb_CongTrinh.EditValue == null)
            {
                _mainObject.CongTrinhId = Guid.Empty;
            }
            else if (_listCongTrinh.Where(x => x.Id.ToString() == cbb_CongTrinh.EditValue.ToString()).ToList().Count > 0)
            {
                _mainObject.CongTrinhId = new Guid(cbb_CongTrinh.EditValue.ToString());
            }
            else
            {
                _mainObject.CongTrinhId = Guid.Empty;
                cbb_CongTrinh.EditValue = null;
            }
        }
        #endregion

        #region RefreshDataSource
        private void RefreshDataSourceDetail()
        {
            if (_moduleObject != null && _moduleObject.Count > 0)
                _moduleObject = _moduleObject.OrderBy(x => x.OrderIndex).ToList();

            tree_NST.DataSource = _moduleObject.Where(x => x.IsSelectNST == true).ToList();
            tree_NST.RefreshDataSource();

            tree_NSTW.DataSource = _moduleObject.Where(x => x.IsSelectNSTW == true).ToList();
            tree_NSTW.RefreshDataSource();

            List<GiaiNganChiTietDto> list = new List<GiaiNganChiTietDto>();
            list.Add(new GiaiNganChiTietDto());
            tree_ODA.DataSource = list;
            tree_ODA.RefreshDataSource();

            SetPropertyTreeList();
        }

        public void SetPropertyTreeList()
        {
            tree_NST.ExpandAll();
            TreeListColumn columnDanhMucNST = tree_NST.Columns["TenDanhMuc"];
            if (columnDanhMucNST != null)
            {
                columnDanhMucNST.Width = 400;
                RepositoryItemMemoEdit memoEdit = new RepositoryItemMemoEdit();
                columnDanhMucNST.ColumnEdit = memoEdit;
            }

            tree_NSTW.ExpandAll();
            TreeListColumn columnDanhMucNSTW = tree_NSTW.Columns["TenDanhMuc"];
            if (columnDanhMucNSTW != null)
            {
                columnDanhMucNSTW.Width = 400;
                RepositoryItemMemoEdit memoEdit = new RepositoryItemMemoEdit();
                columnDanhMucNSTW.ColumnEdit = memoEdit;
            }
        }
        #endregion

        #region Action Đóng
        private void btn_Cancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        #endregion Action Đóng

        #region Xuất excel
        private void btn_ExportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            GGFunctions.ShowMessage("Chưa có mẫu để xuất excel, Vui lòng kiểm tra lại!");
        }
        #endregion

        #region Config
        private void cbb_LoaiKeHoach_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit lke = sender as GridLookUpEdit;
            if (lke.EditValue != null && !string.IsNullOrWhiteSpace(lke.EditValue.ToString()) && lke.EditValue != lke.OldEditValue)
            {
                string loaiKehoach = lke.EditValue.ToString();
                if (loaiKehoach != LoaiKeHoachGiaiNgan.KEO_DAI.ToString() && loaiKehoach != LoaiKeHoachGiaiNgan.TRONG_NAM.ToString())
                {
                    loaiKehoach = string.Empty;
                }
                bool isKehoachKeoDai = false;
                if (loaiKehoach == LoaiKeHoachGiaiNgan.KEO_DAI.ToString())
                {
                    isKehoachKeoDai = true;
                }
                _mainObject.IsKeHoachKeoDai = isKehoachKeoDai;
                SetVisibleQuyThang();
            }
        }

        private void cbb_TenKeHoach_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit lke = sender as GridLookUpEdit;
            if (lke.EditValue != null && !string.IsNullOrWhiteSpace(lke.EditValue.ToString()) && lke.EditValue != lke.OldEditValue)
            {
                SetDataControlQuyThang(lke.EditValue.ToString());
            }
        }

        private void SetVisibleQuyThang()
        {
            if (_mainObject.IsKeHoachKeoDai == false)
            {
                cbe_QuyThang.EditValue = null;
                cbb_TenKeHoach.EditValue = TenKeHoachGiaiNgan.NAM.ToString();
                cbe_QuyThang.Enabled = false;
                cbb_TenKeHoach.Enabled = false;
            }
            else
            {
                cbe_QuyThang.Enabled = true;
                cbb_TenKeHoach.Enabled = true;
            }
        }
        private void cbe_QuyThang_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string tenKeHoach = cbb_TenKeHoach.EditValue == null ? "" : cbb_TenKeHoach.EditValue.ToString();
            SetDataControlQuyThang(tenKeHoach);
        }

        private void SetDataControlQuyThang(string tenKeHoach)
        {
            if (!string.IsNullOrWhiteSpace(tenKeHoach))
            {
                if (tenKeHoach == TenKeHoachGiaiNgan.NAM.ToString())
                {
                    cbe_QuyThang.EditValue = null;
                    cbe_QuyThang.Properties.Items.Clear();
                }
                else if (tenKeHoach == TenKeHoachGiaiNgan.QUY.ToString())
                {
                    cbe_QuyThang.Properties.Items.Clear();
                    cbe_QuyThang.Properties.Items.AddRange(_objectQuy);
                }
                else if (tenKeHoach == TenKeHoachGiaiNgan.THANG.ToString())
                {
                    cbe_QuyThang.Properties.Items.Clear();
                    cbe_QuyThang.Properties.Items.AddRange(_objectThang);
                }
            }
            else
            {
                cbe_QuyThang.EditValue = null;
                cbe_QuyThang.Properties.Items.Clear();
            }
        }
        #endregion
    }
}