using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using xdcb.Common.DanhMuc.ChuDauTuDtos;
using xdcb.Common.DanhMuc.CongTrinhDtos;
using xdcb.Common.DanhMuc.NghiQuyetDtos;
using xdcb.Common.DanhMuc.NguonVonDtos;
using xdcb.FileService.DocumentStoreDtos;
using xdcb.FormQLV.KHVTheoNghiQuyet;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Component;
using xdcb.FormServices.SDK;
using xdcb.FormServices.Shared;
using xdcb.QuanLyVon.KeHoachVonNQ.Dtos;
using xdcb.QuanLyVon.KeHoachVonNQChiTiet.Dtos;

namespace xdcb.FormQLV.KeHoachVonTheoNghiQuyet
{
    public partial class frmCreateKHVTheoNghiQuyet : GGScreenDetail
    {
        #region Property
        private KeHoachVonNQDto _mainObject;
        private List<KeHoachVonNQChiTietDto> _moduleObject = new List<KeHoachVonNQChiTietDto>();
        private bool _isNew;

        #endregion Property

        public frmCreateKHVTheoNghiQuyet(bool isCreate, KeHoachVonNQDto keHoachVonNQDto, BaseModule module)
        {
            InitializeComponent();
            this.Module = module;
            _mainObject = keHoachVonNQDto;
            if (_mainObject.TrangThai == TrangThaiKeHoachVon.DUYET.ToString())
            {
                if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
                {
                    if (_mainObject.NgayBanHanhDauNam == null)
                    {
                        _mainObject.NgayBanHanhDauNam = DateTime.Now.Date;
                    }
                }
                else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
                {
                    if (_mainObject.NgayBanHanhDieuChinh == null)
                    {
                        _mainObject.NgayBanHanhDieuChinh = DateTime.Now.Date;
                    }
                }
                dte_ngayquyetdinh.Focus();
            }
            _isNew = isCreate;
            SetButtonByUser();
            GetValueMainControl();
            InitControl();
        }

        #region InitControl

        public void InitControl()
        {
            GetDataKeHoachVonChiTiet();

            RefreshLayoutBandedGridView(new List<NguonVonDto>());
            tree_chitietkehoachvon.NodeCellStyle += Tree_chitietkehoachvon_NodeCellStyle;
            tree_chitietkehoachvon.CustomUnboundColumnData += Tree_chitietkehoachvon_CustomUnboundColumnData;
            tree_chitietkehoachvon.CustomNodeCellEdit += Tree_chitietkehoachvon_CustomNodeCellEdit;
            tree_chitietkehoachvon.KeyUp += Tree_chitietkehoachvon_KeyUp;
            tree_chitietkehoachvon.GetCustomSummaryValue += Tree_chitietkehoachvon_GetCustomSummaryValue;
            RefreshDataSourceDetail();

            EnabaleControl();

            LoadControlByLoaiKeHoach();

            InitBindEntityToControl(this.Controls, _mainObject);

            if (grl_dinhkemfile != null)
            {
                grl_dinhkemfile.InitializeControl();
                string path = ConfigManager.PathGridViewXML() + ModuleName.KHVTheoNghiQuyet + @"\" + TemplateDesignGrid.GridView_KeHoachVonTheoNghiQuyet_DinhKemFile.ToString();
                grl_dinhkemfile.InitializeControlByDesign(path, CreateDesignGrid.NewGridView.ToString());

                GridView gridView = (GridView)grl_dinhkemfile.MainView;
                gridView.DoubleClick += Grl_dinhkemfile_DoubleClick;
                gridView.KeyUp += Grl_dinhkemfile_KeyUp;
                GetValueUploadFileGridView();
            }
        }
        #endregion

        #region Sự kiện trên lưới TreeList
        private void Tree_chitietkehoachvon_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                KeHoachVonNQChiTietDto objChiTiet = (KeHoachVonNQChiTietDto)tree_chitietkehoachvon.GetDataRecordByNode(tree_chitietkehoachvon.FocusedNode);
                DeleteRowKeHoachVonChiTiet(objChiTiet);
            }
        }

        private void Tree_chitietkehoachvon_CustomUnboundColumnData(object sender, TreeListCustomColumnDataEventArgs e)
        {
            var tree = sender as TreeList;
            List<KeHoachVonNQChiTietDto> moduleObject = (List<KeHoachVonNQChiTietDto>)tree.DataSource;
            var obj = (KeHoachVonNQChiTietDto)tree.GetDataRecordByNode(e.Node);
            if (obj != null)
            {
                if (e.IsGetData)
                {
                    if (e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDauNam.ToString()))
                   || e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString()))
                   || e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.DieuChinhGiam.ToString()))
                   || e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.DieuChinhTang.ToString()))
                   || e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDieuChinh.ToString()))
                   || e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString())))
                    {

                        if (obj.Value != null && obj.Value.Where(x => x.Key.ToString().ToLower().Trim() == e.Column.FieldName.ToString().ToLower().Trim()).Count() > 0)
                        {
                            e.Value = obj.Value[e.Column.FieldName];
                        }
                        else
                        {
                            e.Value = 0;
                        }
                    }
                }
                if (e.IsSetData)
                {
                    bool isEdit = false;
                    if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString() &&
                          (e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDauNam.ToString()))
                        || e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString()))))
                    {
                        isEdit = true;
                    }
                    else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString() &&
                              (e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.DieuChinhGiam.ToString()))
                            || e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.DieuChinhTang.ToString()))
                            || e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDieuChinh.ToString()))
                            || e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString()))))
                    {
                        isEdit = true;
                    }
                    if (isEdit)
                    {
                        obj.Value[e.Column.FieldName] = (e.Value == null ? 0 : Convert.ToDecimal(e.Value));

                    }
                }
                SetValueTreelist(e.Column.FieldName, obj, moduleObject);
            }

        }

        private void SetValueTreelist(string fieldName, KeHoachVonNQChiTietDto obj, List<KeHoachVonNQChiTietDto> moduleObject)
        {
            //Set cac gia tri lien quan
            var objSumNghiQuyet = moduleObject.Where(x => x.CongTrinhId == Guid.Empty && x.NghiQuyetId == obj.NghiQuyetId).FirstOrDefault();

            if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
            {
                if (fieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDauNam.ToString())))
                {
                    obj.KeHoachVonDauNam = CaculateDictionaryValueByColumn(obj.Value, ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDauNam.ToString()));
                }
                else if (fieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString())))
                {
                    obj.KeHoachVonDauNamDuocDuyet = CaculateDictionaryValueByColumn(obj.Value, ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString()));
                }
            }
            else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
            {
                if (fieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.DieuChinhGiam.ToString()))
                                  || fieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.DieuChinhTang.ToString())))
                {
                    obj.DieuChinhGiam = CaculateDictionaryValueByColumn(obj.Value, ConvertStringColum(KeHoachVonNQChiTietColumn.DieuChinhGiam.ToString()));
                    obj.DieuChinhTang = CaculateDictionaryValueByColumn(obj.Value, ConvertStringColum(KeHoachVonNQChiTietColumn.DieuChinhTang.ToString()));

                    string idCongTrinh = fieldName.ToString().Split("_").ToList()[1];

                    string keyDieuChinh = string.Format("{0}_{1}", KeHoachVonNQChiTietColumn.KeHoachVonDieuChinh.ToString(), idCongTrinh);
                    string keyTang = string.Format("{0}_{1}", KeHoachVonNQChiTietColumn.DieuChinhTang.ToString(), idCongTrinh);
                    string keyGiam = string.Format("{0}_{1}", KeHoachVonNQChiTietColumn.DieuChinhGiam.ToString(), idCongTrinh);
                    string keyDauNam = string.Format("{0}_{1}", KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), idCongTrinh);

                    decimal valueDauNam = 0;
                    decimal valueTang = 0;
                    decimal valueGiam = 0;
                    if (obj.Value.Where(x => x.Key.ToString().ToLower().Trim() == keyDauNam.ToString().ToLower().Trim()).Count() > 0)
                    {
                        valueDauNam = obj.Value[keyDauNam];
                    }
                    if (obj.Value.Where(x => x.Key.ToString().ToLower().Trim() == keyTang.ToString().ToLower().Trim()).Count() > 0)
                    {
                        valueTang = obj.Value[keyTang];
                    }
                    if (obj.Value.Where(x => x.Key.ToString().ToLower().Trim() == keyGiam.ToString().ToLower().Trim()).Count() > 0)
                    {
                        valueGiam = obj.Value[keyGiam];
                    }
                    if (obj.Value.Where(x => x.Key.ToString().ToLower().Trim() == keyDieuChinh.ToString().ToLower().Trim()).Count() > 0)
                    {
                        obj.Value[keyDieuChinh] = valueDauNam + valueTang - valueGiam;
                    }
                    obj.KeHoachVonDieuChinh = CaculateDictionaryValueByColumn(obj.Value, ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDieuChinh.ToString()));

                    //Sum lên nghị quyết
                    if (objSumNghiQuyet != null)
                    {
                        objSumNghiQuyet.Value[keyDieuChinh] = CaculateValueSumCongTrinhByNghiQuyet(moduleObject, objSumNghiQuyet.NghiQuyetId, keyDieuChinh);
                        objSumNghiQuyet.DieuChinhGiam = CaculateDictionaryValueByColumn(objSumNghiQuyet.Value, ConvertStringColum(KeHoachVonNQChiTietColumn.DieuChinhGiam.ToString()));
                        objSumNghiQuyet.DieuChinhTang = CaculateDictionaryValueByColumn(objSumNghiQuyet.Value, ConvertStringColum(KeHoachVonNQChiTietColumn.DieuChinhTang.ToString()));
                        objSumNghiQuyet.KeHoachVonDieuChinh = CaculateDictionaryValueByColumn(objSumNghiQuyet.Value, ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDieuChinh.ToString()));
                    }
                }
                else if (fieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString())))
                {
                    obj.KeHoachVonDieuChinhDuocDuyet = CaculateDictionaryValueByColumn(obj.Value, ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString()));
                }
            }
            //Sum lên nghị quyết
            if (objSumNghiQuyet != null)
            {
                bool isEdit = false;
                if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString() &&
                      (fieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDauNam.ToString()))
                    || fieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString()))))
                {
                    isEdit = true;
                }
                else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString() &&
                          (fieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.DieuChinhGiam.ToString()))
                        || fieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.DieuChinhTang.ToString()))
                        || fieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDieuChinh.ToString()))
                        || fieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString()))))
                {
                    isEdit = true;
                }
                if (isEdit)
                {
                    objSumNghiQuyet.Value[fieldName] = CaculateValueSumCongTrinhByNghiQuyet(moduleObject, objSumNghiQuyet.NghiQuyetId, fieldName);
                }
            }

        }

        private void Tree_chitietkehoachvon_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            var tree = sender as TreeList;
            TreeListColumn column = e.Column;
            if (column != null && (column.FieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDauNam.ToString()))
                                    || column.FieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString()))
                                    || column.FieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.DieuChinhTang.ToString()))
                                    || column.FieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.DieuChinhGiam.ToString()))
                                    || column.FieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDieuChinh.ToString()))
                                    || column.FieldName.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString()))
                                    ))
            {
                bool isReadOnly = false;
                List<KeHoachVonNQChiTietDto> moduleObject = (List<KeHoachVonNQChiTietDto>)tree.DataSource;
                var obj = (KeHoachVonNQChiTietDto)tree.GetDataRecordByNode(e.Node);
                if (obj != null && moduleObject != null)
                {
                    if (obj.CongTrinhId == Guid.Empty)
                    {
                        isReadOnly = true;
                    }
                }
                RepositoryItemTextEdit repositoryItem = new RepositoryItemTextEdit();
                repositoryItem.EditFormat.FormatType = FormatType.Numeric;
                repositoryItem.EditFormat.FormatString = FormatValue.N3;
                repositoryItem.DisplayFormat.FormatType = FormatType.Numeric;
                repositoryItem.DisplayFormat.FormatString = FormatValue.N3;
                repositoryItem.Mask.MaskType = MaskType.Numeric;
                repositoryItem.Mask.UseMaskAsDisplayFormat = true;
                repositoryItem.Mask.EditMask = "n3";
                repositoryItem.ReadOnly = isReadOnly;
                e.RepositoryItem = repositoryItem;
            }
        }

        private void Tree_chitietkehoachvon_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            var tree = sender as TreeList;
            if (e.Node != null)
            {
                if (tree != null && tree.DataSource != null)
                {
                    List<KeHoachVonNQChiTietDto> moduleObject = (List<KeHoachVonNQChiTietDto>)tree.DataSource;
                    var obj = (KeHoachVonNQChiTietDto)tree.GetDataRecordByNode(e.Node);
                    if (obj != null && moduleObject != null)
                    {
                        if (obj.CongTrinhId == Guid.Empty)
                        {

                            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                        }
                        else
                        {
                            e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Regular);
                        }
                    }
                    else
                    {
                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Regular);
                    }
                }

            }
        }

        private void Tree_chitietkehoachvon_GetCustomSummaryValue(object sender, GetCustomSummaryValueEventArgs e)
        {
            if (e.IsSummaryFooter)
            {
                if (e.Column.FieldName.Contains(KeHoachVonNQChiTietColumn.KeHoachVonDauNam.ToString())
                    || e.Column.FieldName.Contains(KeHoachVonNQChiTietColumn.KeHoachVonDieuChinh.ToString())
                    || e.Column.FieldName.Contains(KeHoachVonNQChiTietColumn.DieuChinhGiam.ToString())
                    || e.Column.FieldName.Contains(KeHoachVonNQChiTietColumn.DieuChinhTang.ToString())
                    || e.Column.FieldName == KeHoachVonNQChiTietColumn.LuyKeVonNamTruoc.ToString()
                    || e.Column.FieldName == KeHoachVonNQChiTietColumn.LuyKeVonTongCong.ToString()
                   )
                {
                    e.CustomValue = CaculateGetSumByColumnByFormat(e.Column.FieldName, FormatValue.N3);
                }

            }
        }

        #endregion

        #region CaculateNode
        private decimal CaculateValueSumCongTrinhByNghiQuyet(List<KeHoachVonNQChiTietDto> moduleObject, Guid nghiQuyetID, string column)
        {
            decimal value = moduleObject.Where(x => x.CongTrinhId != Guid.Empty && x.NghiQuyetId == nghiQuyetID)
                                                                                        .Sum(o => o.Value.Where(x => x.Key == column).Sum(x => x.Value));
            return value;
        }
        private decimal CaculateDictionaryValueByColumn(Dictionary<string, decimal> dictionary, string column)
        {
            decimal value = dictionary.Where(x => x.Key.Contains(column)).Sum(x => x.Value);
            return value;
        }

        public string CaculateGetSumByColumnByFormat(string column, string format)
        {
            return String.Format(format, GetSumByColumn(column));
        }
        public decimal GetSumByColumn(string column)
        {
            decimal result = 0;
            if (tree_chitietkehoachvon.DataSource != null)
            {
                List<KeHoachVonNQChiTietDto> moduleObject = (List<KeHoachVonNQChiTietDto>)tree_chitietkehoachvon.DataSource;
                if (moduleObject != null || moduleObject.Count == 0)
                {
                    if (_mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachTongNguon.DAU_NAM.ToString().ToLower().Trim())
                    {
                        moduleObject = moduleObject.Where(x => x.IsSelectDieuChinh == false).ToList();
                    }
                    else if (_mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachTongNguon.DIEU_CHINH.ToString().ToLower().Trim())
                    {
                        moduleObject = moduleObject.Where(x => x.IsDeleteDieuChinh == false).ToList();
                    }
                    if (column.Contains("_"))
                    {
                        result = moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(o => o.Value.Where(x => x.Key == column).Sum(x => x.Value));
                    }
                    else
                    {
                        if (column == KeHoachVonNQChiTietColumn.KeHoachVonDauNam.ToString())
                        {
                            result = moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(x => x.KeHoachVonDauNam);
                        }
                        else if (column == KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString())
                        {
                            result = moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(x => x.KeHoachVonDauNamDuocDuyet);
                        }
                        else if (column == KeHoachVonNQChiTietColumn.KeHoachVonDieuChinh.ToString())
                        {
                            result = moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(x => x.KeHoachVonDieuChinh);
                        }
                        else if (column == KeHoachVonNQChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString())
                        {
                            result = moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(x => x.KeHoachVonDieuChinhDuocDuyet);
                        }
                        else if (column == KeHoachVonNQChiTietColumn.DieuChinhGiam.ToString())
                        {
                            result = moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(x => x.DieuChinhGiam);
                        }
                        else if (column == KeHoachVonNQChiTietColumn.DieuChinhTang.ToString())
                        {
                            result = moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(x => x.DieuChinhTang);
                        }
                        else if (column == KeHoachVonNQChiTietColumn.LuyKeVonNamTruoc.ToString())
                        {
                            result = moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(x => x.LuyKeVonNamTruoc);
                        }
                        else if (column == KeHoachVonNQChiTietColumn.LuyKeVonTongCong.ToString())
                        {
                            result = moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(x => x.LuyKeVonTongCong);
                        }
                    }
                }
            }
            return Math.Round(result, 6, MidpointRounding.AwayFromZero);
        }
        #endregion

        #region Bind/Enabale EntityControl
        public void RefreshControlByAction()
        {
            GetDataKeHoachVonChiTiet();
            RefreshLayoutBandedGridView(new List<NguonVonDto>());
            RefreshDataSourceDetail();
            InitBindEntityToControl(box_thongtinchung.Controls, _mainObject);
            EnabaleControl();
        }

        public void LoadControlByLoaiKeHoach()
        {
            if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
            {
                cbbTrangThai.GGDataMember = KeHoachVonNQColumn.TrangThaiDauNam.ToString();
                dte_ngayquyetdinh.GGDataMember = KeHoachVonNQColumn.NgayBanHanhDauNam.ToString();
                txt_soquyetdinh.GGDataMember = KeHoachVonNQColumn.SoQuyetDinhDauNam.ToString();
            }
            else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
            {
                cbbTrangThai.GGDataMember = KeHoachVonNQColumn.TrangThaiDieuChinh.ToString();
                dte_ngayquyetdinh.GGDataMember = KeHoachVonNQColumn.NgayBanHanhDieuChinh.ToString();
                txt_soquyetdinh.GGDataMember = KeHoachVonNQColumn.SoQuyetDinhDieuChinh.ToString();
            }
        }

        public void EnabaleControl()
        {
            if (_mainObject.TrangThai == TrangThaiKeHoachVon.DANG_SOAN.ToString())
            {
                dte_ngayquyetdinh.Enabled = false;
                txt_soquyetdinh.Enabled = false;
                btn_Save.Enabled = true;
                btn_Confirm.Enabled = true;
                btn_Request.Enabled = false;
                btn_Approval.Enabled = false;
                btn_Complete.Enabled = false;
                btn_Cancel.Enabled = true;
                btn_AddNguonVon.Enabled = true;
                btn_AddCongTrinh.Enabled = true;
                box_AttachedFile.Enabled = false;
                btn_UpLoadFile.Enabled = false;
            }
            else if (_mainObject.TrangThai == TrangThaiKeHoachVon.DA_TRINH.ToString())
            {
                dte_ngayquyetdinh.Enabled = false;
                txt_soquyetdinh.Enabled = false;
                btn_Save.Enabled = false;
                btn_Confirm.Enabled = false;
                btn_Request.Enabled = true;
                btn_Approval.Enabled = true;
                btn_Complete.Enabled = false;
                btn_Cancel.Enabled = true;
                btn_AddNguonVon.Enabled = false;
                btn_AddCongTrinh.Enabled = false;
                box_AttachedFile.Enabled = false;
                btn_UpLoadFile.Enabled = false;
            }
            else if (_mainObject.TrangThai == TrangThaiKeHoachVon.YEU_CAU_CHINH_SUA.ToString())
            {
                dte_ngayquyetdinh.Enabled = false;
                txt_soquyetdinh.Enabled = false;
                btn_Save.Enabled = true;
                btn_Confirm.Enabled = true;
                btn_Request.Enabled = false;
                btn_Approval.Enabled = false;
                btn_Complete.Enabled = false;
                btn_Cancel.Enabled = true;
                btn_AddNguonVon.Enabled = true;
                btn_AddCongTrinh.Enabled = true;
                box_AttachedFile.Enabled = false;
                btn_UpLoadFile.Enabled = false;
            }
            else if (_mainObject.TrangThai == TrangThaiKeHoachVon.DUYET.ToString())
            {
                dte_ngayquyetdinh.Enabled = true;
                txt_soquyetdinh.Enabled = true;
                btn_Save.Enabled = true;
                btn_Confirm.Enabled = false;
                btn_Request.Enabled = false;
                btn_Approval.Enabled = false;
                btn_Complete.Enabled = true;
                btn_Cancel.Enabled = true;
                btn_AddNguonVon.Enabled = false;
                btn_AddCongTrinh.Enabled = false;
                box_AttachedFile.Enabled = true;
                btn_UpLoadFile.Enabled = true;
            }
            else if (_mainObject.TrangThai == TrangThaiKeHoachVon.HOAN_THANH.ToString())
            {
                dte_ngayquyetdinh.Enabled = false;
                txt_soquyetdinh.Enabled = false;
                btn_Save.Enabled = false;
                btn_Confirm.Enabled = false;
                btn_Request.Enabled = false;
                btn_Approval.Enabled = false;
                btn_Complete.Enabled = false;
                btn_Cancel.Enabled = true;
                btn_AddNguonVon.Enabled = false;
                btn_AddCongTrinh.Enabled = false;
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

        public void InitBindEntityToControl(Control.ControlCollection controls, KeHoachVonNQDto obj)
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

        #endregion

        #region Đính kèm file
        private void Grl_dinhkemfile_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                GridView gridView = (GridView)sender;
                var item = (FileColumnViewModel)gridView.GetRow(gridView.FocusedRowHandle);
                if (item != null && _mainObject.TrangThai != TrangThaiKeHoachVon.HOAN_THANH.ToString())
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
            if (_mainObject.TrangThai != TrangThaiKeHoachVon.HOAN_THANH.ToString())
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
            if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
            {
                if (!string.IsNullOrWhiteSpace(_mainObject.DinhKemFileDauNam))
                {
                    text = _mainObject.DinhKemFileDauNam;
                }
            }
            else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
            {
                if (!string.IsNullOrWhiteSpace(_mainObject.DinhKemFileDieuChinh))
                {
                    text = _mainObject.DinhKemFileDieuChinh;
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

        #endregion Đính kèm file

        #region GetValueMainControl

        public void GetValueMainControl()
        {
            // Danh sách trạng thái
            cbbTrangThai.ColumnsCaption = new string[1] { ComboBaseControl.Value.GetDescription().ToString() };
            cbbTrangThai.FieldsName = new string[1] { ComboBaseControl.Value.ToString() };
            cbbTrangThai.ValueMember = ComboBaseControl.Key.ToString();
            cbbTrangThai.DisplayMember = ComboBaseControl.Value.ToString();
            cbbTrangThai.DataSource = typeof(TrangThaiKeHoachVon).ToList();
            cbbTrangThai.cboBase.CustomDisplayText += cbbTrangThai_CustomDisplayText;
            cbbTrangThai.ShowData();

            //Nam
            cbe_nam.Properties.Items.AddRange(GGFunctions.GetValueNam());

            //LoaiKeHoach
            cbb_LoaiKeHoach.ColumnsCaption = new string[1] { ComboBaseControl.Value.GetDescription().ToString() };
            cbb_LoaiKeHoach.FieldsName = new string[1] { ComboBaseControl.Value.ToString() };
            cbb_LoaiKeHoach.ValueMember = ComboBaseControl.Key.ToString();
            cbb_LoaiKeHoach.DisplayMember = ComboBaseControl.Value.ToString();
            cbb_LoaiKeHoach.DataSource = typeof(LoaiKeHoachVon).ToList();
            cbb_LoaiKeHoach.cboBase.CustomDisplayText += cbb_LoaiKeHoach_CustomDisplayText;
            cbb_LoaiKeHoach.ShowData();
        }

        private void cbb_LoaiKeHoach_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value != null && e.DisplayText != null)
            {
                LoaiKeHoachVon myStatus;
                Enum.TryParse(e.Value.ToString(), out myStatus);
                e.DisplayText = typeof(LoaiKeHoachVon).GetValueByKey(myStatus);
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
                TrangThaiKeHoachVon myStatus;
                Enum.TryParse(e.Value.ToString(), out myStatus);
                e.DisplayText = typeof(LoaiKeHoachVon).GetValueByKey(myStatus);
            }
            else
            {
                e.DisplayText = null;
            }
        }

        #endregion GetValueMainControl

        #region Action Đóng
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
        }

        private void btn_Cancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        #endregion Action Đóng

        #region Action Lưu
        private async void btn_Save_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_isNew == true)
            {
                if (!ValidateNew())
                    return;
            }
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);
            await Save(_mainObject.TrangThai, _mainObject.LoaiKeHoach);
            //
            _isNew = false;
            SplashScreenManager.CloseForm();
            GGFunctions.ShowMessage("Lưu thành công!");
        }

        public async Task Save(string trangthai, string loaikehoach)
        {
            _moduleObject = (List<KeHoachVonNQChiTietDto>)tree_chitietkehoachvon.DataSource;
            SetValueBySave();
            var result = GGMapper<KeHoachVonNQDto, CreateUpdateKeHoachVonNQDto>.MapSimple(_mainObject);

            var api = ConfigManager.GetAPIByService<IKeHoachVonNQsApi>();

            if (_mainObject.Id == Guid.Empty)
            {
                _mainObject = await api.Create(result);
                _mainObject.TrangThai = trangthai;
                _mainObject.LoaiKeHoach = loaikehoach;
            }
            else
            {
                await api.Update(_mainObject.Id, result);
            }
            //Delete Detail
            var apiDetatil = ConfigManager.GetAPIByService<IKeHoachVonNQChiTietsApi>();
            var dataChiTietOld = apiDetatil.GetListByKeHoachVonNQIdAsync(_mainObject.Id).GetAwaiter().GetResult();
            if (dataChiTietOld != null && dataChiTietOld.Count > 0)
            {
                List<Guid> guidList = _moduleObject.Where(x => x.Id != Guid.Empty).Select(x => x.Id).Distinct().ToList();
                // Xóa đầu năm
                if (_mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachTongNguon.DAU_NAM.ToString().ToLower().Trim())
                {
                    var listDelete = dataChiTietOld.Where(x => !guidList.Contains(x.Id) && x.IsSelectDieuChinh == false);
                    if (listDelete != null && listDelete.Count() > 0)
                    {
                        listDelete.ForEach(o =>
                        {
                            if (o.Id != null && o.Id != Guid.Empty)
                                apiDetatil.Delete(o.Id).GetAwaiter().GetResult();
                        });
                    }
                }
                //Xóa điều chỉnh
                else if (_mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachTongNguon.DIEU_CHINH.ToString().ToLower().Trim())
                {
                    var listDelete = dataChiTietOld.Where(x => !guidList.Contains(x.Id) && x.IsDeleteDieuChinh == false);
                    if (listDelete != null && listDelete.Count() > 0)
                    {
                        listDelete.ForEach(o =>
                        {
                            if (o.Id != null && o.Id != Guid.Empty)
                                apiDetatil.DeleteKeHoachVonNQDieuChinhChiTietById(o.Id).GetAwaiter().GetResult();
                        });
                    }
                }

            }
            //CreateUpdate Detail
            _moduleObject.ForEach(o =>
            {
                o.KeHoachVonNQId = _mainObject.Id;
                if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
                {
                    o.StringKeHoachVonDauNam = JsonConvert.SerializeObject(o.Value.Where(x => x.Key.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDauNam.ToString()))));
                    o.StringKeHoachVonDauNamDuocDuyet = JsonConvert.SerializeObject(o.Value.Where(x => x.Key.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString()))));
                }
                else
                {
                    o.StringDieuChinhGiam = JsonConvert.SerializeObject(o.Value.Where(x => x.Key.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.DieuChinhGiam.ToString()))));
                    o.StringDieuChinhTang = JsonConvert.SerializeObject(o.Value.Where(x => x.Key.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.DieuChinhTang.ToString()))));
                    o.StringKeHoachVonDieuChinh = JsonConvert.SerializeObject(o.Value.Where(x => x.Key.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDieuChinh.ToString()))));
                    o.StringKeHoachVonDieuChinhDuocDuyet = JsonConvert.SerializeObject(o.Value.Where(x => x.Key.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString()))));
                }
                var objDetail = GGMapper<KeHoachVonNQChiTietDto, CreateUpdateKeHoachVonNQChiTietDto>.MapSimple(o);
                if (o.Id == Guid.Empty)
                {
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
            if (_mainObject.TrangThai == TrangThaiKeHoachVon.DUYET.ToString()
                || _mainObject.TrangThai == TrangThaiKeHoachVon.HOAN_THANH.ToString())
            {
                //Lưu file Update
                SaveFileDinhKem();
                List<FileColumnViewModel> listData = (List<FileColumnViewModel>)grl_dinhkemfile.DataSource;
                string strFile = string.Empty;
                if (listData != null && listData.Count > 0)
                {
                    var listString = listData.Where(x => x.Id != Guid.Empty).Select(x => x.Id.ToString()).Distinct();
                    if (listString != null)
                    {
                        strFile = string.Join(";", listString);
                    }
                }
                if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
                {
                    _mainObject.DinhKemFileDauNam = strFile;
                }
                else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
                {
                    _mainObject.DinhKemFileDieuChinh = strFile;
                }
            }
            if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
            {
                _mainObject.KeHoachVonDauNam = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(x => x.KeHoachVonDauNam);
                _mainObject.KeHoachVonDauNamDuocDuyet = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(x => x.KeHoachVonDauNamDuocDuyet);
            }
            else
            {
                _mainObject.KeHoachVonDieuChinh = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(x => x.KeHoachVonDieuChinh);
                _mainObject.KeHoachVonDieuChinhDuocDuyet = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(x => x.KeHoachVonDieuChinhDuocDuyet);
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
            var api = ConfigManager.GetAPIByService<IKeHoachVonNQsApi>();
            var data = api.GetSearchData(Convert.ToInt32(_mainObject.Nam), string.Empty, string.Empty).GetAwaiter().GetResult();
            if (data != null && data.Count > 0)
            {

                //1.Đã tồn tại năm đó (cùng loại kế hoạch) không cho thêm mới
                if (data.Where(x => x.LoaiKeHoach == _mainObject.LoaiKeHoach.ToString()).Count() > 0)
                {
                    GGFunctions.ShowMessage("Năm và loại kế hoạch này đã phát sinh dữ liệu trên hệ thống, Vui lòng kiểm tra lại!");
                    isCheck = false;
                    return isCheck;
                }
                //2.Đã làm kế hoạch điều chỉnh thì không được làm kế hoạch đầu năm
                else if (_mainObject.LoaiKeHoach.ToString() == LoaiKeHoachVon.DAU_NAM.ToString()
                    && data.Where(x => x.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString()).Count() > 0)
                {
                    GGFunctions.ShowMessage("Năm này đã làm kế hoạch điều chỉnh nên không được làm kế hoạch đầu năm, Vui lòng kiểm tra lại!");
                    isCheck = false;
                    return isCheck;
                }
            }
            _moduleObject = (List<KeHoachVonNQChiTietDto>)tree_chitietkehoachvon.DataSource;
            if (_moduleObject == null || _moduleObject.Count == 0)
            {
                GGFunctions.ShowMessage("Vui lòng nhập nhập thông tin chi tiết để lưu dữ liệu chi tiết!");
                isCheck = false;
                return isCheck;
            }
            if (_moduleObject[0].Value == null || _moduleObject[0].Value.Count == 0)
            {
                GGFunctions.ShowMessage("Vui lòng chọn nguồn vốn để bố trí kế hoạch vốn!");
                isCheck = false;
                return isCheck;
            }
            return isCheck;
        }

        #endregion Action Lưu

        #region Action Tải lại dữ liệu công trình
        private void btn_AddCongTrinh_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);
            _moduleObject = (List<KeHoachVonNQChiTietDto>)tree_chitietkehoachvon.DataSource;
            if (_moduleObject != null)
            {
                var apiNghiQuyet = ConfigManager.GetAPIByService<INghiQuyetsApi>();
                var listNghiQuyetID = _moduleObject.Where(x => x.CongTrinhId == Guid.Empty && x.NghiQuyetId != Guid.Empty).Select(x => x.NghiQuyetId).Distinct();
                if (listNghiQuyetID != null && listNghiQuyetID.Count() > 0)
                {
                    listNghiQuyetID.ToList().ForEach(o =>
                    {
                        var apiKHVChiTiet = ConfigManager.GetAPIByService<IKeHoachVonNQChiTietsApi>();
                        List<KeHoachVonNQChiTietDto> listLuyKe = apiKHVChiTiet.GetDataLuyKeByNam(_mainObject.Nam - 1).GetAwaiter().GetResult();
                        if (listLuyKe == null)
                            listLuyKe = new List<KeHoachVonNQChiTietDto>();

                        KeHoachVonNQChiTietDto objvonNQ = _moduleObject.Where(x => x.NghiQuyetId == o && x.CongTrinhId == Guid.Empty).FirstOrDefault();

                        List<NghiQuyetCongTrinhDto> listNghiQuyetCongTrinh = new List<NghiQuyetCongTrinhDto>();
                        NghiQuyetDto listNghiQuyet = apiNghiQuyet.GetAsync(o).GetAwaiter().GetResult();
                        if (listNghiQuyet != null
                            && listNghiQuyet.NghiQuyetCongTrinhs != null
                            && listNghiQuyet.NghiQuyetCongTrinhs.Count > 0)
                        {
                            listNghiQuyetCongTrinh = listNghiQuyet.NghiQuyetCongTrinhs;
                        }
                        //Thêm mới
                        listNghiQuyetCongTrinh.ForEach(u =>
                        {
                            bool isCheckNew = false;
                            bool selectDieuChinh = false;
                            if (_mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachVon.DAU_NAM.ToString().ToLower().Trim())
                            {
                                if (_moduleObject.Where(x => x.IsSelectDieuChinh == false && x.NghiQuyetId == o && x.CongTrinhId == u.CongTrinhId).Count() == 0)
                                {
                                    isCheckNew = true;
                                }
                            }
                            else if (_mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachVon.DIEU_CHINH.ToString().ToLower().Trim())
                            {
                                if (_moduleObject.Where(x => x.IsDeleteDieuChinh == false && x.NghiQuyetId == o && x.CongTrinhId == u.CongTrinhId).Count() == 0)
                                {
                                    isCheckNew = true;
                                    selectDieuChinh = true;
                                }
                            }
                            if (isCheckNew && objvonNQ != null)
                            {
                                KeHoachVonNQChiTietDto obj = AddDataCongTrinh(objvonNQ.NghiQuyetId, u.CongTrinhId, objvonNQ.KeHoachVonId, listLuyKe);
                                if (obj != null && obj.CongTrinhId != Guid.Empty)
                                {
                                    obj.IsSelectDieuChinh = selectDieuChinh;
                                    if (objvonNQ.Value != null && objvonNQ.Value.Count > 0)
                                    {
                                        obj.Value = new Dictionary<string, decimal>();
                                        List<string> keyValues = new List<string>(objvonNQ.Value.Keys);
                                        keyValues.ForEach(k =>
                                        {
                                            obj.Value.Add(k, 0);
                                        });
                                    }
                                    _moduleObject.Add(obj);
                                }
                            }
                        });

                        //Xóa công trình
                        List<Guid> listIDCongTrinh = listNghiQuyetCongTrinh.Select(u => u.CongTrinhId).Distinct().ToList();
                        var deleteData = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty && x.NghiQuyetId == o && !listIDCongTrinh.Contains(x.CongTrinhId)).ToList();
                        if (deleteData != null && deleteData.Count > 0)
                        {
                            deleteData.ForEach(u =>
                            {
                                _moduleObject.Remove(u);
                            });
                        }

                    });
                }
                RefreshDataSourceDetail();
                SplashScreenManager.CloseForm();
                GGFunctions.ShowMessage("Đã tải lại dữ liệu công trinh thành công!");

            }
            else
            {
                SplashScreenManager.CloseForm();
                GGFunctions.ShowMessage("Chưa có thông tin chi tiết! Vui lòng kiểm tra lại!");
                return;
            }
        }
        #endregion Action Tải lại dữ liệu

        #region Action Trình

        private async void btn_Confirm_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_isNew == true)
            {
                if (!ValidateNew())
                    return;
            }
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);

            if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
            {
                _mainObject.TrangThaiDauNam = TrangThaiKeHoachVon.DA_TRINH.ToString();
            }
            else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
            {
                _mainObject.TrangThaiDieuChinh = TrangThaiKeHoachVon.DA_TRINH.ToString();
            }
            _mainObject.TrangThai = TrangThaiKeHoachVon.DA_TRINH.ToString();
            await Save(_mainObject.TrangThai, _mainObject.LoaiKeHoach);
            _isNew = false;
            SplashScreenManager.CloseForm();
            GGFunctions.ShowMessage("Trình thành công!");
        }
        #endregion

        #region Yêu cầu chỉnh sửa
        private async void btn_Request_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);

            if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
            {
                _mainObject.TrangThaiDauNam = TrangThaiKeHoachVon.YEU_CAU_CHINH_SUA.ToString();
            }
            else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
            {
                _mainObject.TrangThaiDieuChinh = TrangThaiKeHoachVon.YEU_CAU_CHINH_SUA.ToString();
            }

            _mainObject.TrangThai = TrangThaiKeHoachVon.YEU_CAU_CHINH_SUA.ToString();
            await Save(_mainObject.TrangThai, _mainObject.LoaiKeHoach);
            SplashScreenManager.CloseForm();
            GGFunctions.ShowMessage("Yêu cầu chỉnh sửa thành công!");
        }

        #endregion

        #region Action Duyệt
        private async void btn_Approval_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);
            if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
            {
                _mainObject.TrangThaiDauNam = TrangThaiKeHoachVon.DUYET.ToString();
                _mainObject.NgayBanHanhDauNam = DateTime.Now.Date;
            }
            else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
            {
                _mainObject.TrangThaiDieuChinh = TrangThaiKeHoachVon.DUYET.ToString();
                _mainObject.NgayBanHanhDieuChinh = DateTime.Now.Date;
            }

            _mainObject.TrangThai = TrangThaiKeHoachVon.DUYET.ToString();
            SetValueByApproval();
            await Save(_mainObject.TrangThai, _mainObject.LoaiKeHoach);

            SplashScreenManager.CloseForm();
            GGFunctions.ShowMessage("Duyệt thành công!");
        }
        public void SetValueByApproval()
        {
            List<KeHoachVonNQChiTietDto> moduleObject = (List<KeHoachVonNQChiTietDto>)tree_chitietkehoachvon.DataSource;
            //Copy Data
            if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
            {
                moduleObject.ForEach(o =>
                {
                    o.KeHoachVonDauNamDuocDuyet = o.KeHoachVonDauNam;

                    List<string> keyValues = new List<string>(o.Value.Keys);
                    keyValues.ForEach(u =>
                    {
                        if (u.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString())))
                        {
                            string key = u.Replace(KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), KeHoachVonNQChiTietColumn.KeHoachVonDauNam.ToString());
                            o.Value[u] = o.Value[key];
                        }
                    });
                });
            }
            else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
            {
                moduleObject.ForEach(o =>
                {
                    o.KeHoachVonDieuChinhDuocDuyet = o.KeHoachVonDieuChinh;

                    List<string> keyValues = new List<string>(o.Value.Keys);
                    keyValues.ForEach(u =>
                    {
                        if (u.Contains(ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString())))
                        {
                            string key = u.Replace(KeHoachVonNQChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString(), KeHoachVonNQChiTietColumn.KeHoachVonDieuChinh.ToString());
                            o.Value[u] = o.Value[key];
                        }
                    });
                });
            }
        }

        #endregion Action Duyệt

        #region Hoàn thành

        private async void btn_Complete_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<FileColumnViewModel> listData = (List<FileColumnViewModel>)grl_dinhkemfile.DataSource;
            if (listData == null || listData.Count == 0)
            {
                GGFunctions.ShowMessage("Vui lòng đính kèm file!");
                return;
            }
            if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
            {
                if (string.IsNullOrWhiteSpace(_mainObject.SoQuyetDinhDauNam))
                {
                    GGFunctions.ShowMessage("Vui lòng nhập số quyết định!");
                    return;
                }
                else if (_mainObject.NgayBanHanhDauNam == null)
                {
                    GGFunctions.ShowMessage("Vui lòng nhập ngày ban hành!");
                    return;
                }
                _mainObject.TrangThaiDauNam = TrangThaiKeHoachVon.HOAN_THANH.ToString();
            }
            else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
            {
                if (string.IsNullOrWhiteSpace(_mainObject.SoQuyetDinhDieuChinh))
                {
                    GGFunctions.ShowMessage("Vui lòng nhập số quyết định!");
                    return;
                }
                else if (_mainObject.NgayBanHanhDieuChinh == null)
                {
                    GGFunctions.ShowMessage("Vui lòng nhập ngày ban hành!");
                    return;
                }
                _mainObject.TrangThaiDieuChinh = TrangThaiKeHoachVon.HOAN_THANH.ToString();
            }
            _mainObject.TrangThai = TrangThaiKeHoachVon.HOAN_THANH.ToString();
            await Save(_mainObject.TrangThai, _mainObject.LoaiKeHoach);
            GGFunctions.ShowMessage("Hoàn thành thành công!");
        }

        #endregion Hoàn thành

        #region Delete Row Chi Tiet
        public void DeleteRowKeHoachVonChiTiet(KeHoachVonNQChiTietDto objDetail)
        {
            if (_mainObject.TrangThai == TrangThaiKeHoachTongNguon.DANG_SOAN.ToString()
                || _mainObject.TrangThai == TrangThaiKeHoachTongNguon.YEU_CAU_CHINH_SUA.ToString())
            {
                List<KeHoachVonNQChiTietDto> moduleObject = (List<KeHoachVonNQChiTietDto>)tree_chitietkehoachvon.DataSource;
                if (objDetail != null && moduleObject != null)
                {
                    if (objDetail.CongTrinhId == Guid.Empty)
                    {
                        GGFunctions.ShowMessage("Chỉ được phép xóa dòng dữ liệu công trình, Vui lòng kiểm tra lại!");
                        return;
                    }
                    moduleObject.Remove(objDetail);
                    tree_chitietkehoachvon.RefreshDataSource();
                    SetPropertyTreeList();
                }
            }
        }
        #endregion

        #region Xuất excel

        private void btn_ExportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_mainObject != null && _mainObject.Id != Guid.Empty)
            {
                ((KHVTheoNghiQuyetModule)Module).SetValueAndControl(_mainObject);
                ((KHVTheoNghiQuyetModule)Module).ExportExcel();
            }
            else
            {
                GGFunctions.ShowMessage("Dữ liệu chưa được lưu nên không thể xuất file excel!");
            }
        }

        #endregion

        #region Thêm nguồn vốn
        private void btn_AddNguonVon_Click(object sender, EventArgs e)
        {
            List<NguonVonDto> list = new List<NguonVonDto>();
            if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
            {
                list = GetValueNguonVonByColumn(_moduleObject[0].Value, ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDauNam.ToString()));
            }
            else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
            {
                list = GetValueNguonVonByColumn(_moduleObject[0].Value, ConvertStringColum(KeHoachVonNQChiTietColumn.KeHoachVonDieuChinh.ToString()));
            }

            guiNguonVon gui = new guiNguonVon(list);
            gui.Module = Module;
            if (gui.ShowDialog() == DialogResult.OK)
            {
                RefreshLayoutBandedGridView(gui.listNguonVon);

                RefreshDataByLayOut();

                RefreshDataSourceDetail();
            }
        }

        #endregion

        #region Create DataSource
        private void GetDataKeHoachVonChiTiet()
        {
            if (_moduleObject == null)
            {
                _moduleObject = new List<KeHoachVonNQChiTietDto>();
            }
            if (_mainObject.Id == Guid.Empty)
            {
                GetDataKeHoachVonChiTietByNew();
            }
            else
            {
                GetDataKeHoachVonChiTietByEdit();
            }
        }

        private void GetDataKeHoachVonChiTietByNew()
        {
            var apiNghiQuyet = ConfigManager.GetAPIByService<INghiQuyetsApi>();

            ((KHVTheoNghiQuyetModule)Module).GetDataNghiQuyet();

            var listNghiQuyet = ((KHVTheoNghiQuyetModule)Module)._listNghiQuyet.Where(x => x.IsTheoDoi == true);

            var apiKHVChiTiet = ConfigManager.GetAPIByService<IKeHoachVonNQChiTietsApi>();
            List<KeHoachVonNQChiTietDto> listLuyKe = apiKHVChiTiet.GetDataLuyKeByNam(_mainObject.Nam - 1).GetAwaiter().GetResult();
            if (listLuyKe == null)
            {
                listLuyKe = new List<KeHoachVonNQChiTietDto>();
            }

            if (listNghiQuyet != null && listNghiQuyet.Count() > 0)
            {
                foreach (NghiQuyetDto item in listNghiQuyet)
                {
                    //Thêm danh mục nghị quyết
                    KeHoachVonNQChiTietDto obj = new KeHoachVonNQChiTietDto();
                    obj.TenDanhMuc = item.TrichYeu;
                    obj.NghiQuyetId = item.Id;
                    obj.KeHoachVonId = Guid.NewGuid();
                    _moduleObject.Add(obj);
                    //Thêm danh mục công trình cho nghị quyết
                    NghiQuyetDto listNghiQuyetCongTrinh = apiNghiQuyet.GetAsync(item.Id).GetAwaiter().GetResult();
                    if (listNghiQuyetCongTrinh != null
                        && listNghiQuyetCongTrinh.NghiQuyetCongTrinhs != null
                        && listNghiQuyetCongTrinh.NghiQuyetCongTrinhs.Count > 0)
                    {
                        listNghiQuyetCongTrinh.NghiQuyetCongTrinhs.ForEach(o =>
                        {
                            CongTrinhDto objCongTrinh = ((KHVTheoNghiQuyetModule)Module)._listCongTrinh.Where(x => x.Id == o.CongTrinhId).FirstOrDefault();
                            if (objCongTrinh != null && objCongTrinh.Id != Guid.Empty)
                            {
                                KeHoachVonNQChiTietDto objKeHoachVonNQChiTiet = AddDataCongTrinh(item.Id, objCongTrinh.Id, obj.KeHoachVonId, listLuyKe);
                                if (objKeHoachVonNQChiTiet != null && objKeHoachVonNQChiTiet.CongTrinhId != Guid.Empty)
                                    _moduleObject.Add(objKeHoachVonNQChiTiet);
                            }
                        });
                    }
                }
            }
            //Sum dữ liệu lũy kế lên nghị quyết
            _moduleObject.Where(x => x.CongTrinhId == Guid.Empty).ForEach(o =>
            {
                o.LuyKeVonTongCong = _moduleObject.Where(x => x.CongTrinhId != null && x.NghiQuyetId == o.NghiQuyetId).Sum(x => x.LuyKeVonTongCong);
                o.LuyKeVonNamTruoc = _moduleObject.Where(x => x.CongTrinhId != null && x.NghiQuyetId == o.NghiQuyetId).Sum(x => x.LuyKeVonNamTruoc);
            });
        }

        private KeHoachVonNQChiTietDto AddDataCongTrinh(Guid nghiQuyetId, Guid congTrinhId, Guid parentId, List<KeHoachVonNQChiTietDto> listLuyKe)
        {
            KeHoachVonNQChiTietDto objKeHoachVonNQChiTiet = new KeHoachVonNQChiTietDto();
            CongTrinhDto objCongTrinh = ((KHVTheoNghiQuyetModule)Module)._listCongTrinh.Where(x => x.Id == congTrinhId).FirstOrDefault();
            if (objCongTrinh != null && objCongTrinh.Id != Guid.Empty)
            {
                objKeHoachVonNQChiTiet.TenDanhMuc = objCongTrinh.TenCongTrinh;
                objKeHoachVonNQChiTiet.NghiQuyetId = nghiQuyetId;
                objKeHoachVonNQChiTiet.CongTrinhId = objCongTrinh.Id;
                if (objCongTrinh.ChuDauTuId != Guid.Empty && ((KHVTheoNghiQuyetModule)Module)._listChuDauTu != null)
                {
                    ChuDauTuDto objChuDauTu = ((KHVTheoNghiQuyetModule)Module)._listChuDauTu.Where(x => x.Id == objCongTrinh.ChuDauTuId).FirstOrDefault();
                    if (objChuDauTu != null)
                    {
                        objKeHoachVonNQChiTiet.TenChuDauTu = objChuDauTu.Ten;
                    }
                }
                objKeHoachVonNQChiTiet.LuyKeVonTongCong = listLuyKe.Where(x => x.CongTrinhId == objKeHoachVonNQChiTiet.CongTrinhId).Select(x => x.LuyKeVonTongCong).FirstOrDefault();
                objKeHoachVonNQChiTiet.LuyKeVonNamTruoc = listLuyKe.Where(x => x.CongTrinhId == objKeHoachVonNQChiTiet.CongTrinhId).Select(x => x.LuyKeVonNamTruoc).FirstOrDefault();
                objKeHoachVonNQChiTiet.ParentId = parentId;
                objKeHoachVonNQChiTiet.KeHoachVonId = Guid.NewGuid();
            }
            return objKeHoachVonNQChiTiet;
        }

        private void GetDataKeHoachVonChiTietByEdit()
        {
            var apiDetatil = ConfigManager.GetAPIByService<IKeHoachVonNQChiTietsApi>();
            _moduleObject = apiDetatil.GetListByKeHoachVonNQIdAsync(_mainObject.Id).GetAwaiter().GetResult();
            if (_isNew == true)
            {
                _moduleObject.ForEach(x => x.IsDeleteDieuChinh = false);
            }
            if (_moduleObject != null && _moduleObject.Count > 0)
            {
                if (_mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachVon.DAU_NAM.ToString().ToLower().Trim())
                {
                    _moduleObject = _moduleObject.Where(x => x.IsSelectDieuChinh == false).OrderBy(x => x.OrderIndex).ToList();
                }
                else if (_mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachVon.DIEU_CHINH.ToString().ToLower().Trim())
                {
                    _moduleObject = _moduleObject.Where(x => x.IsDeleteDieuChinh == false).OrderBy(x => x.OrderIndex).ToList();
                }
                _moduleObject.ForEach(o =>
                {
                    if (o.CongTrinhId == Guid.Empty && o.NghiQuyetId != Guid.Empty)
                    {
                        NghiQuyetDto objNghiQuyet = ((KHVTheoNghiQuyetModule)this.Module)._listNghiQuyet.Where(x => x.Id == o.NghiQuyetId).FirstOrDefault();
                        if (objNghiQuyet != null && objNghiQuyet.Id != Guid.Empty)
                        {
                            o.TenDanhMuc = objNghiQuyet.TrichYeu;
                            o.KeHoachVonId = Guid.NewGuid();
                        }
                    }
                    else if (o.CongTrinhId != Guid.Empty)
                    {
                        CongTrinhDto objCongTrinh = ((KHVTheoNghiQuyetModule)Module)._listCongTrinh.Where(x => x.Id == o.CongTrinhId).FirstOrDefault();
                        if (objCongTrinh != null && objCongTrinh.Id != Guid.Empty)
                        {
                            o.TenDanhMuc = objCongTrinh.TenCongTrinh;
                            o.ParentId = _moduleObject.Where(x => x.NghiQuyetId == o.NghiQuyetId && x.CongTrinhId == Guid.Empty).Select(x => x.KeHoachVonId).FirstOrDefault();
                            o.KeHoachVonId = Guid.NewGuid();
                            if (objCongTrinh.ChuDauTuId != Guid.Empty && ((KHVTheoNghiQuyetModule)Module)._listChuDauTu != null)
                            {
                                ChuDauTuDto objChuDauTu = ((KHVTheoNghiQuyetModule)Module)._listChuDauTu.Where(x => x.Id == objCongTrinh.ChuDauTuId).FirstOrDefault();
                                if (objChuDauTu != null)
                                {
                                    o.TenChuDauTu = objChuDauTu.Ten;
                                }
                            }
                        }
                    }
                    // Gán dữ liệu vào cột động
                    o.Value = new Dictionary<string, decimal>();
                    if (!string.IsNullOrEmpty(o.StringKeHoachVonDauNam))
                    {
                        o.Value = AddValueColumnDynamic(o.Value, o.StringKeHoachVonDauNam);
                    }
                    if (!string.IsNullOrEmpty(o.StringKeHoachVonDauNamDuocDuyet))
                    {
                        o.Value = AddValueColumnDynamic(o.Value, o.StringKeHoachVonDauNamDuocDuyet);
                    }
                    //Load dữ liệu điều chỉnh
                    if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
                    {
                        if (!string.IsNullOrEmpty(o.StringKeHoachVonDieuChinh))
                        {
                            if (!string.IsNullOrEmpty(o.StringDieuChinhGiam))
                            {
                                o.Value = AddValueColumnDynamic(o.Value, o.StringDieuChinhGiam);
                            }
                            if (!string.IsNullOrEmpty(o.StringDieuChinhTang))
                            {
                                o.Value = AddValueColumnDynamic(o.Value, o.StringDieuChinhTang);
                            }
                            if (!string.IsNullOrEmpty(o.StringKeHoachVonDieuChinh))
                            {
                                o.Value = AddValueColumnDynamic(o.Value, o.StringKeHoachVonDieuChinh);
                            }
                            if (!string.IsNullOrEmpty(o.StringKeHoachVonDieuChinhDuocDuyet))
                            {
                                o.Value = AddValueColumnDynamic(o.Value, o.StringKeHoachVonDieuChinhDuocDuyet);
                            }
                        }
                        else//Tạo mới điều chỉnh
                        {
                            o.KeHoachVonDieuChinh = o.KeHoachVonDauNamDuocDuyet;
                            AddValueColumnDieuChinhDynamicByNew(o.Value, o.StringKeHoachVonDauNamDuocDuyet, KeHoachVonNQChiTietColumn.DieuChinhGiam.ToString());
                            AddValueColumnDieuChinhDynamicByNew(o.Value, o.StringKeHoachVonDauNamDuocDuyet, KeHoachVonNQChiTietColumn.DieuChinhTang.ToString());
                            AddValueColumnDieuChinhDynamicByNew(o.Value, o.StringKeHoachVonDauNamDuocDuyet, KeHoachVonNQChiTietColumn.KeHoachVonDieuChinh.ToString());
                            AddValueColumnDieuChinhDynamicByNew(o.Value, o.StringKeHoachVonDauNamDuocDuyet, KeHoachVonNQChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString());
                        }
                    }
                });
            }
        }
        #endregion

        #region Set Column Dynamic
        private void RefreshLayoutBandedGridView(List<NguonVonDto> listNguonVon)
        {
            string path = string.Empty;
            if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
            {
                RefreshLayoutBandedGridViewByDauNam(listNguonVon);
            }
            else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
            {
                RefreshLayoutBandedGridViewByDieuChinh(listNguonVon);
            }

        }

        private void RefreshLayoutBandedGridViewByDauNam(List<NguonVonDto> listNguonVon)
        {
            //Nếu không có nguồn vốn thì danh sách nguồn vốn theo Json
            if (listNguonVon == null || listNguonVon.Count == 0)
            {
                if (_moduleObject != null && _moduleObject.Count > 0)
                {
                    listNguonVon = ConvertJsonToGuildForNguonVon(_moduleObject[0].StringKeHoachVonDauNam);
                }
            }
            string path = ConfigManager.PathTreeListXML() + ModuleName.KHVTheoNghiQuyet + @"\" + TemplateDesignTreeList.TreeList_KeHoachVonNghiQuyet_DauNam.ToString();
            tree_chitietkehoachvon.Bands.Clear();
            tree_chitietkehoachvon.Columns.Clear();
            tree_chitietkehoachvon.InitializeControlByDesign(path, null);

            TreeListBand bandDuKien = tree_chitietkehoachvon.Bands["Band_DuKien"];
            bandDuKien.Caption = KeHoachVonNQChiTietColumn.KeHoachVonDauNam.GetDescription() + _mainObject.Nam.ToString();

            TreeListBand bandKeHoach = tree_chitietkehoachvon.Bands["Band_KeHoach"];
            bandKeHoach.Caption = KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.GetDescription() + _mainObject.Nam.ToString();

            TreeListBand bandLuyKe = tree_chitietkehoachvon.Bands["Band_LuyKe"];
            bandLuyKe.Caption = KeHoachVonNQChiTietColumn.LuyKeVonNamTruoc.GetDescription() + (_mainObject.Nam - 1).ToString();

            TreeListBand bandLuyKeNam = bandLuyKe.Bands["Band_LuyKeNam"];
            if (bandLuyKeNam != null)
            {
                bandLuyKeNam.Caption = "Trong đó: năm " + (_mainObject.Nam - 1).ToString();
            }

            if (_mainObject.TrangThai == TrangThaiKeHoachVon.DANG_SOAN.ToString()
                || _mainObject.TrangThai == TrangThaiKeHoachVon.DA_TRINH.ToString()
                || _mainObject.TrangThai == TrangThaiKeHoachVon.YEU_CAU_CHINH_SUA.ToString())
            {
                AddChildrenGridBand(listNguonVon, bandDuKien, KeHoachVonNQChiTietColumn.KeHoachVonDauNam.ToString(), true);
                AddChildrenGridBand(listNguonVon, bandKeHoach, KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), false);
            }

            else if (_mainObject.TrangThai == TrangThaiKeHoachVon.DUYET.ToString())
            {
                AddChildrenGridBand(listNguonVon, bandDuKien, KeHoachVonNQChiTietColumn.KeHoachVonDauNam.ToString(), false);
                AddChildrenGridBand(listNguonVon, bandKeHoach, KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), true);

            }

            else if (_mainObject.TrangThai == TrangThaiKeHoachVon.HOAN_THANH.ToString())
            {
                AddChildrenGridBand(listNguonVon, bandDuKien, KeHoachVonNQChiTietColumn.KeHoachVonDauNam.ToString(), false);
                AddChildrenGridBand(listNguonVon, bandKeHoach, KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), false);
            }
        }

        private void RefreshLayoutBandedGridViewByDieuChinh(List<NguonVonDto> listNguonVon)
        {
            List<NguonVonDto> listNguonVonDN = GetValueNguonVonByColumn(_moduleObject[0].Value, KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString());
            //Nếu không có nguồn vốn thì danh sách nguồn vốn theo Json
            if (listNguonVon == null || listNguonVon.Count == 0)
            {
                if (_moduleObject != null && _moduleObject.Count > 0)
                {
                    listNguonVon = GetValueNguonVonByColumn(_moduleObject[0].Value, KeHoachVonNQChiTietColumn.KeHoachVonDieuChinh.ToString());
                }
            }
            string path = ConfigManager.PathTreeListXML() + ModuleName.KHVTheoNghiQuyet + @"\" + TemplateDesignTreeList.TreeList_KeHoachVonNghiQuyet_DieuChinh.ToString();
            tree_chitietkehoachvon.Bands.Clear();
            tree_chitietkehoachvon.Columns.Clear();
            tree_chitietkehoachvon.DataSource = _moduleObject;
            tree_chitietkehoachvon.InitializeControlByDesign(path, null);

            TreeListBand bandLuyKe = tree_chitietkehoachvon.Bands["Band_LuyKe"];
            bandLuyKe.Caption = KeHoachVonNQChiTietColumn.LuyKeVonNamTruoc.GetDescription() + (_mainObject.Nam - 1).ToString();
            TreeListBand bandLuyKeNam = bandLuyKe.Bands["Band_LuyKeNam"];
            if (bandLuyKeNam != null)
            {
                bandLuyKeNam.Caption = "Trong đó: năm " + (_mainObject.Nam - 1).ToString();
            }

            TreeListBand bandDauNam = tree_chitietkehoachvon.Bands["Band_KeHoachVonDauNam"];
            bandDauNam.Caption = string.Format("Kế hoạch năm {0} đã giao", _mainObject.Nam.ToString());

            TreeListBand bandDeXuat = tree_chitietkehoachvon.Bands["Band_DeXuat"];
            bandDeXuat.Caption += _mainObject.Nam.ToString();

            TreeListBand bandDieuChinhGiam = bandDeXuat.Bands["Band_DieuChinhGiam"];
            TreeListBand bandDieuChinhTang = bandDeXuat.Bands["Band_DieuChinhTang"];
            TreeListBand bandKeHoachVonDieuChinh = bandDeXuat.Bands["Band_KeHoachVonDieuChinh"];
            bandKeHoachVonDieuChinh.Caption += _mainObject.Nam.ToString();

            TreeListBand bandKeHoachVonDieuChinhDuocDuyet = tree_chitietkehoachvon.Bands["Band_KeHoachVonDieuChinhDuocDuyet"];
            bandKeHoachVonDieuChinhDuocDuyet.Caption = string.Format("Kế hoạch vốn điều chỉnh năm {0} theo quyết định của UB", _mainObject.Nam.ToString());


            AddChildrenGridBand(listNguonVonDN, bandDauNam, KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), false);
            AddChildrenGridBand(listNguonVon, bandKeHoachVonDieuChinh, KeHoachVonNQChiTietColumn.KeHoachVonDieuChinh.ToString(), false);
            if (_mainObject.TrangThai == TrangThaiKeHoachVon.DANG_SOAN.ToString()
                || _mainObject.TrangThai == TrangThaiKeHoachVon.DA_TRINH.ToString()
                || _mainObject.TrangThai == TrangThaiKeHoachVon.YEU_CAU_CHINH_SUA.ToString())
            {
                AddChildrenGridBand(listNguonVon, bandDieuChinhGiam, KeHoachVonNQChiTietColumn.DieuChinhGiam.ToString(), true);
                AddChildrenGridBand(listNguonVon, bandDieuChinhTang, KeHoachVonNQChiTietColumn.DieuChinhTang.ToString(), true);
                AddChildrenGridBand(listNguonVon, bandKeHoachVonDieuChinhDuocDuyet, KeHoachVonNQChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString(), false);
            }

            else if (_mainObject.TrangThai == TrangThaiKeHoachVon.DUYET.ToString())
            {
                AddChildrenGridBand(listNguonVon, bandDieuChinhGiam, KeHoachVonNQChiTietColumn.DieuChinhGiam.ToString(), false);
                AddChildrenGridBand(listNguonVon, bandDieuChinhTang, KeHoachVonNQChiTietColumn.DieuChinhTang.ToString(), false);
                AddChildrenGridBand(listNguonVon, bandKeHoachVonDieuChinhDuocDuyet, KeHoachVonNQChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString(), true);

            }

            else if (_mainObject.TrangThai == TrangThaiKeHoachVon.HOAN_THANH.ToString())
            {
                AddChildrenGridBand(listNguonVon, bandDieuChinhGiam, KeHoachVonNQChiTietColumn.DieuChinhGiam.ToString(), false);
                AddChildrenGridBand(listNguonVon, bandDieuChinhTang, KeHoachVonNQChiTietColumn.DieuChinhTang.ToString(), false);
                AddChildrenGridBand(listNguonVon, bandKeHoachVonDieuChinhDuocDuyet, KeHoachVonNQChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString(), false);
            }
        }

        private void AddChildrenGridBand(List<NguonVonDto> listNguonVon, TreeListBand treeListBand, string columnName, bool allowEdit)
        {
            if (listNguonVon != null && listNguonVon.Count > 0)
            {
                int i = 1;
                TreeListBand treeListBandAdd = new TreeListBand();
                treeListBandAdd.Caption = "Trong đó";
                treeListBandAdd.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                treeListBandAdd.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
                treeListBandAdd.AppearanceHeader.Options.UseTextOptions = true;
                treeListBand.Bands.Add(treeListBandAdd);

                foreach (NguonVonDto nguonVon in listNguonVon)
                {
                    TreeListBand treeListBandChildren = new TreeListBand();
                    treeListBandChildren.Caption = nguonVon.TenNguonVon;
                    treeListBandChildren.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                    treeListBandChildren.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
                    treeListBandChildren.AppearanceHeader.Options.UseTextOptions = true;
                    treeListBandChildren.MinWidth = 120;

                    string fieldName = columnName + "_" + nguonVon.Id;
                    //Thêm column vào database
                    AddColumnDataSource(fieldName);
                    //Thêm BandedGridColumn
                    TreeListColumn treeColumn = new TreeListColumn();
                    treeColumn.FieldName = fieldName;
                    treeColumn.Name = fieldName;
                    treeColumn.Caption = fieldName;
                    treeColumn.Format.FormatType = FormatType.Numeric;
                    treeColumn.Format.FormatString = "n3";
                    treeColumn.OptionsColumn.AllowEdit = allowEdit;

                    treeColumn.SummaryFooter = SummaryItemType.Custom;
                    treeColumn.AllNodesSummary = true;
                    treeColumn.SummaryFooterStrFormat = FormatValue.N3.ToString();

                    treeColumn.UnboundType = UnboundColumnType.Decimal;
                    treeColumn.OptionsColumn.ReadOnly = false;
                    if (allowEdit == true)
                    {
                        RepositoryItemTextEdit rep = new RepositoryItemTextEdit();
                        rep.Mask.MaskType = MaskType.Numeric;
                        rep.Mask.EditMask = "n3";
                        rep.Mask.UseMaskAsDisplayFormat = true;
                        rep.NullText = "0.000";
                        treeColumn.ColumnEdit = rep;
                    }
                    tree_chitietkehoachvon.Columns.Add(treeColumn);
                    treeListBandChildren.Columns.Add(treeColumn);
                    treeListBandAdd.Bands.Add(treeListBandChildren);
                    //Visible column
                    TreeListColumn treeListColumn = tree_chitietkehoachvon.Columns[fieldName];
                    if (treeListColumn != null)
                    {
                        treeListColumn.Visible = true;
                    }
                    i++;
                }
            }
        }


        //Thêm mới column vào datasource
        private void AddColumnDataSource(string columnName)
        {
            //Kiểm tra nếu đã có column thì không cần thêm
            foreach (KeHoachVonNQChiTietDto item in _moduleObject)
            {
                if (item.Value != null && item.Value.Count > 0)
                {
                    if (item.Value.Where(x => x.Key.ToString().ToLower() == columnName.ToString().ToLower()).ToList().Count > 0)
                    {
                        break;
                    }
                }
                if (item.Value == null)
                {
                    item.Value = new Dictionary<string, decimal>();
                }
                item.Value.Add(columnName, 0);
            }
        }

        private void RefreshDataByLayOut()
        {
            List<string> listString = new List<string>();
            foreach (var column in tree_chitietkehoachvon.Columns)
            {
                if (column.FieldName != null && column.FieldName.ToString().Contains("_"))
                {
                    listString.Add(column.FieldName.ToString().ToLower().Trim());
                }
            }
            foreach (KeHoachVonNQChiTietDto item in _moduleObject)
            {
                if (listString != null && listString.Count > 0 && item.Value != null && item.Value.Count > 0)
                {
                    var data = item.Value.Where(x => listString.Contains(x.Key.ToString().ToLower().Trim()));
                    item.Value = new Dictionary<string, decimal>();
                    if (data != null)
                        foreach (var obj in data)
                        {
                            item.Value.Add(obj.Key, obj.Value);
                        }
                }
                else
                {
                    item.Value = new Dictionary<string, decimal>();
                }
            }
        }
        #endregion

        #region RefreshDataSource
        private void RefreshDataSourceDetail()
        {
            if (_moduleObject != null && _moduleObject.Count > 0)
                _moduleObject = _moduleObject.OrderBy(x => x.OrderIndex).ToList();
            tree_chitietkehoachvon.DataSource = _moduleObject;
            tree_chitietkehoachvon.RefreshDataSource();
            SetPropertyTreeList();
        }

        public void SetPropertyTreeList()
        {
            tree_chitietkehoachvon.ExpandAll();
            TreeListColumn columnDanhMuc = tree_chitietkehoachvon.Columns[KeHoachVonNQChiTietColumn.TenDanhMuc.ToString()];
            if (columnDanhMuc != null)
            {
                columnDanhMuc.Width = 400;
                RepositoryItemMemoEdit memoEdit = new RepositoryItemMemoEdit();
                columnDanhMuc.ColumnEdit = memoEdit;
                columnDanhMuc.AppearanceCell.Options.UseTextOptions = true;
                columnDanhMuc.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                columnDanhMuc.AppearanceCell.TextOptions.WordWrap = WordWrap.Wrap;
            }
        }
        #endregion

        #region Convert Data
        private List<NguonVonDto> ConvertJsonToGuildForNguonVon(string strJson)
        {
            List<NguonVonDto> listNguonVon = new List<NguonVonDto>();
            if (!string.IsNullOrEmpty(strJson))
            {
                var api = ConfigManager.GetAPIByService<INguonVonsApi>();
                var dictionary = JsonConvert.DeserializeObject<List<EnumDescriptionViewModel>>(strJson);
                if (dictionary != null && dictionary.Count > 0)
                {
                    foreach (var item in dictionary)
                    {
                        string key = item.Key.ToString();
                        string[] Split = item.Key.Split('_');
                        if (Split != null && Split.Count() > 1)
                        {
                            Guid id = new Guid(Split[1].ToString());
                            if (id != null && id != Guid.Empty)
                            {
                                NguonVonDto objNguonVon = api.GetAsync(id).GetAwaiter().GetResult();
                                if (objNguonVon != null && objNguonVon.Id != Guid.Empty)
                                {
                                    if (listNguonVon.Where(x => x.Id == objNguonVon.Id).ToList().Count == 0)
                                        listNguonVon.Add(objNguonVon);
                                }
                            }
                        }
                    }
                }
            }
            return listNguonVon;
        }

        private List<NguonVonDto> GetValueNguonVonByColumn(Dictionary<string, decimal> value, string column)
        {
            List<NguonVonDto> listNguonVon = new List<NguonVonDto>();
            if (value != null && value.Count > 0)
            {
                var api = ConfigManager.GetAPIByService<INguonVonsApi>();
                foreach (var item in value)
                {
                    if (item.Key.ToString().ToLower().Trim().Contains(column.ToString().ToLower().Trim()))
                    {
                        string[] Split = item.Key.Split('_');
                        if (Split != null && Split.Count() > 1)
                        {
                            Guid id = new Guid(Split[1].ToString());
                            if (id != null && id != Guid.Empty)
                            {
                                NguonVonDto objNguonVon = api.GetAsync(id).GetAwaiter().GetResult();
                                if (objNguonVon != null && objNguonVon.Id != Guid.Empty)
                                {
                                    if (listNguonVon.Where(x => x.Id == objNguonVon.Id).ToList().Count == 0)
                                        listNguonVon.Add(objNguonVon);
                                }
                            }
                        }
                    }
                }
            }
            return listNguonVon;
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

        private Dictionary<string, decimal> AddValueColumnDieuChinhDynamicByNew(Dictionary<string, decimal> value, string strJson, string column)
        {
            if (!string.IsNullOrEmpty(strJson))
            {
                var dictionary = JsonConvert.DeserializeObject<List<EnumDescriptionViewModel>>(strJson);
                if (dictionary != null && dictionary.Count > 0)
                {
                    foreach (var item in dictionary)
                    {
                        string key = item.Key.Replace(KeHoachVonNQChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), column);
                        if (value.Where(x => x.Key.ToString().ToLower() == key.ToString().ToLower()).ToList().Count() == 0)
                        {
                            value.Add(key, (column == KeHoachVonNQChiTietColumn.KeHoachVonDieuChinh.ToString() ? Convert.ToDecimal(item.Value.Trim()) : 0));
                        }
                    }
                }
            }
            return value;
        }

        private string ConvertStringColum(string column)
        {
            return column + "_";
        }
        #endregion
    }
}