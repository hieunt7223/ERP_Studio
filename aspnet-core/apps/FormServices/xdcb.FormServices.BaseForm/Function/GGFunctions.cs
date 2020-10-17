using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text;
using Localization;
using System.Text.RegularExpressions;

namespace xdcb.FormServices.BaseForm
{
    public class GGFunctions
    {
        public static void ShowMessage(string mess)
        {
            XtraMessageBox.Show(mess, BaseFormLocalizedResources.Notification, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowMessageYesNo(string mess)
        {
            return XtraMessageBox.Show(mess, BaseFormLocalizedResources.Notification, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static List<int> GetValueNam()
        {
            List<int> namList = new List<int>();
            for (int i = 1; i <= 5; i++)
            {
                namList.Add(DateTime.Now.Year - i);
            }
            namList.Add(DateTime.Now.Year);
            for (int i = 1; i <= 5; i++)
            {
                namList.Add(DateTime.Now.Year + i);
            }
            return namList.OrderBy(p => p).ToList();
        }

        #region chuyển tiếng việt có dấu sang không dấu
        private static readonly string[] VietNamChar = new string[]
    {
        "aAeEoOuUiIdDyY",
        "áàạảãâấầậẩẫăắằặẳẵ",
        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
        "éèẹẻẽêếềệểễ",
        "ÉÈẸẺẼÊẾỀỆỂỄ",
        "óòọỏõôốồộổỗơớờợởỡ",
        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
        "úùụủũưứừựửữ",
        "ÚÙỤỦŨƯỨỪỰỬỮ",
        "íìịỉĩ",
        "ÍÌỊỈĨ",
        "đ",
        "Đ",
        "ýỳỵỷỹ",
        "ÝỲỴỶỸ"
    };
        public static string ConvertUnicode(string str)
        {
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }
            return str;
        }
        #endregion

        #region Get Url
        public static string GetResultFolder(string path, string folderName)
        {
            string pathUrl = string.Format(@"{0}\{1}", path, folderName);
            if (!Directory.Exists(pathUrl))
            {
                Directory.CreateDirectory(pathUrl);
            }
            var reportFilePath = string.Format(@"{0}", pathUrl);
            return reportFilePath;
        }

        public static string GetResultPath(string path, string folderName, string reportFileName)
        {
            string pathurl = string.Format(@"{0}{1}\{2}", path, folderName, reportFileName);
            if (File.Exists(pathurl))
            {
                return pathurl;
            }
            return string.Empty;
        }

        public static string GetShowFile(string nameFile, string pathTemp)
        {
            //lưu file
            string pathurl = string.Empty;
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Chọn thư mục lưu";
            sf.FileName = nameFile;

            if (sf.ShowDialog() == DialogResult.OK)
            {
                pathurl = sf.FileName;
                if (File.Exists(pathurl))
                {
                    File.Delete(pathurl);
                }
                File.Copy(pathTemp, pathurl);
            }
            return pathurl;
        }

        public static void StartProcess(string fileName)
        {
            try
            {
                Process.Start(fileName);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        public static void ShowException(Exception ex)
        {
            StringBuilder message = new StringBuilder();
            message
                .Append(ex.GetType().Name)
                .Append(": ")
                .Append(ex.Message);

            if (ex.InnerException != null)
            {
                message.AppendFormat(" ({0})", ex.InnerException.Message);
            }

            GGFunctions.ShowMessage(message.ToString());
        }
        #endregion

        #region Chuyển từ List sang Table
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        #endregion

        /// <summary>
        /// Kiểm tra kiểu số
        /// </summary>
        /// <param name="pText"></param>
        /// <returns></returns>
        public static bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        /// <summary>
        /// Chuyển từ kiểu string sang guid
        /// </summary>
        /// <param name="pText"></param>
        /// <returns></returns>
        public static List<Guid> ConvertStringToListGuid(string pText)
        {
            List<Guid> guiList = new List<Guid>();
            if (!string.IsNullOrWhiteSpace(pText))
            {
                List<string> splitlist = pText.Split(';').ToList();
                if (splitlist != null && splitlist.Count > 0)
                {
                    splitlist.ForEach(o =>
                    {
                        if (!string.IsNullOrWhiteSpace(o))
                        {
                            Guid id = Guid.Empty;
                            try
                            {
                                id = new Guid(o.Trim());
                            }
                            catch (Exception ex)
                            {
                                //
                            }
                            if (id != Guid.Empty)
                            {
                                guiList.Add(id);
                            }

                        }
                    });
                }
            }
            return guiList;
        }
    }
}
