using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using xdcb.FormServices.Shared;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.SDK;
using xdcb.QuanLyVon.KeHoachTongNguon.Dtos;
using xdcb.QuanLyVon.KeHoachTongNguonChiTiet.Dtos;
using xdcb.Common.DanhMuc.NguonVonDtos;
using DevExpress.XtraSplashScreen;
using xdcb.FormServices.Component;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;
using xdcb.FileService.DocumentStoreDtos;
using Newtonsoft.Json;
using DevExpress.XtraTreeList.Columns;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using System.Threading.Tasks;

namespace xdcb.FormQLV.KeHoachTongNguon
{
    public partial class frmCreateKeHoachTong : GGScreenDetail
    {
        #region Property
        public KeHoachTongNguonDto mainObject;
        public bool isNew;
        #endregion
        public frmCreateKeHoachTong(bool isCreate, KeHoachTongNguonDto obj)
        {
            InitializeComponent();
            mainObject = obj;
            if (mainObject.TrangThai == TrangThaiKeHoachTongNguon.DUYET.ToString())
            {
                if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DAU_NAM.ToString())
                {
                    if (mainObject.NgayQuyetDinhDauNam.Date.ToString(FormatValue.DateTime.ToString()) == DateTime.MinValue.ToString(FormatValue.DateTime.ToString())
                        || mainObject.NgayQuyetDinhDauNam.Date.ToString(FormatValue.DateTime.ToString()) == DateTime.MaxValue.ToString(FormatValue.DateTime.ToString()))
                    {
                        mainObject.NgayQuyetDinhDauNam = DateTime.Now.Date;
                    }
                }
                else if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString())
                {
                    if (mainObject.NgayQuyetDinhDieuChinh.Date.ToString(FormatValue.DateTime.ToString()) == DateTime.MinValue.ToString(FormatValue.DateTime.ToString())
                        || mainObject.NgayQuyetDinhDieuChinh.Date.ToString(FormatValue.DateTime.ToString()) == DateTime.MaxValue.ToString(FormatValue.DateTime.ToString()))
                    {
                        mainObject.NgayQuyetDinhDieuChinh = DateTime.Now.Date;
                    }
                }
                dte_ngayquyetdinh.Focus();
            }
            isNew = isCreate;
            SetButtonByUser();
            InitControl();
        }

        #region InitControl
        public void InitControl()
        {
            GetValueMainControl();

            EnabaleControl();

            LoadControlByLoaiKeHoach();

            InitBindEntityToControl(box_thongtinchung.Controls, mainObject);

            if (tree_kehoachtongchitiet != null)
            {
                tree_kehoachtongchitiet.InitializeControl();
                tree_kehoachtongchitiet.LoadControlByLoaiKeHoach(true, mainObject);
                tree_kehoachtongchitiet.GetCustomSummaryValue += Tree_kehoachtongchitiet_GetCustomSummaryValue;
                tree_kehoachtongchitiet.CellValueChanged += Tree_kehoachtongchitiet_CellValueChanged;
                tree_kehoachtongchitiet.KeyUp += Tree_kehoachtongchitiet_KeyUp;
                GetValueKeHoachChiTietTreeView();
            }
            if (grl_dinhkemfile != null)
            {
                grl_dinhkemfile.InitializeControl();
                string path = ConfigManager.PathGridViewXML() + ModuleName.KeHoachTongNguon + @"\" + TemplateDesignGrid.GridView_KeHoachTongNguon_DinhKemFile.ToString();
                grl_dinhkemfile.InitializeControlByDesign(path, CreateDesignGrid.NewGridView.ToString());

                GridView gridView = (GridView)grl_dinhkemfile.MainView;
                gridView.DoubleClick += Grl_dinhkemfile_DoubleClick;
                gridView.KeyUp += Grl_dinhkemfile_KeyUp;
                GetValueUploadFileGridView();
            }
        }




        #endregion

        #region Sự kiện trên lưới TreeList
        private void Tree_kehoachtongchitiet_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                KeHoachTongNguonChiTietDto objChiTiet = (KeHoachTongNguonChiTietDto)tree_kehoachtongchitiet.GetDataRecordByNode(tree_kehoachtongchitiet.FocusedNode);
                DeleteRowKeHoachTongNguonChiTiet(objChiTiet);
            }
        }

        private void Tree_kehoachtongchitiet_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            string columnName = e.Column.FieldName;
            List<KeHoachTongNguonChiTietDto> moduleObject = (List<KeHoachTongNguonChiTietDto>)tree_kehoachtongchitiet.DataSource;
            if (moduleObject != null && moduleObject.Count > 0)
            {
                if (columnName == KeHoachTongNguonChiTietsColumn.KeHoachDauNam.ToString()
                    || columnName == KeHoachTongNguonChiTietsColumn.KeHoachDauNamDuocDuyet.ToString()
                    || columnName == KeHoachTongNguonChiTietsColumn.KeHoachBoSungDuocDuyet.ToString())
                {
                    CaculateNode(columnName, moduleObject);
                }
                else if (columnName == KeHoachTongNguonChiTietsColumn.DieuChinhGiam.ToString())
                {
                    CaculateNode(KeHoachTongNguonChiTietsColumn.DieuChinhGiam.ToString(), moduleObject);
                    CaculateNode(KeHoachTongNguonChiTietsColumn.KeHoachBoSung.ToString(), moduleObject);
                }
                else if (columnName == KeHoachTongNguonChiTietsColumn.DieuChinhTang.ToString())
                {
                    CaculateNode(KeHoachTongNguonChiTietsColumn.DieuChinhTang.ToString(), moduleObject);
                    CaculateNode(KeHoachTongNguonChiTietsColumn.KeHoachBoSung.ToString(), moduleObject);
                }
            }
        }
        public void CaculateNode(string columnName, List<KeHoachTongNguonChiTietDto> moduleObject)
        {
            moduleObject.ForEach(o =>
            {
                decimal sum = 0;
                List<KeHoachTongNguonChiTietDto> list = moduleObject.Where(x => x.NguonVonChaId == o.NguonVonId).ToList();
                if (moduleObject.Where(x => x.NguonVonChaId == o.NguonVonId).ToList().Count() > 0 && columnName != KeHoachTongNguonChiTietsColumn.KeHoachBoSung.ToString())
                {
                    GetParentNodeValue(list, moduleObject, columnName, ref sum);
                    if (columnName == KeHoachTongNguonChiTietsColumn.KeHoachDauNam.ToString())
                        o.KeHoachDauNam = sum;
                    else if (columnName == KeHoachTongNguonChiTietsColumn.KeHoachDauNamDuocDuyet.ToString())
                        o.KeHoachDauNamDuocDuyet = sum;
                    else if (columnName == KeHoachTongNguonChiTietsColumn.KeHoachBoSungDuocDuyet.ToString())
                        o.KeHoachBoSungDuocDuyet = sum;
                    else if (columnName == KeHoachTongNguonChiTietsColumn.DieuChinhTang.ToString())
                        o.DieuChinhTang = sum;
                    else if (columnName == KeHoachTongNguonChiTietsColumn.DieuChinhGiam.ToString())
                        o.DieuChinhGiam = sum;
                }
                else if (columnName == KeHoachTongNguonChiTietsColumn.KeHoachBoSung.ToString())
                {
                    if (list != null && list.Count == 0)
                    {
                        list.Add(o);
                    }
                    GetParentNodeValue(list, moduleObject, columnName, ref sum);
                    o.KeHoachBoSung = sum;
                }
            });
        }
        private void GetParentNodeValue(List<KeHoachTongNguonChiTietDto> list, List<KeHoachTongNguonChiTietDto> moduleObject, string columnName, ref decimal parentValue)
        {
            foreach (KeHoachTongNguonChiTietDto item in list)
            {
                if (moduleObject.Where(x => x.NguonVonChaId == item.NguonVonId).ToList().Count() == 0)
                {
                    if (columnName == KeHoachTongNguonChiTietsColumn.KeHoachDauNam.ToString())
                        parentValue += item.KeHoachDauNam;
                    else if (columnName == KeHoachTongNguonChiTietsColumn.KeHoachDauNamDuocDuyet.ToString())
                        parentValue += item.KeHoachDauNamDuocDuyet;
                    else if (columnName == KeHoachTongNguonChiTietsColumn.KeHoachBoSungDuocDuyet.ToString())
                        parentValue += item.KeHoachBoSungDuocDuyet;
                    else if (columnName == KeHoachTongNguonChiTietsColumn.DieuChinhTang.ToString())
                        parentValue += item.DieuChinhTang;
                    else if (columnName == KeHoachTongNguonChiTietsColumn.DieuChinhGiam.ToString())
                        parentValue += item.DieuChinhGiam;
                    else if (columnName == KeHoachTongNguonChiTietsColumn.KeHoachBoSung.ToString())
                        parentValue += (item.KeHoachDauNamDuocDuyet + item.DieuChinhTang - item.DieuChinhGiam);
                }
                else
                {
                    List<KeHoachTongNguonChiTietDto> list1 = moduleObject.Where(x => x.NguonVonChaId == item.NguonVonId).ToList();
                    GetParentNodeValue(list1, moduleObject, columnName, ref parentValue);
                }
            }
        }

        private void Tree_kehoachtongchitiet_GetCustomSummaryValue(object sender, DevExpress.XtraTreeList.GetCustomSummaryValueEventArgs e)
        {
            if (e.IsSummaryFooter)
            {
                if (e.Column.FieldName == KeHoachTongNguonChiTietsColumn.KeHoachDauNamTruoc.ToString())
                {
                    e.CustomValue = GetSumByColumnByFormat(KeHoachTongNguonChiTietsColumn.KeHoachDauNamTruoc.ToString(), FormatValue.N3);
                }
                else if (e.Column.FieldName == KeHoachTongNguonChiTietsColumn.KeHoachBoSungNamTruoc.ToString())
                {
                    e.CustomValue = GetSumByColumnByFormat(KeHoachTongNguonChiTietsColumn.KeHoachBoSungNamTruoc.ToString(), FormatValue.N3);
                }
                else if (e.Column.FieldName == KeHoachTongNguonChiTietsColumn.KeHoachDauNam.ToString())
                {
                    e.CustomValue = GetSumByColumnByFormat(KeHoachTongNguonChiTietsColumn.KeHoachDauNam.ToString(), FormatValue.N3);
                }
                else if (e.Column.FieldName == KeHoachTongNguonChiTietsColumn.KeHoachDauNamDuocDuyet.ToString())
                {
                    e.CustomValue = GetSumByColumnByFormat(KeHoachTongNguonChiTietsColumn.KeHoachDauNamDuocDuyet.ToString(), FormatValue.N3);
                }
                else if (e.Column.FieldName == KeHoachTongNguonChiTietsColumn.DieuChinhGiam.ToString())
                {
                    e.CustomValue = GetSumByColumnByFormat(KeHoachTongNguonChiTietsColumn.DieuChinhGiam.ToString(), FormatValue.N3);
                }
                else if (e.Column.FieldName == KeHoachTongNguonChiTietsColumn.DieuChinhTang.ToString())
                {
                    e.CustomValue = GetSumByColumnByFormat(KeHoachTongNguonChiTietsColumn.DieuChinhTang.ToString(), FormatValue.N3);
                }
                else if (e.Column.FieldName == KeHoachTongNguonChiTietsColumn.KeHoachBoSung.ToString())
                {
                    e.CustomValue = GetSumByColumnByFormat(KeHoachTongNguonChiTietsColumn.KeHoachBoSung.ToString(), FormatValue.N3);
                }
                else if (e.Column.FieldName == KeHoachTongNguonChiTietsColumn.KeHoachBoSungDuocDuyet.ToString())
                {
                    e.CustomValue = GetSumByColumnByFormat(KeHoachTongNguonChiTietsColumn.KeHoachBoSungDuocDuyet.ToString(), FormatValue.N3);
                }
            }
        }
        public string GetSumByColumnByFormat(string column, string format)
        {
            return String.Format(format, GetSumByColumn(column));
        }
        public decimal GetSumByColumn(string column)
        {
            decimal result = 0;
            if (tree_kehoachtongchitiet.DataSource != null)
            {
                List<KeHoachTongNguonChiTietDto> moduleObject = (List<KeHoachTongNguonChiTietDto>)tree_kehoachtongchitiet.DataSource;
                if (moduleObject != null || moduleObject.Count == 0)
                {
                    if (mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachTongNguon.DAU_NAM.ToString().ToLower().Trim())
                    {
                        moduleObject = moduleObject.Where(x => x.IsSelectDieuChinh == false).ToList();
                    }
                    else if (mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachTongNguon.DIEU_CHINH.ToString().ToLower().Trim())
                    {
                        moduleObject = moduleObject.Where(x => x.IsDeleteDieuChinh == false).ToList();
                    }
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

        #region Bind/Enabale EntityControl
        public void RefreshControlByAction()
        {
            tree_kehoachtongchitiet.LoadControlByLoaiKeHoach(true, mainObject);
            InitBindEntityToControl(box_thongtinchung.Controls, mainObject);
            EnabaleControl();
        }

        public void LoadControlByLoaiKeHoach()
        {
            if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DAU_NAM.ToString())
            {
                cbbTrangThai.GGDataMember = KeHoachTongNguonColumn.TrangThaiDauNam.ToString();
                med_ghichu.GGDataMember = KeHoachTongNguonColumn.GhiChuDauNam.ToString();
                dte_ngayquyetdinh.GGDataMember = KeHoachTongNguonColumn.NgayQuyetDinhDauNam.ToString();
                txt_soquyetdinh.GGDataMember = KeHoachTongNguonColumn.SoQuyetDinhDauNam.ToString();
            }
            else if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString())
            {
                cbbTrangThai.GGDataMember = KeHoachTongNguonColumn.TrangThaiDieuChinh.ToString();
                med_ghichu.GGDataMember = KeHoachTongNguonColumn.GhiChuDieuChinh.ToString();
                dte_ngayquyetdinh.GGDataMember = KeHoachTongNguonColumn.NgayQuyetDinhDieuChinh.ToString();
                txt_soquyetdinh.GGDataMember = KeHoachTongNguonColumn.SoQuyetDinhDieuChinh.ToString();
            }
        }
        public void EnabaleControl()
        {
            if (mainObject.TrangThai == TrangThaiKeHoachTongNguon.DANG_SOAN.ToString())
            {
                dte_ngayquyetdinh.Enabled = false;
                txt_soquyetdinh.Enabled = false;
                btn_Save.Enabled = true;
                btn_Confirm.Enabled = true;
                btn_Request.Enabled = false;
                btn_Approval.Enabled = false;
                btn_Complete.Enabled = false;
                btn_Cancel.Enabled = true;
                btn_RefreshData.Enabled = true;
                box_AttachedFile.Enabled = false;
                btn_UpLoadFile.Enabled = false;
            }
            else if (mainObject.TrangThai == TrangThaiKeHoachTongNguon.DA_TRINH.ToString())
            {
                dte_ngayquyetdinh.Enabled = false;
                txt_soquyetdinh.Enabled = false;
                btn_Save.Enabled = false;
                btn_Confirm.Enabled = false;
                btn_Request.Enabled = true;
                btn_Approval.Enabled = true;
                btn_Complete.Enabled = false;
                btn_Cancel.Enabled = true;
                btn_RefreshData.Enabled = false;
                box_AttachedFile.Enabled = false;
                btn_UpLoadFile.Enabled = false;
            }
            else if (mainObject.TrangThai == TrangThaiKeHoachTongNguon.YEU_CAU_CHINH_SUA.ToString())
            {
                dte_ngayquyetdinh.Enabled = false;
                txt_soquyetdinh.Enabled = false;
                btn_Save.Enabled = true;
                btn_Confirm.Enabled = true;
                btn_Request.Enabled = false;
                btn_Approval.Enabled = false;
                btn_Complete.Enabled = false;
                btn_Cancel.Enabled = true;
                btn_RefreshData.Enabled = true;
                box_AttachedFile.Enabled = false;
                btn_UpLoadFile.Enabled = false;
            }
            else if (mainObject.TrangThai == TrangThaiKeHoachTongNguon.DUYET.ToString())
            {
                dte_ngayquyetdinh.Enabled = true;
                txt_soquyetdinh.Enabled = true;
                btn_Save.Enabled = true;
                btn_Confirm.Enabled = false;
                btn_Request.Enabled = false;
                btn_Approval.Enabled = false;
                btn_Complete.Enabled = true;
                btn_Cancel.Enabled = true;
                btn_RefreshData.Enabled = false;
                box_AttachedFile.Enabled = true;
                btn_UpLoadFile.Enabled = true;
            }
            else if (mainObject.TrangThai == TrangThaiKeHoachTongNguon.HOAN_THANH.ToString())
            {
                dte_ngayquyetdinh.Enabled = false;
                txt_soquyetdinh.Enabled = false;
                btn_Save.Enabled = false;
                btn_Confirm.Enabled = false;
                btn_Request.Enabled = false;
                btn_Approval.Enabled = false;
                btn_Complete.Enabled = false;
                btn_Cancel.Enabled = true;
                btn_RefreshData.Enabled = false;
                box_AttachedFile.Enabled = true;
                btn_UpLoadFile.Enabled = false;
            }
        }

        public void SetButtonByUser()
        {
            if (FunctionModule.CurrentUser == UserLogin.chuyenvien.ToString())
            {
                btn_Save.Visibility = BarItemVisibility.Always;
                btn_Confirm.Visibility = BarItemVisibility.Always;
                btn_Request.Visibility = BarItemVisibility.Never;
                btn_Approval.Visibility = BarItemVisibility.Never;
                btn_Complete.Visibility = BarItemVisibility.Always;
                btn_UpLoadFile.Visible = true;
            }
            else if (FunctionModule.CurrentUser == UserLogin.truongphong.ToString())
            {
                btn_Save.Visibility = BarItemVisibility.Never;
                btn_Confirm.Visibility = BarItemVisibility.Never;
                btn_Request.Visibility = BarItemVisibility.Always;
                btn_Approval.Visibility = BarItemVisibility.Always;
                btn_Complete.Visibility = BarItemVisibility.Never;
                btn_UpLoadFile.Visible = false;
            }
        }

        public async void GetValueKeHoachChiTietTreeView()
        {
            var apikehoachchitiet = ConfigManager.GetAPIByService<IKeHoachTongNguonChiTietsApi>();
            List<KeHoachTongNguonChiTietDto> list = new List<KeHoachTongNguonChiTietDto>();
            if (mainObject.Id == Guid.Empty)
            {
                //Lấy số liệu dự toán năm trước
                List<KeHoachTongNguonChiTietDto> listChitiettongnguon = new List<KeHoachTongNguonChiTietDto>();
                var apikehoach = ConfigManager.GetAPIByService<IKeHoachTongNguonsApi>();
                var dataOld = apikehoach.GetSearchData(mainObject.Nam - 1, string.Empty, string.Empty).GetAwaiter().GetResult();
                if (dataOld != null && dataOld.Count > 0)
                {
                    listChitiettongnguon = await apikehoachchitiet.GetListByKeHoachTongNguonIdAsync(dataOld.FirstOrDefault().Id);
                }
                var api = ConfigManager.GetAPIByService<INguonVonsApi>();
                var objList = await api.GetListNotPageAsync();
                if (objList != null && objList.Count > 0)
                {
                    foreach (NguonVonDto item in objList)
                    {
                        KeHoachTongNguonChiTietDto obj = AddKeHoachTongNguonChiTietForNguonVon(item, listChitiettongnguon);
                        list.Add(obj);
                    }
                }
            }
            else
            {
                list = await apikehoachchitiet.GetListByKeHoachTongNguonIdAsync(mainObject.Id);
                //Trường hợp thêm mới điều chỉnh
                if (list != null && list.Count > 0
                    && isNew == true && mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachTongNguon.DIEU_CHINH.ToString().ToLower().Trim())
                {
                    list.Where(x => x.IsSelectDieuChinh == false).ToList().ForEach(o =>
                    {
                        o.IsDeleteDieuChinh = false;
                        o.KeHoachBoSung = o.KeHoachDauNamDuocDuyet + o.DieuChinhTang - o.DieuChinhGiam;
                    });
                }
            }
            KeHoachChiTiet_RefreshDataSource(list);
        }

        public KeHoachTongNguonChiTietDto AddKeHoachTongNguonChiTietForNguonVon(NguonVonDto item, List<KeHoachTongNguonChiTietDto> listChitiettongnguon)
        {
            KeHoachTongNguonChiTietDto obj = new KeHoachTongNguonChiTietDto();
            obj.NguonVonId = item.Id;
            obj.TenNguonVon = item.TenNguonVon;
            obj.NguonVonChaId = (item.ParentId == null ? Guid.Empty : (Guid)item.ParentId);
            if (listChitiettongnguon != null && listChitiettongnguon.Count > 0)
            {
                KeHoachTongNguonChiTietDto objOld = listChitiettongnguon.Where(x => x.NguonVonId == obj.NguonVonId).ToList().FirstOrDefault();
                if (objOld != null && objOld.Id != Guid.Empty)
                {
                    obj.KeHoachDauNamTruoc = objOld.KeHoachDauNamDuocDuyet;
                    obj.KeHoachBoSungNamTruoc = objOld.KeHoachBoSungDuocDuyet;
                }
            }
            return obj;
        }

        public void KeHoachChiTiet_RefreshDataSource(List<KeHoachTongNguonChiTietDto> list)
        {
            if (list != null && list.Count > 0)
            {
                if (mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachTongNguon.DAU_NAM.ToString().ToLower().Trim())
                {
                    list = list.Where(x => x.IsSelectDieuChinh == false).ToList();
                }
                else if (mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachTongNguon.DIEU_CHINH.ToString().ToLower().Trim())
                {
                    list = list.Where(x => x.IsDeleteDieuChinh == false).ToList();
                }
                var apiNguonVon = ConfigManager.GetAPIByService<INguonVonsApi>();
                var dataNguonVon = apiNguonVon.GetListNotPageAsync().GetAwaiter().GetResult();
                list.ForEach(o =>
                {
                    NguonVonDto objNguonVon = dataNguonVon.Where(x => x.Id == o.NguonVonId).ToList().FirstOrDefault();
                    if (objNguonVon != null && objNguonVon.Id != Guid.Empty)
                    {
                        o.MaNguonVon = objNguonVon.MaNguonVon;
                        o.TenNguonVon = objNguonVon.TenNguonVon;
                        o.NguonVonIndex = objNguonVon.OrderIndex;
                    }
                });
                list = list.OrderBy(x => x.NguonVonIndex).ToList();
            }
            tree_kehoachtongchitiet.DataSource = list;
            tree_kehoachtongchitiet.RefreshDataSource();
            SetPropertyTreeList();
        }

        public void SetPropertyTreeList()
        {
            //set thông tin
            tree_kehoachtongchitiet.ExpandAll();
            tree_kehoachtongchitiet.OptionsView.AutoWidth = false;
            tree_kehoachtongchitiet.BestFitColumns();
            TreeListColumn columnNguonVon = tree_kehoachtongchitiet.Columns[KeHoachTongNguonChiTietsColumn.TenNguonVon.ToString()];
            if (columnNguonVon != null)
            {
                columnNguonVon.Width = 400;
                RepositoryItemMemoEdit memoEdit = new RepositoryItemMemoEdit();
                columnNguonVon.ColumnEdit = memoEdit;
                columnNguonVon.AppearanceCell.Options.UseTextOptions = true;
                columnNguonVon.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                columnNguonVon.AppearanceCell.TextOptions.WordWrap = WordWrap.Wrap;
            }
        }

        public void InitBindEntityToControl(Control.ControlCollection controls, KeHoachTongNguonDto obj)
        {
            foreach (Control ctrl in controls)
            {
                string dataMember = GetProperty.GetPropertyStringValue(ctrl, Customs.cstDataMember);
                if (!string.IsNullOrWhiteSpace(dataMember))
                {
                    try
                    {
                        ctrl.DataBindings.Clear();
                        ctrl.DataBindings.Add("EditValue", obj, dataMember, true,
                                                   DataSourceUpdateMode.OnPropertyChanged);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
        #endregion

        #region Đính kèm file
        private void Grl_dinhkemfile_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                GridView gridView = (GridView)sender;
                var item = (FileColumnViewModel)gridView.GetRow(gridView.FocusedRowHandle);
                if (item != null && mainObject.TrangThai != TrangThaiKeHoachTongNguon.HOAN_THANH.ToString())
                {
                    if (GGFunctions.ShowMessageYesNo("File '" + item.FileName + "' có chắc chắn muốn xóa không?") == DialogResult.Yes)
                    {
                        gridView.DeleteRow(gridView.FocusedRowHandle);
                    }
                }
            }
        }

        private void Grl_dinhkemfile_DoubleClick(object sender, EventArgs e)
        {
            GridView gridView = (GridView)sender;
            if (gridView.FocusedRowHandle >= 0)
            {
                var item = (FileColumnViewModel)gridView.GetRow(gridView.FocusedRowHandle);
                if (item != null)
                {
                    ShowFile(item);
                }
            }
        }

        private void btn_UpLoadFile_Click(object sender, EventArgs e)
        {
            if (mainObject.TrangThai != TrangThaiKeHoachTongNguon.HOAN_THANH.ToString())
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "Save file as...";
                dialog.Filter = "Text files (*.txt;*.doc;*.docx;*.xls;*.xlsx;*.pdf)|*.txt;*.doc;*.docx;*.xls;*.xlsx;*.pdf|All files (*.*)|*.*";
                dialog.Multiselect = false;
                dialog.RestoreDirectory = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    UploadFile(dialog.FileName, dialog.SafeFileName);
                }
            }
        }

        public void UploadFile(string path, string safeFileName)
        {
            FileInfo fInfo = new FileInfo(Path.Combine(path));
            if (fInfo.Length > 0)
            {
                FileColumnViewModel obj = new FileColumnViewModel();
                string typeFile = Path.GetExtension(path);
                string nameFile = safeFileName.Replace(typeFile, "").ToString();
                nameFile = GGFunctions.ConvertUnicode(nameFile).Replace(";", "").Replace(" ", "-").ToString().ToLower();
                obj.Length = fInfo.Length;
                obj.Name = safeFileName.ToString();
                obj.FileName = string.Format("{0}{1}", nameFile, typeFile);
                obj.TypeFile = typeFile.ToLower().Trim();
                obj.path = path;

                List<FileColumnViewModel> listData = (List<FileColumnViewModel>)grl_dinhkemfile.DataSource;
                if (listData == null)
                {
                    listData = new List<FileColumnViewModel>();
                }
                if (listData.Where(x => x.FileName.ToLower().Trim() == obj.FileName.ToLower().Trim()).ToList().Count > 0)
                {
                    GGFunctions.ShowMessage("File này đã được upload, vui lòng kiểm tra lại!");
                    return;
                }
                listData.Add(obj);
                RefreshDataSourceDinhKemFile(listData);
            }
            else
            {
                GGFunctions.ShowMessage("Không thể upload file. Vui lòng kiểm tra lại file!");
                return;
            }
        }

        public void ShowFile(FileColumnViewModel obj)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "Chọn thư mục lưu";
            sf.FileName = obj.FileName;

            if (sf.ShowDialog() == DialogResult.OK)
            {
                if (obj.Id != null && obj.Id != Guid.Empty)
                {
                    if (sf.FileName != null && sf.FileName.Length > 0)
                    {
                        string path = GGFiles.DownloadFile(sf.FileName, obj);
                        if (string.IsNullOrWhiteSpace(path))
                        {
                            GGFunctions.ShowMessage("Không có file upload để tải về. Vui lòng kiểm tra lại!");
                            return;
                        }
                        if (File.Exists(path))
                        {
                            GGFunctions.ShowMessage("Tải file '" + obj.FileName + "' thành công!");
                        }
                    }
                    else
                    {
                        GGFunctions.ShowMessage("Không có file upload để tải về. Vui lòng kiểm tra lại!");
                        return;
                    }
                }
                else if (!string.IsNullOrWhiteSpace(obj.path))
                {
                    if (!File.Exists(obj.path))
                    {
                        GGFunctions.ShowMessage("Không có file upload để tải về. Vui lòng kiểm tra lại!");
                        return;
                    }
                    File.Copy(obj.path, sf.FileName);
                    if (File.Exists(sf.FileName))
                    {
                        GGFunctions.ShowMessage("Tải file '" + obj.FileName + "' thành công!");
                    }
                }
                else
                {
                    GGFunctions.ShowMessage("Không có file upload để tải về. Vui lòng kiểm tra lại!");
                    return;
                }
            }
        }

        public void GetValueUploadFileGridView()
        {
            List<FileColumnViewModel> listobj = new List<FileColumnViewModel>();

            string text = string.Empty;
            if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DAU_NAM.ToString())
            {
                if (!string.IsNullOrWhiteSpace(mainObject.DinhKemFileDauNam))
                {
                    text = mainObject.DinhKemFileDauNam;
                }
            }
            else if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString())
            {
                if (!string.IsNullOrWhiteSpace(mainObject.DinhKemFileDieuChinh))
                {
                    text = mainObject.DinhKemFileDieuChinh;
                }
            }
            List<Guid> guidList = GGFunctions.ConvertStringToListGuid(text);
            if (guidList != null && guidList.Count > 0)
            {
                string content = GGFiles.GetValueByListGuid(guidList);
                if (!string.IsNullOrWhiteSpace(content))
                {
                    List<DocumentStoreDto> modelList = JsonConvert.DeserializeObject<List<DocumentStoreDto>>(content);
                    if (modelList != null && modelList.Count > 0)
                    {
                        modelList.ForEach(o =>
                        {
                            if (o.Id != null && o.Id != Guid.Empty)
                            {
                                FileColumnViewModel obj = new FileColumnViewModel();
                                obj.Id = o.Id;
                                obj.FileName = o.FullName;
                                obj.url = o.Url;
                                obj.ContentType = o.KieuFile;
                                listobj.Add(obj);
                            }
                        });
                    }
                }
            }
            RefreshDataSourceDinhKemFile(listobj);
        }

        public void RefreshDataSourceDinhKemFile(List<FileColumnViewModel> data)
        {
            if (data != null && data.Count > 0)
            {
                if (data != null && data.Count > 0)
                {
                    data = data.OrderBy(x => x.FileName).ToList();
                }
            }
            grl_dinhkemfile.DataSource = data;
            grl_dinhkemfile.RefreshDataSource();
        }

        #endregion

        #region GetValueMainControl
        public void GetValueMainControl()
        {
            // Danh sách trạng thái
            cbbTrangThai.ColumnsCaption = new string[1] { ComboBaseControl.Value.GetDescription().ToString() };
            cbbTrangThai.FieldsName = new string[1] { ComboBaseControl.Value.ToString() };
            cbbTrangThai.ValueMember = ComboBaseControl.Key.ToString();
            cbbTrangThai.DisplayMember = ComboBaseControl.Value.ToString();
            cbbTrangThai.DataSource = typeof(TrangThaiKeHoachTongNguon).ToList();
            cbbTrangThai.cboBase.CustomDisplayText += cbbTrangThai_CustomDisplayText;
            cbbTrangThai.ShowData();

            //Nam
            cbe_nam.Properties.Items.AddRange(GGFunctions.GetValueNam());

            //LoaiKeHoach
            cbb_LoaiKeHoach.ColumnsCaption = new string[1] { ComboBaseControl.Value.GetDescription().ToString() };
            cbb_LoaiKeHoach.FieldsName = new string[1] { ComboBaseControl.Value.ToString() };
            cbb_LoaiKeHoach.ValueMember = ComboBaseControl.Key.ToString();
            cbb_LoaiKeHoach.DisplayMember = ComboBaseControl.Value.ToString();
            cbb_LoaiKeHoach.DataSource = typeof(LoaiKeHoachTongNguon).ToList();
            cbb_LoaiKeHoach.cboBase.CustomDisplayText += cbb_LoaiKeHoach_CustomDisplayText;
            cbb_LoaiKeHoach.ShowData();
        }

        private void cbb_LoaiKeHoach_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.DisplayText != null)
            {
                LoaiKeHoachTongNguon myStatus;
                Enum.TryParse(e.Value.ToString(), out myStatus);
                e.DisplayText = typeof(LoaiKeHoachTongNguon).GetValueByKey(myStatus);
            }
            else
            {
                e.DisplayText = null;
            }
        }

        private void cbbTrangThai_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.DisplayText != null)
            {
                TrangThaiKeHoachTongNguon myStatus;
                Enum.TryParse(e.Value.ToString(), out myStatus);
                e.DisplayText = typeof(LoaiKeHoachTongNguon).GetValueByKey(myStatus);
            }
            else
            {
                e.DisplayText = null;
            }
        }
        #endregion

        #region Action Đóng
        private void btn_Cancel_Click(object sender, EventArgs e)
        {

        }
        private void btn_Cancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Action Lưu
        private async void btn_Save_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (isNew == true)
            {
                if (!ValidateNew())
                    return;
            }
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);

            List<KeHoachTongNguonChiTietDto> moduleObject = (List<KeHoachTongNguonChiTietDto>)tree_kehoachtongchitiet.DataSource;
            if (moduleObject == null || moduleObject.Count == 0)
            {
                GGFunctions.ShowMessage("Vui lòng nhập nguồn vốn ở chi tiết!");
                return;
            }
            await Save(mainObject.TrangThai, mainObject.LoaiKeHoach);
            //Load lại dữ liệu
            GetValueKeHoachChiTietTreeView();
            isNew = false;
            SplashScreenManager.CloseForm();
            GGFunctions.ShowMessage("Lưu thành công!");
        }
        public async Task Save(string trangthai, string loaikehoach)
        {
            List<KeHoachTongNguonChiTietDto> moduleObject = (List<KeHoachTongNguonChiTietDto>)tree_kehoachtongchitiet.DataSource;
            SetValueBySave();
            var result = GGMapper<KeHoachTongNguonDto, CreateUpdateKeHoachTongNguonDto>.MapSimple(mainObject);

            var api = ConfigManager.GetAPIByService<IKeHoachTongNguonsApi>();

            if (mainObject.Id == Guid.Empty)
            {
                mainObject = await api.Create(result);

                mainObject.TrangThai = trangthai;
                mainObject.LoaiKeHoach = loaikehoach;
            }
            else
            {
                await api.Update(mainObject.Id, result);
            }

            var apiDetatil = ConfigManager.GetAPIByService<IKeHoachTongNguonChiTietsApi>();
            //Delete Detail
            var dataChiTietOld = apiDetatil.GetListByKeHoachTongNguonIdAsync(mainObject.Id).GetAwaiter().GetResult();
            if (dataChiTietOld != null && dataChiTietOld.Count > 0)
            {
                List<Guid> guidList = moduleObject.ToList().Where(x => x.Id != Guid.Empty).Select(x => x.Id).Distinct().ToList();
                // Xóa đầu năm
                if (mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachTongNguon.DAU_NAM.ToString().ToLower().Trim())
                {
                    List<KeHoachTongNguonChiTietDto> listDelete = dataChiTietOld.Where(x => !guidList.Contains(x.Id) && x.IsSelectDieuChinh == false).ToList();
                    if (listDelete != null && listDelete.Count > 0)
                    {
                        listDelete.ForEach(o =>
                        {
                            if (o.Id != null && o.Id != Guid.Empty)
                                apiDetatil.Delete(o.Id).GetAwaiter().GetResult();
                        });
                    }
                }
                //Xóa điều chỉnh
                else if (mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachTongNguon.DIEU_CHINH.ToString().ToLower().Trim())
                {
                    List<KeHoachTongNguonChiTietDto> listDelete = dataChiTietOld.Where(x => !guidList.Contains(x.Id) && x.IsDeleteDieuChinh == false).ToList();
                    if (listDelete != null && listDelete.Count > 0)
                    {
                        listDelete.ForEach(o =>
                        {
                            if (o.Id != null && o.Id != Guid.Empty)
                                apiDetatil.DeleteKeHoachVonDieuChinhById(o.Id).GetAwaiter().GetResult();
                        });
                    }
                }

            }

            //CreateUpdate Detail
            moduleObject.ForEach(o =>
            {
                var objDetail = GGMapper<KeHoachTongNguonChiTietDto, CreateUpdateKeHoachTongNguonChiTietDto>.MapSimple(o);
                if (o.Id == Guid.Empty)
                {
                    objDetail.KeHoachTongNguonId = mainObject.Id;
                    apiDetatil.Create(objDetail).GetAwaiter().GetResult();
                }
                else
                {
                    apiDetatil.Update(o.Id, objDetail).GetAwaiter().GetResult();
                }
            });

            RefreshControlByAction();
        }

        public void SetValueBySave()
        {
            if (mainObject.TrangThai == TrangThaiKeHoachTongNguon.DUYET.ToString())
            {
                //Lưu file Update
                SaveFileDinhKem();
                List<FileColumnViewModel> listData = (List<FileColumnViewModel>)grl_dinhkemfile.DataSource;
                string strFile = string.Empty;
                if (listData != null && listData.Count > 0)
                {
                    List<string> listString = listData.Where(x => x.Id != Guid.Empty).ToList().Select(x => x.Id.ToString()).Distinct().ToList();
                    if (listString != null)
                    {
                        strFile = string.Join(";", listString);
                    }
                }
                if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DAU_NAM.ToString())
                {
                    mainObject.DinhKemFileDauNam = strFile;
                }
                else if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString())
                {
                    mainObject.DinhKemFileDieuChinh = strFile;
                }
            }
            if (mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
            {
                mainObject.KeHoachDauNam = GetSumByColumn(KeHoachTongNguonChiTietsColumn.KeHoachDauNam.ToString());
                mainObject.KeHoachDauNamDuocDuyet = GetSumByColumn(KeHoachTongNguonChiTietsColumn.KeHoachDauNamDuocDuyet.ToString());
            }
            else
            {
                mainObject.KeHoachSauBoSung = GetSumByColumn(KeHoachTongNguonChiTietsColumn.KeHoachBoSung.ToString());
                mainObject.KeHoachSauBoSungDuocDuyet = GetSumByColumn(KeHoachTongNguonChiTietsColumn.KeHoachBoSungDuocDuyet.ToString());
            }

        }

        public void SaveFileDinhKem()
        {
            List<FileColumnViewModel> listData = (List<FileColumnViewModel>)grl_dinhkemfile.DataSource;
            if (listData == null)
            {
                listData = new List<FileColumnViewModel>();
            }
            listData.ForEach(o =>
            {
                if (o.Id == Guid.Empty)
                {
                    string content = GGFiles.UploadFile(o.path, o.Name);
                    if (!string.IsNullOrWhiteSpace(content))
                    {
                        DocumentStoreModel model = JsonConvert.DeserializeObject<DocumentStoreModel>(content);
                        if (model != null)
                        {
                            o.Id = model.Id;
                            o.ContentType = model.KieuFile;
                        }
                    }
                }
            });
            RefreshDataSourceDinhKemFile(listData);
        }

        public bool ValidateNew()
        {
            bool isCheck = true;
            var api = ConfigManager.GetAPIByService<IKeHoachTongNguonsApi>();
            var data = api.GetSearchData(Convert.ToInt32(mainObject.Nam), string.Empty, string.Empty).GetAwaiter().GetResult();
            if (data != null && data.Count > 0)
            {

                //1.Đã tồn tại năm đó (cùng loại kế hoạch) không cho thêm mới
                if (data.Where(x => x.LoaiKeHoach == mainObject.LoaiKeHoach.ToString()).ToList().Count() > 0)
                {
                    GGFunctions.ShowMessage("Năm và loại kế hoạch này đã phát sinh dữ liệu trên hệ thống, Vui lòng kiểm tra lại!");
                    isCheck = false;
                    return isCheck;
                }
                //2.Đã làm kế hoạch điều chỉnh thì không được làm kế hoạch đầu năm
                else if (mainObject.LoaiKeHoach.ToString() == LoaiKeHoachTongNguon.DAU_NAM.ToString()
                    && data.Where(x => x.LoaiKeHoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString()).ToList().Count() > 0)
                {
                    GGFunctions.ShowMessage("Năm này đã làm kế hoạch điều chỉnh nên không được làm kế hoạch đầu năm, Vui lòng kiểm tra lại!");
                    isCheck = false;
                    return isCheck;
                }
            }
            return isCheck;
        }
        #endregion

        #region Action Tải lại dữ liệu
        private void btn_RefreshData_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);
            List<KeHoachTongNguonChiTietDto> moduleObject = (List<KeHoachTongNguonChiTietDto>)tree_kehoachtongchitiet.DataSource;
            if (moduleObject != null)
            {
                var api = ConfigManager.GetAPIByService<INguonVonsApi>();
                //Thêm mới
                var objList = api.GetListNotPageAsync().GetAwaiter().GetResult();
                if (objList != null && objList.Count > 0)
                {
                    objList.ForEach(o =>
                    {
                        bool isCheckNew = false;
                        bool selectDieuChinh = false;
                        if (mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachTongNguon.DAU_NAM.ToString().ToLower().Trim())
                        {
                            if (moduleObject.Where(x => x.IsSelectDieuChinh == false).ToList().Where(x => x.NguonVonId == o.Id).ToList().Count == 0)
                            {
                                isCheckNew = true;
                            }
                        }
                        else if (mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachTongNguon.DIEU_CHINH.ToString().ToLower().Trim())
                        {
                            if (moduleObject.Where(x => x.IsDeleteDieuChinh == false).ToList().Where(x => x.NguonVonId == o.Id).ToList().Count == 0)
                            {
                                isCheckNew = true;
                                selectDieuChinh = true;
                            }
                        }
                        if (isCheckNew)
                        {
                            KeHoachTongNguonChiTietDto obj = new KeHoachTongNguonChiTietDto();
                            obj.NguonVonId = o.Id;
                            obj.MaNguonVon = o.MaNguonVon;
                            obj.TenNguonVon = o.TenNguonVon;
                            obj.NguonVonIndex = o.OrderIndex;
                            obj.NguonVonChaId = (o.ParentId == null ? Guid.Empty : (Guid)o.ParentId);
                            obj.IsSelectDieuChinh = selectDieuChinh;
                            moduleObject.Add(obj);
                        }
                    });

                }

                //Xóa nguồn vốn
                List<Guid> listIDNguonVon = objList.ToList().Select(o => o.Id).Distinct().ToList();
                var deleteData = moduleObject.Where(x => !listIDNguonVon.Contains(x.NguonVonId)).ToList();
                if (deleteData != null && deleteData.Count > 0)
                {
                    deleteData.ForEach(o =>
                    {
                        moduleObject.Remove(o);
                    });
                }
                KeHoachChiTiet_RefreshDataSource(moduleObject);
                SplashScreenManager.CloseForm();
                GGFunctions.ShowMessage("Đã tải lại dữ liệu nguồn vốn thành công!");

            }
            else
            {
                SplashScreenManager.CloseForm();
                GGFunctions.ShowMessage("Chưa thông tin chi tiết kế hoạch tổng nguồn chi tiết! Vui lòng kiểm tra lại!");
                return;
            }
        }
        #endregion

        #region Action Trình
        private async void btn_Confirm_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (isNew == true)
            {
                if (!ValidateNew())
                    return;
            }
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);

            if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DAU_NAM.ToString())
            {
                mainObject.TrangThaiDauNam = TrangThaiKeHoachTongNguon.DA_TRINH.ToString();
            }
            else if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString())
            {
                mainObject.TrangThaiDieuChinh = TrangThaiKeHoachTongNguon.DA_TRINH.ToString();
            }
            mainObject.TrangThai = TrangThaiKeHoachTongNguon.DA_TRINH.ToString();
            await Save(mainObject.TrangThai, mainObject.LoaiKeHoach);
            isNew = false;
            SplashScreenManager.CloseForm();
            GGFunctions.ShowMessage("Trình thành công!");
        }

        #endregion

        #region Yêu cầu chỉnh sửa
        private async void btn_Request_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);

            if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DAU_NAM.ToString())
            {
                mainObject.TrangThaiDauNam = TrangThaiKeHoachTongNguon.YEU_CAU_CHINH_SUA.ToString();
            }
            else if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString())
            {
                mainObject.TrangThaiDieuChinh = TrangThaiKeHoachTongNguon.YEU_CAU_CHINH_SUA.ToString();
            }

            mainObject.TrangThai = TrangThaiKeHoachTongNguon.YEU_CAU_CHINH_SUA.ToString();
            await Save(mainObject.TrangThai, mainObject.LoaiKeHoach);
            SplashScreenManager.CloseForm();
            GGFunctions.ShowMessage("Yêu cầu chỉnh sửa thành công!");
        }
        #endregion

        #region Action Duyệt
        private async void btn_Approval_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);

            if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DAU_NAM.ToString())
            {
                mainObject.TrangThaiDauNam = TrangThaiKeHoachTongNguon.DUYET.ToString();
                mainObject.NgayQuyetDinhDauNam = DateTime.Now.Date;
            }
            else if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString())
            {
                mainObject.TrangThaiDieuChinh = TrangThaiKeHoachTongNguon.DUYET.ToString();
                mainObject.NgayQuyetDinhDieuChinh = DateTime.Now.Date;
            }

            mainObject.TrangThai = TrangThaiKeHoachTongNguon.DUYET.ToString();
            SetValueByApproval();
            await Save(mainObject.TrangThai, mainObject.LoaiKeHoach);

            SplashScreenManager.CloseForm();
            GGFunctions.ShowMessage("Duyệt thành công!");
        }

        public void SetValueByApproval()
        {
            List<KeHoachTongNguonChiTietDto> moduleObject = (List<KeHoachTongNguonChiTietDto>)tree_kehoachtongchitiet.DataSource;
            //Copy Data
            if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DAU_NAM.ToString())
            {
                moduleObject.ForEach(o =>
                {
                    o.KeHoachDauNamDuocDuyet = o.KeHoachDauNam;
                });
            }
            else if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString())
            {
                moduleObject.ForEach(o =>
                {
                    o.KeHoachBoSungDuocDuyet = o.KeHoachBoSung;
                });
            }
        }
        #endregion

        #region Hoàn thành
        private async void btn_Complete_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<FileColumnViewModel> listData = (List<FileColumnViewModel>)grl_dinhkemfile.DataSource;
            if (listData == null || listData.Count == 0)
            {
                GGFunctions.ShowMessage("Vui lòng đính kèm file!");
                return;
            }
            if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DAU_NAM.ToString())
            {
                if (string.IsNullOrWhiteSpace(mainObject.SoQuyetDinhDauNam))
                {
                    GGFunctions.ShowMessage("Vui lòng nhập số quyết định!");
                    return;
                }
                else if (mainObject.NgayQuyetDinhDauNam.Date.ToString(FormatValue.DateTime.ToString()) == DateTime.MinValue.ToString(FormatValue.DateTime.ToString())
                    || mainObject.NgayQuyetDinhDauNam.Date.ToString(FormatValue.DateTime.ToString()) == DateTime.MaxValue.ToString(FormatValue.DateTime.ToString()))
                {
                    GGFunctions.ShowMessage("Vui lòng nhập ngày quyết định!");
                    return;
                }
                mainObject.TrangThaiDauNam = TrangThaiKeHoachTongNguon.HOAN_THANH.ToString();
            }
            else if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString())
            {
                if (string.IsNullOrWhiteSpace(mainObject.SoQuyetDinhDieuChinh))
                {
                    GGFunctions.ShowMessage("Vui lòng nhập số quyết định!");
                    return;
                }
                else if (mainObject.NgayQuyetDinhDieuChinh.Date.ToString(FormatValue.DateTime.ToString()) == DateTime.MinValue.ToString(FormatValue.DateTime.ToString())
                    || mainObject.NgayQuyetDinhDieuChinh.Date.ToString(FormatValue.DateTime.ToString()) == DateTime.MaxValue.ToString(FormatValue.DateTime.ToString()))
                {
                    GGFunctions.ShowMessage("Vui lòng nhập ngày quyết định!");
                    return;
                }
                mainObject.TrangThaiDieuChinh = TrangThaiKeHoachTongNguon.HOAN_THANH.ToString();
            }
            mainObject.TrangThai = TrangThaiKeHoachTongNguon.HOAN_THANH.ToString();
            await Save(mainObject.TrangThai, mainObject.LoaiKeHoach);
            GGFunctions.ShowMessage("Hoàn thành thành công!");
        }
        #endregion

        #region Xuất excel
        private void btn_ExportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (mainObject != null && mainObject.Id != Guid.Empty)
            {
                ((KeHoachTongNguonModule)Module).SetValueAndControl(mainObject, tree_kehoachtongchitiet);
                ((KeHoachTongNguonModule)Module).ExportExcel();
            }
            else
            {
                GGFunctions.ShowMessage("Dữ liệu chưa được lưu nên không thể xuất file excel!");
            }
        }
        #endregion

        #region Delete Row Chi Tiet
        public void DeleteRowKeHoachTongNguonChiTiet(KeHoachTongNguonChiTietDto objDetail)
        {
            if (mainObject.TrangThai == TrangThaiKeHoachTongNguon.DANG_SOAN.ToString()
                || mainObject.TrangThai == TrangThaiKeHoachTongNguon.YEU_CAU_CHINH_SUA.ToString())
            {
                List<KeHoachTongNguonChiTietDto> moduleObject = (List<KeHoachTongNguonChiTietDto>)tree_kehoachtongchitiet.DataSource;
                if (objDetail != null && moduleObject != null)
                {
                    if (moduleObject.Where(x => x.NguonVonChaId == objDetail.NguonVonId).ToList().Count > 0)
                    {
                        GGFunctions.ShowMessage("Vui lòng xóa dữ liệu nguồn vốn con trước khi xóa nguồn vốn cha!");
                        return;
                    }
                    moduleObject.Remove(objDetail);

                    if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DAU_NAM.ToString())
                    {
                        CaculateNode(KeHoachTongNguonChiTietsColumn.KeHoachDauNam.ToString(), moduleObject);
                    }
                    else if (mainObject.LoaiKeHoach == LoaiKeHoachTongNguon.DIEU_CHINH.ToString())
                    {
                        CaculateNode(KeHoachTongNguonChiTietsColumn.DieuChinhGiam.ToString(), moduleObject);
                        CaculateNode(KeHoachTongNguonChiTietsColumn.DieuChinhTang.ToString(), moduleObject);
                        CaculateNode(KeHoachTongNguonChiTietsColumn.KeHoachBoSung.ToString(), moduleObject);
                    }
                    tree_kehoachtongchitiet.RefreshDataSource();
                    SetPropertyTreeList();
                }
            }
        }
        #endregion
    }
}