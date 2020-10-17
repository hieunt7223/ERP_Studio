using System;
using System.Linq;
using System.Windows.Forms;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;
using DevExpress.XtraGrid.Views.Grid;
using xdcb.QuanLyVon.KeHoachVonNSTW.Dtos;
using xdcb.FormServices.SDK;
using System.Collections.Generic;
using Localization;
using xdcb.QuanLyVon.NhuCauKeHoachVonChiTiet.Dtos;
using xdcb.FormQLV.KHVTheoNganSachTrungUong;

namespace xdcb.FormQLV.KeHoachVonTheoNganSachTrungUong
{
    public partial class frmKHVTheoNganSachTrungUong : GGScreen
    {
        #region Property
        private KeHoachVonNSTWDto _mainObject;
        #endregion
        public frmKHVTheoNganSachTrungUong()
        {
            InitializeComponent();
            GetValueControl();
            InitControl();
            GetDataSearch();
        }

        #region InitControl
        public void InitControl()
        {
            string path = ConfigManager.PathGridViewXML() + ModuleName.KHVTheoNganSachTrungUong + @"\" + TemplateDesignGrid.GridView_KeHoachVonTheoNganSachTrungUong.ToString();
            grd_KeHoachVon.InitializeControlByDesign(path, CreateDesignGrid.NewGridView.ToString());

            GridView gridview = (GridView)grd_KeHoachVon.MainView;
            gridview.CustomColumnDisplayText += Gridview_CustomColumnDisplayText;
            gridview.FocusedRowChanged += Gridview_FocusedRowChanged;
            gridview.DoubleClick += Gridview_DoubleClick;
        }

        private void Gridview_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView dgvSearchResults = (GridView)sender;
            if (dgvSearchResults.FocusedRowHandle >= 0)
            {
                _mainObject = (KeHoachVonNSTWDto)dgvSearchResults.GetRow(dgvSearchResults.FocusedRowHandle);
            }
        }

        private void Gridview_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == KeHoachVonNSTWColumn.TrangThai.ToString())
            {
                if (e.Value != null)
                {
                    TrangThaiKeHoachVon status;
                    Enum.TryParse(e.Value.ToString(), out status);
                    e.DisplayText = typeof(TrangThaiKeHoachVon).GetValueByKey(status);
                }
            }

            if (e.Column.FieldName == KeHoachVonNSTWColumn.LoaiKeHoach.ToString())
            {
                if (e.Value != null)
                {
                    LoaiKeHoachVon status;
                    Enum.TryParse(e.Value.ToString(), out status);
                    e.DisplayText = typeof(LoaiKeHoachVon).GetValueByKey(status);
                }
            }
        }

        private void Gridview_DoubleClick(object sender, EventArgs e)
        {
            GridView dgvSearchResults = (GridView)sender;
            if (dgvSearchResults.FocusedRowHandle >= 0)
            {
                _mainObject = (KeHoachVonNSTWDto)dgvSearchResults.GetRow(dgvSearchResults.FocusedRowHandle);
                Edit();
            }
        }

        #endregion

        #region GetValueControl
        public void GetValueControl()
        {
            // Danh sách trạng thái
            cbbTrangThai.ColumnsCaption = new string[1] { ComboBaseControl.Value.GetDescription().ToString() };
            cbbTrangThai.FieldsName = new string[1] { ComboBaseControl.Value.ToString() };
            cbbTrangThai.ValueMember = ComboBaseControl.Key.ToString();
            cbbTrangThai.DisplayMember = ComboBaseControl.Value.ToString();
            cbbTrangThai.DataSource = typeof(TrangThaiKeHoachVon).ToList();
            cbbTrangThai.cboBase.CustomDisplayText += cbbTrangThai_CustomDisplayText;
            cbbTrangThai.ShowData();

            //Nam
            cbe_nam.Properties.Items.AddRange(GGFunctions.GetValueNam());

            //LoaiKeHoach
            cbb_LoaiKeHoach.ColumnsCaption = new string[1] { ComboBaseControl.Value.GetDescription().ToString() };
            cbb_LoaiKeHoach.FieldsName = new string[1] { ComboBaseControl.Value.ToString() };
            cbb_LoaiKeHoach.ValueMember = ComboBaseControl.Key.ToString();
            cbb_LoaiKeHoach.DisplayMember = ComboBaseControl.Value.ToString();
            cbb_LoaiKeHoach.DataSource = typeof(LoaiKeHoachVon).ToList();
            cbb_LoaiKeHoach.cboBase.CustomDisplayText += cbb_LoaiKeHoach_CustomDisplayText;
            cbb_LoaiKeHoach.ShowData();
        }

        private void cbb_LoaiKeHoach_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.DisplayText != null)
            {
                LoaiKeHoachVon myStatus;
                Enum.TryParse(e.Value.ToString(), out myStatus);
                e.DisplayText = typeof(LoaiKeHoachVon).GetValueByKey(myStatus);
            }
            else
            {
                e.DisplayText = null;
            }
        }

        private void cbbTrangThai_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.DisplayText != null)
            {
                TrangThaiKeHoachVon myStatus;
                Enum.TryParse(e.Value.ToString(), out myStatus);
                e.DisplayText = typeof(TrangThaiKeHoachVon).GetValueByKey(myStatus);
            }
            else
            {
                e.DisplayText = null;
            }
        }
        #endregion

        #region Search
        private void btn_ReloadData_Click(object sender, EventArgs e)
        {
            cbe_nam.EditValue = null;
            cbb_LoaiKeHoach.EditValue = null;
            cbbTrangThai.EditValue = null;
            GetDataSearch();
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            GetDataSearch();
        }
        public void GetDataSearch()
        {
            int nam = cbe_nam.EditValue == null ? 0 : (int)cbe_nam.EditValue;
            string loaikehoach = cbb_LoaiKeHoach.EditValue == null ? string.Empty : cbb_LoaiKeHoach.EditValue.ToString();
            string trangthai = cbbTrangThai.EditValue == null ? string.Empty : cbbTrangThai.EditValue.ToString();

            var api = ConfigManager.GetAPIByService<IKeHoachVonNSTWsApi>();
            var data = api.GetSearchData(nam, loaikehoach, trangthai).GetAwaiter().GetResult();
            if (data != null && data.Count > 0)
            {
                data = data.OrderBy(x => x.Nam).ToList();
            }

            grd_KeHoachVon.DataSource = data;
            grd_KeHoachVon.RefreshDataSource();
        }
        #endregion

        #region Tạo mới
        private async void btn_New_Click(object sender, EventArgs e)
        {
            guiCreateKHV gui = new guiCreateKHV();
            if (gui.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            //Kiểm tra dữ liệu đầu vào
            if (!ValidateNew(Convert.ToInt32(gui.nam), gui.loaikehoach.ToString()))
            {
                return;
            }
            KeHoachVonNSTWDto obj = new KeHoachVonNSTWDto();
            var api = ConfigManager.GetAPIByService<IKeHoachVonNSTWsApi>();
            var data = await api.GetSearchData(Convert.ToInt32(gui.nam), string.Empty, string.Empty);
            if (data != null && data.Count > 0)
            {
                obj = data.FirstOrDefault();
            }
            obj.Nam = Convert.ToInt32(gui.nam);
            obj.LoaiKeHoach = gui.loaikehoach.ToString();
            if (obj.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
            {
                obj.TrangThaiDauNam = TrangThaiKeHoachVon.DANG_SOAN.ToString();
            }
            else if (obj.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
            {
                obj.TrangThaiDieuChinh = TrangThaiKeHoachVon.DANG_SOAN.ToString();
            }
            obj.TrangThai = TrangThaiKeHoachVon.DANG_SOAN.ToString();
            frmCreateKHVTheoNganSachTrungUong guinew = new frmCreateKHVTheoNganSachTrungUong(true, obj, this.Module);
            guinew.Module = this.Module;
            guinew.Text = string.Format(FormQLVLocalizedResources.TextPopUpKeHoachVonNSTW, FormQLVLocalizedResources.ActionCreate);
            guinew.ShowDialog();
            //Load lại dữ liệu
            GetDataSearch();
        }

        public bool ValidateNew(int nam, string loaikehoach)
        {
            bool isCheck = true;
            var api = ConfigManager.GetAPIByService<IKeHoachVonNSTWsApi>();
            //1.Nếu dữ liệu trên hệ thống đang rỗng thì cho phép thêm mới
            var dataAll = api.GetListAsync().GetAwaiter().GetResult();
            if (dataAll == null || dataAll.Count == 0)
            {
                return isCheck;
            }
            //2.Không được tạo dữ liệu có năm nhỏ hơn năm min trên hệ thống!
            int namMin = dataAll.Select(x => x.Nam).Min();
            if (nam < namMin)
            {
                GGFunctions.ShowMessage("Không được tạo dữ liệu năm nhỏ hơn năm " + namMin.ToString() + " , Vui lòng kiểm tra lại!");
                isCheck = false;
                return isCheck;
            }
            //3.Kế hoạch năm trước chưa làm thì không được làm cho kế hoạch năm sau
            int namold = Convert.ToInt32(nam) - 1;
            var dataOld = api.GetSearchData(namold, string.Empty, string.Empty).GetAwaiter().GetResult();
            if ((namMin <= namold) && (dataOld == null || dataOld.Count == 0))
            {
                GGFunctions.ShowMessage("Kế hoạch năm " + namold.ToString() + " chưa có dữ liệu nên không được làm cho kế hoạch năm " + nam.ToString() + ", Vui lòng kiểm tra lại!");
                isCheck = false;
                return isCheck;
            }
            //4.Kế hoạch năm chưa hoàn thành thì không được làm kế hoạch năm sau
            else if ((namMin <= namold) && dataOld != null && dataOld.Where(x => x.TrangThai != TrangThaiKeHoachVon.HOAN_THANH.ToString()).ToList().Count() > 0)
            {
                GGFunctions.ShowMessage("Kế hoạch năm " + namold.ToString() + " chưa hoàn thành nên không được làm cho kế hoạch năm " + nam.ToString() + ", Vui lòng kiểm tra lại!");
                isCheck = false;
                return isCheck;
            }

            var data = api.GetSearchData(Convert.ToInt32(nam), string.Empty, string.Empty).GetAwaiter().GetResult();
            if (data != null && data.Count > 0)
            {
                //5.Đã tồn tại năm đó (cùng loại kế hoạch) không cho thêm mới
                if (data.Where(x => x.LoaiKeHoach == loaikehoach.ToString()).ToList().Count() > 0)
                {
                    GGFunctions.ShowMessage("Năm và loại kế hoạch này đã phát sinh dữ liệu trên hệ thống, Vui lòng kiểm tra lại!");
                    isCheck = false;
                    return isCheck;
                }
                //6.Đã làm kế hoạch điều chỉnh thì không được làm kế hoạch đầu năm
                else if (loaikehoach == LoaiKeHoachVon.DAU_NAM.ToString()
                    && data.Where(x => x.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString()).ToList().Count() > 0)
                {
                    GGFunctions.ShowMessage("Năm này đã làm kế hoạch điều chỉnh nên không được làm kế hoạch đầu năm, Vui lòng kiểm tra lại!");
                    isCheck = false;
                    return isCheck;
                }
                //7.Nếu có kế hoạch đầu năm thì kế hoạch đầu năm hoàn thành thì mới được làm kế hoạch điều chỉnh
                else if (loaikehoach == LoaiKeHoachVon.DIEU_CHINH.ToString()
                        && data.Where(x => x.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString()).ToList().Count() > 0
                        && data.Where(x => x.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString() && x.TrangThai == TrangThaiKeHoachVon.HOAN_THANH.ToString()).ToList().Count() == 0)
                {
                    GGFunctions.ShowMessage("Kế hoạch đầu năm hoàn thành mới được làm kế hoạch điều chỉnh, Vui lòng kiểm tra lại!");
                    isCheck = false;
                    return isCheck;
                }
            }
            //8.Kế hoạch năm trước chưa làm kế hoạch điều chỉnh và kế hoạch năm nay chưa có dữ liệu thì cảnh báo. Nếu đồng ý thì cho phép làm kế hoạch năm nay.
            if ((namMin <= namold) && dataOld != null && dataOld.Where(x => x.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString()).ToList().Count() == 0)
            {
                if (GGFunctions.ShowMessageYesNo("Kế hoạch năm " + namold.ToString() + " chưa làm kế hoạch điều chỉnh. Bạn có muốn tiếp tục không?") == DialogResult.No)
                {
                    isCheck = false;
                    return isCheck;
                }
            }

            return isCheck;
        }
        #endregion

        #region Chỉnh sửa
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            Edit();
        }
        public void Edit()
        {
            if (_mainObject != null && _mainObject.Id != Guid.Empty)
            {
                KeHoachVonNSTWDto obj = _mainObject;
                frmCreateKHVTheoNganSachTrungUong guinew = new frmCreateKHVTheoNganSachTrungUong(false, _mainObject, this.Module);
                guinew.Module = this.Module;
                guinew.Text = string.Format(FormQLVLocalizedResources.TextPopUpKeHoachVonNSTW, FormQLVLocalizedResources.ActionEdit);
                guinew.ShowDialog();

                grd_KeHoachVon.DataSource = null;
                grd_KeHoachVon.RefreshDataSource();

                //Load lại dữ liệu
                GetDataSearch();
                SetFocusedRow(obj);
            }
            else
            {
                GGFunctions.ShowMessage("Không có dữ liệu để chỉnh sửa, Vui lòng kiểm tra lại!");
            }
        }

        public void SetFocusedRow(KeHoachVonNSTWDto obj)
        {
            if (_mainObject != null && _mainObject.Id != Guid.Empty)
            {
                var list = (List<KeHoachVonNSTWDto>)grd_KeHoachVon.DataSource;
                if (list != null && list.Count > 0)
                {
                    GridView gridView = (GridView)grd_KeHoachVon.MainView;
                    gridView.BeginUpdate();
                    int id = GoToPositionOfEntity(list, obj);
                    gridView.FocusedRowHandle = (id >= 0 ? id : 0);
                    gridView.EndUpdate();
                }
            }
        }

        private int GoToPositionOfEntity(List<KeHoachVonNSTWDto> list, KeHoachVonNSTWDto obj)
        {
            int index = -1;
            if (obj != null && obj.Id != Guid.Empty)
            {
                if (list != null && list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        var objlist = list[i];
                        if (objlist.Id == objlist.Id && obj.LoaiKeHoach == obj.LoaiKeHoach)
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

        #region Xóa
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        public void Delete()
        {
            if (_mainObject != null && _mainObject.Id != Guid.Empty)
            {
                var api = ConfigManager.GetAPIByService<IKeHoachVonNSTWsApi>();

                KeHoachVonNSTWDto obj = api.GetAsync(_mainObject.Id).GetAwaiter().GetResult();
                if (obj != null && obj.Id != Guid.Empty)
                {
                    if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
                    {
                        if (obj.TrangThaiDauNam != TrangThaiKeHoachVon.DANG_SOAN.ToString())
                        {
                            GGFunctions.ShowMessage("Chỉ được xóa dữ liệu ở trạng thái đang soạn, Vui lòng kiểm tra lại!");
                            return;
                        }
                        if (GGFunctions.ShowMessageYesNo("Bạn có chắc chắn muốn xóa kế hoạch vốn đầu năm " + _mainObject.Nam.ToString() + " không?") == DialogResult.No)
                        {
                            return;
                        }
                        DeleteKeHoachVonDauNam(_mainObject.Id);
                        GetDataSearch();
                    }
                    else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
                    {
                        if (obj.TrangThaiDieuChinh != TrangThaiKeHoachVon.DANG_SOAN.ToString())
                        {
                            GGFunctions.ShowMessage("Chỉ được xóa dữ liệu ở trạng thái đang soạn, Vui lòng kiểm tra lại!");
                            return;
                        }
                        if (GGFunctions.ShowMessageYesNo("Bạn có chắc chắn muốn xóa kế hoạch vốn điều chỉnh năm" + _mainObject.Nam.ToString() + " không?") == DialogResult.No)
                        {
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(obj.TrangThaiDauNam))
                        {
                            DeleteKeHoachVonDauNam(_mainObject.Id);
                        }
                        else
                        {
                            DeleteKeHoachVonDieuChinh(_mainObject.Id);
                        }
                        GetDataSearch();
                    }
                }
                else
                {
                    GGFunctions.ShowMessage("Dữ liệu đã được xóa trước đây, Vui lòng kiểm tra lại!");
                    return;
                }
            }
            else
            {
                GGFunctions.ShowMessage("Không có dữ liệu để xóa, Vui lòng kiểm tra lại!");
            }
        }
        public void DeleteKeHoachVonDauNam(Guid id)
        {
            var api = ConfigManager.GetAPIByService<IKeHoachVonNSTWsApi>();
            var apiDetatil = ConfigManager.GetAPIByService<IKeHoachVonNSTWChiTietsApi>();

            api.Delete(id).GetAwaiter().GetResult();
            apiDetatil.DeleteByKeHoachVonNSTWId(id);
        }

        public void DeleteKeHoachVonDieuChinh(Guid id)
        {
            var api = ConfigManager.GetAPIByService<IKeHoachVonNSTWsApi>();
            var apiDetatil = ConfigManager.GetAPIByService<IKeHoachVonNSTWChiTietsApi>();

            api.DeleteKeHoachVonNSTWDieuChinh(id).GetAwaiter().GetResult();
            apiDetatil.DeleteDataDieuChinhByKeHoachVonNSTWID(id);
        }
        #endregion

        #region Export Excel
        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            if (_mainObject != null && _mainObject.Id != Guid.Empty)
            {
                ((KHVTheoNganSachTrungUongModule)Module).SetValueAndControl(_mainObject);
                ((KHVTheoNganSachTrungUongModule)Module).ExportExcel();
            }
            else
            {
                GGFunctions.ShowMessage("Không có dữ liệu để xuất file, Vui lòng kiểm tra lại!");
            }
        }
        #endregion
    }
}