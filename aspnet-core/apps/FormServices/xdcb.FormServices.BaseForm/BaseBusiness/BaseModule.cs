using DevExpress.XtraBars.Docking;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Volo.Abp.Application.Dtos;
using xdcb.FormServices.Component;
using xdcb.FormServices.Shared;

namespace xdcb.FormServices.BaseForm
{
    public class BaseModule
    {
        #region variables
        protected String _name = String.Empty;
        protected ParentForm _parentForm;
        #endregion

        #region Variable Object
        protected AuditedEntityDto<int> _mainObject;
        protected BindingSource _mainObjectBindingSource;
        #endregion

        #region properties
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        //public ParentForm parentForm
        //{
        //    get { return _parentForm; }
        //    set { _parentForm = value; }
        //}

        public GGScreen UIMainForm;
        public Panel UIPanel;
        public string DataSourceSearch;
        public int CurrentIndex;
        public object CurrentObjectID;
        #endregion

        #region 
        public AuditedEntityDto<int> MainObject
        {
            get { return _mainObject; }
            set { _mainObject = value; }
        }

        public BindingSource MainObjectBindingSource
        {
            get { return _mainObjectBindingSource; }
            set { _mainObjectBindingSource = value; }
        }
        #endregion

        public BaseModule()
        {
            UIMainForm = new GGScreen { Module = this };
            MainObjectBindingSource = new BindingSource();
        }

        #region
        public virtual void InitMainObject()
        {

        }
        #endregion

        #region Constructor

        public List<Control> GetControlByForm(Control.ControlCollection controls)
        {
            List<Control> listControl = new List<Control>();
            foreach (Control ctrl in controls)
            {
                //if (ctrl.Controls.Count > 0 && !LoadFormToJson.IsGetByControlCustom(ctrl))
                //{
                //    foreach (Control ctrl1 in ctrl.Controls)
                //    {
                //        if (ctrl1.Controls.Count > 0 &&!LoadFormToJson.IsGetByControlCustom(ctrl1))
                //        {
                //            foreach (Control ctrl2 in ctrl1.Controls)
                //            {
                //                if (ctrl2.Controls.Count > 0 && !LoadFormToJson.IsGetByControlCustom(ctrl2))
                //                {
                //                    foreach (Control ctrl3 in ctrl2.Controls)
                //                    {
                //                        listControl.Add(ctrl3);
                //                    }
                //                }
                //                listControl.Add(ctrl2);
                //            }
                //        }
                //        listControl.Add(ctrl1);
                //    }
                //}
                listControl.Add(ctrl);
            }
            return listControl;
        }
        public void InitializeControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl.Controls.Count > 0)
                {
                    InitializeControls(ctrl.Controls);
                }
                string dataMember = GetProperty.GetPropertyStringValue(ctrl, Customs.cstDataMember);
                if (!string.IsNullOrWhiteSpace(dataMember))
                {
                    InitializeControl(ctrl);
                }
            }
        }
        public virtual Control InitializeControl(Control ctrl)
        {
            if (ctrl is IGGControl)
            {
                IGGControl control = (IGGControl)ctrl;
                control.InitializeControl();
            }
            return ctrl;
        }

        public static void InitBindEntityToControl(Control.ControlCollection controls, BindingSource _bindingSource)
        {
            if (_bindingSource.DataSource != null)
                foreach (Control ctrl in controls)
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        InitBindEntityToControl(ctrl.Controls, _bindingSource);
                    }
                    string dataMember = GetProperty.GetPropertyStringValue(ctrl, Customs.cstDataMember);
                    if (!string.IsNullOrWhiteSpace(dataMember))
                    {
                        try
                        {
                            ctrl.DataBindings.Clear();
                            ctrl.DataBindings.Add("EditValue", _bindingSource, dataMember, true,
                                                       DataSourceUpdateMode.OnPropertyChanged);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
        }

        #endregion

        #region Xử lý chung
        public virtual void InitializeModule()
        {
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);
            InitMainObject();
            InitForm();

            SplashScreenManager.CloseForm();
        }

        public void InitForm()
        {
            UIMainForm.InitializeComponent();
            UIMainForm.Module = this;
            UIMainForm.TopLevel = false;
            UIMainForm.Dock = DockStyle.Fill;
            if (FunctionModule.OpenModules.ContainsKey(FunctionModule.CurrentModule))
            {
                UIMainForm.WindowState = FormWindowState.Maximized;
            }
            FunctionModule.MainScreen.pnView.Controls.Add(UIMainForm);
            UIMainForm.Show();
            UIMainForm.Focus();
        }
        public virtual void InitMainObjectBindingSource()
        {
            if (MainObject != null)
            {
                MainObjectBindingSource.DataSource = MainObject;
            }
            //if (SearchObject != null)
            //{
            //    SearchObjectBindingSource = new BindingSource();
            //    SearchObjectBindingSource.DataSource = SearchObject;
            //}
        }
        public virtual void UpdateMainObjectBindingSource()
        {
            MainObjectBindingSource.DataSource = this.MainObject;
            MainObjectBindingSource.ResetBindings(false);
        }
        #endregion

        #region Search

        //public virtual void GetObjectDataSearch()
        //{
        //    object[] obj = GetDataSearch();
        //    if (parentForm.gridSearch != null)
        //    {
        //        parentForm.gridSearch.DataSource = obj;
        //        parentForm.gridSearch.RefreshDataSource();
        //    }

        //}

        public virtual object[] GetDataSearch()
        {
            object[] obj = new object[0];
            return obj;
        }
        #endregion

        #region Action
        public virtual int ActionSave()
        {
            int ID = 0;
            return ID;
        }


        public virtual void ActionDelete()
        {

        }

        public virtual void ActionCancel()
        {
        }

        public virtual void ActionEdit()
        {
        }

        public virtual void ActionNew()
        {
            SetDefaultMainOject();
            //InitBindEntityToControl(parentForm.pnMainControl.Controls, MainObjectBindingSource);
        }

        public virtual void ActionInvalidate()
        {
            Invalidate();
            //InitBindEntityToControl(parentForm.pnMainControl.Controls, MainObjectBindingSource);

            //parentForm.btnAction = ButtonAction.btnView.ToString();
            //parentForm.InvalidateToolBar();
        }


        public virtual void Invalidate()
        {

        }

        public virtual void SetDefaultMainOject()
        {
            try
            {
                //String strMainObjectName = MainObject.GetType().Name;
                //MainObject = BusinessObjectFactory.GetBusinessObject(strMainObjectName);
                //UpdateMainObjectBindingSource();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        #endregion

        #region Thoát màn hình
        public void Close()
        {
            //Remove Module in OpenModules
            FunctionModule.MainScreen.OpenModulesBar.Items.RemoveByKey(Name);
            FunctionModule.RemoveOpenedModule(Name);
            //if (BOSApp.CurrentUser != null)
            //    DeleteUserAudit(Name);

            //Active last open modules
            if (FunctionModule.MainScreen.OpenModulesBar.Items.Count > 0)
            {
                int index = FunctionModule.MainScreen.OpenModulesBar.Items.Count - 1;
                String strModuleName = FunctionModule.MainScreen.OpenModulesBar.Items[index].Name;
                FunctionModule.ShowModule(strModuleName);
            }
        }
        #endregion
    }
}
