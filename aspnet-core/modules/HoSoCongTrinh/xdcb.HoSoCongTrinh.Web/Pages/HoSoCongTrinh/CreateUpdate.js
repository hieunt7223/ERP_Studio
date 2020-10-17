$(document).ready(function () {
    $(".content-wrapper").addClass("content-wrapper-detail");
    $(".isOpened").addClass("show");

    var $datepicker = $('#hanXuLy');
    var date = $('#hanXuLyDefault').val();
    var day = date.substr(0, 2);
    var month = date.substr(3, 2);
    var year = date.substr(6, 4);
    var datepicker = new Date(year, month - 1, day);
    $datepicker.datepicker("setDate", new Intl.DateTimeFormat('en-GB').format(datepicker));
});

var loadPanel = $(".loadpanel").dxLoadPanel({
    shadingColor: "rgba(0,0,0,0.4)",
    position: { of: "#container-load-page" },
    visible: false,
    message: messages.loading_panel,
    showIndicator: true,
    showPane: true,
    shading: true,
    closeOnOutsideClick: false,
}).dxLoadPanel("instance");

var valueSuCanThietDauTu = null;
var valueQuyMoDauTu = null;
var selectedThuVienVanBans = new Array(0);
var selectingThuVienVanBans = new Array(0);
var dataCoSoPhapLy = new Array(0);
var dataDefaultCoSoPhapLy = new Array(0);
var dataDiaDiemThucHien = new Array(0);
var dataNguonVonDauTu = new Array(0);
var dataThanhPhanHoSo = new Array(0);
var selectingPhuongValue = null;
var selectingNguonVonDauTuValue = null;
var thanhPhanHoSoId = null;
var deletedFileIds = new Array(0);

function removeStyleDefaultTreeList() {
    $(".dx-treelist-header-panel").remove();
}

function addRowDiaDiemThucHien() {
    var dataGrid = $('#diadiemthuchien-table').dxDataGrid('instance');
    dataGrid.addRow();
}

function addRowNguonVonDauTu() {
    var dataGrid = $('#nguonvondautu-table').dxDataGrid('instance');
    dataGrid.addRow();
}

function onEditingStartDiaDiemThucHien(e) {
    selectingPhuongValue = e.data.DonViHanhChinhId;
}

function onInitNewRowDiaDiemThucHien() {
    selectingPhuongValue = null;
}

function onEditingStartNguonVonDauTu(e) {
    selectingNguonVonDauTuValue = e.data.NguonVonId;
}

function onEditorPreparingDiaDiemThucHien(e) {
    if ((e.dataField === "ThanhPho" || e.dataField === "DonViHanhChinhId") && e.parentType === "dataRow") {
        e.editorOptions.placeholder = consts.textPlaceholder.selectBox;
    }
    else {
        e.editorOptions.placeholder = consts.textPlaceholder.text;
    }
}

function onEditorPreparingNguonVonDauTu(e) {
    if (e.dataField === "NguonVonId" && e.parentType === "dataRow") {
        e.editorOptions.placeholder = consts.textPlaceholder.selectBox;
    }
    else {
        e.editorOptions.placeholder = consts.textPlaceholder.text;
    }
}

function getPhuongs(options) {
    var exceptedDataString = null;

    dataDiaDiemThucHien.forEach(function (item) {
        if (item.DonViHanhChinhId != selectingPhuongValue) {
            if (exceptedDataString != null) {
                exceptedDataString = exceptedDataString + "&ids=" + item.DonViHanhChinhId;
            } else {
                exceptedDataString = "ids=" + item.DonViHanhChinhId;
            }
        }
    });

    return {
        store: new DevExpress.data.CustomStore({
            loadMode: "raw",
            load: function () {
                return $.getJSON("/api/app/donViHanhChinh/donViCapPhuongXaThiTran/excludeIds?" + exceptedDataString );
            }
        }),
        filter: options.data ? [
            "parentId", "=", options.data.DonViHanhChinhChaId
        ] : null,
    };
}

function getNguonVonDauTus() {
    var exceptedDataString = null;

    dataNguonVonDauTu.forEach(function (item) {
        if (item.NguonVonId != selectingNguonVonDauTuValue) {
            if (exceptedDataString != null) {
                exceptedDataString = exceptedDataString + "&ids=" + item.NguonVonId;
            } else {
                exceptedDataString = "ids=" + item.NguonVonId;
            }
        }
    });

    return {
        store: new DevExpress.data.CustomStore({
            loadMode: "raw",
            load: function () {
                return $.getJSON("/api/app/nguonVon/excludeIds?" + exceptedDataString);
            }
        })
    };
}

function setThanhPhoValue(rowData, value) {
    rowData.DonViHanhChinhChaId = value;
    rowData.DonViHanhChinhId = null;
}

function checkValidTphsMacDinh() {
    if ($(".valid-tphs-macdinh").length > 0) {
        $("body").removeClass("fixedPosition");
        $("body").addClass("fixed");
        return false;
    }

    return true;
}   

$("#OnSaveCV").click(function () {
    var actionName = "SaveCV";
    CheckAction(actionName);
});

$("#OnCompleteCV").click(function () {
    var actionName = "CompleteCV";
    CheckAction(actionName);
});

$("#OnRequestEditCV").click(function () {
    var actionName = "RequestEditCV";
    CheckAction(actionName);
});

$("#OnSaveCDT").click(function () {
    var actionName = "SaveCDT";
    CheckAction(actionName);
});

$("#OnSendCDT").click(function () {
    var actionName = "SendCDT";
    CheckAction(actionName);
});

function OnSave(actionName, hoSoCongTrinhId, hoSoCongTrinhChiTietId) {
    var isValidTphsMacDinh = checkValidTphsMacDinh();

    if (isValidTphsMacDinh) {
        loadPanel.show();
        var newHoSoCongTrinhChiTiet = formatDatToInsert(actionName, hoSoCongTrinhId, hoSoCongTrinhChiTietId);
        abp.ajax({
            url: '/api/app/hoSoCongTrinh',
            type: "post",
            data: JSON.stringify(newHoSoCongTrinhChiTiet)
        }).done(function () {
            deleteFile();
            window.location.href = 'List';
        });
    } else {
        abp.notify.error(messages.NotEnoughData);
    }
}

function OnUpdate(actionName, hoSoCongTrinhId, hoSoCongTrinhChiTietId) {
    var isValidTphsMacDinh = checkValidTphsMacDinh();

    if (isValidTphsMacDinh) {
        loadPanel.show();
        var newHoSoCongTrinhChiTiet = formatDatToInsert(actionName, hoSoCongTrinhId, hoSoCongTrinhChiTietId);
        var urlRequest = '/api/app/hoSoCongTrinh/' + $("#hoSoCongTrinhId").val();
        abp.ajax({
            url: urlRequest,
            type: "put",
            data: JSON.stringify(newHoSoCongTrinhChiTiet)
        }).done(function () {
            deleteFile();
            window.location.href = 'List';
        });
    } else {
        abp.notify.error(messages.NotEnoughData);
    }
}

function formatDatToInsert(actionName, hoSoCongTrinhId, hoSoCongTrinhChiTietId) {
    var data =
    {
        congTrinhId: $("#congTrinhId").val(),
        loaiHoSoId: $("#loaiHoSoId").val(),
        trangThai: GetTrangThaiByAction(actionName),
        soLanDieuChinh: parseInt($("#soLanDieuChinh").val()),
        hanXuLy: $("#hanXuLy").val(),
        hoSoCongTrinhChiTietDtos: [
            {
                trangThai: GetTrangThaiByAction(actionName),
                soLanDieuChinh: parseInt($("#soLanDieuChinh").val()),
                hanXuLy: $("#hanXuLy").val(),
                suCanThietDauTu: $("#suCanThietDauTu").dxTextArea("instance").option("value"),
                quyMoDauTu: $("#quyMoDauTu").dxTextArea("instance").option("value"),
                diaDiemXayDungs: FormatDataDiaDiemThucHien(),
                mucDauTuPheDuyet: $("#mucDauTuPheDuyet").length > 0 ? $("#mucDauTuPheDuyet").dxNumberBox("instance").option("value") : 0,
                mucDauTuBoSung: $("#mucDauTuBoSung").length > 0 ? $("#mucDauTuBoSung").dxNumberBox("instance").option("value") : 0,
                tongMucDauTu: $("#tongMucDauTu").length > 0 ? $("#tongMucDauTu").dxNumberBox("instance").option("value") : 0,
                mucDuToanDuocDuyet: $("#tongMucDuToanDuocDuyet").length > 0 ? $("#tongMucDuToanDuocDuyet").dxNumberBox("instance").option("value") : 0,
                thanhPhanHoSos: FormatDataThanhPhanHoSo(),
                coSoPhapLys: FormatDataCoSoPhapLy(),
                ketQuaThamDinhs: GetFileId(),
                nguonVons: FormatDataNguonVonDauTu(),
                yKienThamDinh: getDataYKienThamDinhBaoCaoChuTruong(),
                thamDinhGoiThau: getDataYKienThamDinhKeHoachNhaThau(),
                thamDinhDieuChinhGoiThau: getDataYKienThamDinhDieuChinhNhaThau(),
                mucTieuDauTu: $("#mucTieuDauTu").val(),
                nganhLinhVucSuDungId: $("#nganhLinhVucDauTu").children("option:selected").val() != "" ? $("#nganhLinhVucDauTu").children("option:selected").val() : consts.guid_is_null,
                noiDungQuyMoDauTuDeXuatDieuChinh: getValueQuyMoDauTuDieuChinh()
            }
        ]
    };

    var chuDauTuId = $("#chuDauTuId").val();
    if (!chuDauTuId) {
        data.chuDauTuId = chuDauTuId;
    }

    if (hoSoCongTrinhId != null) {
        data.id = hoSoCongTrinhId;
        data.hoSoCongTrinhChiTietDtos[0].hoSoCongTrinhId = hoSoCongTrinhId;
    }

    if (hoSoCongTrinhChiTietId != null) {
        data.hoSoCongTrinhChiTietDtos[0].id = hoSoCongTrinhChiTietId;
    }

    return data;
}

function GetDataDiaDiemThucHien(e) {
    var ds = e.component.getDataSource();
    var filter = e.component.getCombinedFilter();
    ds.store().load({ sort: ds.sort(), filter: filter ? filter : null })
        .done((allData) => {
            dataDiaDiemThucHien = allData;
        });
}

function GetDataNguonVonDauTu(e) {
    var ds = e.component.getDataSource();
    var filter = e.component.getCombinedFilter();
    ds.store().load({ sort: ds.sort(), filter: filter ? filter : null })
        .done((allData) => {
            dataNguonVonDauTu = allData;
        });
}

function GetDataThanhPhanHoSo(e) {
    var ds = e.component.getDataSource();
    var filter = e.component.getCombinedFilter();
    ds.store().load({ sort: ds.sort(), filter: filter ? filter : null })
        .done((allData) => {
            dataThanhPhanHoSo = allData;
        });
}

function GetDataCoSoPhapLy(e) {
    var ds = e.component.getDataSource();
    var filter = e.component.getCombinedFilter();
    ds.store().load({ sort: ds.sort(), filter: filter ? filter : null })
        .done((allData) => {
            dataCoSoPhapLy = allData;
        });
}

function getValueYKienCuaDonViPhoiHop() {
    var editorInstance = $("#yKienCuaDonViPhoiHop").dxHtmlEditor("instance");
    return editorInstance.option("value")
}

function getValueNoiDungDauTu() {
    var editorInstance = $("#noiDungDauTu").dxHtmlEditor("instance");
    return editorInstance.option("value")
}

function getValueNoiDungThamMuu() {
    var editorInstance = $("#noiDungThamMuu").dxHtmlEditor("instance");
    return editorInstance.option("value")
}

function getValueQuyMoDauTuDieuChinh() {
    var editorInstance = $("#quyMoDauTuDieuChinh").dxHtmlEditor("instance");
    var data = null;

    if (editorInstance) {
        data = editorInstance.option("value");
    }

    return data;
}

function getDataYKienThamDinhBaoCaoChuTruong() {
    var data = null;
    var tenViewLoaiHoSo = $("#tenViewLoaiHoSo").val();

    if (tenViewLoaiHoSo == "ThamDinhDeXuatChuTruongDauTu"
        || tenViewLoaiHoSo == "ThamDinhDieuChinhChuTruongDauTu"
        || tenViewLoaiHoSo == "ThamDinhBaoCaoKinhTeKyThuat"
        || tenViewLoaiHoSo == "ThamDinhDuAnDauTu"
        || tenViewLoaiHoSo == "ThamDinhHoSoMoiThau") {
        data = {
            donViChuTriThamDinh: {
                id: $("#donViChuTriThamDinh").children("option:selected").val() != "" ? $("#donViChuTriThamDinh").children("option:selected").val() : consts.guid_is_null
            },
            donViPhoiHopThamDinhs: GetDonViPhoiHopThamDinhList(),
            hinhThucThamDinh: parseInt($("#hinhThucThamDinh").val()),
            capQuyetDinhChuTruong: {
                id: $("#cqdChuTrươngDauTu").children("option:selected").val() != "" ? $("#cqdChuTrươngDauTu").children("option:selected").val() : consts.guid_is_null
            },
            capQuyetDinhDauTuDuAn: {
                id: $("#cqdDauTu").children("option:selected").val() != "" ? $("#cqdDauTu").children("option:selected").val() : consts.guid_is_null
            },
            yKienThamDinhDonViPhoiHop: getValueYKienCuaDonViPhoiHop(),
            suCanThietDauTuDuAn: $("#suCanThiet").val(),
            suTuanThuQuyDinh: $("#suTuanThu").val(),
            suPhuHopMucTieuChienLuoc: $("#suPhuHopMucTieu").val(),
            suPhuHopMucTieuPhanLoai: $("#suPhuHopTieuChi").val(),
            noiDungDauTu: getValueNoiDungDauTu(),
            yKienCuaDonViThamDinh: $("#yKienDonViThamDinh").val(),
            noiDungTrinhVaKienNghi: getValueNoiDungThamMuu(),
        };
    }
    return data;
}

function getDataYKienThamDinhKeHoachNhaThau() {
    var data = null;
    var tenViewLoaiHoSo = $("#tenViewLoaiHoSo").val();

    if (tenViewLoaiHoSo == "ThamDinhKeHoachLuaChonNhaThau") {
        data = {
            canCuPhapLys: formatDataKetQuaThamDinh(),
            yKienThamDinhCanCuPhapLy: $("#yKienThamDinhPhapLy").val(),
            congViecThucHiens: formatDataCongViecThucHien(),
            congViecKhongApDungs: formatDataCongViecKhongApDung(),
            congViecThuocKeHoachs: formatDataCongViecThuocKeHoach(),
            congViecChuaDuDieuKienLapKeHoachs: formatDataCongViecChuaDuDieuKienLapKeHoach(),
            yKienThamDinhNoiDungKeHoach: $("#yKienThamDinhNoiDungKeHoach").val(),
            yKienThamDinhGiaTriCongViec: $("#yKienThamDinhTongGiaTriCongViec").val(),
            goiThauThamDinhs: formatDataGoiThauThamDinh(),
            noiDungTrinhVaKienNghi: getValueNoiDungThamMuu()
        };
    }
    return data;
}

function getDataYKienThamDinhDieuChinhNhaThau() {
    var data = null;
    var tenViewLoaiHoSo = $("#tenViewLoaiHoSo").val();

    if (tenViewLoaiHoSo == "ThamDinhDieuChinhKeHoachLuaChonNhaThau") {
        data = {
            goiThauDuocPheDuyets: formatDatGoiThauDuocPheDuyet(),
            goiThauDeNghiDieuChinhs: formatDataGoiThauDeNghiDieuChinh(),
            danhGiaCoQuanThamDinh: $("#danhGiaCoQuanThamDinh").val(),
            goiThauDeXuats: formatDataGoiThauDeXuat(),
            noiDungTrinhVaKienNghi: getValueNoiDungThamMuu()
        };
    }
    return data;
}

function FormatDataDiaDiemThucHien() {
    var data = Array(0);
    if (dataDiaDiemThucHien.length > 0) {
        dataDiaDiemThucHien.forEach(function (item) {
            data.push({
                donViHanhChinhId: item.DonViHanhChinhId ? item.DonViHanhChinhId : item.DonViHanhChinhChaId,
                ghiChu: item.GhiChu
            });
        });
    }

    return data;
}

function FormatDataNguonVonDauTu() {
    var data = Array(0);
    if (dataNguonVonDauTu.length > 0) {
        dataNguonVonDauTu.forEach(function (item) {
            data.push({
                nguonVonId: item.NguonVonId,
                giaTriDeNghi: item.GiaTriDeNghi,
                giaTriThamDinh: item.GiaTriThamDinh,
                giaTriNguonVon: item.GiaTriNguonVon
            });
        });
    } 
    return data;
}

function FormatDataThanhPhanHoSo() {
    var data = Array(0);

    getFileIdsTphs();

    if (dataThanhPhanHoSo.length > 0) {
        dataThanhPhanHoSo.forEach(function (item) {
            var fileIds = new Array(0);

            if (item.Files) {
                item.Files.forEach(
                    function (file) {
                        fileIds.push({
                            fileId: file.Id
                        });
                    });
            }
            data.push({
                thanhPhanHoSoId: item.ThanhPhanHoSoId,
                batBuoc: item.BatBuoc,
                soKyHieu: item.SoQuyetDinh,
                ngayBanHanh: item.NgayBanHanhFormat,
                donViBanHanhId: item.DonViBanHanhId,
                trichYeu: item.TrichYeu,
                hoSoCongTrinhChiTietThanhPhanHoSoFileDtos: fileIds
            });
        });
    }
    return data;
}

function FormatDataCoSoPhapLy() {
    var data = Array(0);

    getFileCspl();

    if (dataCoSoPhapLy.length > 0) {
        dataCoSoPhapLy.forEach(function (item) {
            data.push({
                thuVienVanBanId: item.ThuVienVanBanId,
                coSoPhapLyJsonViewModel: item.CoSoPhapLyJsonViewModel,
            });
        });
    }
    return data;
}

function GetDonViPhoiHopThamDinhList() {
    var values = $("#donViPhoiHopThamDinh").dxTagBox("instance").option("selectedItems");
    var donViPhoiHopThamDinhs = new Array(0);

    if (values.length > 0) {
        values.forEach(function (item) {
            donViPhoiHopThamDinhs.push(
                {
                    id: item.Id
                }
            );
        });
    }

    return donViPhoiHopThamDinhs;
}

function GetValueSuCanThietDauTu(e) {
    valueSuCanThietDauTu = e.component["_changedValue"];
}

function GetValueQuyMoDauTu(e) {
    valueQuyMoDauTu = e.component["_changedValue"];
}

function SelectionChanged(selectedItems) {
    selectingThuVienVanBans = selectedItems.selectedRowsData;
}

function deleteFile() {
    deletedFileIds.forEach(function (fileId) {
        xdcb.fileService.documentStores.documentStore.delete(fileId);
    });
}

function GetFileId() {
    var fileIds = new Array(0);

    $(".defaultFiles").each(function () {
        if ($(this).attr("Id_File") !== "") {
            fileIds.push({ fileId: $(this).attr("Id_File") });
        }
    });

    $('.hidden-inputs.hidden .file_ketquathamdinh').each(function () {
        var fd = new FormData();
        var files = $(this)[0].files[0];
        fd.append('file', files);
        $.ajax({
            url: '/api/app/document',
            type: 'post',
            data: fd,
            async: false,
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.id != undefined) {
                    fileIds.push({ fileId: response.id });
                }
            },
        });
    });
    return fileIds;
}

function CheckAction(actionName) {
    var params = GetParamByAction();
    if (params.isTaoMoi) {
        OnSave(actionName, hoSoCongTrinhId = null, hoSoCongTrinhChiTietId = null);
    }
    if (params.isTaoMoiDieuChinh) {
        OnSave(actionName, params.hoSoCongTrinhId, hoSoCongTrinhChiTietId = null)
    }
    if (params.isChinhSua) {
        OnUpdate(actionName, params.hoSoCongTrinhId, params.hoSoCongTrinhChiTietId)
    }
}

function GetParamByAction() {
    var hoSoCongTrinhId = $("#hoSoCongTrinhId").val();
    var soLanDieuChinh = $("#soLanDieuChinh").val();
    var hoSoCongTrinhChiTietId = $("#hoSoCongTrinhChiTietId").val();
    var params = null;
    if (hoSoCongTrinhChiTietId == consts.guid_is_null) {
        if (hoSoCongTrinhId === 'null' && soLanDieuChinh <= 1) {
            params = {
                isTaoMoi: true,
                isTaoMoiDieuChinh: false,
                isChinhSua: false
            };
        } else if (hoSoCongTrinhId != 'null' && soLanDieuChinh > 1) {
            params = {
                hoSoCongTrinhId: hoSoCongTrinhId,
                isTaoMoi: false,
                isTaoMoiDieuChinh: true,
                isChinhSua: false
            };
        }
    }
    else {
        params = {
            hoSoCongTrinhId: hoSoCongTrinhId,
            hoSoCongTrinhChiTietId: hoSoCongTrinhChiTietId,
            isTaoMoi: false,
            isTaoMoiDieuChinh: false,
            isChinhSua: true
        };
    }
    return params;
}

function GetTrangThaiByAction(actionName) {
    switch (actionName) {
        case "SaveCDT":
            return 1
            break;
        case "SaveCV":
            return 2
            break;
        case "SendCDT":
            return 2
            break;
        case "RequestEditCV":
            return 3
            break;
        case "CompleteCV":
            return 4
            break;
    }
}

function checkFile(fileName, settings, current) {
    var accepted = "invalid",
        acceptedFileTypes = current.acceptedFileTypes || settings.acceptedFileTypes,
        regex;

    for (var i = 0; i < acceptedFileTypes.length; i++) {
        regex = new RegExp("\\." + acceptedFileTypes[i] + "$", "i");

        if (regex.test(fileName)) {
            accepted = "valid";
            break;
        } else {
            accepted = "badFileName";
        }
    }
    return accepted;
};