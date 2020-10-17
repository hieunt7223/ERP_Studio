using DevExpress.Utils;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.IO;
using xdcb.FormServices.Shared;

namespace xdcb.FormServices.Component
{
    public partial class GGGridControl : DevExpress.XtraGrid.GridControl, IGGControl
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

        #endregion

        #region CustomControl
        public GGGridControl()
        {
            //
        }

        public virtual void InitializeControl()
        {
            String strTableName = GGDataSource;
            String strColumnName = GGDataMember;
            //
        }
        public virtual void InitializeControlByDesign(string path, string strCreate)
        {
            if (!string.IsNullOrWhiteSpace(path) && !string.IsNullOrWhiteSpace(strCreate))
            {
                if (File.Exists(path))
                {
                    SetGridControl(strCreate);
                    this.MainView.RestoreLayoutFromXml(path, OptionsLayoutBase.FullLayout);
                    GridView gridView = (GridView)this.MainView;
                    //gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
                    //gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
                    //gridView.OptionsCustomization.AllowFilter = true;
                    //gridView.OptionsView.ShowAutoFilterRow = false;
                    gridView.OptionsView.ShowGroupPanel = false;
                    gridView.OptionsView.ShowDetailButtons = false;
                    //gridView.OptionsView.ShowIndicator = false;
                    //gridView.OptionsBehavior.Editable = false;
                }
            }
            #endregion
        }

        public void SetGridControl(string strCreate)
        {
            if (strCreate == CreateDesignGrid.NewGridView.ToString())
            {
                GridView gridView = new GridView();
                this.MainView = gridView;
            }
            else if (strCreate == CreateDesignGrid.NewBanded.ToString())
            {
                BandedGridView bandedView = new BandedGridView();
                this.MainView = bandedView;
            }
        }
    }
}
