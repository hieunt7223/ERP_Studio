using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.ToolbarForm;
using Localization;
using xdcb.FormServices.Shared;

namespace xdcb.FormServices.BaseForm
{
    public partial class MainForm : ToolbarForm
    {
        public Panel pnView;
        public ToolStrip OpenModulesBar;
        public Bar MenuBar;
        public MainForm()
        {
            InitializeComponent();
            pnView = pn_View;
            OpenModulesBar = toolStripOpenModule;
            MenuBar = bar2;
            SetColorToolbar();

            FunctionModule.MainScreen = this;

            Text = $"{Text} - Build version {BuildVersion()}";
        }

        private void SetColorToolbar()
        {
            OpenModulesBar.ForeColor = Color.FromArgb(0x0E5AD8);
        }
        #region Cấu hình hệ thống
        private void btn_GenerateEntity_ItemClick(object sender, ItemClickEventArgs e)
        {
            FunctionModule.ShowModule(ModuleName.GenerateEntity.ToString());

        }
        private void btn_GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            FunctionModule.ShowModule(ModuleName.DesignGridView.ToString());
        }

        private void btn_TreeList_ItemClick(object sender, ItemClickEventArgs e)
        {
            FunctionModule.ShowModule(ModuleName.DesignTreeList.ToString());
        }

        private void btn_ImportData_ItemClick(object sender, ItemClickEventArgs e)
        {
            FunctionModule.ShowModule(ModuleName.ImportData.ToString());
        }

        private void btn_DesignForm_ItemClick(object sender, ItemClickEventArgs e)
        {
            FunctionModule.ShowModule(ModuleName.DesignForm.ToString());
        }
        #endregion

        #region quản lý vốn
        private void bbi_kehoachtongnguon_ItemClick(object sender, ItemClickEventArgs e)
        {
            FunctionModule.ShowModule(ModuleName.KeHoachTongNguon.ToString());
        }

        private void btn_TongHopNhuCauVonHangNam_ItemClick(object sender, ItemClickEventArgs e)
        {
            FunctionModule.ShowModule(ModuleName.TongHopNhuCauVonHangNam.ToString());
        }

        private void btn_TongHopNhuCauVonTrungHan_ItemClick(object sender, ItemClickEventArgs e)
        {
            FunctionModule.ShowModule(ModuleName.TongHopNhuCauVonTrungHan.ToString());
        }

        private void btn_KHVTheoNghiQuyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            FunctionModule.ShowModule(ModuleName.KHVTheoNghiQuyet.ToString());
        }

        private void btn_KHVTheoNganSachTinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            FunctionModule.ShowModule(ModuleName.KHVTheoNganSachTinh.ToString());
        }

        private void btn_KHVTheoNganSachTrungUong_ItemClick(object sender, ItemClickEventArgs e)
        {
            FunctionModule.ShowModule(ModuleName.KHVTheoNganSachTrungUong.ToString());
        }

        private void btn_TongHopGiaiNgan_ItemClick(object sender, ItemClickEventArgs e)
        {
            FunctionModule.ShowModule(ModuleName.TongHopGiaiNgan.ToString());
        }
        #endregion

        #region Danh mục
        private void bbi_NghiQuyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            FunctionModule.ShowModule(ModuleName.NghiQuyet.ToString());
        }

        private void bbi_CongTrinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            FunctionModule.ShowModule(ModuleName.CongTrinh.ToString());
        }

        private void btn_DMNguonVon_ItemClick(object sender, ItemClickEventArgs e)
        {
            FunctionModule.ShowModule(ModuleName.NguonVon.ToString());
        }

        private void btn_DMLoaiKhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            FunctionModule.ShowModule(ModuleName.LoaiKhoan.ToString());
        }

        private void btn_DMChuongTrinhMucTieuQuocGia_ItemClick(object sender, ItemClickEventArgs e)
        {
            FunctionModule.ShowModule(ModuleName.ChuongTrinhMucTieuQuocGia.ToString());
        }

        #endregion

        #region Load Form
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            FunctionModule.LogIn();
        }
        #endregion

        private void btn_LogOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (GGFunctions.ShowMessageYesNo(BaseFormLocalizedResources.ConfirmLogOffMessage) == DialogResult.Yes)
            {
                FunctionModule.LogOff();
            }
        }

        private string BuildVersion()
        {
            var assembly = System.Reflection.Assembly.LoadFrom("xdcb.FormQLV.dll");
            var version = assembly.GetName().Version;

            var buildDate = File.GetLastWriteTime(assembly.Location);

            return $"{version.Major}.{version.Minor}.{version.Build} ({buildDate:yyyy-MM-dd HH:mm})";
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Process process = Process.Start("updater.exe", "/checknow");
                process.Close();
            }
            catch
            {
                MessageBox.Show("Chức năng này không hoạt động với phiên bản Debug.");
            }
        }

       
    }
}