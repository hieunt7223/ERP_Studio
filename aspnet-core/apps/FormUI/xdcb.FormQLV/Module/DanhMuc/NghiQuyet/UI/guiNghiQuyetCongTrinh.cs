using System;
using System.Collections.Generic;
using System.Windows.Forms;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;
using xdcb.FormServices.SDK;
using System.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.ViewInfo;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using xdcb.Common.DanhMuc.CongTrinhDtos;
using Volo.Abp.Application.Dtos;
using System.Linq;
using xdcb.Common;

namespace xdcb.FormQLV.Module.DanhMuc.NghiQuyet.UI
{
    public partial class guiNghiQuyetCongTrinh : GGScreenDetail
    {
        #region property
        public List<CongTrinhDto> listNghiQuyetCongTrinh = new List<CongTrinhDto>();
        RepositoryItemCheckEdit _checkEdit;
        #endregion
        public guiNghiQuyetCongTrinh(CongTrinhDto congTrinh, bool isCreate)
        {
            InitializeComponent();
            SetValueTreeList();

            TreeListNode nodeID = list_NghiQuyetCongTrinh.FindNodeByKeyID(congTrinh.Id);
            if (nodeID != null)
            {
                nodeID.Checked = true;
                list_NghiQuyetCongTrinh.FocusedNode = nodeID;
                nodeID.Expanded = true;
            }
            btn_DongY.Visible = isCreate;
        }
        #region SetValueTreeList
        public void SetValueTreeList()
        {
            List<CongTrinhDto> data = new List<CongTrinhDto>();
            List<CongTrinhDto> exist = new List<CongTrinhDto>();

            var apiCongTrinh = ConfigManager.GetAPIByService<ICongTrinhsApi>();
            var apiNghiQuyet = ConfigManager.GetAPIByService<INghiQuyetsApi>();
            var items = apiCongTrinh.GetListAsync(new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 }).GetAwaiter().GetResult().Items;
            var listNghiQuyet = apiNghiQuyet.SearchAsync(new ConditionSearch { keyword = "", SkipCount = 0, MaxResultCount = 1000 }).GetAwaiter().GetResult().Items;
            foreach(var item in listNghiQuyet)
            {
                var nghiQuyet = apiNghiQuyet.GetAsync(item.Id).GetAwaiter().GetResult();
                foreach(var item1 in items)
                {
                    var isExist = nghiQuyet.NghiQuyetCongTrinhs.FirstOrDefault(x => x.CongTrinhId == item1.Id);
                    if (isExist != null)
                    {
                        exist.Add(item1);
                    }
                 
                }
                
            }
             foreach(var item in items)
            {
                var isExist = exist.FirstOrDefault(x=>x.Id==item.Id);
                if (isExist == null)
                {
                    data.Add(item);
                }
            }
          


            string path = ConfigManager.PathTreeListXML() + ModuleName.NghiQuyet + @"\" + TemplateDesignTreeList.TreeList_CongTrinh.ToString();
            list_NghiQuyetCongTrinh.InitializeControlByDesign(path, null);

            list_NghiQuyetCongTrinh.DataSource = data;
            list_NghiQuyetCongTrinh.ExpandAll();
            list_NghiQuyetCongTrinh.CollapseToLevel(1);
            list_NghiQuyetCongTrinh.OptionsSelection.MultiSelect = true;
            list_NghiQuyetCongTrinh.OptionsSelection.SelectNodesOnRightClick = true;
            list_NghiQuyetCongTrinh.OptionsView.ShowCheckBoxes = true;
            list_NghiQuyetCongTrinh.OptionsCustomization.AllowSort = false;
            _checkEdit = (RepositoryItemCheckEdit)list_NghiQuyetCongTrinh.RepositoryItems.Add("CheckEdit");
            list_NghiQuyetCongTrinh.CustomDrawColumnHeader += Tree_CustomDrawColumnHeader;
            list_NghiQuyetCongTrinh.MouseUp += Tree_MouseUp;
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

            List<CongTrinhDto> listData = new List<CongTrinhDto>();
            var node = list_NghiQuyetCongTrinh.GetAllCheckedNodes();
            foreach (TreeListNode item in node)
            {
                CongTrinhDto obj = list_NghiQuyetCongTrinh.GetDataRecordByNode(item) as CongTrinhDto;
                if (obj != null)
                {
                    if (obj.Id != Guid.Empty)
                        listData.Add(obj);
                }
            }
            if (listData == null || listData.Count == 0)
            {
                GGFunctions.ShowMessage("Vui lòng chọn đơn vị hành chính!");
                return;
            }
            listNghiQuyetCongTrinh = listData;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}