using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using xdcb.FormServices.Shared;
using Localization;

namespace xdcb.FormServices.BaseForm
{
    public partial class guiLogin : XtraForm
    {
        public guiLogin()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void guiLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login.Focus();
                Login();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            Login();
        }



        public void Login()
        {
            string username = txt_UserName.EditValue == null ? string.Empty : txt_UserName.EditValue.ToString();
            string password = txt_Password.EditValue == null ? string.Empty : txt_Password.EditValue.ToString();
            if (string.IsNullOrWhiteSpace(username))
            {
                GGFunctions.ShowMessage(BaseFormLocalizedResources.UserNameError.ToString());
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                GGFunctions.ShowMessage(BaseFormLocalizedResources.PasswordError.ToString());
                return;
            }
            if (FunctionModule.IsAuthenticated(username, password))
            {
                FunctionModule.SetCurrentUserLogin(username);
                this.Dispose();
            }
            else
            {
                GGFunctions.ShowMessage(BaseFormLocalizedResources.InvalidAuthenticationMessage.ToString());
                return;
            }
        }
    }
}