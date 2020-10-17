using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;
using xdcb.FormServices.SDK;
using xdcb.Common;
using DevExpress.XtraGrid.Views.Grid;
using xdcb.Common.DanhMuc.NghiQuyetDtos;
using xdcb.FormQLV.Module.DanhMuc.NghiQuyet.UI;
using Localization;
using DevExpress.XtraPrinting;
using DevExpress.Printing.ExportHelpers;
using DevExpress.Export;
using System.IO;
using DevExpress.Utils.Extensions;

namespace xdcb.FormQLV.Module.NghiQuyet.UI
{
    public partial class frmNghiQuyet : GGScreen
    {
        #region Property
        public NghiQuyetDto mainObject;
        #endregion
        public frmNghiQuyet()
        {
            InitializeComponent();
            InitControl();
            ReloadData();
        }

        #region InitControl

        public void InitControl()
        {
            string path = ConfigManager.PathGridViewXML() + ModuleName.NghiQuyet + @"\" + TemplateDesignGrid.GridView_DanhSachNghiQuyet.ToString();
            grl_DanhsachNghiQuyet.InitializeControlByDesign(path, CreateDesignGrid.NewGridView.ToString());

            GridView gridview = (GridView)grl_DanhsachNghiQuyet.MainView;
            gridview.FocusedRowChanged += Gridview_FocusedRowChanged;
            gridview.DoubleClick += Gridview_DoubleClick;
            gridview.KeyUp += GridView_KeyUp;
        }

        private void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Delete();
            }
        }



        private void Gridview_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView dgvSearchResults = (GridView)sender;
            if (dgvSearchResults.FocusedRowHandle >= 0)
            {
                mainObject = (NghiQuyetDto)dgvSearchResults.GetRow(dgvSearchResults.FocusedRowHandle);
            }
        }

        private void Gridview_DoubleClick(object sender, EventArgs e)
        {
            GridView dgvSearchResults = (GridView)sender;
            if (dgvSearchResults.FocusedRowHandle >= 0)
            {
                mainObject = (NghiQuyetDto)dgvSearchResults.GetRow(dgvSearchResults.FocusedRowHandle);
                Edit();
            }
        }

        #endregion


        public void GetDataSearch()
        {
            string trichyeu = txtTrichYeu.EditValue == null ? string.Empty : txtTrichYeu.EditValue.ToString();

            var api = ConfigManager.GetAPIByService<INghiQuyetsApi>();
            var data = api.SearchAsync(new ConditionSearch { keyword= trichyeu, SkipCount =0,MaxResultCount=1000}).GetAwaiter().GetResult().Items;
            if (data != null)
            {
                data = data.OrderByDescending(x => x.CreationTime).ToList();
                int i = 1;
                data.ForEach(o =>
                {
                    o.STT = i;
                    i++;
                });
            }
            grl_DanhsachNghiQuyet.DataSource = data;
            grl_DanhsachNghiQuyet.RefreshDataSource();
        }

        #region ReloadData
        private void btn_ReloadData_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        public void ReloadData()
        {
            txtTrichYeu.EditValue = string.Empty;
            GetDataSearch();
        }
        #endregion

        private void btn_Search_Click(object sender, EventArgs e)
        {
            GetDataSearch();
        }



        #region chỉnh sửa
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            Edit();
        }
        public void Edit()
        {
            if (mainObject != null && mainObject.Id != Guid.Empty)
            {
                var api = ConfigManager.GetAPIByService<INghiQuyetsApi>();
                NghiQuyetDto obj = api.GetAsync(mainObject.Id).GetAwaiter().GetResult();
                frmNghiQuyetChiTiet gui = new frmNghiQuyetChiTiet(obj);
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

      

        #endregion

        #region Thêm mới
        private void btn_New_Click(object sender, EventArgs e)
        {
            NghiQuyetDto obj = new NghiQuyetDto();
            frmNghiQuyetChiTiet gui = new frmNghiQuyetChiTiet(obj);
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

        public void SetFocusedRow(NghiQuyetDto obj)
        {
            if (obj != null && obj.Id != Guid.Empty)
            {
                GridView gridView = (GridView)grl_DanhsachNghiQuyet.MainView;
                if (gridView.RowCount > 0)
                {
                    gridView.BeginUpdate();
                    int index = 0;
                    for (int i = 0; i < gridView.RowCount; i++)
                    {
                        NghiQuyetDto objData = gridView.GetRow(i) as NghiQuyetDto;
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

        #region Xóa
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        public void Delete()
        {
            if (mainObject != null && mainObject.Id != Guid.Empty)
            {
                if (GGFunctions.ShowMessageYesNo("Bạn có muốn xóa dữ liệu") == DialogResult.No)
                    return;
                var api = ConfigManager.GetAPIByService<INghiQuyetsApi>();
                api.Delete(mainObject.Id).GetAwaiter().GetResult();
                GetDataSearch();
            }
            else
            {
                GGFunctions.ShowMessage("Không có dữ liệu để xóa, Vui lòng kiểm tra lại!");
            }
            
        }

        #endregion

        #region Export Excel
        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Chọn thư mục lưu";
            sf.Filter = "Text files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            sf.FileName = "danhmucnghiquyet_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                XlsxExportOptionsEx options = new XlsxExportOptionsEx();
                options.CustomizeSheetHeader += Options_CustomizeSheetHeader;

                grl_DanhsachNghiQuyet.ExportToXlsx(sf.FileName, options);
                if (File.Exists(sf.FileName))
                {
                    GGFunctions.StartProcess(sf.FileName);
                }
            }
        }

        private void Options_CustomizeSheetHeader(ContextEventArgs e)
        {
            GridView gridView = (GridView)grl_DanhsachNghiQuyet.MainView;
            int index = 0;
            if (gridView != null && gridView.Columns.Count() > 0)
                index = gridView.Columns.Count() - 1;
            CellObject row1 = new CellObject();
            row1.Value = "DANH MỤC NGHỊ QUYẾT";
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