using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList;
using Localization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using xdcb.Common;
using xdcb.Common.DanhMuc.ChuDauTuDtos;
using xdcb.Common.DanhMuc.CongTrinhDtos;
using xdcb.Common.DanhMuc.LoaiCongTrinhDtos;
using xdcb.Common.DanhMuc.NghiQuyetDtos;
using xdcb.Common.DanhMuc.NguonVonDtos;
using xdcb.FormQLV.KeHoachVonTheoNghiQuyet;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Component;
using xdcb.FormServices.SDK;
using xdcb.FormServices.Shared;
using xdcb.QuanLyVon.KeHoachVonNQ.Dtos;
using xdcb.QuanLyVon.KeHoachVonNQChiTiet.Dtos;

namespace xdcb.FormQLV.KHVTheoNghiQuyet
{
    public class KHVTheoNghiQuyetModule : BaseModule
    {
        #region property
        private KeHoachVonNQDto _mainObject;
        private List<KeHoachVonNQChiTietDto> _moduleObject = new List<KeHoachVonNQChiTietDto>();

        public List<NghiQuyetDto> _listNghiQuyet = new List<NghiQuyetDto>();
        public List<ChuDauTuDto> _listChuDauTu = new List<ChuDauTuDto>();
        public List<CongTrinhDto> _listCongTrinh = new List<CongTrinhDto>();
        public List<LoaiCongTrinhDto> _listLoaiCongTrinh = new List<LoaiCongTrinhDto>();

        #endregion
        public KHVTheoNghiQuyetModule()
        {
            Name = ModuleName.KHVTheoNghiQuyet.ToString();
            frmKHVTheoNghiQuyet frm = new frmKHVTheoNghiQuyet();
            frm.Text = ModuleName.KHVTheoNghiQuyet.GetDescription();
            UIMainForm = frm;
            InitializeModule();

            GetObjectControl();
        }

        #region Get/SetValue
        public void SetValueAndControl(KeHoachVonNQDto obj)
        {
            _mainObject = obj;
        }
        public void GetObjectControl()
        {
            if (_listChuDauTu != null)
                _listChuDauTu.Clear();

            if (_listLoaiCongTrinh != null)
                _listLoaiCongTrinh.Clear();

            var apiChuDauTu = ConfigManager.GetAPIByService<IChuDauTusApi>();
            _listChuDauTu = apiChuDauTu.GetAll().GetAwaiter().GetResult();

            var apiLoaiCongTrinh = ConfigManager.GetAPIByService<ILoaiCongTrinhsApi>();
            _listLoaiCongTrinh = apiLoaiCongTrinh.GetAll().GetAwaiter().GetResult();

            GetDataNghiQuyet();
            GetDataCongTrinh();
        }

        public void GetDataNghiQuyet()
        {
            if (_listNghiQuyet != null)
                _listNghiQuyet.Clear();
            var apiNghiQuyet = ConfigManager.GetAPIByService<INghiQuyetsApi>();
            var dataNghiQuyet = apiNghiQuyet.SearchAsync(new ConditionSearch { SkipCount = 0, MaxResultCount = Int32.MaxValue }).GetAwaiter().GetResult();
            if (dataNghiQuyet != null && dataNghiQuyet.Items.Count > 0)
            {
                _listNghiQuyet = (List<NghiQuyetDto>)dataNghiQuyet.Items;
            }
        }
        public void GetDataCongTrinh()
        {
            if (_listCongTrinh != null)
                _listCongTrinh.Clear();
            var apiCongTrinh = ConfigManager.GetAPIByService<ICongTrinhsApi>();
            _listCongTrinh.AddRange(apiCongTrinh.GetListNotPageAsync().GetAwaiter().GetResult());
        }
        #endregion

        #region Export Excel
        public void ExportExcel()
        {
            if (_mainObject != null && _mainObject.Id != Guid.Empty)
            {
                string path = ConfigManager.PathTemplate();
                if (string.IsNullOrWhiteSpace(path))
                {
                    GGFunctions.ShowMessage("Vui lòng cấu hình đường dẫn chứa template");
                }
                if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
                {
                    ExportExcel_DauNam(path);
                }
                else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
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
            string temFilePath = GGFunctions.GetResultPath(path, ModuleName.KHVTheoNghiQuyet.ToString(), TemplateExel.KeHoachVonTheoNghiQuyet_DauNam.ToString());
            if (string.IsNullOrWhiteSpace(temFilePath))
            {
                GGFunctions.ShowMessage("Không có mẫu để xuất file. Vui lòng kiểm tra lại");
                isExport = false;
                return isExport;
            }

            string newFilePath = GGFunctions.GetShowFile(string.Format(FormQLVLocalizedResources.kehoachvontheonghiquyetdaunam, _mainObject.Nam.ToString()), temFilePath);
            if (string.IsNullOrWhiteSpace(newFilePath))
            {
                isExport = false;
                return isExport;
            }
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);

            var dSet = new DataSet();
            DataTable dtHeader = GGFunctions.ConvertToDataTable<KeHoachVonNQDto>(SetValueHeaderReport());

            List<KeHoachVonNQChiTietDto> listdetail = SetValueDetailReport();

            //Thêm cột động
            DataTable dtColumn = CreateDataTable(listdetail[0].Value, "dtColumn", KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), 10, 7, 8, 9, 10);
            dSet.Tables.Add(dtColumn);
            //TableDetail
            DataTable dtDetail = ConvertToDataTable(listdetail);
            DataTable dtSumDetail = ConvertToDataTable(SetSumDetailReport(listdetail[0].Value));

            ExcelExport.AddColumnDynamic(temFilePath, newFilePath, dSet);

            ExcelExport.ExportWithTemplateCustom(temFilePath, newFilePath, dtHeader, dtDetail, dtSumDetail, 1, 1);
            SplashScreenManager.CloseForm();
            if (File.Exists(newFilePath))
            {
                GGFunctions.StartProcess(newFilePath);
            }
            dtColumn.Dispose();
            dSet.Dispose();
            return isExport;

        }

        public bool ExportExcel_DieuChinh(string path)
        {
            bool isExport = true;
            string temFilePath = GGFunctions.GetResultPath(path, ModuleName.KHVTheoNghiQuyet.ToString(), TemplateExel.KeHoachVonTheoNghiQuyet_DieuChinh.ToString());
            if (string.IsNullOrWhiteSpace(temFilePath))
            {
                GGFunctions.ShowMessage("Không có mẫu để xuất file. Vui lòng kiểm tra lại");
                isExport = false;
                return isExport;
            }

            string newFilePath = GGFunctions.GetShowFile(string.Format(FormQLVLocalizedResources.kehoachvontheonghiquyetdieuchinh, _mainObject.Nam.ToString()), temFilePath);
            if (string.IsNullOrWhiteSpace(newFilePath))
            {
                isExport = false;
                return isExport;
            }
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);

            var dSet = new DataSet();
            DataTable dtHeader = GGFunctions.ConvertToDataTable<KeHoachVonNQDto>(SetValueHeaderReport());

            List<KeHoachVonNQChiTietDto> listdetail = SetValueDetailReport();

            //Thêm cột động
            DataTable dtDieuChinhDuocDuyet = CreateDataTable(listdetail[0].Value, "dtDieuChinhDuocDuyet", KeHoachVonNQChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString(), 20, 7, 8, 9, 10);
            DataTable dtDieuChinh = CreateDataTable(listdetail[0].Value, "dtDieuChinh", KeHoachVonNQChiTietColumn.KeHoachVonDieuChinh.ToString(), 17, 7, 8, 9, 10);
            DataTable dtTang = CreateDataTable(listdetail[0].Value, "dtTang", KeHoachVonNQChiTietColumn.DieuChinhTang.ToString(), 14, 7, 8, 9, 10);
            DataTable dtGiam = CreateDataTable(listdetail[0].Value, "dtGiam", KeHoachVonNQChiTietColumn.DieuChinhGiam.ToString(), 11, 7, 8, 9, 10);
            dSet.Tables.AddRange(new DataTable[] { dtDieuChinhDuocDuyet, dtDieuChinh, dtTang, dtGiam });
            //TableDetail
            DataTable dtDetail = ConvertToDataTable(listdetail);
            DataTable dtSumDetail = ConvertToDataTable(SetSumDetailReport(listdetail[0].Value));

            ExcelExport.AddColumnDynamic(temFilePath, newFilePath, dSet);

            ExcelExport.ExportWithTemplateCustom(temFilePath, newFilePath, dtHeader, dtDetail, dtSumDetail, 1, 1);
            SplashScreenManager.CloseForm();
            if (File.Exists(newFilePath))
            {
                GGFunctions.StartProcess(newFilePath);
            }
            dtDieuChinhDuocDuyet.Dispose();
            dtDieuChinh.Dispose();
            dtTang.Dispose();
            dtGiam.Dispose();
            dSet.Dispose();
            return isExport;

        }

        public List<KeHoachVonNQDto> SetValueHeaderReport()
        {
            List<KeHoachVonNQDto> listHead = new List<KeHoachVonNQDto>();

            _mainObject.NamOld = _mainObject.Nam - 1;
            _mainObject.NgaySoQuyetDinh = string.Empty;
            if (!string.IsNullOrWhiteSpace(_mainObject.SoQuyetDinh))
                _mainObject.NgaySoQuyetDinh = _mainObject.SoQuyetDinh;
            if (_mainObject.NgayBanHanh != null)
            {
                _mainObject.NgaySoQuyetDinh += " Ngày " + Convert.ToDateTime(_mainObject.NgayBanHanh).ToString(FormatValue.DateTime);
            }
            listHead.Add(_mainObject);
            return listHead;
        }

        public List<KeHoachVonNQChiTietDto> SetValueDetailReport()
        {
            var apiDetatil = ConfigManager.GetAPIByService<IKeHoachVonNQChiTietsApi>();
            List<KeHoachVonNQChiTietDto> listChiTiet = apiDetatil.GetListByKeHoachVonNQIdAsync(_mainObject.Id).GetAwaiter().GetResult();

            _moduleObject = new List<KeHoachVonNQChiTietDto>();

            if (_mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachVon.DAU_NAM.ToString().ToLower().Trim())
            {
                listChiTiet = listChiTiet.Where(x => x.IsSelectDieuChinh == false).ToList().OrderBy(x => x.OrderIndex).ToList();
            }
            else if (_mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachVon.DIEU_CHINH.ToString().ToLower().Trim())
            {
                listChiTiet = listChiTiet.Where(x => x.IsDeleteDieuChinh == false).ToList().OrderBy(x => x.OrderIndex).ToList();
            }

            int i = 0;
            int order = 1;
            //Lấy danh sách nghị quyết
            listChiTiet.Where(x => x.CongTrinhId == Guid.Empty).ToList().OrderBy(x => x.OrderIndex).ToList().ForEach(o =>
            {
                //Lấy danh sách công trình thuộc nghị quyết
                List<KeHoachVonNQChiTietDto> listChiTiet_CongTrinh = GetDataChiTietForCongTrinh(o.NghiQuyetId, listChiTiet.Where(x => x.CongTrinhId != Guid.Empty && x.NghiQuyetId == o.NghiQuyetId).ToList().OrderBy(x => x.OrderIndex).ToList());
                GetGetDataChiTietForNghiQuyet(o, i);

                o.IsBold = true;
                o.OrderIndex = order++;
                _moduleObject.Add(o);

                //Danh sách loại công trình thuộc nghị quyết
                List<KeHoachVonNQChiTietDto> listChiTiet_LoaiCongTrinh = GetDataChiTietForLoaiCongTrinh(listChiTiet_CongTrinh);
                if (listChiTiet_LoaiCongTrinh != null && listChiTiet_LoaiCongTrinh.Count > 0)
                {
                    int j = 1;
                    listChiTiet_LoaiCongTrinh.ForEach(u =>
                    {
                        u.STT = string.Format("{0}.{1}", o.STT, j);
                        u.IsBold = true;
                        u.OrderIndex = order++;
                        _moduleObject.Add(u);

                        //Lấy danh sách công trình thuộc loại công trình
                        int k = 1;
                        listChiTiet_CongTrinh.Where(x => x.LoaiCongTrinhID == u.LoaiCongTrinhID).ToList().ForEach(h =>
                        {
                            h.STT = k.ToString();
                            h.IsBold = false;
                            h.OrderIndex = order++;
                            _moduleObject.Add(h);
                            k++;
                        });
                        j++;
                    });
                }
                i++;
            });
            return _moduleObject;
        }

        private KeHoachVonNQChiTietDto GetGetDataChiTietForNghiQuyet(KeHoachVonNQChiTietDto obj, int index)
        {
            string[] MyArray = new string[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII", "XII", "XIV", "XV", "XVI", "XVII", "XVIII", "XIX", "XX", "XXI", "XXII", "XXIII", "XXIV", "XXV", "XXVI" };
            obj.STT = MyArray[index].ToString().ToUpper();
            NghiQuyetDto objNghiQuyet = _listNghiQuyet.Where(x => x.Id == obj.NghiQuyetId).ToList().FirstOrDefault();
            if (objNghiQuyet != null && objNghiQuyet.Id != Guid.Empty)
            {
                obj.TenDanhMuc = objNghiQuyet.TrichYeu;
            }
            GetValueColumnDynamic(obj);
            return obj;
        }
        private List<KeHoachVonNQChiTietDto> GetDataChiTietForCongTrinh(Guid nghiQuyetId, List<KeHoachVonNQChiTietDto> list)
        {
            if (list == null)
                list = new List<KeHoachVonNQChiTietDto>();
            list.Where(x => x.CongTrinhId != Guid.Empty && x.NghiQuyetId == nghiQuyetId).ToList().OrderBy(x => x.OrderIndex).ToList().ForEach(o =>
            {
                CongTrinhDto objCongTrinh = _listCongTrinh.Where(x => x.Id == o.CongTrinhId).ToList().FirstOrDefault();
                if (objCongTrinh != null && objCongTrinh.Id != Guid.Empty)
                {
                    o.TenDanhMuc = objCongTrinh.TenCongTrinh;
                    if (objCongTrinh.ChuDauTuId != Guid.Empty && _listChuDauTu != null)
                    {
                        ChuDauTuDto objChuDauTu = _listChuDauTu.Where(x => x.Id == objCongTrinh.ChuDauTuId).ToList().FirstOrDefault();
                        if (objChuDauTu != null)
                        {
                            o.TenChuDauTu = objChuDauTu.Ten;
                        }
                    }
                    if (objCongTrinh.LoaiCongTrinhId != Guid.Empty && _listLoaiCongTrinh != null)
                    {
                        LoaiCongTrinhDto objLoaiCongTrinh = _listLoaiCongTrinh.Where(x => x.Id == objCongTrinh.LoaiCongTrinhId).ToList().FirstOrDefault();
                        if (objLoaiCongTrinh != null)
                        {
                            o.TenLoaiCongTrinh = objLoaiCongTrinh.TenLoaiCongTrinh;
                            o.LoaiCongTrinhID = objLoaiCongTrinh.Id;
                        }
                    }
                }
                GetValueColumnDynamic(o);
            });
            return list;
        }
        private List<KeHoachVonNQChiTietDto> GetDataChiTietForLoaiCongTrinh(List<KeHoachVonNQChiTietDto> list)
        {
            List<KeHoachVonNQChiTietDto> listChiTiet_LoaiCongTrinh = new List<KeHoachVonNQChiTietDto>();
            list.Select(x => x.LoaiCongTrinhID).Distinct().ToList().ForEach(o =>
            {
                KeHoachVonNQChiTietDto obj = new KeHoachVonNQChiTietDto();
                obj.LoaiCongTrinhID = o;
                LoaiCongTrinhDto objLoaiCongTrinh = _listLoaiCongTrinh.Where(x => x.Id == o).ToList().FirstOrDefault();
                if (objLoaiCongTrinh != null && objLoaiCongTrinh.Id != Guid.Empty)
                {
                    obj.TenDanhMuc = objLoaiCongTrinh.TenLoaiCongTrinh;
                }
                obj.TongVonDeAn = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhID == o).ToList().Sum(x => x.TongVonDeAn);
                obj.VonDeAn = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhID == o).ToList().Sum(x => x.VonDeAn);
                obj.LuyKeVonTongCong = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhID == o).ToList().Sum(x => x.LuyKeVonTongCong);
                obj.LuyKeVonNamTruoc = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhID == o).ToList().Sum(x => x.LuyKeVonNamTruoc);
                obj.KeHoachVonDauNamDuocDuyet = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhID == o).ToList().Sum(x => x.KeHoachVonDauNamDuocDuyet);
                obj.DieuChinhGiam = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhID == o).ToList().Sum(x => x.DieuChinhGiam);
                obj.DieuChinhTang = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhID == o).ToList().Sum(x => x.DieuChinhTang);
                obj.KeHoachVonDieuChinh = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhID == o).ToList().Sum(x => x.KeHoachVonDieuChinh);
                obj.KeHoachVonDieuChinhDuocDuyet = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhID == o).ToList().Sum(x => x.KeHoachVonDieuChinhDuocDuyet);
                if (list[0].Value != null && list[0].Value.Count > 0)
                {
                    obj.Value = new Dictionary<string, decimal>();
                    List<string> keyValues = new List<string>(list[0].Value.Keys);
                    keyValues.ForEach(u =>
                    {
                        decimal giatri = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhID == o).ToList().Sum(r => r.Value.Where(x => x.Key == u).ToList().Sum(x => x.Value));
                        obj.Value.Add(u, giatri);
                    });
                }
                listChiTiet_LoaiCongTrinh.Add(obj);
            });
            return listChiTiet_LoaiCongTrinh;
        }

        private void GetValueColumnDynamic(KeHoachVonNQChiTietDto obj)
        {
            // Gán dữ liệu vào cột động
            obj.Value = new Dictionary<string, decimal>();
            if (!string.IsNullOrEmpty(obj.StringKeHoachVonDauNam))
            {
                AddValueColumnDynamic(obj.Value, obj.StringKeHoachVonDauNam);
            }
            if (!string.IsNullOrEmpty(obj.StringKeHoachVonDauNamDuocDuyet))
            {
                AddValueColumnDynamic(obj.Value, obj.StringKeHoachVonDauNamDuocDuyet);
            }
            //Load dữ liệu điều chỉnh
            if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
            {
                if (!string.IsNullOrEmpty(obj.StringDieuChinhGiam))
                {
                    AddValueColumnDynamic(obj.Value, obj.StringDieuChinhGiam);
                }
                if (!string.IsNullOrEmpty(obj.StringDieuChinhTang))
                {
                    AddValueColumnDynamic(obj.Value, obj.StringDieuChinhTang);
                }
                if (!string.IsNullOrEmpty(obj.StringKeHoachVonDieuChinh))
                {
                    AddValueColumnDynamic(obj.Value, obj.StringKeHoachVonDieuChinh);
                }
                if (!string.IsNullOrEmpty(obj.StringKeHoachVonDieuChinhDuocDuyet))
                {
                    AddValueColumnDynamic(obj.Value, obj.StringKeHoachVonDieuChinhDuocDuyet);
                }
            }
        }
        public List<KeHoachVonNQChiTietDto> SetSumDetailReport(Dictionary<string, decimal> value)
        {
            List<KeHoachVonNQChiTietDto> sumObject = new List<KeHoachVonNQChiTietDto>();
            KeHoachVonNQChiTietDto obj = new KeHoachVonNQChiTietDto();
            obj.Value = value;
            obj.TongVonDeAn = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(x => x.TongVonDeAn);
            obj.VonDeAn = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(x => x.VonDeAn);
            obj.LuyKeVonTongCong = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(x => x.LuyKeVonTongCong);
            obj.LuyKeVonNamTruoc = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(x => x.LuyKeVonNamTruoc);
            obj.KeHoachVonDauNamDuocDuyet = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(x => x.KeHoachVonDauNamDuocDuyet);
            obj.DieuChinhGiam = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(x => x.DieuChinhGiam);
            obj.DieuChinhTang = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(x => x.DieuChinhTang);
            obj.KeHoachVonDieuChinh = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(x => x.KeHoachVonDieuChinh);
            obj.KeHoachVonDieuChinhDuocDuyet = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(x => x.KeHoachVonDieuChinhDuocDuyet);
            if (obj.Value != null && obj.Value.Count > 0)
            {
                List<string> keyValues = new List<string>(obj.Value.Keys);
                keyValues.ForEach(u =>
                {
                    obj.Value[u] = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(o => o.Value.Where(x => x.Key == u).ToList().Sum(x => x.Value));
                });
            }
            obj.IsBold = true;
            sumObject.Add(obj);
            return sumObject;
        }
        #endregion

        #region ConvertData
        private NguonVonDto GetValueNguonVonByColumn(string key, string column)
        {
            NguonVonDto objNguonVon = new NguonVonDto();
            if (key.ToString().ToLower().Trim().Contains(column.ToString().ToLower().Trim()))
            {
                string[] Split = key.Split('_');
                if (Split != null && Split.Count() > 1)
                {
                    Guid id = new Guid(Split[1].ToString());
                    if (id != null && id != Guid.Empty)
                    {
                        var api = ConfigManager.GetAPIByService<INguonVonsApi>();
                        objNguonVon = api.GetAsync(id).GetAwaiter().GetResult();
                    }
                }
            }
            return objNguonVon;
        }

        private string ConvertStringColum(string column)
        {
            return column + "_";
        }

        private Dictionary<string, decimal> AddValueColumnDynamic(Dictionary<string, decimal> value, string strJson)
        {
            if (!string.IsNullOrEmpty(strJson))
            {
                var dictionary = JsonConvert.DeserializeObject<List<EnumDescriptionViewModel>>(strJson);
                if (dictionary != null && dictionary.Count > 0)
                {
                    foreach (var item in dictionary)
                    {
                        if (value.Where(x => x.Key.ToString().ToLower() == item.Key.ToString().ToLower()).ToList().Count() == 0)
                        {
                            value.Add(item.Key, Convert.ToDecimal(item.Value.Trim()));
                        }
                    }
                }
            }
            return value;
        }

        private DataTable CreateDataTable(Dictionary<string, decimal> value, string tableName, string columnName, int columnIndex, int groupRowIndex, int headedRowIndex, int totalRowIndex, int detailRowIndex)
        {
            DataTable dtColumn = new DataTable();
            dtColumn.TableName = tableName;
            dtColumn.Columns.Add("Key", typeof(string));
            dtColumn.Columns.Add("ColumnIndex", typeof(int));
            dtColumn.Columns.Add("GroupRowIndex", typeof(int));
            dtColumn.Columns.Add("HeadedRowIndex", typeof(int));
            dtColumn.Columns.Add("TotalRowIndex", typeof(int));
            dtColumn.Columns.Add("DetailRowIndex", typeof(int));
            dtColumn.Columns.Add("Description", typeof(string));
            if (value != null)
            {
                foreach (var item in value)
                {
                    if (item.Key.ToLower().Trim().Contains(ConvertStringColum(columnName).ToString().ToLower().Trim()))
                    {
                        DataRow row = dtColumn.NewRow();
                        row["Key"] = item.Key;
                        row["ColumnIndex"] = columnIndex;
                        row["GroupRowIndex"] = groupRowIndex;
                        row["HeadedRowIndex"] = headedRowIndex;
                        row["TotalRowIndex"] = totalRowIndex;
                        row["DetailRowIndex"] = detailRowIndex;
                        NguonVonDto objNguonVonDto = GetValueNguonVonByColumn(item.Key, ConvertStringColum(columnName));
                        row["Description"] = (objNguonVonDto != null ? objNguonVonDto.TenNguonVon : item.Key);
                        dtColumn.Rows.Add(row);
                    }
                }
            }
            return dtColumn;
        }


        private DataTable ConvertToDataTable(List<KeHoachVonNQChiTietDto> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(KeHoachVonNQChiTietDto));
            DataTable table = new DataTable();

            // Tạo cột
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            if (data[0].Value != null && data[0].Value.Count > 0)
            {
                List<string> keyValues = new List<string>(data[0].Value.Keys);
                keyValues.ForEach(u =>
                {
                    table.Columns.Add(u, typeof(decimal));
                });
            }

            // Đổ dữ liệu chi tiết
            foreach (KeHoachVonNQChiTietDto item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;

                if (item.Value != null && item.Value.Count > 0)
                {
                    List<string> keyValues = new List<string>(item.Value.Keys);
                    keyValues.ForEach(u =>
                    {
                        row[u] = item.Value[u];
                    });
                }
                table.Rows.Add(row);
            }
            return table;
        }
        #endregion
    }
}
