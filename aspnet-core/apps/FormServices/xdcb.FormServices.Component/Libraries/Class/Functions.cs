using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace xdcb.FormServices.Component.Libraries
{
    public class Functions
    {
        public static System.Random aRandom = new System.Random();
        public static string[] ARR_QUAN_HE_THAN_THICH = new string[] { 
            "Cha", "Bố", "Mẹ", "Con", "Vợ", "Chồng", "Anh", "Em", "Chị", "C\x00f4", "D\x00ec", "Ch\x00fa", "B\x00e1c", "Th\x00edm", "Ch\x00e1u", "\x00d4ng nội",
            "B\x00e0 nội", "\x00d4ng ngoại", "B\x00e0 ngoại"
        };
        public static string[] ARR_TEN_THUONG_DUNG = new string[] { 
            "An", "Anh", "\x00c1nh", "B\x00ecnh", "Ch\x00e2u", "Cường", "Diệu", "Dũng", "Đức", "H\x00e0", "Hạnh", "Hoa", "Ho\x00e0", "Hương", "H\x00f9ng", "Khoa",
            "Kh\x00f4i", "Lan", "Lệ", "Ly", "Minh", "Mai", "My", "Mỹ", "Nam", "Nga", "Nguy\x00ean", "Như", "Phương", "Phượng", "Quang", "Qu\x00e2n",
            "Thanh", "Thảo", "Th\x00f9y", "Th\x00fay", "T\x00fa", "Tuấn", "Tr\x00e2m", "Tr\x00e2n", "Uy\x00ean", "V\x00e2n"
        };
        public static string[] ARR_HO_LOT_THUONG_DUNG = new string[] { 
            "Nguyễn", "Nguyễn Thị", "Nguyễn Văn", "Trần", "Trần Quang", "Trần Thị", "L\x00ea", "L\x00ea Thị", "Trịnh", "Phan", "Ph\x00f9ng", "Đặng", "Huỳnh", "B\x00f9i", "Th\x00e2n", "Trương",
            "Ho\x00e0ng", "Văn", "V\x00f5", "Ch\x00e2u", "T\x00f4n Nữ"
        };
        private static ErrorProvider errProvider = new ErrorProvider();
        private static SortedList arrayControlWillSetError = new SortedList();
        private static ErrorProvider validError;
        public static int tu;
        public static int mau;

        public static bool Application_IsInstalled(string sEXEFileNameOfApp)
        {
            bool flag = false;
            RegistryKey key = null;
            string str = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\";
            try
            {
                key = Registry.LocalMachine.OpenSubKey(str + sEXEFileNameOfApp);
                flag = key != null;
            }
            catch
            {
                flag = false;
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                }
            }
            return flag;
        }

        public static string AppPath() => 
            Application.StartupPath;

        public static bool ArrayIsNullOrEmpty(object[] arrayObj) => 
            ((arrayObj == null) || (arrayObj.Length == 0));

        public static ArrayList ArrayList_RemoveEmptyItems(ArrayList aArrayList)
        {
            for (int i = aArrayList.Count - 1; i >= 0; i--)
            {
                if (aArrayList[i].ToString().Length == 0)
                {
                    aArrayList.RemoveAt(i);
                }
            }
            return aArrayList;
        }

        public static int Bool2Int(bool bBoolValue) => 
            (bBoolValue ? 1 : 0);

        public static string Bool2Sex(bool boolValue) => 
            (boolValue ? "Nam" : "Nữ");

        public static string Bool2String(bool bBoolValue) => 
            (bBoolValue ? "True" : "False");

        public static bool BoolStr2Bool(string sBoolean)
        {
            bool flag = false;
            string str2 = sBoolean.ToUpper();
            if (str2 == null)
            {
                return flag;
            }
            if (str2 != "TRUE")
            {
                if (str2 != "FALSE")
                {
                    return flag;
                }
            }
            else
            {
                return true;
            }
            return false;
        }

        public static int Calendar_DayOfYear(DateTime aAnyDate)
        {
            int[] numArray = new int[] { 0, 0x1f, 0x3b, 90, 120, 0x97, 0xb5, 0xd4, 0xf3, 0x111, 0x130, 0x14e };
            return ((numArray[aAnyDate.Month - 1] + aAnyDate.Day) + (((aAnyDate.Month > 2) && Calendar_IsLeapYear(aAnyDate.Year)) ? 1 : 0));
        }

        public static bool Calendar_IsLeapYear(int year) => 
            (((year % 4) == 0) && (((year % 100) != 0) || ((year % 400) == 0)));

        public static void CleanEditControls(Control parentControl, ActionOnControl action)
        {
            if (!License_TrialIsExpired())
            {
                foreach (Control control in parentControl.Controls)
                {
                    DevExpress.XtraEditors.Controls.SearchMode searchMode;
                    if ((((control is GroupControl) || (control is PanelControl)) || (control is LayoutControl)) || (control is XtraUserControl))
                    {
                        CleanEditControls(control, action);
                    }
                    else if (control is BaseEdit)
                    {
                        switch (action)
                        {
                            case ActionOnControl.ClearErrorIndicator:
                                ClearErrorMessage(control);
                                break;

                            case ActionOnControl.ClearEditContent:
                                goto Label_0098;
                        }
                    }
                    continue;
                Label_0098:
                    searchMode = SearchMode.OnlyInPopup;
                    if (control is LookUpEdit)
                    {
                        searchMode = ((LookUpEdit) control).Properties.SearchMode;
                        ((LookUpEdit) control).Properties.SearchMode = SearchMode.OnlyInPopup;
                    }
                    if (control is PictureEdit)
                    {
                        ((PictureEdit) control).DataBindings.Clear();
                        ((PictureEdit) control).Image = null;
                    }
                    else if (!(control is CheckEdit))
                    {
                        ((BaseEdit) control).Text = string.Empty;
                        ((BaseEdit) control).EditValue = null;
                    }
                    else
                    {
                        ((CheckEdit) control).Checked = false;
                    }
                    if (control is LookUpEdit)
                    {
                        ((LookUpEdit) control).Properties.SearchMode = searchMode;
                    }
                }
            }
        }

        public static void ClearErrorMessage(Control ctl)
        {
            errProvider.SetError(ctl, string.Empty);
        }

        public static void ClearReadOnlyDB(string FileName)
        {
            try
            {
                File.SetAttributes(FileName, FileAttributes.Normal);
            }
            catch
            {
            }
        }

        public static void ClearValidateForm(Control parentControl)
        {
            if (validError != null)
            {
                validError.Clear();
                validError.Dispose();
            }
        }

        public static object CorrectDBValue(object dBValue) => 
            ((dBValue == DBNull.Value) ? null : dBValue);

        public static string CreateUserNameFromFullName(string fullName)
        {
            string str = string.Empty;
            if (string.IsNullOrEmpty(fullName))
            {
                return str;
            }
            string[] strArray = Str_VietUnicodeSangKhongDau(fullName.Trim()).Split(new char[] { ' ' });
            if ((strArray != null) && (strArray.Length > 0))
            {
                str = strArray[strArray.Length - 1];
                for (int i = 0; i < (strArray.Length - 1); i++)
                {
                    if (strArray.Length > 0)
                    {
                        str = str + strArray[i][0].ToString();
                    }
                }
            }
            return str.ToLower();
        }

        public static string CreateUserNameFromFullNameWithHyphen(string fullName)
        {
            string str = string.Empty;
            if (string.IsNullOrEmpty(fullName))
            {
                return str;
            }
            string[] strArray = Str_VietUnicodeSangKhongDau(fullName.Trim()).Split(new char[] { ' ' });
            if ((strArray != null) && (strArray.Length > 0))
            {
                for (int i = 0; i < (strArray.Length - 1); i++)
                {
                    if (strArray.Length > 0)
                    {
                        str = str + strArray[i][0].ToString() + "_";
                    }
                }
                str = str + strArray[strArray.Length - 1];
            }
            return str.ToLower();
        }

        public static bool CurrentAppIsRunning() => 
            (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1);

        public static DataTable DataRowsToDataTable(DataRow[] aDTRC)
        {
            DataTable table = new DataTable();
            foreach (DataRow row in aDTRC)
            {
                table.ImportRow(row);
            }
            return table;
        }

        public static void DataRowsToDataTable(DataRow[] aDTRC, DataTable destDTB)
        {
            foreach (DataRow row in aDTRC)
            {
                destDTB.ImportRow(row);
            }
        }

        public static void DataTable_CopyData(DataTable srcDTB, DataTable destDTB, bool usingItemArrayMethod)
        {
            foreach (DataRow row2 in srcDTB.Rows)
            {
                if (usingItemArrayMethod)
                {
                    DataRow row = destDTB.NewRow();
                    row.ItemArray = row2.ItemArray;
                    destDTB.Rows.Add(row);
                }
                else
                {
                    destDTB.ImportRow(row2);
                }
            }
        }

        public static bool DataTableIsNullOrEmpty(DataTable dataTable) => 
            ((dataTable == null) || (dataTable.Rows.Count == 0));

        public static List<TSource> DataTableToList<TSource>(DataTable dataTable) where TSource: new()
        {
            List<TSource> list = new List<TSource>();
            var first = (from aProp in typeof(TSource).GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).Cast<PropertyInfo>() select new { 
                Name = aProp.Name,
                Type = Nullable.GetUnderlyingType(aProp.PropertyType) ?? aProp.PropertyType
            }).ToList();
            var second = (from aHeader in dataTable.Columns.Cast<DataColumn>() select new { 
                Name = aHeader.ColumnName,
                Type = aHeader.DataType
            }).ToList();
            var list4 = first.Intersect(second).ToList();
            foreach (DataRow row in dataTable.AsEnumerable().ToList<DataRow>())
            {
                TSource local2 = default(TSource);
                TSource local = (local2 == null) ? Activator.CreateInstance<TSource>() : (local2 = default(TSource));
                foreach (var type in list4)
                {
                    PropertyInfo property = local.GetType().GetProperty(type.Name);
                    if (!IsNullOrEmpty(row[type.Name]))
                    {
                        property.SetValue(local, row[type.Name], null);
                    }
                }
                list.Add(local);
            }
            return list;
        }

        public static DateTime Date_AddFirstTimeOfDay(DateTime day)
        {
            TimeSpan span = new TimeSpan(0, 0, 0);
            return day.Date.Add(span);
        }

        public static int Date_IndexDayOfWeek(string sTenThuTrongTuan_VN)
        {
            try
            {
                ArrayList list = new ArrayList { 
                    "chủ nhật",
                    "thứ hai",
                    "thứ ba",
                    "thứ tư",
                    "thứ năm",
                    "thứ s\x00e1u",
                    "thứ bảy"
                };
                return list.IndexOf(sTenThuTrongTuan_VN.Trim().ToLower());
            }
            catch
            {
                return -1;
            }
        }

        public static DateTime? DateEdit_GetDateTime(DateEdit dateEdit)
        {
            DateTime? nullable = null;
            if (EditValueIsValid(dateEdit.EditValue))
            {
                nullable = new DateTime?(DateTime.Parse(dateEdit.EditValue.ToString()));
            }
            return nullable;
        }

        public static string DayOfWeek_E2V(DayOfWeek aDayOfWeek)
        {
            switch (aDayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "Chủ Nhật";

                case DayOfWeek.Monday:
                    return "Thứ Hai";

                case DayOfWeek.Tuesday:
                    return "Thứ Ba";

                case DayOfWeek.Wednesday:
                    return "Thứ Tư";

                case DayOfWeek.Thursday:
                    return "Thứ Năm";

                case DayOfWeek.Friday:
                    return "Thứ S\x00e1u";

                case DayOfWeek.Saturday:
                    return "Thứ Bảy";
            }
            return null;
        }

        public static void DebugPrint(string sPrint)
        {
            Debug.WriteLine(sPrint);
        }

        public static float DiemSo_Round(double dValue, int iDigits, int iSoChuSoThapPhanGiuLaiTruocLamTron)
        {
            float num3 = (float) Math.Round(dValue, iDigits);
            string s = dValue.ToString();
            int index = s.IndexOf(".");
            if (index <= 0)
            {
                return num3;
            }
            int num2 = (s.Length - index) - 1;
            if (num2 > iSoChuSoThapPhanGiuLaiTruocLamTron)
            {
                s = s.Remove((index + 1) + iSoChuSoThapPhanGiuLaiTruocLamTron, num2 - iSoChuSoThapPhanGiuLaiTruocLamTron);
                num2 = iSoChuSoThapPhanGiuLaiTruocLamTron;
            }
            string str2 = s;
            double num5 = double.Parse(s);
            if (iDigits <= num2)
            {
                for (int i = str2.Length - 1; i > (index + iDigits); i--)
                {
                    if (int.Parse(str2.Substring(i, 1)) >= 5)
                    {
                        double num4 = Math.Pow(10.0, (double) -((i - index) - 1));
                        s = (num5 + num4).ToString();
                    }
                }
                return float.Parse(s.Substring(0, (index + iDigits) + 1));
            }
            return float.Parse(s.Substring(0, (index + num2) + 1));
        }

        private static void Directory_Iterate(string p_TargetDir, string p_FilePattern, ref Hashtable p_htDirs, ref Hashtable p_htFiles)
        {
            try
            {
                string[] files = Directory.GetFiles(p_TargetDir, p_FilePattern);
                string[] directories = Directory.GetDirectories(p_TargetDir);
                p_htDirs.Remove(p_TargetDir);
                Hashtable hashtable = new Hashtable(0x1388);
                Hashtable hashtable2 = new Hashtable(0x1388);
                int index = 0;
                int num2 = 0;
                for (index = 0; index < directories.Length; index++)
                {
                    try
                    {
                        p_htDirs.Add(directories[index], directories[index]);
                        hashtable.Add(directories[index], directories[index]);
                    }
                    catch
                    {
                    }
                }
                for (num2 = 0; num2 < files.Length; num2++)
                {
                    try
                    {
                        p_htFiles.Add(files[num2], files[num2]);
                        hashtable2.Add(files[num2], files[num2]);
                    }
                    catch
                    {
                    }
                }
                while (hashtable.Count > 0)
                {
                    IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
                    enumerator.MoveNext();
                    hashtable.Remove(enumerator.Key.ToString());
                }
                while (hashtable2.Count > 0)
                {
                    IDictionaryEnumerator enumerator = hashtable2.GetEnumerator();
                    enumerator.MoveNext();
                    hashtable2.Remove(enumerator.Key.ToString());
                }
            }
            catch
            {
                p_htDirs.Remove(p_TargetDir);
            }
        }

        public static bool EditValueIsValid(object editValue) => 
            (((editValue != null) && (editValue != DBNull.Value)) && (editValue.ToString().Trim().Length > 0));

        public static bool EmailIsValid(string emailAddress)
        {
            string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
            return Regex.Match(emailAddress.Trim(), pattern, RegexOptions.IgnoreCase).Success;
        }

        private void ExtractImages(DevExpress.Utils.ImageCollection imageCollection)
        {
            if (imageCollection != null)
            {
                int num = 0;
                foreach (Image image in imageCollection.Images)
                {
                    num++;
                    image.Save(num.ToString() + ".PNG", ImageFormat.Png);
                }
            }
        }

        public static void File_CreateList(string p_TargetDir, string p_FilePattern, ref Hashtable p_htDirs, ref Hashtable p_htFiles, bool p_SearchSubdirs)
        {
            string currentDirectory;
            if (p_TargetDir.Length != 0)
            {
                currentDirectory = p_TargetDir;
            }
            else
            {
                currentDirectory = Directory.GetCurrentDirectory();
            }
            try
            {
                string[] files = Directory.GetFiles(currentDirectory, p_FilePattern);
                string[] directories = Directory.GetDirectories(currentDirectory);
                for (int i = 0; i < directories.Length; i++)
                {
                    p_htDirs.Add(directories[i], directories[i]);
                }
                for (int j = 0; j < files.Length; j++)
                {
                    p_htFiles.Add(files[j], files[j]);
                }
                if (p_SearchSubdirs)
                {
                    while (p_htDirs.Count > 0)
                    {
                        IDictionaryEnumerator enumerator = p_htDirs.GetEnumerator();
                        enumerator.MoveNext();
                        Directory_Iterate(enumerator.Key.ToString(), p_FilePattern, ref p_htDirs, ref p_htFiles);
                    }
                }
            }
            catch
            {
            }
        }

        public static enuFileType File_GetType(string sFileName)
        {
            enuFileType uNKNOWN = enuFileType.UNKNOWN;
            if (string.IsNullOrEmpty(sFileName))
            {
                return uNKNOWN;
            }
            string str2 = Path.GetExtension(sFileName).ToUpper();
            if (str2 == null)
            {
                return uNKNOWN;
            }
            if ((str2 != ".XLS") && (str2 != ".XLSX"))
            {
                if ((str2 != ".DOC") && (str2 != ".DOCX"))
                {
                    if (str2 == ".MDB")
                    {
                        return enuFileType.MSACCESS;
                    }
                    if (str2 != ".DBF")
                    {
                        return uNKNOWN;
                    }
                    return enuFileType.DBF;
                }
            }
            else
            {
                return enuFileType.EXCEL;
            }
            return enuFileType.DOC;
        }

        public static int FindMaxValue(int[] arrValues)
        {
            if ((arrValues == null) || (arrValues.Length == 0))
            {
                return 0;
            }
            int num = arrValues[0];
            for (int i = 0; i < arrValues.Length; i++)
            {
                if (num < arrValues[i])
                {
                    num = arrValues[i];
                }
            }
            return num;
        }

        public static int FindMinValue(int[] arrValues)
        {
            if ((arrValues == null) || (arrValues.Length == 0))
            {
                return 0;
            }
            int num = arrValues[0];
            for (int i = 0; i < arrValues.Length; i++)
            {
                if (num > arrValues[i])
                {
                    num = arrValues[i];
                }
            }
            return num;
        }

        public static string FixBooleanTypeInSQLCmd(string sSQL, string sBoolean)
        {
            string str = null;
            string str3 = sBoolean.ToUpper();
            int length = str3.Length;
            for (int i = 0; i < sSQL.Length; i++)
            {
                string str2 = sSQL.Substring(i, 1);
                if (str2.ToUpper() == str3.Substring(0, 1))
                {
                    if ((i + length) > sSQL.Length)
                    {
                        str2 = sSQL.Substring(i, sSQL.Length - i);
                    }
                    else
                    {
                        str2 = sSQL.Substring(i, length);
                    }
                    if (str2.ToUpper() != str3)
                    {
                        goto Label_0117;
                    }
                    i += length - 1;
                    int num = 0;
                    for (int j = 0; j < i; j++)
                    {
                        if (sSQL[j] == '\'')
                        {
                            num++;
                        }
                    }
                    if ((num % 2) == 0)
                    {
                        switch (str3)
                        {
                            case "TRUE":
                                str2 = "1";
                                break;

                            case "FALSE":
                                goto Label_010B;
                        }
                    }
                }
                goto Label_0121;
            Label_010B:
                str2 = "0";
                goto Label_0121;
            Label_0117:
                str2 = str2.Substring(0, 1);
            Label_0121:
                str = str + str2;
            }
            return str;
        }

        public static string FixSQLCmdForUnicode(string sSQL)
        {
            int num = 0;
            string str = sSQL.Trim();
            string str2 = null;
            bool flag = false;
            int length = str.Length;
            for (int i = 0; i < length; i++)
            {
                flag = false;
                if (str[i] == '\'')
                {
                    num++;
                    if (((num % 2) == 1) && (i > 0))
                    {
                        char ch = str[i - 1];
                        if (ch != '\'')
                        {
                            flag = true;
                        }
                    }
                }
                str2 = str2 + (flag ? "N" : null) + str.Substring(i, 1);
            }
            return str2;
        }

        public static string FixSQLCmdForUnicode_old(string sSQL)
        {
            int num = 0;
            string str = sSQL.Trim();
            string str2 = str.Substring(0, "INSERT".Length).ToUpper();
            string str3 = str.Substring(0, "UPDATE".Length).ToUpper();
            bool flag = str2 == "INSERT";
            bool flag2 = str3 == "UPDATE";
            if (!(flag || flag2))
            {
                return sSQL;
            }
            int index = str.IndexOf("WHERE");
            string str4 = null;
            bool flag3 = false;
            bool flag4 = true;
            if (flag)
            {
                flag4 = str.IndexOf("VALUES") != -1;
            }
            if (flag4)
            {
                index = (index == -1) ? str.Length : index;
                for (int i = 0; i < index; i++)
                {
                    flag3 = false;
                    if (str[i] == '\'')
                    {
                        num++;
                        if (((num % 2) == 1) && (i > 0))
                        {
                            char ch = str[i - 1];
                            if (ch != '\'')
                            {
                                flag3 = true;
                            }
                        }
                    }
                    str4 = str4 + (flag3 ? "N" : null) + str.Substring(i, 1);
                }
                return (str4 + str.Substring(index, str.Length - index));
            }
            return str;
        }

        public static string FixSQLDeleteCmd(string sSQL)
        {
            string str = sSQL;
            if (string.IsNullOrEmpty(sSQL))
            {
                return str;
            }
            if (sSQL.ToUpper().IndexOf("DELETE") != -1)
            {
                return sSQL.Replace("Delete", "DELETE").Replace("delete", "DELETE").Replace("DELETE *", "DELETE").Replace("DELETE  *", "DELETE");
            }
            return sSQL;
        }

        public static string FixSQLString(string s) => 
            s?.Replace("'", "''");

        public static float Float_Parse(string sFloat)
        {
            NumberFormatInfo provider = new NumberFormatInfo {
                NumberDecimalSeparator = "."
            };
            try
            {
                return float.Parse(sFloat, provider);
            }
            catch
            {
                return -1f;
            }
        }

        public static string Font_UNI2VNI(string unicodeStr)
        {
            if (string.IsNullOrEmpty(unicodeStr))
            {
                return string.Empty;
            }
            int[] numArray = new int[] { 
                0x1ea5, 0x1ea7, 0x1ea9, 0x1eab, 0x1ead, 0xe2, 0xe1, 0xe0, 0x1ea3, 0xe3, 0x1ea1, 0x1eaf, 0x1eb1, 0x1eb3, 0x1eb5, 0x1eb7,
                0x103, 250, 0xf9, 0x1ee7, 0x169, 0x1ee5, 0x1ee9, 0x1eeb, 0x1eed, 0x1eef, 0x1ef1, 0x1b0, 0x1ebf, 0x1ec1, 0x1ec3, 0x1ec5,
                0x1ec7, 0xea, 0xe9, 0xe8, 0x1ebb, 0x1ebd, 0x1eb9, 0x1ed1, 0x1ed3, 0x1ed5, 0x1ed7, 0x1ed9, 0xf4, 0xf3, 0xf2, 0x1ecf,
                0xf5, 0x1ecd, 0x1edb, 0x1edd, 0x1edf, 0x1ee1, 0x1ee3, 0x1a1, 0xed, 0xec, 0x1ec9, 0x129, 0x1ecb, 0xfd, 0x1ef3, 0x1ef7,
                0x1ef9, 0x1ef5, 0x111, 0x1ea4, 0x1ea6, 0x1ea8, 0x1eaa, 0x1eac, 0xc2, 0xc1, 0xc0, 0x1ea2, 0xc3, 0x1ea0, 0x1eae, 0x1eb0,
                0x1eb2, 0x1eb4, 0x1eb6, 0x102, 0xda, 0xd9, 0x1ee6, 360, 0x1ee4, 0x1ee8, 0x1eea, 0x1eec, 0x1eee, 0x1ef0, 0x1af, 0x1ebe,
                0x1ec0, 0x1ec2, 0x1ec4, 0x1ec6, 0xca, 0xc9, 200, 0x1eba, 0x1ebc, 0x1eb8, 0x1ed0, 0x1ed2, 0x1ed4, 0x1ed6, 0x1ed8, 0xd4,
                0xd3, 210, 0x1ece, 0xd5, 0x1ecc, 0x1eda, 0x1edc, 0x1ede, 0x1ee0, 0x1ee2, 0x1a0, 0xcd, 0xcc, 0x1ec8, 0x128, 0x1eca,
                0xdd, 0x1ef2, 0x1ef6, 0x1ef8, 0x1ef4, 0x110
            };
            string[] strArray = new string[] { 
                "a\x00e1", "a\x00e0", "a\x00e5", "a\x00e3", "a\x00e4", "a\x00e2", "a\x00f9", "a\x00f8", "a\x00fb", "a\x00f5", "a\x00ef", "a\x00e9", "a\x00e8", "a\x00fa", "a\x00fc", "a\x00eb",
                "a\x00ea", "u\x00f9", "u\x00f8", "u\x00fb", "u\x00f5", "u\x00ef", "\x00f6\x00f9", "\x00f6\x00f8", "\x00f6\x00fb", "\x00f6\x00f5", "\x00f6\x00ef", "\x00f6", "e\x00e1", "e\x00e0", "e\x00e5", "e\x00e3",
                "e\x00e4", "e\x00e2", "e\x00f9", "e\x00f8", "e\x00fb", "e\x00f5", "e\x00ef", "o\x00e1", "o\x00e0", "o\x00e5", "o\x00e3", "o\x00e4", "o\x00e2", "o\x00f9", "o\x00f8", "o\x00fb",
                "o\x00f5", "o\x00ef", "\x00f4\x00f9", "\x00f4\x00f8", "\x00f4\x00fb", "\x00f4\x00f5", "\x00f4\x00ef", "\x00f4", "\x00ed", "\x00ec", "\x00e6", "\x00f3", "\x00f2", "y\x00f9", "y\x00f8", "y\x00fb",
                "y\x00f5", "\x00ee", "\x00f1", "A\x00c1", "A\x00c0", "A\x00c5", "A\x00c3", "A\x00c4", "A\x00c2", "A\x00d9", "A\x00d8", "A\x00db", "A\x00d5", "A\x00cf", "A\x00c9", "A\x00c8",
                "A\x00da", "A\x00dc", "A\x00cb", "A\x00ca", "U\x00d9", "U\x00d8", "U\x00db", "U\x00d5", "U\x00cf", "\x00d6\x00d9", "\x00d6\x00d8", "\x00d6\x00db", "\x00d6\x00d5", "\x00d6\x00cf", "\x00d6", "E\x00c1",
                "E\x00c0", "E\x00c5", "E\x00c3", "E\x00c4", "E\x00c2", "E\x00d9", "E\x00d8", "E\x00db", "E\x00d5", "E\x00cf", "O\x00c1", "O\x00c0", "O\x00c5", "O\x00c3", "O\x00c4", "O\x00c2",
                "O\x00d9", "O\x00d8", "O\x00db", "O\x00d5", "O\x00cf", "\x00d4\x00d9", "\x00d4\x00d8", "\x00d4\x00db", "\x00d4\x00d5", "\x00d4\x00cf", "\x00d4", "\x00cd", "\x00cc", "\x00c6", "\x00d3", "\x00d2",
                "Y\x00d9", "Y\x00d8", "Y\x00db", "Y\x00d5", "\x00ce", "\x00d1"
            };
            string[] strArray2 = new string[] { 
                "aau\x00f8", "aa\x00f8", "aao\x00f5", "au\x00f8", "ao\x00f5", "ae\x00f9", "ae\x00f8", "auu\x00f8", "ae\x00e2", "uu\x00f8", "uo\x00f5", "\x00f6o\x00f5", "eo\x00f5", "AAU\x00d8", "AA\x00d8", "AAO\x00d5",
                "AU\x00d8", "AO\x00d5", "AE\x00d9", "AE\x00d8", "AUU\x00d8", "AE\x00c2", "UU\x00d8", "UO\x00d5", "\x00d6O\x00d5", "EO\x00d5"
            };
            string[] strArray3 = new string[] { 
                "a\x00e1", "a\x00e0", "a\x00e3", "a\x00f9", "a\x00f5", "a\x00e9", "a\x00e8", "a\x00fa", "a\x00ea", "u\x00f9", "u\x00f5", "\x00f6\x00f5", "e\x00f5", "A\x00c1", "A\x00c0", "A\x00c3",
                "A\x00d9", "A\x00d5", "A\x00c9", "A\x00c8", "A\x00da", "A\x00ca", "U\x00d9", "U\x00d5", "\x00d6\x00d5", "E\x00d5"
            };
            string str = unicodeStr;
            for (int i = 0; i < numArray.Length; i++)
            {
                str = str.Replace(Convert.ToString((char) numArray[i]), strArray[i]);
            }
            for (int j = 0; j < strArray3.Length; j++)
            {
                str = str.Replace(strArray2[j], strArray3[j]);
            }
            return str;
        }

        public static string Font_VNI2UNI(string VNIStr)
        {
            if (string.IsNullOrEmpty(VNIStr))
            {
                return string.Empty;
            }
            int[] numArray = new int[] { 
                0x1ea5, 0x1ea7, 0x1ea9, 0x1eab, 0x1ead, 0xe2, 0x1ea3, 0xe3, 0x1ea1, 0x1eaf, 0x1eb1, 0x1eb3, 0x1eb5, 0x1eb7, 0x103, 250,
                0xf9, 0x1ee7, 0x169, 0x1ee5, 0x1ee9, 0x1eeb, 0x1eed, 0x1eef, 0x1ef1, 0x1b0, 0x1ebf, 0x1ec1, 0x1ec3, 0x1ec5, 0x1ec7, 0xea,
                0xe9, 0xe8, 0x1ebb, 0x1ebd, 0x1eb9, 0x1ed1, 0x1ed3, 0x1ed5, 0x1ed7, 0x1ed9, 0x1ecf, 0xf5, 0x1ecd, 0x1edb, 0x1edd, 0x1edf,
                0x1ee1, 0x1ee3, 0x1a1, 0xed, 0xec, 0x1ec9, 0x129, 0x1ecb, 0xfd, 0x1ef3, 0x1ef7, 0x1ef9, 0x1ef5, 0x111, 0x1ea4, 0x1ea6,
                0x1ea8, 0x1eaa, 0x1eac, 0xc2, 0x1ea2, 0xc3, 0x1ea0, 0x1eae, 0x1eb0, 0x1eb2, 0x1eb4, 0x1eb6, 0x102, 0xda, 0xd9, 0x1ee6,
                360, 0x1ee4, 0x1ee8, 0x1eea, 0x1eec, 0x1eee, 0x1ef0, 0x1af, 0x1ebe, 0x1ec0, 0x1ec2, 0x1ec4, 0x1ec6, 0xca, 0xc9, 200,
                0x1eba, 0x1ebc, 0x1eb8, 0x1ed0, 0x1ed2, 0x1ed4, 0x1ed6, 0x1ed8, 0x1ece, 0xd5, 0x1ecc, 0x1eda, 0x1edc, 0x1ede, 0x1ee0, 0x1ee2,
                0x1a0, 0xcd, 0xcc, 0x1ec8, 0x128, 0x1eca, 0xdd, 0x1ef2, 0x1ef6, 0x1ef8, 0x1ef4, 0x110, 0xe1, 0xe0, 0xf4, 0xf3,
                0xf2, 0xc1, 0xc0, 0xd4, 0xd3, 210
            };
            string[] strArray = new string[] { 
                "a\x00e1", "a\x00e0", "a\x00e5", "a\x00e3", "a\x00e4", "a\x00e2", "a\x00fb", "a\x00f5", "a\x00ef", "a\x00e9", "a\x00e8", "a\x00fa", "a\x00fc", "a\x00eb", "a\x00ea", "u\x00f9",
                "u\x00f8", "u\x00fb", "u\x00f5", "u\x00ef", "\x00f6\x00f9", "\x00f6\x00f8", "\x00f6\x00fb", "\x00f6\x00f5", "\x00f6\x00ef", "\x00f6", "e\x00e1", "e\x00e0", "e\x00e5", "e\x00e3", "e\x00e4", "e\x00e2",
                "e\x00f9", "e\x00f8", "e\x00fb", "e\x00f5", "e\x00ef", "o\x00e1", "o\x00e0", "o\x00e5", "o\x00e3", "o\x00e4", "o\x00fb", "o\x00f5", "o\x00ef", "\x00f4\x00f9", "\x00f4\x00f8", "\x00f4\x00fb",
                "\x00f4\x00f5", "\x00f4\x00ef", "\x00f4", "\x00ed", "\x00ec", "\x00e6", "\x00f3", "\x00f2", "y\x00f9", "y\x00f8", "y\x00fb", "y\x00f5", "\x00ee", "\x00f1", "A\x00c1", "A\x00c0",
                "A\x00c5", "A\x00c3", "A\x00c4", "A\x00c2", "A\x00db", "A\x00d5", "A\x00cf", "A\x00c9", "A\x00c8", "A\x00da", "A\x00dc", "A\x00cb", "A\x00ca", "U\x00d9", "U\x00d8", "U\x00db",
                "U\x00d5", "U\x00cf", "\x00d6\x00d9", "\x00d6\x00d8", "\x00d6\x00db", "\x00d6\x00d5", "\x00d6\x00cf", "\x00d6", "E\x00c1", "E\x00c0", "E\x00c5", "E\x00c3", "E\x00c4", "E\x00c2", "E\x00d9", "E\x00d8",
                "E\x00db", "E\x00d5", "E\x00cf", "O\x00c1", "O\x00c0", "O\x00c5", "O\x00c3", "O\x00c4", "O\x00db", "O\x00d5", "O\x00cf", "\x00d4\x00d9", "\x00d4\x00d8", "\x00d4\x00db", "\x00d4\x00d5", "\x00d4\x00cf",
                "\x00d4", "\x00cd", "\x00cc", "\x00c6", "\x00d3", "\x00d2", "Y\x00d9", "Y\x00d8", "Y\x00db", "Y\x00d5", "\x00ce", "\x00d1", "a\x00f9", "a\x00f8", "o\x00e2", "o\x00f9",
                "o\x00f8", "A\x00d9", "A\x00d8", "O\x00c2", "O\x00d9", "O\x00d8"
            };
            string[] strArray2 = new string[] { 
                "aau\x00f8", "aa\x00f8", "aao\x00f5", "au\x00f8", "ao\x00f5", "ae\x00f9", "ae\x00f8", "auu\x00f8", "ae\x00e2", "uu\x00f8", "uo\x00f5", "\x00f6o\x00f5", "eo\x00f5", "AAU\x00d8", "AA\x00d8", "AAO\x00d5",
                "AU\x00d8", "AO\x00d5", "AE\x00d9", "AE\x00d8", "AUU\x00d8", "AE\x00c2", "UU\x00d8", "UO\x00d5", "\x00d6O\x00d5", "EO\x00d5"
            };
            string[] strArray3 = new string[] { 
                "a\x00e1", "a\x00e0", "a\x00e3", "a\x00f9", "a\x00f5", "a\x00e9", "a\x00e8", "a\x00fa", "a\x00ea", "u\x00f9", "u\x00f5", "\x00f6\x00f5", "e\x00f5", "A\x00c1", "A\x00c0", "A\x00c3",
                "A\x00d9", "A\x00d5", "A\x00c9", "A\x00c8", "A\x00da", "A\x00ca", "U\x00d9", "U\x00d5", "\x00d6\x00d5", "E\x00d5"
            };
            string str = VNIStr;
            for (int i = 0; i < numArray.Length; i++)
            {
                str = str.Replace(strArray[i], Convert.ToString((char) numArray[i]));
            }
            return str;
        }

        public static void FormatGrid(GridView grvMain, string listFieldsHide, string listFieldsShow)
        {
            int num;
            string[] strArray = listFieldsHide.Split(new char[] { '|' });
            for (num = 0; num < strArray.Length; num++)
            {
                if (!strArray[num].Trim().Equals(""))
                {
                    grvMain.Columns[strArray[num]].Visible = false;
                }
            }
            string[] strArray2 = listFieldsShow.Split(new char[] { '|' });
            for (num = 0; num < strArray2.Length; num++)
            {
                if (!strArray2[num].Trim().Equals(""))
                {
                    grvMain.Columns[strArray2[num]].VisibleIndex = num;
                }
            }
        }

        public static void FormatGrid1(GridView grvMain, string listFieldsStt, RepositoryItemDateEdit repositoryItemDateEdit1)
        {
            string[] strArray = listFieldsStt.Split(new char[] { '|' });
            for (int i = 0; i < strArray.Length; i++)
            {
                grvMain.Columns[strArray[i]].VisibleIndex = i;
                if (strArray[i].Contains("Time"))
                {
                    grvMain.Columns[strArray[i]].ColumnEdit = repositoryItemDateEdit1;
                }
            }
            grvMain.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
        }

        public static void FormatGrid2(GridView grvMain, string listFieldsHide, string listFieldsShow)
        {
            int num;
            string[] strArray = listFieldsHide.Split(new char[] { '|' });
            for (num = 0; num < strArray.Length; num++)
            {
                if (!strArray[num].Trim().Equals(""))
                {
                    grvMain.Columns[strArray[num]].Visible = false;
                }
            }
            string[] strArray2 = listFieldsShow.Split(new char[] { '|' });
            for (num = 0; num < strArray2.Length; num++)
            {
                if (!strArray2[num].Trim().Equals(""))
                {
                    grvMain.Columns[strArray2[num]].VisibleIndex = num;
                }
            }
        }

        public static void FormatGridLayout(string[] arrFieldsName, string[] arrColumnsCaption, GridView gridView)
        {
            if (!License_TrialIsExpired() && (!ArrayIsNullOrEmpty(arrFieldsName) && !ArrayIsNullOrEmpty(arrColumnsCaption)))
            {
                for (int i = 0; i < gridView.Columns.Count; i++)
                {
                    gridView.Columns[i].Caption = arrColumnsCaption[i];
                    gridView.Columns[i].FieldName = arrFieldsName[i];
                    gridView.Columns[i].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                    if ("System.Decimal|System.Int32".Contains(gridView.Columns[i].ColumnType.ToString()))
                    {
                        gridView.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                    }
                    else
                    {
                        gridView.Columns[i].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    }
                }
            }
        }

        public static string FormatNumber(decimal So, int SoThapPhan)
        {
            CultureInfo info = new CultureInfo("en-US", false);
            Thread.CurrentThread.CurrentCulture = info;
            NumberFormatInfo numberFormat = info.NumberFormat;
            numberFormat.NumberDecimalDigits = SoThapPhan;
            return So.ToString("N", numberFormat);
        }

        public static void FormatNumberColumn(GridView gridView, ArrayList fieldNames)
        {
            if (!License_TrialIsExpired() && (fieldNames.Count != 0))
            {
                foreach (GridColumn column in gridView.Columns)
                {
                    if (fieldNames.Contains(column.FieldName))
                    {
                        column.DisplayFormat.FormatType = FormatType.Numeric;
                        column.DisplayFormat.FormatString = "N0";
                    }
                }
            }
        }

        public static void FormatNumberColumn(GridView gridView, string fieldName)
        {
            if (!License_TrialIsExpired() && !string.IsNullOrEmpty(fieldName))
            {
                foreach (GridColumn column in gridView.Columns)
                {
                    if (fieldName.Equals(column.FieldName))
                    {
                        column.DisplayFormat.FormatType = FormatType.Numeric;
                        column.DisplayFormat.FormatString = "N0";
                        break;
                    }
                }
            }
        }

        public static string GetAddressRandom()
        {
            string[] strArray = new string[] { "H\x00f9ng Vương", "Trần Ph\x00fa", "Quang Trung", "H\x00e0m Nghi", "L\x00ea Lợi", "Phan Ch\x00e2u Trinh", "L\x00fd Th\x00e1i Tổ", "Ho\x00e0ng Diệu", "Pasteur", "L\x00ea Duẩn", "Đống Đa" };
            int index = Random_(aRandom, 1, strArray.Length) - 1;
            return string.Concat(new object[] { Random(0x3e7L, 1L).ToString(), ' ', strArray[index], ", Đ\x00e0 Nẵng" });
        }

        public static ArrayList GetArrayListTablesFromDataset(DataSet dtsDataSet)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < dtsDataSet.Tables.Count; i++)
            {
                list.Add(dtsDataSet.Tables[i].TableName);
            }
            return list;
        }

        public static bool GetBooleanRandom() => 
            (Random(1L, 0L) == 1L);

        public static bool? GetBoolValue(object oValue)
        {
            bool? nullable = null;
            try
            {
                if (!IsNull(oValue))
                {
                    nullable = new bool?(bool.Parse(oValue.ToString()));
                }
            }
            catch
            {
            }
            return nullable;
        }

        public static DataRow[] GetData(string sSql, OleDbConnection aOleDbConnection)
        {
            try
            {
                DataSet dataSet = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter(sSql, aOleDbConnection);
                dataSet.Tables.Add("Result");
                adapter.Fill(dataSet, "Result");
                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                DataRow[] rowArray = new DataRow[dataSet.Tables[0].Rows.Count];
                return dataSet.Tables[0].Select();
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                return null;
            }
        }

        public DataTable GetDataTable(string sSql, OleDbConnection aOleDbConnection)
        {
            try
            {
                DataSet dataSet = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter(sSql, aOleDbConnection);
                dataSet.Tables.Add("Result");
                adapter.Fill(dataSet, "Result");
                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return dataSet.Tables[0];
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                return null;
            }
        }

        public static string GetDateRandom(bool isDateVN)
        {
            if (isDateVN)
            {
                return string.Concat(new object[] { Random(0x1cL, 1L), "/", Random(12L, 1L), "/", Random(0x7d4L, 0x7d0L) });
            }
            return string.Concat(new object[] { Random(12L, 1L), "/", Random(0x1cL, 1L), "/", Random(0x7d4L, 0x7d0L) });
        }

        public static string GetDBNameNoPath(string sFullName)
        {
            int num = sFullName.LastIndexOf(@"\");
            return sFullName.Substring(num + 1, (sFullName.Length - 1) - num);
        }

        public static string GetDBPathFromRegistry(string sSubKey, string sValueName)
        {
            string str = null;
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(sSubKey);
                if (key != null)
                {
                    str = key.GetValue(sValueName).ToString();
                    key.Close();
                }
            }
            catch
            {
            }
            return str;
        }

        public static string GetDBSQLSourceName(string sSQLConnectionString)
        {
            string str = @"SQL Server: \\";
            int index = sSQLConnectionString.IndexOf("Data Source=");
            int num2 = sSQLConnectionString.IndexOf(";", index);
            str = str + sSQLConnectionString.Substring(index + "Data Source=".Length, num2 - (index + "Data Source=".Length));
            index = sSQLConnectionString.IndexOf("Database=");
            num2 = sSQLConnectionString.IndexOf(";", index);
            return (str + @"\" + sSQLConnectionString.Substring(index + "Database=".Length, num2 - (index + "Database=".Length)));
        }

        public static decimal GetDecimalValue(object decimalValue)
        {
            decimal num = 0M;
            try
            {
                if (!IsNull(decimalValue))
                {
                    num = decimal.Parse(decimalValue.ToString());
                }
            }
            catch
            {
                num = 0M;
            }
            return num;
        }

        public static string GetDefaultPrinterNameOnSystem()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string str in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = str;
                if (settings.IsDefaultPrinter)
                {
                    return str;
                }
            }
            return string.Empty;
        }

        public static string GetFirstChar(string s) => 
            ((s.Length > 0) ? s.Substring(0, 1) : "");

        public static string GetFirstNameRandom()
        {
            string[] strArray = new string[] { "Nguyễn", "Trần", "L\x00ea", "L\x00fd", "Trịnh", "Phạm", "Hồ", "T\x00f4n Nữ", "Phan", "Th\x00e1i", "Đinh" };
            int index = Random_(aRandom, 1, strArray.Length) - 1;
            return strArray[index];
        }

        public static string GetHinhThucDanhGiaRandom()
        {
            string[] strArray = new string[] { "Kh\x00e1", "Giỏi", "Yếu", "K\x00e9m", "TB" };
            int index = ((int) Random((long) strArray.Length, 1L)) - 1;
            return strArray[index];
        }

        public static int GetIntValue(object integerValue)
        {
            int num = 0;
            try
            {
                if (!IsNull(integerValue))
                {
                    num = int.Parse(integerValue.ToString());
                }
            }
            catch
            {
                num = 0;
            }
            return num;
        }

        public static int? GetIntValue_AllowNull(object integerValue)
        {
            int? nullable = null;
            try
            {
                if (!IsNull(integerValue))
                {
                    nullable = new int?(int.Parse(integerValue.ToString()));
                }
            }
            catch
            {
                nullable = null;
            }
            return nullable;
        }

        public static string GetLastNameRandom()
        {
            string[] strArray = new string[] { 
                "Nguy\x00ean", "Minh", "Long", "Ly", "Trinh", "Hương", "Duy\x00ean", "Mai", "Phương", "Ngọc", "Anh", "Dung", "Vũ", "Tuấn", "Quỳnh", "Linh",
                "Chi", "Nam", "Thứ", "Giao", "Nh\x00e0n", "Đ\x00f4ng", "Nghĩa", "Thịnh", "Chinh", "Giang", "Thu\x00fd", "Thy", "Ti\x00ean", "L\x00fd", "Lệ", "Diễm"
            };
            int index = Random_(aRandom, 1, strArray.Length) - 1;
            return strArray[index];
        }

        public static string GetMiddleNameRandom()
        {
            string[] strArray = new string[] { "Thị", "Quang", "V\x00e2n", "C\x00f4ng", "Phước", "Đức", "Mai", "Phương", "Ngọc", "Anh", "Diệu", "Thanh", "Huyền", "Quỳnh" };
            int index = Random_(aRandom, 1, strArray.Length) - 1;
            return strArray[index];
        }

        public static string GetNgheNghiepRandom()
        {
            string[] strArray = new string[] { "C\x00f4ng nh\x00e2n", "Thợ nề", "Gi\x00e1o vi\x00ean", "B\x00e1c sĩ", "Bộ đội", "Bu\x00f4n b\x00e1n", "Vi\x00ean chức", "Nh\x00e0 b\x00e1o", "Thương gia", "Nh\x00e0 văn" };
            int index = Random_(aRandom, 1, strArray.Length) - 1;
            return strArray[index];
        }

        public static object GetSelectedCellValue(GridView gridView, string fieldName)
        {
            if (gridView.IsGroupRow(gridView.FocusedRowHandle) || (gridView.FocusedRowHandle < 0))
            {
                return null;
            }
            try
            {
                DataRowView row = gridView.GetRow(gridView.FocusedRowHandle) as DataRowView;
                return row[fieldName];
            }
            catch (Exception exception)
            {
                WriteLogFile("AppLog.txt", exception.Message, true);
                return null;
            }
        }

        public static string GetTempNameFromCurrentDateTime()
        {
            DateTime now = DateTime.Now;
            string[] strArray = new string[5];
            strArray[0] = now.Day.ToString().PadLeft(2, '0');
            strArray[1] = now.Month.ToString().PadLeft(2, '0');
            int num = now.Year % 0x3e8;
            strArray[2] = num.ToString().PadLeft(2, '0');
            strArray[3] = now.Hour.ToString().PadLeft(2, '0');
            strArray[4] = now.Minute.ToString().PadLeft(2, '0');
            return string.Concat(strArray);
        }

        public static string GetTenDanTocRandom()
        {
            string[] strArray = new string[] { 
                "Kinh", "T\x00e0y", "N\x00f9ng", "M\x00f4ng", "Mường", "Dao", "Khmer", "\x00cađ\x00ea", "CaoLan", "Th\x00e1i", "Gia rai", "La ch\x00ed", "H\x00e0 nh\x00ec", "Gi\x00e1y", "M'n\x00f4ng", "C\x00e0 tu",
                "X\x00eađăng", "Xti\x00eang", "Bana", "H'r\x00ea", "Gi\x00e9 tri\x00eang", "Chăm", "Cơ ho", "Mạ", "S\x00e1n D\x00ecu", "Thổ", "Khơ m\x00fa", "V\x00e2n kiều", "T\x00e0 \x00f4i", "Co", "Chơ ro", "Xinh mun",
                "Chu ru", "Phu l\x00e1", "La h\x00fa", "Kh\x00e1ng", "Lự", "Pa (Th\x00e8n)", "L\x00f4 l\x00f4", "Ch\x00fat", "Mảng", "Cơ lao", "Bố y", "La ha", "C\x00f4\x00f4ng", "Ng\x00e1i", "Si la", "Pu p\x00e9o",
                "Br\x00e2u", "Rơ măm", "Ơ đu", "Hoa"
            };
            int index = ((int) Random((long) strArray.Length, 1L)) - 1;
            return strArray[index];
        }

        public static string GetTextFitControl(string fontName, float fontSize, string orgText, int controlWidth)
        {
            string str = orgText;
            if (!string.IsNullOrEmpty(orgText))
            {
                Font font = new Font(fontName, fontSize);
                Size size = TextRenderer.MeasureText(orgText, font);
                if (size.Width > controlWidth)
                {
                    float num = size.Width / orgText.Length;
                    int length = (int) (((float) controlWidth) / num);
                    str = orgText.Substring(0, length);
                }
            }
            return str;
        }

        public static int GetTextWidthByPixel(string fontName, float fontSize, string text)
        {
            if (License_TrialIsExpired())
            {
                return 0;
            }
            int width = 0;
            if (!string.IsNullOrEmpty(text))
            {
                Font font = new Font(fontName, fontSize);
                width = TextRenderer.MeasureText(text, font).Width;
            }
            return width;
        }

        public static string GetUniqueID()
        {
            DateTime now = DateTime.Now;
            string[] strArray = new string[6];
            int num = (now.Year % 0x3e8) % 100;
            strArray[0] = num.ToString().PadLeft(2, '0');
            strArray[1] = now.Month.ToString().PadLeft(2, '0');
            strArray[2] = now.Day.ToString().PadLeft(2, '0');
            strArray[3] = now.Hour.ToString().PadLeft(2, '0');
            strArray[4] = now.Minute.ToString().PadLeft(2, '0');
            strArray[5] = now.Second.ToString().PadLeft(2, '0');
            return string.Concat(strArray);
        }

        public static string GetValueFromRegistry(string sSubKey, string sValueName)
        {
            string str = null;
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(sSubKey);
                if (key != null)
                {
                    str = key.GetValue(sValueName).ToString();
                    key.Close();
                }
            }
            catch
            {
            }
            return str;
        }

        public static void Grid_ExpandCollapseGroup(GridView gridView, bool isExpand, int groupLevel)
        {
            if ((gridView.RowCount != 0) && (groupLevel >= 0))
            {
                if (isExpand)
                {
                    gridView.CollapseAllGroups();
                }
                else
                {
                    gridView.ExpandAllGroups();
                }
                int rowHandle = 0;
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    rowHandle = -i;
                    if (gridView.IsGroupRow(rowHandle) && (gridView.GetRowLevel(rowHandle) == groupLevel))
                    {
                        if (isExpand)
                        {
                            gridView.ExpandGroupRow(rowHandle);
                        }
                        else
                        {
                            gridView.CollapseGroupRow(rowHandle);
                        }
                    }
                }
            }
        }

        public static void Grid_FormatColumnByDateTime(GridView gridView, string columnName, bool isHourOnly)
        {
            try
            {
                if (gridView.Columns[columnName] != null)
                {
                    gridView.Columns[columnName].DisplayFormat.FormatString = isHourOnly ? "hh:mm tt" : "dd/MM/yyyy hh:mm tt";
                    gridView.Columns[columnName].DisplayFormat.FormatType = FormatType.Custom;
                }
            }
            catch
            {
            }
        }

        public static void Grid_FormatColumnByDateTime(GridView gridView, string columnName, string formatString)
        {
            try
            {
                if (gridView.Columns[columnName] != null)
                {
                    gridView.Columns[columnName].DisplayFormat.FormatString = formatString;
                    gridView.Columns[columnName].DisplayFormat.FormatType = FormatType.Custom;
                }
            }
            catch
            {
            }
        }

        public static void GridView_ExpandCollapseGroup(GridView gridView, bool isExpand, int groupLevel)
        {
            if ((gridView.RowCount != 0) && (groupLevel >= 0))
            {
                if (isExpand)
                {
                    gridView.CollapseAllGroups();
                }
                else
                {
                    gridView.ExpandAllGroups();
                }
                int rowHandle = 0;
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    rowHandle = -i;
                    if (gridView.IsGroupRow(rowHandle) && (gridView.GetRowLevel(rowHandle) == groupLevel))
                    {
                        if (isExpand)
                        {
                            gridView.ExpandGroupRow(rowHandle);
                        }
                        else
                        {
                            gridView.CollapseGroupRow(rowHandle);
                        }
                    }
                }
            }
        }

        public static void GridView_IncrementalSearch(GridColumn searchColumn, string searchString)
        {
            if (!License_TrialIsExpired() && !string.IsNullOrEmpty(searchString))
            {
                GridView view = searchColumn.View as GridView;
                view.CollapseAllGroups();
                view.FocusedColumn = searchColumn;
                view.StartIncrementalSearch(searchString);
            }
        }

        public static Guid Guid_Clone(Guid guidFrom)
        {
            if (License_TrialIsExpired())
            {
                return Guid.Empty;
            }
            string str = "0123456789abcdef";
            string str2 = guidFrom.ToString();
            char ch = str2[str2.Length - 1];
            int index = str.IndexOf(ch);
            if (str[index] == 'f')
            {
                index = 0;
            }
            else
            {
                index++;
            }
            char ch2 = str[index];
            return new Guid(str2.Substring(0, str2.Length - 1) + ch2);
        }

        public static void HoLot_AutoComplete(TextEdit textEdit, ChangingEventArgs e)
        {
            if (!IsNull(e.NewValue) && ((e.OldValue == null) || (e.NewValue.ToString().Length >= e.OldValue.ToString().Length)))
            {
                string str = e.NewValue.ToString().ToLower();
                if (((str.Length > 0) && (str.Length <= 3)) && !str.EndsWith(" "))
                {
                    HoLotThuongDung_ID unknown = HoLotThuongDung_ID.Unknown;
                    for (int i = 0; i < 13; i++)
                    {
                        if (((HoLotThuongDung_ID) i).ToString().Equals(str))
                        {
                            unknown = (HoLotThuongDung_ID) i;
                            break;
                        }
                    }
                    if (unknown != HoLotThuongDung_ID.Unknown)
                    {
                        string str2 = ARR_HO_LOT_THUONG_DUNG[(int) unknown];
                        if (str2 != string.Empty)
                        {
                            e.Cancel = true;
                            textEdit.EditValue = str2 + " ";
                            SendKeys.Send("{END}");
                        }
                    }
                }
            }
        }

        public static bool IsNull(object obj) => 
            ((obj == null) || (obj == DBNull.Value));

        public static bool IsNullOrEmpty(object obj) => 
            (((obj == null) || (obj == DBNull.Value)) || (obj.ToString().Trim().Length == 0));

        public static bool IsValidCharForNumericTextBox(char cKeyChar)
        {
            string s = cKeyChar.ToString();
            return (!char.IsDigit(s, 0) && !char.IsControl(s, 0));
        }

        public static bool KillOthersExcludeCurrentInstance()
        {
            Process currentProcess = Process.GetCurrentProcess();
            if (currentProcess == null)
            {
                return false;
            }
            bool flag = true;
            string processName = currentProcess.ProcessName;
            int id = currentProcess.Id;
            Process[] processesByName = Process.GetProcessesByName(processName);
            int length = 0;
            if (processesByName != null)
            {
                length = processesByName.Length;
                try
                {
                    for (int i = length - 1; i >= 0; i--)
                    {
                        if (processesByName[i].Id != id)
                        {
                            processesByName[i].Kill();
                        }
                    }
                }
                catch
                {
                    flag = false;
                }
            }
            return flag;
        }

        public static bool License_TrialIsExpired() => 
            false;

        public static void ListView_AddItems(ListView aListView, ArrayList arlItems)
        {
            aListView.Items.Clear();
            if (arlItems != null)
            {
                ListViewItem item = null;
                for (int i = 0; i < arlItems.Count; i++)
                {
                    item = new ListViewItem {
                        Text = arlItems[i].ToString()
                    };
                    aListView.Items.Add(item);
                }
                if (arlItems.Count > 0)
                {
                    aListView.Items[0].Selected = true;
                }
            }
        }

        public static void ListView_AutofitColumnHeader(ListView aListView)
        {
            foreach (ColumnHeader header in aListView.Columns)
            {
                header.Width = -2;
            }
        }

        public static void ListView_AutofitLargestItem(ListView aListView)
        {
            foreach (ColumnHeader header in aListView.Columns)
            {
                header.Width = -1;
            }
        }

        public static void ListView_CheckAll(ListView aCheckListView, bool isCheck)
        {
            for (int i = 0; i < aCheckListView.Items.Count; i++)
            {
                aCheckListView.Items[i].Checked = isCheck;
            }
        }

        public static bool ListView_CheckStatesWasChanged(ListView aListView, ArrayList arlSaveCheckStates)
        {
            for (int i = 0; i < arlSaveCheckStates.Count; i++)
            {
                if (((bool) arlSaveCheckStates[i]) != aListView.Items[i].Checked)
                {
                    return true;
                }
            }
            return false;
        }

        public static void ListView_CreateEvent_SelectedIndexChanged(ListView aListView)
        {
            int num = ListView_IndexOfSelectedItem(aListView);
            for (int i = 0; i < aListView.Items.Count; i++)
            {
                if (i != num)
                {
                    aListView.Items[i].Selected = true;
                    break;
                }
            }
        }

        public static ArrayList ListView_GetCheckedItems(ListView aListView)
        {
            ArrayList list = new ArrayList();
            list.Clear();
            foreach (ListViewItem item in aListView.CheckedItems)
            {
                list.Add(item.Text);
            }
            return list;
        }

        public static ArrayList ListView_GetTagListOfCheckedItems(ListView aListView)
        {
            ArrayList list = new ArrayList();
            list.Clear();
            foreach (ListViewItem item in aListView.CheckedItems)
            {
                list.Add(item.Tag);
            }
            return list;
        }

        public static int ListView_IndexOfFirstCheckedItem(ListView aListView)
        {
            bool flag = false;
            int num = -1;
            num = 0;
            while (num < aListView.Items.Count)
            {
                if (aListView.Items[num].Checked)
                {
                    flag = true;
                    break;
                }
                num++;
            }
            return (flag ? num : -1);
        }

        public static int ListView_IndexOfSelectedItem(ListView aListView)
        {
            bool flag = false;
            int num = -1;
            num = 0;
            while (num < aListView.Items.Count)
            {
                if (aListView.Items[num].Selected)
                {
                    flag = true;
                    break;
                }
                num++;
            }
            return (flag ? num : -1);
        }

        public static int ListView_InitListView(ListView aListView, string arrHeaderCaption, string arrHeaderWidth)
        {
            string[] strArray2;
            int num2;
            aListView.View = View.Details;
            aListView.MultiSelect = false;
            aListView.AllowColumnReorder = true;
            aListView.GridLines = true;
            aListView.FullRowSelect = true;
            aListView.HideSelection = false;
            aListView.Columns.Clear();
            string[] strArray = arrHeaderCaption.Split(new char[] { ':' });
            if (arrHeaderWidth == null)
            {
                int num = aListView.Width / strArray.Length;
                strArray2 = new string[strArray.Length];
                for (num2 = 0; num2 < strArray2.Length; num2++)
                {
                    strArray2[num2] = num.ToString();
                }
            }
            else
            {
                strArray2 = arrHeaderWidth.Split(new char[] { ':' });
            }
            for (num2 = 0; num2 < strArray.Length; num2++)
            {
                aListView.Columns.Add(strArray[num2], int.Parse(strArray2[num2]), HorizontalAlignment.Left);
            }
            return strArray.Length;
        }

        public static int ListView_ItemExist(ListView aListView, string sKeyOfItem)
        {
            for (int i = 0; i < aListView.Items.Count; i++)
            {
                if (sKeyOfItem == aListView.Items[i].Text)
                {
                    return i;
                }
            }
            return -1;
        }

        public static bool ListView_ItemsWasChanged(ListView aListView, ArrayList arraySaveKeyItems)
        {
            int count = aListView.Items.Count;
            if (arraySaveKeyItems.Count != count)
            {
                return true;
            }
            for (int i = 0; i < count; i++)
            {
                if (!arraySaveKeyItems.Contains(aListView.Items[i].Text))
                {
                    return true;
                }
            }
            return false;
        }

        public static void ListView_SaveCheckStates(ListView aListView, ArrayList arlSaveCheckStates)
        {
            arlSaveCheckStates.Clear();
            for (int i = 0; i < aListView.Items.Count; i++)
            {
                arlSaveCheckStates.Add(aListView.Items[i].Checked);
            }
        }

        public static void ListView_SaveKeyItems(ListView aListView, ArrayList arrSaveKeyItems)
        {
            arrSaveKeyItems.Clear();
            for (int i = 0; i < aListView.Items.Count; i++)
            {
                arrSaveKeyItems.Add(aListView.Items[i].Text);
            }
        }

        public static void ListView_SelectItem(string sItemText, ListView aListView)
        {
            for (int i = 0; i < aListView.Items.Count; i++)
            {
                if (aListView.Items[i].Text == sItemText)
                {
                    aListView.Items[i].Selected = true;
                    break;
                }
            }
        }

        public static void MemoEdit_RemoveLastSpaceFromSelectionText(MemoEdit memoEditMoTa)
        {
            int selectionLength = memoEditMoTa.SelectionLength;
            if (selectionLength > 0)
            {
                string selectedText = memoEditMoTa.SelectedText;
                if (selectedText.Substring(selectedText.Length - 1, 1)[0] == ' ')
                {
                    memoEditMoTa.SelectionLength = selectionLength - 1;
                }
            }
        }

        public static void MsgBox(string sCaption, string sMessage)
        {
            MessageBox.Show(sMessage, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public static void MsgBox_Error(string textMsg)
        {
            MessageBox.Show(textMsg, "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        public static void MsgBox_Error(string sCaption, string sMessage)
        {
            MessageBox.Show(sMessage, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        public static void MsgBox_Exc(string sCaption, string sMessage)
        {
            MessageBox.Show(sMessage, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void MsgBox_Inf(string sCaption, string sMessage)
        {
            MessageBox.Show(sMessage, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public static void MsgBox_OK(string textMsg)
        {
            MessageBox.Show(textMsg, "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public static void MsgBox_Warning(string textMsg)
        {
            MessageBox.Show(textMsg, "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void MsgBox_Warning(string sCaption, string sMessage)
        {
            MessageBox.Show(sMessage, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static DialogResult MsgBox_YesNo(string textMsg) => 
            MessageBox.Show(textMsg, "Th\x00f4ng b\x00e1o", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        public static DialogResult MsgBox_YesNoCancel(string textMsg) => 
            MessageBox.Show(textMsg, "Th\x00f4ng b\x00e1o", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

        public static string Number_DocSoTienTiengAnh(decimal soTien, CurrencyUnit currencyUnit)
        {
            string str = string.Empty;
            if (soTien == 0M)
            {
                return "None";
            }
            string str2 = " ";
            string str3 = string.Empty;
            string str4 = str3;
            string str5 = str3;
            string str6 = str3;
            str4 = ((str4 + "one      two      three    four     ") + "five     six      seven    eight    " + "nine     ten      eleven   twelve   ") + "thirteen fourteen fifteen  sixteen  " + "seventeeneighteen nineteen ";
            str5 = str5 + "twenty   thirty   forty    fifty    " + "sixty    seventy  eighty   ninety   ";
            str6 = str6 + "billion  milion   thousand dollars  cents    ";
            if (soTien < 0M)
            {
                str = "Minus ";
            }
            else
            {
                str = str3;
            }
            string str7 = Math.Abs(soTien).ToString("############.00");
            if (str7.Contains(","))
            {
                str7 = str7.Replace(",", ".");
            }
            str7 = string.Empty.PadRight(12, ' ') + str7;
            str7 = str7.Substring(str7.Length - 15);
            string str8 = string.Empty;
            string str9 = string.Empty;
            for (int i = 1; i <= 5; i++)
            {
                str8 = str7.Substring((i * 3) - 3, 3);
                if (str8 != string.Empty.PadRight(3, ' '))
                {
                    switch (str8)
                    {
                        case "000":
                            if ((i == 4) && (Math.Abs(soTien) > 1M))
                            {
                                str9 = currencyUnit.ToString() + "s.";
                            }
                            else
                            {
                                str9 = str3;
                            }
                            break;

                        case ".00":
                            str9 = string.Empty;
                            break;

                        default:
                        {
                            int result = 0;
                            if (!int.TryParse(str8.Substring(0, 1), out result))
                            {
                                result = 0;
                            }
                            int num3 = 0;
                            if (!int.TryParse(str8.Substring(1, 1), out num3))
                            {
                                num3 = 0;
                            }
                            int num4 = 0;
                            if (!int.TryParse(str8.Substring(str8.Length - 1, 1), out num4))
                            {
                                num4 = 0;
                            }
                            int num5 = 0;
                            if (!int.TryParse(str8.Substring(str8.Length - 2, 2), out num5))
                            {
                                num5 = 0;
                            }
                            if (result == 0)
                            {
                                str9 = str3;
                            }
                            else
                            {
                                str9 = str4.Substring((result * 9) - 9, 9).Trim() + " hundred ";
                                if ((num5 > 0) && (num5 < 0x15))
                                {
                                    str9 = str9 + "and ";
                                }
                            }
                            if ((i == 5) && (Math.Abs(soTien) > 1M))
                            {
                                str9 = "and " + str9;
                            }
                            if ((num5 < 20) && (num5 > 0))
                            {
                                str9 = str9 + str4.Substring((num5 * 9) - 9, 9).Trim() + str2;
                            }
                            else if (num5 >= 20)
                            {
                                str9 = str9 + str5.Substring(((num3 - 1) * 9) - 9, 9).Trim() + str2;
                                if (num4 > 0)
                                {
                                    str9 = str9 + str4.Substring((num4 * 9) - 9, 9).Trim() + str2;
                                }
                            }
                            str9 = str9 + str6.Substring((i * 9) - 9, 9).Trim() + str2;
                            break;
                        }
                    }
                    str = str + str9;
                }
            }
            return (str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1));
        }

        public static string NumberToString(double Value)
        {
            if (License_TrialIsExpired())
            {
                return string.Empty;
            }
            StringBuilder builder = new StringBuilder();
            if (Value == 0.0)
            {
                builder.Append("Kh\x00f4ng");
            }
            else if (Math.Abs(Value) > 999999999999)
            {
                builder.Append("Số qu\x00e1 lớn");
            }
            else
            {
                char ch;
                int num;
                if (Value < 0.0)
                {
                    builder.Append("Trừ");
                    Value = Math.Abs(Value);
                }
                string[] strArray = new string[] { " tỷ", " triệu", " ngh\x00ecn", "" };
                string[] strArray2 = new string[] { " kh\x00f4ng", " một", " hai", " ba", " bốn", " năm", " s\x00e1u", " bảy", " t\x00e1m", " ch\x00edn" };
                CultureInfo currentCulture = CultureInfo.CurrentCulture;
                string[] strArray3 = Value.ToString("#000000000000.0000000000", currentCulture).Split(new string[] { currentCulture.NumberFormat.NumberDecimalSeparator }, StringSplitOptions.None);
                for (num = 0; num < 4; num++)
                {
                    string str = strArray3[0].Substring(num * 3, 3);
                    if (str != "000")
                    {
                        ch = str[0];
                        char ch2 = str[1];
                        char ch3 = str[2];
                        if ((ch != '0') || ((builder.Length != 0) && (ch == '0')))
                        {
                            builder.Append(strArray2[Convert.ToInt16(ch.ToString(currentCulture))]);
                            builder.Append(" trăm");
                        }
                        if (ch2 == '1')
                        {
                            builder.Append(" mười");
                        }
                        else if (ch2 != '0')
                        {
                            builder.Append(strArray2[Convert.ToInt16(ch2.ToString(currentCulture))]);
                            builder.Append(" mươi");
                        }
                        else if ((ch3 != '0') && (builder.Length != 0))
                        {
                            builder.Append(" lẻ");
                        }
                        if (ch3 == '1')
                        {
                            if ((ch2 == '0') || (ch2 == '1'))
                            {
                                builder.Append(strArray2[Convert.ToInt16(ch3.ToString(currentCulture))]);
                            }
                            else
                            {
                                builder.Append(" mốt");
                            }
                        }
                        else if (ch3 == '5')
                        {
                            if (ch2 == '0')
                            {
                                builder.Append(strArray2[Convert.ToInt16(ch3.ToString(currentCulture))]);
                            }
                            else
                            {
                                builder.Append(" lăm");
                            }
                        }
                        else if (ch3 != '0')
                        {
                            builder.Append(strArray2[Convert.ToInt16(ch3.ToString(currentCulture))]);
                        }
                        builder.Append(strArray[num]);
                    }
                }
                if (strArray3.Length == 2)
                {
                    int index = -1;
                    for (num = strArray3[1].Length - 1; num > -1; num--)
                    {
                        ch = strArray3[1][num];
                        if ((ch != '0') && (index == -1))
                        {
                            builder.Append(" phẩy");
                            index = builder.Length;
                        }
                        if (index != -1)
                        {
                            builder.Insert(index, strArray2[Convert.ToInt16(ch.ToString(currentCulture))]);
                        }
                    }
                }
            }
            string str2 = builder.ToString();
            if (!string.IsNullOrEmpty(str2))
            {
                str2 = str2.Trim();
                char ch4 = str2[0];
                str2 = str2.Remove(0, 1);
                str2 = ch4.ToString().ToUpper(CultureInfo.CurrentCulture) + str2;
            }
            return str2;
        }

        public static int NumOfRunningInstances()
        {
            Process[] processesByName = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            int length = 0;
            if (processesByName != null)
            {
                length = processesByName.Length;
            }
            return length;
        }

        public static int NumOfRunningInstances(string processName)
        {
            if (string.IsNullOrEmpty(processName))
            {
                return 0;
            }
            Process[] processesByName = Process.GetProcessesByName(processName);
            int length = 0;
            if (processesByName != null)
            {
                length = processesByName.Length;
            }
            return length;
        }

        public static bool PhoneIsValid(string phoneNumber)
        {
            string pattern = @"^\(?[0-9]+\)?\.?[0-9]+$";
            return Regex.Match(phoneNumber.Trim(), pattern, RegexOptions.IgnoreCase).Success;
        }

        public static bool PrinterIsAvailable(string printerName)
        {
            bool isValid = false;
            if (!string.IsNullOrEmpty(printerName))
            {
                try
                {
                    PrintDocument document = new PrintDocument {
                        PrinterSettings = { PrinterName = printerName }
                    };
                    isValid = document.PrinterSettings.IsValid;
                }
                catch
                {
                    isValid = false;
                }
            }
            return isValid;
        }
        public static int Random()
        {
            System.Random random = new System.Random();
            return random.Next();
        }

        public static int Random(int maxValue)
        {
            System.Random random = new System.Random();
            return random.Next(maxValue);
        }

        public static long Random(long upperbound, long lowerbound)
        {
            System.Random random = new System.Random();
            long num = ((long) (((upperbound - lowerbound) + 1L) * random.NextDouble())) + lowerbound;
            if (num > upperbound)
            {
                num = upperbound;
            }
            return num;
        }

        public static int Random_(int minValue, int maxValue)
        {
            System.Random random = new System.Random();
            return random.Next(minValue, maxValue);
        }

        public static int Random_(System.Random Rnd, int minValue, int maxValue) => 
            Rnd.Next(minValue, maxValue);

        public static ArrayList ReadLogFile(string logFileName)
        {
            if (!File.Exists(logFileName))
            {
                return null;
            }
            StreamReader reader = new StreamReader(logFileName);
            ArrayList list = new ArrayList();
            while (reader.Peek() >= 0)
            {
                list.Add(reader.ReadLine().Trim());
            }
            reader.Close();
            return list;
        }

        public static bool Registry_SetValue(RegistryKey aRegistryBaseKey, string sSubKey, string sName, string sValue)
        {
            bool flag = true;
            RegistryKey key = null;
            try
            {
                key = aRegistryBaseKey.OpenSubKey(sSubKey, true);
                if (key == null)
                {
                    key = aRegistryBaseKey.CreateSubKey(sSubKey);
                }
                if (!(string.IsNullOrEmpty(sName) || (sValue == null)))
                {
                    key.SetValue(sName, sValue);
                }
            }
            catch
            {
                flag = false;
            }
            finally
            {
                if (key != null)
                {
                    key.Close();
                }
            }
            return flag;
        }

        public static bool RequiredFieldsIsValid(Control parentControl)
        {
            errProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            bool isAlert = false;
            bool isSetFocus = false;
            arrayControlWillSetError.Clear();
            bool flag3 = RequiredFieldsIsValid_(parentControl, isAlert, ref isSetFocus);
            if (arrayControlWillSetError.Count > 0)
            {
                (arrayControlWillSetError.GetByIndex(0) as Control).Focus();
            }
            return flag3;
        }

        private static bool RequiredFieldsIsValid_(Control parentControl, bool isAlert, ref bool isSetFocus)
        {
            if (License_TrialIsExpired())
            {
                return false;
            }
            string str = string.Empty;
            foreach (Control control in parentControl.Controls)
            {
                if ((((control is GroupControl) || (control is PanelControl)) || ((control is LayoutControl) || (control is XtraUserControl))) || (control is GroupBox))
                {
                    RequiredFieldsIsValid_(control, isAlert, ref isSetFocus);
                }
                else
                {
                    ClearErrorMessage(control);
                    str = ((control.Tag == null) || string.IsNullOrEmpty(control.Tag.ToString().Trim())) ? string.Empty : control.Tag.ToString();
                    if (str.Trim().Length == 0)
                    {
                        continue;
                    }
                    switch (control.GetType().ToString())
                    {
                        case "DevExpress.XtraEditors.TextEdit":
                        {
                            TextEdit edit = control as TextEdit;
                            isAlert = edit.Text.Trim().Length == 0;
                            goto Label_0355;
                        }
                        case "DevExpress.XtraEditors.MemoEdit":
                        {
                            MemoEdit edit2 = control as MemoEdit;
                            isAlert = edit2.Text.Trim().Length == 0;
                            goto Label_0355;
                        }
                        case "DevExpress.XtraEditors.LookUpEdit":
                        {
                            LookUpEdit edit3 = control as LookUpEdit;
                            isAlert = IsNull(edit3.EditValue) || (edit3.Text.Trim().Length == 0);
                            goto Label_0355;
                        }
                        case "DevExpress.XtraEditors.GridLookUpEdit":
                        {
                            GridLookUpEdit edit4 = control as GridLookUpEdit;
                            isAlert = IsNull(edit4.EditValue) || (edit4.Text.Trim().Length == 0);
                            goto Label_0355;
                        }
                        case "DevExpress.XtraEditors.ComboBoxEdit":
                        {
                            ComboBoxEdit edit5 = control as ComboBoxEdit;
                            isAlert = IsNull(edit5.EditValue) || (edit5.Text.Trim().Length == 0);
                            goto Label_0355;
                        }
                        case "DevExpress.XtraEditors.DateEdit":
                        {
                            DateEdit edit6 = control as DateEdit;
                            isAlert = IsNull(edit6.EditValue) || (edit6.Text.Trim().Length == 0);
                            goto Label_0355;
                        }
                        case "DevExpress.XtraEditors.TimeEdit":
                        {
                            TimeEdit edit7 = control as TimeEdit;
                            isAlert = IsNull(edit7.EditValue) || (edit7.Text.Trim().Length == 0);
                            goto Label_0355;
                        }
                        case "DevExpress.XtraEditors.RadioGroup":
                        {
                            RadioGroup group = control as RadioGroup;
                            isAlert = IsNull(group.EditValue);
                            goto Label_0355;
                        }
                        case "DevExpress.XtraEditors.SpinEdit":
                        {
                            SpinEdit edit8 = control as SpinEdit;
                            isAlert = IsNull(edit8.EditValue) || (edit8.Text.Trim().Length == 0);
                            goto Label_0355;
                        }
                    }
                    isAlert = false;
                    str = string.Empty;
                }
            Label_0355:
                if ((isAlert && !string.IsNullOrEmpty(str)) && (control.Controls.Count >= 1))
                {
                    if (!arrayControlWillSetError.ContainsKey(control.Name))
                    {
                        arrayControlWillSetError.Add(control.Name, control);
                    }
                    SetErrorMessage(control, str + " kh\x00f4ng được để trống", ref isSetFocus);
                }
            }
            bool flag = !isSetFocus;
            return flag;
        }

        public static void SetAppearanceDisabled(Control devExpControl)
        {
            if (devExpControl is BaseEdit)
            {
                BaseEdit edit = devExpControl as BaseEdit;
                if (!(((edit is CheckEdit) || (edit is HyperLinkEdit)) || (edit is RadioGroup)))
                {
                    edit.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke;
                }
                edit.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
                edit.Properties.AppearanceDisabled.Options.UseForeColor = true;
            }
        }

        public static void SetErrorMessage(Control ctl, string errorMessage, ref bool setFocus)
        {
            errProvider.SetError(ctl, errorMessage);
            if (!setFocus)
            {
                setFocus = true;
            }
        }

        public static void SetFocusOnFirstChildControl(Control parentControl)
        {
            if (!License_TrialIsExpired())
            {
                foreach (Control control in parentControl.Controls)
                {
                    if ((((control is GroupControl) || (control is PanelControl)) || (control is LayoutControl)) || (control is XtraUserControl))
                    {
                        SetFocusOnFirstChildControl(control);
                    }
                    else if (((control is BaseEdit) && control.TabStop) && (control.TabIndex == 0))
                    {
                        control.Focus();
                        break;
                    }
                }
            }
        }

        public static void Sleep(int iMilisec)
        {
            Thread.Sleep(iMilisec);
        }

        public static void SpilitString(string s)
        {
            tu = 0;
            mau = 0;
            int index = s.IndexOf("/");
            if (index != -1)
            {
                tu = int.Parse(s.Substring(0, index));
                mau = int.Parse(s.Substring(index + 1, (s.Length - index) - 1));
            }
        }

        public static ArrayList Str_ArrayString2ArrayList(string[] arrayString)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < arrayString.Length; i++)
            {
                list.Add(arrayString[i]);
            }
            return list;
        }

        public static int Str_Bool2Int(string sBoolean)
        {
            switch (sBoolean.ToUpper())
            {
                case "TRUE":
                    return 1;

                case "FALSE":
                    return 0;
            }
            return -1;
        }

        public static string Str_CopyFrom(string sSource, char lastCharToSeek)
        {
            if (sSource.Length > 0)
            {
                for (int i = sSource.Length - 1; i >= 0; i--)
                {
                    if (sSource[i] == lastCharToSeek)
                    {
                        return sSource.Substring(i + 1, (sSource.Length - 1) - i).TrimStart(new char[] { ' ' });
                    }
                }
            }
            return "";
        }

        public static string Str_EncodeFullName(string sFullName, bool isEncode)
        {
            string str;
            int num2;
            char ch;
            string str2 = sFullName;
            if (isEncode)
            {
                for (num2 = 0; num2 < sFullName.Length; num2++)
                {
                    ch = sFullName[num2];
                    str = ch.ToString();
                    int index = "a\x00e0ả\x00e3\x00e1ạăằẳẵắặ\x00e2ầẩẫấậđe\x00e8ẻẽ\x00e9ẹ\x00eaềểễếệi\x00ecỉĩ\x00edịo\x00f2ỏ\x00f5\x00f3ọ\x00f4ồổỗốộơờởỡớợu\x00f9ủũ\x00faụưừửữứựyỳỷỹ\x00fdỵ".IndexOf(str);
                    if (index != -1)
                    {
                        str2 = str2.Replace(str, "11a7a8a9abadafagajakalapaqarasavawazdydzebedefegejekeleqeresevhzi9ijikiliqnzo6o7o8o9odofogojokolopoqorosovowoztzu9udufugujukuluqurusuvxzy9ydyfygyj".Substring(2 * index, 2));
                    }
                    index = "A\x00c0Ả\x00c3\x00c1ẠĂẰẲẴẮẶ\x00c2ẦẨẪẤẬĐE\x00c8ẺẼ\x00c9Ẹ\x00caỀỂỄẾỆI\x00ccỈĨ\x00cdỊO\x00d2Ỏ\x00d5\x00d3Ọ\x00d4ỒỔỖỐỘƠỜỞỠỚỢU\x00d9ỦŨ\x00daỤƯỪỬỮỨỰYỲỶỸ\x00ddỴ".IndexOf(str);
                    if (index != -1)
                    {
                        str2 = str2.Replace(str, "00A7A8A9ABADAFAGAJAKALAPAQARASAVAWAZDYDZEBEDEFEGEJEKELEQERESEVHZI9IJIKILIQNZO6O7O8O9ODOFOGOJOKOLOPOQOROSOVOWOZTZU9UDUFUGUJUKULUQURUSUVXZY9YDYFYGYJ".Substring(2 * index, 2));
                    }
                }
                return str2;
            }
            num2 = 0;
            while (num2 < "11a7a8a9abadafagajakalapaqarasavawazdydzebedefegejekeleqeresevhzi9ijikiliqnzo6o7o8o9odofogojokolopoqorosovowoztzu9udufugujukuluqurusuvxzy9ydyfygyj".Length)
            {
                str = "11a7a8a9abadafagajakalapaqarasavawazdydzebedefegejekeleqeresevhzi9ijikiliqnzo6o7o8o9odofogojokolopoqorosovowoztzu9udufugujukuluqurusuvxzy9ydyfygyj".Substring(num2, 2);
                ch = "a\x00e0ả\x00e3\x00e1ạăằẳẵắặ\x00e2ầẩẫấậđe\x00e8ẻẽ\x00e9ẹ\x00eaềểễếệi\x00ecỉĩ\x00edịo\x00f2ỏ\x00f5\x00f3ọ\x00f4ồổỗốộơờởỡớợu\x00f9ủũ\x00faụưừửữứựyỳỷỹ\x00fdỵ"[num2 / 2];
                str2 = str2.Replace(str, ch.ToString());
                num2 += 2;
            }
            for (num2 = 0; num2 < "00A7A8A9ABADAFAGAJAKALAPAQARASAVAWAZDYDZEBEDEFEGEJEKELEQERESEVHZI9IJIKILIQNZO6O7O8O9ODOFOGOJOKOLOPOQOROSOVOWOZTZU9UDUFUGUJUKULUQURUSUVXZY9YDYFYGYJ".Length; num2 += 2)
            {
                str = "00A7A8A9ABADAFAGAJAKALAPAQARASAVAWAZDYDZEBEDEFEGEJEKELEQERESEVHZI9IJIKILIQNZO6O7O8O9ODOFOGOJOKOLOPOQOROSOVOWOZTZU9UDUFUGUJUKULUQURUSUVXZY9YDYFYGYJ".Substring(num2, 2);
                str2 = str2.Replace(str, "A\x00c0Ả\x00c3\x00c1ẠĂẰẲẴẮẶ\x00c2ẦẨẪẤẬĐE\x00c8ẺẼ\x00c9Ẹ\x00caỀỂỄẾỆI\x00ccỈĨ\x00cdỊO\x00d2Ỏ\x00d5\x00d3Ọ\x00d4ỒỔỖỐỘƠỜỞỠỚỢU\x00d9ỦŨ\x00daỤƯỪỬỮỨỰYỲỶỸ\x00ddỴ"[num2 / 2].ToString());
            }
            return str2;
        }

        public static string Str_FullName_Upper2Lower(string sUpper)
        {
            string str = "";
            if (sUpper.Length <= 0)
            {
                return str;
            }
            str = sUpper.Trim().ToLower();
            while (str.IndexOf("  ") > 0)
            {
                str = str.Replace("  ", " ");
            }
            string[] strArray = str.Split(new char[] { ' ' });
            str = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].Length > 0)
                {
                    string str2 = strArray[i].Substring(0, 1).ToUpper();
                    str = str + str2 + strArray[i].Substring(1, strArray[i].Length - 1) + " ";
                }
            }
            return str.Trim();
        }

        public static string Str_GetFirstChar(string sString) => 
            (sString?.Length > 0) ? sString.Substring(0, 1) : "";

        public static float Str_PhanSo2Float(string sPhanSo)
        {
            int index = sPhanSo.IndexOf("/");
            if (index != -1)
            {
                int num3 = int.Parse(sPhanSo.Substring(0, index));
                int num4 = int.Parse(sPhanSo.Substring(index + 1, (sPhanSo.Length - index) - 1));
                if (num4 == 0)
                {
                    return 0f;
                }
                return (((float) num3) / ((float) num4));
            }
            try
            {
                return float.Parse(sPhanSo);
            }
            catch
            {
                return -1f;
            }
        }

        public static string Str_PhucHoiGiaTriVietTat(SortedList srlCacGiaTriVietTat, string sGiaTriVietTat)
        {
            string str = null;
            if (((srlCacGiaTriVietTat != null) && (srlCacGiaTriVietTat.Count > 0)) && (sGiaTriVietTat != null))
            {
                SortedList list = new SortedList();
                for (int i = 0; i < srlCacGiaTriVietTat.Count; i++)
                {
                    list.Add(srlCacGiaTriVietTat.GetKey(i).ToString().ToUpper(), srlCacGiaTriVietTat.GetByIndex(i).ToString());
                }
                if (list.ContainsKey(sGiaTriVietTat.ToUpper()))
                {
                    str = list.GetByIndex(list.IndexOfKey(sGiaTriVietTat.ToUpper())).ToString();
                }
            }
            return str;
        }

        public static string[] Str_SortFullNames(string[] arrFullName)
        {
            string[] strArray = new string[arrFullName.Length];
            if (arrFullName.Length > 0)
            {
                int num2;
                int[] numArray = new int[arrFullName.Length];
                int index = -1;
                SortedList list = new SortedList();
                for (num2 = 0; num2 < arrFullName.Length; num2++)
                {
                    string key = Str_EncodeFullName(Str_SwapFirstNameAndLastName(arrFullName[num2]), true);
                    index = list.IndexOfKey(key);
                    if (index == -1)
                    {
                        list.Add(key, num2);
                    }
                    else
                    {
                        numArray[index]++;
                    }
                }
                for (num2 = 0; num2 < strArray.Length; num2++)
                {
                    strArray[num2] = Str_EncodeFullName(list.GetKey(num2).ToString(), false);
                    strArray[num2] = Str_SwapFirstNameAndLastName(strArray[num2]);
                    if (numArray[num2] > 0)
                    {
                        for (int i = 0; i < numArray[num2]; i++)
                        {
                            strArray[(num2 + i) + 1] = strArray[num2];
                        }
                    }
                }
            }
            return strArray;
        }

        public static ArrayList Str_SplitPersonalName(string sFullName)
        {
            ArrayList list = new ArrayList { 
                "",
                ""
            };
            if (!string.IsNullOrEmpty(sFullName))
            {
                string str = sFullName.Trim();
                while (str.IndexOf("  ") > 0)
                {
                    str = str.Replace("  ", " ");
                }
                string[] strArray = str.Split(new char[] { ' ' });
                if (strArray.Length > 0)
                {
                    string str2 = strArray[strArray.Length - 1];
                    list[0] = str.Substring(0, str.Length - str2.Length).Trim();
                    list[1] = str2;
                }
            }
            return list;
        }

        public static string Str_SQLCmd_Access2SQLServer(bool bConnectIsSQLServer, string sSQL)
        {
            if (bConnectIsSQLServer)
            {
                return FixSQLDeleteCmd(FixBooleanTypeInSQLCmd(FixBooleanTypeInSQLCmd(FixSQLCmdForUnicode(sSQL), "true"), "false"));
            }
            return sSQL;
        }

        public static string Str_SwapFirstNameAndLastName(string sFullName)
        {
            string str2;
            string str = "";
            if (sFullName.Length <= 0)
            {
                return str;
            }
            str = sFullName.Trim().ToLower();
            while (str.IndexOf("  ") > 0)
            {
                str = str.Replace("  ", " ");
            }
            string[] strArray = str.Split(new char[] { ' ' });
            if (strArray.Length > 1)
            {
                str2 = strArray[0];
                strArray[0] = strArray[strArray.Length - 1];
                strArray[strArray.Length - 1] = str2;
            }
            str = "";
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].Length > 0)
                {
                    str2 = strArray[i].Substring(0, 1).ToUpper();
                    str = str + str2 + strArray[i].Substring(1, strArray[i].Length - 1) + " ";
                }
            }
            return str.Trim();
        }

        public static string Str_UpperFirstCharOfWord(string str)
        {
            string str2 = string.Empty;
            if (!string.IsNullOrEmpty(str))
            {
                char[] chArray = str.Replace("  ", " ").ToCharArray();
                char ch = ' ';
                for (int i = 0; i < chArray.Length; i++)
                {
                    char ch2 = chArray[i];
                    char ch3 = ch2.ToString().ToUpper()[0];
                    if (i == 0)
                    {
                        if (ch2 != ch)
                        {
                            chArray[i] = ch3;
                        }
                    }
                    else
                    {
                        char ch4 = chArray[i - 1];
                        if (ch4.Equals(ch))
                        {
                            chArray[i] = ch3;
                        }
                    }
                    str2 = str2 + chArray[i].ToString();
                }
            }
            return str2;
        }

        public static string Str_ValidPathFolder(string sPathFolder)
        {
            string str = sPathFolder;
            if (sPathFolder != null)
            {
                if (sPathFolder.Length <= 0)
                {
                    return str;
                }
                if (sPathFolder.Substring(sPathFolder.Length - 1, 1) != @"\")
                {
                    str = sPathFolder + @"\";
                }
            }
            return str;
        }

        public static string Str_ValidURL(string sURL)
        {
            string str = sURL;
            if (sURL != null)
            {
                if (sURL.Length <= 0)
                {
                    return str;
                }
                if (sURL.Substring(sURL.Length - 1, 1) != "/")
                {
                    str = sURL + "/";
                }
            }
            return str;
        }

        public static string Str_VietUnicodeSangKhongDau(string sTiengVietCodau)
        {
            string str = string.Empty;
            if (!string.IsNullOrEmpty(sTiengVietCodau))
            {
                int index = -1;
                str = sTiengVietCodau;
                bool flag = false;
                foreach (char ch in str)
                {
                    if (" abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(ch) == -1)
                    {
                        flag = false;
                        index = "\x00e0ả\x00e3\x00e1ạăằẳẵắặ\x00e2ầẩẫấậđ\x00e8ẻẽ\x00e9ẹ\x00eaềểễếệ\x00ecỉĩ\x00edị\x00f2ỏ\x00f5\x00f3ọ\x00f4ồổỗốộơờởỡớợ\x00f9ủũ\x00faụưừửữứựỳỷỹ\x00fdỵ".IndexOf(ch);
                        if (index == -1)
                        {
                            index = "\x00c0Ả\x00c3\x00c1ẠĂẰẲẴẮẶ\x00c2ẦẨẪẤẬĐ\x00c8ẺẼ\x00c9Ẹ\x00caỀỂỄẾỆ\x00ccỈĨ\x00cdỊ\x00d2Ỏ\x00d5\x00d3Ọ\x00d4ỒỔỖỐỘƠỜỞỠỚỢ\x00d9ỦŨ\x00daỤƯỪỬỮỨỰỲỶỸ\x00ddỴ".IndexOf(ch);
                            flag = index != -1;
                        }
                        if (index != -1)
                        {
                            str = str.Replace(ch, flag ? char.ToUpper("aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyy"[index]) : "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyy"[index]);
                        }
                    }
                }
            }
            return str;
        }

        public static string String_Reverse(string str)
        {
            char[] chArray = str.ToCharArray();
            int index = str.Length - 1;
            int num2 = 0;
            while (num2 < index)
            {
                chArray[num2] = (char) (chArray[num2] ^ chArray[index]);
                chArray[index] = (char) (chArray[index] ^ chArray[num2]);
                chArray[num2] = (char) (chArray[num2] ^ chArray[index]);
                num2++;
                index--;
            }
            return new string(chArray);
        }

        public static void TextEdit_SetAutoComplete(TextEdit textEdit, AutoCompleteStringCollection autoCompleteSource)
        {
            if ((autoCompleteSource != null) && (autoCompleteSource.Count > 0))
            {
                textEdit.MaskBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                textEdit.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textEdit.MaskBox.AutoCompleteCustomSource = autoCompleteSource;
            }
        }

        public static void TextEdit_SetAutoComplete(TextEdit textEdit, string[] autoCompleteSource)
        {
            if ((autoCompleteSource != null) && (autoCompleteSource.Length > 0))
            {
                textEdit.MaskBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                textEdit.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textEdit.MaskBox.AutoCompleteCustomSource.AddRange(autoCompleteSource);
            }
        }

        public static string UnicodeToNoSign(string s)
        {
            int num;
            string str;
            if (License_TrialIsExpired())
            {
                return string.Empty;
            }
            s = s.Replace("Đ", "D");
            s = s.Replace("đ", "d");
            int[] numArray = new int[] { 
                0x61, 0xe2, 0x103, 0x65, 0xea, 0x69, 0x6f, 0xf4, 0x1a1, 0x75, 0x1b0, 0x79, 0x41, 0xc2, 0x102, 0x45,
                0xca, 0x49, 0x4f, 0xd4, 0x1a0, 0x55, 0x1af, 0x59, 0xe1, 0x1ea5, 0x1eaf, 0xe9, 0x1ebf, 0xed, 0xf3, 0x1ed1,
                0x1edb, 250, 0x1ee9, 0xfd, 0xc1, 0x1ea4, 0x1eae, 0xc9, 0x1ebe, 0xcd, 0xd3, 0x1ed0, 0x1eda, 0xda, 0x1ee8, 0xdd,
                0xe0, 0x1ea7, 0x1eb1, 0xe8, 0x1ec1, 0xec, 0xf2, 0x1ed3, 0x1edd, 0xf9, 0x1eeb, 0x1ef3, 0xc0, 0x1ea6, 0x1eb0, 200,
                0x1ec0, 0xcc, 210, 0x1ed2, 0x1edc, 0xd9, 0x1eea, 0x1ef2, 0x1ea1, 0x1ead, 0x1eb7, 0x1eb9, 0x1ec7, 0x1ecb, 0x1ecd, 0x1ed9,
                0x1ee3, 0x1ee5, 0x1ef1, 0x1ef5, 0x1ea0, 0x1eac, 0x1eb6, 0x1eb8, 0x1ec6, 0x1eca, 0x1ecc, 0x1ed8, 0x1ee2, 0x1ee4, 0x1ef0, 0x1ef4,
                0x1ea3, 0x1ea9, 0x1eb3, 0x1ebb, 0x1ec3, 0x1ec9, 0x1ecf, 0x1ed5, 0x1edf, 0x1ee7, 0x1eed, 0x1ef7, 0x1ea2, 0x1ea8, 0x1eb2, 0x1eba,
                0x1ec2, 0x1ec8, 0x1ece, 0x1ed4, 0x1ede, 0x1ee6, 0x1eec, 0x1ef6, 0xe3, 0x1eab, 0x1eb5, 0x1ebd, 0x1ec5, 0x129, 0xf5, 0x1ed7,
                0x1ee1, 0x169, 0x1eef, 0x1ef9, 0xc3, 0x1eaa, 0x1eb4, 0x1ebc, 0x1ec4, 0x128, 0xd5, 0x1ed6, 0x1ee0, 360, 0x1eee, 0x1ef8,
                100, 0x111, 0x44, 0x110
            };
            for (num = numArray.Length - 1; num >= 0; num--)
            {
                str = ((char) numArray[num]).ToString();
                s = s.Replace(str, "::" + num + "::");
            }
            string[] strArray = new string[] { 
                "a", "a", "a", "e", "e", "i", "o", "o", "o", "u", "u", "y", "A", "A", "A", "E",
                "E", "I", "O", "O", "O", "U", "U", "Y", "a", "a", "a", "e", "e", "i", "o", "o",
                "o", "u", "u", "y", "A", "A", "A", "E", "E", "I", "O", "O", "O", "U", "U", "Y",
                "a", "a", "a", "e", "e", "i", "o", "o", "o", "u", "u", "y", "A", "A", "A", "E",
                "E", "I", "O", "O", "O", "U", "U", "Y", "a", "a", "a", "e", "e", "i", "o", "o",
                "o", "u", "u", "y", "A", "A", "A", "E", "E", "I", "O", "O", "O", "U", "U", "Y",
                "a", "a", "a", "e", "e", "i", "o", "o", "o", "u", "u", "y", "A", "A", "A", "E",
                "E", "I", "O", "O", "O", "U", "U", "Y", "a", "a", "a", "e", "e", "i", "o", "o",
                "o", "u", "u", "y", "A", "A", "A", "E", "E", "I", "O", "O", "O", "U", "U", "Y",
                "d", "d", "D", "D"
            };
            for (num = strArray.Length - 1; num >= 0; num--)
            {
                str = strArray[num];
                s = s.Replace("::" + num + "::", str);
            }
            s = s.Replace("Đ", "D");
            s = s.Replace("đ", "d");
            return s;
        }

        public static bool URLIsValid(string URL)
        {
            string pattern = @"^(http|https|ftp)\://(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(URL);
        }

        public static bool UserIsAdminGroup(string userName) => 
            false;

        public static bool UserIsDefaultAdmin(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
            }
            return false;
        }

        public static bool UserNameIsAdmin(string sUserName)
        {
            if ((sUserName != null) && (sUserName.Length > 0))
            {
                string str = sUserName.ToLower();
                return (((str == "admin") || (str == "administrator")) || (str == "quantri"));
            }
            return false;
        }

        public static bool ValidateForm(Control parentControl)
        {
            if (License_TrialIsExpired())
            {
                return false;
            }
            validError = new ErrorProvider();
            int num = 0;
            foreach (Control control in parentControl.Controls)
            {
                if (((control is GroupControl) || (control is PanelControl)) || (control is LayoutControl))
                {
                    ValidateForm(control);
                }
                else if (((control is BaseEdit) && (((BaseEdit) control).Tag != null)) && ((((BaseEdit) control).EditValue == null) | ((BaseEdit) control).Text.Trim().Equals(string.Empty)))
                {
                    validError.SetError((BaseEdit) control, ((BaseEdit) control).Tag.ToString() + " kh\x00f4ng được để trống!");
                    ((BaseEdit) control).Focus();
                    num++;
                }
            }
            if (num != 0)
            {
                return false;
            }
            return true;
        }

        public static void WriteLogFile(string logFileName, string writeContent, bool bAttachDate)
        {
            if (!File.Exists(logFileName))
            {
                File.CreateText(logFileName).Close();
            }
            StreamWriter writer = File.AppendText(logFileName);
            if (bAttachDate)
            {
                writer.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss t'M'") + ": " + writeContent);
            }
            else
            {
                writer.WriteLine(writeContent);
            }
            writer.Close();
        }

        public enum ActionOnControl
        {
            ClearErrorIndicator,
            ClearEditContent
        }

        public enum CurrencyUnit
        {
            VND,
            USD
        }

        public enum enuFileType
        {
            UNKNOWN = -1,
            EXCEL = 1,
            MSACCESS = 2,
            DBF = 3,
            DOC = 4
        }

        private enum HoLotThuongDung_ID
        {
            ng,
            tra,
            l,
            tri,
            phu,
            đa,
            huy,
            bu,
            tha,
            tru,
            hoa,
            va,
            cha,
            Unknown
        }
    }
}

