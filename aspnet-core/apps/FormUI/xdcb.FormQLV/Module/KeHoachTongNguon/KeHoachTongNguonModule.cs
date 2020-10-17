using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Localization;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Component;
using xdcb.FormServices.Shared;
using xdcb.QuanLyVon.KeHoachTongNguon.Dtos;
using xdcb.QuanLyVon.KeHoachTongNguonChiTiet.Dtos;

namespace xdcb.FormQLV.KeHoachTongNguon
{
    public class KeHoachTongNguonModule : BaseModule
    {
        #region property
        public KeHoachTongNguonDto mainObject;
        public TreeList tree_kehoachtongnguonchitietView;
        #endregion
        public KeHoachTongNguonModule()
        {
            Name = ModuleName.KeHoachTongNguon.ToString();
            frmKeHoachTong frm = new frmKeHoachTong();
            UIMainForm = frm;
            InitializeModule();
        }

        #region SetValue
        public void SetValueAndControl(KeHoachTongNguonDto objKeHoachTongNguonDto, TreeList treeList)
        {
            mainObject = objKeHoachTongNguonDto;
            tree_kehoachtongnguonchitietView = treeList;
        }

        #endregion
        #region Export Excel
        public void ExportExcel()
        {
            if (mainObject != null && mainObject.Id != Guid.Empty)
            {
                List<KeHoachTongNguonChiTietDto> moduleObject = (List<KeHoachTongNguonChiTietDto>)tree_kehoachtongnguonchitietView.DataSource;
                if (moduleObject == null || moduleObject.Count == 0)
                {
                    GGFunctions.ShowMessage("Không có thông tin chi tiết để xuất file, Vui lòng kiểm tra lại!");
                    return;
                }
                string path = ConfigManager.PathTemplate();
                if (string.IsNullOrWhiteSpace(path))
                {
                    GGFunctions.ShowMessage("Vui lòng cấu hình đường dẫn chứa template");
                }
                if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DAU_NAM.ToString())
                {
                    ExportExcel_DauNam(path);
                }
                else if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString())
                {
                    ExportExcel_DieuChinh(path);
                }
            }
            else
            {
                GGFunctions.ShowMessage("Không có dữ liệu để xuất file, Vui lòng kiểm tra lại!");
            }
        }

        public bool ExportExcel_DauNam(string path)
        {
            bool isExport = true;
            string temFilePath = GGFunctions.GetResultPath(path, TemplateFolder.KeHoachTongNguon.ToString(), TemplateExel.kehoachtongnguondaunam.ToString());
            if (string.IsNullOrWhiteSpace(temFilePath))
            {
                GGFunctions.ShowMessage("Không có mẫu để xuất file. Vui lòng kiểm tra lại");
                isExport = false;
                return isExport;
            }

            string newFilePath = GGFunctions.GetShowFile(string.Format(FormQLVLocalizedResources.kehoachtongnguondaunam, mainObject.Nam.ToString()), temFilePath);
            if (string.IsNullOrWhiteSpace(newFilePath))
            {
                isExport = false;
                return isExport;
            }
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);

            DataTable dtHeader = GGFunctions.ConvertToDataTable<KeHoachTongNguonDto>(SetValueHeaderReport());
            DataTable dtDetail = GGFunctions.ConvertToDataTable<KeHoachTongNguonChiTietDto>(SetValueDetailReport());
            DataTable dtSumDetail = GGFunctions.ConvertToDataTable<KeHoachTongNguonChiTietDto>(SetSumDetailReport());
            ExcelExport.ExportWithTemplate(temFilePath, newFilePath, null, dtHeader, dtDetail, dtSumDetail, 1, 1);
            SplashScreenManager.CloseForm();
            if (File.Exists(newFilePath))
            {
                GGFunctions.StartProcess(newFilePath);
            }
            return isExport;

        }

        public bool ExportExcel_DieuChinh(string path)
        {
            bool isExport = true;
            string temFilePath = GGFunctions.GetResultPath(path, TemplateFolder.KeHoachTongNguon.ToString(), TemplateExel.kehoachtongnguondieuchinh.ToString());
            if (string.IsNullOrWhiteSpace(temFilePath))
            {
                GGFunctions.ShowMessage("Không có mẫu để xuất file. Vui lòng kiểm tra lại");
                isExport = false;
                return isExport;
            }

            string newFilePath = GGFunctions.GetShowFile(string.Format(FormQLVLocalizedResources.kehoachtongnguondieuchinh, mainObject.Nam.ToString()), temFilePath);
            if (string.IsNullOrWhiteSpace(newFilePath))
            {
                isExport = false;
                return isExport;
            }

            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);
            DataTable dtHeader = GGFunctions.ConvertToDataTable<KeHoachTongNguonDto>(SetValueHeaderReport());
            DataTable dtDetail = GGFunctions.ConvertToDataTable<KeHoachTongNguonChiTietDto>(SetValueDetailReport());
            DataTable dtSumDetail = GGFunctions.ConvertToDataTable<KeHoachTongNguonChiTietDto>(SetSumDetailReport());
            ExcelExport.ExportWithTemplate(temFilePath, newFilePath, null, dtHeader, dtDetail, dtSumDetail, 1, 1);
            SplashScreenManager.CloseForm();
            if (File.Exists(newFilePath))
            {
                GGFunctions.StartProcess(newFilePath);
            }
            return isExport;
        }

        public List<KeHoachTongNguonDto> SetValueHeaderReport()
        {
            List<KeHoachTongNguonDto> listHead = new List<KeHoachTongNguonDto>();

            mainObject.NamOld = mainObject.Nam - 1;
            mainObject.NgaySoQuyetDinh = string.Empty;
            if (!string.IsNullOrWhiteSpace(mainObject.SoQuyetDinh))
                mainObject.NgaySoQuyetDinh = mainObject.SoQuyetDinh;
            if (mainObject.NgayQuyetDinh.ToString(FormatValue.DateTime) != DateTime.MinValue.ToString(FormatValue.DateTime)
                && mainObject.NgayQuyetDinh.ToString(FormatValue.DateTime) != DateTime.MinValue.ToString(FormatValue.DateTime))
            {
                mainObject.NgaySoQuyetDinh += " Ngày " + mainObject.NgayQuyetDinh.ToString(FormatValue.DateTime);
            }
            listHead.Add(mainObject);
            return listHead;
        }

        public List<KeHoachTongNguonChiTietDto> SetValueDetailReport()
        {
            List<TreeListNode> node = tree_kehoachtongnguonchitietView.GetNodeList();

            List<KeHoachTongNguonChiTietDto> moduleObject = new List<KeHoachTongNguonChiTietDto>();
            string[] MyArray = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            int i = 0;
            foreach (TreeListNode item in node)
            {
                KeHoachTongNguonChiTietDto obj = tree_kehoachtongnguonchitietView.GetDataRecordByNode(item) as KeHoachTongNguonChiTietDto;
                obj.STT = string.Empty;
                if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DAU_NAM.ToString())
                {
                    obj.SoSanhDuToan = (obj.KeHoachDauNamTruoc == 0 ?
                                        0 :
                                        Math.Round(obj.KeHoachDauNam / obj.KeHoachDauNamTruoc, 3, MidpointRounding.AwayFromZero));
                    obj.SoSanhBoSung = (obj.KeHoachBoSungNamTruoc == 0 ?
                                        0 :
                                        Math.Round(obj.KeHoachDauNam / obj.KeHoachBoSungNamTruoc, 3, MidpointRounding.AwayFromZero));
                }
                else if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString())
                {
                    obj.SoSanhDuToan = (obj.KeHoachDauNamTruoc == 0 ?
                                        0 :
                                        Math.Round(obj.KeHoachBoSung / obj.KeHoachDauNamTruoc, 3, MidpointRounding.AwayFromZero));
                    obj.SoSanhBoSung = (obj.KeHoachBoSungNamTruoc == 0 ?
                                        0 :
                                        Math.Round(obj.KeHoachBoSung / obj.KeHoachBoSungNamTruoc, 3, MidpointRounding.AwayFromZero));
                }
                if (moduleObject.Where(x => x.NguonVonId == obj.NguonVonChaId).ToList().Count() == 0)
                {
                    obj.STT = MyArray[i].ToString().ToUpper();
                    i++;
                }
                else
                {
                    string stt = moduleObject.Where(x => x.NguonVonId == obj.NguonVonChaId).ToList().Select(x => x.STT).FirstOrDefault();
                    for (int j = 1; j <= 8000; j++)
                    {
                        string sttChild = string.Format("{0}.{1}", stt, j);
                        if (moduleObject.Where(x => x.STT == sttChild).ToList().Count() == 0)
                        {
                            obj.STT = sttChild;
                            break;
                        }
                    }
                }
                moduleObject.Add(obj);
            }
            //Xóa số tự chữ
            moduleObject.ForEach(o =>
            {
                if (!string.IsNullOrWhiteSpace(o.STT) && o.STT.Length > 2)
                {
                    o.STT = o.STT.Substring(2, o.STT.Length - 2).ToString();
                }
            });
            return moduleObject;
        }

        public List<KeHoachTongNguonChiTietDto> SetSumDetailReport()
        {
            List<KeHoachTongNguonChiTietDto> sumObject = new List<KeHoachTongNguonChiTietDto>();
            KeHoachTongNguonChiTietDto obj = new KeHoachTongNguonChiTietDto();
            obj.KeHoachDauNamTruoc = GetSumByColumn(KeHoachTongNguonChiTietsColumn.KeHoachDauNamTruoc.ToString());
            obj.KeHoachBoSungNamTruoc = GetSumByColumn(KeHoachTongNguonChiTietsColumn.KeHoachBoSungNamTruoc.ToString());

            if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DAU_NAM.ToString())
            {
                obj.KeHoachDauNam = GetSumByColumn(KeHoachTongNguonChiTietsColumn.KeHoachDauNam.ToString());
                obj.SoSanhDuToan = (obj.KeHoachDauNamTruoc == 0 ?
                                        0 :
                                        Math.Round(obj.KeHoachDauNam / obj.KeHoachDauNamTruoc, 3, MidpointRounding.AwayFromZero));
                obj.SoSanhBoSung = (obj.KeHoachBoSungNamTruoc == 0 ?
                                    0 :
                                    Math.Round(obj.KeHoachDauNam / obj.KeHoachBoSungNamTruoc, 3, MidpointRounding.AwayFromZero));
            }
            else if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString())
            {
                obj.KeHoachDauNamDuocDuyet = GetSumByColumn(KeHoachTongNguonChiTietsColumn.KeHoachDauNamDuocDuyet.ToString());
                obj.DieuChinhTang = GetSumByColumn(KeHoachTongNguonChiTietsColumn.DieuChinhTang.ToString());
                obj.DieuChinhGiam = GetSumByColumn(KeHoachTongNguonChiTietsColumn.DieuChinhGiam.ToString());
                obj.KeHoachBoSung = GetSumByColumn(KeHoachTongNguonChiTietsColumn.KeHoachBoSung.ToString());
                obj.SoSanhDuToan = (obj.KeHoachDauNamTruoc == 0 ?
                                           0 :
                                           Math.Round(obj.KeHoachBoSung / obj.KeHoachDauNamTruoc, 3, MidpointRounding.AwayFromZero));
                obj.SoSanhBoSung = (obj.KeHoachBoSungNamTruoc == 0 ?
                                    0 :
                                    Math.Round(obj.KeHoachBoSung / obj.KeHoachBoSungNamTruoc, 3, MidpointRounding.AwayFromZero));
            }
            sumObject.Add(obj);
            return sumObject;
        }
        #endregion

        #region GetSumByColumn
        public decimal GetSumByColumn(string column)
        {
            decimal result = 0;
            if (tree_kehoachtongnguonchitietView != null && tree_kehoachtongnguonchitietView.DataSource != null)
            {
                List<KeHoachTongNguonChiTietDto> moduleObject = (List<KeHoachTongNguonChiTietDto>)tree_kehoachtongnguonchitietView.DataSource;
                if (moduleObject != null || moduleObject.Count == 0)
                {
                    moduleObject.ForEach(o =>
                    {
                        if (moduleObject.Where(x => x.NguonVonChaId == o.NguonVonId).ToList().Count == 0)
                        {
                            if (column == KeHoachTongNguonChiTietsColumn.KeHoachDauNamTruoc.ToString())
                            {
                                result += o.KeHoachDauNamTruoc;
                            }
                            else if (column == KeHoachTongNguonChiTietsColumn.KeHoachBoSungNamTruoc.ToString())
                            {
                                result += o.KeHoachBoSungNamTruoc;
                            }
                            else if (column == KeHoachTongNguonChiTietsColumn.KeHoachDauNam.ToString())
                            {
                                result += o.KeHoachDauNam;
                            }
                            else if (column == KeHoachTongNguonChiTietsColumn.KeHoachDauNamDuocDuyet.ToString())
                            {
                                result += o.KeHoachDauNamDuocDuyet;
                            }
                            else if (column == KeHoachTongNguonChiTietsColumn.DieuChinhGiam.ToString())
                            {
                                result += o.DieuChinhGiam;
                            }
                            else if (column == KeHoachTongNguonChiTietsColumn.DieuChinhTang.ToString())
                            {
                                result += o.DieuChinhTang;
                            }
                            else if (column == KeHoachTongNguonChiTietsColumn.KeHoachBoSung.ToString())
                            {
                                result += o.KeHoachBoSung;
                            }
                            else if (column == KeHoachTongNguonChiTietsColumn.KeHoachBoSungDuocDuyet.ToString())
                            {
                                result += o.KeHoachBoSungDuocDuyet;
                            }
                        }
                    });
                }
            }
            return Math.Round(result, 6, MidpointRounding.AwayFromZero);
        }
        #endregion
    }
}
