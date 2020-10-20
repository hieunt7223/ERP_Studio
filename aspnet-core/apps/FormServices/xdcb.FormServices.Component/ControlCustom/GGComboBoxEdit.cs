using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
namespace xdcb.FormServices.Component
{
    public partial class GGComboBoxEdit : DevExpress.XtraEditors.ComboBoxEdit, IGGControl
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
        public GGComboBoxEdit()
        {
        }

        public virtual void InitializeControl()
        {
            InitObjectDataToComboBase();
        }

        protected virtual void InitObjectDataToComboBase()
        {
            String strTableName = GGDataSource;
            String strColumnName = GGDataMember;
            //If DataMember is not empty
            if (!String.IsNullOrEmpty(strTableName) && !String.IsNullOrEmpty(strColumnName))
            {
                //listConfigColumn = ConfigColumnsRepository.GetObjectByTableName(strTableName);
                //if (listConfigColumn != null && listConfigColumn.Count > 0)
                //{
                //    ConfigColumns objConfigColumnInfo = listConfigColumn.Where(x => x.ConfigColumnName == strColumnName).ToList().FirstOrDefault();
                //    if (objConfigColumnInfo != null && !string.IsNullOrEmpty(objConfigColumnInfo.ConfigColumnDataSource))
                //    {
                //        if (objConfigColumnInfo.ConfigColumnDataSource == TableName.ADConfigValuesTableName)
                //        {
                //            if (!string.IsNullOrWhiteSpace(objConfigColumnInfo.ConfigColumnFilter))
                //            {
                //                string sqlstring = string.Format("SELECT ADConfigKeyValue,ADConfigText FROM dbo.ADConfigValues WHERE ADConfigKeyGroup=N'{0}'", objConfigColumnInfo.ConfigColumnFilter);
                //                DataTable dt = FormServicesRepository.SelectByQuerySQL(sqlstring);
                //                if (dt != null && dt.Rows.Count > 0)
                //                {
                //                    foreach (DataRow row in dt.Rows)
                //                    {
                //                        this.Properties.Items.Add(row.Field<string>("ADConfigKeyValue"));
                //                    }
                //                    dt.Dispose();
                //                }

                //            }
                //        }
                //    }
                //}
            }
        }

        public virtual void InitializeControlByDesign(string path, string strCreate)
        {
        }
        #endregion
    }
}
