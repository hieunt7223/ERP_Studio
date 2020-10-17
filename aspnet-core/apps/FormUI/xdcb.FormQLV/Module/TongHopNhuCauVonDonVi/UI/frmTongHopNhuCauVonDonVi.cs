using System;
using System.Data;
using System.Linq;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;
using xdcb.FormQLV.NhuCauVonDonVi;
using xdcb.FormServices.SDK;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;
using System.Windows.Forms;
using xdcb.QuanLyVon.NhuCauKeHoachVon.Dtos;
using xdcb.FormQLV.KHVTheoNganSachTrungUong;
using xdcb.FormQLV.NhuCauVonHangNam;

namespace xdcb.FormQLV.TongHopNhuCauVonDonVi
{
    public partial class frmTongHopNhuCauVonDonVi : GGScreen
    {
        public string strTenKeHoach;
        public frmTongHopNhuCauVonDonVi(string tenKeHoach)
        {
            InitializeComponent();
            strTenKeHoach = tenKeHoach;

            GetValueControl();
            InitControl();
            ReloadData();
        }

        #region GetValueControl
        public void GetValueControl()
        {
            var api = ConfigManager.GetAPIByService<INhuCauKeHoachVonsApi>();
            List<int> objectYear = api.GetObjectYear().GetAwaiter().GetResult();
            //Nam
            cbe_Nam.Properties.Items.AddRange(objectYear);

            //LoaiKeHoach
            cbb_LoaiKeHoach.ColumnsCaption = new string[1] { ComboBaseControl.Value.GetDescription().ToString() };
            cbb_LoaiKeHoach.FieldsName = new string[1] { ComboBaseControl.Value.ToString() };
            cbb_LoaiKeHoach.ValueMember = ComboBaseControl.Key.ToString();
            cbb_LoaiKeHoach.DisplayMember = ComboBaseControl.Value.ToString();
            cbb_LoaiKeHoach.DataSource = typeof(LoaiKeHoachNhuCauVon).ToListModel().ToList();
            cbb_LoaiKeHoach.cboBase.CustomDisplayText += cbb_LoaiKeHoach_CustomDisplayText;
            cbb_LoaiKeHoach.ShowData();
        }

        private void cbb_LoaiKeHoach_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.DisplayText != null)
            {
                LoaiKeHoachNhuCauVon status;
                Enum.TryParse(e.Value.ToString(), out status);
                e.DisplayText = typeof(LoaiKeHoachNhuCauVon).GetValueByKey(status);
            }
            else
            {
                e.DisplayText = null;
            }
        }
        private void cbbTenKeHoach_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.DisplayText != null)
            {
                KeHoachNhuCauVon status;
                Enum.TryParse(e.Value.ToString(), out status);
                e.DisplayText = typeof(KeHoachNhuCauVon).GetValueByKey(status);
            }
            else
            {
                e.DisplayText = null;
            }
        }

        #endregion

        #region InitControl
        public void InitControl()
        {
            string path = ConfigManager.PathGridViewXML() + ModuleName.TongHopNhuCauVonDonVi + @"\" + TemplateDesignGrid.GridView_TongNhuCauVonDonVi.ToString();
            grd_tongnhucauvondonvi.InitializeControlByDesign(path, CreateDesignGrid.NewGridView.ToString());

            GridView gridview = (GridView)grd_tongnhucauvondonvi.MainView;
            gridview.CustomColumnDisplayText += Gridview_CustomColumnDisplayText;
            gridview.DoubleClick += Gridview_DoubleClick;
        }

        private void Gridview_DoubleClick(object sender, EventArgs e)
        {
            ShowNhuCauVon();
        }

        private void ShowNhuCauVon()
        {
            NhuCauKeHoachVonDto obj = GetDataNhuCauVon();
            if (obj != null)
            {
                string nam = obj.DenNam.ToString();
                if (obj.TenKeHoach.ToLower().Trim() == KeHoachNhuCauVon.TRUNG_HAN.ToString().ToLower().Trim()
                && obj.LoaiKeHoach.ToLower().Trim() == LoaiKeHoachNhuCauVon.DIEU_CHINH.ToString().ToLower().Trim())
                {
                    nam = obj.GiaiDoanNam.ToString().Trim();
                }
                frmNhuCauVonDonVi gui = new frmNhuCauVonDonVi(nam, obj.LoaiKeHoach, obj.TenKeHoach);
                gui.WindowState = FormWindowState.Maximized;
                gui.StartPosition = FormStartPosition.CenterScreen;
                gui.ShowDialog();
            }
        }

        private void Gridview_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == NhuCauKeHoachVonColumn.LoaiKeHoach.ToString())
            {
                if (e.Value != null)
                {
                    LoaiKeHoachNhuCauVon status;
                    Enum.TryParse(e.Value.ToString(), out status);
                    e.DisplayText = typeof(LoaiKeHoachNhuCauVon).GetValueByKey(status);
                }
            }
            if (e.Column.FieldName == NhuCauKeHoachVonColumn.TenKeHoach.ToString())
            {
                if (e.Value != null)
                {
                    KeHoachNhuCauVon status;
                    Enum.TryParse(e.Value.ToString(), out status);
                    e.DisplayText = typeof(KeHoachNhuCauVon).GetValueByKey(status);
                }
            }
        }

        #endregion

        #region Search
        private void btn_ReloadData_Click(object sender, EventArgs e)
        {
            ReloadData();
        }
        public void ReloadData()
        {
            cbe_Nam.EditValue = null;
            cbb_LoaiKeHoach.EditValue = null;
            GetDataSearch();
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            GetDataSearch();
        }
        public async void GetDataSearch()
        {
            string namValue = cbe_Nam.EditValue == null ? string.Empty : cbe_Nam.EditValue.ToString();
            int nam = 0;
            if (GGFunctions.IsNumber(namValue))
            {
                nam = Convert.ToInt32(namValue);
            }
            else
            {
                cbe_Nam.EditValue = null;
            }

            string loaikehoach = cbb_LoaiKeHoach.EditValue == null ? string.Empty : cbb_LoaiKeHoach.EditValue.ToString();

            var api = ConfigManager.GetAPIByService<INhuCauKeHoachVonsApi>();
            var data = await api.GetGroupData(nam, loaikehoach, strTenKeHoach);
            if (data != null && data.Count > 0)
            {
                data = data.OrderBy(x => x.DenNam).ToList();
                int i = 1;
                data.ForEach(o =>
                {
                    o.STT = i++;
                });
            }
            grd_tongnhucauvondonvi.DataSource = data;
            grd_tongnhucauvondonvi.RefreshDataSource();
        }

        #endregion

        #region ExportExcel
        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            NhuCauKeHoachVonDto mainObject = GetDataNhuCauVon();
            if (mainObject != null)
            {
                string path = ConfigManager.PathTemplate();
                if (string.IsNullOrWhiteSpace(path))
                {
                    GGFunctions.ShowMessage("Vui lòng cấu hình đường dẫn chứa template");
                    return;
                }
                NhuCauVonHangNamModule module = new NhuCauVonHangNamModule(Convert.ToInt32(mainObject.DenNam.ToString()), mainObject.LoaiKeHoach, mainObject.TenKeHoach, Guid.Empty, Guid.Empty);
                module.ExportExcel();
            }
            else
            {
                GGFunctions.ShowMessage("Không có dữ liệu để xuất file, Vui lòng kiểm tra lại!");
            }
        }

        private NhuCauKeHoachVonDto GetDataNhuCauVon()
        {
            NhuCauKeHoachVonDto obj = null;
            GridView dgvResults = (GridView)grd_tongnhucauvondonvi.MainView;
            if (dgvResults.FocusedRowHandle >= 0)
            {
                obj = (NhuCauKeHoachVonDto)dgvResults.GetRow(dgvResults.FocusedRowHandle);
            }
            return obj;
        }
        #endregion

        #region Edit
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            ShowNhuCauVon();
        }
        #endregion
    }
}