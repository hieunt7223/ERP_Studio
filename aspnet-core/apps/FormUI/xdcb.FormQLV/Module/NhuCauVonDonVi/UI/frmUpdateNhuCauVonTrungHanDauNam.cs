using System;
using System.Windows.Forms;
using xdcb.FormServices.Shared;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.SDK;
using DevExpress.XtraSplashScreen;
using xdcb.FormServices.Component;
using xdcb.QuanLyVon.NhuCauKeHoachVonChiTiet.Dtos;
using xdcb.QuanLyVon.NhuCauKeHoachVon.Dtos;
using xdcb.Common.DanhMuc.LoaiCongTrinhDtos;
using System.Collections.Generic;
using xdcb.Common.DanhMuc.CongTrinhDtos;

namespace xdcb.FormQLV.NhuCauVonDonVi
{
    public partial class frmUpdateNhuCauVonTrungHanDauNam : GGScreenDetail
    {
        private NhuCauKeHoachVonChiTietDto _moduleObject;
        private NhuCauKeHoachVonDto _mainObject;
        private List<LoaiCongTrinhDto> _listLoaiCongTrinh = new List<LoaiCongTrinhDto>();
        public frmUpdateNhuCauVonTrungHanDauNam(NhuCauKeHoachVonChiTietDto nhuCauKeHoachVonChiTietDto)
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
            gcl_vontrunghan.Text += ": " + _mainObject.GiaiDoanNam.ToString();
            box_LuyKeVon.Text += " " + (_mainObject.TuNam - 1).ToString();
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
        private void txt_NhuCauNST_Validated(object sender, EventArgs e)
        {
            SetValueNhuCauTongTien();
        }

        private void txt_NhuCauNSTW_Validated(object sender, EventArgs e)
        {
            SetValueNhuCauTongTien();
        }

        private void txt_NhuCauODA_Validated(object sender, EventArgs e)
        {
            SetValueNhuCauTongTien();
        }
        public void SetValueNhuCauTongTien()
        {
            _moduleObject.NhuCauVonDauNamTongCong = _moduleObject.NhuCauVonDauNamNST + _moduleObject.NhuCauVonDauNamNSTW + _moduleObject.NhuCauVonDauNamODA;
            InitBindEntityToControl(this.Controls, _moduleObject);
        }

        #endregion

        private void btn_Save_Click(object sender, EventArgs e)
        {
            var api = ConfigManager.GetAPIByService<INhuCauKeHoachVonsApi>();
            _mainObject = api.GetAsync(_moduleObject.NhuCauKeHoachVonID).GetAwaiter().GetResult();
            if (_mainObject.TrangThaiDauNam.ToLower().Trim() == TrangThaiKeHoachNhuCauVon.DA_CHOT.ToString().ToLower().Trim())
            {
                GGFunctions.ShowMessage("Dữ liệu đã được chốt số liệu nên không được lưu!");
                return;
            }
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);
            // Luu Nhu Cau Von Chi Tiet
            var apiChiTiet = ConfigManager.GetAPIByService<INhuCauKeHoachVonChiTietsApi>();
            var resultChiTiet = GGMapper<NhuCauKeHoachVonChiTietDto, CreateUpdateNhuCauKeHoachVonChiTietDto>.MapSimple(_moduleObject);
            apiChiTiet.Update(_moduleObject.Id, resultChiTiet).GetAwaiter().GetResult();

            // Luu Nhu Cau Von
            NhuCauKeHoachVonChiTietDto objSumValue = apiChiTiet.GetDataSumValueByNhuCauVonID(_moduleObject.NhuCauKeHoachVonID).GetAwaiter().GetResult();
            if (objSumValue != null && objSumValue.NhuCauKeHoachVonID != Guid.Empty)
            {
                _mainObject.TongNhuCauVonDauNam = objSumValue.NhuCauVonDauNamTongCong;
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