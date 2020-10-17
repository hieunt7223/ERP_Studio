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
using xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGiaDtos;
using xdcb.FormServices.SDK;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraPrinting;
using System.IO;
using DevExpress.Export;
using DevExpress.Printing.ExportHelpers;

namespace xdcb.FormQLV.Module.DanhMuc.ChuongTrinhMucTieuQuocGia.UI
{
    public partial class frmChuongTrinhMucTieuQuocGia  : GGScreen
    {
        public frmChuongTrinhMucTieuQuocGia()
        {
            InitializeComponent();
            InitControl();
            ReloadData();
        }

        public void InitControl()
        {
            string path = ConfigManager.PathTreeListXML() + ModuleName.ChuongTrinhMucTieuQuocGia + @"\" + TemplateDesignTreeList.TreeList_DanhSachChuongTrinhMucTieuQuocGia.ToString();
            tree_danhsachchuongtrinhmuctieuquocgia.InitializeControlByDesign(path, CreateDesignTree.NewTreeList.ToString());
            tree_danhsachchuongtrinhmuctieuquocgia.OptionsDragAndDrop.AcceptOuterNodes = true;
            tree_danhsachchuongtrinhmuctieuquocgia.RootValue = Guid.Empty;
            tree_danhsachchuongtrinhmuctieuquocgia.KeyUp += Tree_ChuongTrinhMucTieuQuocGia_KeyUp;
            tree_danhsachchuongtrinhmuctieuquocgia.PopupMenuShowing += Tree_danhsachChuongTrinhMucTieuQuocGia_PopupMenuShowing;
            tree_danhsachchuongtrinhmuctieuquocgia.FocusedNodeChanged += tree_ChuongTrinhMucTieuQuocGia_FocusedNodeChanged;
            tree_danhsachchuongtrinhmuctieuquocgia.AfterDragNode += Tree_danhsachChuongTrinhMucTieuQuocGia_AfterDragNode;
            tree_danhsachchuongtrinhmuctieuquocgia.StateImageList = imageCollection1;
            tree_danhsachchuongtrinhmuctieuquocgia.GetStateImage += TreeList_GetStateImage;
        }

        private void TreeList_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            e.NodeImageIndex = 0;
        }

        private void Tree_danhsachChuongTrinhMucTieuQuocGia_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            //Set text của menu
            var ChuongTrinhMucTieuQuocGia = e.Menu.Items;
            if (ChuongTrinhMucTieuQuocGia.Count > 0)
            {
                ChuongTrinhMucTieuQuocGia[0].Caption = "Thêm";
                ChuongTrinhMucTieuQuocGia[1].Caption = "Thêm con";
            }

        }

        private void Tree_danhsachChuongTrinhMucTieuQuocGia_AfterDragNode(object sender, DevExpress.XtraTreeList.AfterDragNodeEventArgs e)
        {
            ChuongTrinhMucTieuQuocGiaDto ChuongTrinhMucTieuQuocGia = (ChuongTrinhMucTieuQuocGiaDto)tree_danhsachchuongtrinhmuctieuquocgia.GetDataRecordByNode(tree_danhsachchuongtrinhmuctieuquocgia.FocusedNode);
            var api = ConfigManager.GetAPIByService<IChuongTrinhMucTieuQuocGiasApi>();
            //Kiểm tra phần tử cha nếu là Khoản thì không cho phép
            var parent = e.Node.ParentNode;

            if (parent == null)
            {
                ChuongTrinhMucTieuQuocGia.ParentId = null;
            }
            //Lưu dữ liệu
            CreateUpdateChuongTrinhMucTieuQuocGiaDto  createUpdateChuongTrinhMucTieuQuocGiaDto = new CreateUpdateChuongTrinhMucTieuQuocGiaDto
            {
                MaChuongTrinhMucTieuQuocGia = ChuongTrinhMucTieuQuocGia.MaChuongTrinhMucTieuQuocGia,
                TenChuongTrinhMucTieuQuocGia = ChuongTrinhMucTieuQuocGia.TenChuongTrinhMucTieuQuocGia,
                ParentId = ChuongTrinhMucTieuQuocGia.ParentId
            };
            api.UpdateAsync(ChuongTrinhMucTieuQuocGia.Id, createUpdateChuongTrinhMucTieuQuocGiaDto).GetAwaiter().GetResult();
        }

        #region ReloadData

        private void btn_ReloadData_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        public void ReloadData()
        {
            txtTuKhoa.EditValue = string.Empty;
            GetDataSearch();
        }

        #endregion ReloadData

        public void GetDataSearch()
        {
            string tuKhoa = txtTuKhoa.EditValue == null ? string.Empty : txtTuKhoa.EditValue.ToString();

            var api = ConfigManager.GetAPIByService<IChuongTrinhMucTieuQuocGiasApi>();
            var data = api.SearchAsync(tuKhoa).GetAwaiter().GetResult();
            tree_danhsachchuongtrinhmuctieuquocgia.DataSource = data;
            tree_danhsachchuongtrinhmuctieuquocgia.RefreshDataSource();
            tree_danhsachchuongtrinhmuctieuquocgia.ExpandAll();
            TreeListColumn columnDanhMuc = tree_danhsachchuongtrinhmuctieuquocgia.Columns["TenChuongTrinhMucTieuQuocGia"];
            if (columnDanhMuc != null)
            {
                columnDanhMuc.Width = 400;
                RepositoryItemMemoEdit memoEdit = new RepositoryItemMemoEdit();
                columnDanhMuc.ColumnEdit = memoEdit;
            }
        }

        #region Tìm kiếm

        private void btn_Search_Click(object sender, EventArgs e)
        {
            GetDataSearch();
        }

        #endregion Tìm kiếm

        #region Update và Create

        private void tree_ChuongTrinhMucTieuQuocGia_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.OldNode == null) return;
            var api = ConfigManager.GetAPIByService<IChuongTrinhMucTieuQuocGiasApi>();
            var data = (ChuongTrinhMucTieuQuocGiaDto)tree_danhsachchuongtrinhmuctieuquocgia.GetDataRecordByNode(e.OldNode);

            if (data.TenChuongTrinhMucTieuQuocGia == null || data.TenChuongTrinhMucTieuQuocGia == "")
            {
                //Nếu không nhập Mã số sẽ hiển thị thông báo và quay về dòng cũ
                GGFunctions.ShowMessage("Trường tên nguồn vốn là trường bắt buộc, vui lòng kiểm tra lại !");
                tree_danhsachchuongtrinhmuctieuquocgia.FocusedNode = e.OldNode;
            }
            else
            {
                if (data.Id == Guid.Empty)
                {
                    //Xử lý thêm mới

                    var newChuongTrinhMucTieuQuocGia = new CreateUpdateChuongTrinhMucTieuQuocGiaDto
                    {
                        TenChuongTrinhMucTieuQuocGia = data.TenChuongTrinhMucTieuQuocGia,
                        MaChuongTrinhMucTieuQuocGia = data.MaChuongTrinhMucTieuQuocGia,
                        ParentId = data.ParentId
                    };
                    //Thêm dữ liệu mới
                    api.CreateAsync(newChuongTrinhMucTieuQuocGia).GetAwaiter().GetResult();
                    ReloadData();
                }
                else
                {
                    var chuongTrinhMucTieuQuocGia = new CreateUpdateChuongTrinhMucTieuQuocGiaDto
                    {
                        TenChuongTrinhMucTieuQuocGia = data.TenChuongTrinhMucTieuQuocGia,
                        MaChuongTrinhMucTieuQuocGia = data.MaChuongTrinhMucTieuQuocGia,
                        ParentId = data.ParentId
                    };
                    //Xử lý update
                    api.UpdateAsync(data.Id, chuongTrinhMucTieuQuocGia);
                }
            }
        }

        #endregion Update và Create

        #region Xóa dứ liệu

        private void Tree_ChuongTrinhMucTieuQuocGia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ChuongTrinhMucTieuQuocGiaDto ChuongTrinhMucTieuQuocGia = (ChuongTrinhMucTieuQuocGiaDto)tree_danhsachchuongtrinhmuctieuquocgia.GetDataRecordByNode(tree_danhsachchuongtrinhmuctieuquocgia.FocusedNode);
                Delete(ChuongTrinhMucTieuQuocGia);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            ChuongTrinhMucTieuQuocGiaDto ChuongTrinhMucTieuQuocGia = (ChuongTrinhMucTieuQuocGiaDto)tree_danhsachchuongtrinhmuctieuquocgia.GetDataRecordByNode(tree_danhsachchuongtrinhmuctieuquocgia.FocusedNode);
            Delete(ChuongTrinhMucTieuQuocGia);
        }

        private void Delete(ChuongTrinhMucTieuQuocGiaDto ChuongTrinhMucTieuQuocGia)
        {
            if (GGFunctions.ShowMessageYesNo("Bạn có muốn xóa dữ liệu") == DialogResult.No)
                return;
            var api = ConfigManager.GetAPIByService<IChuongTrinhMucTieuQuocGiasApi>();
            api.DeleteAsync(ChuongTrinhMucTieuQuocGia.Id).GetAwaiter().GetResult();
            ReloadData();
        }

        #endregion Xóa dứ liệu

        #region Xuất excel
        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Chọn thư mục lưu";
            sf.Filter = "Text files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            sf.FileName = "danhmucchuongtrinhmuctieuquocgia_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                XlsxExportOptionsEx options = new XlsxExportOptionsEx();
                options.CustomizeSheetHeader += Options_CustomizeSheetHeader;

                tree_danhsachchuongtrinhmuctieuquocgia.ExportToXlsx(sf.FileName, options);
                if (File.Exists(sf.FileName))
                {
                    GGFunctions.StartProcess(sf.FileName);
                }
            }
        }

        private void Options_CustomizeSheetHeader(ContextEventArgs e)
        {
            int index = 0;
            if (tree_danhsachchuongtrinhmuctieuquocgia.Columns.Count > 0)
            {
                index = tree_danhsachchuongtrinhmuctieuquocgia.Columns.Count - 1;
            }
                
            CellObject row1 = new CellObject();
            row1.Value = "DANH MỤC CHƯƠNG TRÌNH MỤC TIÊU QUỐC GIA";
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