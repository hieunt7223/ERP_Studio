using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using xdcb.FormServices.Component;

namespace xdcb.FormServices.BaseForm
{
    public partial class GGScreen : XtraForm
    {
        #region Constants of Property Names
        public const String cstDataSourcePropertyName = "GGDataSource";
        public const String cstDataMemberPropertyName = "GGDataMember";
        public const String cstFieldGroupPropertyName = "GGFieldGroup";
        public const String cstCommentPropertyName = "GGComment";
        public const String cstBindingPropertyName = "GGPropertyName";
        public const String cstErrorPropertyName = "GGErrorPropertyName";
        public const String cstPrivilegePropertyName = "GGPrivilege";
        public const String cstDescriptionPropertyName = "GGDescription";
        public const String cstRelationPropertyName = "GGFieldRelation";
        #endregion

        #region Constants of Field Groups
        public const String cstFieldGroupNonCreatable = "NonCreatable";
        public const String cstFieldGroupNonEditable = "NonEditable";
        public const String cstFieldGroupAction = "Action";
        public const String cstFieldGroupNonAction = "NonAction";
        public const String cstFieldGroupSearch = "Search";
        public const String cstFieldGroupCustom = "Custom";
        #endregion

        public BaseModule Module { get; set; }
        public void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GGScreen
            // 
            this.ClientSize = new System.Drawing.Size(1023, 548);
            this.IconOptions.Image = global::xdcb.FormServices.BaseForm.Properties.Resources.logo1;
            this.Name = "GGScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GGScreen_FormClosing);
            this.ResumeLayout(false);

        }

        private void GGScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);
            FunctionModule.RemoveOpenedModule(Module);
            SplashScreenManager.CloseForm();
        }
    }
}
