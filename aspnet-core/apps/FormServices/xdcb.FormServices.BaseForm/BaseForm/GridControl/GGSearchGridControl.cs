using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Linq;
using xdcb.FormServices.Component;
using xdcb.FormServices.SDK;
using xdcb.FormServices.Shared;

namespace xdcb.FormServices.BaseForm
{
    public partial class GGSearchGridControl : DevExpress.XtraGrid.GridControl, IGGControl
    {
        #region Variables
        protected String _GGDataSource;
        protected String _GGDataMember;
        protected String _GGFieldGroup;
        protected String _GGFieldRelation;
        #endregion

        #region Public Properties
        [Category("GreenGlobal")]
        public String GGDataSource
        {
            get
            {
                return _GGDataSource;
            }
            set
            {
                _GGDataSource = value;
            }
        }

        [Category("GreenGlobal")]
        public String GGDataMember
        {
            get
            {
                return _GGDataMember;
            }
            set
            {
                _GGDataMember = value;
            }
        }

        [Category("GreenGlobal")]
        public String GGFieldGroup
        {
            get
            {
                return _GGFieldGroup;
            }
            set
            {
                _GGFieldGroup = value;
            }
        }

        [Category("GreenGlobal")]
        public String GGFieldRelation
        {
            get
            {
                return _GGFieldRelation;
            }
            set
            {
                _GGFieldRelation = value;
            }
        }

        public BaseModule Module;
        #endregion

        #region CustomControl
        public GGSearchGridControl()
        {
            //
        }
        public virtual void InitializeControlByDesign(string path, string strCreate)
        {
        }

        public virtual void InitializeControl()
        {
            GridView dgvSearchResults = InitializeSearchResultsGridView();
            this.ViewCollection.Add(dgvSearchResults);
            this.MainView = dgvSearchResults;
            dgvSearchResults.GridControl = this;
            this.UseEmbeddedNavigator = true;
            this.EmbeddedNavigator.Name = "navigator_" + this.Name;
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
            dgvSearchResults.OptionsView.ColumnAutoWidth = false;
            dgvSearchResults.OptionsCustomization.AllowFilter = true;
            dgvSearchResults.OptionsView.ShowAutoFilterRow = true;
            dgvSearchResults.OptionsView.ShowGroupPanel = false;
            dgvSearchResults.OptionsView.ShowIndicator = false;
            dgvSearchResults.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(GridViewSearchResults_FocusedRowChanged);
            dgvSearchResults.OptionsBehavior.Editable = false;

            AddColumnsToGridViewResults(dgvSearchResults, GGDataSource);
            dgvSearchResults.ShowGridMenu += new GridMenuEventHandler(gridView_ShowGridMenu);
            return dgvSearchResults;
        }

        private void GridViewSearchResults_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView dgvSearchResults = (GridView)sender;
            if (dgvSearchResults.DataSource != null && dgvSearchResults.FocusedRowHandle >= 0)
            {
                try
                {
                    object[] item = (object[])dgvSearchResults.DataSource;
                    object obj = item[dgvSearchResults.FocusedRowHandle];

                    var id= obj.GetType().GetProperty("Id").GetValue(obj, null);

                    ((BaseModule)Module).CurrentIndex = dgvSearchResults.FocusedRowHandle;

                    ((BaseModule)Module).CurrentObjectID = id;
                    ((BaseModule)Module).ActionInvalidate();
                }
                catch (Exception ex)
                {
                    //
                }
               
            }
        }

        protected virtual void AddColumnsToGridViewResults(GridView gridView, string tableName)
        {
            //gridView.Columns.Clear();
            //var api = ConfigManager.GetAPIByService<IConfigColumnsApi>();
            //var columncolumnList = api.GetObjectByTableName(tableName).GetAwaiter().GetResult().ToList();
            //if (columncolumnList != null && columncolumnList.Count > 0)
            //{
            //    foreach (ConfigColumnDto objConfigColumn in columncolumnList)
            //    {
            //        if (objConfigColumn != null)
            //        {
            //            bool isAllow = Convert.ToBoolean(objConfigColumn.ConfigColumnAllowEdit);
            //            bool isVisible = Convert.ToBoolean(objConfigColumn.ConfigColumnIsVisible);
            //            int visibleIndex = Convert.ToInt32(objConfigColumn.ConfigColumnVisibleIndex);
            //            int width = Convert.ToInt32(objConfigColumn.ConfigColumnWidth);

            //            DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
            //            if (isVisible)
            //            {
            //                col.Visible = true;
            //                col.VisibleIndex = visibleIndex;
            //            }
            //            else
            //            {
            //                col.Visible = false;
            //            }

            //            if (width > 0)
            //            {
            //                col.Width = width;
            //            }
            //            col.Name = "col" + objConfigColumn.ConfigColumnName;
            //            col.FieldName = objConfigColumn.ConfigColumnName;
            //            col.Caption = objConfigColumn.ConfigColumnCaption;
            //            gridView.Columns.Add(col);
            //        }
            //    }
            //}
            //else
            //{
            //    AddDefaultColumnsToGridView(gridView, tableName);
            //}
        }

        protected virtual void AddDefaultColumnsToGridView(GridView gridView, string tableName)
        {

        }

        void gridView_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            //GridView gr = (GridView)sender;
            //if (e.Menu == null) return;
            //if (e.HitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.ColumnPanel ||
            //    e.HitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.ColumnEdge ||
            //    e.HitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.ColumnFilterButton ||
            //    e.HitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.Column)
            //{
            //    bool isExcel = false;
            //    foreach (DXMenuItem item in e.Menu.Items)
            //    {
            //        if (item.Tag.ToString() == "ExportExcel")
            //        {
            //            isExcel = true;
            //            continue;
            //        }
            //    }
            //    //AddMenu(gr, e.Menu, isExcel);
            //}
        }
        #endregion
    }
}
