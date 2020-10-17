﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using xdcb.QuanLyVon.KeHoachVonNST.Dtos;
using xdcb.QuanLyVon.KeHoachVonNSTChiTiet.Dtos;
using xdcb.FormServices.BaseForm;
using xdcb.FormServices.Shared;
using xdcb.FormServices.SDK;
using xdcb.QuanLyVon.NhuCauKeHoachVonChiTiet.Dtos;
using xdcb.Common.DanhMuc.CongTrinhDtos;
using Newtonsoft.Json;
using xdcb.Common.DanhMuc.NguonVonDtos;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraTreeList.Data;
using DevExpress.XtraTreeList;
using DevExpress.XtraGrid.Views.Grid;
using xdcb.FileService.DocumentStoreDtos;
using System.IO;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;
using xdcb.FormServices.Component;
using xdcb.Common.DanhMuc.LoaiKhoanDtos;
using xdcb.Common.DanhMuc.ChuDauTuDtos;
using DevExpress.Utils.Extensions;
using xdcb.FormQLV.KHVTheoNganSachTinh;

namespace xdcb.FormQLV.Module.KeHoachVonTheoNganSachTinh
{
    public partial class frmCreateKHVTheoNganSachTinh : GGScreenDetail
    {
        #region Property
        private KeHoachVonNSTDto _mainObject;
        private List<KeHoachVonNSTChiTietDto> _moduleObject = new List<KeHoachVonNSTChiTietDto>();
        private bool _isNew;
        public List<LoaiKhoanDto> _listLoaiKhoan = new List<LoaiKhoanDto>();
        public List<ChuDauTuDto> _listChuDauTu = new List<ChuDauTuDto>();
        public List<CongTrinhDto> _listCongTrinh = new List<CongTrinhDto>();

        #endregion Property
        public frmCreateKHVTheoNganSachTinh(bool isCreate, KeHoachVonNSTDto keHoachVonNSTDto, BaseModule module)
        {
            InitializeComponent();
            this.Module = module;
            _mainObject = keHoachVonNSTDto;
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
            GetDataChuDautu();

            GetDataLoaiKhoan();

            GetDataCongTrinh();

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
                string path = ConfigManager.PathGridViewXML() + ModuleName.KHVTheoNganSachTinh + @"\" + TemplateDesignGrid.GridView_KeHoachVonTheoNganSachTinh_DinhKemFile.ToString();
                grl_dinhkemfile.InitializeControlByDesign(path, CreateDesignGrid.NewGridView.ToString());

                GridView gridView = (GridView)grl_dinhkemfile.MainView;
                gridView.DoubleClick += Grl_dinhkemfile_DoubleClick;
                gridView.KeyUp += Grl_dinhkemfile_KeyUp;
                GetValueUploadFileGridView();
            }

           
        }
        #endregion

        #region Get loại khoản, công trình, chủ đầu tư
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

        public void GetDataChuDautu()
        {
            if (_listChuDauTu != null)
                _listChuDauTu.Clear();
            var apiChuDauTu = ConfigManager.GetAPIByService<IChuDauTusApi>();
            _listChuDauTu = apiChuDauTu.GetAll().GetAwaiter().GetResult();
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

        #region Sự kiện trên lưới TreeList
        private void Tree_chitietkehoachvon_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                KeHoachVonNSTChiTietDto objChiTiet = (KeHoachVonNSTChiTietDto)tree_chitietkehoachvon.GetDataRecordByNode(tree_chitietkehoachvon.FocusedNode);
                DeleteRowKeHoachVonChiTiet(objChiTiet);
            }
        }

        private void Tree_chitietkehoachvon_CustomUnboundColumnData(object sender, TreeListCustomColumnDataEventArgs e)
        {
            var tree = sender as TreeList;
            List<KeHoachVonNSTChiTietDto> moduleObject = (List<KeHoachVonNSTChiTietDto>)tree.DataSource;
            var obj = (KeHoachVonNSTChiTietDto)tree.GetDataRecordByNode(e.Node);
            if (obj != null)
            {
                if (e.IsGetData)
                {
                    if (e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDauNam.ToString()))
                   || e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString()))
                   || e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.DieuChinhGiam.ToString()))
                   || e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.DieuChinhTang.ToString()))
                   || e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinh.ToString()))
                   || e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString())))
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
                          (e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDauNam.ToString()))
                        || e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString()))))
                    {
                        isEdit = true;
                    }
                    else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString() &&
                              (e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.DieuChinhGiam.ToString()))
                            || e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.DieuChinhTang.ToString()))
                            || e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinh.ToString()))
                            || e.Column.FieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString()))))
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

        private void SetValueTreelist(string fieldName, KeHoachVonNSTChiTietDto obj, List<KeHoachVonNSTChiTietDto> moduleObject)
        {
            //Set cac gia tri lien quan
            var objSumNganSachTinh = moduleObject.Where(x => x.CongTrinhId == Guid.Empty && x.LoaiKhoanId == obj.LoaiKhoanId).ToList().FirstOrDefault();

            if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
            {
                if (fieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDauNam.ToString())))
                {
                    obj.KeHoachVonDauNam = CaculateDictionaryValueByColumn(obj.Value, ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDauNam.ToString()));
                }
                else if (fieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString())))
                {
                    obj.KeHoachVonDauNamDuocDuyet = CaculateDictionaryValueByColumn(obj.Value, ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString()));
                }
            }
            else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
            {
                if (fieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.DieuChinhGiam.ToString()))
                                  || fieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.DieuChinhTang.ToString())))
                {
                    obj.DieuChinhGiam = CaculateDictionaryValueByColumn(obj.Value, ConvertStringColum(KeHoachVonNSTChiTietColumn.DieuChinhGiam.ToString()));
                    obj.DieuChinhTang = CaculateDictionaryValueByColumn(obj.Value, ConvertStringColum(KeHoachVonNSTChiTietColumn.DieuChinhTang.ToString()));

                    string idCongTrinh = fieldName.ToString().Split("_").ToList()[1];

                    string keyDieuChinh = string.Format("{0}_{1}", KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinh.ToString(), idCongTrinh);
                    string keyTang = string.Format("{0}_{1}", KeHoachVonNSTChiTietColumn.DieuChinhTang.ToString(), idCongTrinh);
                    string keyGiam = string.Format("{0}_{1}", KeHoachVonNSTChiTietColumn.DieuChinhGiam.ToString(), idCongTrinh);
                    string keyDauNam = string.Format("{0}_{1}", KeHoachVonNSTChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), idCongTrinh);

                    decimal valueDauNam = 0;
                    decimal valueTang = 0;
                    decimal valueGiam = 0;
                    if (obj.Value.Where(x => x.Key.ToString().ToLower().Trim() == keyDauNam.ToString().ToLower().Trim()).ToList().Count > 0)
                    {
                        valueDauNam = obj.Value[keyDauNam];
                    }
                    if (obj.Value.Where(x => x.Key.ToString().ToLower().Trim() == keyTang.ToString().ToLower().Trim()).ToList().Count > 0)
                    {
                        valueTang = obj.Value[keyTang];
                    }
                    if (obj.Value.Where(x => x.Key.ToString().ToLower().Trim() == keyGiam.ToString().ToLower().Trim()).ToList().Count > 0)
                    {
                        valueGiam = obj.Value[keyGiam];
                    }
                    if (obj.Value.Where(x => x.Key.ToString().ToLower().Trim() == keyDieuChinh.ToString().ToLower().Trim()).ToList().Count > 0)
                    {
                        obj.Value[keyDieuChinh] = valueDauNam + valueTang - valueGiam;
                    }
                    obj.KeHoachVonDieuChinh = CaculateDictionaryValueByColumn(obj.Value, ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinh.ToString()));

                    //Sum lên loại khoản
                    if (objSumNganSachTinh != null)
                    {
                        objSumNganSachTinh.Value[keyDieuChinh] = CaculateValueSumCongTrinh(moduleObject, objSumNganSachTinh.LoaiKhoanId, keyDieuChinh);
                        objSumNganSachTinh.DieuChinhGiam = CaculateDictionaryValueByColumn(objSumNganSachTinh.Value, ConvertStringColum(KeHoachVonNSTChiTietColumn.DieuChinhGiam.ToString()));
                        objSumNganSachTinh.DieuChinhTang = CaculateDictionaryValueByColumn(objSumNganSachTinh.Value, ConvertStringColum(KeHoachVonNSTChiTietColumn.DieuChinhTang.ToString()));
                        objSumNganSachTinh.KeHoachVonDieuChinh = CaculateDictionaryValueByColumn(objSumNganSachTinh.Value, ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinh.ToString()));
                    }
                }
                else if (fieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString())))
                {
                    obj.KeHoachVonDieuChinhDuocDuyet = CaculateDictionaryValueByColumn(obj.Value, ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString()));
                }
            }
            //Sum lên loại khoản
            if (objSumNganSachTinh != null)
            {
                bool isEdit = false;
                if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString() &&
                      (fieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDauNam.ToString()))
                    || fieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString()))))
                {
                    isEdit = true;
                }
                else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString() &&
                          (fieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.DieuChinhGiam.ToString()))
                        || fieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.DieuChinhTang.ToString()))
                        || fieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinh.ToString()))
                        || fieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString()))))
                {
                    isEdit = true;
                }
                if (isEdit)
                {
                    if (objSumNganSachTinh.Value != null)
                        objSumNganSachTinh.Value[fieldName] = CaculateValueSumCongTrinh(moduleObject, objSumNganSachTinh.LoaiKhoanId, fieldName);
                }
            }

        }

        private void Tree_chitietkehoachvon_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            var tree = sender as TreeList;
            TreeListColumn column = e.Column;
            if (column != null && (column.FieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDauNam.ToString()))
                                    || column.FieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString()))
                                    || column.FieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.DieuChinhTang.ToString()))
                                    || column.FieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.DieuChinhGiam.ToString()))
                                    || column.FieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinh.ToString()))
                                    || column.FieldName.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString()))
                                    ))
            {
                bool isReadOnly = false;
                List<KeHoachVonNSTChiTietDto> moduleObject = (List<KeHoachVonNSTChiTietDto>)tree.DataSource;
                var obj = (KeHoachVonNSTChiTietDto)tree.GetDataRecordByNode(e.Node);
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
                    List<KeHoachVonNSTChiTietDto> moduleObject = (List<KeHoachVonNSTChiTietDto>)tree.DataSource;
                    var obj = (KeHoachVonNSTChiTietDto)tree.GetDataRecordByNode(e.Node);
                    if (obj != null && moduleObject != null)
                    {
                        if (moduleObject.Where(x => x.ParentId == obj.KeHoachVonId).ToList().Count() > 0)
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
                if (e.Column.FieldName.Contains(KeHoachVonNSTChiTietColumn.KeHoachVonDauNam.ToString())
                    || e.Column.FieldName.Contains(KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinh.ToString())
                    || e.Column.FieldName.Contains(KeHoachVonNSTChiTietColumn.DieuChinhGiam.ToString())
                    || e.Column.FieldName.Contains(KeHoachVonNSTChiTietColumn.DieuChinhTang.ToString())
                    || e.Column.FieldName == KeHoachVonNSTChiTietColumn.LuyKeVonNamTruoc.ToString()
                    || e.Column.FieldName == KeHoachVonNSTChiTietColumn.LuyKeVonTongCong.ToString()
                   )
                {
                    e.CustomValue = CaculateGetSumByColumnByFormat(e.Column.FieldName, FormatValue.N3);
                }

            }
        }

        #endregion

        #region Delete Row Chi Tiet
        public void DeleteRowKeHoachVonChiTiet(KeHoachVonNSTChiTietDto objDetail)
        {
            if (_mainObject.TrangThai == TrangThaiKeHoachTongNguon.DANG_SOAN.ToString()
                || _mainObject.TrangThai == TrangThaiKeHoachTongNguon.YEU_CAU_CHINH_SUA.ToString())
            {
                List<KeHoachVonNSTChiTietDto> moduleObject = (List<KeHoachVonNSTChiTietDto>)tree_chitietkehoachvon.DataSource;
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

        #region CaculateNode
        private decimal CaculateValueSumCongTrinh(List<KeHoachVonNSTChiTietDto> moduleObject, Guid loaiKhoanId, string column)
        {
            decimal value = 0;
            if (moduleObject != null && moduleObject.Where(x => x.Value == null).Count() == 0)
            {
                value = moduleObject.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiKhoanId == loaiKhoanId).Sum(o => o.Value.Where(x => x.Key == column).Sum(x => x.Value));
            }
            return value;
        }
        private decimal CaculateDictionaryValueByColumn(Dictionary<string, decimal> dictionary, string column)
        {
            decimal value = dictionary == null ? 0 : dictionary.Where(x => x.Key.Contains(column)).Sum(x => x.Value);
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
                List<KeHoachVonNSTChiTietDto> moduleObject = (List<KeHoachVonNSTChiTietDto>)tree_chitietkehoachvon.DataSource;
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
                        if (moduleObject != null && moduleObject.Where(x => x.Value == null).Count() == 0)
                            result = moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(o => o.Value.Where(x => x.Key == column).Sum(x => x.Value));
                    }
                    else
                    {
                        if (column == KeHoachVonNSTChiTietColumn.KeHoachVonDauNam.ToString())
                        {
                            result = moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(x => x.KeHoachVonDauNam);
                        }
                        else if (column == KeHoachVonNSTChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString())
                        {
                            result = moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(x => x.KeHoachVonDauNamDuocDuyet);
                        }
                        else if (column == KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinh.ToString())
                        {
                            result = moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(x => x.KeHoachVonDieuChinh);
                        }
                        else if (column == KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString())
                        {
                            result = moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(x => x.KeHoachVonDieuChinhDuocDuyet);
                        }
                        else if (column == KeHoachVonNSTChiTietColumn.DieuChinhGiam.ToString())
                        {
                            result = moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(x => x.DieuChinhGiam);
                        }
                        else if (column == KeHoachVonNSTChiTietColumn.DieuChinhTang.ToString())
                        {
                            result = moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(x => x.DieuChinhTang);
                        }
                        else if (column == KeHoachVonNSTChiTietColumn.LuyKeVonNamTruoc.ToString())
                        {
                            result = moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(x => x.LuyKeVonNamTruoc);
                        }
                        else if (column == KeHoachVonNSTChiTietColumn.LuyKeVonTongCong.ToString())
                        {
                            result = moduleObject.Where(x => x.CongTrinhId != Guid.Empty).Sum(x => x.LuyKeVonTongCong);
                        }
                    }
                }
            }
            return Math.Round(result, 6, MidpointRounding.AwayFromZero);
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
                cbbTrangThai.GGDataMember = KeHoachVonNSTColumn.TrangThaiDauNam.ToString();
                dte_ngayquyetdinh.GGDataMember = KeHoachVonNSTColumn.NgayBanHanhDauNam.ToString();
                txt_soquyetdinh.GGDataMember = KeHoachVonNSTColumn.SoQuyetDinhDauNam.ToString();
            }
            else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
            {
                cbbTrangThai.GGDataMember = KeHoachVonNSTColumn.TrangThaiDieuChinh.ToString();
                dte_ngayquyetdinh.GGDataMember = KeHoachVonNSTColumn.NgayBanHanhDieuChinh.ToString();
                txt_soquyetdinh.GGDataMember = KeHoachVonNSTColumn.SoQuyetDinhDieuChinh.ToString();
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
                box_AttachedFile.Enabled = false;
                btn_UpLoadFile.Enabled = false;
                btn_AddCongTrinh.Enabled = true;
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
                box_AttachedFile.Enabled = false;
                btn_UpLoadFile.Enabled = false;
                btn_AddCongTrinh.Enabled = false;
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
                box_AttachedFile.Enabled = false;
                btn_UpLoadFile.Enabled = false;
                btn_AddCongTrinh.Enabled = true;
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
                box_AttachedFile.Enabled = true;
                btn_UpLoadFile.Enabled = true;
                btn_AddCongTrinh.Enabled = false;
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
                box_AttachedFile.Enabled = true;
                btn_UpLoadFile.Enabled = false;
                btn_AddCongTrinh.Enabled = false;
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

        public void InitBindEntityToControl(Control.ControlCollection controls, KeHoachVonNSTDto obj)
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

        #region Thêm nguồn vốn
        private void btn_AddNguonVon_Click(object sender, EventArgs e)
        {
            List<NguonVonDto> list = new List<NguonVonDto>();
            if (_moduleObject == null || _moduleObject.Count == 0)
            {
                GGFunctions.ShowMessage("Vui lòng chọn công trình thêm vào trước khi thêm nguồn vốn!");
                return;
            }
            if (_moduleObject != null && _moduleObject.Count > 0)
            {
                if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
                {
                    list = GetValueNguonVonByColumn(_moduleObject[0].Value, ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDauNam.ToString()));
                }
                else if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
                {
                    list = GetValueNguonVonByColumn(_moduleObject[0].Value, ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinh.ToString()));
                }
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
                _moduleObject = new List<KeHoachVonNSTChiTietDto>();
            }
            if (_mainObject.Id == Guid.Empty && _isNew == true)
            {
                GetDataKeHoachVonChiTietByNew();
            }
            //Xử lý điêu chỉnh nếu có kế hoạch vốn điều chỉnh và nhu cầu vốn
            else if (_mainObject.Id != Guid.Empty && _isNew == true && _mainObject.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString())
            {
                GetDataKeHoachVonChiTietByDieuChinhNew();
            }
            else
            {
                GetDataKeHoachVonChiTietByEdit();
            }
        }

        private void GetDataKeHoachVonChiTietByNew()
        {
            List<NhuCauKeHoachVonChiTietDto> listNhuCauVon = GetDataNhuCauVon(_mainObject.Nam, _mainObject.LoaiKeHoach.ToString(), KeHoachNhuCauVon.HANG_NAM.ToString());
            var apiKHVChiTiet = ConfigManager.GetAPIByService<IKeHoachVonNSTChiTietApi>();
            List<KeHoachVonNSTChiTietDto> listLuyKe = apiKHVChiTiet.GetDataLuyKeByNam(_mainObject.Nam - 1).GetAwaiter().GetResult();
            if (listLuyKe == null)
            {
                listLuyKe = new List<KeHoachVonNSTChiTietDto>();
            }
            if (listNhuCauVon != null && listNhuCauVon.Count() > 0)
            {
                Dictionary<string, decimal> dictionary = new Dictionary<string, decimal>();
                var listCongTrinh = _listCongTrinh.Where(x => listNhuCauVon.Select(o => o.CongTrinhID).Distinct().Contains(x.Id));
                var listLoaiKhoan = _listLoaiKhoan.Where(x => listCongTrinh.Select(o => o.LoaiKhoanId).Distinct().Contains(x.Id));
                if (listLoaiKhoan != null)
                {
                    foreach(LoaiKhoanDto item in listLoaiKhoan)
                    {
                        //Thêm danh mục loại khoản
                        _moduleObject.Add(AddRowLoaiKhoan(item, dictionary));
                        //Thêm danh mục công trình cho loại khoản
                        listCongTrinh.Where(x => x.LoaiKhoanId == item.Id).ToList().ForEach(o =>
                        {
                            KeHoachVonNSTChiTietDto objChiTiet = AddRowCongTrinh(item.Id, o.Id, _moduleObject.Where(x => x.LoaiKhoanId == o.LoaiKhoanId && x.CongTrinhId == Guid.Empty).Select(x => x.KeHoachVonId).FirstOrDefault(), listLuyKe, listNhuCauVon, dictionary);
                            if (objChiTiet != null && objChiTiet.CongTrinhId != Guid.Empty)
                            {
                                _moduleObject.Add(objChiTiet);
                            }
                        });
                    }
                }
                //Sum dữ liệu lũy kế lên loại khoản
                SumValueGroupChiTiet();
            }
        }

        private void GetDataKeHoachVonChiTietByEdit()
        {
            var apiDetatil = ConfigManager.GetAPIByService<IKeHoachVonNSTChiTietApi>();
            _moduleObject = apiDetatil.GetListByKeHoachVonNSTIdAsync(_mainObject.Id).GetAwaiter().GetResult();
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
                    if (o.CongTrinhId == Guid.Empty && o.LoaiKhoanId != Guid.Empty)
                    {
                        LoaiKhoanDto objLoaiKhoan = _listLoaiKhoan.Where(x => x.Id == o.LoaiKhoanId).FirstOrDefault();
                        if (objLoaiKhoan != null && objLoaiKhoan.Id != Guid.Empty)
                        {
                            o.TenDanhMuc = objLoaiKhoan.TenLoaiKhoan;
                            o.KeHoachVonId = Guid.NewGuid();
                        }
                    }
                    else if (o.CongTrinhId != Guid.Empty)
                    {
                        CongTrinhDto objCongTrinh = _listCongTrinh.Where(x => x.Id == o.CongTrinhId).FirstOrDefault();
                        if (objCongTrinh != null && objCongTrinh.Id != Guid.Empty)
                        {
                            o.TenDanhMuc = objCongTrinh.TenCongTrinh;
                            o.ParentId = _moduleObject.Where(x => x.LoaiKhoanId == o.LoaiKhoanId && x.CongTrinhId == Guid.Empty).Select(x => x.KeHoachVonId).FirstOrDefault();
                            o.KeHoachVonId = Guid.NewGuid();
                            o.MaSoDuAn = objCongTrinh.MaSoDuAn;
                            o.SoQuyetDinh = objCongTrinh.SoQuyetDinhDauTu;
                            o.LoaiCongTrinhID = objCongTrinh.LoaiCongTrinhId == null ? Guid.Empty : new Guid(objCongTrinh.LoaiCongTrinhId.ToString());
                            o.TongMucDauTu = objCongTrinh.TongMucDauTu == null ? 0 : Convert.ToDecimal(objCongTrinh.TongMucDauTu);
                            o.NST = objCongTrinh.NST == null ? 0 : Convert.ToDecimal(objCongTrinh.NST);
                            ChuDauTuDto objChuDauTu = _listChuDauTu.Where(x => x.Id == objCongTrinh.ChuDauTuId).FirstOrDefault();
                            if (objChuDauTu != null && objChuDauTu.Id != Guid.Empty)
                            {
                                o.MaSoChuong = objChuDauTu.MaSoChuong;
                                o.TenChuDauTu = objChuDauTu.Ten;
                            }
                            LoaiKhoanDto objLoaiKhoan = _listLoaiKhoan.Where(x => x.Id == objCongTrinh.LoaiKhoanId).ToList().FirstOrDefault();
                            if (objLoaiKhoan != null && objLoaiKhoan.Id != Guid.Empty)
                            {
                                o.MaLoaiKhoan = objLoaiKhoan.MaSo;
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

        private void GetDataKeHoachVonChiTietByDieuChinhNew()
        {
            List<NhuCauKeHoachVonChiTietDto> listNhuCauVon = GetDataNhuCauVon(_mainObject.Nam, _mainObject.LoaiKeHoach.ToString(), KeHoachNhuCauVon.HANG_NAM.ToString());
            if (listNhuCauVon != null && listNhuCauVon.Count() > 0)
            {
                var apiDetatil = ConfigManager.GetAPIByService<IKeHoachVonNSTChiTietApi>();

                var listChiTietDauNam = apiDetatil.GetListByKeHoachVonNSTIdAsync(_mainObject.Id).GetAwaiter().GetResult();
                if (listChiTietDauNam == null)
                    listChiTietDauNam = new List<KeHoachVonNSTChiTietDto>();
                if (_isNew == true)
                {
                    listChiTietDauNam.ForEach(x => x.IsDeleteDieuChinh = false);
                }
                listChiTietDauNam = listChiTietDauNam.Where(x => x.IsDeleteDieuChinh == false).OrderBy(x => x.OrderIndex).ToList();


                var apiKHVChiTiet = ConfigManager.GetAPIByService<IKeHoachVonNSTChiTietApi>();
                List<KeHoachVonNSTChiTietDto> listLuyKe = apiKHVChiTiet.GetDataLuyKeByNam(_mainObject.Nam - 1).GetAwaiter().GetResult();
                if (listLuyKe == null)
                {
                    listLuyKe = new List<KeHoachVonNSTChiTietDto>();
                }
                if (listNhuCauVon != null && listNhuCauVon.Count() > 0)
                {
                    Dictionary<string, decimal> dictionary = new Dictionary<string, decimal>();
                    if (listChiTietDauNam != null && listChiTietDauNam.Count > 0)
                    {
                        dictionary = SetValueDictionaryForDieuChinh(listChiTietDauNam[0]);
                    }
                    var listCongTrinh = _listCongTrinh.Where(x => listNhuCauVon.Select(o => o.CongTrinhID).Distinct().Contains(x.Id));
                    var listLoaiKhoan = _listLoaiKhoan.Where(x => listCongTrinh.Select(o => o.LoaiKhoanId).Distinct().Contains(x.Id));
                    if (listLoaiKhoan != null)
                    {
                        foreach (LoaiKhoanDto item in listLoaiKhoan)
                        {
                            //Thêm danh mục loại khoản
                            KeHoachVonNSTChiTietDto cloneChiTiet = listChiTietDauNam.Where(x => x.LoaiKhoanId == item.Id && x.CongTrinhId == Guid.Empty).FirstOrDefault();
                            var isExist = _moduleObject.FirstOrDefault(x => x.Id == cloneChiTiet.Id);
                            if (cloneChiTiet != null)
                            {
                               
                                if (isExist == null)
                                {
                                    _moduleObject.Add(SetValueRowLoaiKhoanForDieuChinh(item, cloneChiTiet));
                                }
                                
                            }
                            else
                            {
                                if (isExist == null)
                                {
                                    _moduleObject.Add(AddRowLoaiKhoan(item, dictionary));
                                }
                                    
                            }
                            //Thêm danh mục công trình cho loại khoản
                            listCongTrinh.Where(x => x.LoaiKhoanId == item.Id).ToList().ForEach(o =>
                            {
                                cloneChiTiet = listChiTietDauNam.Where(x => x.CongTrinhId == o.Id).FirstOrDefault();
                                isExist = _moduleObject.FirstOrDefault(x => x.Id == cloneChiTiet.Id);
                                if (cloneChiTiet != null)
                                {
                                    if (isExist==null)
                                    {
                                        _moduleObject.Add(SetValueRowCongTrinhForDieuChinh(cloneChiTiet, _moduleObject.Where(x => x.LoaiKhoanId == o.LoaiKhoanId && x.CongTrinhId == Guid.Empty).Select(x => x.KeHoachVonId).FirstOrDefault(), listNhuCauVon));
                                    }
                                   
                                }
                                else
                                {
                                    if (isExist == null)
                                    {
                                        _moduleObject.Add(AddRowCongTrinh(item.Id, o.Id, _moduleObject.Where(x => x.LoaiKhoanId == o.LoaiKhoanId && x.CongTrinhId == Guid.Empty).Select(x => x.KeHoachVonId).FirstOrDefault(), listLuyKe, listNhuCauVon, dictionary));
                                    }
                                }
                            });
                        }
                    }
                    //Sum dữ liệu lũy kế lên loại khoản
                    SumValueGroupChiTiet();
                }
            }
            else
            {
                GetDataKeHoachVonChiTietByEdit();
            }
        }

        private Dictionary<string, decimal> SetValueDictionaryForDieuChinh(KeHoachVonNSTChiTietDto obj)
        {
            Dictionary<string, decimal> dictionary = new Dictionary<string, decimal>();
            if (obj != null)
            {
                if (!string.IsNullOrEmpty(obj.StringKeHoachVonDauNam))
                {
                    dictionary = AddValueColumnDynamic(dictionary, obj.StringKeHoachVonDauNam);
                }
                if (!string.IsNullOrEmpty(obj.StringKeHoachVonDauNamDuocDuyet))
                {
                    dictionary = AddValueColumnDynamic(dictionary, obj.StringKeHoachVonDauNamDuocDuyet);
                }
                AddValueColumnDieuChinhDynamicByNew(dictionary, obj.StringKeHoachVonDauNamDuocDuyet, KeHoachVonNQChiTietColumn.DieuChinhGiam.ToString());
                AddValueColumnDieuChinhDynamicByNew(dictionary, obj.StringKeHoachVonDauNamDuocDuyet, KeHoachVonNQChiTietColumn.DieuChinhTang.ToString());
                AddValueColumnDieuChinhDynamicByNew(dictionary, obj.StringKeHoachVonDauNamDuocDuyet, KeHoachVonNQChiTietColumn.KeHoachVonDieuChinh.ToString());
                AddValueColumnDieuChinhDynamicByNew(dictionary, obj.StringKeHoachVonDauNamDuocDuyet, KeHoachVonNQChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString());
            }
            return dictionary;
        }

        private KeHoachVonNSTChiTietDto AddRowLoaiKhoan(LoaiKhoanDto item, Dictionary<string, decimal> dictionary)
        {
            bool selectDieuChinh = false;
            if (_mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachVon.DIEU_CHINH.ToString().ToLower().Trim())
            {
                selectDieuChinh = true;
            }
            KeHoachVonNSTChiTietDto obj = new KeHoachVonNSTChiTietDto();
            obj.TenDanhMuc = item.TenLoaiKhoan;
            obj.LoaiKhoanId = item.Id;
            obj.KeHoachVonId = Guid.NewGuid();
            obj.IsSelectDieuChinh = selectDieuChinh;
            if (dictionary != null && dictionary.Count > 0)
            {
                obj.Value = new Dictionary<string, decimal>();
                List<string> keyValues = new List<string>(dictionary.Keys);
                keyValues.ForEach(k =>
                {
                    obj.Value.Add(k, 0);
                });
            }
            return obj;
        }

        private KeHoachVonNSTChiTietDto SetValueRowLoaiKhoanForDieuChinh(LoaiKhoanDto item, KeHoachVonNSTChiTietDto obj)
        {
            obj.TenDanhMuc = item.TenLoaiKhoan;
            obj.KeHoachVonId = Guid.NewGuid();
            obj.Value = SetValueDictionaryForDieuChinh(obj);
            return obj;
        }

        private KeHoachVonNSTChiTietDto AddRowCongTrinh(Guid loaiKhoanId, Guid congTrinhId, Guid parentId, List<KeHoachVonNSTChiTietDto> listLuyKe, List<NhuCauKeHoachVonChiTietDto> listNhuCauVon, Dictionary<string, decimal> dictionary)
        {
            bool selectDieuChinh = false;
            if (_mainObject.LoaiKeHoach.ToString().ToLower().Trim() == LoaiKeHoachVon.DIEU_CHINH.ToString().ToLower().Trim())
            {
                selectDieuChinh = true;
            }
            KeHoachVonNSTChiTietDto obj = new KeHoachVonNSTChiTietDto();
            CongTrinhDto objCongTrinh = _listCongTrinh.Where(x => x.Id == congTrinhId).FirstOrDefault();
            if (objCongTrinh != null && objCongTrinh.Id != Guid.Empty)
            {
                obj.TenDanhMuc = objCongTrinh.TenCongTrinh;
                obj.LoaiKhoanId = loaiKhoanId;
                obj.CongTrinhId = objCongTrinh.Id;
                obj.MaSoDuAn = objCongTrinh.MaSoDuAn;
                obj.SoQuyetDinh = objCongTrinh.SoQuyetDinhDauTu;
                obj.LoaiCongTrinhID = objCongTrinh.LoaiCongTrinhId == null ? Guid.Empty : new Guid(objCongTrinh.LoaiCongTrinhId.ToString());
                obj.TongMucDauTu = objCongTrinh.TongMucDauTu == null ? 0 : Convert.ToDecimal(objCongTrinh.TongMucDauTu);
                obj.NST = objCongTrinh.NST == null ? 0 : Convert.ToDecimal(objCongTrinh.NST);
                ChuDauTuDto objChuDauTu = _listChuDauTu.Where(x => x.Id == objCongTrinh.ChuDauTuId).FirstOrDefault();
                if (objChuDauTu != null && objChuDauTu.Id != Guid.Empty)
                {
                    obj.MaSoChuong = objChuDauTu.MaSoChuong;
                    obj.TenChuDauTu = objChuDauTu.Ten;
                }
                LoaiKhoanDto objLoaiKhoan = _listLoaiKhoan.Where(x => x.Id == objCongTrinh.LoaiKhoanId).ToList().FirstOrDefault();
                if (objLoaiKhoan != null && objLoaiKhoan.Id != Guid.Empty)
                {
                    obj.MaLoaiKhoan = objLoaiKhoan.MaSo;
                }
                obj.LuyKeVonTongCong = listLuyKe.Where(x => x.CongTrinhId == obj.CongTrinhId).Select(x => x.LuyKeVonTongCong).FirstOrDefault();
                obj.LuyKeVonNamTruoc = listLuyKe.Where(x => x.CongTrinhId == obj.CongTrinhId).Select(x => x.LuyKeVonNamTruoc).FirstOrDefault();
                obj.ParentId = parentId;
                obj.KeHoachVonId = Guid.NewGuid();
                obj.IsSelectDieuChinh = selectDieuChinh;
                if (listNhuCauVon != null && listNhuCauVon.Count > 0)
                {
                    if (_mainObject.LoaiKeHoach.ToString() == LoaiKeHoachVon.DAU_NAM.ToString())
                    {
                        obj.NhuCauKeHoachVonDauNam = listNhuCauVon.Where(x => x.CongTrinhID == obj.CongTrinhId).Select(x => x.NhuCauVonDauNamNST).FirstOrDefault();
                        obj.NhuCauKeHoachVonChiTietDauNamId = listNhuCauVon.Where(x => x.CongTrinhID == obj.CongTrinhId).Select(x => x.Id).FirstOrDefault();
                    }
                    else if (_mainObject.LoaiKeHoach.ToString() == LoaiKeHoachVon.DIEU_CHINH.ToString())
                    {
                        obj.NhuCauKeHoachVonDieuChinh = listNhuCauVon.Where(x => x.CongTrinhID == obj.CongTrinhId).Select(x => x.NhuCauVonDauNamNST).FirstOrDefault();
                        obj.NhuCauKeHoachVonChiTietDieuChinhId = listNhuCauVon.Where(x => x.CongTrinhID == obj.CongTrinhId).Select(x => x.Id).FirstOrDefault();
                    }
                }
                if (dictionary != null && dictionary.Count > 0)
                {
                    obj.Value = new Dictionary<string, decimal>();
                    List<string> keyValues = new List<string>(dictionary.Keys);
                    keyValues.ForEach(k =>
                    {
                        obj.Value.Add(k, 0);
                    });
                }
            }
            return obj;
        }

        private KeHoachVonNSTChiTietDto SetValueRowCongTrinhForDieuChinh(KeHoachVonNSTChiTietDto obj, Guid parentId, List<NhuCauKeHoachVonChiTietDto> listNhuCauVon)
        {
            CongTrinhDto objCongTrinh = _listCongTrinh.Where(x => x.Id == obj.CongTrinhId).FirstOrDefault();
            if (objCongTrinh != null && objCongTrinh.Id != Guid.Empty)
            {
                obj.TenDanhMuc = objCongTrinh.TenCongTrinh;
                obj.MaSoDuAn = objCongTrinh.MaSoDuAn;
                obj.SoQuyetDinh = objCongTrinh.SoQuyetDinhDauTu;
                obj.LoaiCongTrinhID = objCongTrinh.LoaiCongTrinhId == null ? Guid.Empty : new Guid(objCongTrinh.LoaiCongTrinhId.ToString());
                obj.TongMucDauTu = objCongTrinh.TongMucDauTu == null ? 0 : Convert.ToDecimal(objCongTrinh.TongMucDauTu);
                obj.NST = objCongTrinh.NST == null ? 0 : Convert.ToDecimal(objCongTrinh.NST);
                ChuDauTuDto objChuDauTu = _listChuDauTu.Where(x => x.Id == objCongTrinh.ChuDauTuId).FirstOrDefault();
                if (objChuDauTu != null && objChuDauTu.Id != Guid.Empty)
                {
                    obj.MaSoChuong = objChuDauTu.MaSoChuong;
                    obj.TenChuDauTu = objChuDauTu.Ten;
                }
                LoaiKhoanDto objLoaiKhoan = _listLoaiKhoan.Where(x => x.Id == objCongTrinh.LoaiKhoanId).ToList().FirstOrDefault();
                if (objLoaiKhoan != null && objLoaiKhoan.Id != Guid.Empty)
                {
                    obj.MaLoaiKhoan = objLoaiKhoan.MaSo;
                }
                obj.ParentId = parentId;
                obj.KeHoachVonId = Guid.NewGuid();
                if (listNhuCauVon != null && listNhuCauVon.Count > 0)
                {
                    obj.NhuCauKeHoachVonDieuChinh = listNhuCauVon.Where(x => x.CongTrinhID == obj.CongTrinhId).Select(x => x.NhuCauVonDieuChinhNST).FirstOrDefault();
                    obj.NhuCauKeHoachVonChiTietDieuChinhId = listNhuCauVon.Where(x => x.CongTrinhID == obj.CongTrinhId).Select(x => x.Id).FirstOrDefault();
                }
                obj.Value = SetValueDictionaryForDieuChinh(obj);
            }
            return obj;
        }

        private void SumValueGroupChiTiet()
        {
            if (_moduleObject == null)
                _moduleObject = new List<KeHoachVonNSTChiTietDto>();
            _moduleObject.Where(x => x.CongTrinhId == Guid.Empty).ForEach(o =>
            {
                o.LuyKeVonTongCong = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiKhoanId == o.LoaiKhoanId).Sum(x => x.LuyKeVonTongCong);
                o.LuyKeVonNamTruoc = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiKhoanId == o.LoaiKhoanId).Sum(x => x.LuyKeVonNamTruoc);
                o.NhuCauKeHoachVonDauNam = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiKhoanId == o.LoaiKhoanId).Sum(x => x.NhuCauKeHoachVonDauNam);
                o.NhuCauKeHoachVonDieuChinh = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty && x.LoaiKhoanId == o.LoaiKhoanId).Sum(x => x.NhuCauKeHoachVonDieuChinh);
            });
        }

        private List<NhuCauKeHoachVonChiTietDto> GetDataNhuCauVon(int nam, string loaikehoach, string tenKeHoach)
        {
            var data = new List<NhuCauKeHoachVonChiTietDto>();
            var api = ConfigManager.GetAPIByService<INhuCauKeHoachVonsApi>();
            var dataChung = api.GetSearchData(nam, loaikehoach, tenKeHoach, Guid.Empty).GetAwaiter().GetResult();
            if (dataChung != null && dataChung.Count > 0)
            {
                List<Guid> listGuid = dataChung.Where(x => x.TrangThai.ToLower().Trim() != TrangThaiKeHoachNhuCauVon.DANG_SOAN.ToString().ToLower().Trim()).Select(x => x.Id).Distinct().ToList();
                if (listGuid != null && listGuid.Count > 0)
                {
                    var apiChiTiet = ConfigManager.GetAPIByService<INhuCauKeHoachVonChiTietsApi>();
                    data = apiChiTiet.GetListDataByNhuCauVonIDAndCongTrinh(listGuid, Guid.Empty).GetAwaiter().GetResult();
                    if (data != null && data.Count > 0)
                    {
                        if (loaikehoach.ToString().ToLower().Trim() == LoaiKeHoachNhuCauVon.DAU_NAM.ToString().ToLower().Trim())
                        {
                            data = data.Where(x => x.IsSelectDieuChinh == false).ToList();
                        }
                        else if (loaikehoach.ToString().ToLower().Trim() == LoaiKeHoachNhuCauVon.DIEU_CHINH.ToString().ToLower().Trim())
                        {
                            data = data.Where(x => x.IsDeleteDieuChinh == false).ToList();
                        }
                        data = data.OrderBy(x => x.OrderIndex).ToList();
                    }
                }
            }
            return data;
        }
        #endregion

        #region Thêm công trình
        private void btn_AddCongTrinh_Click(object sender, EventArgs e)
        {
            _moduleObject = (List<KeHoachVonNSTChiTietDto>)tree_chitietkehoachvon.DataSource;
            if (_moduleObject == null)
            {
                _moduleObject = new List<KeHoachVonNSTChiTietDto>();
            }
            guiCongTrinh gui = new guiCongTrinh(_moduleObject.Select(x => x.CongTrinhId).Distinct().ToList(), _mainObject.Nam);
            gui.Module = Module;
            if (gui.ShowDialog() == DialogResult.OK)
            {
                SplashScreenManager.ShowForm(null, typeof(GGWaitForm), false, false, false, ParentFormState.Locked);

                List<NhuCauKeHoachVonChiTietDto> listNhuCauVon = GetDataNhuCauVon(_mainObject.Nam, _mainObject.LoaiKeHoach.ToString(), KeHoachNhuCauVon.HANG_NAM.ToString());
                var apiKHVChiTiet = ConfigManager.GetAPIByService<IKeHoachVonNSTChiTietApi>();
                List<KeHoachVonNSTChiTietDto> listLuyKe = apiKHVChiTiet.GetDataLuyKeByNam(_mainObject.Nam - 1).GetAwaiter().GetResult();
                if (listLuyKe == null)
                {
                    listLuyKe = new List<KeHoachVonNSTChiTietDto>();
                }

                Dictionary<string, decimal> dictionary = new Dictionary<string, decimal>();
                if (_moduleObject != null && _moduleObject.Count > 0)
                {
                    dictionary = _moduleObject[0].Value;
                }

                foreach (var item in gui._listCongTrinh)
                {
                    Guid loaiKhoanId = item.LoaiKhoanId == null ? Guid.Empty : new Guid(item.LoaiKhoanId.ToString());
                    if (_moduleObject.Where(x => x.LoaiKhoanId == loaiKhoanId && x.CongTrinhId == Guid.Empty).Count() == 0)
                    {
                        var loaiKhoan = _listLoaiKhoan.Where(x => x.Id == item.LoaiKhoanId).FirstOrDefault();
                        _moduleObject.Add(AddRowLoaiKhoan(loaiKhoan, dictionary));
                    }
                    KeHoachVonNSTChiTietDto objChiTiet = AddRowCongTrinh(loaiKhoanId, item.Id, _moduleObject.Where(x => x.LoaiKhoanId == item.LoaiKhoanId && x.CongTrinhId == Guid.Empty).Select(x => x.KeHoachVonId).FirstOrDefault(), listLuyKe, listNhuCauVon, dictionary);
                    if (objChiTiet != null && objChiTiet.CongTrinhId != Guid.Empty)
                    {
                        _moduleObject.Add(objChiTiet);
                    }
                }
                SumValueGroupChiTiet();

                RefreshDataSourceDetail();

                SplashScreenManager.CloseForm();
            }
        }
        #endregion 

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
            _moduleObject = (List<KeHoachVonNSTChiTietDto>)tree_chitietkehoachvon.DataSource;
            SetValueBySave();
            var result = GGMapper<KeHoachVonNSTDto, CreateUpdateKeHoachVonNSTDto>.MapSimple(_mainObject);

            var api = ConfigManager.GetAPIByService<IKeHoachVonNSTsApi>();

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
            var apiDetatil = ConfigManager.GetAPIByService<IKeHoachVonNSTChiTietApi>();
            var dataChiTietOld = apiDetatil.GetListByKeHoachVonNSTIdAsync(_mainObject.Id).GetAwaiter().GetResult();
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
                                apiDetatil.DeleteKeHoachVonNSTDieuChinhChiTietById(o.Id).GetAwaiter().GetResult();
                        });
                    }
                }

            }
            //CreateUpdate Detail
            _moduleObject.ForEach(o =>
            {
                o.KeHoachVonNSTId = _mainObject.Id;
                if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
                {
                    o.StringKeHoachVonDauNam = JsonConvert.SerializeObject(o.Value.Where(x => x.Key.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDauNam.ToString()))));
                    o.StringKeHoachVonDauNamDuocDuyet = JsonConvert.SerializeObject(o.Value.Where(x => x.Key.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString()))));
                }
                else
                {
                    o.StringDieuChinhGiam = JsonConvert.SerializeObject(o.Value.Where(x => x.Key.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.DieuChinhGiam.ToString()))));
                    o.StringDieuChinhTang = JsonConvert.SerializeObject(o.Value.Where(x => x.Key.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.DieuChinhTang.ToString()))));
                    o.StringKeHoachVonDieuChinh = JsonConvert.SerializeObject(o.Value.Where(x => x.Key.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinh.ToString()))));
                    o.StringKeHoachVonDieuChinhDuocDuyet = JsonConvert.SerializeObject(o.Value.Where(x => x.Key.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString()))));
                }
                var objDetail = GGMapper<KeHoachVonNSTChiTietDto, CreateUpdateKeHoachVonNSTChiTietDto>.MapSimple(o);
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
                    List<string> listString = listData.Where(x => x.Id != Guid.Empty).ToList().Select(x => x.Id.ToString()).Distinct().ToList();
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
                _mainObject.KeHoachVonDauNam = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(x => x.KeHoachVonDauNam);
                _mainObject.KeHoachVonDauNamDuocDuyet = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(x => x.KeHoachVonDauNamDuocDuyet);
            }
            else
            {
                _mainObject.KeHoachVonDieuChinh = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(x => x.KeHoachVonDieuChinh);
                _mainObject.KeHoachVonDieuChinhDuocDuyet = _moduleObject.Where(x => x.CongTrinhId != Guid.Empty).ToList().Sum(x => x.KeHoachVonDieuChinhDuocDuyet);
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
            var api = ConfigManager.GetAPIByService<IKeHoachVonNSTsApi>();
            var data = api.GetSearchData(Convert.ToInt32(_mainObject.Nam), string.Empty, string.Empty).GetAwaiter().GetResult();
            if (data != null && data.Count > 0)
            {

                //1.Đã tồn tại năm đó (cùng loại kế hoạch) không cho thêm mới
                if (data.Where(x => x.LoaiKeHoach == _mainObject.LoaiKeHoach.ToString()).ToList().Count() > 0)
                {
                    GGFunctions.ShowMessage("Năm và loại kế hoạch này đã phát sinh dữ liệu trên hệ thống, Vui lòng kiểm tra lại!");
                    isCheck = false;
                    return isCheck;
                }
                //2.Đã làm kế hoạch điều chỉnh thì không được làm kế hoạch đầu năm
                else if (_mainObject.LoaiKeHoach.ToString() == LoaiKeHoachVon.DAU_NAM.ToString()
                    && data.Where(x => x.LoaiKeHoach == LoaiKeHoachVon.DIEU_CHINH.ToString()).ToList().Count() > 0)
                {
                    GGFunctions.ShowMessage("Năm này đã làm kế hoạch điều chỉnh nên không được làm kế hoạch đầu năm, Vui lòng kiểm tra lại!");
                    isCheck = false;
                    return isCheck;
                }
            }
            _moduleObject = (List<KeHoachVonNSTChiTietDto>)tree_chitietkehoachvon.DataSource;
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

        #region Action Tải lại dữ liệu
        private void btn_RefreshData_Click(object sender, EventArgs e)
        {

        }

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
            List<KeHoachVonNSTChiTietDto> moduleObject = (List<KeHoachVonNSTChiTietDto>)tree_chitietkehoachvon.DataSource;
            //Copy Data
            if (_mainObject.LoaiKeHoach == LoaiKeHoachVon.DAU_NAM.ToString())
            {
                moduleObject.ForEach(o =>
                {
                    o.KeHoachVonDauNamDuocDuyet = o.KeHoachVonDauNam;

                    List<string> keyValues = new List<string>(o.Value.Keys);
                    keyValues.ForEach(u =>
                    {
                        if (u.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString())))
                        {
                            string key = u.Replace(KeHoachVonNSTChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), KeHoachVonNSTChiTietColumn.KeHoachVonDauNam.ToString());
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
                        if (u.Contains(ConvertStringColum(KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString())))
                        {
                            string key = u.Replace(KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString(), KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinh.ToString());
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

        #endregion Action Tải lại dữ liệu

        #region Action Đóng


        private void btn_Cancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        #endregion Action Đóng

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
            string path = ConfigManager.PathTreeListXML() + ModuleName.KHVTheoNganSachTinh + @"\" + TemplateDesignTreeList.TreeList_KeHoachVonNganSachTinh_DauNam.ToString();
            tree_chitietkehoachvon.Bands.Clear();
            tree_chitietkehoachvon.Columns.Clear();
            tree_chitietkehoachvon.InitializeControlByDesign(path, null);

            TreeListBand bandNhuCauVon = tree_chitietkehoachvon.Bands["Band_NhuCauVon"];
            bandNhuCauVon.Caption += _mainObject.Nam.ToString();

            TreeListBand bandDuKien = tree_chitietkehoachvon.Bands["Band_DuKien"];
            bandDuKien.Caption = KeHoachVonNSTChiTietColumn.KeHoachVonDauNam.GetDescription() + _mainObject.Nam.ToString();

            TreeListBand bandKeHoach = tree_chitietkehoachvon.Bands["Band_KeHoach"];
            bandKeHoach.Caption = KeHoachVonNSTChiTietColumn.KeHoachVonDauNamDuocDuyet.GetDescription() + _mainObject.Nam.ToString();

            TreeListBand bandLuyKe = tree_chitietkehoachvon.Bands["Band_LuyKe"];
            bandLuyKe.Caption = KeHoachVonNSTChiTietColumn.LuyKeVonNamTruoc.GetDescription() + (_mainObject.Nam - 1).ToString();

            TreeListBand bandLuyKeNam = bandLuyKe.Bands["Band_LuyKeNam"];
            if (bandLuyKeNam != null)
            {
                bandLuyKeNam.Caption = "Trong đó: năm " + (_mainObject.Nam - 1).ToString();
            }

            if (_mainObject.TrangThai == TrangThaiKeHoachVon.DANG_SOAN.ToString()
                || _mainObject.TrangThai == TrangThaiKeHoachVon.DA_TRINH.ToString()
                || _mainObject.TrangThai == TrangThaiKeHoachVon.YEU_CAU_CHINH_SUA.ToString())
            {
                AddChildrenGridBand(listNguonVon, bandDuKien, KeHoachVonNSTChiTietColumn.KeHoachVonDauNam.ToString(), true);
                AddChildrenGridBand(listNguonVon, bandKeHoach, KeHoachVonNSTChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), false);
            }

            else if (_mainObject.TrangThai == TrangThaiKeHoachVon.DUYET.ToString())
            {
                AddChildrenGridBand(listNguonVon, bandDuKien, KeHoachVonNSTChiTietColumn.KeHoachVonDauNam.ToString(), false);
                AddChildrenGridBand(listNguonVon, bandKeHoach, KeHoachVonNSTChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), true);

            }

            else if (_mainObject.TrangThai == TrangThaiKeHoachVon.HOAN_THANH.ToString())
            {
                AddChildrenGridBand(listNguonVon, bandDuKien, KeHoachVonNSTChiTietColumn.KeHoachVonDauNam.ToString(), false);
                AddChildrenGridBand(listNguonVon, bandKeHoach, KeHoachVonNSTChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), false);
            }
        }

        private void RefreshLayoutBandedGridViewByDieuChinh(List<NguonVonDto> listNguonVon)
        {
            List<NguonVonDto> listNguonVonDN = GetValueNguonVonByColumn(_moduleObject[0].Value, KeHoachVonNSTChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString());
            //Nếu không có nguồn vốn thì danh sách nguồn vốn theo Json
            if (listNguonVon == null || listNguonVon.Count == 0)
            {
                if (_moduleObject != null && _moduleObject.Count > 0)
                {
                    listNguonVon = GetValueNguonVonByColumn(_moduleObject[0].Value, KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinh.ToString());
                }
            }
            string path = ConfigManager.PathTreeListXML() + ModuleName.KHVTheoNganSachTinh + @"\" + TemplateDesignTreeList.TreeList_KeHoachVonNganSachTinh_DieuChinh.ToString();
            tree_chitietkehoachvon.Bands.Clear();
            tree_chitietkehoachvon.Columns.Clear();
            tree_chitietkehoachvon.DataSource = _moduleObject;
            tree_chitietkehoachvon.InitializeControlByDesign(path, null);

            TreeListBand bandNhuCauVon = tree_chitietkehoachvon.Bands["Band_NhuCauVon"];
            bandNhuCauVon.Caption += _mainObject.Nam.ToString();

            TreeListBand bandLuyKe = tree_chitietkehoachvon.Bands["Band_LuyKe"];
            bandLuyKe.Caption = KeHoachVonNSTChiTietColumn.LuyKeVonNamTruoc.GetDescription() + (_mainObject.Nam - 1).ToString();
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


            AddChildrenGridBand(listNguonVonDN, bandDauNam, KeHoachVonNSTChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), false);
            AddChildrenGridBand(listNguonVon, bandKeHoachVonDieuChinh, KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinh.ToString(), false);
            if (_mainObject.TrangThai == TrangThaiKeHoachVon.DANG_SOAN.ToString()
                || _mainObject.TrangThai == TrangThaiKeHoachVon.DA_TRINH.ToString()
                || _mainObject.TrangThai == TrangThaiKeHoachVon.YEU_CAU_CHINH_SUA.ToString())
            {
                AddChildrenGridBand(listNguonVon, bandDieuChinhGiam, KeHoachVonNSTChiTietColumn.DieuChinhGiam.ToString(), true);
                AddChildrenGridBand(listNguonVon, bandDieuChinhTang, KeHoachVonNSTChiTietColumn.DieuChinhTang.ToString(), true);
                AddChildrenGridBand(listNguonVon, bandKeHoachVonDieuChinhDuocDuyet, KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString(), false);
            }

            else if (_mainObject.TrangThai == TrangThaiKeHoachVon.DUYET.ToString())
            {
                AddChildrenGridBand(listNguonVon, bandDieuChinhGiam, KeHoachVonNSTChiTietColumn.DieuChinhGiam.ToString(), false);
                AddChildrenGridBand(listNguonVon, bandDieuChinhTang, KeHoachVonNSTChiTietColumn.DieuChinhTang.ToString(), false);
                AddChildrenGridBand(listNguonVon, bandKeHoachVonDieuChinhDuocDuyet, KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString(), true);

            }

            else if (_mainObject.TrangThai == TrangThaiKeHoachVon.HOAN_THANH.ToString())
            {
                AddChildrenGridBand(listNguonVon, bandDieuChinhGiam, KeHoachVonNSTChiTietColumn.DieuChinhGiam.ToString(), false);
                AddChildrenGridBand(listNguonVon, bandDieuChinhTang, KeHoachVonNSTChiTietColumn.DieuChinhTang.ToString(), false);
                AddChildrenGridBand(listNguonVon, bandKeHoachVonDieuChinhDuocDuyet, KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinhDuocDuyet.ToString(), false);
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
            foreach (KeHoachVonNSTChiTietDto item in _moduleObject)
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
            foreach (KeHoachVonNSTChiTietDto item in _moduleObject)
            {
                if (listString != null && listString.Count > 0 && item.Value != null && item.Value.Count > 0)
                {
                    var data = item.Value.Where(x => listString.Contains(x.Key.ToString().ToLower().Trim())).ToList();
                    item.Value = new Dictionary<string, decimal>();
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
            tree_chitietkehoachvon.DataSource = _moduleObject;
            tree_chitietkehoachvon.RefreshDataSource();
            SetPropertyTreeList();
        }

        public void SetPropertyTreeList()
        {
            tree_chitietkehoachvon.ExpandAll();
            TreeListColumn columnDanhMuc = tree_chitietkehoachvon.Columns[KeHoachVonNSTChiTietColumn.TenDanhMuc.ToString()];
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
                        string key = item.Key.Replace(KeHoachVonNSTChiTietColumn.KeHoachVonDauNamDuocDuyet.ToString(), column);
                        if (value.Where(x => x.Key.ToString().ToLower() == key.ToString().ToLower()).ToList().Count() == 0)
                        {
                            value.Add(key, (column == KeHoachVonNSTChiTietColumn.KeHoachVonDieuChinh.ToString() ? Convert.ToDecimal(item.Value.Trim()) : 0));
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

        #region Export Excel
        private void btn_ExportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_mainObject != null && _mainObject.Id != Guid.Empty)
            {
                ((KHVTheoNganSachTinhModule)Module).SetValueAndControl(_mainObject);
                ((KHVTheoNganSachTinhModule)Module).ExportExcel();
            }
            else
            {
                GGFunctions.ShowMessage("Dữ liệu chưa được lưu nên không thể xuất file excel!");
            }
        }
        #endregion

    }
}