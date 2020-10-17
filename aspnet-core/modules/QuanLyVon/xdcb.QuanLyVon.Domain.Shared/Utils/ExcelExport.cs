using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace xdcb.QuanLyVon
{
    public class ExcelExport
    {
        private const string _MergePrefix = "M.";
        private const string _HeaderPrefix = "C.";
        private const string _FieldPrefix = "F.";
        private const string _DynamicColumnName = "h";
        private const string _DynamicTableName = "th";
        private const string _DataTableName = "t0";
        private const string _HeaderTableName = "t1";
        private const string _SumDataTableName = "t2";
        private static int _sheetIndex = 1;
        private static ExcelPackage _temPackage, _newPackage;
        private static ExcelWorksheet _tempSheet, _workSheet;

        /// <summary>
        /// Khởi tạo các đối tượng Excel ban đầu
        /// </summary>
        /// <param name="temFilePath">Đường dẫn file template</param>
        /// <param name="newFilePath">Đường dẫn file kết quả</param>
        public static void CreateExcelComponent(string temFilePath, string newFilePath)
        {
            try
            {
                //if (File.Exists(newFilePath) && _sheetIndex == 1)
                //    File.Delete(newFilePath);
                //if (!File.Exists(newFilePath))
                //{
                //    if (!string.IsNullOrEmpty(temFilePath) && FtpClientConnect.ConnectServer())
                //    {
                //        FtpClientConnect.DownloadFileFromFtp(newFilePath,temFilePath);
                //        //THuyTTT marked 3.6.2015 vi doc ftp
                //        //File.Copy(memory, newFilePath);
                //    }
                //}

                _temPackage = new ExcelPackage(new FileInfo(temFilePath));
                _newPackage = new ExcelPackage(new FileInfo(newFilePath));

                //Đọc sheet
                _tempSheet = GetSheet(_temPackage, _sheetIndex);
                _workSheet = GetSheet(_newPackage, _sheetIndex);
            }
            catch (IOException ioE)
            {
                throw new IOException("Lỗi không thể đọc được file excel mẫu hoặc file excel kết quả.\nVui lòng đóng tất cả file excel nếu bạn đang mở nó.\n\n" + ioE.Message, ioE);
            }
            catch (Exception e)
            {
                var t = e;
                throw;
            }
        }

        /// <summary>
        /// Xóa sheet trong file excel theo vị trí sheetIndex, sheetIndex bắt đầu từ 1
        /// </summary>
        /// <param name="excelFilePath">Đường dẫn file excel</param>
        /// <param name="sheetIndex">Vị trí sheet cần xóa, bắt đầu từ 1</param>
        /// <returns>true: xóa thành công, false: không thể xóa hoặc lỗi</returns>
        public static bool RemoveSheet(string excelFilePath, int sheetIndex)
        {
            try
            {
                if (File.Exists(excelFilePath))
                {
                    ExcelPackage excelPackage = new ExcelPackage(new FileInfo(excelFilePath));
                    if (sheetIndex > 0 && sheetIndex <= excelPackage.Workbook.Worksheets.Count)
                    {
                        excelPackage.Workbook.Worksheets.Delete(sheetIndex);
                        excelPackage.Save();
                        return true;
                    }
                }
            }
            catch { }
            return false;
        }

        /// <summary>
        /// Xóa sheet trong file excel theo tên của sheet
        /// </summary>
        /// <param name="excelFilePath">Đường dẫn file excel</param>
        /// <param name="sheetName">Tên của sheet cần xóa</param>
        /// <returns>true: xóa thành công, false: không thể xóa hoặc lỗi</returns>
        public static bool RemoveSheet(string excelFilePath, string sheetName)
        {
            try
            {
                if (File.Exists(excelFilePath))
                {
                    ExcelPackage excelPackage = new ExcelPackage(new FileInfo(excelFilePath));
                    ExcelWorksheet sheet = excelPackage.Workbook.Worksheets[sheetName];
                    if (sheet != null)
                    {
                        excelPackage.Workbook.Worksheets.Delete(sheet);
                        excelPackage.Save();
                        return true;
                    }
                }
            }
            catch { }
            return false;
        }

        /// <summary>
        /// Lọc và copy DataTable từ DataTable theo một cột dữ liệu có giá trị kiểu int
        /// </summary>
        /// <param name="sourceTable">DataTable nguồn</param>
        /// <param name="fieldName">Field cần lọc</param>
        /// <param name="filterValue">Dữ liệu cần lọc</param>
        /// <returns>DataTable mới đã lọc</returns>
        public static DataTable FilterByField(DataTable sourceTable, string fieldName, int filterValue)
        {
            return FilterByCriteria(sourceTable, fieldName + " = " + filterValue.ToString());
        }

        /// <summary>
        /// Lọc và copy DataTable từ DataTable theo một cột dữ liệu có kiểu string 
        /// </summary>
        /// <param name="sourceTable">DataTable nguồn</param>
        /// <param name="fieldName">Tên cột cần lọc</param>
        /// <param name="filterValue">Giá trị cần lọc</param>
        /// <returns>DataTable mới sau khi lọc</returns>
        public static DataTable FilterByField(DataTable sourceTable, string fieldName, string filterValue)
        {
            return FilterByCriteria(sourceTable, fieldName + " = '" + filterValue.ToString() + "'");
        }

        /// <summary>
        /// Lọc và copy DataTable từ DataTable theo chuỗi điều kiện
        /// </summary>
        /// <param name="sourceTable">DataTable nguồn</param>
        /// <param name="criteria">Chuỗi điều kiện</param>
        /// <returns>DataTable mới sau khi lọc</returns>
        public static DataTable FilterByCriteria(DataTable sourceTable, string criteria)
        {
            if (sourceTable != null && sourceTable.Rows.Count > 0)
            {
                DataTable dtNew = sourceTable.Clone();
                DataRow[] dtRows = sourceTable.Select(criteria);
                if (dtRows.Count() > 0)
                {
                    foreach (DataRow row in dtRows)
                        dtNew.ImportRow(row);
                }
                    
                
                return dtNew;
            }
            else
                return null;
        }

        /// <summary>
        /// Export dữ liệu ra file excel theo template, đưa vào nhiều sheet
        /// </summary>
        /// <param name="temFilePath">Đường dẫn file template</param>
        /// <param name="newFilePath">Đường dẫn file kết quả</param>
        /// <param name="dtColumns">Bảng chứa các cột được chèn thêm vào file excel</param>
        /// <param name="dtHeader">Bảng chứa các giá trị header, footer, caption, titile</param>
        /// <param name="dtData">Bảng dữ liệu được đổ vào file excel</param>
        /// <param name="fieldId">Field của sheet, mỗi field là mỗi sheet</param>
        /// <param name="fieldName">Tên của sheet</param>
        /// <param name="hiddenColumns">Số cột được ẩn tính từ đầu sheet</param>
        public static void ExportMultiSheet(string temFilePath, string newFilePath, string fieldId, string fieldName,
                                                  DataTable dtColumns, DataTable dtHeader, DataTable dtData, int hiddenColumns)
        {
            dtColumns.TableName = _DynamicTableName;
            dtHeader.TableName = _HeaderTableName;
            dtData.TableName = _DataTableName;
            DataTable dtSheet = dtHeader.Copy();
            HorizontalMapping hMap = new HorizontalMapping();
            VerticalMapping vMap = new VerticalMapping();

            if (HasDataRow(dtSheet))
            {
                CreateExcelComponent(temFilePath, newFilePath);
                if (_workSheet != null && _tempSheet != null)
                {
                    foreach (DataRow row in dtSheet.Rows)
                    {
                        object oValue = row[fieldId];
                        if (oValue != null)
                        {
                            int fieldValue = (int)oValue;
                            DataTable tmpColumns = FilterByField(dtColumns, fieldId, fieldValue);
                            DataTable tmpHeader = FilterByField(dtHeader, fieldId, fieldValue);
                            DataTable tmpData = FilterByField(dtData, fieldId, fieldValue);
                            DataSet dSet = new DataSet();
                            dSet.Tables.Add(tmpHeader);

                            //Thêm một sheet mới
                            string sheetName = row[fieldName].ToString();
                            ExcelWorksheet workSheet = _newPackage.Workbook.Worksheets.Add(sheetName, _tempSheet);

                            //Nếu có thêm cột theo chiều ngang
                            if (HasDataRow(tmpColumns))
                            {
                                hMap = GetHorizontalMapping(workSheet, dtColumns);
                                if (hMap.HasMapping)
                                    AddHorizontalColumns(_tempSheet, workSheet, tmpColumns, hMap);
                            }
                            vMap = GetVerticalMapping(workSheet, dtData);
                            //Đổ dữ liệu từ DataTable vào sheet
                            FillSheetCaptions(workSheet, dSet, vMap);
                            MergeSheetCaption(workSheet, hMap);
                            FillSheet(workSheet, tmpData, vMap, hiddenColumns);
                        }
                    }
                    _newPackage.Workbook.Worksheets.Delete(_workSheet);
                    _newPackage.Save();
                }
                else
                {
                    throw new FileNotFoundException("Không thể đọc file excel mẫu");
                }
            }
        }

        /// <summary>
        /// Export dữ liệu trong DataSet ra file Excel dựa vào template, tại sheet thứ sheetIndex (bắt đầu từ 1)
        /// </summary>
        /// <param name="temFilePath">Đường dẫn file template</param>
        /// <param name="newFilePath">Đường dẫn file kết quả</param>
        /// <param name="dtColumns">Danh sách cột được thêm vào</param>
        /// <param name="dtHeader">Bảng chứa các giá trị header, footer, caption, titile</param>
        /// <param name="dtData">Bảng dữ liệu được đổ vào file excel</param>
        /// <param name="sheetIndex">Thứ tự sheet được export, bắt đầu từ 1</param>
        /// <param name="hiddenColumns">Số cột được ẩn tính từ đầu sheet</param>
        public static void ExportWithTemplate(string temFilePath, string newFilePath, DataTable dtColumns, DataTable dtHeader, DataTable dtData, DataTable dtSumData, int sheetIndex, int hiddenColumns)
        {
            _sheetIndex = sheetIndex;
            var dSet = new DataSet();
            if (dtColumns != null && dtColumns.Rows.Count > 0)
            {
                dtColumns.TableName = _DynamicTableName;
                dSet.Tables.Add(dtColumns);
            }
            if (dtHeader != null && dtHeader.Rows.Count > 0)
            {
                dtHeader.TableName = _HeaderTableName;
                dSet.Tables.Add(dtHeader);
            }
            if (dtData != null && dtData.Rows.Count > 0)
            {
                dtData.TableName = _DataTableName;
                dSet.Tables.Add(dtData);
            }
            if (dtSumData != null && dtSumData.Rows.Count > 0)
            {
                dtSumData.TableName = _SumDataTableName;
                dSet.Tables.Add(dtSumData);
            }
            ExportWithTemplate(temFilePath, newFilePath, dSet, hiddenColumns);
            if (dSet.Tables != null && dSet.Tables.Count > 0)
                dSet.Tables.Clear();
        }

        /// <summary>
        /// Export dữ liệu trong DataSet ra file Excel dựa vào template
        /// </summary>
        /// <param name="temFilePath">Đường dẫn file template</param>
        /// <param name="newFilePath">Đường dẫn file kết quả</param>
        /// <param name="dtColumns">Danh sách cột được thêm vào</param>
        /// <param name="dtHeader">Bảng chứa các giá trị header, footer, caption, titile</param>
        /// <param name="dtData">Bảng dữ liệu được đổ vào file excel</param>
        /// <param name="hiddenColumns">Số cột được ẩn tính từ đầu sheet</param>
        public static void ExportWithTemplate(string temFilePath, string newFilePath, DataTable dtColumns, DataTable dtHeader, DataTable dtData, DataTable dtSumData, int hiddenColumns)
        {
            _sheetIndex = 1;
            var dSet = new DataSet();
            if (dtColumns != null)
            {
                dtColumns.TableName = _DynamicTableName;
                dSet.Tables.Add(dtColumns);
            }
            if (dtHeader != null)
            {
                dtHeader.TableName = _HeaderTableName;
                dSet.Tables.Add(dtHeader);
            }
            if (dtData != null)
            {
                dtData.TableName = _DataTableName;
                dSet.Tables.Add(dtData);
            }

            ExportWithTemplate(temFilePath, newFilePath, dSet, hiddenColumns);
            if (dSet.Tables != null && dSet.Tables.Count > 0)
                dSet.Tables.Clear();
        }

        /// <summary>
        /// Export dữ liệu trong DataSet ra file Excel dựa vào template với TableName là t0: fill dữ liệu, th: dynamic column, t?: header, caption or footer
        /// </summary>
        /// <param name="temFilePath">Đường dẫn file template</param>
        /// <param name="newFilePath">Đường dẫn file kết quả</param>
        /// <param name="dSet">DataSet gồm các DataTable chứa dữ liệu</param>
        /// <param name="hiddenColumns">Số cột được ẩn tính từ đầu sheet</param>
        public static void ExportWithTemplate(string temFilePath, string newFilePath, DataSet dSet, int hiddenColumns)
        {
            CreateExcelComponent(temFilePath, newFilePath);
            if (_workSheet != null && _tempSheet != null)
            {
                if (dSet != null && dSet.Tables.Count > 0)
                {
                    HorizontalMapping hMap = new HorizontalMapping();
                    VerticalMapping vMap = new VerticalMapping();

                    //Nếu có add cột theo chiều ngang
                    if (dSet.Tables.Contains(_DynamicTableName))
                    {
                        DataTable dtColumns = dSet.Tables[_DynamicTableName];
                        if (HasDataRow(dtColumns))
                        {
                            hMap = GetHorizontalMapping(_workSheet, dtColumns);
                            if (hMap.HasMapping)
                                AddHorizontalColumns(_tempSheet, _workSheet, dtColumns, hMap);
                        }
                    }

                    if (dSet.Tables.Contains(_DataTableName))
                    {
                        DataTable dtFill = dSet.Tables[_DataTableName];
                        vMap = GetVerticalMapping(_workSheet, dtFill);

                        //Đổ dữ liệu từ DataTable vào sheet
                        FillSheetCaptions(_workSheet, dSet, vMap);
                        MergeSheetCaption(_workSheet, hMap);
                        //Dữ liệu detail
                        FillSheet(_workSheet, dtFill, vMap, hiddenColumns);
                        //Sum dữ liệu
                        DataTable dtSumFill = dSet.Tables[_SumDataTableName];
                        vMap = GetVerticalMappingByt(_workSheet, dtSumFill, _SumDataTableName);
                        FillSumSheet(_workSheet, dtSumFill, vMap, hiddenColumns);
                    }
                    _newPackage.Save();
                }
            }
            else
                throw new FileNotFoundException("Không thể đọc file excel mẫu");
        }

        /// <summary>
        /// Chèn cột tự động dựa theo dữ liệu truyền vào (nếu có)
        /// </summary>
        /// <param name="tempSheet">Sheet mẫu dùng để copy</param>
        /// <param name="workSheet">Sheet được chèn cột</param>
        /// <param name="dtColumns">Danh sách cột</param>
        /// <param name="hMap">Class Ánh xạ cột theo chiều ngang</param>
        private static void AddHorizontalColumns(ExcelWorksheet tempSheet, ExcelWorksheet workSheet, DataTable dtColumns, HorizontalMapping hMap)
        {
            if (HasDataRow(dtColumns))
            {
                if (hMap.HasMapping)
                {
                    int mergeFirstLocation = 0, mergeLastLocation = 0;
                    int firstCol = hMap.ColumnsMapping;
                    int temCol = firstCol;
                    int newCol = firstCol;
                    int firstRow = LocateRowOfHeader(true, workSheet, firstCol) - 1;
                    int lastRow = LocateRowOfHeader(false, workSheet, firstCol);

                    foreach (DataRow hRow in dtColumns.Rows)
                    {
                        //Insert column
                        newCol++;
                        workSheet.InsertColumn(newCol, 1, temCol);
                        workSheet.Column(newCol).Width = workSheet.Column(temCol).Width;
                        for (int curentRowIndex = firstRow; curentRowIndex <= lastRow; curentRowIndex++)
                        {
                            ExcelRange temCell = workSheet.Cells[curentRowIndex, temCol];
                            ExcelRange newCell = workSheet.Cells[curentRowIndex, newCol];
                            //Copy cell
                            newCell.Value = temCell.Value;
                            newCell.StyleID = temCell.StyleID;
                            if (newCell.Value != null)
                            {
                                foreach (DataColumn hCol in dtColumns.Columns)
                                    if (newCell.Value.ToString() == "{" + _HeaderPrefix + hCol.ColumnName + "}")
                                        newCell.Value = hRow[hCol];
                                    else if (newCell.Value.ToString() == "{" + _FieldPrefix + hCol.ColumnName + "}")
                                        newCell.Value = "{" + hRow[hCol] + "}";
                            }

                            //kiểm tra nếu có merge cell theo chiều dọc
                            if (temCell.Merge)
                            {
                                if (mergeFirstLocation == 0)
                                    mergeFirstLocation = curentRowIndex;
                            }
                            else
                            {
                                //Kiểm tra nếu có merge cells
                                if (mergeFirstLocation > 0)
                                {
                                    mergeLastLocation = curentRowIndex - 1;
                                    ExcelRange mergeCells = workSheet.Cells[mergeFirstLocation, newCol, mergeLastLocation, newCol];
                                    MergeCells(mergeCells);
                                    mergeFirstLocation = 0;
                                }
                            }
                        }
                    }

                    //Merge các cột vừa thêm vào
                    firstCol = hMap.ColumnsMapping;
                    firstRow = LocateRowOfHeader(true, workSheet, firstCol);
                    firstRow--;
                    if (firstRow > 0)
                    {
                        //Range của các cột vừa thêm vào
                        ExcelRange newColRange = workSheet.Cells[firstRow, firstCol + 1,
                            firstRow, firstCol + dtColumns.Rows.Count];
                        newColRange.Value = null;
                        newColRange.Merge = true;
                        //Trả lại giá trị ban đầu của cell của template
                        newColRange.Value = workSheet.Cells[firstRow, firstCol].Value;
                    }
                    //Ẩn cột template
                    workSheet.Column(firstCol).Hidden = true;

                    //Ẩn dòng đầu tiên
                    workSheet.Row(1).Hidden = true;
                }
            }
        }

        /// <summary>
        /// Merge toàn bộ cell của ExcelRange
        /// </summary>
        private static void MergeCells(ExcelRange mergeCells)
        {
            try
            {
                string rangeHeader = string.Empty;
                foreach (ExcelRangeBase cell in mergeCells)
                {
                    if (cell.Merge)
                        cell.Merge = false;
                    if (cell.Value != null)
                        if (!string.IsNullOrEmpty(cell.Value.ToString()))
                            rangeHeader = cell.Value.ToString();
                }
                mergeCells.Value = null;
                mergeCells.Merge = true;
                mergeCells.Value = rangeHeader;
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        /// <summary>
        /// Tìm dòng đầu tiên của header
        /// </summary>
        /// <param name="LocateFirstRow">True:Tìm dòng đầu tiên, False:Tìm dòng cuối cùng</param>
        /// <param name="workSheet">Sheet cần tìm</param>
        /// <param name="columnIndex">Tìm tại cột</param>
        /// <returns>Vị trí của dòng, nếu ko tìm thấy trả về -1</returns>
        private static int LocateRowOfHeader(bool LocateFirstRow, ExcelWorksheet workSheet, int columnIndex)
        {
            int rowIndex = -1;
            string cellValue;
            for (int iRow = workSheet.Dimension.Start.Row; iRow <= workSheet.Dimension.End.Row; iRow++)
            {
                ExcelRange cell = workSheet.Cells[iRow, columnIndex];
                if (cell.Value != null)
                {
                    cellValue = cell.Value.ToString();
                    if (cellValue.StartsWith("{") && cellValue.EndsWith("}"))
                    {
                        rowIndex = iRow;
                        if (LocateFirstRow) break;
                    }
                }
            }
            return rowIndex;
        }

        /// <summary>
        /// Tìm các dòng có merge trong 1 cột
        /// </summary>
        /// <param name="workSheet">Sheet cần tìm</param>
        /// <param name="columnIndex">Tìm tại cột</param>
        /// <returns>Danh sách vị trí các dòng có merge</returns>
        private static List<int> RowsOfMerge(ExcelWorksheet workSheet, int columnIndex)
        {
            List<int> rows = new List<int>();
            ExcelRange colRange = workSheet.Cells[1, columnIndex, workSheet.Dimension.End.Row, columnIndex];
            for (int iRow = workSheet.Dimension.Start.Row; iRow <= workSheet.Dimension.End.Row; iRow++)
                if (workSheet.Cells[iRow, columnIndex].Merge)
                    rows.Add(iRow);
            return rows;
        }

        /// <summary>
        /// Đổ toàn bộ dữ liệu trong DataTable vào Sheet
        /// </summary>
        private static void FillSheet(ExcelWorksheet workSheet, DataTable dTable, VerticalMapping vMap,
           int hiddenColumns)
        {
            List<RowMapping> rowsMapping = vMap.RowsMapping.Where(n => n.TableName == _DataTableName).ToList();
            int totalRowFeed = rowsMapping.Count;
            int rowIndex = -1, newRowIndex;
            int lastCol = workSheet.Dimension.End.Column;
            //Feed data into sheet, t0 is default for row repeat
            if (rowsMapping.Count > 0)
            {
                if (HasDataRow(dTable))
                {
                    bool isBold = false;
                    foreach (DataRow dataRow in dTable.Rows)
                    {
                        try
                        {
                            isBold = Convert.ToBoolean(dataRow["IsBold"]);
                        }
                        catch
                        {
                            isBold = false;
                        }
                        foreach (RowMapping rMap in rowsMapping)
                        {
                            if (rowIndex == -1) rowIndex = rMap.SheetIndex;
                            newRowIndex = rowIndex + totalRowFeed;
                            workSheet.InsertRow(newRowIndex, 1, rowIndex);

                            foreach (ColumnMapping cMap in rMap.ColumnsMaping)
                            {
                                var cell = workSheet.Cells[newRowIndex, cMap.SheetIndex];
                                try
                                {
                                    if (dataRow[cMap.TableIndex] == null)
                                    {
                                        cell.Style.Numberformat = null;
                                        cell.Value = null;
                                        cell.Style.Font.Bold = isBold;
                                    }
                                    else if (Convert.ToDouble(dataRow[cMap.TableIndex].ToString()) == 0)
                                    {
                                        cell.Style.Numberformat = null;
                                        cell.Value = 0;
                                        cell.Style.Font.Bold = isBold;
                                    }
                                    else
                                    {
                                        cell.Value = dataRow[cMap.TableIndex];
                                        cell.Style.Font.Bold = isBold;
                                    }
                                }
                                catch
                                {
                                    cell.Value = dataRow[cMap.TableIndex];
                                    cell.Style.Font.Bold = isBold;
                                }
                            }
                            rowIndex++;
                        }
                    }
                }
                int firstRow = rowsMapping[0].SheetIndex;
                foreach (RowMapping rMap in rowsMapping)
                    workSheet.DeleteRow(firstRow);
            }
            //Ẩn những cột đầu tiên
            for (int hCol = 1; hCol <= hiddenColumns; hCol++)
                workSheet.Column(hCol).Hidden = true;
            //workSheet.DeleteColumn(hCol);

        }

        private static void FillSumSheet(ExcelWorksheet workSheet, DataTable dTable, VerticalMapping vMap,
           int hiddenColumns)
        {
            List<RowMapping> rowsMapping = vMap.RowsMapping.Where(n => n.TableName == _SumDataTableName).ToList();
            int totalRowFeed = rowsMapping.Count;
            int rowIndex = rowsMapping[0].SheetIndex, newRowIndex;
            int lastCol = workSheet.Dimension.End.Column;
            //Feed data into sheet, t0 is default for row repeat
            if (rowsMapping.Count > 0)
            {
                if (HasDataRow(dTable))
                {
                    foreach (DataRow dataRow in dTable.Rows)
                        foreach (RowMapping rMap in rowsMapping)
                        {
                            newRowIndex = rowIndex;
                            foreach (ColumnMapping cMap in rMap.ColumnsMaping)
                            {
                                var cell = workSheet.Cells[newRowIndex, cMap.SheetIndex];
                                try
                                {
                                    if (dataRow[cMap.TableIndex] == null)
                                    {
                                        cell.Style.Numberformat = null;
                                        cell.Value = null;
                                    }
                                    else if (Convert.ToDouble(dataRow[cMap.TableIndex].ToString()) == 0)
                                    {
                                        cell.Style.Numberformat = null;
                                        cell.Value = 0;
                                    }
                                    else
                                        cell.Value = dataRow[cMap.TableIndex];
                                }
                                catch
                                {
                                    cell.Value = dataRow[cMap.TableIndex];
                                }
                            }
                            rowIndex++;
                        }
                }
                int firstRow = rowsMapping[0].SheetIndex;
            }
            //Ẩn những cột đầu tiên
            for (int hCol = 1; hCol <= hiddenColumns; hCol++)
                workSheet.Column(hCol).Hidden = true;
            //workSheet.DeleteColumn(hCol);

        }
        /// <summary>
        /// Merge các dòng caption (trên cùng) của ExcelWorksheet theo điều chỉnh ban đầu
        /// </summary>
        private static void MergeSheetCaption(ExcelWorksheet workSheet, HorizontalMapping hMap)
        {
            //Merge các dòng caption của file excel
            int firstRow = workSheet.Dimension.Start.Row;
            int lastRow = workSheet.Dimension.End.Row;
            int temCol = 2, firstCol, lastCol;

            for (int temRow = firstRow; temRow <= lastRow; temRow++)
            {
                try
                {
                    ExcelRange cell = workSheet.Cells[temRow, temCol];
                    if (cell.Value != null)
                    {
                        string cellValue = cell.Value.ToString();
                        if (cellValue.StartsWith("{" + _MergePrefix) && cellValue.EndsWith("}"))
                        {
                            string cellAddress = cellValue.Replace("{" + _MergePrefix, "").Replace("}", "");
                            firstCol = workSheet.Cells[cellAddress].Start.Column;
                            lastCol = workSheet.Cells[cellAddress].End.Column;
                            if (hMap.HasMapping) lastCol += hMap.DynamicColumnCount;
                            ExcelRange rangeMerge = workSheet.Cells[temRow, firstCol, temRow, lastCol];
                            MergeCells(rangeMerge);
                            rangeMerge.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            rangeMerge.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            rangeMerge.Style.WrapText = true;
                        }
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// Đổ dữ liệu của DataTable trong DataSet vào sheet: dữ liệu không có dạng lặp
        /// </summary>
        private static void FillSheetCaptions(ExcelWorksheet workSheet, DataSet dSet, VerticalMapping vMap)
        {
            if (dSet != null && dSet.Tables.Count > 0)
            {
                DataTable dTable = new DataTable();
                foreach (RowMapping rMap in vMap.RowsMapping)
                    if (rMap.TableName != _DataTableName)
                    {
                        int rowIndex = rMap.SheetIndex;
                        int lastCol = workSheet.Dimension.End.Column;
                        dTable = dSet.Tables[rMap.TableName];
                        if (HasDataRow(dTable))
                            foreach (ExcelRangeBase cell in workSheet.Cells[rowIndex, 1, rowIndex, lastCol])
                                if (cell.Value != null)
                                {
                                    string cellValue = cell.Value.ToString();
                                    foreach (DataColumn col in dTable.Columns)
                                        if (cellValue.Contains("{" + col.ColumnName + "}"))
                                        {
                                            cellValue = cellValue.Replace("{" + col.ColumnName + "}",
                                                                            dTable.Rows[0][col].ToString());
                                            cell.Value = cellValue;
                                        }
                                }
                    }
            }
        }



        /// <summary>
        /// Tìm kiếm và ánh xạ cột trong Template với cột của table theo chiều dọc
        /// </summary>
        private static VerticalMapping GetVerticalMapping(ExcelWorksheet workSheet, DataTable dTable)
        {
            VerticalMapping vMap = new VerticalMapping();
            //Tìm các dòng có mapping được định nghĩa trong template
            for (int rowIndex = workSheet.Dimension.Start.Row; rowIndex <= workSheet.Dimension.End.Row; rowIndex++)
            {
                var cell = workSheet.Cells[rowIndex, 1];
                if (cell != null && cell.Value != null)
                {
                    //Dòng này có mapping từ t0, t1, t???
                    if (cell.Value.ToString().StartsWith("t") && !cell.Value.ToString().StartsWith(_SumDataTableName))
                    {
                        var rMap = new RowMapping(rowIndex, cell.Value.ToString());
                        vMap.RowsMapping.Add(rMap);
                    }
                }
            }

            foreach (RowMapping rMap in vMap.RowsMapping)
            {
                //Find and mapping Columns from TemplateSheet to DataTable
                for (int cellIndex = workSheet.Dimension.Start.Column; cellIndex <= workSheet.Dimension.End.Column; cellIndex++)
                {
                    var cell = workSheet.Cells[rMap.SheetIndex, cellIndex];
                    if (cell != null && cell.Value != null)
                    {
                        for (int colIndex = 0; colIndex < dTable.Columns.Count; colIndex++)
                        {
                            string colName = dTable.Columns[colIndex].ColumnName;
                            if (cell.Value.ToString().Contains("{" + colName + "}"))
                            {
                                //Column mapping found
                                rMap.ColumnsMaping.Add(new ColumnMapping(cellIndex, colIndex));
                            }
                        }
                    }
                }
            }
            return vMap;
        }

        private static VerticalMapping GetVerticalMappingByt(ExcelWorksheet workSheet, DataTable dTable, string t)
        {
            VerticalMapping vMap = new VerticalMapping();
            //Tìm các dòng có mapping được định nghĩa trong template
            for (int rowIndex = workSheet.Dimension.Start.Row; rowIndex <= workSheet.Dimension.End.Row; rowIndex++)
            {
                var cell = workSheet.Cells[rowIndex, 1];
                if (cell != null && cell.Value != null)
                {
                    //Dòng này có mapping từ t0, t1, t???
                    if (cell.Value.ToString().StartsWith(t))
                    {
                        var rMap = new RowMapping(rowIndex, cell.Value.ToString());
                        vMap.RowsMapping.Add(rMap);
                    }
                }
            }

            foreach (RowMapping rMap in vMap.RowsMapping)
            {
                //Find and mapping Columns from TemplateSheet to DataTable
                for (int cellIndex = workSheet.Dimension.Start.Column; cellIndex <= workSheet.Dimension.End.Column; cellIndex++)
                {
                    var cell = workSheet.Cells[rMap.SheetIndex, cellIndex];
                    if (cell != null && cell.Value != null)
                    {
                        for (int colIndex = 0; colIndex < dTable.Columns.Count; colIndex++)
                        {
                            string colName = dTable.Columns[colIndex].ColumnName;
                            if (cell.Value.ToString().Contains("{" + colName + "}"))
                            {
                                //Column mapping found
                                rMap.ColumnsMaping.Add(new ColumnMapping(cellIndex, colIndex));
                            }
                        }
                    }
                }
            }
            return vMap;
        }

        /// <summary>
        /// Tìm kiếm và ánh xạ cột trong Template với cột của table theo chiều ngang
        /// </summary>
        private static HorizontalMapping GetHorizontalMapping(ExcelWorksheet workSheet, DataTable dTable)
        {
            HorizontalMapping hMap = new HorizontalMapping();
            hMap.DynamicColumnCount = dTable.Rows.Count;

            //Tìm các cột có mapping được định nghĩa trong template
            for (int colIndex = workSheet.Dimension.Start.Column; colIndex <= workSheet.Dimension.End.Column; colIndex++)
            {
                var cell = workSheet.Cells[1, colIndex];
                if (cell != null && cell.Value != null)
                {
                    //Cột này có mapping từ h0, h1, t???
                    if (cell.Value.ToString().StartsWith(_DynamicColumnName))
                    {
                        hMap.ColumnsMapping = colIndex;
                        break;
                    }
                }
            }

            if (hMap.HasMapping)
            {
                //Tìm các dòng có mapping được định nghĩa trong template
                for (int rowIndex = workSheet.Dimension.Start.Row; rowIndex <= workSheet.Dimension.End.Row; rowIndex++)
                {
                    var cell = workSheet.Cells[rowIndex, 1];
                    if (cell != null && cell.Value != null)
                    {
                        //Dòng này có mapping từ t0, t1, t???
                        if (cell.Value.ToString().StartsWith("t"))
                        {
                            var rMap = new RowMapping(rowIndex, cell.Value.ToString());
                            hMap.RowsMapping.Add(rMap);
                        }
                    }
                }
            }
            return hMap;
        }

        /// <summary>
        /// Láy sheet theo vị trí trong excel package
        /// </summary>
        private static ExcelWorksheet GetSheet(ExcelPackage package, int position)
        {
            ExcelWorksheet currentWorksheet = null;
            ExcelWorkbook workBook = package.Workbook;
            if (workBook != null)
            {
                if (workBook.Worksheets.Count >= position)
                {
                    currentWorksheet = workBook.Worksheets[position];
                }
            }
            return currentWorksheet;
        }

        public static bool HasDataRow(DataTable dTable)
        {
            if (dTable == null) return false;
            else return (dTable.Rows.Count > 0);
        }

        /// <summary>
        /// Ánh xạ dòng theo chiều dọc: Tìm tất cả Dòng trong Sheet để ánh xạ với DataTable trong DataSet
        /// </summary>
        private class VerticalMapping
        {
            public VerticalMapping()
            {
                RowsMapping = new List<RowMapping>();
            }
            public List<RowMapping> RowsMapping { get; set; }
        }

        /// <summary>
        /// Anh xạ cột theo chiều ngang: Cột được thêm vào tự động dựa vào dữ liệu trong data table (TableName:th)
        /// </summary>
        private class HorizontalMapping
        {
            public HorizontalMapping()
            {
                RowsMapping = new List<RowMapping>();
                DynamicColumnCount = 0;
                ColumnsMapping = 0;
            }
            public bool HasMapping { get { return ColumnsMapping > 0; } private set { } }
            public int DynamicColumnCount { get; set; }
            public int ColumnsMapping { get; set; }
            public List<RowMapping> RowsMapping { get; set; }
        }

        /// <summary>
        /// Ánh xạ dòng: dòng trong word sheet <=> table name trong data table
        /// </summary>
        private class RowMapping
        {
            public RowMapping(int sheetIndex, string tableName)
            {
                SheetIndex = sheetIndex;
                TableName = tableName;
                ColumnsMaping = new List<ColumnMapping>();
            }
            public int SheetIndex { get; set; }
            public string TableName { get; set; }
            public List<ColumnMapping> ColumnsMaping { get; set; }
        }

        /// <summary>
        /// Ánh xạ cột: Cột trong word sheet <=> Cột trong data table
        /// </summary>
        private class ColumnMapping
        {
            public ColumnMapping(int sheetIndex, int tableIndex)
            {
                SheetIndex = sheetIndex;
                TableIndex = tableIndex;
            }
            public int SheetIndex { get; set; }
            public int TableIndex { get; set; }
        }
    }
}
