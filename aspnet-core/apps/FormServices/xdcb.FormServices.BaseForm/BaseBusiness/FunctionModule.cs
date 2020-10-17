using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using xdcb.FormServices.Shared;
using System.Linq;

namespace xdcb.FormServices.BaseForm
{
    public class FunctionModule
    {
        #region Properties
        public static MainForm MainScreen;
        public static SortedList OpenModules = new SortedList();
        public static ImageList SectionImageList = new ImageList();
        public static String CurrentModule = String.Empty;
        public static String CurrentUser;
        #endregion

        #region ShowForm
        public static BaseModule ShowModule(String moduleName)
        {
            CurrentModule = moduleName;
            BaseModule _baseModule;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (IsOpenedModule(moduleName))
                {
                    _baseModule = ((BaseModule)OpenModules[moduleName]);
                    ShowOpenedModule(moduleName);
                }
                else
                {
                    _baseModule = BaseModuleFactory.GetModule(moduleName, "");//
                    if (_baseModule != null)
                        ShowNewModule(_baseModule);
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                return null;
            }
            return _baseModule;
        }

        public static void ShowOpenedModule(String moduleName)
        {
            ToolStripButton tsbtnModule = (ToolStripButton)MainScreen.OpenModulesBar.Items[moduleName];
            CheckOpenModuleToolStripButton(tsbtnModule);
            BaseModule module = (BaseModule)OpenModules[moduleName];
            tsbtnModule.Visible = true;
            module.UIMainForm.Show();
        }

        public static void ShowNewModule(BaseModule module)
        {
            UpdateOpenedModule(module);
            AddOpenModuleToOpenModulesToolStrip(module.Name);
        }

        public static void UpdateOpenedModule(BaseModule module)
        {
            if (!IsOpenedModule(module.Name))
            {
                OpenModules.Add(module.Name, module);
            }
            else
                OpenModules[module.Name] = module;
        }

        public static void RemoveOpenedModule(BaseModule module)
        {
            if (IsOpenedModule(module.Name))
            {
                ((BaseModule)OpenModules[module.Name]).Close();
                OpenModules.Remove(module.Name);
            }
        }

        public static void RemoveOpenedModule(String moduleName)
        {
            if (IsOpenedModule(moduleName))
            {
                OpenModules.Remove(moduleName);
            }
        }

        public static bool IsOpenedModule(String moduleName)
        {
            return OpenModules.ContainsKey(moduleName);
        }

        public static void ShowOpenModule(String moduleName)
        {
            BaseModule module = (BaseModule)OpenModules[moduleName];

            module.UIMainForm.Show();
        }
        public static void AddOpenModuleToOpenModulesToolStrip(String moduleName)
        {
            ToolStripButton tsbtnModule = PopulateOpenModulesToolStripButton(moduleName);
            MainScreen.OpenModulesBar.Items.Add(tsbtnModule);
            tsbtnModule.Visible = true;
            CheckOpenModuleToolStripButton(tsbtnModule);
        }

        private static ToolStripButton PopulateOpenModulesToolStripButton(String moduleName)
        {
            ModuleName status;
            Enum.TryParse(moduleName, out status);
            string moduleDesc = typeof(ModuleName).GetValueByKey(status);
            ToolStripButton tsbtnOpenModules = new ToolStripButton(moduleDesc, SectionImageList.Images[moduleName], OpenModulesToolStrip_Click, moduleName);
            tsbtnOpenModules.TextImageRelation = TextImageRelation.ImageBeforeText;
            tsbtnOpenModules.CheckOnClick = true;
            return tsbtnOpenModules;
        }

        private static void OpenModulesToolStrip_Click(object sender, EventArgs e)
        {
            ToolStripButton tsbtnModule = (ToolStripButton)sender;
            CheckOpenModuleToolStripButton(tsbtnModule);
            ShowModule(tsbtnModule.Name);
        }

        public static void CheckOpenModuleToolStripButton(ToolStripButton tsbtnModule)
        {
            tsbtnModule.Checked = true;
            foreach (ToolStripButton tsbtnOpenedModule in MainScreen.OpenModulesBar.Items)
            {
                if (tsbtnOpenedModule.Name != tsbtnModule.Name)
                {
                    tsbtnOpenedModule.Checked = false;
                    BaseModule module = (BaseModule)OpenModules[tsbtnOpenedModule.Name];
                    module.UIMainForm.Hide();
                }

            }
        }
        #endregion

        #region Login
        public static void LogIn()
        {
            SetVisibleLayoutMenu(false);
            guiLogin _guiLogin = new guiLogin();
            _guiLogin.ShowDialog();
        }
        public static bool IsAuthenticated(String strUserName, String strPassword)
        {
            UserLogin _userLogin;
            Enum.TryParse(strUserName, out _userLogin);
            string user = typeof(UserLogin).GetValueByKeyAndValue(_userLogin, strUserName.ToLower());
            if (!string.IsNullOrWhiteSpace(user))
            {
                if (strPassword.Equals(PasswordLogin.matkhau.GetDescription()))
                    return true;
            }
            return false;
        }

        public static void SetCurrentUserLogin(String strUserName)
        {
            UserLogin _userLogin;
            Enum.TryParse(strUserName, out _userLogin);
            string user = typeof(UserLogin).GetValueByKeyAndValue(_userLogin, strUserName.ToLower());
            CurrentUser = user;
            SetVisibleLayoutMenu(true);
        }
        #endregion

        #region LogOff
        public static void LogOff()
        {
            CloseAllOpenModules();
            DisposeAllCatched();
            MainScreen.OpenModulesBar.Items.Clear();
            MainScreen.OpenModulesBar.Enabled = true;
            GC.Collect(0, GCCollectionMode.Forced);

            LogIn();
        }

        public static void CloseAllOpenModules()
        {
            for (int i = 0; i < OpenModules.Count; i++)
            {
                BaseModule module = (BaseModule)OpenModules.GetByIndex(i);
                module.UIMainForm.Close();
                i--;
            }
        }
        public static void DisposeAllCatched()
        {
            OpenModules.Clear();
        }
        #endregion

        #region
        private static void SetVisibleLayoutMenu(bool isVisible)
        {
            MainScreen.pnView.Visible = isVisible;
            MainScreen.MenuBar.Visible = isVisible;
            MainScreen.OpenModulesBar.Visible = isVisible;
        }
        #endregion
    }
}
