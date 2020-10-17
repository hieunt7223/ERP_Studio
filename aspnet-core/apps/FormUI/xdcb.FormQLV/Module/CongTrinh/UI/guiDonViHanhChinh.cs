using System;
using System.Collections.Generic;
using System.Windows.Forms;
using xdcb.FormServices.BaseForm;
using xdcb.Common.DanhMuc.DonViHanhChinhDtos;
using xdcb.FormServices.Shared;
using xdcb.FormServices.SDK;
using System.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.ViewInfo;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;

namespace xdcb.FormQLV.CongTrinh
{
    public partial class guiDonViHanhChinh : GGScreenDetail
    {
        #region property
        public List<DonViHanhChinhDto> _listDonViHanhChinh = new List<DonViHanhChinhDto>();
        RepositoryItemCheckEdit _checkEdit;
        #endregion
        public guiDonViHanhChinh(DonViHanhChinhDto donViHanhChinh, bool isCreate)
        {
            InitializeComponent();
            SetValueTreeList();
            TreeListNode nodeID = tree_DonViHanhChinh.FindNodeByKeyID(donViHanhChinh.Id);
            if (nodeID != null)
            {
                nodeID.Checked = true;
                tree_DonViHanhChinh.FocusedNode = nodeID;
                nodeID.Expanded = true;
            }
            btn_DongY.Visible = isCreate;
        }

        #region SetValueTreeList
        public void SetValueTreeList()
        {
            List<DonViHanhChinhDto> data = new List<DonViHanhChinhDto>();

            var apiDonViHanhChinh = ConfigManager.GetAPIByService<IDonViHanhChinhsApi>();
            data = apiDonViHanhChinh.GetAll().GetAwaiter().GetResult();
            string path = ConfigManager.PathTreeListXML() + ModuleName.CongTrinh + @"\" + TemplateDesignTreeList.TreeList_DonViHanhChinh.ToString();
            tree_DonViHanhChinh.InitializeControlByDesign(path, null);

            tree_DonViHanhChinh.DataSource = data;
            tree_DonViHanhChinh.ExpandAll();
            tree_DonViHanhChinh.CollapseToLevel(1);
            tree_DonViHanhChinh.OptionsSelection.MultiSelect = true;
            tree_DonViHanhChinh.OptionsSelection.SelectNodesOnRightClick = true;
            tree_DonViHanhChinh.OptionsView.ShowCheckBoxes = true;
            tree_DonViHanhChinh.OptionsCustomization.AllowSort = false;
            _checkEdit = (RepositoryItemCheckEdit)tree_DonViHanhChinh.RepositoryItems.Add("CheckEdit");
            tree_DonViHanhChinh.CustomDrawColumnHeader += Tree_CustomDrawColumnHeader;
            tree_DonViHanhChinh.MouseUp += Tree_MouseUp;
        }

        private void Tree_MouseUp(object sender, MouseEventArgs e)
        {
            TreeList tree = sender as TreeList;
            Point pt = new Point(e.X, e.Y);
            TreeListHitInfo hit = tree.GetHitInfo(pt);
            if (hit.Column != null)
            {
                tree.BeginUpdate();
                ColumnInfo info = tree.ViewInfo.ColumnsInfo[hit.Column];
                Rectangle checkRect = new Rectangle(info.Bounds.Left + 3, info.Bounds.Top + 3, 12, 12);
                if (checkRect.Contains(pt))
                {
                    if (IsAllSelected(tree))
                        tree.UncheckAll();
                    else
                        tree.CheckAll();
                }
                tree.EndUpdate();
            }
        }

        private void Tree_CustomDrawColumnHeader(object sender, CustomDrawColumnHeaderEventArgs e)
        {
            if (e.Column != null && e.Column.VisibleIndex == 0)
            {
                Rectangle checkRect = new Rectangle(e.Bounds.Left + 3, e.Bounds.Top + 3, 12, 12);
                ColumnInfo info = (ColumnInfo)e.ObjectArgs;
                if (info.CaptionRect.Left < 30)
                    info.CaptionRect = new Rectangle(new Point(info.CaptionRect.Left + 15, info.CaptionRect.Top), info.CaptionRect.Size);
                e.Painter.DrawObject(info);
                DrawCheckBox(e.Graphics, _checkEdit, checkRect, IsAllSelected(sender as TreeList));
                e.Handled = true;
            }
        }

        protected void DrawCheckBox(Graphics g, RepositoryItemCheckEdit edit, Rectangle r, bool Checked)
        {
            CheckEditViewInfo info;
            CheckEditPainter painter;
            ControlGraphicsInfoArgs args;
            info = edit.CreateViewInfo() as CheckEditViewInfo;
            painter = edit.CreatePainter() as CheckEditPainter;
            info.EditValue = Checked;
            info.Bounds = r;
            info.CalcViewInfo(g);
            args = new ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
            painter.Draw(args);
            args.Cache.Dispose();
        }

        private bool IsAllSelected(TreeList tree)
        {
            bool isCheck = false;
            var node = tree.GetAllCheckedNodes();
            if (node != null && node.Count > 0)
            {
                isCheck = true;
            }
            return isCheck;
        }
        #endregion

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btn_DongY_Click(object sender, EventArgs e)
        {

            List<DonViHanhChinhDto> listData = new List<DonViHanhChinhDto>();
            var node = tree_DonViHanhChinh.GetAllCheckedNodes();
            foreach (TreeListNode item in node)
            {
                DonViHanhChinhDto obj = tree_DonViHanhChinh.GetDataRecordByNode(item) as DonViHanhChinhDto;
                if (obj != null)
                {
                    if (obj.Id != Guid.Empty)
                        listData.Add(obj);
                }
            }
            if (listData == null || listData.Count == 0)
            {
                GGFunctions.ShowMessage("Vui lòng chọn địa điểm xây dựng!");
                return;
            }
            _listDonViHanhChinh = listData;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}