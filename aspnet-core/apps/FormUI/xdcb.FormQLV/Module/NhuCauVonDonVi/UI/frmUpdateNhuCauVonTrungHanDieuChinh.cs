using System;
using System.Windows.Forms;
using xdcb.FormServices.Shared;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.SDK;
using xdcb.Common.DanhMuc.CongTrinhDtos;
using DevExpress.XtraSplashScreen;
using xdcb.FormServices.Component;
using xdcb.QuanLyVon.NhuCauKeHoachVonChiTiet.Dtos;
using xdcb.QuanLyVon.NhuCauKeHoachVon.Dtos;
using System.Collections.Generic;
using xdcb.Common.DanhMuc.LoaiCongTrinhDtos;

namespace xdcb.FormQLV.NhuCauVonDonVi
{
    public partial class frmUpdateNhuCauVonTrungHanDieuChinh : GGScreenDetail
    {
        public NhuCauKeHoachVonChiTietDto _moduleObject;
        public NhuCauKeHoachVonDto _mainObject;
        private List<LoaiCongTrinhDto> _listLoaiCongTrinh = new List<LoaiCongTrinhDto>();

        public frmUpdateNhuCauVonTrungHanDieuChinh(NhuCauKeHoachVonChiTietDto nhuCauKeHoachVonChiTietDto)
        {
            InitializeComponent();
            _moduleObject = nhuCauKeHoachVonChiTietDto;
            _mainObject = new NhuCauKeHoachVonDto();
            if (_moduleObject != null && _moduleObject.NhuCauKeHoachVonID != Guid.Empty)
            {
                var api = ConfigManager.GetAPIByService<INhuCauKeHoachVonsApi>();
                _mainObject = api.GetAsync(_moduleObject.NhuCauKeHoachVonID).GetAwaiter().GetResult();
            }
            GetValueControl();
            InitBindEntityToControl(this.Controls, _moduleObject);
            SetTextGroup(); ;
        }

        #region GetValueControl
        public void GetObjectControl()
        {
            if (_listLoaiCongTrinh != null)
                _listLoaiCongTrinh.Clear();
            var apiLoaiCongTrinh = ConfigManager.GetAPIByService<ILoaiCongTrinhsApi>();
            _listLoaiCongTrinh.Add(new LoaiCongTrinhDto());
            _listLoaiCongTrinh.AddRange(apiLoaiCongTrinh.GetAll().GetAwaiter().GetResult());
        }

        public void GetValueControl()
        {
            GetObjectControl();

            cbb_LoaiCongTrinh.ColumnsCaption = new string[2] { LoaiCongTrinhColumn.TenLoaiCongTrinh.GetDescription().ToString(), LoaiCongTrinhColumn.MaLoaiCongTrinh.GetDescription().ToString() };
            cbb_LoaiCongTrinh.FieldsName = new string[2] { LoaiCongTrinhColumn.TenLoaiCongTrinh.ToString(), LoaiCongTrinhColumn.MaLoaiCongTrinh.ToString() };
            cbb_LoaiCongTrinh.ValueMember = LoaiCongTrinhColumn.Id.ToString();
            cbb_LoaiCongTrinh.DisplayMember = LoaiCongTrinhColumn.TenLoaiCongTrinh.ToString();
            cbb_LoaiCongTrinh.DataSource = _listLoaiCongTrinh;
            cbb_LoaiCongTrinh.ShowData();
        }
        #endregion

        public void SetTextGroup()
        {
            box_LuyKeVon.Text += " " + (_mainObject.TuNam - 1).ToString();
            box_DeXuat.Text += ": " + _mainObject.GiaiDoanNam.ToString();
            box_KeHoachVon.Text += " " + _mainObject.GiaiDoanNam.ToString();
        }

        public void InitBindEntityToControl(Control.ControlCollection controls, NhuCauKeHoachVonChiTietDto obj)
        {
            foreach (Control ctrl in controls)
            {
                string dataMember = GetProperty.GetPropertyStringValue(ctrl, Customs.cstDataMember);
                if (ctrl.Controls != null && ctrl.Controls.Count > 0)
                {
                    InitBindEntityToControl(ctrl.Controls, obj);
                }
                if (!string.IsNullOrWhiteSpace(dataMember))
                {
                    try
                    {
                        ctrl.DataBindings.Clear();
                        if (ctrl.GetType().ToString() == ControlCustomTypeName.GGLabel.ToString())
                        {
                            ctrl.DataBindings.Add("Text", obj, dataMember, true, DataSourceUpdateMode.OnPropertyChanged);
                        }
                        else
                        {
                            ctrl.DataBindings.Add("EditValue", obj, dataMember, true,
                                                   DataSourceUpdateMode.OnPropertyChanged);
                        }
                    }
                    catch (Exception ex)
                    {
                        //
                    }
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Validated
        private void txt_DieuChinhGiamNTSDauNam_Validated(object sender, EventArgs e)
        {
            SetValueNhuCauTongTien();
        }
        private void txt_DieuChinhGiamNSTWDauNam_Validated(object sender, EventArgs e)
        {
            SetValueNhuCauTongTien();
        }
        private void txt_DieuChinhGiamODADauNam_Validated(object sender, EventArgs e)
        {
            SetValueNhuCauTongTien();
        }
        private void txt_DieuChinhTangNTSDauNam_Validated(object sender, EventArgs e)
        {
            SetValueNhuCauTongTien();
        }
        private void txt_DieuChinhTangNSTWDauNam_Validated(object sender, EventArgs e)
        {
            SetValueNhuCauTongTien();
        }
        private void txt_DieuChinhTangODADauNam_Validated(object sender, EventArgs e)
        {
            SetValueNhuCauTongTien();
        }
        public void SetValueNhuCauTongTien()
        {
            _moduleObject.DieuChinhGiamTongCong = _moduleObject.DieuChinhGiamNST + _moduleObject.DieuChinhGiamNSTW + _moduleObject.DieuChinhGiamODA;
            _moduleObject.DieuChinhTangTongCong = _moduleObject.DieuChinhTangNST + _moduleObject.DieuChinhTangNSTW + _moduleObject.DieuChinhTangODA;
            _moduleObject.NhuCauVonDieuChinhTongCong = _moduleObject.NhuCauVonDauNamTongCong - _moduleObject.DieuChinhGiamTongCong + _moduleObject.DieuChinhTangTongCong;
            InitBindEntityToControl(this.Controls, _moduleObject);
        }

        #endregion

        private void btn_Save_Click(object sender, EventArgs e)
        {
            var api = ConfigManager.GetAPIByService<INhuCauKeHoachVonsApi>();
            _mainObject = api.GetAsync(_moduleObject.NhuCauKeHoachVonID).GetAwaiter().GetResult();
            if (_mainObject.TrangThaiDieuChinh.ToLower().Trim() == TrangThaiKeHoachNhuCauVon.DA_CHOT.ToString().ToLower().Trim())
            {
                GGFunctions.ShowMessage("Dữ liệu đã được chốt số liệu nên không được lưu!");
                return;
            }
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);
            _moduleObject.NhuCauVonDieuChinhNST = _moduleObject.NhuCauVonDauNamNST - _moduleObject.DieuChinhGiamNST + _moduleObject.DieuChinhTangNST;
            _moduleObject.NhuCauVonDieuChinhNSTW = _moduleObject.NhuCauVonDauNamNSTW - _moduleObject.DieuChinhGiamNSTW + _moduleObject.DieuChinhTangNSTW;
            _moduleObject.NhuCauVonDieuChinhODA = _moduleObject.NhuCauVonDauNamODA - _moduleObject.DieuChinhGiamODA + _moduleObject.DieuChinhTangODA;
            // Luu Nhu Cau Von Chi Tiet
            var apiChiTiet = ConfigManager.GetAPIByService<INhuCauKeHoachVonChiTietsApi>();
            var resultChiTiet = GGMapper<NhuCauKeHoachVonChiTietDto, CreateUpdateNhuCauKeHoachVonChiTietDto>.MapSimple(_moduleObject);
            apiChiTiet.Update(_moduleObject.Id, resultChiTiet).GetAwaiter().GetResult();

            // Luu Nhu Cau Von
            NhuCauKeHoachVonChiTietDto objSumValue = apiChiTiet.GetDataSumValueByNhuCauVonID(_moduleObject.NhuCauKeHoachVonID).GetAwaiter().GetResult();
            if (objSumValue != null && objSumValue.NhuCauKeHoachVonID != Guid.Empty)
            {
                _mainObject.TongNhuCauVonDieuChinh = objSumValue.NhuCauVonDieuChinhTongCong;
                var result = GGMapper<NhuCauKeHoachVonDto, CreateUpdateNhuCauKeHoachVonDto>.MapSimple(_mainObject);
                api.Update(_mainObject.Id, result).GetAwaiter().GetResult();
            }

            //Cap nhat loai cong trinh
            UpdateDanhMucCongTrinh();

            SplashScreenManager.CloseForm();
            this.Close();
        }
        private void UpdateDanhMucCongTrinh()
        {
            var api = ConfigManager.GetAPIByService<ICongTrinhsApi>();
            if (_moduleObject.CongTrinhID != Guid.Empty)
            {
                CongTrinhDto objCongTrinh = api.GetAsync(_moduleObject.CongTrinhID).GetAwaiter().GetResult();
                if (objCongTrinh != null && objCongTrinh.Id != Guid.Empty)
                {
                    var result = GGMapper<CongTrinhDto, CreateUpdateCongTrinhDto>.MapSimple(objCongTrinh);
                    result.LoaiCongTrinhId = _moduleObject.LoaiCongTrinhId;
                    api.Update(objCongTrinh.Id, result).GetAwaiter().GetResult();
                }
            }
        }


    }
}