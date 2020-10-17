using System;
using System.Collections.Generic;
using System.ComponentModel;
using xdcb.FormServices.ConfigColumns.Dtos;

namespace xdcb.FormServices.Component
{
    public partial class GGDateEdit : DevExpress.XtraEditors.DateEdit, IGGControl
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
        List<ConfigColumnDto> listConfigColumn;
        public GGDateEdit()
        {
            listConfigColumn = new List<ConfigColumnDto>();
            this.CustomDisplayText += GGDateEdit_CustomDisplayText;
        }

        private void GGDateEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null)
            {
                try
                {
                    if (Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy") == DateTime.MinValue.ToString("dd/MM/yyyy")
                        || Convert.ToDateTime(e.Value).ToString("dd/MM/yyyy") == DateTime.MaxValue.ToString("dd/MM/yyyy"))
                    {
                        e.DisplayText = "";
                    }
                }
                catch(Exception ex)
                {
                    //
                }
            }
        }

        public virtual void InitializeControl()
        {
        }
        public virtual void InitializeControlByDesign(string path, string strCreate)
        {
        }
        #endregion
    }
}
