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
using xdcb.Common.DanhMuc.NguonVonDtos;
using xdcb.FormServices.Shared;
using xdcb.FormServices.SDK;
using xdcb.Common;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraPrinting;
using System.IO;
using DevExpress.Export;
using DevExpress.Printing.ExportHelpers;

namespace xdcb.FormQLV.Module.DanhMuc.NguonVon.UI
{
    public partial class frmNguonVon : GGScreen
    {
        #region Property

        public NguonVonDto mainObject;

        #endregion Property
        public frmNguonVon()
        {
            InitializeComponent();
            InitControl();
            ReloadData();
        }

        public void InitControl()
        {
            string path = ConfigManager.PathTreeListXML() + ModuleName.NguonVon + @"\" + TemplateDesignTreeList.TreeList_DanhSachNguonVon.ToString();
            tree_danhsachnguonvon.InitializeControlByDesign(path, CreateDesignTree.NewTreeList.ToString());
            tree_danhsachnguonvon.OptionsDragAndDrop.AcceptOuterNodes = true;
            tree_danhsachnguonvon.RootValue = Guid.Empty;
            tree_danhsachnguonvon.KeyUp += Tree_NguonVon_KeyUp;
            tree_danhsachnguonvon.PopupMenuShowing += Tree_danhsachnguonvon_PopupMenuShowing;
            tree_danhsachnguonvon.FocusedNodeChanged += tree_nguonVon_FocusedNodeChanged;
            tree_danhsachnguonvon.AfterDragNode += Tree_danhsachnguonvon_AfterDragNode;
            tree_danhsachnguonvon.StateImageList = imageCollection1;
            tree_danhsachnguonvon.GetStateImage += TreeList_GetStateImage;
        }

        private void TreeList_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            e.NodeImageIndex = 0;
        }

        private void Tree_danhsachnguonvon_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            //Set text của menu
            var nguonVon = e.Menu.Items;
            if (nguonVon.Count > 0)
            {
                nguonVon[0].Caption = "Thêm nguồn vốn";
                nguonVon[1].Caption = "Thêm nguồn vốn con";
            }
            
        }

        private void Tree_danhsachnguonvon_AfterDragNode(object sender, DevExpress.XtraTreeList.AfterDragNodeEventArgs e)
        {
            NguonVonDto nguonVon = (NguonVonDto)tree_danhsachnguonvon.GetDataRecordByNode(tree_danhsachnguonvon.FocusedNode);
            var api = ConfigManager.GetAPIByService<INguonVonsApi>();
            //Kiểm tra phần tử cha nếu là Khoản thì không cho phép
            var parent = e.Node.ParentNode;
            
            if (parent == null)
            {
                nguonVon.ParentId = null;
            }
            //Lưu dữ liệu
            CreateUpdateNguonVonDto createUpdateNguonVonDto = new CreateUpdateNguonVonDto
            {
                MaNguonVon = nguonVon.MaNguonVon,
                TenNguonVon = nguonVon.TenNguonVon,
                ParentId = nguonVon.ParentId
            };
            api.UpdateAsync(nguonVon.Id, createUpdateNguonVonDto).GetAwaiter().GetResult();
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

            var api = ConfigManager.GetAPIByService<INguonVonsApi>();
            List<NguonVonDto> nguonVonDtos = new List<NguonVonDto>();
            var data = api.Search(tuKhoa).GetAwaiter().GetResult();
            tree_danhsachnguonvon.DataSource = data;
            tree_danhsachnguonvon.RefreshDataSource();
            tree_danhsachnguonvon.ExpandAll();
            TreeListColumn columnDanhMuc = tree_danhsachnguonvon.Columns["TenNguonVon"];
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

        private void tree_nguonVon_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.OldNode == null) return;
            var api = ConfigManager.GetAPIByService<INguonVonsApi>();
            var data = (NguonVonDto)tree_danhsachnguonvon.GetDataRecordByNode(e.OldNode);

            if (data.TenNguonVon == null || data.TenNguonVon == "")
            {
                //Nếu không nhập Mã số sẽ hiển thị thông báo và quay về dòng cũ
                GGFunctions.ShowMessage("Trường tên nguồn vốn là trường bắt buộc, vui lòng kiểm tra lại !");
                tree_danhsachnguonvon.FocusedNode = e.OldNode;
            }
            else
            {
                if (data.Id == Guid.Empty)
                {
                    //Xử lý thêm mới

                    var newNguonVon = new CreateUpdateNguonVonDto
                    {
                        TenNguonVon = data.TenNguonVon,
                        MaNguonVon = data.MaNguonVon,
                        ParentId = data.ParentId
                    };
                    //Thêm dữ liệu mới
                    api.CreateAsync(newNguonVon).GetAwaiter().GetResult();
                    ReloadData();
                }
                else
                {
                    var nguonVon = new CreateUpdateNguonVonDto
                    {
                        TenNguonVon = data.TenNguonVon,
                        MaNguonVon = data.MaNguonVon,
                        ParentId = data.ParentId
                    };
                    //Xử lý update
                    api.UpdateAsync(data.Id, nguonVon);
                }
            }
        }

        #endregion Update và Create

        #region Xóa dứ liệu

        private void Tree_NguonVon_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                NguonVonDto nguonVon = (NguonVonDto)tree_danhsachnguonvon.GetDataRecordByNode(tree_danhsachnguonvon.FocusedNode);
                Delete(nguonVon);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            NguonVonDto nguonVon = (NguonVonDto)tree_danhsachnguonvon.GetDataRecordByNode(tree_danhsachnguonvon.FocusedNode);
            Delete(nguonVon);
        }

        private void Delete(NguonVonDto nguonVon)
        {
            if (GGFunctions.ShowMessageYesNo("Bạn có muốn xóa dữ liệu") == DialogResult.No)
                return;
            var api = ConfigManager.GetAPIByService<INguonVonsApi>();
            api.DeleteAsync(nguonVon.Id).GetAwaiter().GetResult();
            ReloadData();
        }

        #endregion Xóa dứ liệu

        #region Xuất excel
        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Chọn thư mục lưu";
            sf.Filter = "Text files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            sf.FileName = "danhmucnguonvon_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                XlsxExportOptionsEx options = new XlsxExportOptionsEx();
                options.CustomizeSheetHeader += Options_CustomizeSheetHeader;

                tree_danhsachnguonvon.ExportToXlsx(sf.FileName, options);
                if (File.Exists(sf.FileName))
                {
                    GGFunctions.StartProcess(sf.FileName);
                }
            }
        }

        private void Options_CustomizeSheetHeader(ContextEventArgs e)
        {
            int index = 0;
            if (tree_danhsachnguonvon.Columns.Count > 0)
            {
                index = tree_danhsachnguonvon.Columns.Count - 1;
            }

            CellObject row1 = new CellObject();
            row1.Value = "DANH MỤC NGUỒN VỐN";
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