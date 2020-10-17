using System;
using System.Collections.Generic;
using System.Windows.Forms;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;
using xdcb.FormServices.SDK;
using xdcb.Common.DanhMuc.CongTrinhDtos;
using System.Linq;
using System.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.ViewInfo;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;

namespace xdcb.FormQLV
{
    public partial class guiCongTrinh : GGScreenDetail
    {
        #region property
        public List<CongTrinhDto> _listCongTrinh = new List<CongTrinhDto>();
        private List<Guid> _listGuidCongTrinh = new List<Guid>();
        private int _nam;
        RepositoryItemCheckEdit _checkEdit;
        #endregion
        public guiCongTrinh(List<Guid> listGuid, int nam)
        {
            InitializeComponent();
            _listGuidCongTrinh = listGuid;
            _nam = nam;
            if (_nam > 0)
                gg_danhsach.Text += " năm " + nam;
            SetValueTreeList();
            txt_TenCongTrinh.EditValue = string.Empty;
        }

        #region SetValueTreeList
        public void SetValueTreeList()
        {
            string path = ConfigManager.PathTreeListXML() + @"UI\" + TemplateDesignTreeList.TreeList_UI_CongTrinh.ToString();
            tree_CongTrinh.InitializeControlByDesign(path, null);
            tree_CongTrinh.DataSource = GetData();
            tree_CongTrinh.ExpandAll();
            tree_CongTrinh.CollapseToLevel(1);
            tree_CongTrinh.OptionsSelection.MultiSelect = true;
            tree_CongTrinh.OptionsSelection.SelectNodesOnRightClick = true;
            tree_CongTrinh.OptionsView.ShowCheckBoxes = true;
            tree_CongTrinh.OptionsCustomization.AllowSort = false;
            _checkEdit = (RepositoryItemCheckEdit)tree_CongTrinh.RepositoryItems.Add("CheckEdit");
            tree_CongTrinh.CustomDrawColumnHeader += Tree_NguonVon_CustomDrawColumnHeader;
            tree_CongTrinh.MouseUp += Tree_NguonVon_MouseUp;
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
            List<CongTrinhDto> listData = new List<CongTrinhDto>();
            var node = tree_CongTrinh.GetAllCheckedNodes();
            foreach (TreeListNode item in node)
            {
                CongTrinhDto obj = tree_CongTrinh.GetDataRecordByNode(item) as CongTrinhDto;
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
            _listCongTrinh = listData;
            DialogResult = DialogResult.OK;
            Close();
        }

        #region Search
        private void btn_Search_Click(object sender, EventArgs e)
        {
            tree_CongTrinh.DataSource = GetData();
            tree_CongTrinh.ExpandAll();
            tree_CongTrinh.CollapseToLevel(1);
        }

        private List<CongTrinhDto> GetData()
        {
            List<CongTrinhDto> listData = new List<CongTrinhDto>();
            string strTenCongTrinh = string.Empty;
            if (txt_TenCongTrinh.EditValue != null)
            {
                strTenCongTrinh = txt_TenCongTrinh.EditValue.ToString();
            }
            var api = ConfigManager.GetAPIByService<ICongTrinhsApi>();
            var data = api.GetSearchData(strTenCongTrinh, Guid.Empty,0).GetAwaiter().GetResult();
            if (data != null)
            {
                listData = data.Where(x => !_listGuidCongTrinh.Contains(x.Id)
                                        && Convert.ToDateTime(x.ThoiGianThucHienTuNgay).Date.Year <= _nam
                                        && Convert.ToDateTime(x.ThoiGianThucHienDenNgay).Date.Year >= _nam
                                      ).ToList();
            }
            return listData;
        }
        #endregion

    }
}