using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using xdcb.FormServices.BaseForm;
using DevExpress.XtraGrid.Views.Grid;
using xdcb.FormServices.Shared;
using xdcb.FormServices.SDK;
using xdcb.Common.DanhMuc.NhomCongTrinhDtos;
using xdcb.Common.DanhMuc.ChuDauTuDtos;
using xdcb.Common.DanhMuc.LoaiKhoanDtos;
using xdcb.Common.DanhMuc.CongTrinhDtos;
using Localization;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraPrinting;
using DevExpress.Printing.ExportHelpers;
using DevExpress.Export;

namespace xdcb.FormQLV.CongTrinh
{
    public partial class frmCongTrinh : GGScreen
    {
        #region Property
        public List<ChuDauTuDto> listChuDauTu = new List<ChuDauTuDto>();
        public List<LoaiKhoanDto> listLoaiKhoan = new List<LoaiKhoanDto>();
        public List<NhomCongTrinhDto> listNhomCongTrinh = new List<NhomCongTrinhDto>();
        public CongTrinhDto mainObject;
        #endregion
        public frmCongTrinh()
        {
            InitializeComponent();
            InitControl();
            GetValueControl();
            ReloadData();
        }
        public void GetValueControl()
        {
            GetObjectControl();

            cbb_ChuDauTu.ColumnsCaption = new string[2] { ChuDauTuColumn.Ten.GetDescription().ToString(), ChuDauTuColumn.MaSoChuong.GetDescription().ToString() };
            cbb_ChuDauTu.FieldsName = new string[2] { ChuDauTuColumn.Ten.ToString(), ChuDauTuColumn.MaSoChuong.ToString() };
            cbb_ChuDauTu.ValueMember = ChuDauTuColumn.Id.ToString();
            cbb_ChuDauTu.DisplayMember = ChuDauTuColumn.Ten.ToString();
            cbb_ChuDauTu.DataSource = listChuDauTu;
            cbb_ChuDauTu.ShowData();

            //TuNam
            cbe_Nam.Properties.Items.AddRange(GGFunctions.GetValueNam());

        }
        public void GetObjectControl()
        {
            if (listChuDauTu != null)
                listChuDauTu.Clear();
            if (listLoaiKhoan != null)
                listLoaiKhoan.Clear();
            if (listNhomCongTrinh != null)
                listNhomCongTrinh.Clear();

            var apiChuDauTu = ConfigManager.GetAPIByService<IChuDauTusApi>();
            listChuDauTu.AddRange(apiChuDauTu.GetAll().GetAwaiter().GetResult());


            var apiLoaiKhoan = ConfigManager.GetAPIByService<ILoaiKhoansApi>();
            listLoaiKhoan = apiLoaiKhoan.GetAll().GetAwaiter().GetResult();

            var apiNhomCongTrinh = ConfigManager.GetAPIByService<INhomCongTrinhsApi>();
            listNhomCongTrinh = apiNhomCongTrinh.GetAll().GetAwaiter().GetResult();
        }

        #region InitControl
        public void InitControl()
        {
            string path = ConfigManager.PathGridViewXML() + ModuleName.CongTrinh + @"\" + TemplateDesignGrid.GridView_DanhSachCongTrinh.ToString();
            grl_DanhsachCongTrinh.InitializeControlByDesign(path, CreateDesignGrid.NewGridView.ToString());

            GridView gridview = (GridView)grl_DanhsachCongTrinh.MainView;
            gridview.FocusedRowChanged += Gridview_FocusedRowChanged;
            gridview.DoubleClick += Gridview_DoubleClick;
        }

        private void Gridview_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView dgvSearchResults = (GridView)sender;
            if (dgvSearchResults.FocusedRowHandle >= 0)
            {
                mainObject = (CongTrinhDto)dgvSearchResults.GetRow(dgvSearchResults.FocusedRowHandle);
            }
        }

        private void Gridview_DoubleClick(object sender, EventArgs e)
        {
            GridView dgvSearchResults = (GridView)sender;
            if (dgvSearchResults.FocusedRowHandle >= 0)
            {
                mainObject = (CongTrinhDto)dgvSearchResults.GetRow(dgvSearchResults.FocusedRowHandle);
                Edit();
            }
        }
        #endregion

        private void btn_Search_Click(object sender, EventArgs e)
        {
            GetDataSearch();
        }

        public void GetDataSearch()
        {
            string tencongtrinh = txtTenCongTrinh.EditValue == null ? string.Empty : txtTenCongTrinh.EditValue.ToString();

            Guid chuDauTuId;
            if (cbb_ChuDauTu.EditValue == null)
            {
                chuDauTuId = Guid.Empty;
            }
            else if (listChuDauTu.Where(x => x.Id.ToString() == cbb_ChuDauTu.EditValue.ToString()).ToList().Count > 0)
            {
                chuDauTuId = new Guid(cbb_ChuDauTu.EditValue.ToString());
            }
            else
            {
                chuDauTuId = Guid.Empty;
                cbb_ChuDauTu.EditValue = null;
            }

            int nam = 0;
            if (cbe_Nam.EditValue != null)
            {
                nam = Convert.ToInt32(cbe_Nam.EditValue);
            }

            var api = ConfigManager.GetAPIByService<ICongTrinhsApi>();
            var data = api.GetSearchData(tencongtrinh, chuDauTuId, nam).GetAwaiter().GetResult();
            if (data != null)
            {
                data = data.OrderByDescending(x => x.CreationTime).ToList();
                int i = 1;
                data.ForEach(o =>
                {
                    if (o.ChuDauTuId != null && o.ChuDauTuId != Guid.Empty)
                    {
                        o.TenChuDauTu = listChuDauTu.Where(x => x.Id == o.ChuDauTuId).ToList().Select(x => x.Ten).FirstOrDefault();
                        o.MaChuong = listChuDauTu.Where(x => x.Id == o.ChuDauTuId).ToList().Select(x => x.MaSoChuong).FirstOrDefault();
                    }
                    if (o.NhomCongTrinhId != null && o.NhomCongTrinhId != Guid.Empty)
                    {
                        o.TenNhomCongTrinh = listNhomCongTrinh.Where(x => x.Id == o.NhomCongTrinhId).ToList().Select(x => x.TenNhomCongTrinh).FirstOrDefault();
                    }
                    if (o.LoaiKhoanId != null && o.LoaiKhoanId != Guid.Empty)
                    {
                        o.MaLoaiKhoan = listLoaiKhoan.Where(x => x.Id == o.LoaiKhoanId).ToList().Select(x => x.MaSo).FirstOrDefault();
                    }
                    o.STT = i;
                    i++;
                });
            }
            grl_DanhsachCongTrinh.DataSource = data;
            grl_DanhsachCongTrinh.RefreshDataSource();
            SetPropertyColumn();
        }

        public void SetPropertyColumn()
        {
            GridView gridView = (GridView)grl_DanhsachCongTrinh.MainView;

            gridView.OptionsView.RowAutoHeight = true;
            RepositoryItemMemoEdit ritem = new RepositoryItemMemoEdit();
            grl_DanhsachCongTrinh.RepositoryItems.Add(ritem);

            GridColumn columnTenCongTrinh = gridView.Columns[CongTrinhColumn.TenCongTrinh.ToString()];
            if (columnTenCongTrinh != null)
            {
                columnTenCongTrinh.MaxWidth = 700;
                columnTenCongTrinh.ColumnEdit = ritem;
            }
        }

        #region ReloadData
        private void btn_ReloadData_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        public void ReloadData()
        {
            txtTenCongTrinh.EditValue = string.Empty;
            cbb_ChuDauTu.EditValue = null;
            cbe_Nam.EditValue = null;
            GetDataSearch();
        }
        #endregion

        #region chỉnh sửa
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            Edit();
        }
        public void Edit()
        {
            if (mainObject != null && mainObject.Id != Guid.Empty)
            {
                var api = ConfigManager.GetAPIByService<ICongTrinhsApi>();
                CongTrinhDto obj = api.GetCongTrinhByIdAsync(mainObject.Id).GetAwaiter().GetResult();
                frmCongTrinhChiTiet gui = new frmCongTrinhChiTiet(obj);
                gui.Module = this.Module;
                gui.Text = string.Format(FormQLVLocalizedResources.TextPopUpCongTrinh, FormQLVLocalizedResources.ActionEdit);
                gui.ShowDialog();

                GetDataSearch();
                SetFocusedRow(obj);
            }
            else
            {
                GGFunctions.ShowMessage("Không có dữ liệu để chỉnh sửa, Vui lòng kiểm tra lại!");
            }
        }

        public void SetFocusedRow(CongTrinhDto obj)
        {
            if (obj != null && obj.Id != Guid.Empty)
            {
                GridView gridView = (GridView)grl_DanhsachCongTrinh.MainView;
                if (gridView.RowCount > 0)
                {
                    gridView.BeginUpdate();
                    int index = 0;
                    for (int i = 0; i < gridView.RowCount; i++)
                    {
                        CongTrinhDto objData = gridView.GetRow(i) as CongTrinhDto;
                        if (objData.Id == obj.Id)
                        {
                            index = i;
                            break;
                        }
                    }
                    gridView.EndUpdate();
                    gridView.FocusedRowHandle = index;
                    gridView.SelectRow(index);
                }
            }

        }

        #endregion

        #region Thêm mới
        private void btn_New_Click(object sender, EventArgs e)
        {
            CongTrinhDto obj = new CongTrinhDto();
            frmCongTrinhChiTiet gui = new frmCongTrinhChiTiet(obj);
            gui.Module = this.Module;
            gui.Text = string.Format(FormQLVLocalizedResources.TextPopUpCongTrinh, FormQLVLocalizedResources.ActionCreate);
            gui.ShowDialog();
            if (gui.mainObject.Id != Guid.Empty)
            {
                GetDataSearch();
                SetFocusedRow(gui.mainObject);
            }
        }
        #endregion

        #region Xóa
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void Delete()
        {
            if (mainObject != null && mainObject.Id != Guid.Empty)
            {
                if (GGFunctions.ShowMessageYesNo("Bạn có muốn chắc chắn xóa công trình '" + mainObject.TenCongTrinh + "' không?") == System.Windows.Forms.DialogResult.Yes)
                {
                    if (IsValidateDelete())
                    {
                        var api = ConfigManager.GetAPIByService<ICongTrinhsApi>();
                        api.DeleteAsync(mainObject.Id).GetAwaiter().GetResult();
                        GetDataSearch();
                        GridView dgvSearchResults = (GridView)grl_DanhsachCongTrinh.MainView;
                        if (dgvSearchResults.FocusedRowHandle >= 0)
                        {
                            mainObject = (CongTrinhDto)dgvSearchResults.GetRow(dgvSearchResults.FocusedRowHandle);
                        }
                    }
                }
            }
            else
            {
                GGFunctions.ShowMessage("Không có dữ liệu để xóa, Vui lòng kiểm tra lại!");
            }
        }

        private bool IsValidateDelete()
        {
            //Kiểm tra NhuCauVon
            var apiNhuCauChiTiet = ConfigManager.GetAPIByService<INhuCauKeHoachVonChiTietsApi>();
            var dataNhuCauChiTiet = apiNhuCauChiTiet.GetListByCongTrinhIDAsync(mainObject.Id).GetAwaiter().GetResult();
            if (dataNhuCauChiTiet != null && dataNhuCauChiTiet.Count() > 0)
            {
                var apiNhuCau = ConfigManager.GetAPIByService<INhuCauKeHoachVonsApi>();
                var dataNhuCau = apiNhuCau.GetListAsync().GetAwaiter().GetResult();
                if (dataNhuCau != null)
                {
                    var listnam = dataNhuCau.Where(x => dataNhuCauChiTiet.Select(o => o.NhuCauKeHoachVonID).Distinct().Contains(x.Id)).Select(x => x.GiaiDoanNam).Distinct();
                    if (listnam != null)
                    {
                        GGFunctions.ShowMessage("Công trình '" + mainObject.TenCongTrinh + "' không được xóa vì đã được tạo dữ liệu ở nhu cầu vốn qua các giai đoạn và năm sau:" + Environment.NewLine + "* " +
                                                 string.Join(Environment.NewLine + "* ", listnam.ToArray()));
                        return false;
                    }
                }
            }

            //Kiểm tra KeHoachVonNQ
            var apiKeHoachVonNQChiTiet = ConfigManager.GetAPIByService<IKeHoachVonNQChiTietsApi>();
            var apiKeHoachVonNQ = ConfigManager.GetAPIByService<IKeHoachVonNQsApi>();
            var dataKeHoachVonNQChiTiet = apiKeHoachVonNQChiTiet.GetListByCongTrinhIdAsync(mainObject.Id).GetAwaiter().GetResult();
            if (dataKeHoachVonNQChiTiet != null && dataKeHoachVonNQChiTiet.Count() > 0)
            {
                var dataKeHoachVonNQ = apiKeHoachVonNQ.GetListAsync().GetAwaiter().GetResult();
                if (dataKeHoachVonNQ != null)
                {
                    var listnam = dataKeHoachVonNQ.Where(x => dataKeHoachVonNQChiTiet.Select(o => o.KeHoachVonNQId).Distinct().Contains(x.Id)).Select(x => x.Nam).Distinct();
                    if (listnam != null)
                    {
                        GGFunctions.ShowMessage("Công trình '" + mainObject.TenCongTrinh + "' không được xóa vì đã được tạo dữ liệu ở kế hoạch vốn theo nghị quyết qua các năm sau:" + Environment.NewLine + "* " +
                                                 string.Join(Environment.NewLine + "* ", listnam.ToArray()));
                        return false;
                    }
                }
            }

            //Kiểm tra KeHoachVonNSTW
            var apiKeHoachVonNSTWChiTiet = ConfigManager.GetAPIByService<IKeHoachVonNSTWChiTietsApi>();
            var apiKeHoachVonNSTW = ConfigManager.GetAPIByService<IKeHoachVonNSTWsApi>();
            var dataKeHoachVonNSTWChiTiet = apiKeHoachVonNSTWChiTiet.GetListByCongTrinhIdAsync(mainObject.Id).GetAwaiter().GetResult();
            if (dataKeHoachVonNSTWChiTiet != null && dataKeHoachVonNSTWChiTiet.Count() > 0)
            {
                var dataKeHoachVonNSTW = apiKeHoachVonNSTW.GetListAsync().GetAwaiter().GetResult();
                if (dataKeHoachVonNSTW != null)
                {
                    var listnam = dataKeHoachVonNSTW.Where(x => dataKeHoachVonNSTWChiTiet.Select(o => o.KeHoachVonNSTWId).Distinct().Contains(x.Id)).Select(x => x.Nam).Distinct();
                    if (listnam != null)
                    {
                        GGFunctions.ShowMessage("Công trình '" + mainObject.TenCongTrinh + "' không được xóa vì đã được tạo dữ liệu ở kế hoạch vốn theo ngân sách trung ương qua các năm sau:" + Environment.NewLine + "* " +
                                                 string.Join(Environment.NewLine + "* ", listnam.ToArray()));
                        return false;
                    }
                }
            }
            return true;

        }
        #endregion

        #region Export Excel
        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Chọn thư mục lưu";
            sf.Filter = "Text files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            sf.FileName = "danhmuccongtrinh_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                XlsxExportOptionsEx options = new XlsxExportOptionsEx();
                options.CustomizeSheetHeader += Options_CustomizeSheetHeader;

                grl_DanhsachCongTrinh.ExportToXlsx(sf.FileName, options);
                if (File.Exists(sf.FileName))
                {
                    GGFunctions.StartProcess(sf.FileName);
                }
            }
        }

        private void Options_CustomizeSheetHeader(ContextEventArgs e)
        {
            GridView gridView = (GridView)grl_DanhsachCongTrinh.MainView;
            int index = 0;
            if (gridView != null && gridView.Columns.Count() > 0)
                index = gridView.Columns.Count() - 1;
            CellObject row1 = new CellObject();
            row1.Value = "DANH MỤC CÔNG TRÌNH";
            XlFormattingObject rowFormatting1 = new XlFormattingObject();
            rowFormatting1.Font = new XlCellFont { Bold = true, Size = 14 };
            rowFormatting1.Alignment = new DevExpress.Export.Xl.XlCellAlignment { HorizontalAlignment = DevExpress.Export.Xl.XlHorizontalAlignment.Center, VerticalAlignment = DevExpress.Export.Xl.XlVerticalAlignment.Top };
            row1.Formatting = rowFormatting1;
            e.ExportContext.AddRow(new[] { row1 });
            e.ExportContext.MergeCells(new DevExpress.Export.Xl.XlCellRange(new DevExpress.Export.Xl.XlCellPosition(0, 0), new DevExpress.Export.Xl.XlCellPosition(index, 0)));
        }
        #endregion
    }
}