using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace xdcb.Common.Application.Extensions
{
    public static class ReportExcelExtensions
    {
        public static FileContentResult GetFileExcel<T>(IEnumerable<T> list, ExcelBorderStyle excelBorderStyle, string title, string fileName)
        {
            var stream = new MemoryStream();
            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                var t = typeof(T);
                var Headings = t.GetProperties();
                workSheet.Cells[1, 1, 1, Headings.Count()].Merge = true;
                workSheet.Cells[1, 1, 1, Headings.Count()].Style.Font.Bold = true;
                workSheet.Cells[1, 1, 1, Headings.Count()].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells[1, 1].Value = title;
                for (int i = 0; i < Headings.Count(); i++)
                {
                    workSheet.Cells[2, 1, 2, i + 1].Value = Headings[i].Name;
                    workSheet.Cells[2, 1, 2, i + 1].Style.Font.Bold = true;
                    workSheet.Cells[2, 1, 2, i + 1].AutoFitColumns();
                }
                workSheet.Cells[2, 1, 2, Headings.Count()].LoadFromCollection(list, true);
                workSheet.Cells[workSheet.Dimension.Address].Style.Border.Top.Style = excelBorderStyle;
                workSheet.Cells[workSheet.Dimension.Address].Style.Border.Left.Style = excelBorderStyle;
                workSheet.Cells[workSheet.Dimension.Address].Style.Border.Right.Style = excelBorderStyle;
                workSheet.Cells[workSheet.Dimension.Address].Style.Border.Bottom.Style = excelBorderStyle;
                package.Save();
            }
            stream.Position = 0;
            return new FileContentResult(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = $"{fileName}.xlsx"
            };
        }
    }
}