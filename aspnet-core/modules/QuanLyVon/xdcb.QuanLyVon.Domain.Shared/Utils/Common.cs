using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace xdcb.QuanLyVon
{
    public static class Common
    {
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

        public static void StartProcess(string fileName)
        {
            try
            {
                Process.Start(fileName);
            }
            catch (Exception ex)
            {

            }
        }

        public static string CoppyFile(string newFile, string oldTemp)
        {
            //lưu file

            if (File.Exists(newFile))
            {
                File.Delete(newFile);
            }
            File.Copy(oldTemp, newFile);

            return newFile;
        }
    }
}
