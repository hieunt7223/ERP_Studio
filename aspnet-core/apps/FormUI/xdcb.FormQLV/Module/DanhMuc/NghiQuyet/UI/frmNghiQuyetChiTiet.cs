using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using xdcb.FormServices.BaseForm;
using xdcb.Common.DanhMuc.NghiQuyetDtos;
using xdcb.Common.DanhMuc.CongTrinhDtos;
using xdcb.FormServices.Shared;
using xdcb.FormServices.SDK;
using Volo.Abp.Application.Dtos;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using xdcb.FormQLV.CongTrinh;
using DevExpress.XtraSplashScreen;
using xdcb.FormServices.Component;

namespace xdcb.FormQLV.Module.DanhMuc.NghiQuyet.UI
{
    public partial class frmNghiQuyetChiTiet : GGScreenDetail
    {
        #region Property
        public NghiQuyetDto mainObject;
        public List<CongTrinhDto> listCongTrinh = new List<CongTrinhDto>();
        #endregion
        public frmNghiQuyetChiTiet(NghiQuyetDto objNghiQuyet)
        {
            InitializeComponent();
            mainObject = objNghiQuyet;

            InitControl();
            GetValueControl();
            InitBindEntityToControl(this.Controls, mainObject);
        }

        #region GetValueControl
        public void GetObjectControl()
        {
            if (listCongTrinh != null)
                listCongTrinh.Clear();

            var apiCongTrinh = ConfigManager.GetAPIByService<ICongTrinhsApi>();
            listCongTrinh.Add(new CongTrinhDto());
            var data = apiCongTrinh.GetListAsync(new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 }).GetAwaiter().GetResult().Items;
           listCongTrinh.AddRange(data);
        }

        public void GetValueControl()
        {
            GetObjectControl();
        }

        #endregion

        public void InitBindEntityToControl(Control.ControlCollection controls, NghiQuyetDto obj)
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

                    }
                }
            }
        }

        public void InitControl()
        {
            string path = ConfigManager.PathGridViewXML() + ModuleName.NghiQuyet + @"\" + TemplateDesignGrid.GridView_NghiQuyet_NghiQuyetCongTrinh.ToString();
            grl_NghiQuyetCongTrinh.InitializeControlByDesign(path, CreateDesignGrid.NewGridView.ToString());

            List<NghiQuyetCongTrinhDto> list = mainObject.NghiQuyetCongTrinhs;
            grl_NghiQuyetCongTrinh.DataSource = list;
            GridView gridView = (GridView)grl_NghiQuyetCongTrinh.MainView;
            gridView.CustomColumnDisplayText += GridView_CustomColumnDisplayText;
            gridView.DoubleClick += GridView_DoubleClick;
            gridView.KeyUp += GridView_KeyUp;
        }

        private void GridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                GridView gridView = (GridView)sender;
                gridView.DeleteRow(gridView.FocusedRowHandle);
            }
        }

        private void GridView_DoubleClick(object sender, EventArgs e)
        {
            GridView gridView = (GridView)sender;
            if (gridView.FocusedRowHandle >= 0)
            {
                var item = (NghiQuyetCongTrinhDto)gridView.GetRow(gridView.FocusedRowHandle);
                MouseEventArgs mouseEvent = e as MouseEventArgs;
                GridHitInfo info = gridView.CalcHitInfo(mouseEvent.X, mouseEvent.Y);
                if (info != null && info.Column != null)
                {
                    if (info.Column.ToString() == NghiQuyetCongTrinhColumn.CongTrinhId.GetDescription())
                    {
                        CongTrinhDto obj = listCongTrinh.Where(x => x.Id == item.CongTrinhId).ToList().FirstOrDefault();
                        if (obj != null && obj.Id != Guid.Empty)
                        {
                            ShowCongTrinh(false, obj);
                        }
                    }
                }
            }
        }

        private void GridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == NghiQuyetCongTrinhColumn.CongTrinhId.ToString())
            {
                if (e.Value != null)
                {
                    Guid id = new Guid(e.Value.ToString());
                    e.DisplayText = listCongTrinh.Where(x => x.Id == id).ToList().Select(x => x.TenCongTrinh).FirstOrDefault();
                }
            }
        }

        private void btn_Cancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        #region Lưu
        private void btn_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ValidataSave())
            {
                return;
            }
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);

            var api = ConfigManager.GetAPIByService<INghiQuyetsApi>();
            var newNghiQuyetCongTrinh = new CreateUpdateNghiQuyetCongTrinhDto();
            mainObject.NghiQuyetCongTrinhs = (List<NghiQuyetCongTrinhDto>)grl_NghiQuyetCongTrinh.DataSource;
            newNghiQuyetCongTrinh.NghiQuyetCongTrinhs = mainObject.NghiQuyetCongTrinhs;
            var result = GGMapper<NghiQuyetDto, CreateUpdateNghiQuyetDto>.MapSimple(mainObject);
            if (mainObject.Id == Guid.Empty)
            {
                mainObject = api.Create(result).GetAwaiter().GetResult();
            }
            else
            {
                api.Update(mainObject.Id, result).GetAwaiter().GetResult();

                api.DeleteNghiQuyetCongTrinh(mainObject.Id).GetAwaiter().GetResult();
            }
            
            

            if (newNghiQuyetCongTrinh.NghiQuyetCongTrinhs != null && newNghiQuyetCongTrinh.NghiQuyetCongTrinhs.Count > 0)
            {
                newNghiQuyetCongTrinh.NghiQuyetCongTrinhs.ForEach(o =>
                {
                    o.NghiQuyetId = mainObject.Id;
                });
                
                api.CreateNghiQuyetCongTrinh(newNghiQuyetCongTrinh).GetAwaiter().GetResult();
            }
            SplashScreenManager.CloseForm();
            GGFunctions.ShowMessage("Lưu thành công!");
        }

        public bool ValidataSave()
        {
            bool check = true;
            if (string.IsNullOrWhiteSpace(mainObject.SoVanBan))
            {
                GGFunctions.ShowMessage("Vui lòng nhập số văn bản!");
                check = false;
                return check;
            }

            if (string.IsNullOrWhiteSpace(mainObject.TrichYeu))
            {
                GGFunctions.ShowMessage("Vui lòng nhập trích yếu!");
                check = false;
                return check;
            }

            
            return check;
        }


        #endregion

        private void btn_CreateCongTrinh_Click(object sender, EventArgs e)
        {
            CongTrinhDto objCongTrinh = new CongTrinhDto();
            ShowCongTrinh(true, objCongTrinh);
        }

        public void ShowCongTrinh(bool isCreate, CongTrinhDto objCongTrinh)
        {
            guiNghiQuyetCongTrinh gui = new guiNghiQuyetCongTrinh(objCongTrinh, isCreate);
            gui.Module = this.Module;
            if (gui.ShowDialog() == DialogResult.OK)
            {
                if (isCreate == false)
                {
                    return;
                }
                if (gui.listNghiQuyetCongTrinh == null || gui.listNghiQuyetCongTrinh.Count == 0)
                {
                    return;
                }
                List<NghiQuyetCongTrinhDto> listNghiQuyetCongTrinh = (List<NghiQuyetCongTrinhDto>)grl_NghiQuyetCongTrinh.DataSource;
                if (listNghiQuyetCongTrinh == null)
                {
                    listNghiQuyetCongTrinh = new List<NghiQuyetCongTrinhDto>();
                }
                gui.listNghiQuyetCongTrinh.ForEach(o =>
                {
                    if (listNghiQuyetCongTrinh.ToList().Where(x => x.CongTrinhId == o.Id).ToList().Count == 0)
                    {
                        NghiQuyetCongTrinhDto obj = new NghiQuyetCongTrinhDto();
                        obj.NghiQuyetId = mainObject.Id;
                        obj.CongTrinhId = o.Id;
                        listNghiQuyetCongTrinh.Add(obj);
                    }
                });
                grl_NghiQuyetCongTrinh.DataSource = listNghiQuyetCongTrinh;
                grl_NghiQuyetCongTrinh.RefreshDataSource();
            }
        }

        
    }
}