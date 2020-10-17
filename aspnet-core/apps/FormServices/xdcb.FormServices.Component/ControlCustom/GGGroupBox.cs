using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using xdcb.FormServices.ConfigColumns.Dtos;

namespace xdcb.FormServices.Component
{
    public partial class GGGroupBox : GroupBox, IGGControl
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
        public GGGroupBox()
        {
            listConfigColumn = new List<ConfigColumnDto>();          
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
