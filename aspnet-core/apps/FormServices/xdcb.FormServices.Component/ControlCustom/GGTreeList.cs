﻿using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace xdcb.FormServices.Component
{
    public partial class GGTreeList : DevExpress.XtraTreeList.TreeList, IGGControl
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
        public GGTreeList()
        {
        }

        public virtual void InitializeControl()
        {
        }
        public virtual void InitializeControlByDesign(string path, string strCreate)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                if (File.Exists(path))
                {
                    this.RestoreLayoutFromXml(path, OptionsLayoutBase.FullLayout);
                }
            }
        }
        #endregion

    }
}
