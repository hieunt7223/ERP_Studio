using xdcb.FormServices.Shared;
using DevExpress.XtraGrid.Views.Grid;
using xdcb.FormServices.BaseForm;
using xdcb.Common.DanhMuc.CongTrinhDtos;
using xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGiaDtos;
using System.Collections.Generic;
using xdcb.Common.DanhMuc.ChuDauTuDtos;
using xdcb.Common.DanhMuc.LoaiKhoanDtos;
using xdcb.Common.DanhMuc.NhomCongTrinhDtos;
using xdcb.Common.DanhMuc.LoaiCongTrinhDtos;
using xdcb.FormServices.SDK;
using System.Windows.Forms;
using System;
using System.Linq;
using xdcb.FormServices.Component;
using DevExpress.XtraEditors;
using xdcb.Common.DanhMuc.DonViHanhChinhDtos;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraSplashScreen;

namespace xdcb.FormQLV.CongTrinh
{
    public partial class frmCongTrinhChiTiet : GGScreenDetail
    {
        #region Property
        public CongTrinhDto mainObject;

        public List<ChuongTrinhMucTieuQuocGiaDto> listCTMTQuocGia = new List<ChuongTrinhMucTieuQuocGiaDto>();
        public List<ChuDauTuDto> listChuDauTu = new List<ChuDauTuDto>();
        public List<LoaiKhoanDto> listLoaiKhoan = new List<LoaiKhoanDto>();
        public List<NhomCongTrinhDto> listNhomCongTrinh = new List<NhomCongTrinhDto>();
        public List<LoaiCongTrinhDto> listLoaiCongtrinh = new List<LoaiCongTrinhDto>();
        public List<DonViHanhChinhDto> listDonViHanhChinh = new List<DonViHanhChinhDto>();
        #endregion
        public frmCongTrinhChiTiet(CongTrinhDto objCongTrinh)
        {
            InitializeComponent();
            mainObject = objCongTrinh;
            SetValueNamByNgay();
            InitControl();
            GetValueControl();
            InitBindEntityToControl(this.Controls, mainObject);

        }

        #region GetValueControl
        public void GetObjectControl()
        {
            if (listChuDauTu != null)
                listChuDauTu.Clear();
            if (listCTMTQuocGia != null)
                listCTMTQuocGia.Clear();
            if (listLoaiKhoan != null)
                listLoaiKhoan.Clear();
            if (listNhomCongTrinh != null)
                listNhomCongTrinh.Clear();
            if (listLoaiCongtrinh != null)
                listLoaiCongtrinh.Clear();
            if (listDonViHanhChinh != null)
                listDonViHanhChinh.Clear();

            var apiChuDauTu = ConfigManager.GetAPIByService<IChuDauTusApi>();
            listChuDauTu.AddRange(apiChuDauTu.GetAll().GetAwaiter().GetResult());

            var apiLoaiKhoan = ConfigManager.GetAPIByService<ILoaiKhoansApi>();
            listLoaiKhoan.Add(new LoaiKhoanDto());
            listLoaiKhoan.AddRange(apiLoaiKhoan.GetAll().GetAwaiter().GetResult());

            var apiNhomCongTrinh = ConfigManager.GetAPIByService<INhomCongTrinhsApi>();
            listNhomCongTrinh.Add(new NhomCongTrinhDto());
            listNhomCongTrinh.AddRange(apiNhomCongTrinh.GetAll().GetAwaiter().GetResult());

            var apiCTMTGG = ConfigManager.GetAPIByService<IChuongTrinhMucTieuQuocGiasApi>();
            listCTMTQuocGia.Add(new ChuongTrinhMucTieuQuocGiaDto());
            listCTMTQuocGia.AddRange(apiCTMTGG.GetAll().GetAwaiter().GetResult());

            var apiLoaiCongTrinh = ConfigManager.GetAPIByService<ILoaiCongTrinhsApi>();
            listLoaiCongtrinh.Add(new LoaiCongTrinhDto());
            listLoaiCongtrinh.AddRange(apiLoaiCongTrinh.GetAll().GetAwaiter().GetResult());

            var apiDonViHanhChinh = ConfigManager.GetAPIByService<IDonViHanhChinhsApi>();
            listDonViHanhChinh.Add(new DonViHanhChinhDto());
            listDonViHanhChinh.AddRange(apiDonViHanhChinh.GetAll().GetAwaiter().GetResult());
        }

        public void GetValueControl()
        {
            GetObjectControl();

            cbb_ChuDauTu.ColumnsCaption = new string[2] { ChuDauTuColumn.Ten.GetDescription().ToString(), ChuDauTuColumn.MaSoChuong.GetDescription().ToString() };
            cbb_ChuDauTu.FieldsName = new string[2] { ChuDauTuColumn.Ten.ToString(), ChuDauTuColumn.MaSoChuong.ToString() };
            cbb_ChuDauTu.ValueMember = ChuDauTuColumn.Id.ToString();
            cbb_ChuDauTu.DisplayMember = ChuDauTuColumn.Ten.ToString();
            cbb_ChuDauTu.DataSource = listChuDauTu;
            cbb_ChuDauTu.EditValueChanged += Cbb_ChuDauTu_EditValueChanged;
            cbb_ChuDauTu.ShowData();

            cbb_NhomCongTrinh.ColumnsCaption = new string[2] { NhomCongTrinhColumn.TenNhomCongTrinh.GetDescription().ToString(), NhomCongTrinhColumn.MaNhomCongTrinh.GetDescription().ToString() };
            cbb_NhomCongTrinh.FieldsName = new string[2] { NhomCongTrinhColumn.TenNhomCongTrinh.ToString(), NhomCongTrinhColumn.MaNhomCongTrinh.ToString() };
            cbb_NhomCongTrinh.ValueMember = NhomCongTrinhColumn.Id.ToString();
            cbb_NhomCongTrinh.DisplayMember = NhomCongTrinhColumn.TenNhomCongTrinh.ToString();
            cbb_NhomCongTrinh.DataSource = listNhomCongTrinh;
            cbb_NhomCongTrinh.ShowData();

            cbb_LoaiKhoan.ColumnsCaption = new string[2] { LoaiKhoanColumn.TenLoaiKhoan.GetDescription().ToString(), LoaiKhoanColumn.MaSo.GetDescription().ToString() };
            cbb_LoaiKhoan.FieldsName = new string[2] { LoaiKhoanColumn.TenLoaiKhoan.ToString(), LoaiKhoanColumn.MaSo.ToString() };
            cbb_LoaiKhoan.ValueMember = LoaiKhoanColumn.Id.ToString();
            cbb_LoaiKhoan.DisplayMember = LoaiKhoanColumn.TenLoaiKhoan.ToString();
            cbb_LoaiKhoan.DataSource = listLoaiKhoan;
            cbb_LoaiKhoan.ShowData();

            cbb_CTMTQG.ColumnsCaption = new string[2] { ChuongTrinhMucTieuQuocGiaColumn.TenChuongTrinhMucTieuQuocGia.GetDescription().ToString(), ChuongTrinhMucTieuQuocGiaColumn.MaChuongTrinhMucTieuQuocGia.GetDescription().ToString() };
            cbb_CTMTQG.FieldsName = new string[2] { ChuongTrinhMucTieuQuocGiaColumn.TenChuongTrinhMucTieuQuocGia.ToString(), ChuongTrinhMucTieuQuocGiaColumn.MaChuongTrinhMucTieuQuocGia.ToString() };
            cbb_CTMTQG.ValueMember = ChuongTrinhMucTieuQuocGiaColumn.Id.ToString();
            cbb_CTMTQG.DisplayMember = ChuongTrinhMucTieuQuocGiaColumn.TenChuongTrinhMucTieuQuocGia.ToString();
            cbb_CTMTQG.DataSource = listCTMTQuocGia;
            cbb_CTMTQG.ShowData();

            cbb_LoaiCongTrinh.ColumnsCaption = new string[2] { LoaiCongTrinhColumn.TenLoaiCongTrinh.GetDescription().ToString(), LoaiCongTrinhColumn.MaLoaiCongTrinh.GetDescription().ToString() };
            cbb_LoaiCongTrinh.FieldsName = new string[2] { LoaiCongTrinhColumn.TenLoaiCongTrinh.ToString(), LoaiCongTrinhColumn.MaLoaiCongTrinh.ToString() };
            cbb_LoaiCongTrinh.ValueMember = LoaiCongTrinhColumn.Id.ToString();
            cbb_LoaiCongTrinh.DisplayMember = LoaiCongTrinhColumn.TenLoaiCongTrinh.ToString();
            cbb_LoaiCongTrinh.DataSource = listLoaiCongtrinh;
            cbb_LoaiCongTrinh.ShowData();

            //TuNam
            cbe_TuNam.Properties.Items.AddRange(GGFunctions.GetValueNam());
            //DenNam
            cbe_DenNam.Properties.Items.AddRange(GGFunctions.GetValueNam());
        }

        private void Cbb_ChuDauTu_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit lke = sender as GridLookUpEdit;
            if (lke.EditValue != null && !string.IsNullOrWhiteSpace(lke.EditValue.ToString()) && lke.EditValue != lke.OldEditValue)
            {
                Guid idcdt = new Guid(lke.EditValue.ToString());
                ChuDauTuDto obj = listChuDauTu.Where(x => x.Id == idcdt).ToList().FirstOrDefault();
                if (obj != null && obj.Id != Guid.Empty)
                {
                    mainObject.MaChuong = obj.MaSoChuong;
                }
            }
        }
        #endregion

        public void InitBindEntityToControl(Control.ControlCollection controls, CongTrinhDto obj)
        {
            foreach (Control ctrl in controls)
            {
                string dataMember = GetProperty.GetPropertyStringValue(ctrl, Customs.cstDataMember);
                if (ctrl.Controls != null && ctrl.Controls.Count > 0)
                {
                    InitBindEntityToControl(ctrl.Controls, obj);
                }
                if (!string.IsNullOrWhiteSpace(dataMember))
                {
                    try
                    {
                        ctrl.DataBindings.Clear();
                        if (ctrl.GetType().ToString() == ControlCustomTypeName.GGLabel.ToString())
                        {
                            ctrl.DataBindings.Add("Text", obj, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
                        }
                        else
                        {
                            ctrl.DataBindings.Add("EditValue", obj, dataMember, true,
                                                   DataSourceUpdateMode.OnPropertyChanged);
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        public void InitControl()
        {
            string path = ConfigManager.PathGridViewXML() + ModuleName.CongTrinh + @"\" + TemplateDesignGrid.GridView_CongTrinh_DiaDiemXayDung.ToString();
            grl_DiaDiemXayDung.InitializeControlByDesign(path, CreateDesignGrid.NewGridView.ToString());

            List<DiaDiemXayDungDto> list = mainObject.DiaDiemXayDungs;
            grl_DiaDiemXayDung.DataSource = list;
            GridView gridView = (GridView)grl_DiaDiemXayDung.MainView;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridView.DoubleClick += GridView_DoubleClick;
            gridView.KeyUp += GridView_KeyUp;
        }

        private void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                GridView gridView = (GridView)sender;
                gridView.DeleteRow(gridView.FocusedRowHandle);
            }
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            GridView gridView = (GridView)sender;
            if (gridView.FocusedRowHandle >= 0)
            {
                var item = (DiaDiemXayDungDto)gridView.GetRow(gridView.FocusedRowHandle);
                MouseEventArgs mouseEvent = e as MouseEventArgs;
                GridHitInfo info = gridView.CalcHitInfo(mouseEvent.X, mouseEvent.Y);
                if (info != null && info.Column != null)
                {
                    if (info.Column.ToString() == DiaDiemXayDungColumn.DonViHanhChinhId.GetDescription())
                    {
                        DonViHanhChinhDto obj = listDonViHanhChinh.Where(x => x.Id == item.DonViHanhChinhId).ToList().FirstOrDefault();
                        if (obj != null && obj.Id != Guid.Empty)
                        {
                            ShowDonViHanhChinh(false, obj);
                        }
                    }
                }
            }
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == DiaDiemXayDungColumn.DonViHanhChinhId.ToString())
            {
                if (e.Value != null)
                {
                    Guid id = new Guid(e.Value.ToString());
                    e.DisplayText = listDonViHanhChinh.Where(x => x.Id == id).ToList().Select(x => x.TenDonViHanhChinh).FirstOrDefault();
                }
            }
        }

        private void btn_Cancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        #region Lưu
        private void btn_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ValidataSave())
            {
                return;
            }
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);

            var api = ConfigManager.GetAPIByService<ICongTrinhsApi>();
            ChuongTrinhMucTieuQuocGiaDto objCTMTQG = listCTMTQuocGia.Where(x => x.Id == mainObject.CTMTQuocGiaId).ToList().FirstOrDefault();
            if (objCTMTQG == null || objCTMTQG.Id == Guid.Empty)
            {
                mainObject.CTMTQuocGiaId = null;
            }
            GetValueNgayByNam();
            mainObject.DiaDiemXayDungs = (List<DiaDiemXayDungDto>)grl_DiaDiemXayDung.DataSource;
            var result = GGMapper<CongTrinhDto, CreateUpdateCongTrinhDto>.MapSimple(mainObject);
            if (mainObject.Id == Guid.Empty)
            {
                mainObject = api.Create(result).GetAwaiter().GetResult();
            }
            else
            {
                api.Update(mainObject.Id, result).GetAwaiter().GetResult();

                api.DeleleDiaDiemXayDungByCongTrinhId(mainObject.Id).GetAwaiter().GetResult();
            }

            if (result.DiaDiemXayDungs != null && result.DiaDiemXayDungs.Count > 0)
            {
                result.DiaDiemXayDungs.ForEach(o =>
                {
                    o.CongTrinhId = mainObject.Id;
                });
                api.SaveDiaDiemXayDung(result).GetAwaiter().GetResult();
            }
            SplashScreenManager.CloseForm();
            GGFunctions.ShowMessage("Lưu thành công!");
        }

        public bool ValidataSave()
        {
            bool check = true;
            if (string.IsNullOrWhiteSpace(mainObject.TenCongTrinh))
            {
                GGFunctions.ShowMessage("Vui lòng nhập tên công trình!");
                check = false;
                return check;
            }

            var api = ConfigManager.GetAPIByService<ICongTrinhsApi>();
            var data = api.GetListNotPageAsync().GetAwaiter().GetResult();
            if (data != null && data.ToList().Where(x => x.IsDeleted == false && x.Id != mainObject.Id
                                                   && x.TenCongTrinh.ToLower().Trim() == mainObject.TenCongTrinh.ToLower().Trim()).ToList().Count > 0)
            {
                GGFunctions.ShowMessage("Tên công trình đã tồn tại. Vui lòng kiểm tra lại!");
                check = false;
                return check;
            }
            return check;
        }


        #endregion

        private void SetValueNamByNgay()
        {
            if (mainObject.ThoiGianThucHienTuNgay != null)
            {
                mainObject.TuNam = Convert.ToDateTime(mainObject.ThoiGianThucHienTuNgay).Year;
            }
            if (mainObject.ThoiGianThucHienDenNgay != null)
            {
                mainObject.DenNam = Convert.ToDateTime(mainObject.ThoiGianThucHienDenNgay).Year;
            }
        }

        private void GetValueNgayByNam()
        {
            if (mainObject.TuNam == null || mainObject.TuNam == 0)
            {
                mainObject.ThoiGianThucHienTuNgay = null;
            }
            else
            {
                mainObject.ThoiGianThucHienTuNgay = new DateTime(Convert.ToInt32(mainObject.TuNam), 1, 1);
            }

            if (mainObject.DenNam == null || mainObject.DenNam == 0)
            {
                mainObject.ThoiGianThucHienDenNgay = null;
            }
            else
            {
                mainObject.ThoiGianThucHienDenNgay = new DateTime(Convert.ToInt32(mainObject.DenNam), 12, 31);
            }
        }

        private void btn_CreateDonViHanhChinh_Click(object sender, EventArgs e)
        {
            DonViHanhChinhDto objDonViHanhChinh = new DonViHanhChinhDto();
            ShowDonViHanhChinh(true, objDonViHanhChinh);
        }

        public void ShowDonViHanhChinh(bool isCreate, DonViHanhChinhDto objDonViHanhChinh)
        {
            guiDonViHanhChinh gui = new guiDonViHanhChinh(objDonViHanhChinh, isCreate);
            gui.Module = this.Module;
            if (gui.ShowDialog() == DialogResult.OK)
            {
                if (isCreate == false)
                {
                    return;
                }
                if (gui._listDonViHanhChinh == null || gui._listDonViHanhChinh.Count == 0)
                {
                    return;
                }
                List<DiaDiemXayDungDto> listDiaDiemXayDung = (List<DiaDiemXayDungDto>)grl_DiaDiemXayDung.DataSource;
                if (listDiaDiemXayDung == null)
                {
                    listDiaDiemXayDung = new List<DiaDiemXayDungDto>();
                }
                gui._listDonViHanhChinh.ForEach(o =>
                {
                    if (listDiaDiemXayDung.ToList().Where(x => x.DonViHanhChinhId == o.Id).ToList().Count == 0)
                    {
                        DiaDiemXayDungDto obj = new DiaDiemXayDungDto();
                        obj.CongTrinhId = mainObject.Id;
                        obj.DonViHanhChinhId = o.Id;
                        listDiaDiemXayDung.Add(obj);
                    }
                });
                grl_DiaDiemXayDung.DataSource = listDiaDiemXayDung;
                grl_DiaDiemXayDung.RefreshDataSource();
            }
        }

        #region Thay doi muc dau tu
        private void txt_NST_EditValueChanged(object sender, EventArgs e)
        {
            GGTextEdit textEdit = sender as GGTextEdit;
            if (textEdit.EditValue != null && !string.IsNullOrWhiteSpace(textEdit.EditValue.ToString()) && textEdit.EditValue != textEdit.OldEditValue)
            {
                mainObject.NST = Convert.ToDecimal(textEdit.EditValue.ToString());
                SetValueTongMucDauTu();
            }
        }


        private void txt_NSTW_EditValueChanged(object sender, EventArgs e)
        {
            GGTextEdit textEdit = sender as GGTextEdit;
            if (textEdit.EditValue != null && !string.IsNullOrWhiteSpace(textEdit.EditValue.ToString()) && textEdit.EditValue != textEdit.OldEditValue)
            {
                mainObject.NSTW = Convert.ToDecimal(textEdit.EditValue.ToString());
                SetValueTongMucDauTu();
            }
        }

        private void txt_ODA_EditValueChanged(object sender, EventArgs e)
        {
            GGTextEdit textEdit = sender as GGTextEdit;
            if (textEdit.EditValue != null && !string.IsNullOrWhiteSpace(textEdit.EditValue.ToString()) && textEdit.EditValue != textEdit.OldEditValue)
            {
                mainObject.ODA = Convert.ToDecimal(textEdit.EditValue.ToString());
                SetValueTongMucDauTu();
            }
        }

        private void SetValueTongMucDauTu()
        {
            mainObject.TongMucDauTu = Convert.ToDecimal(mainObject.NST) + Convert.ToDecimal(mainObject.NSTW) + Convert.ToDecimal(mainObject.ODA);
        }
        #endregion
    }
}