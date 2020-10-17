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
using xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGiaDtos;
using xdcb.Common.DanhMuc.CongTrinhDtos;
using xdcb.Common.DanhMuc.LoaiCongTrinhDtos;
using xdcb.Common.DanhMuc.LoaiKhoanDtos;
using xdcb.Common.DanhMuc.NguonVonDtos;
using xdcb.Common.DanhMuc.NhomCongTrinhDtos;
using xdcb.FormQLV.KeHoachVonTheoNganSachTrungUong;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Component;
using xdcb.FormServices.SDK;
using xdcb.FormServices.Shared;
using xdcb.QuanLyVon.KeHoachVonNSTW.Dtos;
using xdcb.QuanLyVon.KeHoachVonNSTWChiTiet.Dtos;

namespace xdcb.FormQLV.KHVTheoNganSachTrungUong
{
    public class KHVTheoNganSachTrungUongModule : BaseModule
    {
        #region property
        private KeHoachVonNSTWDto _mainObject;
        private List<KeHoachVonNSTWChiTietDto> _moduleObject = new List<KeHoachVonNSTWChiTietDto>();

        public List<LoaiKhoanDto> _listLoaiKhoan = new List<LoaiKhoanDto>();
        public List<ChuDauTuDto> _listChuDauTu = new List<ChuDauTuDto>();
        public List<CongTrinhDto> _listCongTrinh = new List<CongTrinhDto>();
        public List<LoaiCongTrinhDto> _listLoaiCongTrinh = new List<LoaiCongTrinhDto>();
        public List<ChuongTrinhMucTieuQuocGiaDto> _listCTMTQuocGia = new List<ChuongTrinhMucTieuQuocGiaDto>();
        public List<NhomCongTrinhDto> _listNhomCongTrinh = new List<NhomCongTrinhDto>();


        #endregion
        public KHVTheoNganSachTrungUongModule()
        {
            Name = ModuleName.KHVTheoNganSachTrungUong.ToString();
            frmKHVTheoNganSachTrungUong frm = new frmKHVTheoNganSachTrungUong();
            frm.Text = ModuleName.KHVTheoNganSachTrungUong.GetDescription();
            UIMainForm = frm;
            InitializeModule();

            GetObjectControl();
        }

        #region Get/SetValue
        public void SetValueAndControl(KeHoachVonNSTWDto obj)
        {
            _mainObject = obj;
        }
        public void GetObjectControl()
        {
            if (_listChuDauTu != null)
                _listChuDauTu.Clear();

            if (_listLoaiCongTrinh != null)
                _listLoaiCongTrinh.Clear();

            if (_listCTMTQuocGia != null)
                _listCTMTQuocGia.Clear();

            if (_listNhomCongTrinh != null)
                _listNhomCongTrinh.Clear();

            var apiChuDauTu = ConfigManager.GetAPIByService<IChuDauTusApi>();
            _listChuDauTu = apiChuDauTu.GetAll().GetAwaiter().GetResult();

            var apiLoaiCongTrinh = ConfigManager.GetAPIByService<ILoaiCongTrinhsApi>();
            _listLoaiCongTrinh = apiLoaiCongTrinh.GetAll().GetAwaiter().GetResult();

            var apiCTMTGG = ConfigManager.GetAPIByService<IChuongTrinhMucTieuQuocGiasApi>();
            _listCTMTQuocGia = apiCTMTGG.GetAll().GetAwaiter().GetResult();

            var apiNhomCongTrinh = ConfigManager.GetAPIByService<INhomCongTrinhsApi>();
            _listNhomCongTrinh = apiNhomCongTrinh.GetAll().GetAwaiter().GetResult();

            GetDataLoaiKhoan();

            GetDataCongTrinh();
        }

        public void GetDataLoaiKhoan()
        {
            if (_listLoaiKhoan != null)
                _listLoaiKhoan.Clear();
            var apiLoaiKhoan = ConfigManager.GetAPIByService<ILoaiKhoansApi>();
            _listLoaiKhoan = apiLoaiKhoan.GetAll().GetAwaiter().GetResult();
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
            string temFilePath = GGFunctions.GetResultPath(path, ModuleName.KHVTheoNganSachTrungUong.ToString(), TemplateExel.KeHoachVonTheoNganSachTrungUong_DauNam.ToString());
            if (string.IsNullOrWhiteSpace(temFilePath))
            {
                GGFunctions.ShowMessage("Không có mẫu để xuất file. Vui lòng kiểm tra lại");
                isExport = false;
                return isExport;
            }

            string newFilePath = GGFunctions.GetShowFile(string.Format(FormQLVLocalizedResources.kehoachvontheoNSTWdaunam, _mainObject.Nam.ToString()), temFilePath);
            if (string.IsNullOrWhiteSpace(newFilePath))
            {
                isExport = false;
                return isExport;
            }
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);

            var dSet = new DataSet();
            DataTable dtHeader = GGFunctions.ConvertToDataTable<KeHoachVonNSTWDto>(SetValueHeaderReport());

            List<KeHoachVonNSTWChiTietDto> listdetail = SetValueDetailReport();

            //Thêm cột động
            DataTable dtColumn = CreateDataTable(listdetail[0].Value, "dtColumn", KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), 29, 7, 8, 9, 10);
            DataTable dtColumnTrungHanNam = CreateDataTable(listdetail[0].Value, "dtColumnTrungHanNam", KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), 18, 7, 8, 0, 0);
            DataTable dtColumnTrungHanGiaiDoan = CreateDataTable(listdetail[0].Value, "dtColumnTrungHanGiaiDoan", KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), 14, 7, 8, 0, 0);
            dSet.Tables.AddRange(new DataTable[] { dtColumn, dtColumnTrungHanNam, dtColumnTrungHanGiaiDoan });
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
            dtColumnTrungHanNam.Dispose();
            dtColumnTrungHanGiaiDoan.Dispose();
            dSet.Dispose();
            return isExport;

        }

        public bool ExportExcel_DieuChinh(string path)
        {
            bool isExport = true;
            string temFilePath = GGFunctions.GetResultPath(path, ModuleName.KHVTheoNganSachTrungUong.ToString(), TemplateExel.KeHoachVonTheoNganSachTrungUong_DieuChinh.ToString());
            if (string.IsNullOrWhiteSpace(temFilePath))
            {
                GGFunctions.ShowMessage("Không có mẫu để xuất file. Vui lòng kiểm tra lại");
                isExport = false;
                return isExport;
            }

            string newFilePath = GGFunctions.GetShowFile(string.Format(FormQLVLocalizedResources.kehoachvontheoNSTWdieuchinh, _mainObject.Nam.ToString()), temFilePath);
            if (string.IsNullOrWhiteSpace(newFilePath))
            {
                isExport = false;
                return isExport;
            }
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);

            var dSet = new DataSet();
            DataTable dtHeader = GGFunctions.ConvertToDataTable<KeHoachVonNSTWDto>(SetValueHeaderReport());

            List<KeHoachVonNSTWChiTietDto> listdetail = SetValueDetailReport();
            //Thêm cột động
            DataTable dtDieuChinhDuocDuyet = CreateDataTable(listdetail[0].Value, "dtDieuChinhDuocDuyet", KeHoachVonNQChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString(), 41, 7, 8, 9, 10);
            DataTable dtDieuChinh = CreateDataTable(listdetail[0].Value, "dtDieuChinh", KeHoachVonNQChiTietColumn.KeHoachVonDieuChinh.ToString(), 38, 7, 8, 9, 10);
            DataTable dtTang = CreateDataTable(listdetail[0].Value, "dtTang", KeHoachVonNQChiTietColumn.DieuChinhTang.ToString(), 35, 7, 8, 9, 10);
            DataTable dtGiam = CreateDataTable(listdetail[0].Value, "dtGiam", KeHoachVonNQChiTietColumn.DieuChinhGiam.ToString(), 32, 7, 8, 9, 10);
            DataTable dtDaGiao = CreateDataTable(listdetail[0].Value, "dtDaGiao", KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), 29, 7, 8, 9, 10);

            DataTable dtTrungHanNam = CreateDataTable(listdetail[0].Value, "dtTrungHanNam", KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), 18, 7, 8, 0, 0);
            DataTable dtTrungHanGiaiDoan = CreateDataTable(listdetail[0].Value, "dtTrungHanGiaiDoan", KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), 14, 7, 8, 0, 0);

            dSet.Tables.AddRange(new DataTable[] { dtDieuChinhDuocDuyet, dtDieuChinh, dtTang, dtGiam, dtDaGiao, dtTrungHanNam, dtTrungHanGiaiDoan });
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
            dtDaGiao.Dispose();
            dtTrungHanNam.Dispose();
            dtTrungHanGiaiDoan.Dispose();
            dSet.Dispose();
            return isExport;

        }

        public List<KeHoachVonNSTWDto> SetValueHeaderReport()
        {
            List<KeHoachVonNSTWDto> listHead = new List<KeHoachVonNSTWDto>();

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

        public List<KeHoachVonNSTWChiTietDto> SetValueDetailReport()
        {
            var apiDetatil = ConfigManager.GetAPIByService<IKeHoachVonNSTWChiTietsApi>();
            List<KeHoachVonNSTWChiTietDto> listChiTiet = apiDetatil.GetListByKeHoachVonNSTWIdAsync(_mainObject.Id).GetAwaiter().GetResult();

            _moduleObject = new List<KeHoachVonNSTWChiTietDto>();

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
            //Lấy danh sách loại khoản
            listChiTiet.Where(x => x.CongTrinhId == Guid.Empty).ToList().OrderBy(x => x.OrderIndex).ToList().ForEach(o =>
            {
                //Lấy danh sách công trình thuộc nghị quyết
                List<KeHoachVonNSTWChiTietDto> listChiTiet_CongTrinh = GetDataChiTietForCongTrinh(o.LoaiKhoanId, listChiTiet.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiKhoanId == o.LoaiKhoanId).ToList().OrderBy(x => x.OrderIndex).ToList());
                GetGetDataChiTietForLoaiKhoan(o, i);

                o.IsBold = true;
                o.OrderIndex = order++;
                _moduleObject.Add(o);

                //Danh sách loại công trình thuộc nghị quyết
                List<KeHoachVonNSTWChiTietDto> listChiTiet_LoaiCongTrinh = GetDataChiTietForLoaiCongTrinh(listChiTiet_CongTrinh);
                if (listChiTiet_LoaiCongTrinh != null && listChiTiet_LoaiCongTrinh.Count > 0)
                {
                    int j = 1;
                    listChiTiet_LoaiCongTrinh.ForEach(u =>
                    {
                        u.STT = string.Format("{0}.{1}", o.STT, j);
                        u.IsBold = true;
                        u.OrderIndex = order++;
                        _moduleObject.Add(u);

                        //lấy danh sách nhóm công trình
                        GetDataChiTietForNhomCongTrinh(o.LoaiKhoanId, u.LoaiCongTrinhId, listChiTiet_CongTrinh).ForEach(n =>
                        {
                            n.IsBold = true;
                            n.OrderIndex = order++;
                            _moduleObject.Add(n);

                            //Lấy danh sách công trình thuộc loại công trình và nhóm công trình
                            int k = 1;
                            listChiTiet_CongTrinh.Where(x => x.LoaiCongTrinhId == u.LoaiCongTrinhId && x.NhomCongTrinhId == n.NhomCongTrinhId).ToList().ForEach(h =>
                              {
                                  h.STT = k.ToString();
                                  h.IsBold = false;
                                  h.OrderIndex = order++;
                                  _moduleObject.Add(h);
                                  k++;
                              });
                            j++;
                        });
                    });
                }
                i++;
            });
            return _moduleObject;
        }

        private KeHoachVonNSTWChiTietDto GetGetDataChiTietForLoaiKhoan(KeHoachVonNSTWChiTietDto obj, int index)
        {
            string[] MyArray = new string[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII", "XII", "XIV", "XV", "XVI", "XVII", "XVIII", "XIX", "XX", "XXI", "XXII", "XXIII", "XXIV", "XXV", "XXVI" };
            obj.STT = MyArray[index].ToString().ToUpper();
            LoaiKhoanDto objLoaiKhoan = _listLoaiKhoan.Where(x => x.Id == obj.LoaiKhoanId).ToList().FirstOrDefault();
            if (objLoaiKhoan != null && objLoaiKhoan.Id != Guid.Empty)
            {
                obj.TenDanhMuc = objLoaiKhoan.TenLoaiKhoan;
            }
            GetValueColumnDynamic(obj);
            return obj;
        }

        private List<KeHoachVonNSTWChiTietDto> GetDataChiTietForCongTrinh(Guid loaiKhoanId, List<KeHoachVonNSTWChiTietDto> list)
        {
            if (list == null)
                list = new List<KeHoachVonNSTWChiTietDto>();
            list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiKhoanId == loaiKhoanId).ToList().OrderBy(x => x.OrderIndex).ToList().ForEach(o =>
            {
                CongTrinhDto objCongTrinh = _listCongTrinh.Where(x => x.Id == o.CongTrinhId).ToList().FirstOrDefault();
                if (objCongTrinh != null && objCongTrinh.Id != Guid.Empty)
                {
                    o.TenDanhMuc = objCongTrinh.TenCongTrinh;
                    o.MaSoDuAn = objCongTrinh.MaSoDuAn;
                    o.SoQuyetDinh = objCongTrinh.SoQuyetDinhDauTu;
                    o.LoaiCongTrinhId = objCongTrinh.LoaiCongTrinhId == null ? Guid.Empty : new Guid(objCongTrinh.LoaiCongTrinhId.ToString());
                    o.TongMucDauTu = objCongTrinh.TongMucDauTu == null ? 0 : Convert.ToDecimal(objCongTrinh.TongMucDauTu);
                    o.MucDauTuNSTW = objCongTrinh.NSTW == null ? 0 : Convert.ToDecimal(objCongTrinh.NSTW);
                    ChuDauTuDto objChuDauTu = _listChuDauTu.Where(x => x.Id == objCongTrinh.ChuDauTuId).FirstOrDefault();
                    if (objChuDauTu != null && objChuDauTu.Id != Guid.Empty)
                    {
                        o.MaSoChuong = objChuDauTu.MaSoChuong;
                        o.TenChuDauTu = objChuDauTu.Ten;
                    }

                    ChuongTrinhMucTieuQuocGiaDto objCTMT = _listCTMTQuocGia.Where(x => x.Id == objCongTrinh.CTMTQuocGiaId).FirstOrDefault();
                    if (objCTMT != null && objCTMT.Id != Guid.Empty)
                    {
                        o.MaChuongTrinh = objCTMT.MaChuongTrinhMucTieuQuocGia;
                    }
                    LoaiKhoanDto objLoaiKhoan = _listLoaiKhoan.Where(x => x.Id == objCongTrinh.LoaiKhoanId).ToList().FirstOrDefault();
                    if (objLoaiKhoan != null && objLoaiKhoan.Id != Guid.Empty)
                    {
                        o.MaLoaiKhoan = objLoaiKhoan.MaSo;
                    }
                    if (objCongTrinh.LoaiCongTrinhId != Guid.Empty && _listLoaiCongTrinh != null)
                    {
                        LoaiCongTrinhDto objLoaiCongTrinh = _listLoaiCongTrinh.Where(x => x.Id == objCongTrinh.LoaiCongTrinhId).ToList().FirstOrDefault();
                        if (objLoaiCongTrinh != null)
                        {
                            o.TenLoaiCongTrinh = objLoaiCongTrinh.TenLoaiCongTrinh;
                            o.LoaiCongTrinhId = objLoaiCongTrinh.Id;
                        }
                    }

                    if (objCongTrinh.NhomCongTrinhId != Guid.Empty && _listNhomCongTrinh != null)
                    {
                        NhomCongTrinhDto objNhomCongTrinh = _listNhomCongTrinh.Where(x => x.Id == objCongTrinh.NhomCongTrinhId).ToList().FirstOrDefault();
                        if (objNhomCongTrinh != null)
                        {
                            o.TenNhomCongTrinh = objNhomCongTrinh.TenNhomCongTrinh;
                            o.NhomCongTrinhId = objNhomCongTrinh.Id;
                        }
                    }
                }
                GetValueColumnDynamic(o);
            });
            return list;
        }

        private List<KeHoachVonNSTWChiTietDto> GetDataChiTietForLoaiCongTrinh(List<KeHoachVonNSTWChiTietDto> list)
        {
            List<KeHoachVonNSTWChiTietDto> listChiTiet_LoaiCongTrinh = new List<KeHoachVonNSTWChiTietDto>();
            list.Select(x => x.LoaiCongTrinhId).Distinct().ToList().ForEach(o =>
            {
                KeHoachVonNSTWChiTietDto obj = new KeHoachVonNSTWChiTietDto();
                obj.LoaiCongTrinhId = o;
                LoaiCongTrinhDto objLoaiCongTrinh = _listLoaiCongTrinh.Where(x => x.Id == o).ToList().FirstOrDefault();
                if (objLoaiCongTrinh != null && objLoaiCongTrinh.Id != Guid.Empty)
                {
                    obj.TenDanhMuc = objLoaiCongTrinh.TenLoaiCongTrinh;
                }
                obj.TongMucDauTu = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhId == o).ToList().Sum(x => x.TongMucDauTu);
                obj.MucDauTuNSTW = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhId == o).ToList().Sum(x => x.MucDauTuNSTW);
                obj.LuyKeVonTongCong = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhId == o).ToList().Sum(x => x.LuyKeVonTongCong);
                obj.LuyKeVonNamTruoc = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhId == o).ToList().Sum(x => x.LuyKeVonNamTruoc);
                obj.KeHoachVonDauNamDuocDuyet = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhId == o).ToList().Sum(x => x.KeHoachVonDauNamDuocDuyet);
                obj.DieuChinhGiam = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhId == o).ToList().Sum(x => x.DieuChinhGiam);
                obj.DieuChinhTang = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhId == o).ToList().Sum(x => x.DieuChinhTang);
                obj.KeHoachVonDieuChinh = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhId == o).ToList().Sum(x => x.KeHoachVonDieuChinh);
                obj.KeHoachVonDieuChinhDuocDuyet = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhId == o).ToList().Sum(x => x.KeHoachVonDieuChinhDuocDuyet);
                if (list[0].Value != null && list[0].Value.Count > 0)
                {
                    obj.Value = new Dictionary<string, decimal>();
                    List<string> keyValues = new List<string>(list[0].Value.Keys);
                    keyValues.ForEach(u =>
                    {
                        decimal giatri = list.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiCongTrinhId == o).ToList().Sum(r => r.Value.Where(x => x.Key == u).ToList().Sum(x => x.Value));
                        obj.Value.Add(u, giatri);
                    });
                }
                listChiTiet_LoaiCongTrinh.Add(obj);
            });
            return listChiTiet_LoaiCongTrinh;
        }

        private List<KeHoachVonNSTWChiTietDto> GetDataChiTietForNhomCongTrinh(Guid loaiKhoanId, Guid loaiCongTrinhId, List<KeHoachVonNSTWChiTietDto> list)
        {

            string[] MyArray = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            List<KeHoachVonNSTWChiTietDto> listChiTiet_NhomCongTrinh = new List<KeHoachVonNSTWChiTietDto>();
            int index = 0;
            var listGuiNhomCongTrinh = list.Where(x => x.LoaiKhoanId == loaiKhoanId && x.LoaiCongTrinhId == loaiCongTrinhId).OrderBy(x => x.TenNhomCongTrinh).Select(x => x.NhomCongTrinhId).Distinct();
            if (listGuiNhomCongTrinh != null)
                listGuiNhomCongTrinh.ToList().ForEach(o =>
                {
                    KeHoachVonNSTWChiTietDto obj = new KeHoachVonNSTWChiTietDto();
                    obj.NhomCongTrinhId = o;
                    obj.STT = MyArray[index].ToString();
                    NhomCongTrinhDto objNhomCongTrinh = _listNhomCongTrinh.Where(x => x.Id == o).ToList().FirstOrDefault();
                    if (objNhomCongTrinh != null && objNhomCongTrinh.Id != Guid.Empty)
                    {
                        obj.TenDanhMuc = objNhomCongTrinh.TenNhomCongTrinh;
                    }
                    obj.TongMucDauTu = list.Where(x => x.CongTrinhId != Guid.Empty && x.NhomCongTrinhId == o && x.LoaiCongTrinhId == loaiCongTrinhId && x.LoaiKhoanId == loaiKhoanId).ToList().Sum(x => x.TongMucDauTu);
                    obj.MucDauTuNSTW = list.Where(x => x.CongTrinhId != Guid.Empty && x.NhomCongTrinhId == o && x.LoaiCongTrinhId == loaiCongTrinhId && x.LoaiKhoanId == loaiKhoanId).ToList().Sum(x => x.MucDauTuNSTW);
                    obj.LuyKeVonTongCong = list.Where(x => x.CongTrinhId != Guid.Empty && x.NhomCongTrinhId == o && x.LoaiCongTrinhId == loaiCongTrinhId && x.LoaiKhoanId == loaiKhoanId).ToList().Sum(x => x.LuyKeVonTongCong);
                    obj.LuyKeVonNamTruoc = list.Where(x => x.CongTrinhId != Guid.Empty && x.NhomCongTrinhId == o && x.LoaiCongTrinhId == loaiCongTrinhId && x.LoaiKhoanId == loaiKhoanId).ToList().Sum(x => x.LuyKeVonNamTruoc);
                    obj.KeHoachVonDauNamDuocDuyet = list.Where(x => x.CongTrinhId != Guid.Empty && x.NhomCongTrinhId == o && x.LoaiCongTrinhId == loaiCongTrinhId && x.LoaiKhoanId == loaiKhoanId).ToList().Sum(x => x.KeHoachVonDauNamDuocDuyet);
                    obj.DieuChinhGiam = list.Where(x => x.CongTrinhId != Guid.Empty && x.NhomCongTrinhId == o && x.LoaiCongTrinhId == loaiCongTrinhId && x.LoaiKhoanId == loaiKhoanId).ToList().Sum(x => x.DieuChinhGiam);
                    obj.DieuChinhTang = list.Where(x => x.CongTrinhId != Guid.Empty && x.NhomCongTrinhId == o && x.LoaiCongTrinhId == loaiCongTrinhId && x.LoaiKhoanId == loaiKhoanId).ToList().Sum(x => x.DieuChinhTang);
                    obj.KeHoachVonDieuChinh = list.Where(x => x.CongTrinhId != Guid.Empty && x.NhomCongTrinhId == o && x.LoaiCongTrinhId == loaiCongTrinhId && x.LoaiKhoanId == loaiKhoanId).ToList().Sum(x => x.KeHoachVonDieuChinh);
                    obj.KeHoachVonDieuChinhDuocDuyet = list.Where(x => x.CongTrinhId != Guid.Empty && x.NhomCongTrinhId == o && x.LoaiCongTrinhId == loaiCongTrinhId && x.LoaiKhoanId == loaiKhoanId).ToList().Sum(x => x.KeHoachVonDieuChinhDuocDuyet);

                    if (list[0].Value != null && list[0].Value.Count > 0)
                    {
                        obj.Value = new Dictionary<string, decimal>();
                        List<string> keyValues = new List<string>(list[0].Value.Keys);
                        keyValues.ForEach(u =>
                        {
                            decimal giatri = list.Where(x => x.CongTrinhId != Guid.Empty && x.NhomCongTrinhId == o && x.LoaiCongTrinhId == loaiCongTrinhId && x.LoaiKhoanId == loaiKhoanId).ToList().Sum(r => r.Value.Where(x => x.Key == u).ToList().Sum(x => x.Value));
                            obj.Value.Add(u, giatri);
                        });
                    }
                    listChiTiet_NhomCongTrinh.Add(obj);
                    index++;
                });
            return listChiTiet_NhomCongTrinh;
        }

        private void GetValueColumnDynamic(KeHoachVonNSTWChiTietDto obj)
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

        public List<KeHoachVonNSTWChiTietDto> SetSumDetailReport(Dictionary<string, decimal> value)
        {
            List<KeHoachVonNSTWChiTietDto> sumObject = new List<KeHoachVonNSTWChiTietDto>();
            KeHoachVonNSTWChiTietDto obj = new KeHoachVonNSTWChiTietDto();
            obj.Value = value;
            obj.TongMucDauTu = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(x => x.TongMucDauTu);
            obj.MucDauTuNSTW = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(x => x.MucDauTuNSTW);
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

        private DataTable ConvertToDataTable(List<KeHoachVonNSTWChiTietDto> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(KeHoachVonNSTWChiTietDto));
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
            foreach (KeHoachVonNSTWChiTietDto item in data)
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
