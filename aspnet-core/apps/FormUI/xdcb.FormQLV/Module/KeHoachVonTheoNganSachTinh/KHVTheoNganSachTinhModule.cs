using DevExpress.XtraSplashScreen;
using Localization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using xdcb.Common.DanhMuc.ChuDauTuDtos;
using xdcb.Common.DanhMuc.NguonVonDtos;
using xdcb.FormQLV.Module.KeHoachVonTheoNganSachTinh;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Component;
using xdcb.FormServices.SDK;
using xdcb.FormServices.Shared;
using xdcb.QuanLyVon.KeHoachVonNST.Dtos;
using xdcb.QuanLyVon.KeHoachVonNSTChiTiet.Dtos;

namespace xdcb.FormQLV.KHVTheoNganSachTinh
{
    public class KHVTheoNganSachTinhModule : BaseModule
    {
        #region property
        private KeHoachVonNSTDto _mainObject;
        private List<KeHoachVonNSTChiTietDto> _moduleObject = new List<KeHoachVonNSTChiTietDto>();

        public List<KeHoachVonNSTChiTietDto> _listLoaiKhoan = new List<KeHoachVonNSTChiTietDto>();
        public List<ChuDauTuDto> _listChuDauTu = new List<ChuDauTuDto>();
        public List<KeHoachVonNSTChiTietDto> _listCongTrinh = new List<KeHoachVonNSTChiTietDto>();
        public List<KeHoachVonNSTChiTietDto> _listLoaiCongTrinh = new List<KeHoachVonNSTChiTietDto>();
        public List<KeHoachVonNSTChiTietDto> _listNhomCongTrinh = new List<KeHoachVonNSTChiTietDto>();

        // có cả 3 loại khoản, loại công trình, nhóm công trình
        public List<KeHoachVonNSTChiTietDto> _list1 = new List<KeHoachVonNSTChiTietDto>();

        // có cả 2 loại khoản, loại công trình
        public List<KeHoachVonNSTChiTietDto> _list2 = new List<KeHoachVonNSTChiTietDto>();

        // có cả 2 loại khoản,  nhóm công trình
        public List<KeHoachVonNSTChiTietDto> _list3 = new List<KeHoachVonNSTChiTietDto>();

        //loại công trình, nhóm công trình
        public List<KeHoachVonNSTChiTietDto> _list4 = new List<KeHoachVonNSTChiTietDto>();

        //có 1 loại loại khoản
        public List<KeHoachVonNSTChiTietDto> _list5 = new List<KeHoachVonNSTChiTietDto>();

        //có 1 loại loại công trình
        public List<KeHoachVonNSTChiTietDto> _list6 = new List<KeHoachVonNSTChiTietDto>();

        //có 1 loại nhóm công trình
        public List<KeHoachVonNSTChiTietDto> _list7 = new List<KeHoachVonNSTChiTietDto>();

        //không có loại nào
        public List<KeHoachVonNSTChiTietDto> _list8 = new List<KeHoachVonNSTChiTietDto>();

        #endregion
        public KHVTheoNganSachTinhModule()
        {
            Name = ModuleName.KHVTheoNganSachTinh.ToString();
            frmKHVTheoNganSachTinh frm = new frmKHVTheoNganSachTinh();
            frm.Text = ModuleName.KHVTheoNganSachTinh.GetDescription();
            UIMainForm = frm;
            InitializeModule();
        }
        #region Get/SetValue
        public void SetValueAndControl(KeHoachVonNSTDto obj)
        {
            _mainObject = obj;
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
            string temFilePath = GGFunctions.GetResultPath(path, ModuleName.KHVTheoNganSachTinh.ToString(), TemplateExel.KeHoachVonTheoNganSachTinh_DauNam.ToString());
            if (string.IsNullOrWhiteSpace(temFilePath))
            {
                GGFunctions.ShowMessage("Không có mẫu để xuất file. Vui lòng kiểm tra lại");
                isExport = false;
                return isExport;
            }

            string newFilePath = GGFunctions.GetShowFile(string.Format(FormQLVLocalizedResources.kehoachvontheongansachtinhdaunam, _mainObject.Nam.ToString()), temFilePath);
            if (string.IsNullOrWhiteSpace(newFilePath))
            {
                isExport = false;
                return isExport;
            }
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);

            var dSet = new DataSet();
            DataTable dtHeader = GGFunctions.ConvertToDataTable<KeHoachVonNSTDto>(SetValueHeaderReport());

            List<KeHoachVonNSTChiTietDto> listdetail = SetValueDetailReport();

            //Thêm cột động
            DataTable dtColumn = CreateDataTable(listdetail[0].Value, KeHoachVonNSTChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), 15, 6, 7, 8, 9);
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
            return isExport;

        }

        public bool ExportExcel_DieuChinh(string path)
        {
            bool isExport = true;
            string temFilePath = GGFunctions.GetResultPath(path, ModuleName.KHVTheoNganSachTinh.ToString(), TemplateExel.KeHoachVonTheoNganSachTinh_DieuChinh.ToString());
            if (string.IsNullOrWhiteSpace(temFilePath))
            {
                GGFunctions.ShowMessage("Không có mẫu để xuất file. Vui lòng kiểm tra lại");
                isExport = false;
                return isExport;
            }

            string newFilePath = GGFunctions.GetShowFile(string.Format(FormQLVLocalizedResources.kehoachvontheongansachtinhdieuchinh, _mainObject.Nam.ToString()), temFilePath);
            if (string.IsNullOrWhiteSpace(newFilePath))
            {
                isExport = false;
                return isExport;
            }
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);

            var dSet = new DataSet();
            DataTable dtHeader = GGFunctions.ConvertToDataTable<KeHoachVonNSTDto>(SetValueHeaderReport());

            List<KeHoachVonNSTChiTietDto> listdetail = SetValueDetailReport();
            List<string> listStringKey = new List<string>();
            foreach(var item in listdetail[0].Value)
            {
                string stringKey = item.Key.Split("_")[0];
                listStringKey.Add(stringKey);
            }
            //int col = listdetail[0].Value.Count;
            int col_daunam_duocduyet = listStringKey.Where(x=>x== "KeHoachVonDauNamDuocDuyet").Count();
            int col = listStringKey.Where(x => x == "DieuChinhGiam").Count();

            //Thêm cột động
            DataTable dtColumn = CreateDataTable(listdetail[0].Value, KeHoachVonNSTChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), 14, 7, 8, 9, 10);
            dSet.Tables.Add(dtColumn);
            //Thêm cột động
            DataTable dtColumn1 = CreateDataTable(listdetail[0].Value, KeHoachVonNSTChiTietColumn.DieuChinhGiam.ToString(), 14+ col_daunam_duocduyet + 2, 7, 8, 9, 10);;
            dSet.Tables.Add(dtColumn1);
            //Thêm cột động
            DataTable dtColumn2 = CreateDataTable(listdetail[0].Value, KeHoachVonNSTChiTietColumn.DieuChinhTang.ToString(), 14+ col_daunam_duocduyet+col +4, 7, 8, 9, 10);
            dSet.Tables.Add(dtColumn2);
            //Thêm cột động
            DataTable dtColumn3 = CreateDataTable(listdetail[0].Value, KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinh.ToString(), 14 + col_daunam_duocduyet + (col+2) * 2 +2, 7, 8, 9, 10);
            dSet.Tables.Add(dtColumn3);
            //Thêm cột động
            DataTable dtColumn4 = CreateDataTable(listdetail[0].Value, KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString(), 14 + col_daunam_duocduyet + (col+2) * 3+2 , 7, 8, 9, 10);
            dSet.Tables.Add(dtColumn4);
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
            return isExport;

        }

        public List<KeHoachVonNSTDto> SetValueHeaderReport()
        {
            List<KeHoachVonNSTDto> listHead = new List<KeHoachVonNSTDto>();

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

        public List<KeHoachVonNSTChiTietDto> SetValueDetailReport()
        {
            var apiDetatil = ConfigManager.GetAPIByService<IKeHoachVonNSTChiTietApi>();
            var apiCongTrinh = ConfigManager.GetAPIByService<ICongTrinhsApi>();
            List<KeHoachVonNSTChiTietDto> listChiTiet = apiDetatil.GetListByKeHoachVonNSTIdAsync(_mainObject.Id).GetAwaiter().GetResult();
            listChiTiet = listChiTiet.Where(x => x.CongTrinhId != Guid.Empty).ToList();
            //set các thông tin của công trình vào KeHoachVonNST
            foreach (var item in listChiTiet)
            {
                var congTrinh = apiCongTrinh.GetCongTrinhDetailAsync(item.CongTrinhId).GetAwaiter().GetResult();
                item.TenChuDauTu = congTrinh.TenChuDauTu;
                item.MaSoDuAn = congTrinh.MaSoDuAn;
                item.MaSoChuong = congTrinh.MaChuong;
                item.MaLoaiKhoan = congTrinh.MaLoaiKhoan;
                item.SoQuyetDinh = congTrinh.SoQuyetDinhDauTu;
                item.TongMucDauTu = congTrinh.TongMucDauTu ?? 0;
                item.NST = congTrinh.NST ?? 0;
                item.LoaiCongTrinhID = (Guid)congTrinh.LoaiCongTrinhId;
                item.TenNhomCongTrinh = congTrinh.TenNhomCongTrinh;
                item.TenLoaiCongTrinh = congTrinh.TenLoaiCongTrinh;
                item.LoaiKhoanID = (Guid)congTrinh.LoaiKhoanId;
                item.NhomCongTrinhID = (Guid)congTrinh.NhomCongTrinhId;
                item.TenLoaiKhoan = congTrinh.TenLoaiKhoan;
                item.TenDanhMuc = congTrinh.TenCongTrinh;
                GetValueColumnDynamic(item);
            }


            _moduleObject = new List<KeHoachVonNSTChiTietDto>();

            if (_mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachVon.DAU_NAM.ToString().ToLower().Trim())
            {
                listChiTiet = listChiTiet.Where(x => x.IsSelectDieuChinh == false).ToList().OrderBy(x => x.OrderIndex).ToList();
            }
            else if (_mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachVon.DIEU_CHINH.ToString().ToLower().Trim())
            {
                listChiTiet = listChiTiet.Where(x => x.IsDeleteDieuChinh == false).ToList().OrderBy(x => x.OrderIndex).ToList();
            }

            _list1 = listChiTiet.Where(x => x.LoaiCongTrinhID != null && x.LoaiKhoanID != null && x.NhomCongTrinhID != null).ToList();
            _list2 = listChiTiet.Where(x => x.LoaiCongTrinhID != null && x.LoaiKhoanID != null && x.NhomCongTrinhID == null).ToList();
            _list3 = listChiTiet.Where(x => x.LoaiCongTrinhID == null && x.LoaiKhoanID != null && x.NhomCongTrinhID != null).ToList();
            _list4 = listChiTiet.Where(x => x.LoaiCongTrinhID != null && x.LoaiKhoanID == null && x.NhomCongTrinhID != null).ToList();
            _list5 = listChiTiet.Where(x => x.LoaiCongTrinhID == null && x.LoaiKhoanID != null && x.NhomCongTrinhID == null).ToList();
            _list6 = listChiTiet.Where(x => x.LoaiCongTrinhID != null && x.LoaiKhoanID == null && x.NhomCongTrinhID == null).ToList();
            _list7 = listChiTiet.Where(x => x.LoaiCongTrinhID == null && x.LoaiKhoanID == null && x.NhomCongTrinhID != null).ToList();
            _list8 = listChiTiet.Where(x => x.LoaiCongTrinhID == null && x.LoaiKhoanID == null && x.NhomCongTrinhID == null).ToList();

            #region Xử lý với trường hợp có cả 3 loại
            //lấy danh sách loại khoản
            _listLoaiKhoan = GetGetDataChiTietForLoaiKhoan(_list1);

            int order = 1;
            if(_list1 !=null && _list1.Count > 0)
            {
                foreach (var item in _listLoaiKhoan)
                {
                    item.IsBold = true;
                    item.OrderIndex = order++;
                    _moduleObject.Add(item);

                    //lấy danh sách loại công trình
                    _listLoaiCongTrinh = GetDataChiTietForLoaiCongTrinh(item.LoaiKhoanID, _list1);

                    foreach (var item1 in _listLoaiCongTrinh)
                    {
                        item1.IsBold = true;
                        item1.OrderIndex = order++;
                        _moduleObject.Add(item1);

                        //lấy danh sách nhóm công trình
                        _listNhomCongTrinh = GetDataChiTietForNhomCongTrinh(item.LoaiKhoanID, item1.LoaiCongTrinhID, _list1);

                        foreach (var item2 in _listNhomCongTrinh)
                        {
                            item2.IsBold = true;
                            item2.OrderIndex = order++;
                            _moduleObject.Add(item2);

                            //lấy danh sách công trình
                            _listCongTrinh = _list1.Where(x => x.LoaiKhoanID == item.LoaiKhoanID && x.NhomCongTrinhID == item2.NhomCongTrinhID && item1.LoaiCongTrinhID == x.LoaiCongTrinhID).ToList();
                            int index = 1;
                            foreach (var item3 in _listCongTrinh)
                            {
                                item3.STT = index.ToString();
                                item3.IsBold = false;
                                item3.OrderIndex = order++;
                                GetValueColumnDynamic(item3);
                                _moduleObject.Add(item3);
                                index++;
                            }

                        }
                    }
                }
            }

            #endregion

            #region Xử lý với chỉ có loại khoản và loại công trình
            if (_list2 != null && _list2.Count > 0)
            {
                //lấy danh sách loại khoản
                _listLoaiKhoan = GetGetDataChiTietForLoaiKhoan(_list2);

                foreach (var item in _listLoaiKhoan)
                {
                    item.IsBold = true;
                    item.OrderIndex = order++;
                    _moduleObject.Add(item);

                    //lấy danh sách loại công trình
                    _listLoaiCongTrinh = GetDataChiTietForLoaiCongTrinh(item.LoaiKhoanID, _list2);

                    foreach (var item1 in _listLoaiCongTrinh)
                    {
                        item1.IsBold = true;
                        item1.OrderIndex = order++;
                        _moduleObject.Add(item1);

                        //lấy danh sách công trình
                        _listCongTrinh = _list2.Where(x => x.LoaiKhoanID == item.LoaiKhoanID && item1.LoaiCongTrinhID == x.LoaiCongTrinhID).ToList();
                        var index = 1;
                        foreach (var item3 in _listCongTrinh)
                        {
                            item3.STT = index.ToString();
                            item3.IsBold = false;
                            item3.OrderIndex = order++;
                            GetValueColumnDynamic(item3);
                            _moduleObject.Add(item3);
                            index++;
                        }


                    }
                }
            }

            #endregion

            #region Xử lý với trường hợp có cả 2 loại loại khoản, nhóm công trình

            if (_list3 != null && _list3.Count > 0)
            {
                //lấy danh sách loại khoản
                _listLoaiKhoan = GetGetDataChiTietForLoaiKhoan(_list3);

                foreach (var item in _listLoaiKhoan)
                {
                    item.IsBold = true;
                    item.OrderIndex = order++;
                    _moduleObject.Add(item);
                    //lấy danh sách nhóm công trình
                    _listNhomCongTrinh = GetDataChiTietForNhomCongTrinh(item.LoaiKhoanID, null, _list3);

                    foreach (var item2 in _listNhomCongTrinh)
                    {
                        item2.IsBold = true;
                        item2.OrderIndex = order++;
                        _moduleObject.Add(item2);

                        //lấy danh sách công trình
                        _listCongTrinh = _list3.Where(x => x.LoaiKhoanID == item.LoaiKhoanID && x.NhomCongTrinhID == item2.NhomCongTrinhID).ToList();
                        var index = 1;
                        foreach (var item3 in _listCongTrinh)
                        {
                            item3.STT = index.ToString();
                            item3.IsBold = false;
                            item3.OrderIndex = order++;
                            GetValueColumnDynamic(item3);
                            _moduleObject.Add(item3);
                            index++;
                        }

                    }

                }
            }

            #endregion

            #region Xử lý với trường hợp có cả loại khoản
            if (_list5 != null && _list5.Count > 0)
            {
                //lấy danh sách loại khoản
                _listLoaiKhoan = GetGetDataChiTietForLoaiKhoan(_list5);


                foreach (var item in _listLoaiKhoan)
                {
                    item.IsBold = true;
                    item.OrderIndex = order++;
                    _moduleObject.Add(item);

                    //lấy danh sách công trình
                    _listCongTrinh = _list5.Where(x => x.LoaiKhoanID == item.LoaiKhoanID).ToList();
                    var index = 1;
                    foreach (var item3 in _listCongTrinh)
                    {
                        item3.STT = index.ToString();
                        item3.IsBold = false;
                        item3.OrderIndex = order++;
                        GetValueColumnDynamic(item3);
                        _moduleObject.Add(item3);
                        index++;
                    }
                }
            }

            #endregion

            #region Xử lý với trường có 2 loại ( loại công trình, nhóm công trình)
            if (_list4 != null && _list4.Count > 0)
            {
                //lấy danh sách loại công trình
                _listLoaiCongTrinh = GetDataChiTietForLoaiCongTrinh(null, _list4);

                foreach (var item1 in _listLoaiCongTrinh)
                {
                    item1.IsBold = true;
                    item1.OrderIndex = order++;
                    _moduleObject.Add(item1);

                    //lấy danh sách nhóm công trình
                    _listNhomCongTrinh = GetDataChiTietForNhomCongTrinh(null, null, _list4);

                    foreach (var item2 in _listNhomCongTrinh)
                    {
                        item2.IsBold = true;
                        item2.OrderIndex = order++;
                        _moduleObject.Add(item2);

                        //lấy danh sách công trình
                        _listCongTrinh = _list4.Where(x => x.NhomCongTrinhID == item2.NhomCongTrinhID && item1.LoaiCongTrinhID == x.LoaiCongTrinhID).ToList();
                        var index = 1;
                        foreach (var item3 in _listCongTrinh)
                        {
                            item3.STT = index.ToString();
                            item3.IsBold = false;
                            item3.OrderIndex = order++;
                            GetValueColumnDynamic(item3);
                            _moduleObject.Add(item3);
                            index++;
                        }

                    }
                }
            }


            #endregion

            #region Xử lý với trường hợp có loại công trình
            if (_list6 != null && _list6.Count > 0)
            {
                //lấy danh sách loại khoản
                _listLoaiKhoan = GetGetDataChiTietForLoaiKhoan(_list6);

                foreach (var item1 in _listLoaiCongTrinh)
                {
                    item1.IsBold = true;
                    item1.OrderIndex = order++;
                    _moduleObject.Add(item1);

                    //lấy danh sách công trình
                    _listCongTrinh = _list6.Where(x => item1.LoaiCongTrinhID == x.LoaiCongTrinhID).ToList();
                    var index = 1;
                    foreach (var item3 in _listCongTrinh)
                    {
                        item3.STT = index.ToString();
                        item3.IsBold = false;
                        item3.OrderIndex = order++;
                        GetValueColumnDynamic(item3);
                        _moduleObject.Add(item3);
                        index++;
                    }
                }
            }
            #endregion

            #region Xử lý với trường hợp chỉ có nhóm công trình
            if (_list7 != null && _list7.Count > 0)
            {
                //lấy danh sách nhóm công trình
                _listNhomCongTrinh = GetDataChiTietForNhomCongTrinh(null, null, _list7);

                foreach (var item2 in _listNhomCongTrinh)
                {
                    item2.IsBold = true;
                    item2.OrderIndex = order++;
                    _moduleObject.Add(item2);

                    //lấy danh sách công trình
                    _listCongTrinh = _list7.Where(x => x.NhomCongTrinhID == item2.NhomCongTrinhID).ToList();
                    var index = 1;
                    foreach (var item3 in _listCongTrinh)
                    {
                        item3.STT = index.ToString();
                        item3.IsBold = false;
                        item3.OrderIndex = order++;
                        GetValueColumnDynamic(item3);
                        _moduleObject.Add(item3);
                        index++;
                    }

                }
            }

            #endregion

            #region Xử lý với trường hợp không có loại khoản, loại công trình, nhóm công trình
            if (_list8 != null && _list8.Count > 0)
            {
                //lấy danh sách công trình
                _listCongTrinh = _list8;
                var i = 1;
                foreach (var item3 in _listCongTrinh)
                {
                    item3.STT = i.ToString();
                    item3.IsBold = false;
                    item3.OrderIndex = order++;
                    GetValueColumnDynamic(item3);
                    _moduleObject.Add(item3);
                    i++;
                }
            }
            #endregion

            return _moduleObject;
        }

        private List<KeHoachVonNSTChiTietDto> GetGetDataChiTietForLoaiKhoan(List<KeHoachVonNSTChiTietDto> list)
        {
            List<KeHoachVonNSTChiTietDto> listResult = new List<KeHoachVonNSTChiTietDto>();
            string[] MyArray = new string[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII", "XII", "XIV", "XV", "XVI", "XVII", "XVIII", "XIX", "XX", "XXI", "XXII", "XXIII", "XXIV", "XXV", "XXVI" };

            var listLoaiKhoan = list.Select(x => x.LoaiKhoanID).Distinct().ToList();
            for (int i = 0; i < listLoaiKhoan.Count; i++)
            {
                var item = list.FirstOrDefault(x => x.LoaiKhoanID == listLoaiKhoan[i]);
                if (item!=null)
                {
                    var loaiKhoan = new KeHoachVonNSTChiTietDto();
                    loaiKhoan.STT = MyArray[i].ToString().ToUpper();
                    loaiKhoan.KeHoachVonNSTId = item.KeHoachVonNSTId;
                    loaiKhoan.LoaiKhoanID = item.LoaiKhoanID;
                    loaiKhoan.LoaiCongTrinhID = item.LoaiCongTrinhID;
                    loaiKhoan.NhomCongTrinhID = item.NhomCongTrinhID;
                    loaiKhoan.CongTrinhId = item.CongTrinhId;
                    loaiKhoan.TongMucDauTu = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiKhoanID == listLoaiKhoan[i]).ToList().Sum(x => x.TongMucDauTu);
                    loaiKhoan.NST = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiKhoanID == listLoaiKhoan[i]).ToList().Sum(x => x.NST);
                    loaiKhoan.NhuCauKeHoachVonDauNam = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiKhoanID == listLoaiKhoan[i]).ToList().Sum(x => x.NhuCauKeHoachVonDauNam);
                    loaiKhoan.StringKeHoachVonDauNam = item.StringKeHoachVonDauNam;
                    loaiKhoan.StringKeHoachVonDauNamDuocDuyet = item.StringKeHoachVonDauNamDuocDuyet;
                    loaiKhoan.StringDieuChinhGiam = item.StringDieuChinhGiam;
                    loaiKhoan.StringDieuChinhTang = item.StringDieuChinhTang;
                    loaiKhoan.StringKeHoachVonDieuChinh = item.StringKeHoachVonDieuChinh;
                    loaiKhoan.StringKeHoachVonDieuChinhDuocDuyet = item.StringKeHoachVonDieuChinhDuocDuyet;
                    loaiKhoan.TenDanhMuc = item.TenLoaiKhoan;
                    loaiKhoan.TongVonDeAn = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiKhoanID == listLoaiKhoan[i]).ToList().Sum(x => x.TongVonDeAn);
                    loaiKhoan.VonDeAn = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiKhoanID == listLoaiKhoan[i]).ToList().Sum(x => x.VonDeAn);
                    loaiKhoan.LuyKeVonTongCong = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiKhoanID == listLoaiKhoan[i]).ToList().Sum(x => x.LuyKeVonTongCong);
                    loaiKhoan.LuyKeVonNamTruoc = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiKhoanID == listLoaiKhoan[i]).ToList().Sum(x => x.LuyKeVonNamTruoc);
                    loaiKhoan.KeHoachVonDauNamDuocDuyet = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiKhoanID == listLoaiKhoan[i]).ToList().Sum(x => x.KeHoachVonDauNamDuocDuyet);


                    if (list[0].Value != null && list[0].Value.Count > 0)
                    {
                        loaiKhoan.Value = new Dictionary<string, decimal>();
                        List<string> keyValues = new List<string>(list[0].Value.Keys);
                        keyValues.ForEach(u =>
                        {
                            decimal giatri = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiKhoanID == listLoaiKhoan[i]).ToList().Sum(r => r.Value.Where(x => x.Key == u).ToList().Sum(x => x.Value));
                            loaiKhoan.Value.Add(u, giatri);
                        });
                    }
                    listResult.Add(loaiKhoan);
                }
            }

            return listResult;
        }
        private List<KeHoachVonNSTChiTietDto> GetDataChiTietForLoaiCongTrinh(Guid? LoaiKhoanId, List<KeHoachVonNSTChiTietDto> list)
        {
            List<KeHoachVonNSTChiTietDto> listChiTiet_LoaiCongTrinh = new List<KeHoachVonNSTChiTietDto>();
            var listLoaiCongTrinhId = list.Where(x => x.LoaiKhoanID == LoaiKhoanId ).Select(x => x.LoaiCongTrinhID).Distinct().ToList();
            int index = 1;
            foreach (var item in listLoaiCongTrinhId)
            {
                var loaiCongTrinh = list.FirstOrDefault(x => x.LoaiCongTrinhID == item);
                if (loaiCongTrinh!=null)
                {
                    var nhuCauVon_LoaiCongTrinh = new KeHoachVonNSTChiTietDto();
                    nhuCauVon_LoaiCongTrinh.STT = "(" + index.ToString() + ")";
                    nhuCauVon_LoaiCongTrinh.KeHoachVonNSTId = loaiCongTrinh.KeHoachVonNSTId;
                    nhuCauVon_LoaiCongTrinh.LoaiKhoanID = loaiCongTrinh.LoaiKhoanID;
                    nhuCauVon_LoaiCongTrinh.LoaiCongTrinhID = loaiCongTrinh.LoaiCongTrinhID;
                    nhuCauVon_LoaiCongTrinh.NhomCongTrinhID = loaiCongTrinh.NhomCongTrinhID;
                    nhuCauVon_LoaiCongTrinh.CongTrinhId = loaiCongTrinh.CongTrinhId;
                    nhuCauVon_LoaiCongTrinh.TongMucDauTu = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhID == item && x.LoaiKhoanID == LoaiKhoanId).ToList().Sum(x => x.TongMucDauTu);
                    nhuCauVon_LoaiCongTrinh.NST = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhID == item && x.LoaiKhoanID == LoaiKhoanId).ToList().Sum(x => x.NST);
                    nhuCauVon_LoaiCongTrinh.NhuCauKeHoachVonDieuChinh = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhID == item && x.LoaiKhoanID == LoaiKhoanId).ToList().Sum(x => x.NhuCauKeHoachVonDieuChinh);
                    nhuCauVon_LoaiCongTrinh.StringKeHoachVonDauNam = loaiCongTrinh.StringKeHoachVonDauNam;
                    nhuCauVon_LoaiCongTrinh.StringKeHoachVonDauNamDuocDuyet = loaiCongTrinh.StringKeHoachVonDauNamDuocDuyet;
                    nhuCauVon_LoaiCongTrinh.StringDieuChinhGiam = loaiCongTrinh.StringDieuChinhGiam;
                    nhuCauVon_LoaiCongTrinh.StringDieuChinhTang = loaiCongTrinh.StringDieuChinhTang;
                    nhuCauVon_LoaiCongTrinh.StringKeHoachVonDieuChinh = loaiCongTrinh.StringKeHoachVonDieuChinh;
                    nhuCauVon_LoaiCongTrinh.StringKeHoachVonDieuChinhDuocDuyet = loaiCongTrinh.StringKeHoachVonDieuChinhDuocDuyet;
                    nhuCauVon_LoaiCongTrinh.TenDanhMuc = loaiCongTrinh.TenLoaiCongTrinh;
                    nhuCauVon_LoaiCongTrinh.TongVonDeAn = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhID == item && x.LoaiKhoanID == LoaiKhoanId).ToList().Sum(x => x.TongVonDeAn);
                    nhuCauVon_LoaiCongTrinh.VonDeAn = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhID == item && x.LoaiKhoanID == LoaiKhoanId).ToList().Sum(x => x.VonDeAn);
                    nhuCauVon_LoaiCongTrinh.LuyKeVonTongCong = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhID == item && x.LoaiKhoanID == LoaiKhoanId).ToList().Sum(x => x.LuyKeVonTongCong);
                    nhuCauVon_LoaiCongTrinh.LuyKeVonNamTruoc = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhID == item && x.LoaiKhoanID == LoaiKhoanId).ToList().Sum(x => x.LuyKeVonNamTruoc);
                    nhuCauVon_LoaiCongTrinh.KeHoachVonDauNamDuocDuyet = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhID == item && x.LoaiKhoanID == LoaiKhoanId).ToList().Sum(x => x.KeHoachVonDauNamDuocDuyet);
                    if (list[0].Value != null && list[0].Value.Count > 0)
                    {
                        nhuCauVon_LoaiCongTrinh.Value = new Dictionary<string, decimal>();
                        List<string> keyValues = new List<string>(list[0].Value.Keys);
                        keyValues.ForEach(u =>
                        {
                            decimal giatri = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhID == item && x.LoaiKhoanID == LoaiKhoanId).ToList().Sum(r => r.Value.Where(x => x.Key == u).ToList().Sum(x => x.Value));
                            nhuCauVon_LoaiCongTrinh.Value.Add(u, giatri);
                        });
                    }
                    // GetValueColumnDynamic(nhuCauVon_LoaiCongTrinh);
                    listChiTiet_LoaiCongTrinh.Add(nhuCauVon_LoaiCongTrinh);
                    index++;
                }
                
            }

            return listChiTiet_LoaiCongTrinh;
        }

        private List<KeHoachVonNSTChiTietDto> GetDataChiTietForNhomCongTrinh(Guid? LoaiKhoanId, Guid? LoaiCongTrinhId, List<KeHoachVonNSTChiTietDto> list)
        {

            string[] MyArray = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            List<KeHoachVonNSTChiTietDto> listChiTiet_NhomCongTrinh = new List<KeHoachVonNSTChiTietDto>();
            var listLoaiCongTrinhId = list.Where(x => x.LoaiKhoanID == LoaiKhoanId && x.LoaiCongTrinhID == LoaiCongTrinhId).Select(x => x.NhomCongTrinhID).Distinct().ToList();
            int index = 0;
            foreach (var item in listLoaiCongTrinhId)
            {
                var nhomCongTrinh = list.FirstOrDefault(x => x.NhomCongTrinhID == item);
                
                if (nhomCongTrinh != null)
                {
                    var nhuCauVon_NhomCongTrinh = new KeHoachVonNSTChiTietDto();

                    nhuCauVon_NhomCongTrinh.STT = MyArray[index];
                    nhuCauVon_NhomCongTrinh.KeHoachVonNSTId = nhomCongTrinh.KeHoachVonNSTId;
                    nhuCauVon_NhomCongTrinh.LoaiKhoanID = nhomCongTrinh.LoaiKhoanID;
                    nhuCauVon_NhomCongTrinh.LoaiCongTrinhID = nhomCongTrinh.LoaiCongTrinhID;
                    nhuCauVon_NhomCongTrinh.NhomCongTrinhID = nhomCongTrinh.NhomCongTrinhID;
                    nhuCauVon_NhomCongTrinh.CongTrinhId = nhomCongTrinh.CongTrinhId;                    
                    nhuCauVon_NhomCongTrinh.TongMucDauTu = list.Where(x => x.CongTrinhId != Guid.Empty && x.NhomCongTrinhID == item && x.LoaiKhoanID == LoaiKhoanId && x.LoaiCongTrinhID == LoaiCongTrinhId).ToList().Sum(x => x.TongMucDauTu);
                    nhuCauVon_NhomCongTrinh.NST = list.Where(x => x.CongTrinhId != Guid.Empty && x.NhomCongTrinhID == item && x.LoaiKhoanID == LoaiKhoanId && x.LoaiCongTrinhID == LoaiCongTrinhId).ToList().Sum(x => x.NST);
                    nhuCauVon_NhomCongTrinh.NhuCauKeHoachVonDauNam = nhomCongTrinh.NhuCauKeHoachVonDauNam;
                    nhuCauVon_NhomCongTrinh.StringKeHoachVonDauNam = nhomCongTrinh.StringKeHoachVonDauNam;
                    nhuCauVon_NhomCongTrinh.StringKeHoachVonDauNamDuocDuyet = nhomCongTrinh.StringKeHoachVonDauNamDuocDuyet;
                    nhuCauVon_NhomCongTrinh.StringDieuChinhGiam = nhomCongTrinh.StringDieuChinhGiam;
                    nhuCauVon_NhomCongTrinh.StringDieuChinhTang = nhomCongTrinh.StringDieuChinhTang;
                    nhuCauVon_NhomCongTrinh.StringKeHoachVonDieuChinh = nhomCongTrinh.StringKeHoachVonDieuChinh;
                    nhuCauVon_NhomCongTrinh.StringKeHoachVonDieuChinhDuocDuyet = nhomCongTrinh.StringKeHoachVonDieuChinhDuocDuyet;
                    nhuCauVon_NhomCongTrinh.TenDanhMuc = nhomCongTrinh.TenNhomCongTrinh;
                    nhuCauVon_NhomCongTrinh.TongVonDeAn = list.Where(x => x.CongTrinhId != Guid.Empty && x.NhomCongTrinhID == item && x.LoaiKhoanID == LoaiKhoanId && x.LoaiCongTrinhID == LoaiCongTrinhId).ToList().Sum(x => x.TongVonDeAn);
                    nhuCauVon_NhomCongTrinh.VonDeAn = list.Where(x => x.CongTrinhId != Guid.Empty && x.NhomCongTrinhID == item && x.LoaiKhoanID == LoaiKhoanId && x.LoaiCongTrinhID == LoaiCongTrinhId).ToList().Sum(x => x.VonDeAn);
                    nhuCauVon_NhomCongTrinh.LuyKeVonTongCong = list.Where(x => x.CongTrinhId != Guid.Empty && x.NhomCongTrinhID == item && x.LoaiKhoanID == LoaiKhoanId && x.LoaiCongTrinhID == LoaiCongTrinhId).ToList().Sum(x => x.LuyKeVonTongCong);
                    nhuCauVon_NhomCongTrinh.LuyKeVonNamTruoc = list.Where(x => x.CongTrinhId != Guid.Empty && x.NhomCongTrinhID == item && x.LoaiKhoanID == LoaiKhoanId && x.LoaiCongTrinhID == LoaiCongTrinhId).ToList().Sum(x => x.LuyKeVonNamTruoc);
                    nhuCauVon_NhomCongTrinh.KeHoachVonDauNamDuocDuyet = list.Where(x => x.CongTrinhId != Guid.Empty && x.NhomCongTrinhID == item && x.LoaiKhoanID == LoaiKhoanId && x.LoaiCongTrinhID == LoaiCongTrinhId).ToList().Sum(x => x.KeHoachVonDauNamDuocDuyet);
                    if (list[0].Value != null && list[0].Value.Count > 0)
                    {
                        nhuCauVon_NhomCongTrinh.Value = new Dictionary<string, decimal>();
                        List<string> keyValues = new List<string>(list[0].Value.Keys);
                        keyValues.ForEach(u =>
                        {
                            var listNhomCongTrinh = list.Where(x => x.CongTrinhId != Guid.Empty && x.NhomCongTrinhID == item && x.LoaiKhoanID == LoaiKhoanId && x.LoaiCongTrinhID == LoaiCongTrinhId).ToList();
                            if (listNhomCongTrinh.Count>0)
                            {
                                decimal giatri = listNhomCongTrinh.Sum(r => r.Value.Where(x => x.Key == u).ToList().Sum(x => x.Value));
                                nhuCauVon_NhomCongTrinh.Value.Add(u, giatri);
                            }
                            
                           
                        });
                    }
                    listChiTiet_NhomCongTrinh.Add(nhuCauVon_NhomCongTrinh);
                    index++;
                }

            }

            return listChiTiet_NhomCongTrinh;
        }

        private void GetValueColumnDynamic(KeHoachVonNSTChiTietDto obj)
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
        public List<KeHoachVonNSTChiTietDto> SetSumDetailReport(Dictionary<string, decimal> value)
        {
            List<KeHoachVonNSTChiTietDto> sumObject = new List<KeHoachVonNSTChiTietDto>();
            KeHoachVonNSTChiTietDto obj = new KeHoachVonNSTChiTietDto();
            obj.Value = value;
            obj.TongVonDeAn = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(x => x.TongVonDeAn);
            obj.VonDeAn = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(x => x.VonDeAn);
            obj.LuyKeVonTongCong = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(x => x.LuyKeVonTongCong);
            obj.LuyKeVonNamTruoc = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(x => x.LuyKeVonNamTruoc);
            obj.KeHoachVonDauNamDuocDuyet = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(x => x.KeHoachVonDauNamDuocDuyet);
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

        private DataTable CreateDataTable(Dictionary<string, decimal> value, string tableName, int columnIndex, int groupRowIndex, int headedRowIndex, int totalRowIndex, int detailRowIndex)
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
                    if (item.Key.ToLower().Trim().Contains(ConvertStringColum(tableName).ToString().ToLower().Trim()))
                    {
                        DataRow row = dtColumn.NewRow();
                        row["Key"] = item.Key;
                        row["ColumnIndex"] = columnIndex;
                        row["GroupRowIndex"] = groupRowIndex;
                        row["HeadedRowIndex"] = headedRowIndex;
                        row["TotalRowIndex"] = totalRowIndex;
                        row["DetailRowIndex"] = detailRowIndex;
                        NguonVonDto objNguonVonDto = GetValueNguonVonByColumn(item.Key, ConvertStringColum(tableName));
                        row["Description"] = (objNguonVonDto != null ? objNguonVonDto.TenNguonVon : item.Key);
                        dtColumn.Rows.Add(row);
                    }
                }
            }
            return dtColumn;
        }

        private DataTable ConvertToDataTable(List<KeHoachVonNSTChiTietDto> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(KeHoachVonNSTChiTietDto));
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
            foreach (KeHoachVonNSTChiTietDto item in data)
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
