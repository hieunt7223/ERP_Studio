var dataGoiThauThamDinh = new Array(0);
var dataGoiThauDuocPheDuyet = new Array(0);
var dataGoiThauDeNghiDieuChinh = new Array(0);
var dataGoiThauDeXuat = new Array(0);
var dataKetQuaThamDinh = new Array(0);
var dataCongViecThucHien = new Array(0);
var dataCongViecKhongApDung = new Array(0);
var dataCongViecChuaDuDieuKienLapKeHoach = new Array(0);
var dataCongViecThuocKeHoach = new Array(0);
var selectingKetQuaThamDinhValue = null;
var selectingCongViecThuocKeHoachValue = null;
var selectingCongViecThucHienValue = null;
var selectingCongViecKhongApDungValue = null;
var selectingCongViecChuaDuDieuKienLapKeHoachValue = null;
var selectingGoiThauThamDinhValue = null;
var selectingGoiThauDươcPheDuyetValue = null;
var selectingGoiThauDeNghiDieuChinhValue = null;
var selectingGoiThauDeXuatValue = null;

// Start - Xử lý Phần công việc thuộc kế hoạch
function addRowCongViecThuocKeHoach() {
    var dataGrid = $('#congviecthuockehoach-table').dxDataGrid('instance');
    selectingCongViecThuocKeHoachValue = null;
    dataGrid.addRow();
}

function onEditorPreparingCongViecThuocKeHoach(e) {
    if (e.dataField === "CongViecGoiThauId" && e.parentType === "dataRow") {
        e.editorOptions.placeholder = consts.textPlaceholder.selectBox;
    }
}

function getDataCongViecThuocKeHoach(e) {
    var ds = e.component.getDataSource();
    var filter = e.component.getCombinedFilter();
    ds.store().load({ sort: ds.sort(), filter: filter ? filter : null })
        .done((allData) => {
            dataCongViecThuocKeHoach = allData;
        });
}

function formatDataCongViecThuocKeHoach() {
    return dataCongViecThuocKeHoach;
}

function onEditingStartCongViecThuocKeHoach(e) {
    selectingCongViecThuocKeHoachValue = e.data.CongViecGoiThauId;
}

function getCongViecThuocKeHoach() {
    var exceptedDataString = null;

    dataCongViecThuocKeHoach.forEach(function (item) {
        if (item.CongViecGoiThauId != selectingCongViecThuocKeHoachValue) {
            if (exceptedDataString != null) {
                exceptedDataString = exceptedDataString + "&ids=" + item.CongViecGoiThauId;
            } else {
                exceptedDataString = "ids=" + item.CongViecGoiThauId;
            }
        }
    });

    return {
        store: new DevExpress.data.CustomStore({
            loadMode: "raw",
            load: function () {
                return $.getJSON("/api/app/goiThau/child?" + exceptedDataString);
            }
        })
    };
}
// End - Xử lý Phần công việc thuộc kế hoạch

// Start - Xử lý Phần công việc không áp dụng
function addRowCongViecKhongApDung() {
    var dataGrid = $('#congvieckhongapdung-table').dxDataGrid('instance');
    selectingCongViecKhongApDungValue = null;
    dataGrid.addRow();
}

function onEditorPreparingCongViecKhongApDung(e) {
    if ((e.dataField === "CongViecGoiThauId" || e.dataField === "DonViThucHienId") && e.parentType === "dataRow") {
        e.editorOptions.placeholder = consts.textPlaceholder.selectBox;
    }
    else {
        e.editorOptions.placeholder = consts.textPlaceholder.text;
    }
}

function getDataCongViecKhongApDung(e) {
    var ds = e.component.getDataSource();
    var filter = e.component.getCombinedFilter();
    ds.store().load({ sort: ds.sort(), filter: filter ? filter : null })
        .done((allData) => {
            dataCongViecKhongApDung = allData;
        });
}

function formatDataCongViecKhongApDung() {
    return dataCongViecKhongApDung;
}

function onEditingStartCongViecKhongApDung(e) {
    selectingCongViecKhongApDungValue = e.data.CongViecGoiThauId;
}

function getCongViecKhongApDung() {
    var exceptedDataString = null;

    dataCongViecKhongApDung.concat(dataCongViecThucHien).forEach(function (item) {
        if (item.CongViecGoiThauId != selectingCongViecKhongApDungValue) {
            if (exceptedDataString != null) {
                exceptedDataString = exceptedDataString + "&ids=" + item.CongViecGoiThauId;
            } else {
                exceptedDataString = "ids=" + item.CongViecGoiThauId;
            }
        }
    });

    return {
        store: new DevExpress.data.CustomStore({
            loadMode: "raw",
            load: function () {
                return $.getJSON("/api/app/goiThau/child?" + exceptedDataString);
            }
        })
    };
}
// End - Xử lý Phần công việc không áp dụng

// Start - Xử lý Phần công việc chưa đủ điều kiện lập kế hoạch
function addRowCongViecChuaDuDieuKienLapKeHoach() {
    var dataGrid = $('#congviecchuadudieukienlapkehoach-table').dxDataGrid('instance');
    selectingCongViecChuaDuDieuKienLapKeHoachvalue = null;
    dataGrid.addRow();
}

function onEditorPreparingCongViecChuaDuDieuKienLapKeHoach(e) {
    if (e.dataField === "CongViecGoiThauId" && e.parentType === "dataRow") {
        e.editorOptions.placeholder = consts.textPlaceholder.selectBox;
    }
    else {
        e.editorOptions.placeholder = consts.textPlaceholder.text;
    }
}

function getDataCongViecChuaDuDieuKienLapKeHoach(e) {
    var ds = e.component.getDataSource();
    var filter = e.component.getCombinedFilter();
    ds.store().load({ sort: ds.sort(), filter: filter ? filter : null })
        .done((allData) => {
            dataCongViecChuaDuDieuKienLapKeHoach = allData;
        });
}

function formatDataCongViecChuaDuDieuKienLapKeHoach() {
    return dataCongViecChuaDuDieuKienLapKeHoach;
}

function onEditingStartCongViecChuaDuDieuKienLapKeHoach(e) {
    selectingCongViecChuaDuDieuKienLapKeHoachValue = e.data.CongViecGoiThauId;
}

function getCongViecChuaDuDieuKienLapKeHoach() {
    var exceptedDataString = null;

    dataCongViecChuaDuDieuKienLapKeHoach.forEach(function (item) {
        if (item.CongViecGoiThauId != selectingCongViecChuaDuDieuKienLapKeHoachValue) {
            if (exceptedDataString != null) {
                exceptedDataString = exceptedDataString + "&ids=" + item.CongViecGoiThauId;
            } else {
                exceptedDataString = "ids=" + item.CongViecGoiThauId;
            }
        }
    });

    return {
        store: new DevExpress.data.CustomStore({
            loadMode: "raw",
            load: function () {
                return $.getJSON("/api/app/goiThau/child?" + exceptedDataString);
            }
        })
    };
}
// End - Xử lý Phần công việc chưa đủ điều kiện lập kế hoạch

// Start - Xử lý Phần công việc thực hiện
function addRowCongViecThucHien() {
    var dataGrid = $('#congviecthuchien-table').dxDataGrid('instance');
    selectingCongViecThucHienValue = null;
    dataGrid.addRow();
}

function onEditorPreparingCongViecThucHien(e) {
    if (e.dataField === "CongViecGoiThauId" && e.parentType === "dataRow") {
        e.editorOptions.placeholder = consts.textPlaceholder.selectBox;
    }
    else {
        e.editorOptions.placeholder = consts.textPlaceholder.text;
    }
}

function getDataCongViecThucHien(e) {
    var ds = e.component.getDataSource();
    var filter = e.component.getCombinedFilter();
    ds.store().load({ sort: ds.sort(), filter: filter ? filter : null })
        .done((allData) => {
            dataCongViecThucHien = allData;
        });
}

function formatDataCongViecThucHien() {
    return dataCongViecThucHien;
}

function onEditingStartCongViecThucHien(e) {
    selectingCongViecThucHienValue = e.data.CongViecGoiThauId;
}

function getCongViecThucHien() {
    var exceptedDataString = null;

    dataCongViecKhongApDung.concat(dataCongViecThucHien).forEach(function (item) {
        if (item.CongViecGoiThauId != selectingCongViecThucHienValue) {
            if (exceptedDataString != null) {
                exceptedDataString = exceptedDataString + "&ids=" + item.CongViecGoiThauId;
            } else {
                exceptedDataString = "ids=" + item.CongViecGoiThauId;
            }
        }
    });

    return {
        store: new DevExpress.data.CustomStore({
            loadMode: "raw",
            load: function () {
                return $.getJSON("/api/app/goiThau/child?" + exceptedDataString);
            }
        })
    };
}
// End - Xử lý Phần công việc thực hiện

// Start - Xử lý Kết quả thẩm định về căn cứ pháp lý
function addRowKetQuaThamDinhPhapLy() {
    var dataGrid = $('#ketquathamdinhphaply-table').dxDataGrid('instance');
    selectingKetQuaThamDinhValue = null;
    dataGrid.addRow();
}

function onEditorPreparingKetQuaThamDinh(e) {
    if (e.dataField === "TenNoiDungKiemTra" && e.parentType === "dataRow") {
        e.editorOptions.placeholder = consts.textPlaceholder.selectBox;
    }
}

function getDataKetQuaThamDinh(e) {
    var ds = e.component.getDataSource();
    var filter = e.component.getCombinedFilter();
    ds.store().load({ sort: ds.sort(), filter: filter ? filter : null })
        .done((allData) => {
            dataKetQuaThamDinh = allData;
        });
}

function formatDataKetQuaThamDinh() {
    return dataKetQuaThamDinh;
}

function onEditingStartKetQuaThamDinh(e) {
    selectingKetQuaThamDinhValue = e.data.TenNoiDungKiemTra;
}

function getKetQuaThamDinh() {
    var ketQuaThamDinhs = new Array(0);
    var selectedKetQuaThamDinhs = new Array(0);

    dataThanhPhanHoSo.forEach(function (item) {
        var noiDung = "";

        if (item.SoQuyetDinh && item.SoQuyetDinh != "") {
            noiDung += item.SoQuyetDinh;
        }
        if (item.NgayBanHanhFormat && item.NgayBanHanhFormat != "") {
            noiDung += " ngày " + item.NgayBanHanhFormat;
        }
        if (item.TenDonViBanHanh && item.TenDonViBanHanh != "") {
            noiDung += " của " + item.TenDonViBanHanh;
        }
        if (item.TrichYeu && item.TrichYeu != "") {
            noiDung += " về " + item.TrichYeu;
        }

        if (noiDung != "") {
            ketQuaThamDinhs.push(noiDung);
        }
    });

    selectedKetQuaThamDinhs = dataKetQuaThamDinh.map(function (item) { return item.TenNoiDungKiemTra; });

    if (selectingKetQuaThamDinhValue) {
        ketQuaThamDinhs = ketQuaThamDinhs.filter(x => !selectedKetQuaThamDinhs.includes(x));
        ketQuaThamDinhs.push(selectingKetQuaThamDinhValue);
    } else {
        ketQuaThamDinhs = ketQuaThamDinhs.filter(x => !selectedKetQuaThamDinhs.includes(x));
    }

    return {
        store: new DevExpress.data.CustomStore({
            loadMode: "raw",
            load: function () {
                return ketQuaThamDinhs;
            }
        })
    };
}
// End - Xử lý Kết quả thẩm định về căn cứ pháp lý

// Start - Xử lý Gói thầu thẩm định
function addRowGoiThauThamDinh() {
    var treeList = $('#goithauthamdinh-treelist').dxTreeList('instance');
    selectingGoiThauThamDinhValue = null;
    treeList.addRow();
}

function onInitNewRowGoiThauThamDinh() {
    selectingGoiThauThamDinhValue = null;
}

function onEditorPreparingGoiThauThamDinh(e) {
    if (e.row.data.GoiThauParentId == consts.guid_is_null) {
        if (e.dataField === "GiaGoiThau" || e.dataField === "HinhThucLuaChonNhaThauId"
            || e.dataField === "PhuongThucLuaChonNhaThauId" || e.dataField === "ThoiGianBatDau"
            || e.dataField === "LoaiHopDongId" || e.dataField === "ThoiGianThucHien") {
            e.editorOptions.readOnly = true;
        }
        if (
            (e.dataField === "HinhThucLuaChonNhaThauId"
                || e.dataField === "PhuongThucLuaChonNhaThauId" || e.dataField === "LoaiHopDongId"
            ) && e.parentType === "dataRow") {
            e.editorOptions.placeholder = "";
        }
        else if (e.dataField === "GoiThauId" && e.parentType === "dataRow") {
            e.editorOptions.placeholder = consts.textPlaceholder.selectBox;
        }
    } else {
        if (
            (e.dataField === "GoiThauId" || e.dataField === "HinhThucLuaChonNhaThauId"
                || e.dataField === "PhuongThucLuaChonNhaThauId" || e.dataField === "LoaiHopDongId"
            ) && e.parentType === "dataRow") {
            e.editorOptions.placeholder = consts.textPlaceholder.selectBox;
        }
        else {
            e.editorOptions.placeholder = consts.textPlaceholder.text;
        }
    }
}

function onCellPreparedGoiThauThamDinh(e) {
    if (e.rowType == "data") {
        if (e.row.data.GoiThauParentId == consts.guid_is_null) {
            e.cellElement.find(".dx-link-edit").remove();
        } else {
            e.cellElement.find(".dx-link-add").remove();
        }
    }
}

function onEditingStartGoiThauThamDinh(e) {
    selectingGoiThauThamDinhValue = e.data.GoiThauId;
}

function getGoiThauThamDinh(e) {
    var goiThaus = null;
    var exceptedDataString = null;

    dataGoiThauThamDinh.forEach(function (item) {
        if (item.GoiThauId != selectingGoiThauThamDinhValue) {
            if (exceptedDataString != null) {
                exceptedDataString = exceptedDataString + "&childIds=" + item.GoiThauId;
            } else {
                exceptedDataString = "?childIds=" + item.GoiThauId;
            }
        }
    });

    if (e.data && e.data.GoiThauParentId != consts.guid_is_null) {
        goiThaus = {
            store: new DevExpress.data.CustomStore({
                loadMode: "raw",
                load: function () {
                    return $.getJSON("/api/app/goiThau/childByCriteria/" + e.data.GoiThauParentId + exceptedDataString);
                }
            })
        };
    } else {
        goiThaus = {
            store: new DevExpress.data.CustomStore({
                loadMode: "raw",
                load: function () {
                    return $.getJSON("/api/app/goiThau/goiThaus");
                }
            })
        };
    }

    return goiThaus;
}

function getDataGoiThauThamDinh(e) {
    removeStyleDefaultTreeList();
    var ds = e.component.getDataSource();
    var filter = e.component.getCombinedFilter();
    ds.store().load({ sort: ds.sort(), filter: filter ? filter : null })
        .done((allData) => {
            dataGoiThauThamDinh = allData;
        });
}

function formatDataGoiThauThamDinh() {
    var parentIds = new Array(0);
    var parentIdsByNode = dataGoiThauThamDinh.map(function (item) { return item.GoiThauParentId; });
    var parentIdsByRoot = dataGoiThauThamDinh.filter(x => x.GoiThauParentId == consts.guid_is_null).map(function (item) { return item.GoiThauId; });

    parentIdsByNode = parentIdsByNode.filter(function (item, i, parentIdsByNode) { return i == parentIdsByNode.indexOf(item); }).filter(x => x != consts.guid_is_null);
    parentIds = parentIdsByNode.filter(x => !parentIdsByRoot.includes(x));
    dataGoiThauThamDinh = dataGoiThauThamDinh.filter(x => !parentIds.includes(x.GoiThauParentId));

    return dataGoiThauThamDinh;
}
// End - Xử lý Gói thầu thẩm định

// Start - Xử lý Gói thầu được phê duyệt
function addRowGoiThauDuocPheDuyet() {
    var treeList = $('#goithauduocpheduyet-treelist').dxTreeList('instance');
    selectingGoiThauDươcPheDuyetValue = null;
    treeList.addRow();
}

function onInitNewRowGoiThauDuocPheDuyet() {
    selectingGoiThauDuocPheDuyetValue = null;
}

function onEditingStartGoiThauDuocPheDuyet(e) {
    selectingGoiThauDươcPheDuyetValue = e.data.GoiThauId;
}

function getGoiThauDuocPheDuyet(e) {
    var goiThaus = null;
    var exceptedDataString = null;

    dataGoiThauDuocPheDuyet.forEach(function (item) {
        if (item.GoiThauId != selectingGoiThauDươcPheDuyetValue) {
            if (exceptedDataString != null) {
                exceptedDataString = exceptedDataString + "&childIds=" + item.GoiThauId;
            } else {
                exceptedDataString = "?childIds=" + item.GoiThauId;
            }
        }
    });

    if (e.data && e.data.GoiThauParentId != consts.guid_is_null) {
        goiThaus = {
            store: new DevExpress.data.CustomStore({
                loadMode: "raw",
                load: function () {
                    return $.getJSON("/api/app/goiThau/childByCriteria/" + e.data.GoiThauParentId + exceptedDataString);
                }
            })
        };
    } else {
        goiThaus = {
            store: new DevExpress.data.CustomStore({
                loadMode: "raw",
                load: function () {
                    return $.getJSON("/api/app/goiThau/goiThaus");
                }
            })
        };
    }

    return goiThaus;
}

function getDataGoiThauDuocPheDuyet(e) {
    removeStyleDefaultTreeList();
    var ds = e.component.getDataSource();
    var filter = e.component.getCombinedFilter();
    ds.store().load({ sort: ds.sort(), filter: filter ? filter : null })
        .done((allData) => {
            dataGoiThauDuocPheDuyet = allData;
        });
}

function formatDatGoiThauDuocPheDuyet() {
    var parentIds = new Array(0);
    var parentIdsByNode = dataGoiThauDuocPheDuyet.map(function (item) { return item.GoiThauParentId; });
    var parentIdsByRoot = dataGoiThauDuocPheDuyet.filter(x => x.GoiThauParentId == consts.guid_is_null).map(function (item) { return item.GoiThauId; });

    parentIdsByNode = parentIdsByNode.filter(function (item, i, parentIdsByNode) { return i == parentIdsByNode.indexOf(item); }).filter(x => x != consts.guid_is_null);
    parentIds = parentIdsByNode.filter(x => !parentIdsByRoot.includes(x));
    dataGoiThauDuocPheDuyet = dataGoiThauDuocPheDuyet.filter(x => !parentIds.includes(x.GoiThauParentId));

    return dataGoiThauDuocPheDuyet;
}
// End - Xử lý Gói thầu được phê duyệt

// Start - Xử lý Gói thầu đề nghị điều chỉnh
function addRowGoiThauDeNghiDieuChinh() {
    var treeList = $('#goithaudenghidieuchinh-treelist').dxTreeList('instance');
    selectingGoiThauDeNghiDieuChinhValue = null;
    treeList.addRow();
}

function onInitNewRowGoiThauDeNghiDieuChinh() {
    selectingGoiThauDeNghiDieuChinhValue = null;
}

function onEditingStartGoiThauDeNghiDieuChinh(e) {
    selectingGoiThauDeNghiDieuChinhValue = e.data.GoiThauId;
}

function getGoiThauDeNghiDieuChinh(e) {
    var goiThaus = null;
    var exceptedDataString = null;

    dataGoiThauDeNghiDieuChinh.forEach(function (item) {
        if (item.GoiThauId != selectingGoiThauDeNghiDieuChinhValue) {
            if (exceptedDataString != null) {
                exceptedDataString = exceptedDataString + "&childIds=" + item.GoiThauId;
            } else {
                exceptedDataString = "?childIds=" + item.GoiThauId;
            }
        }
    });

    if (e.data && e.data.GoiThauParentId != consts.guid_is_null) {
        goiThaus = {
            store: new DevExpress.data.CustomStore({
                loadMode: "raw",
                load: function () {
                    return $.getJSON("/api/app/goiThau/childByCriteria/" + e.data.GoiThauParentId + exceptedDataString);
                }
            })
        };
    } else {
        goiThaus = {
            store: new DevExpress.data.CustomStore({
                loadMode: "raw",
                load: function () {
                    return $.getJSON("/api/app/goiThau/goiThaus");
                }
            })
        };
    }

    return goiThaus;
}

function getDataGoiThauDeNghiDieuChinh(e) {
    removeStyleDefaultTreeList();
    var ds = e.component.getDataSource();
    var filter = e.component.getCombinedFilter();
    ds.store().load({ sort: ds.sort(), filter: filter ? filter : null })
        .done((allData) => {
            dataGoiThauDeNghiDieuChinh = allData;
        });
}

function formatDataGoiThauDeNghiDieuChinh() {
    var parentIds = new Array(0);
    var parentIdsByNode = dataGoiThauDeNghiDieuChinh.map(function (item) { return item.GoiThauParentId; });
    var parentIdsByRoot = dataGoiThauDeNghiDieuChinh.filter(x => x.GoiThauParentId == consts.guid_is_null).map(function (item) { return item.GoiThauId; });

    parentIdsByNode = parentIdsByNode.filter(function (item, i, parentIdsByNode) { return i == parentIdsByNode.indexOf(item); }).filter(x => x != consts.guid_is_null);
    parentIds = parentIdsByNode.filter(x => !parentIdsByRoot.includes(x));
    dataGoiThauDeNghiDieuChinh = dataGoiThauDeNghiDieuChinh.filter(x => !parentIds.includes(x.GoiThauParentId));

    return dataGoiThauDeNghiDieuChinh;
}
// End - Xử lý Gói thầu đề nghị điều chỉnh

// Start - Xử lý Gói thầu đề xuất
function addRowGoiThauDeXuat() {
    var treeList = $('#goithaudexuat-treelist').dxTreeList('instance');
    selectingGoiThauDeXuatValue = null;
    treeList.addRow();
}

function onInitNewRowGoiThauDeXuat() {
    selectingGoiThauDeXuatValue = null;
}

function onEditingStartGoiThauDeXuat(e) {
    selectingGoiThauDeXuatValue = e.data.GoiThauId;
}

function getGoiThauDeXuat(e) {
    var goiThaus = null;
    var exceptedDataString = null;

    dataGoiThauDeXuat.forEach(function (item) {
        if (item.GoiThauId != selectingGoiThauDeXuatValue) {
            if (exceptedDataString != null) {
                exceptedDataString = exceptedDataString + "&childIds=" + item.GoiThauId;
            } else {
                exceptedDataString = "?childIds=" + item.GoiThauId;
            }
        }
    });

    if (e.data && e.data.GoiThauParentId != consts.guid_is_null) {
        goiThaus = {
            store: new DevExpress.data.CustomStore({
                loadMode: "raw",
                load: function () {
                    return $.getJSON("/api/app/goiThau/childByCriteria/" + e.data.GoiThauParentId + exceptedDataString);
                }
            })
        };
    } else {
        goiThaus = {
            store: new DevExpress.data.CustomStore({
                loadMode: "raw",
                load: function () {
                    return $.getJSON("/api/app/goiThau/goiThaus");
                }
            })
        };
    }

    return goiThaus;
}

function getDataGoiThauDeXuat(e) {
    removeStyleDefaultTreeList();
    var ds = e.component.getDataSource();
    var filter = e.component.getCombinedFilter();
    ds.store().load({ sort: ds.sort(), filter: filter ? filter : null })
        .done((allData) => {
            dataGoiThauDeXuat = allData;
        });
}

function formatDataGoiThauDeXuat() {
    var parentIds = new Array(0);
    var parentIdsByNode = dataGoiThauDeXuat.map(function (item) { return item.GoiThauParentId; });
    var parentIdsByRoot = dataGoiThauDeXuat.filter(x => x.GoiThauParentId == consts.guid_is_null).map(function (item) { return item.GoiThauId; });

    parentIdsByNode = parentIdsByNode.filter(function (item, i, parentIdsByNode) { return i == parentIdsByNode.indexOf(item); }).filter(x => x != consts.guid_is_null);
    parentIds = parentIdsByNode.filter(x => !parentIdsByRoot.includes(x));
    dataGoiThauDeXuat = dataGoiThauDeXuat.filter(x => !parentIds.includes(x.GoiThauParentId));

    return dataGoiThauDeXuat;
}
// End - Xử lý Gói thầu đề xuất

function checkValidDuplication(error) {
    error.error.message = messages.NotAllowDuplicate;
    error.error.url = "";
}