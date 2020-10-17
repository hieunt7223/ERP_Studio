using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using xdcb.FormServices.Component;
using xdcb.FormServices.Shared;
using xdcb.QuanLyVon.KeHoachTongNguon.Dtos;
using xdcb.QuanLyVon.KeHoachTongNguonChiTiet.Dtos;

namespace xdcb.FormQLV.KeHoachTongNguon
{
    public class KeHoachVonChiTietCreateTreeList : GGTreeList
    {
        public override void InitializeControl()
        {
            ExpandAll();
            OptionsView.ShowSummaryFooter = true;
            ForceInitialize();

            #region Phân cấp
            this.ParentFieldName = KeHoachTongNguonChiTietsColumn.NguonVonChaId.ToString();
            this.KeyFieldName = KeHoachTongNguonChiTietsColumn.NguonVonId.ToString();
            this.RootValue = Guid.Empty;
            #endregion
            InitTreeListColumns();

            this.NodeCellStyle += KeHoachVonChiTietCreateTreeList_NodeCellStyle;
            this.CustomNodeCellEdit += KeHoachVonChiTietCreateTreeList_CustomNodeCellEdit;
        }


        #region Custom

        private void KeHoachVonChiTietCreateTreeList_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            var tree = sender as TreeList;
            TreeListColumn column = e.Column;
            if (column != null && (column.FieldName == KeHoachTongNguonChiTietsColumn.KeHoachDauNam.ToString()
                                    || column.FieldName == KeHoachTongNguonChiTietsColumn.KeHoachDauNamDuocDuyet.ToString()
                                    || column.FieldName == KeHoachTongNguonChiTietsColumn.KeHoachBoSung.ToString()
                                    || column.FieldName == KeHoachTongNguonChiTietsColumn.KeHoachBoSungDuocDuyet.ToString()
                                    || column.FieldName == KeHoachTongNguonChiTietsColumn.DieuChinhGiam.ToString()
                                    || column.FieldName == KeHoachTongNguonChiTietsColumn.DieuChinhTang.ToString()
                                    ))
            {
                bool isReadOnly = false;
                List<KeHoachTongNguonChiTietDto> moduleObject = (List<KeHoachTongNguonChiTietDto>)tree.DataSource;
                var obj = (KeHoachTongNguonChiTietDto)tree.GetDataRecordByNode(e.Node);
                if (obj != null && moduleObject != null)
                {
                    if (moduleObject.Where(x => x.NguonVonChaId == obj.NguonVonId).ToList().Count() > 0)
                    {
                        isReadOnly = true;
                    }
                }
                RepositoryItemTextEdit repositoryItem = new RepositoryItemTextEdit();
                repositoryItem.EditFormat.FormatType = FormatType.Numeric;
                repositoryItem.EditFormat.FormatString = FormatValue.N3;
                repositoryItem.DisplayFormat.FormatType = FormatType.Numeric;
                repositoryItem.DisplayFormat.FormatString = FormatValue.N3;
                repositoryItem.Mask.MaskType = MaskType.Numeric;
                repositoryItem.Mask.UseMaskAsDisplayFormat = true;
                repositoryItem.Mask.EditMask = "n3";
                repositoryItem.ReadOnly = isReadOnly;
                e.RepositoryItem = repositoryItem;
            }
        }
        private void KeHoachVonChiTietCreateTreeList_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            var tree = sender as TreeList;

            if (e.Node != null)
            {
                if (tree != null && tree.DataSource != null)
                {
                    List<KeHoachTongNguonChiTietDto> moduleObject = (List<KeHoachTongNguonChiTietDto>)tree.DataSource;
                    var obj = (KeHoachTongNguonChiTietDto)tree.GetDataRecordByNode(e.Node);
                    if (obj != null && moduleObject != null)
                    {
                        if (moduleObject.Where(x => x.NguonVonChaId == obj.NguonVonId).ToList().Count() > 0)
                        {

                            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                        }
                        else
                        {
                            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Regular);
                        }
                    }
                    else
                    {
                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Regular);

                    }

                }

            }
        }
        protected void InitTreeListColumns()
        {
            Columns.Clear();
            #region InitTreeListColumns
            AddTreeListColumns(0, KeHoachTongNguonChiTietsColumn.TenNguonVon.ToString(), KeHoachTongNguonChiTietsColumn.TenNguonVon.GetDescription(), true, false, true);
            AddTreeListColumns(1, KeHoachTongNguonChiTietsColumn.KeHoachDauNamTruoc.ToString(), KeHoachTongNguonChiTietsColumn.KeHoachDauNamTruoc.GetDescription(), true, false, true);
            AddTreeListColumns(2, KeHoachTongNguonChiTietsColumn.KeHoachBoSungNamTruoc.ToString(), KeHoachTongNguonChiTietsColumn.KeHoachBoSungNamTruoc.GetDescription(), true, false, true);
            AddTreeListColumns(3, KeHoachTongNguonChiTietsColumn.KeHoachDauNam.ToString(), KeHoachTongNguonChiTietsColumn.KeHoachDauNam.GetDescription(), true, false, true);
            AddTreeListColumns(4, KeHoachTongNguonChiTietsColumn.KeHoachDauNamDuocDuyet.ToString(), KeHoachTongNguonChiTietsColumn.KeHoachDauNamDuocDuyet.GetDescription(), true, false, true);
            AddTreeListColumns(5, KeHoachTongNguonChiTietsColumn.DieuChinhTang.ToString(), KeHoachTongNguonChiTietsColumn.DieuChinhTang.GetDescription(), true, false, true);
            AddTreeListColumns(6, KeHoachTongNguonChiTietsColumn.DieuChinhGiam.ToString(), KeHoachTongNguonChiTietsColumn.DieuChinhGiam.GetDescription(), true, false, true);
            AddTreeListColumns(7, KeHoachTongNguonChiTietsColumn.KeHoachBoSung.ToString(), KeHoachTongNguonChiTietsColumn.KeHoachBoSung.GetDescription(), true, false, true);
            AddTreeListColumns(8, KeHoachTongNguonChiTietsColumn.KeHoachBoSungDuocDuyet.ToString(), KeHoachTongNguonChiTietsColumn.KeHoachBoSungDuocDuyet.GetDescription(), true, false, true);
            AddTreeListColumns(9, KeHoachTongNguonChiTietsColumn.GhiChuSoDauNam.ToString(), KeHoachTongNguonChiTietsColumn.GhiChuSoDauNam.GetDescription(), true, false, true);
            AddTreeListColumns(10, KeHoachTongNguonChiTietsColumn.GhiChuUyBanDauNam.ToString(), KeHoachTongNguonChiTietsColumn.GhiChuUyBanDauNam.GetDescription(), true, false, true);
            AddTreeListColumns(11, KeHoachTongNguonChiTietsColumn.GhiChuSoDieuChinh.ToString(), KeHoachTongNguonChiTietsColumn.GhiChuSoDieuChinh.GetDescription(), true, false, true);
            AddTreeListColumns(12, KeHoachTongNguonChiTietsColumn.GhiChuUyBanDieuChinh.ToString(), KeHoachTongNguonChiTietsColumn.GhiChuUyBanDieuChinh.GetDescription(), true, false, true);
            #endregion

            OptionsBehavior.ImmediateEditor = true;
        }
        #endregion


        public void AddTreeListColumns(int visibleIndex, string fieldName, string Caption, bool readOnly, bool allowEdit, bool visible)
        {
            BeginUpdate();

            TreeListColumn column = Columns.Add();
            column.Visible = visible;
            column.OptionsColumn.AllowEdit = allowEdit;
            column.OptionsColumn.ReadOnly = false;
            column.Caption = Caption;
            OptionsView.AutoWidth = true;

            column.OptionsColumn.FixedWidth = false;
            column.VisibleIndex = visibleIndex;
            column.FieldName = fieldName;
            if (column.FieldName == KeHoachTongNguonChiTietsColumn.GhiChuSoDauNam.ToString()
                || column.FieldName == KeHoachTongNguonChiTietsColumn.GhiChuUyBanDauNam.ToString()
                || column.FieldName == KeHoachTongNguonChiTietsColumn.GhiChuSoDieuChinh.ToString()
                || column.FieldName == KeHoachTongNguonChiTietsColumn.GhiChuUyBanDieuChinh.ToString())
            {
                column.MinWidth = 200;
            }
            EndUpdate();
            Update();
        }

        public void LoadControlByLoaiKeHoach(bool isCreate, KeHoachTongNguonDto obj)
        {
            #region Set năm cho cột
            string namtruoc = string.Empty;
            string namnay = string.Empty;
            if (obj != null && obj.Nam != 0)
            {
                namtruoc = " " + (obj.Nam - 1).ToString();
                namnay = " " + obj.Nam.ToString();
            }
            TreeListColumn columns = this.Columns[KeHoachTongNguonChiTietsColumn.KeHoachDauNamTruoc.ToString()];
            if (columns != null)
            {
                columns.Caption = KeHoachTongNguonChiTietsColumn.KeHoachDauNamTruoc.GetDescription() + namtruoc;
                SetEditColumns(columns);
            }
            columns = this.Columns[KeHoachTongNguonChiTietsColumn.KeHoachBoSungNamTruoc.ToString()];
            if (columns != null)
            {
                columns.Caption = KeHoachTongNguonChiTietsColumn.KeHoachBoSungNamTruoc.GetDescription() + namtruoc;
                SetEditColumns(columns);
            }
            columns = this.Columns[KeHoachTongNguonChiTietsColumn.KeHoachDauNam.ToString()];
            if (columns != null)
            {
                columns.Caption = KeHoachTongNguonChiTietsColumn.KeHoachDauNam.GetDescription() + namnay;
                SetEditColumns(columns);
            }
            columns = this.Columns[KeHoachTongNguonChiTietsColumn.KeHoachDauNamDuocDuyet.ToString()];
            if (columns != null)
            {
                columns.Caption = KeHoachTongNguonChiTietsColumn.KeHoachDauNamDuocDuyet.GetDescription() + namnay;
                SetEditColumns(columns);
            }
            columns = this.Columns[KeHoachTongNguonChiTietsColumn.KeHoachBoSung.ToString()];
            if (columns != null)
            {
                columns.Caption = KeHoachTongNguonChiTietsColumn.KeHoachBoSung.GetDescription() + namnay;
                SetEditColumns(columns);
            }
            columns = this.Columns[KeHoachTongNguonChiTietsColumn.KeHoachBoSungDuocDuyet.ToString()];
            if (columns != null)
            {
                columns.Caption = KeHoachTongNguonChiTietsColumn.KeHoachBoSungDuocDuyet.GetDescription() + namnay;
                SetEditColumns(columns);
            }
            columns = this.Columns[KeHoachTongNguonChiTietsColumn.DieuChinhGiam.ToString()];
            if (columns != null)
            {
                SetEditColumns(columns);
            }
            columns = this.Columns[KeHoachTongNguonChiTietsColumn.DieuChinhTang.ToString()];
            if (columns != null)
            {
                SetEditColumns(columns);
            }

            #endregion

            #region Cấu hình cột theo object
            if (isCreate)
            {

                List<string> ColumnAllowEditFalse = new List<string>();
                List<string> ColumnAllowEditTrue = new List<string>();
                if (obj.LoaiKeHoach == LoaiKeHoachTongNguon.DAU_NAM.ToString())
                {
                    ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.TenNguonVon.ToString());
                    ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.KeHoachDauNamTruoc.ToString());
                    ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.KeHoachBoSungNamTruoc.ToString());

                    if (obj.TrangThaiDauNam.ToString() == TrangThaiKeHoachTongNguon.DANG_SOAN.ToString()
                        || obj.TrangThaiDauNam.ToString() == TrangThaiKeHoachTongNguon.DA_TRINH.ToString()
                        || obj.TrangThaiDauNam.ToString() == TrangThaiKeHoachTongNguon.YEU_CAU_CHINH_SUA.ToString())
                    {
                        ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.KeHoachDauNamDuocDuyet.ToString());

                        ColumnAllowEditTrue.Add(KeHoachTongNguonChiTietsColumn.KeHoachDauNam.ToString());
                        ColumnAllowEditTrue.Add(KeHoachTongNguonChiTietsColumn.GhiChuSoDauNam.ToString());
                        ColumnAllowEditTrue.Add(KeHoachTongNguonChiTietsColumn.GhiChuUyBanDauNam.ToString());
                    }
                    else if (obj.TrangThaiDauNam.ToString() == TrangThaiKeHoachTongNguon.DUYET.ToString())
                    {
                        ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.KeHoachDauNam.ToString());

                        ColumnAllowEditTrue.Add(KeHoachTongNguonChiTietsColumn.KeHoachDauNamDuocDuyet.ToString());
                        ColumnAllowEditTrue.Add(KeHoachTongNguonChiTietsColumn.GhiChuSoDauNam.ToString());
                        ColumnAllowEditTrue.Add(KeHoachTongNguonChiTietsColumn.GhiChuUyBanDauNam.ToString());
                    }
                    else if (obj.TrangThaiDauNam.ToString() == TrangThaiKeHoachTongNguon.HOAN_THANH.ToString())
                    {
                        ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.KeHoachDauNam.ToString());

                        ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.KeHoachDauNamDuocDuyet.ToString());
                        ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.GhiChuSoDauNam.ToString());
                        ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.GhiChuUyBanDauNam.ToString());
                    }
                }
                else if (obj.LoaiKeHoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString())
                {
                    ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.TenNguonVon.ToString());
                    ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.KeHoachDauNamTruoc.ToString());
                    ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.KeHoachBoSungNamTruoc.ToString());
                    ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.KeHoachDauNam.ToString());
                    ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.KeHoachDauNamDuocDuyet.ToString());
                    ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.KeHoachBoSung.ToString());

                    if (obj.TrangThaiDieuChinh.ToString() == TrangThaiKeHoachTongNguon.DANG_SOAN.ToString()
                        || obj.TrangThaiDieuChinh.ToString() == TrangThaiKeHoachTongNguon.DA_TRINH.ToString()
                        || obj.TrangThaiDieuChinh.ToString() == TrangThaiKeHoachTongNguon.YEU_CAU_CHINH_SUA.ToString())
                    {
                        ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.KeHoachBoSungDuocDuyet.ToString());

                        ColumnAllowEditTrue.Add(KeHoachTongNguonChiTietsColumn.DieuChinhGiam.ToString());
                        ColumnAllowEditTrue.Add(KeHoachTongNguonChiTietsColumn.DieuChinhTang.ToString());
                        ColumnAllowEditTrue.Add(KeHoachTongNguonChiTietsColumn.GhiChuSoDieuChinh.ToString());
                        ColumnAllowEditTrue.Add(KeHoachTongNguonChiTietsColumn.GhiChuUyBanDieuChinh.ToString());
                    }
                    else if (obj.TrangThaiDieuChinh.ToString() == TrangThaiKeHoachTongNguon.DUYET.ToString())
                    {
                        ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.DieuChinhGiam.ToString());
                        ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.DieuChinhTang.ToString());

                        ColumnAllowEditTrue.Add(KeHoachTongNguonChiTietsColumn.KeHoachBoSungDuocDuyet.ToString());
                        ColumnAllowEditTrue.Add(KeHoachTongNguonChiTietsColumn.GhiChuSoDieuChinh.ToString());
                        ColumnAllowEditTrue.Add(KeHoachTongNguonChiTietsColumn.GhiChuUyBanDieuChinh.ToString());
                    }
                    else if (obj.TrangThaiDieuChinh.ToString() == TrangThaiKeHoachTongNguon.HOAN_THANH.ToString())
                    {
                        ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.DieuChinhGiam.ToString());
                        ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.DieuChinhTang.ToString());

                        ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.KeHoachBoSungDuocDuyet.ToString());
                        ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.GhiChuSoDieuChinh.ToString());
                        ColumnAllowEditFalse.Add(KeHoachTongNguonChiTietsColumn.GhiChuUyBanDieuChinh.ToString());
                    }
                }

                foreach (TreeListColumn column in this.Columns)
                {
                    if (ColumnAllowEditFalse.Contains(column.FieldName))
                    {
                        column.Visible = true;
                        column.OptionsColumn.AllowEdit = false;
                    }
                    else if (ColumnAllowEditTrue.Contains(column.FieldName))
                    {
                        column.Visible = true;
                        column.OptionsColumn.AllowEdit = true;
                    }
                    else
                    {
                        column.Visible = false;
                        column.OptionsColumn.AllowEdit = false;
                    }
                }
            }
            else if (isCreate == false && obj != null && obj.Id != Guid.Empty)
            {
                if (obj.LoaiKeHoach == LoaiKeHoachTongNguon.DAU_NAM.ToString())
                {
                    columns = this.Columns[KeHoachTongNguonChiTietsColumn.DieuChinhTang.ToString()];
                    if (columns != null)
                    {
                        columns.Visible = false;
                        columns.OptionsColumn.AllowEdit = false;
                    }
                    columns = this.Columns[KeHoachTongNguonChiTietsColumn.DieuChinhGiam.ToString()];
                    if (columns != null)
                    {
                        columns.Visible = false;
                        columns.OptionsColumn.AllowEdit = false;
                    }
                    
                    columns = this.Columns[KeHoachTongNguonChiTietsColumn.KeHoachBoSung.ToString()];
                    if (columns != null)
                    {
                        columns.Visible = false;
                        columns.OptionsColumn.AllowEdit = false;
                    }
                    columns = this.Columns[KeHoachTongNguonChiTietsColumn.KeHoachBoSungDuocDuyet.ToString()];
                    if (columns != null)
                    {
                        columns.Visible = false;
                        columns.OptionsColumn.AllowEdit = false;
                    }
                    columns = this.Columns[KeHoachTongNguonChiTietsColumn.GhiChuSoDauNam.ToString()];
                    if (columns != null)
                    {
                        columns.Visible = true;
                        columns.OptionsColumn.AllowEdit = false;
                        columns.VisibleIndex = 9;
                    }
                    columns = this.Columns[KeHoachTongNguonChiTietsColumn.GhiChuUyBanDauNam.ToString()];
                    if (columns != null)
                    {
                        columns.Visible = true;
                        columns.OptionsColumn.AllowEdit = false;
                        columns.VisibleIndex = 10;
                    }
                    columns = this.Columns[KeHoachTongNguonChiTietsColumn.GhiChuSoDieuChinh.ToString()];
                    if (columns != null)
                    {
                        columns.Visible = false;
                        columns.OptionsColumn.AllowEdit = false;
                    }
                    columns = this.Columns[KeHoachTongNguonChiTietsColumn.GhiChuUyBanDieuChinh.ToString()];
                    if (columns != null)
                    {
                        columns.Visible = false;
                        columns.OptionsColumn.AllowEdit = false;
                    }
                }
                else if (obj.LoaiKeHoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString())
                {
                    columns = this.Columns[KeHoachTongNguonChiTietsColumn.DieuChinhTang.ToString()];
                    if (columns != null)
                    {
                        columns.Visible = true;
                        columns.OptionsColumn.AllowEdit = false;
                        columns.VisibleIndex = 7;
                    }
                    columns = this.Columns[KeHoachTongNguonChiTietsColumn.DieuChinhGiam.ToString()];
                    if (columns != null)
                    {
                        columns.Visible = true;
                        columns.OptionsColumn.AllowEdit = false;
                        columns.VisibleIndex = 8;
                    }
                    
                    columns = this.Columns[KeHoachTongNguonChiTietsColumn.KeHoachBoSung.ToString()];
                    if (columns != null)
                    {
                        columns.Visible = true;
                        columns.OptionsColumn.AllowEdit = false;
                        columns.VisibleIndex = 9;
                    }
                    columns = this.Columns[KeHoachTongNguonChiTietsColumn.KeHoachBoSungDuocDuyet.ToString()];
                    if (columns != null)
                    {
                        columns.Visible = true;
                        columns.OptionsColumn.AllowEdit = false;
                        columns.VisibleIndex = 10;
                    }
                    columns = this.Columns[KeHoachTongNguonChiTietsColumn.GhiChuSoDauNam.ToString()];
                    if (columns != null)
                    {
                        columns.Visible = false;
                        columns.OptionsColumn.AllowEdit = false;
                    }
                    columns = this.Columns[KeHoachTongNguonChiTietsColumn.GhiChuUyBanDauNam.ToString()];
                    if (columns != null)
                    {
                        columns.Visible = false;
                        columns.OptionsColumn.AllowEdit = false;
                    }
                    columns = this.Columns[KeHoachTongNguonChiTietsColumn.GhiChuSoDieuChinh.ToString()];
                    if (columns != null)
                    {
                        columns.Visible = true;
                        columns.OptionsColumn.AllowEdit = false;
                        columns.VisibleIndex = 11;
                    }
                    columns = this.Columns[KeHoachTongNguonChiTietsColumn.GhiChuUyBanDieuChinh.ToString()];
                    if (columns != null)
                    {
                        columns.Visible = true;
                        columns.OptionsColumn.AllowEdit = false;
                        columns.VisibleIndex = 12;
                    }             
                }
            }
            else
            {
                foreach (TreeListColumn column in this.Columns)
                {
                    column.Visible = true;
                    column.OptionsColumn.AllowEdit = false;
                }
            }

            #endregion

        }

        public TreeListColumn SetEditColumns(TreeListColumn columns)
        {
            columns.Format.FormatType = FormatType.Numeric;
            columns.Format.FormatString = FormatValue.N3;

            RepositoryItemTextEdit repositoryItem = new RepositoryItemTextEdit();
            repositoryItem.EditFormat.FormatType = FormatType.Numeric;
            repositoryItem.EditFormat.FormatString = FormatValue.N3;
            repositoryItem.DisplayFormat.FormatType = FormatType.Numeric;
            repositoryItem.DisplayFormat.FormatString = FormatValue.N3;
            repositoryItem.Mask.MaskType = MaskType.Numeric;
            repositoryItem.Mask.UseMaskAsDisplayFormat = true;
            repositoryItem.Mask.EditMask = "n3";
            columns.ColumnEdit = repositoryItem;

            columns.SummaryFooter = SummaryItemType.Custom;
            columns.AllNodesSummary = true;
            columns.RowFooterSummaryStrFormat = FormatValue.N3;
            return columns;
        }
    }
}
