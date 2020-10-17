using DevExpress.Export;
using DevExpress.Printing.ExportHelpers;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using xdcb.Common;
using xdcb.Common.DanhMuc.LoaiKhoanDtos;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.SDK;
using xdcb.FormServices.Shared;

namespace xdcb.FormQLV.Module.DanhMuc.LoaiKhoan.UI
{
    public partial class frmLoaiKhoan : GGScreen
    {
        #region Property

        public LoaiKhoanDto mainObject;

        #endregion Property

        public frmLoaiKhoan()
        {
            InitializeComponent();
            InitControl();
            ReloadData();
        }

        #region InitControl

        public void InitControl()
        {
            string path = ConfigManager.PathTreeListXML() + ModuleName.LoaiKhoan + @"\" + TemplateDesignTreeList.TreeList_DanhSachLoaiKhoan.ToString();
            tree_danhsachloaikhoan.InitializeControlByDesign(path, CreateDesignTree.NewTreeList.ToString());
            tree_danhsachloaikhoan.CustomColumnDisplayText += tree_danhsachloaikhoan_CustomColumnDisplayText;
            tree_danhsachloaikhoan.KeyUp += Tree_LoaiKhoan_KeyUp;
            tree_danhsachloaikhoan.OptionsDragAndDrop.AcceptOuterNodes = true;
            tree_danhsachloaikhoan.RootValue = Guid.Empty;
            tree_danhsachloaikhoan.FocusedNodeChanged += tree_danhsachloaikhoan_FocusedNodeChanged;
            tree_danhsachloaikhoan.AfterDragNode += Tree_danhsachloaikhoan_AfterDragNode;
            tree_danhsachloaikhoan.PopupMenuShowing += Tree_danhsachloaikhoan_PopupMenuShowing;
            tree_danhsachloaikhoan.TreeListMenuItemClick += Tree_danhsachloaikhoan_TreeListMenuItemClick;
            tree_danhsachloaikhoan.StateImageList = imageCollection1;
            tree_danhsachloaikhoan.GetStateImage += TreeList_GetStateImage;
        }

        private void TreeList_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
             e.NodeImageIndex = 0;
        }

        private void Tree_danhsachloaikhoan_TreeListMenuItemClick(object sender, TreeListMenuItemClickEventArgs e)
        {
            //Kiểm tra nếu thêm con vào khoản thì không cho
            LoaiKhoanDto loaiKhoan = (LoaiKhoanDto)tree_danhsachloaikhoan.GetDataRecordByNode(tree_danhsachloaikhoan.FocusedNode);
            if (e.MenuItem.Caption == "Thêm khoản" && loaiKhoan.LoaiLoaiKhoan == 2)
            {
                GGFunctions.ShowMessage("Không thể thêm khoản trong khoản, vui lòng kiểm tra lại !");
                ReloadData();
                return;
            }
        }

        private void Tree_danhsachloaikhoan_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            //Set text của menu
            var loaiKhoanMenu = e.Menu.Items;
            if (loaiKhoanMenu.Count > 0)
            {
                loaiKhoanMenu[0].Caption = "Thêm loại";
                loaiKhoanMenu[1].Caption = "Thêm khoản";
            }

        }

        private void Tree_danhsachloaikhoan_AfterDragNode(object sender, DevExpress.XtraTreeList.AfterDragNodeEventArgs e)
        {
            LoaiKhoanDto loaiKhoan = (LoaiKhoanDto)tree_danhsachloaikhoan.GetDataRecordByNode(tree_danhsachloaikhoan.FocusedNode);
            var api = ConfigManager.GetAPIByService<ILoaiKhoansApi>();
            //Kiểm tra phần tử cha nếu là Khoản thì không cho phép
            var parent = e.Node.ParentNode;
            if (parent != null)
            {
                var item = (LoaiKhoanDto)tree_danhsachloaikhoan.GetDataRecordByNode(parent);
                if (item.LoaiLoaiKhoan == 2)
                {
                    GGFunctions.ShowMessage("Khoản không thể là cha, vui lòng kiểm tra lại !");
                    ReloadData();
                    return;
                }
            }
            //Nếu là loại và có chứa khoản thì không cho phép làm con
            if (e.Node.HasChildren && loaiKhoan.LoaiLoaiKhoan == 1 && loaiKhoan.LoaiKhoanChaID != Guid.Empty)
            {
                GGFunctions.ShowMessage("Loại không thể là con khi chứa khoản, vui lòng kiểm tra lại !");
                ReloadData();
                return;
            }
            if (parent != null)
            {
                if (loaiKhoan.LoaiKhoanChaID != Guid.Empty)
                {
                    loaiKhoan.LoaiLoaiKhoan = 2;
                }
                else
                {
                    loaiKhoan.LoaiLoaiKhoan = 1;
                }
            }
            else
            {
                loaiKhoan.LoaiLoaiKhoan = 1;
                loaiKhoan.LoaiKhoanChaID = null;
            }

            //Lưu dữ liệu
            CreateUpdateLoaiKhoanDto createUpdateLoaiKhoanDto = new CreateUpdateLoaiKhoanDto
            {
                LoaiKhoanChaID = loaiKhoan.LoaiKhoanChaID,
                TenLoaiKhoan = loaiKhoan.TenLoaiKhoan,
                GhiChu = loaiKhoan.GhiChu,
                LoaiLoaiKhoan = (LoaiKhoanType)loaiKhoan.LoaiLoaiKhoan,
                MaSo = loaiKhoan.MaSo
            };
            api.UpdateAsync(loaiKhoan.Id, createUpdateLoaiKhoanDto).GetAwaiter().GetResult();
        }

        private void tree_danhsachloaikhoan_CustomColumnDisplayText(object sender, DevExpress.XtraTreeList.CustomColumnDisplayTextEventArgs e)
        {
            var isLoai = true;

            if (e.Node.ParentNode != null)
            {
                isLoai = false;
            }

            if (e.Column.FieldName == LoaiKhoanColumn.LoaiLoaiKhoan.ToString())
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString() != "0")
                    {
                        if (e.Value.ToString() == "1")
                        {
                            e.DisplayText = "Loại";
                        }
                        else
                        {
                            e.DisplayText = "Khoản";
                        }
                    }
                    else
                    {
                        if (isLoai)
                        {
                            e.DisplayText = "Loại";
                        }
                        else
                        {
                            e.DisplayText = "Khoản";
                        }
                    }
                }
            }
        }

        private void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (GGFunctions.ShowMessageYesNo("Bạn có muốn xóa dữ liệu") == DialogResult.No)
                    return;
                GridView gridView = (GridView)sender;
                var api = ConfigManager.GetAPIByService<ILoaiKhoansApi>();
                api.DeleteAsync(mainObject.Id).GetAwaiter().GetResult();
                gridView.DeleteRow(gridView.FocusedRowHandle);
            }
        }

        private void Gridview_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView dgvSearchResults = (GridView)sender;
            if (dgvSearchResults.FocusedRowHandle >= 0)
            {
                mainObject = (LoaiKhoanDto)dgvSearchResults.GetRow(dgvSearchResults.FocusedRowHandle);
            }
        }

        #endregion InitControl

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

            var api = ConfigManager.GetAPIByService<ILoaiKhoansApi>();
            List<LoaiKhoanDto> loaiKhoanDtos = new List<LoaiKhoanDto>();
            loaiKhoanDtos.Add(new LoaiKhoanDto());
            var data = api.SearchAsync(new ConditionSearch { keyword = tuKhoa, SkipCount = 0, MaxResultCount = 1000 }).GetAwaiter().GetResult();
            tree_danhsachloaikhoan.DataSource = data;
            tree_danhsachloaikhoan.RefreshDataSource();
            tree_danhsachloaikhoan.ExpandAll();
            TreeListColumn columnDanhMuc = tree_danhsachloaikhoan.Columns["GhiChu"];
            if (columnDanhMuc != null)
            {
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

        private void tree_danhsachloaikhoan_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.OldNode == null) return;
            var api = ConfigManager.GetAPIByService<ILoaiKhoansApi>();
            var data = (LoaiKhoanDto)tree_danhsachloaikhoan.GetDataRecordByNode(e.OldNode);

            if (data.MaSo == null || data.MaSo == "")
            {
                //Nếu không nhập Mã số sẽ hiển thị thông báo và quay về dòng cũ
                GGFunctions.ShowMessage("Trường mã số là trường bắt buộc, vui lòng kiểm tra lại !");
                tree_danhsachloaikhoan.FocusedNode = e.OldNode;
            }
            else if (data.TenLoaiKhoan == null || data.TenLoaiKhoan == "")
            {
                //Nếu không nhập tên gọi sẽ hiển thị thông báo và quay về dòng cũ
                GGFunctions.ShowMessage("Trường tên gọi là trường bắt buộc, vui lòng kiểm tra lại !");
                tree_danhsachloaikhoan.FocusedNode = e.OldNode;
            }
            else
            {
                if (data.Id == Guid.Empty)
                {
                    //Xử lý thêm mới

                    //Kiểm tra xem là loại hay khoản
                    if (data.LoaiKhoanChaID == null)
                    {
                        data.LoaiLoaiKhoan = 1;
                    }
                    else
                    {
                        data.LoaiLoaiKhoan = 2;
                    }
                    var newLoaiKhoan = new CreateUpdateLoaiKhoanDto
                    {
                        MaSo = data.MaSo,
                        GhiChu = data.GhiChu,
                        LoaiKhoanChaID = data.LoaiKhoanChaID,
                        TenLoaiKhoan = data.TenLoaiKhoan,
                        LoaiLoaiKhoan = (LoaiKhoanType)data.LoaiLoaiKhoan
                    };
                    //Thêm dữ liệu mới
                    api.Create(newLoaiKhoan).GetAwaiter().GetResult();
                    ReloadData();
                }
                else
                {
                    var newLoaiKhoan = new CreateUpdateLoaiKhoanDto
                    {
                        MaSo = data.MaSo,
                        GhiChu = data.GhiChu,
                        LoaiKhoanChaID = data.LoaiKhoanChaID,
                        TenLoaiKhoan = data.TenLoaiKhoan,
                        LoaiLoaiKhoan = (LoaiKhoanType)data.LoaiLoaiKhoan
                    };
                    //Xử lý update
                    api.UpdateAsync(data.Id, newLoaiKhoan);
                }
            }
        }

        #endregion Update và Create

        #region Xóa dứ liệu

        private void Tree_LoaiKhoan_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                LoaiKhoanDto loaiKhoan = (LoaiKhoanDto)tree_danhsachloaikhoan.GetDataRecordByNode(tree_danhsachloaikhoan.FocusedNode);
                Delete(loaiKhoan);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            LoaiKhoanDto loaiKhoan = (LoaiKhoanDto)tree_danhsachloaikhoan.GetDataRecordByNode(tree_danhsachloaikhoan.FocusedNode);
            Delete(loaiKhoan);
        }

        private void Delete(LoaiKhoanDto loaiKhoan)
        {
            if (GGFunctions.ShowMessageYesNo("Bạn có muốn xóa dữ liệu") == DialogResult.No)
                return;
            var api = ConfigManager.GetAPIByService<ILoaiKhoansApi>();
            api.DeleteAsync(loaiKhoan.Id).GetAwaiter().GetResult();
            ReloadData();
        }

        #endregion Xóa dứ liệu

        #region Xuất excel
        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Chọn thư mục lưu";
            sf.Filter = "Text files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            sf.FileName = "danhmucloaikhoan_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                XlsxExportOptionsEx options = new XlsxExportOptionsEx();

                options.CustomizeSheetHeader += Options_CustomizeSheetHeader;
                options.CustomizeCell += options_CustomizeCell;
                tree_danhsachloaikhoan.ExportToXlsx(sf.FileName, options);
                if (File.Exists(sf.FileName))
                {
                    GGFunctions.StartProcess(sf.FileName);
                }
            }
        }

        private void Options_CustomizeSheetHeader(ContextEventArgs e)
        {
            int index = 0;
            if (tree_danhsachloaikhoan.Columns.Count > 0)
            {
                index = tree_danhsachloaikhoan.Columns.Count - 1;
            }

            CellObject row1 = new CellObject();
            row1.Value = "DANH MỤC LOẠI - KHOẢN";
            XlFormattingObject rowFormatting1 = new XlFormattingObject();
            rowFormatting1.Font = new XlCellFont { Bold = true, Size = 14 };
            rowFormatting1.Alignment = new DevExpress.Export.Xl.XlCellAlignment { HorizontalAlignment = DevExpress.Export.Xl.XlHorizontalAlignment.Center, VerticalAlignment = DevExpress.Export.Xl.XlVerticalAlignment.Top };
            row1.Formatting = rowFormatting1;
            e.ExportContext.AddRow(new[] { row1 });
            e.ExportContext.MergeCells(new DevExpress.Export.Xl.XlCellRange(new DevExpress.Export.Xl.XlCellPosition(0, 0), new DevExpress.Export.Xl.XlCellPosition(index, 0)));
        }

        private void options_CustomizeCell(CustomizeCellEventArgs e)
        {

            if (e.ColumnFieldName == LoaiKhoanColumn.LoaiLoaiKhoan.ToString())
            {
                if (e.Value.ToString() == "1")
                {
                    e.Value = "Loại";
                    e.Handled = true;
                }
                if (e.Value.ToString() == "2")
                {
                    e.Value = "Khoản";
                    e.Handled = true;
                }
            }

        }
        #endregion
    }
}