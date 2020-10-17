using DevExpress.XtraSplashScreen;
using Localization;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using xdcb.Common.DanhMuc.ChuDauTuDtos;
using xdcb.Common.DanhMuc.CongTrinhDtos;
using xdcb.Common.DanhMuc.LoaiCongTrinhDtos;
using xdcb.Common.DanhMuc.LoaiKhoanDtos;
using xdcb.Common.DanhMuc.NhomCongTrinhDtos;
using xdcb.FormQLV.NhuCauVonDonVi;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Component;
using xdcb.FormServices.SDK;
using xdcb.FormServices.Shared;
using xdcb.QuanLyVon.NhuCauKeHoachVon.Dtos;
using xdcb.QuanLyVon.NhuCauKeHoachVonChiTiet.Dtos;

namespace xdcb.FormQLV.NhuCauVonHangNam
{
    public class NhuCauVonHangNamModule : BaseModule
    {
        #region Property
        public NhuCauKeHoachVonDto _mainObject = new NhuCauKeHoachVonDto();
        public List<NhuCauKeHoachVonChiTietDto> _moduleObject = new List<NhuCauKeHoachVonChiTietDto>();

        public List<CongTrinhDto> _listCongTrinh = new List<CongTrinhDto>();
        public List<ChuDauTuDto> _listChuDauTu = new List<ChuDauTuDto>();
        public List<LoaiKhoanDto> _listLoaiKhoan = new List<LoaiKhoanDto>();
        public List<LoaiCongTrinhDto> _listLoaiCongTrinh = new List<LoaiCongTrinhDto>();
        #endregion
        public NhuCauVonHangNamModule()
        {
            Name = ModuleName.NhuCauVonHangNam.ToString();
            frmNhuCauVonDonVi frm = new frmNhuCauVonDonVi(DateTime.Now.Year.ToString(), LoaiKeHoachNhuCauVon.DAU_NAM.ToString(), KeHoachNhuCauVon.HANG_NAM.ToString());
            frm.Text = ModuleName.NhuCauVonHangNam.GetDescription();
            UIMainForm = frm;
            InitializeModule();
        }

        public NhuCauVonHangNamModule(int nam, string loaikehoach, string tenkehoach, Guid congTrinhId, Guid chuDauTuid)
        {
            GetObjectControl();
            GetDataNhuCauVon(nam, loaikehoach, tenkehoach, congTrinhId, chuDauTuid);
        }

        #region GetObject
        public void GetObjectControl()
        {
            if (_listChuDauTu != null)
                _listChuDauTu.Clear();
            if (_listCongTrinh != null)
                _listCongTrinh.Clear();
            if (_listLoaiKhoan != null)
                _listLoaiKhoan.Clear();
            if (_listLoaiCongTrinh != null)
                _listLoaiCongTrinh.Clear();

            var apiChuDauTu = ConfigManager.GetAPIByService<IChuDauTusApi>();
            _listChuDauTu = apiChuDauTu.GetAll().GetAwaiter().GetResult();

            var apiCongTrinh = ConfigManager.GetAPIByService<ICongTrinhsApi>();
            _listCongTrinh = apiCongTrinh.GetListNotPageAsync().GetAwaiter().GetResult();

            var apiLoaiKhoan = ConfigManager.GetAPIByService<ILoaiKhoansApi>();
            _listLoaiKhoan = apiLoaiKhoan.GetAll().GetAwaiter().GetResult();

            var apiLoaiCongTrinh = ConfigManager.GetAPIByService<ILoaiCongTrinhsApi>();
            _listLoaiCongTrinh = apiLoaiCongTrinh.GetAll().GetAwaiter().GetResult();
        }

        private void GetDataNhuCauVon(int nam, string loaikehoach, string tenkehoach, Guid congTrinhId, Guid chuDauTuid)
        {
            var api = ConfigManager.GetAPIByService<INhuCauKeHoachVonsApi>();
            var dataChung = api.GetSearchData(nam, loaikehoach, tenkehoach, chuDauTuid).GetAwaiter().GetResult();
            if (dataChung != null && dataChung.Count > 0)
            {
                _mainObject = dataChung.FirstOrDefault();
                var listGuid = dataChung.Where(x => x.TrangThai.ToLower().Trim() != TrangThaiKeHoachNhuCauVon.DANG_SOAN.ToString().ToLower().Trim()).Select(x => x.Id).Distinct();
                if (listGuid != null)
                {

                    var apiChiTiet = ConfigManager.GetAPIByService<INhuCauKeHoachVonChiTietsApi>();
                    var listChiTiet = apiChiTiet.GetListDataByNhuCauVonIDAndCongTrinh(listGuid.ToList(), congTrinhId).GetAwaiter().GetResult();
                    if (listChiTiet != null && listChiTiet.Count > 0)
                    {
                        if (loaikehoach.ToString().ToLower().Trim() == LoaiKeHoachNhuCauVon.DAU_NAM.ToString().ToLower().Trim())
                        {
                            listChiTiet = listChiTiet.Where(x => x.IsSelectDieuChinh == false).ToList();
                        }
                        else if (loaikehoach.ToString().ToLower().Trim() == LoaiKeHoachNhuCauVon.DIEU_CHINH.ToString().ToLower().Trim())
                        {
                            listChiTiet = listChiTiet.Where(x => x.IsDeleteDieuChinh == false).ToList();
                        }
                        listChiTiet = listChiTiet.OrderBy(x => x.OrderIndex).ToList();

                        listChiTiet.ForEach(o =>
                        {
                            NhuCauKeHoachVonDto objNhuCauVon = dataChung.Where(x => x.Id == o.NhuCauKeHoachVonID).ToList().FirstOrDefault();
                            CongTrinhDto objCongTrinh = _listCongTrinh.Where(x => x.Id == o.CongTrinhID).ToList().FirstOrDefault();
                            if (objNhuCauVon != null && objCongTrinh != null && objCongTrinh.Id != Guid.Empty)
                            {
                                o.MaCongTrinh = objCongTrinh.MaCongTrinh;
                                o.MaSoDuAn = objCongTrinh.MaSoDuAn;
                                o.TenCongTrinh = objCongTrinh.TenCongTrinh;
                                o.TenDanhMuc = objCongTrinh.TenCongTrinh;
                                o.SoQuyetDinh = objCongTrinh.SoQuyetDinhDauTu;
                                o.NgayBanHanh = objCongTrinh.NgayQuyetDinhDauTu;
                                o.LoaiCongTrinhId = objCongTrinh.LoaiCongTrinhId == null ? Guid.Empty : new Guid(objCongTrinh.LoaiCongTrinhId.ToString());
                                o.TongMucDauTu = objCongTrinh.TongMucDauTu == null ? 0 : Convert.ToDecimal(objCongTrinh.TongMucDauTu);
                                o.MucDauTuNST = objCongTrinh.NST == null ? 0 : Convert.ToDecimal(objCongTrinh.NST);
                                o.MucDauTuNSTW = objCongTrinh.NSTW == null ? 0 : Convert.ToDecimal(objCongTrinh.NSTW);
                                o.MucDauTuODA = objCongTrinh.ODA == null ? 0 : Convert.ToDecimal(objCongTrinh.ODA);
                                o.NhuCauVonDauNamTongCong = o.NhuCauVonDauNamNST + o.NhuCauVonDauNamNSTW + o.NhuCauVonDauNamODA;
                                o.NhuCauVonDieuChinhTongCong = o.NhuCauVonDieuChinhNST + o.NhuCauVonDieuChinhNSTW + o.NhuCauVonDieuChinhODA;
                                o.DieuChinhGiamTongCong = o.DieuChinhGiamNST + o.DieuChinhGiamNSTW + o.DieuChinhGiamODA;
                                o.DieuChinhTangTongCong = o.DieuChinhTangNST + o.DieuChinhTangNSTW + o.DieuChinhTangODA;
                                o.LuyKeVonNamTruocTongCong = o.LuyKeVonNamTruocNST + o.LuyKeVonNamTruocNSTW + o.LuyKeVonNamTruocODA;
                                o.LuyKeKhoiLuongNamTruocTongCong = o.LuyKeKhoiLuongNamTruocNST + o.LuyKeKhoiLuongNamTruocNSTW + o.LuyKeKhoiLuongNamTruocODA;
                                ChuDauTuDto objChuDauTu = _listChuDauTu.Where(x => x.Id == objNhuCauVon.ChuDauTuID).ToList().FirstOrDefault();
                                if (objChuDauTu != null && objChuDauTu.Id != Guid.Empty)
                                {
                                    o.MaSoChuong = objChuDauTu.MaSoChuong;
                                    o.TenChuDauTu = objChuDauTu.Ten;
                                    o.ChuDauTuID = objChuDauTu.Id;
                                }
                                LoaiKhoanDto objLoaiKhoan = _listLoaiKhoan.Where(x => x.Id == objCongTrinh.LoaiKhoanId).ToList().FirstOrDefault();
                                if (objLoaiKhoan != null && objLoaiKhoan.Id != Guid.Empty)
                                {
                                    o.MaLoaiKhoan = objLoaiKhoan.MaSo;
                                    o.TenLoaiKhoan = objLoaiKhoan.TenLoaiKhoan;
                                    o.LoaiKhoanId = objLoaiKhoan.Id;
                                }

                                LoaiCongTrinhDto objLoaiCongTrinh = _listLoaiCongTrinh.Where(x => x.Id == objCongTrinh.LoaiCongTrinhId).ToList().FirstOrDefault();
                                if (objLoaiCongTrinh != null && objLoaiCongTrinh.Id != Guid.Empty)
                                {
                                    o.MaLoaiKhoan = objLoaiKhoan.MaSo;
                                    o.TenLoaiKhoan = objLoaiKhoan.TenLoaiKhoan;
                                    o.LoaiKhoanId = objLoaiKhoan.Id;
                                }
                            }
                        });
                        int i = 0;
                        int order = 1;
                        //Lấy danh sách loại khoản
                        listChiTiet.Select(x => x.LoaiKhoanId).Distinct().ToList().ForEach(o =>
                          {
                              //Lấy danh sách công trình thuộc loại khoản
                              var listChiTiet_CongTrinh = listChiTiet.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiKhoanId == o).ToList().OrderBy(x => x.OrderIndex).ToList();

                              NhuCauKeHoachVonChiTietDto objLoaiKhoan = new NhuCauKeHoachVonChiTietDto();
                              objLoaiKhoan.LoaiKhoanId = o;
                              GetGetDataChiTietForLoaiKhoan(objLoaiKhoan, i, listChiTiet_CongTrinh);
                              objLoaiKhoan.IsBold = true;
                              _moduleObject.Add(objLoaiKhoan);

                              //Danh sách loại công trình thuộc loại khoản
                              var listChiTiet_LoaiCongTrinh = GetDataChiTietForLoaiCongTrinh(listChiTiet_CongTrinh);
                              if (listChiTiet_LoaiCongTrinh != null && listChiTiet_LoaiCongTrinh.Count > 0)
                              {
                                  int j = 1;
                                  listChiTiet_LoaiCongTrinh.ForEach(u =>
                                  {
                                      u.SoThuTu = string.Format("{0}.{1}", objLoaiKhoan.SoThuTu, j);
                                      u.IsBold = true;
                                      u.OrderIndex = order++;
                                      _moduleObject.Add(u);
                                      //Lấy danh sách công trình thuộc loại công trình và nhóm công trình
                                      int k = 1;
                                      listChiTiet_CongTrinh.Where(x => x.LoaiCongTrinhId == u.LoaiCongTrinhId).ToList().ForEach(h =>
                                      {
                                          h.SoThuTu = k.ToString();
                                          h.IsBold = false;
                                          h.OrderIndex = order++;
                                          _moduleObject.Add(h);
                                          k++;
                                      });
                                  });
                              }
                              i++;
                          });
                    }
                }
            }
        }

        private NhuCauKeHoachVonChiTietDto GetGetDataChiTietForLoaiKhoan(NhuCauKeHoachVonChiTietDto obj, int index, List<NhuCauKeHoachVonChiTietDto> list)
        {
            string[] MyArray = new string[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII", "XII", "XIV", "XV", "XVI", "XVII", "XVIII", "XIX", "XX", "XXI", "XXII", "XXIII", "XXIV", "XXV", "XXVI" };
            obj.SoThuTu = MyArray[index].ToString().ToUpper();
            LoaiKhoanDto objLoaiKhoan = _listLoaiKhoan.Where(x => x.Id == obj.LoaiKhoanId).ToList().FirstOrDefault();
            if (objLoaiKhoan != null && objLoaiKhoan.Id != Guid.Empty)
            {
                obj.MaLoaiKhoan = objLoaiKhoan.MaSo;
                obj.TenLoaiKhoan = objLoaiKhoan.TenLoaiKhoan;
                obj.LoaiKhoanId = objLoaiKhoan.Id;
                obj.TenDanhMuc = objLoaiKhoan.TenLoaiKhoan;
            }
            obj.TongMucDauTu = list.Sum(x => x.TongMucDauTu);
            obj.MucDauTuNST = list.Sum(x => x.MucDauTuNST);
            obj.MucDauTuNSTW = list.Sum(x => x.MucDauTuNSTW);
            obj.MucDauTuODA = list.Sum(x => x.MucDauTuODA);
            obj.NhuCauVonDauNamNST = list.Sum(x => x.NhuCauVonDauNamNST);
            obj.NhuCauVonDauNamNSTW = list.Sum(x => x.NhuCauVonDauNamNSTW);
            obj.NhuCauVonDauNamODA = list.Sum(x => x.NhuCauVonDauNamODA);
            obj.NhuCauVonDieuChinhNST = list.Sum(x => x.NhuCauVonDieuChinhNST);
            obj.NhuCauVonDieuChinhNSTW = list.Sum(x => x.NhuCauVonDieuChinhNSTW);
            obj.NhuCauVonDieuChinhODA = list.Sum(x => x.NhuCauVonDieuChinhODA);
            obj.DieuChinhGiamNST = list.Sum(x => x.DieuChinhGiamNST);
            obj.DieuChinhGiamNSTW = list.Sum(x => x.DieuChinhGiamNSTW);
            obj.DieuChinhGiamODA = list.Sum(x => x.DieuChinhGiamODA);
            obj.DieuChinhTangNST = list.Sum(x => x.DieuChinhTangNST);
            obj.DieuChinhTangNSTW = list.Sum(x => x.DieuChinhTangNSTW);
            obj.DieuChinhTangODA = list.Sum(x => x.DieuChinhTangODA);
            obj.LuyKeVonNamTruocNST = list.Sum(x => x.LuyKeVonNamTruocNST);
            obj.LuyKeVonNamTruocNSTW = list.Sum(x => x.LuyKeVonNamTruocNSTW);
            obj.LuyKeVonNamTruocODA = list.Sum(x => x.LuyKeVonNamTruocODA);
            obj.LuyKeKhoiLuongNamTruocNST = list.Sum(x => x.LuyKeKhoiLuongNamTruocNST);
            obj.LuyKeKhoiLuongNamTruocNSTW = list.Sum(x => x.LuyKeKhoiLuongNamTruocNSTW);
            obj.LuyKeKhoiLuongNamTruocODA = list.Sum(x => x.LuyKeKhoiLuongNamTruocODA);
            obj.NhuCauVonDauNamTongCong = list.Sum(x => x.NhuCauVonDauNamTongCong);
            obj.NhuCauVonDieuChinhTongCong = list.Sum(x => x.NhuCauVonDieuChinhTongCong);
            obj.DieuChinhGiamTongCong = list.Sum(x => x.DieuChinhGiamTongCong);
            obj.DieuChinhTangTongCong = list.Sum(x => x.DieuChinhTangTongCong);
            obj.LuyKeVonNamTruocTongCong = list.Sum(x => x.LuyKeVonNamTruocTongCong);
            obj.LuyKeKhoiLuongNamTruocTongCong = list.Sum(x => x.LuyKeKhoiLuongNamTruocTongCong);
            return obj;
        }

        private List<NhuCauKeHoachVonChiTietDto> GetDataChiTietForLoaiCongTrinh(List<NhuCauKeHoachVonChiTietDto> list)
        {
            List<NhuCauKeHoachVonChiTietDto> listChiTiet_LoaiCongTrinh = new List<NhuCauKeHoachVonChiTietDto>();
            list.Select(x => x.LoaiCongTrinhId).Distinct().ToList().ForEach(o =>
            {
                NhuCauKeHoachVonChiTietDto obj = new NhuCauKeHoachVonChiTietDto();
                obj.LoaiCongTrinhId = o;
                LoaiCongTrinhDto objLoaiCongTrinh = _listLoaiCongTrinh.Where(x => x.Id == o).ToList().FirstOrDefault();
                if (objLoaiCongTrinh != null && objLoaiCongTrinh.Id != Guid.Empty)
                {
                    obj.TenDanhMuc = objLoaiCongTrinh.TenLoaiCongTrinh;
                }
                obj.TongMucDauTu = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.TongMucDauTu);
                obj.MucDauTuNST = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.MucDauTuNST);
                obj.MucDauTuNSTW = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.MucDauTuNSTW);
                obj.MucDauTuODA = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.MucDauTuODA);
                obj.NhuCauVonDauNamNST = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.NhuCauVonDauNamNST);
                obj.NhuCauVonDauNamNSTW = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.NhuCauVonDauNamNSTW);
                obj.NhuCauVonDauNamODA = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.NhuCauVonDauNamODA);
                obj.NhuCauVonDieuChinhNST = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.NhuCauVonDieuChinhNST);
                obj.NhuCauVonDieuChinhNSTW = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.NhuCauVonDieuChinhNSTW);
                obj.NhuCauVonDieuChinhODA = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.NhuCauVonDieuChinhODA);
                obj.DieuChinhGiamNST = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.DieuChinhGiamNST);
                obj.DieuChinhGiamNSTW = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.DieuChinhGiamNSTW);
                obj.DieuChinhGiamODA = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.DieuChinhGiamODA);
                obj.DieuChinhTangNST = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.DieuChinhTangNST);
                obj.DieuChinhTangNSTW = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.DieuChinhTangNSTW);
                obj.DieuChinhTangODA = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.DieuChinhTangODA);
                obj.LuyKeVonNamTruocNST = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.LuyKeVonNamTruocNST);
                obj.LuyKeVonNamTruocNSTW = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.LuyKeVonNamTruocNSTW);
                obj.LuyKeVonNamTruocODA = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.LuyKeVonNamTruocODA);
                obj.LuyKeKhoiLuongNamTruocNST = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.LuyKeKhoiLuongNamTruocNST);
                obj.LuyKeKhoiLuongNamTruocNSTW = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.LuyKeKhoiLuongNamTruocNSTW);
                obj.LuyKeKhoiLuongNamTruocODA = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.LuyKeKhoiLuongNamTruocODA);
                obj.NhuCauVonDauNamTongCong = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.NhuCauVonDauNamTongCong);
                obj.NhuCauVonDieuChinhTongCong = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.NhuCauVonDieuChinhTongCong);
                obj.DieuChinhGiamTongCong = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.DieuChinhGiamTongCong);
                obj.DieuChinhTangTongCong = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.DieuChinhTangTongCong);
                obj.LuyKeVonNamTruocTongCong = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.LuyKeVonNamTruocTongCong);
                obj.LuyKeKhoiLuongNamTruocTongCong = list.Where(x => x.CongTrinhID != Guid.Empty && x.LoaiCongTrinhId == o).Sum(x => x.LuyKeKhoiLuongNamTruocTongCong);
                listChiTiet_LoaiCongTrinh.Add(obj);
            });
            return listChiTiet_LoaiCongTrinh;
        }
        #endregion

        #region Export Excel
        public void ExportExcel()
        {
            if (_mainObject != null && _mainObject.Id != Guid.Empty)
            {
                string path = ConfigManager.PathTemplate();
                if (_mainObject.TenKeHoach == KeHoachNhuCauVon.HANG_NAM.ToString())
                {
                    if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
                    {
                        ExportExcel_HangNam_DauNam(path);
                    }
                    else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
                    {
                        ExportExcel_HangNam_DieuChinh(path);
                    }
                }
                else if (_mainObject.TenKeHoach == KeHoachNhuCauVon.TRUNG_HAN.ToString())
                {
                    if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
                    {
                        ExportExcel_TrungHan_DauNam(path);
                    }
                    else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
                    {
                        ExportExcel_TrungHan_DieuChinh(path);
                    }
                }


            }
            else
            {
                GGFunctions.ShowMessage("Không có dữ liệu để xuất file, Vui lòng kiểm tra lại!");
            }
        }

        public bool ExportExcel_HangNam_DauNam(string path)
        {
            bool isExport = true;
            string temFilePath = GGFunctions.GetResultPath(path, ModuleName.NhuCauVonHangNam.ToString(), TemplateExel.NhuCauKeHoachVonHangNam_DauNam.ToString());
            if (string.IsNullOrWhiteSpace(temFilePath))
            {
                GGFunctions.ShowMessage("Không có mẫu để xuất file. Vui lòng kiểm tra lại");
                isExport = false;
                return isExport;
            }
            string newFilePath = GGFunctions.GetShowFile(string.Format(FormQLVLocalizedResources.nhucaukehoachvonhangnamdaunam, _mainObject.GiaiDoanNam.ToString()), temFilePath);
            if (string.IsNullOrWhiteSpace(newFilePath))
            {
                isExport = false;
                return isExport;
            }
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);
            List<NhuCauKeHoachVonChiTietDto> listdetail = _moduleObject;
            DataTable dtHeader = GGFunctions.ConvertToDataTable<NhuCauKeHoachVonDto>(SetValueHeaderReport());
            DataTable dtDetail = GGFunctions.ConvertToDataTable(listdetail);
            DataTable dtSumDetail = GGFunctions.ConvertToDataTable(SetSumDetailReport());

            ExcelExport.ExportWithTemplate(temFilePath, newFilePath, null, dtHeader, dtDetail, dtSumDetail, 1, 1);
            ExcelExport.ExportWithTemplate(temFilePath, newFilePath, null, dtHeader, dtDetail, dtSumDetail, 2, 1);
            SplashScreenManager.CloseForm();
            if (File.Exists(newFilePath))
            {
                GGFunctions.StartProcess(newFilePath);
            }
            dtHeader.Dispose();
            dtDetail.Dispose();
            dtSumDetail.Dispose();
            return isExport;

        }

        public bool ExportExcel_HangNam_DieuChinh(string path)
        {
            bool isExport = true;
            string temFilePath = GGFunctions.GetResultPath(path, ModuleName.NhuCauVonHangNam.ToString(), TemplateExel.NhuCauKeHoachVonHangNam_DieuChinh.ToString());
            if (string.IsNullOrWhiteSpace(temFilePath))
            {
                GGFunctions.ShowMessage("Không có mẫu để xuất file. Vui lòng kiểm tra lại");
                isExport = false;
                return isExport;
            }
            string newFilePath = GGFunctions.GetShowFile(string.Format(FormQLVLocalizedResources.nhucaukehoachvonhangnamdieuchinh, _mainObject.GiaiDoanNam.ToString()), temFilePath);
            if (string.IsNullOrWhiteSpace(newFilePath))
            {
                isExport = false;
                return isExport;
            }
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);
            List<NhuCauKeHoachVonChiTietDto> listdetail = _moduleObject;
            DataTable dtHeader = GGFunctions.ConvertToDataTable<NhuCauKeHoachVonDto>(SetValueHeaderReport());
            DataTable dtDetail = GGFunctions.ConvertToDataTable(listdetail);
            DataTable dtSumDetail = GGFunctions.ConvertToDataTable(SetSumDetailReport());

            ExcelExport.ExportWithTemplate(temFilePath, newFilePath, null, dtHeader, dtDetail, dtSumDetail, 1, 1);
            ExcelExport.ExportWithTemplate(temFilePath, newFilePath, null, dtHeader, dtDetail, dtSumDetail, 2, 1);
            SplashScreenManager.CloseForm();
            if (File.Exists(newFilePath))
            {
                GGFunctions.StartProcess(newFilePath);
            }
            dtHeader.Dispose();
            dtDetail.Dispose();
            dtSumDetail.Dispose();
            return isExport;

        }

        public bool ExportExcel_TrungHan_DauNam(string path)
        {
            bool isExport = true;
            string temFilePath = GGFunctions.GetResultPath(path, ModuleName.NhuCauVonTrungHan.ToString(), TemplateExel.NhuCauKeHoachVonTrungHan_DauNam.ToString());
            if (string.IsNullOrWhiteSpace(temFilePath))
            {
                GGFunctions.ShowMessage("Không có mẫu để xuất file. Vui lòng kiểm tra lại");
                isExport = false;
                return isExport;
            }
            string newFilePath = GGFunctions.GetShowFile(string.Format(FormQLVLocalizedResources.nhucaukehoachvontrunghandaunam, _mainObject.GiaiDoanNam.ToString()), temFilePath);
            if (string.IsNullOrWhiteSpace(newFilePath))
            {
                isExport = false;
                return isExport;
            }
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);
            List<NhuCauKeHoachVonChiTietDto> listdetail = _moduleObject;
            DataTable dtHeader = GGFunctions.ConvertToDataTable<NhuCauKeHoachVonDto>(SetValueHeaderReport());
            DataTable dtDetail = GGFunctions.ConvertToDataTable(listdetail);
            DataTable dtSumDetail = GGFunctions.ConvertToDataTable(SetSumDetailReport());

            ExcelExport.ExportWithTemplate(temFilePath, newFilePath, null, dtHeader, dtDetail, dtSumDetail, 1, 1);
            ExcelExport.ExportWithTemplate(temFilePath, newFilePath, null, dtHeader, dtDetail, dtSumDetail, 2, 1);
            SplashScreenManager.CloseForm();
            if (File.Exists(newFilePath))
            {
                GGFunctions.StartProcess(newFilePath);
            }
            dtHeader.Dispose();
            dtDetail.Dispose();
            dtSumDetail.Dispose();
            return isExport;

        }

        public bool ExportExcel_TrungHan_DieuChinh(string path)
        {
            bool isExport = true;
            string temFilePath = GGFunctions.GetResultPath(path, ModuleName.NhuCauVonTrungHan.ToString(), TemplateExel.NhuCauKeHoachVonTrungHan_DieuChinh.ToString());
            if (string.IsNullOrWhiteSpace(temFilePath))
            {
                GGFunctions.ShowMessage("Không có mẫu để xuất file. Vui lòng kiểm tra lại");
                isExport = false;
                return isExport;
            }
            string newFilePath = GGFunctions.GetShowFile(string.Format(FormQLVLocalizedResources.nhucaukehoachvontrunghandieuchinh, _mainObject.GiaiDoanNam.ToString()), temFilePath);
            if (string.IsNullOrWhiteSpace(newFilePath))
            {
                isExport = false;
                return isExport;
            }
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);
            List<NhuCauKeHoachVonChiTietDto> listdetail = _moduleObject;
            DataTable dtHeader = GGFunctions.ConvertToDataTable<NhuCauKeHoachVonDto>(SetValueHeaderReport());
            DataTable dtDetail = GGFunctions.ConvertToDataTable(listdetail);
            DataTable dtSumDetail = GGFunctions.ConvertToDataTable(SetSumDetailReport());

            ExcelExport.ExportWithTemplate(temFilePath, newFilePath, null, dtHeader, dtDetail, dtSumDetail, 1, 1);
            ExcelExport.ExportWithTemplate(temFilePath, newFilePath, null, dtHeader, dtDetail, dtSumDetail, 2, 1);
            SplashScreenManager.CloseForm();
            if (File.Exists(newFilePath))
            {
                GGFunctions.StartProcess(newFilePath);
            }
            dtHeader.Dispose();
            dtDetail.Dispose();
            dtSumDetail.Dispose();
            return isExport;

        }

        public List<NhuCauKeHoachVonDto> SetValueHeaderReport()
        {
            List<NhuCauKeHoachVonDto> listHead = new List<NhuCauKeHoachVonDto>();
            listHead.Add(_mainObject);
            return listHead;
        }

        public List<NhuCauKeHoachVonChiTietDto> SetSumDetailReport()
        {
            List<NhuCauKeHoachVonChiTietDto> sumObject = new List<NhuCauKeHoachVonChiTietDto>();
            NhuCauKeHoachVonChiTietDto obj = new NhuCauKeHoachVonChiTietDto();
            obj.TongMucDauTu = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.TongMucDauTu);
            obj.MucDauTuNST = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.MucDauTuNST);
            obj.MucDauTuNSTW = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.MucDauTuNSTW);
            obj.MucDauTuODA = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.MucDauTuODA);
            obj.NhuCauVonDauNamNST = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.NhuCauVonDauNamNST);
            obj.NhuCauVonDauNamNSTW = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.NhuCauVonDauNamNSTW);
            obj.NhuCauVonDauNamODA = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.NhuCauVonDauNamODA);
            obj.NhuCauVonDieuChinhNST = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.NhuCauVonDieuChinhNST);
            obj.NhuCauVonDieuChinhNSTW = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.NhuCauVonDieuChinhNSTW);
            obj.NhuCauVonDieuChinhODA = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.NhuCauVonDieuChinhODA);
            obj.DieuChinhGiamNST = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.DieuChinhGiamNST);
            obj.DieuChinhGiamNSTW = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.DieuChinhGiamNSTW);
            obj.DieuChinhGiamODA = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.DieuChinhGiamODA);
            obj.DieuChinhTangNST = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.DieuChinhTangNST);
            obj.DieuChinhTangNSTW = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.DieuChinhTangNSTW);
            obj.DieuChinhTangODA = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.DieuChinhTangODA);
            obj.LuyKeVonNamTruocNST = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.LuyKeVonNamTruocNST);
            obj.LuyKeVonNamTruocNSTW = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.LuyKeVonNamTruocNSTW);
            obj.LuyKeVonNamTruocODA = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.LuyKeVonNamTruocODA);
            obj.LuyKeKhoiLuongNamTruocNST = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.LuyKeKhoiLuongNamTruocNST);
            obj.LuyKeKhoiLuongNamTruocNSTW = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.LuyKeKhoiLuongNamTruocNSTW);
            obj.LuyKeKhoiLuongNamTruocODA = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.LuyKeKhoiLuongNamTruocODA);
            obj.NhuCauVonDauNamTongCong = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.NhuCauVonDauNamTongCong);
            obj.NhuCauVonDieuChinhTongCong = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.NhuCauVonDieuChinhTongCong);
            obj.DieuChinhGiamTongCong = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.DieuChinhGiamTongCong);
            obj.DieuChinhTangTongCong = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.DieuChinhTangTongCong);
            obj.LuyKeVonNamTruocTongCong = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.LuyKeVonNamTruocTongCong);
            obj.LuyKeKhoiLuongNamTruocTongCong = _moduleObject.Where(x => x.CongTrinhID != Guid.Empty).ToList().Sum(x => x.LuyKeKhoiLuongNamTruocTongCong);
            obj.IsBold = true;
            sumObject.Add(obj);
            return sumObject;
        }
        #endregion
    }
}
