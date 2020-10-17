using System;
using System.Collections.Generic;
using System.Windows.Forms;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;
using xdcb.FormServices.SDK;
using xdcb.Common.DanhMuc.NguonVonDtos;
using System.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.ViewInfo;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;

namespace xdcb.FormQLV
{
    public partial class guiNguonVon : GGScreenDetail
    {
        #region property
        public List<NguonVonDto> listNguonVon = new List<NguonVonDto>();
        RepositoryItemCheckEdit _checkEdit;
        #endregion
        public guiNguonVon(List<NguonVonDto> listNguonVon)
        {
            InitializeComponent();
            SetValueTreeList();
            txt_TenNguonVon.EditValue = string.Empty;
            if (listNguonVon == null)
            {
                listNguonVon = new List<NguonVonDto>();
            }
            if (listNguonVon != null && listNguonVon.Count > 0)
            {
                listNguonVon.ForEach(o =>
                {
                    TreeListNode node = tree_NguonVon.FindNodeByKeyID(o.Id);
                    if (node != null)
                    {
                        node.Checked = true;
                    }

                });
                TreeListNode nodeID = tree_NguonVon.FindNodeByKeyID(listNguonVon[0].Id);
                if (nodeID != null)
                {
                    tree_NguonVon.FocusedNode = nodeID;
                    nodeID.Expanded = true;
                }
            }
        }

        #region SetValueTreeList
        public void SetValueTreeList()
        {
            string path = ConfigManager.PathTreeListXML() + @"UI\" + TemplateDesignTreeList.TreeList_UI_NguonVon.ToString();
            tree_NguonVon.InitializeControlByDesign(path, null);
            tree_NguonVon.DataSource = GetData();
            tree_NguonVon.ExpandAll();
            tree_NguonVon.CollapseToLevel(1);
            tree_NguonVon.OptionsSelection.MultiSelect = true;
            tree_NguonVon.OptionsSelection.SelectNodesOnRightClick = true;
            tree_NguonVon.OptionsView.ShowCheckBoxes = true;
            tree_NguonVon.OptionsCustomization.AllowSort = false;
            _checkEdit = (RepositoryItemCheckEdit)tree_NguonVon.RepositoryItems.Add("CheckEdit");
            tree_NguonVon.CustomDrawColumnHeader += Tree_NguonVon_CustomDrawColumnHeader;
            tree_NguonVon.MouseUp += Tree_NguonVon_MouseUp;
        }

        private void Tree_NguonVon_MouseUp(object sender, MouseEventArgs e)
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

        private void Tree_NguonVon_CustomDrawColumnHeader(object sender, CustomDrawColumnHeaderEventArgs e)
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
            List<NguonVonDto> listData = new List<NguonVonDto>();
            var node = tree_NguonVon.GetAllCheckedNodes();
            foreach (TreeListNode item in node)
            {
                NguonVonDto obj = tree_NguonVon.GetDataRecordByNode(item) as NguonVonDto;
                if (obj != null)
                {
                    if (obj.Id != Guid.Empty)
                        listData.Add(obj);
                }
            }
            if (listData == null || listData.Count == 0)
            {
                GGFunctions.ShowMessage("Vui lòng chọn nguồn vốn!");
                return;
            }
            listNguonVon = listData;
            DialogResult = DialogResult.OK;
            Close();
        }

        #region Search
        private void btn_Search_Click(object sender, EventArgs e)
        {
            tree_NguonVon.DataSource = GetData();
            tree_NguonVon.ExpandAll();
            tree_NguonVon.CollapseToLevel(1);
        }

        private List<NguonVonDto> GetData()
        {
            string strTenNguonVon = string.Empty;
            if (txt_TenNguonVon.EditValue != null)
            {
                strTenNguonVon = txt_TenNguonVon.EditValue.ToString();
            }
            var api = ConfigManager.GetAPIByService<INguonVonsApi>();
            List<NguonVonDto> data = api.Search(strTenNguonVon).GetAwaiter().GetResult();
            return data;
        }
        #endregion

    }
}