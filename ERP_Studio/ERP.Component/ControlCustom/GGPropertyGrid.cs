using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ERP.Component.ControlCustom
{
    public class GGPropertyGrid : PropertyGrid, IGGControl
    {
        #region Variables
        protected String _GGDataSource;
        protected String _GGDataMember;
        protected String _GGFieldGroup;
        protected String _GGFieldRelation;
        private IContainer components;
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
        public GGPropertyGrid()
        {
        }
        public GGPropertyGrid(IContainer container)
        {
            container.Add(this);
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
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
