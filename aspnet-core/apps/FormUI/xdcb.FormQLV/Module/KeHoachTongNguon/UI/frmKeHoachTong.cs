using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;
using xdcb.QuanLyVon.KeHoachTongNguon.Dtos;
using xdcb.FormServices.SDK;
using DevExpress.XtraGrid.Views.Grid;
using xdcb.QuanLyVon.KeHoachTongNguonChiTiet.Dtos;
using System.Collections.Generic;
using DevExpress.XtraTreeList.Columns;
using xdcb.Common.DanhMuc.NguonVonDtos;
using Localization;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;

namespace xdcb.FormQLV.KeHoachTongNguon
{
    public partial class frmKeHoachTong : GGScreen
    {
        #region Property
        public KeHoachTongNguonDto mainObject;
        #endregion
        public frmKeHoachTong()
        {
            InitializeComponent();
            GetValueControl();
            InitControl();
            GetDataSearch();
        }

        #region InitControl
        public void InitControl()
        {
            grv_KeHoachTongNguon.InitializeControl();
            GridView grid = (GridView)grv_KeHoachTongNguon.MainView;
            grid.FocusedRowChanged += Grid_FocusedRowChanged;
            grid.DoubleClick += Grid_DoubleClick;

            tree_kehoachtongnguonchitietView.InitializeControl();
            tree_kehoachtongnguonchitietView.LoadControlByLoaiKeHoach(false, mainObject);
            tree_kehoachtongnguonchitietView.GetCustomSummaryValue += Tree_kehoachtongnguonchitietView_GetCustomSummaryValue;
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
            cbbTrangThai.DataSource = typeof(TrangThaiKeHoachTongNguon).ToList();
            cbbTrangThai.cboBase.CustomDisplayText += cbbTrangThai_CustomDisplayText;
            cbbTrangThai.ShowData();

            //Nam
            cbe_nam.Properties.Items.AddRange(GGFunctions.GetValueNam());

            //LoaiKeHoach
            cbb_LoaiKeHoach.ColumnsCaption = new string[1] { ComboBaseControl.Value.GetDescription().ToString() };
            cbb_LoaiKeHoach.FieldsName = new string[1] { ComboBaseControl.Value.ToString() };
            cbb_LoaiKeHoach.ValueMember = ComboBaseControl.Key.ToString();
            cbb_LoaiKeHoach.DisplayMember = ComboBaseControl.Value.ToString();
            cbb_LoaiKeHoach.DataSource = typeof(LoaiKeHoachTongNguon).ToList();
            cbb_LoaiKeHoach.cboBase.CustomDisplayText += cbb_LoaiKeHoach_CustomDisplayText;
            cbb_LoaiKeHoach.ShowData();
        }

        private void cbb_LoaiKeHoach_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.DisplayText != null)
            {
                LoaiKeHoachTongNguon myStatus;
                Enum.TryParse(e.Value.ToString(), out myStatus);
                e.DisplayText = typeof(LoaiKeHoachTongNguon).GetValueByKey(myStatus);
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
                TrangThaiKeHoachTongNguon myStatus;
                Enum.TryParse(e.Value.ToString(), out myStatus);
                e.DisplayText = typeof(LoaiKeHoachTongNguon).GetValueByKey(myStatus);
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

            var api = ConfigManager.GetAPIByService<IKeHoachTongNguonsApi>();
            var data = api.GetSearchData(nam, loaikehoach, trangthai).GetAwaiter().GetResult();
            if (data != null && data.Count > 0)
            {
                data = data.OrderBy(x => x.Nam).ToList();
            }

            grv_KeHoachTongNguon.DataSource = data;
            grv_KeHoachTongNguon.RefreshDataSource();

            GridView gridView = (GridView)grv_KeHoachTongNguon.MainView;
            gridView.BestFitColumns();

            if (data == null || data.Count == 0)
            {
                tree_kehoachtongnguonchitietView.DataSource = null;
                tree_kehoachtongnguonchitietView.RefreshDataSource();
            }

        }
        #endregion

        #region Tạo mới
        private async void btn_New_Click(object sender, EventArgs e)
        {
            guiCreate gui = new guiCreate();
            if (gui.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            //Kiểm tra dữ liệu đầu vào
            if (!ValidateNew(Convert.ToInt32(gui.nam), gui.loaikehoach.ToString()))
            {
                return;
            }
            KeHoachTongNguonDto obj = new KeHoachTongNguonDto();
            var api = ConfigManager.GetAPIByService<IKeHoachTongNguonsApi>();
            var data = await api.GetSearchData(Convert.ToInt32(gui.nam), string.Empty, string.Empty);
            if (data != null && data.Count > 0)
            {
                obj = data.FirstOrDefault();

            }
            obj.Nam = Convert.ToInt32(gui.nam);
            obj.LoaiKeHoach = gui.loaikehoach.ToString();
            if (obj.LoaiKeHoach == LoaiKeHoachTongNguon.DAU_NAM.ToString())
            {
                obj.TrangThaiDauNam = TrangThaiKeHoachTongNguon.DANG_SOAN.ToString();
            }
            else if (obj.LoaiKeHoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString())
            {
                obj.TrangThaiDieuChinh = TrangThaiKeHoachTongNguon.DANG_SOAN.ToString();
            }
            obj.TrangThai = TrangThaiKeHoachTongNguon.DANG_SOAN.ToString();
            frmCreateKeHoachTong guinew = new frmCreateKeHoachTong(true, obj);
            guinew.Module = this.Module;
            guinew.Text = string.Format(FormQLVLocalizedResources.TextPopUpKeHoachVon, FormQLVLocalizedResources.ActionCreate);
            guinew.ShowDialog();

            //Load lại dữ liệu
            GetDataSearch();
        }

        public bool ValidateNew(int nam, string loaikehoach)
        {
            bool isCheck = true;
            var api = ConfigManager.GetAPIByService<IKeHoachTongNguonsApi>();
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
            else if ((namMin <= namold) && dataOld != null && dataOld.Where(x => x.TrangThai != TrangThaiKeHoachTongNguon.HOAN_THANH.ToString()).ToList().Count() > 0)
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
                else if (loaikehoach == LoaiKeHoachTongNguon.DAU_NAM.ToString()
                    && data.Where(x => x.LoaiKeHoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString()).ToList().Count() > 0)
                {
                    GGFunctions.ShowMessage("Năm này đã làm kế hoạch điều chỉnh nên không được làm kế hoạch đầu năm, Vui lòng kiểm tra lại!");
                    isCheck = false;
                    return isCheck;
                }
                //7.Nếu có kế hoạch đầu năm thì kế hoạch đầu năm hoàn thành thì mới được làm kế hoạch điều chỉnh
                else if (loaikehoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString()
                        && data.Where(x => x.LoaiKeHoach == LoaiKeHoachTongNguon.DAU_NAM.ToString()).ToList().Count() > 0
                        && data.Where(x => x.LoaiKeHoach == LoaiKeHoachTongNguon.DAU_NAM.ToString() && x.TrangThai == TrangThaiKeHoachTongNguon.HOAN_THANH.ToString()).ToList().Count() == 0)
                {
                    GGFunctions.ShowMessage("Kế hoạch đầu năm hoàn thành mới được làm kế hoạch điều chỉnh, Vui lòng kiểm tra lại!");
                    isCheck = false;
                    return isCheck;
                }
            }
            //8.Kế hoạch năm trước chưa làm kế hoạch điều chỉnh và kế hoạch năm nay chưa có dữ liệu thì cảnh báo. Nếu đồng ý thì cho phép làm kế hoạch năm nay.
            else if ((namMin <= namold) && dataOld != null && dataOld.Where(x => x.LoaiKeHoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString()).ToList().Count() == 0)
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
            if (mainObject != null && mainObject.Id != Guid.Empty)
            {
                KeHoachTongNguonDto obj = mainObject;
                frmCreateKeHoachTong guinew = new frmCreateKeHoachTong(false, mainObject);
                guinew.Module = this.Module;
                guinew.Text = string.Format(FormQLVLocalizedResources.TextPopUpKeHoachVon, FormQLVLocalizedResources.ActionEdit);
                guinew.ShowDialog();

                grv_KeHoachTongNguon.DataSource = null;
                grv_KeHoachTongNguon.RefreshDataSource();

                tree_kehoachtongnguonchitietView.DataSource = null;
                tree_kehoachtongnguonchitietView.RefreshDataSource();
                //Load lại dữ liệu
                GetDataSearch();
                SetFocusedRow(obj);
            }
            else
            {
                GGFunctions.ShowMessage("Không có dữ liệu để chỉnh sửa, Vui lòng kiểm tra lại!");
            }
        }

        public void SetFocusedRow(KeHoachTongNguonDto obj)
        {
            if (mainObject != null && mainObject.Id != Guid.Empty)
            {
                var list = (List<KeHoachTongNguonDto>)grv_KeHoachTongNguon.DataSource;
                if (list != null && list.Count > 0)
                {
                    GridView gridView = (GridView)grv_KeHoachTongNguon.MainView;
                    gridView.BeginUpdate();
                    int id = GoToPositionOfEntity(list, obj);
                    gridView.FocusedRowHandle = (id >= 0 ? id : 0);
                    gridView.EndUpdate();
                }
            }
        }
        private int GoToPositionOfEntity(List<KeHoachTongNguonDto> list, KeHoachTongNguonDto objKeHoachTongNguon)
        {
            int index = -1;
            if (objKeHoachTongNguon != null && objKeHoachTongNguon.Id != Guid.Empty)
            {
                if (list != null && list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        var obj = list[i];
                        if (obj.Id == objKeHoachTongNguon.Id && obj.LoaiKeHoach == objKeHoachTongNguon.LoaiKeHoach)
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
            if (mainObject != null && mainObject.Id != Guid.Empty)
            {
                var api = ConfigManager.GetAPIByService<IKeHoachTongNguonsApi>();

                KeHoachTongNguonDto obj = api.GetAsync(mainObject.Id).GetAwaiter().GetResult();
                if (obj != null && obj.Id != Guid.Empty)
                {
                    if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DAU_NAM.ToString())
                    {
                        if (obj.TrangThaiDauNam != TrangThaiKeHoachTongNguon.DANG_SOAN.ToString())
                        {
                            GGFunctions.ShowMessage("Chỉ được xóa dữ liệu ở trạng thái đang soạn, Vui lòng kiểm tra lại!");
                            return;
                        }
                        if (GGFunctions.ShowMessageYesNo("Bạn có chắc chắn muốn xóa kế hoạch vốn đầu năm " + mainObject.Nam.ToString() + " không?") == DialogResult.No)
                        {
                            return;
                        }
                        DeleteKeHoachVonDauNam(mainObject.Id);
                        GetDataSearch();
                    }
                    else if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString())
                    {
                        if (obj.TrangThaiDieuChinh != TrangThaiKeHoachTongNguon.DANG_SOAN.ToString())
                        {
                            GGFunctions.ShowMessage("Chỉ được xóa dữ liệu ở trạng thái đang soạn, Vui lòng kiểm tra lại!");
                            return;
                        }
                        if (GGFunctions.ShowMessageYesNo("Bạn có chắc chắn muốn xóa kế hoạch vốn điều chỉnh năm" + mainObject.Nam.ToString() + " không?") == DialogResult.No)
                        {
                            return;
                        }
                        if (string.IsNullOrWhiteSpace(obj.TrangThaiDauNam))
                        {
                            DeleteKeHoachVonDauNam(mainObject.Id);
                        }
                        else
                        {
                            DeleteKeHoachVonDieuChinh(mainObject.Id);
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
            var api = ConfigManager.GetAPIByService<IKeHoachTongNguonsApi>();
            var apiDetatil = ConfigManager.GetAPIByService<IKeHoachTongNguonChiTietsApi>();
            var data = apiDetatil.GetListByKeHoachTongNguonIdAsync(id).GetAwaiter().GetResult();
            if (data != null && data.Count > 0)
            {
                data.ForEach(o =>
                {
                    if (o.Id != null && o.Id != Guid.Empty)
                    {
                        apiDetatil.Delete(o.Id).GetAwaiter().GetResult();
                    }
                });
            }
            api.Delete(id).GetAwaiter().GetResult();
        }

        public void DeleteKeHoachVonDieuChinh(Guid id)
        {
            var api = ConfigManager.GetAPIByService<IKeHoachTongNguonsApi>();
            var apiDetatil = ConfigManager.GetAPIByService<IKeHoachTongNguonChiTietsApi>();
            var data = apiDetatil.GetListByKeHoachTongNguonIdAsync(id).GetAwaiter().GetResult();
            if (data != null && data.Count > 0)
            {
                data.ForEach(o =>
                {
                    if (o.Id != null && o.Id != Guid.Empty)
                    {
                        apiDetatil.DeleteKeHoachVonDieuChinhById(o.Id).GetAwaiter().GetResult();
                    }
                });
            }
            api.DeleteKeHoachVonDieuChinh(id).GetAwaiter().GetResult();
        }
        #endregion

        #region Sự kiện danh sách tổng nguồn
        public void Grid_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView dgvSearchResults = (GridView)sender;
            if (dgvSearchResults.FocusedRowHandle >= 0)
            {
                mainObject = (KeHoachTongNguonDto)dgvSearchResults.GetRow(dgvSearchResults.FocusedRowHandle);
                grv_KeHoachTongNguon.LoadCaptionHeaderGridView(mainObject.Nam.ToString());
                GetValueKeHoachTongNguonChiTietTreeList();

                gcl_chitietkehoach.Text = "Chi tiết kế hoạch tổng nguồn: Năm "
                    + mainObject.Nam.ToString()
                    + " - Loại kế hoạch: "
                    + (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DAU_NAM.ToString() ? LoaiKeHoachTongNguon.DAU_NAM.GetDescription() : LoaiKeHoachTongNguon.DIEU_CHINH.GetDescription());
            }
        }

        private void Grid_DoubleClick(object sender, EventArgs e)
        {

            GridView dgvSearchResults = (GridView)sender;
            if (dgvSearchResults.FocusedRowHandle >= 0)
            {
                mainObject = (KeHoachTongNguonDto)dgvSearchResults.GetRow(dgvSearchResults.FocusedRowHandle);
                Edit();
            }
        }
        #endregion

        #region Get Value KeHoachTongNguonChiTiet
        public void GetValueKeHoachTongNguonChiTietTreeList()
        {
            if (mainObject != null)
            {
                var api = ConfigManager.GetAPIByService<IKeHoachTongNguonChiTietsApi>();
                var data = api.GetListByKeHoachTongNguonIdAsync(mainObject.Id).GetAwaiter().GetResult();
                if (data != null && data.Count > 0)
                {
                    if (mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachTongNguon.DAU_NAM.ToString().ToLower().Trim())
                    {
                        data = data.Where(x => x.IsSelectDieuChinh == false).ToList();
                    }
                    else if (mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachTongNguon.DIEU_CHINH.ToString().ToLower().Trim())
                    {
                        data = data.Where(x => x.IsDeleteDieuChinh == false).ToList();
                    }
                }
                var apiNguonVon = ConfigManager.GetAPIByService<INguonVonsApi>();
                var dataNguonVon = apiNguonVon.GetListNotPageAsync().GetAwaiter().GetResult();

                if (data != null && data.Count > 0 && dataNguonVon != null)
                {
                    data.ForEach(o =>
                    {
                        NguonVonDto objNguonVon = dataNguonVon.Where(x => x.Id == o.NguonVonId).ToList().FirstOrDefault();
                        if (objNguonVon != null && objNguonVon.Id != Guid.Empty)
                        {
                            o.MaNguonVon = objNguonVon.MaNguonVon;
                            o.TenNguonVon = objNguonVon.TenNguonVon;
                            o.NguonVonIndex = objNguonVon.OrderIndex;
                        }
                    });
                    data = data.OrderBy(x => x.NguonVonIndex).ToList();
                }
                tree_kehoachtongnguonchitietView.LoadControlByLoaiKeHoach(false, mainObject);
                tree_kehoachtongnguonchitietView.DataSource = data;
                tree_kehoachtongnguonchitietView.RefreshDataSource();

                //set thông tin
                tree_kehoachtongnguonchitietView.ExpandAll();
                tree_kehoachtongnguonchitietView.OptionsView.AutoWidth = false;
                tree_kehoachtongnguonchitietView.BestFitColumns();
                TreeListColumn columnNguonVon = tree_kehoachtongnguonchitietView.Columns[KeHoachTongNguonChiTietsColumn.TenNguonVon.ToString()];
                if (columnNguonVon != null)
                {
                    columnNguonVon.Width = 400;
                    RepositoryItemMemoEdit memoEdit = new RepositoryItemMemoEdit();
                    columnNguonVon.ColumnEdit = memoEdit;
                    columnNguonVon.AppearanceCell.Options.UseTextOptions = true;
                    columnNguonVon.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                    columnNguonVon.AppearanceCell.TextOptions.WordWrap = WordWrap.Wrap;
                }
            }
        }
        #endregion

        #region Sự kiện kế hoạch tổng nguồn chi tiết
        private void Tree_kehoachtongnguonchitietView_GetCustomSummaryValue(object sender, DevExpress.XtraTreeList.GetCustomSummaryValueEventArgs e)
        {
            if (e.IsSummaryFooter)
            {
                if (e.Column.FieldName == KeHoachTongNguonChiTietsColumn.KeHoachDauNamTruoc.ToString())
                {
                    e.CustomValue = GetSumByColumnByFormat(KeHoachTongNguonChiTietsColumn.KeHoachDauNamTruoc.ToString(), FormatValue.N3);
                }
                else if (e.Column.FieldName == KeHoachTongNguonChiTietsColumn.KeHoachBoSungNamTruoc.ToString())
                {
                    e.CustomValue = GetSumByColumnByFormat(KeHoachTongNguonChiTietsColumn.KeHoachBoSungNamTruoc.ToString(), FormatValue.N3);
                }
                else if (e.Column.FieldName == KeHoachTongNguonChiTietsColumn.KeHoachDauNam.ToString())
                {
                    e.CustomValue = GetSumByColumnByFormat(KeHoachTongNguonChiTietsColumn.KeHoachDauNam.ToString(), FormatValue.N3);
                }
                else if (e.Column.FieldName == KeHoachTongNguonChiTietsColumn.KeHoachDauNamDuocDuyet.ToString())
                {
                    e.CustomValue = GetSumByColumnByFormat(KeHoachTongNguonChiTietsColumn.KeHoachDauNamDuocDuyet.ToString(), FormatValue.N3);
                }
                else if (e.Column.FieldName == KeHoachTongNguonChiTietsColumn.DieuChinhGiam.ToString())
                {
                    e.CustomValue = GetSumByColumnByFormat(KeHoachTongNguonChiTietsColumn.DieuChinhGiam.ToString(), FormatValue.N3);
                }
                else if (e.Column.FieldName == KeHoachTongNguonChiTietsColumn.DieuChinhTang.ToString())
                {
                    e.CustomValue = GetSumByColumnByFormat(KeHoachTongNguonChiTietsColumn.DieuChinhTang.ToString(), FormatValue.N3);
                }
                else if (e.Column.FieldName == KeHoachTongNguonChiTietsColumn.KeHoachBoSung.ToString())
                {
                    e.CustomValue = GetSumByColumnByFormat(KeHoachTongNguonChiTietsColumn.KeHoachBoSung.ToString(), FormatValue.N3);
                }
                else if (e.Column.FieldName == KeHoachTongNguonChiTietsColumn.KeHoachBoSungDuocDuyet.ToString())
                {
                    e.CustomValue = GetSumByColumnByFormat(KeHoachTongNguonChiTietsColumn.KeHoachBoSungDuocDuyet.ToString(), FormatValue.N3);
                }
            }
        }
        public string GetSumByColumnByFormat(string column, string format)
        {
            return String.Format(format, GetSumByColumn(column));
        }
        public decimal GetSumByColumn(string column)
        {
            decimal result = 0;
            if (tree_kehoachtongnguonchitietView.DataSource != null)
            {
                List<KeHoachTongNguonChiTietDto> moduleObject = (List<KeHoachTongNguonChiTietDto>)tree_kehoachtongnguonchitietView.DataSource;
                if (moduleObject != null || moduleObject.Count == 0)
                {
                    if (mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachTongNguon.DAU_NAM.ToString().ToLower().Trim())
                    {
                        moduleObject = moduleObject.Where(x => x.IsSelectDieuChinh == false).ToList();
                    }
                    else if (mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachTongNguon.DIEU_CHINH.ToString().ToLower().Trim())
                    {
                        moduleObject = moduleObject.Where(x => x.IsDeleteDieuChinh == false).ToList();
                    }
                    moduleObject.ForEach(o =>
                    {
                        if (moduleObject.Where(x => x.NguonVonChaId == o.NguonVonId).ToList().Count == 0)
                        {
                            if (column == KeHoachTongNguonChiTietsColumn.KeHoachDauNamTruoc.ToString())
                            {
                                result += o.KeHoachDauNamTruoc;
                            }
                            else if (column == KeHoachTongNguonChiTietsColumn.KeHoachBoSungNamTruoc.ToString())
                            {
                                result += o.KeHoachBoSungNamTruoc;
                            }
                            else if (column == KeHoachTongNguonChiTietsColumn.KeHoachDauNam.ToString())
                            {
                                result += o.KeHoachDauNam;
                            }
                            else if (column == KeHoachTongNguonChiTietsColumn.KeHoachDauNamDuocDuyet.ToString())
                            {
                                result += o.KeHoachDauNamDuocDuyet;
                            }
                            else if (column == KeHoachTongNguonChiTietsColumn.DieuChinhGiam.ToString())
                            {
                                result += o.DieuChinhGiam;
                            }
                            else if (column == KeHoachTongNguonChiTietsColumn.DieuChinhTang.ToString())
                            {
                                result += o.DieuChinhTang;
                            }
                            else if (column == KeHoachTongNguonChiTietsColumn.KeHoachBoSung.ToString())
                            {
                                result += o.KeHoachBoSung;
                            }
                            else if (column == KeHoachTongNguonChiTietsColumn.KeHoachBoSungDuocDuyet.ToString())
                            {
                                result += o.KeHoachBoSungDuocDuyet;
                            }
                        }
                    });
                }
            }
            return Math.Round(result, 6, MidpointRounding.AwayFromZero);
        }
        #endregion

        #region Export Excel
        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            if (mainObject != null && mainObject.Id != Guid.Empty)
            {
                ((KeHoachTongNguonModule)Module).SetValueAndControl(mainObject, tree_kehoachtongnguonchitietView);
                ((KeHoachTongNguonModule)Module).ExportExcel();
            }
            else
            {
                GGFunctions.ShowMessage("Không có dữ liệu để xuất file, Vui lòng kiểm tra lại!");
            }
        }
        #endregion


    }
}