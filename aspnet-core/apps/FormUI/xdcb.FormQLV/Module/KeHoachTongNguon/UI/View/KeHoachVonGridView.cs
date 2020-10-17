using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xdcb.FormServices.Component;
using xdcb.FormServices.Shared;
using xdcb.QuanLyVon.KeHoachTongNguon.Dtos;

namespace xdcb.FormQLV.KeHoachTongNguon
{
    public class KeHoachVonGridView : GGGridControl
    {
        public virtual void InitializeControl()
        {
            GridView dgvSearchResults = InitializeSearchResultsGridView();
            this.ViewCollection.Add(dgvSearchResults);
            this.MainView = dgvSearchResults;
            dgvSearchResults.GridControl = this;
            this.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.EmbeddedNavigator.Buttons.Append.Visible = false;
        }

        protected virtual GridView InitializeSearchResultsGridView()
        {
            GridView dgvSearchResults = new GridView();
            dgvSearchResults.Name = "dgvs_" + this.Name;
            dgvSearchResults.OptionsSelection.EnableAppearanceFocusedCell = false;
            dgvSearchResults.OptionsSelection.EnableAppearanceFocusedRow = true;
            dgvSearchResults.OptionsView.ColumnAutoWidth = true;
            dgvSearchResults.OptionsCustomization.AllowFilter = true;
            dgvSearchResults.OptionsView.ShowAutoFilterRow = false;
            dgvSearchResults.OptionsView.ShowGroupPanel = false;
            dgvSearchResults.OptionsView.ShowIndicator = false;
            dgvSearchResults.CustomColumnDisplayText += DgvSearchResults_CustomColumnDisplayText;
            dgvSearchResults.OptionsBehavior.Editable = false;

            AddColumnsToGridViewResults(dgvSearchResults, GGDataSource);
            return dgvSearchResults;
        }

        private void DgvSearchResults_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == KeHoachTongNguonColumn.TrangThai.ToString())
            {
                if (e.Value != null)
                {
                    TrangThaiKeHoachTongNguon myStatus;
                    Enum.TryParse(e.Value.ToString(), out myStatus);
                    e.DisplayText = typeof(TrangThaiKeHoachTongNguon).GetValueByKey(myStatus);
                }
            }

            if (e.Column.FieldName == KeHoachTongNguonColumn.LoaiKeHoach.ToString())
            {
                if (e.Value != null)
                {
                    LoaiKeHoachTongNguon myStatus;
                    Enum.TryParse(e.Value.ToString(), out myStatus);
                    e.DisplayText = typeof(LoaiKeHoachTongNguon).GetValueByKey(myStatus);
                }
            }
            if (e.Column.FieldName == KeHoachTongNguonColumn.NgayQuyetDinh.ToString())
            {
                if (e.Value != null)
                {
                    string date = Convert.ToDateTime(e.Value.ToString()).ToString(FormatValue.DateTime.ToString());
                    if (date == DateTime.MinValue.ToString(FormatValue.DateTime.ToString()) ||
                        date == DateTime.MaxValue.ToString(FormatValue.DateTime.ToString()))
                    {
                        e.DisplayText = "";
                    }
                }
            }
        }
        protected virtual void AddColumnsToGridViewResults(GridView gridView, string tableName)
        {
            gridView.Columns.Clear();


            GridColumn column = new GridColumn();
            column.FieldName = KeHoachTongNguonColumn.Nam.ToString();
            column.Caption = KeHoachTongNguonColumn.Nam.GetDescription();
            column.VisibleIndex = 1;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = KeHoachTongNguonColumn.NgayQuyetDinh.ToString();
            column.Caption = KeHoachTongNguonColumn.NgayQuyetDinh.GetDescription();
            column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            column.DisplayFormat.FormatString = FormatValue.DateTime.ToString();
            column.VisibleIndex = 2;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = KeHoachTongNguonColumn.SoQuyetDinh.ToString();
            column.Caption = KeHoachTongNguonColumn.SoQuyetDinh.GetDescription();
            column.VisibleIndex = 3;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = KeHoachTongNguonColumn.KeHoachDauNam.ToString();
            column.Caption = KeHoachTongNguonColumn.KeHoachDauNam.GetDescription();
            column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            column.DisplayFormat.FormatString = FormatValue.N3.ToString();
            column.VisibleIndex = 4;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = KeHoachTongNguonColumn.KeHoachDauNamDuocDuyet.ToString();
            column.Caption = KeHoachTongNguonColumn.KeHoachDauNamDuocDuyet.GetDescription();
            column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            column.DisplayFormat.FormatString = FormatValue.N3.ToString();
            column.VisibleIndex = 5;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = KeHoachTongNguonColumn.KeHoachSauBoSung.ToString();
            column.Caption = KeHoachTongNguonColumn.KeHoachSauBoSung.GetDescription();
            column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            column.DisplayFormat.FormatString = FormatValue.N3.ToString();
            column.VisibleIndex = 6;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = KeHoachTongNguonColumn.KeHoachSauBoSungDuocDuyet.ToString();
            column.Caption = KeHoachTongNguonColumn.KeHoachSauBoSungDuocDuyet.GetDescription();
            column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            column.DisplayFormat.FormatString = FormatValue.N3.ToString();
            column.VisibleIndex = 7;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = KeHoachTongNguonColumn.TrangThai.ToString();
            column.Caption = KeHoachTongNguonColumn.TrangThai.GetDescription();
            column.VisibleIndex = 8;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = KeHoachTongNguonColumn.LoaiKeHoach.ToString();
            column.Caption = KeHoachTongNguonColumn.LoaiKeHoach.GetDescription();
            column.VisibleIndex = 9;
            gridView.Columns.Add(column);

            column = new GridColumn();
            column.FieldName = KeHoachTongNguonColumn.GhiChu.ToString();
            column.Caption = KeHoachTongNguonColumn.GhiChu.GetDescription();
            column.VisibleIndex = 10;
            gridView.Columns.Add(column);
        }

        public void LoadCaptionHeaderGridView(string strnam)
        {
            GridView gridView = (GridView)this.MainView;
            if (gridView != null)
            {
                GridColumn columns = gridView.Columns[KeHoachTongNguonColumn.KeHoachDauNam.ToString()];
                if (columns != null)
                {
                    columns.Caption = KeHoachTongNguonColumn.KeHoachDauNam.GetDescription() +" "+ strnam;
                }
                columns = gridView.Columns[KeHoachTongNguonColumn.KeHoachDauNamDuocDuyet.ToString()];
                if (columns != null)
                {
                    columns.Caption = KeHoachTongNguonColumn.KeHoachDauNamDuocDuyet.GetDescription() + " " + strnam;
                }
                columns = gridView.Columns[KeHoachTongNguonColumn.KeHoachSauBoSung.ToString()];
                if (columns != null)
                {
                    columns.Caption = KeHoachTongNguonColumn.KeHoachSauBoSung.GetDescription() + " " + strnam;
                }
                columns = gridView.Columns[KeHoachTongNguonColumn.KeHoachSauBoSungDuocDuyet.ToString()];
                if (columns != null)
                {
                    columns.Caption = KeHoachTongNguonColumn.KeHoachSauBoSungDuocDuyet.GetDescription() + " " + strnam;
                }
            }
        }
    }
}