using System;
using System.Linq;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;
using DevExpress.XtraGrid.Views.Grid;
using xdcb.FormServices.SDK;
using System.Collections.Generic;
using xdcb.QuanLyVon.GiaiNgan.Dtos;
using Localization;

namespace xdcb.FormQLV.TongHopGiaiNgan
{
    public partial class frmTongHopGiaiNgan : GGScreen
    {
        #region Property
        private GiaiNganDto _mainObject;
        #endregion
        public frmTongHopGiaiNgan()
        {
            InitializeComponent();
            GetValueControl();
            InitControl();
            GetDataSearch();
        }

        #region InitControl
        public void InitControl()
        {
            string path = ConfigManager.PathGridViewXML() + ModuleName.TongHopGiaiNgan + @"\" + TemplateDesignGrid.GridView_TongHopGiaiNgan.ToString();
            grd_danhsach.InitializeControlByDesign(path, CreateDesignGrid.NewGridView.ToString());

            GridView gridview = (GridView)grd_danhsach.MainView;
            gridview.FocusedRowChanged += Gridview_FocusedRowChanged;
            gridview.DoubleClick += Gridview_DoubleClick;
        }

        private void Gridview_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView dgvSearchResults = (GridView)sender;
            if (dgvSearchResults.FocusedRowHandle >= 0)
            {
                _mainObject = (GiaiNganDto)dgvSearchResults.GetRow(dgvSearchResults.FocusedRowHandle);
            }
        }

        private void Gridview_DoubleClick(object sender, EventArgs e)
        {
            GridView dgvSearchResults = (GridView)sender;
            if (dgvSearchResults.FocusedRowHandle >= 0)
            {
                _mainObject = (GiaiNganDto)dgvSearchResults.GetRow(dgvSearchResults.FocusedRowHandle);
                Edit();
            }
        }

        #endregion

        #region GetValueControl
        public void GetValueControl()
        {
            var api = ConfigManager.GetAPIByService<IGiaiNgansApi>();
            List<int> objectYear = api.GetObjectYear().GetAwaiter().GetResult();
            //Nam
            cbe_Nam.Properties.Items.AddRange(objectYear);

            //LoaiKeHoach
            cbb_LoaiKeHoach.ColumnsCaption = new string[1] { ComboBaseControl.Value.GetDescription().ToString() };
            cbb_LoaiKeHoach.FieldsName = new string[1] { ComboBaseControl.Value.ToString() };
            cbb_LoaiKeHoach.ValueMember = ComboBaseControl.Key.ToString();
            cbb_LoaiKeHoach.DisplayMember = ComboBaseControl.Value.ToString();
            cbb_LoaiKeHoach.DataSource = typeof(LoaiKeHoachGiaiNgan).ToListModel().ToList();
            cbb_LoaiKeHoach.cboBase.CustomDisplayText += cbb_LoaiKeHoach_CustomDisplayText;
            cbb_LoaiKeHoach.ShowData();
        }

        private void cbb_LoaiKeHoach_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.DisplayText != null)
            {
                LoaiKeHoachGiaiNgan myStatus;
                Enum.TryParse(e.Value.ToString(), out myStatus);
                e.DisplayText = typeof(LoaiKeHoachGiaiNgan).GetValueByKey(myStatus);
            }
            else
            {
                e.DisplayText = null;
            }
        }
        #endregion

        #region Search
        private void btn_ReloadData_Click(object sender, EventArgs e)
        {
            cbe_Nam.EditValue = null;
            cbb_LoaiKeHoach.EditValue = null;
            GetDataSearch();
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            GetDataSearch();
        }
        public void GetDataSearch()
        {
            int nam = cbe_Nam.EditValue == null ? 0 : (int)cbe_Nam.EditValue;
            string loaikehoach = cbb_LoaiKeHoach.EditValue == null ? string.Empty : cbb_LoaiKeHoach.EditValue.ToString();

            bool? isKeHoachKeoDai = null;
            if (!string.IsNullOrWhiteSpace(loaikehoach) && loaikehoach == LoaiKeHoachGiaiNgan.TRONG_NAM.ToString())
            {
                isKeHoachKeoDai = false;
            }
            else if (!string.IsNullOrWhiteSpace(loaikehoach) && loaikehoach == LoaiKeHoachGiaiNgan.KEO_DAI.ToString())
            {
                isKeHoachKeoDai = true;
            }

            var api = ConfigManager.GetAPIByService<IGiaiNgansApi>();
            var data = api.GetGroupData(nam, isKeHoachKeoDai, Guid.Empty).GetAwaiter().GetResult();
            if (data != null && data.Count > 0)
            {
                int i = 1;
                data = data.OrderByDescending(x => x.Nam).ThenByDescending(x => x.KeHoachGiaiNgan).ToList();
                data.ForEach(o =>
                {
                    o.STT = i;
                    i++;
                });
            }
            grd_danhsach.DataSource = data;
            grd_danhsach.RefreshDataSource();
        }
        #endregion

        #region Chỉnh sửa
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            Edit();
        }
        public void Edit()
        {
            SetDataMainObject();
            if (_mainObject != null)
            {
                GiaiNganDto obj = _mainObject;
                obj.LoaiKeHoach = (_mainObject.IsKeHoachKeoDai == false ? LoaiKeHoachGiaiNgan.TRONG_NAM.ToString() : LoaiKeHoachGiaiNgan.KEO_DAI.ToString());
                frmCreateTongHopGiaiNgan guinew = new frmCreateTongHopGiaiNgan(_mainObject, this.Module);
                guinew.Module = this.Module;
                guinew.Text = string.Format(FormQLVLocalizedResources.TextPopUpGiaiNgan, FormQLVLocalizedResources.ActionEdit);
                guinew.ShowDialog();

                grd_danhsach.DataSource = null;
                grd_danhsach.RefreshDataSource();
                //Load lại dữ liệu
                GetDataSearch();
                SetFocusedRow(obj);
            }
            else
            {
                GGFunctions.ShowMessage("Không có dữ liệu để chỉnh sửa, Vui lòng kiểm tra lại!");
            }
        }

        private void SetDataMainObject()
        {
            _mainObject = null;
            GridView dgvResults = (GridView)grd_danhsach.MainView;
            if (dgvResults.FocusedRowHandle >= 0)
            {
                _mainObject = (GiaiNganDto)dgvResults.GetRow(dgvResults.FocusedRowHandle);
            }
        }

        public void SetFocusedRow(GiaiNganDto obj)
        {
            if (_mainObject != null && _mainObject.Id != Guid.Empty)
            {
                var list = (List<GiaiNganDto>)grd_danhsach.DataSource;
                if (list != null && list.Count > 0)
                {
                    GridView gridView = (GridView)grd_danhsach.MainView;
                    gridView.BeginUpdate();
                    int id = GoToPositionOfEntity(list, obj);
                    gridView.FocusedRowHandle = (id >= 0 ? id : 0);
                    gridView.EndUpdate();
                }
            }
        }

        private int GoToPositionOfEntity(List<GiaiNganDto> list, GiaiNganDto obj)
        {
            int index = -1;
            if (obj != null && obj.Id != Guid.Empty)
            {
                if (list != null && list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        var objlist = list[i];
                        if (objlist.KeHoachGiaiNgan == obj.KeHoachGiaiNgan && objlist.Nam == obj.Nam)
                        {
                            index = i;
                            break;
                        }
                    }
                }
            }

            return index;
        }
        #endregion

        #region Export Excel
        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            GGFunctions.ShowMessage("Chưa có mẫu để xuất excel, Vui lòng kiểm tra lại!");
        }
        #endregion
    }
}