using System;
using System.Windows.Forms;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Component;
using DevExpress.XtraSplashScreen;
using Microsoft.Office.Interop.Excel;
using xdcb.FormServices.Shared;
using xdcb.FormServices.SDK;
using Volo.Abp.Application.Dtos;
using System.Text.RegularExpressions;

namespace xdcb.FormStudio.ImportData
{
    public partial class frmImportData : GGScreen
    {
        #region Private variable
        private Microsoft.Office.Interop.Excel.Application App;
        private Workbook WorkBook;
        private Worksheet WorkSheet;
        #endregion
        public frmImportData()
        {
            InitializeComponent();
        }
        private async void btn_ImportNhuCauVon_Click(object sender, EventArgs e)
        {
            Range range = InitializeDataImport();
            if (range == null)
                return;
            if (GGFunctions.ShowMessageYesNo("Bạn có chắc chắc muốn Import dữ liệu nhu cầu vốn!") == DialogResult.No)
                return;
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);
            var apiCongTrinh = ConfigManager.GetAPIByService<ICongTrinhsApi>();

            PagedAndSortedResultRequestDto input = new PagedAndSortedResultRequestDto();
            input.SkipCount = 0;
            input.MaxResultCount = 1000;
            SplashScreenManager.CloseForm();
            GGFunctions.ShowMessage("Import thành công!");
        }

        public decimal GetValueDecimal(string text)
        {
            decimal value = 0;
            if (IsNumber(text))
            {
                value = decimal.Parse(text);
            }
            return value;
        }
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText.Trim().Replace(",", ""));
        }
        #region
        public Range InitializeDataImport()
        {
            string filePath = string.Empty;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files (*.xls;*.xlsx)|*.xls;*.xlsx"; ;
            if (dialog.ShowDialog() != DialogResult.Cancel)
                filePath = dialog.FileName;
            if (!String.IsNullOrEmpty(filePath))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                App = new Microsoft.Office.Interop.Excel.Application();
                WorkBook = App.Workbooks.Open(filePath, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                App.Visible = false;
                WorkSheet = (Worksheet)WorkBook.Worksheets.get_Item(1);
                Range range = WorkSheet.UsedRange;
                return range;
            }
            return null;
        }
        public void ReleaseDataImport()
        {
            WorkBook.Close(true, null, null);
            App.Quit();
            ReleaseObject(WorkSheet);
            ReleaseObject(WorkBook);
            ReleaseObject(App);
        }

        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                GGFunctions.ShowMessage(ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion
    }
}