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

var selectedThuVienVanBans = new Array(0);
var selectingThuVienVanBans = new Array(0);
var dataCoSoPhapLy = new Array(0);
var dataThanhPhanHoSo = new Array(0);
var acceptedFileTypes = ['pdf', 'jpg', 'jpeg', 'png', 'doc', 'docx']

function ReplaceTextNoData() {
    $(".dx-datagrid-nodata").text(messages.no_data);
}

function onEditorPreparingTongMucDauTu(e) {
    if (e.dataField === "ChiPhiId" && e.parentType === "dataRow") {
        e.editorOptions.placeholder = consts.textPlaceholder.selectBox;
    }
}

function onEditorPreparingThanhPhanHoSo(e) {
    if (e.dataField === "ThanhPhanHoSoId" && e.parentType === "dataRow") {
        e.editorOptions.placeholder = consts.textPlaceholder.selectBox;
    }
}

$("#onSaveLoaiHoSo").click(function (e) {
    e.preventDefault();

    if (!$("#form_loaihoso").valid()) {
        return;
    }
    var data = getDataInsert();
    var urlRequest = '/api/app/loaiHoSo/';
    var type = "post";
    var loaiHoSoId = $("#loaiHoSoId").val();
    if (loaiHoSoId) {
        urlRequest = urlRequest + loaiHoSoId;
        type = "put";
    }
    abp.ajax({
        url: urlRequest,
        type: type,
        data: JSON.stringify(data)
    }).done(function () {
        window.location.replace("/LoaiHoSo");
    });
});

function getDataInsert() {
    var dataInsert = {
        tenLoaiHoSo: $("#LoaiHoSo_TenLoaiHoSo").val(),
        isDieuChinh: false,
        isTrangThai: false,
        thoiGianXuLyQuyDinhNhomA: $("#thoi_gian_nhom_a").val(),
        thoiGianXuLyQuyDinhNhomB: $("#thoi_gian_nhom_b").val(),
        thoiGianXuLyQuyDinhNhomC: $("#thoi_gian_nhom_c").val(),
        thanhPhanHoSos: getDataTableThanhPhanHoSo(),
        coSoPhapLys: getDataTableCoSoPhapLys()
    }
    if ($("#LoaiHoSo_IsDieuChinh").is(":checked")) {
        dataInsert.isDieuChinh = true;
    }
    if ($("#LoaiHoSo_IsTrangThai").is(":checked")) {
        dataInsert.isTrangThai = true;
    }
    return dataInsert;
}

function getDataTableThanhPhanHoSo() {
    var thanhPhanHoSos = $("#thanhphanhoso-table").dxDataGrid('instance')._controllers.data._dataSource._items;
    var data = [];
    if (thanhPhanHoSos.length > 0) {
        thanhPhanHoSos.forEach(function (item) {
            if (item.IsBatBuoc) {
                data.push({
                    thanhPhanHoSoId: item.Id,
                    batBuoc: item.IsBatBuoc
                });
            } else {
                data.push({
                    thanhPhanHoSoId: item.Id,
                    batBuoc: false
                });
            }
        });
    }

    return data;
}

function getDataTableCoSoPhapLys() {
    var coSoPhapLys = $("#cosophaply-table").dxDataGrid('instance')._controllers.data._dataSource._items;
    var data = [];
    if (coSoPhapLys.length > 0) {
        coSoPhapLys.forEach(function (item) {
            data.push({
                thuVienVanBanId: item.Id
            });
        });
    }

    return data;
}

function GetDataCoSoPhapLy(e) {
    ReplaceTextNoData();
    var ds = e.component.getDataSource();
    var filter = e.component.getCombinedFilter();
    ds.store().load({ sort: ds.sort(), filter: filter ? filter : null })
        .done((allData) => {
            if (selectedThuVienVanBans.length < 1) {
                selectedThuVienVanBans = allData;
            }
            dataCoSoPhapLy = allData;
        });
}

function FormatDataThanhPhanHoSo() {
    var data = Array(0);

    if (dataThanhPhanHoSo.length > 0) {
        dataThanhPhanHoSo.forEach(function (item) {
            data.push({
                thanhPhanHoSoId: item.ThanhPhanHoSoId,
                batBuoc: item.BatBuoc,
                hoSoCongTrinhChiTietThanhPhanHoSoFileDtos: []
            });
        });
    }
    return data;
}
function FormatDataCoSoPhapLy() {
    var data = Array(0);

    if (dataCoSoPhapLy.length > 0) {
        dataCoSoPhapLy.forEach(function (item) {
            data.push({
                thuVienVanBanId: item.ThuVienVanBanId,
                noiDungJson: item.NoiDung
            });
        });
    }
    return data;
}

function SelectionChanged(selectedItems) {
    selectingThuVienVanBans = selectedItems.selectedRowsData;
}

function SelectThuVienVanBan() {
    var dataGrid = $('#cosophaply-table').dxDataGrid('instance');
    selectedThuVienVanBans = dataGrid.getDataSource()._store._array.concat(renameKeyObject(selectingThuVienVanBans));
}

function renameKeyObject(data) {
    data.forEach(function (obj) {
        Object.keys(obj).forEach(function (key) {
            var new_key = capitalizeFirstLetter(key);

            Object.defineProperty(
                obj,
                new_key,
                Object.getOwnPropertyDescriptor(obj, key)
            );
            delete obj[key];
        });
    });
    return data;
}

function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}


function OpenModal() {
    abp.ajax({
        url: '/api/app/thuVienVanBan',
        type: 'get'
    }).done(function (data) {
        GetDataGridMultiple(data.items);
    });
}

function InsertDataRow() {
    SelectThuVienVanBan();
    clearSelection();
    $('#myModal').modal('hide');
    GetDataGrid(selectedThuVienVanBans);
}

// thanh phan ho so
var listSelectedThanhPhanHoSos = [];
var listThanhPhanHoSos = null;
//var listloaiVanBan = null;
function addRowThanhPhanHoSo() {
    var dataGrid = $('#thanhphanhoso-table').dxDataGrid('instance');
    listSelectedThanhPhanHoSos = dataGrid.getDataSource()._store._array;
    dataGrid.addRow();
}

function onEditorPreparingThanhPhanHoSo(e) {
    if (e.dataField === "Id" && e.parentType === "dataRow") {
        e.editorOptions.placeholder = consts.textPlaceholder.selectBox;
        if (listThanhPhanHoSos == null) {
            listThanhPhanHoSos = e.lookup.items
        }
    }
}

function setLoaiVanBanValue(rowData, value) {
    rowData.Id = value;
    rowData.LoaiVanBan = listThanhPhanHoSos.find(s => s.Id === value).LoaiVanBan;
}

var rowThanhPhanHoSoValidating = function (e) {
    var thanhPhanHoSoId = e.newData.Id;
    var object = listSelectedThanhPhanHoSos.find(s => s.Id == thanhPhanHoSoId);
    if (object) {
        e.errorText = "Không được chọn trùng tên thành phần hồ sơ";
        e.isValid = false;
    }
}
// end thanh phan ho so

function GetDataGridMultiple(data) {
    data = data.filter(ar => !dataCoSoPhapLy.find(rm => (rm.Id === ar.id)));
    $("#dataGirdMultiple").dxDataGrid({
        noDataText: messages.no_data,
        dataSource: data,
        showBorders: true,
        selection: {
            mode: "multiple"
        },
        paging: {
            pageSize: 10
        },
        filterRow: {
            visible: false
        },
        onSelectionChanged: SelectionChanged,
        columns: [
            {
                dataField: "soKyHieu",
                caption: "Số ký hiệu"
            },
            {
                dataField: "trichYeu",
                caption: "Trích yếu"
            },
            {
                dataField: "ngayBanHanhFormat",
                caption: "Ngày ban hành"
            },
            {
                dataField: "tenLoaiVanBan",
                caption: "Loại văn bản"
            },
            {
                dataField: "donViBanHanh",
                caption: "Đơn vị ban hành"
            },
            {
                dataField: "id",
                caption: "",
                width: 60,
                cellTemplate: function (container, options) {
                    var id = options.data.id;
                    if (id) {
                        var markup =
                            "<div class='text-center'>" +
                            "<button class='btn-action btn-detail' onclick='ChiTietCoSoPhapLy(this)' _thuvienvanbanid='" + id + "' data-toggle='modal' data-target='.CoSoPhapLyDetail' type='button'>" +
                            "<i class='fa fa-eye'></i>" +
                            "</button >"
                        "</div>";
                        container.append(markup);
                    }
                }
            }
        ]
    });
}

function GetDataGrid(data) {
    $("#cosophaply-table").dxDataGrid({
        noDataText: messages.no_data,
        dataSource: data,
        showBorders: true,
        paging: {
            enabled: false
        },
        editing: {
            mode: "row",
            allowAdding: false,
            allowUpdating: false,
            allowDeleting: true,
            useIcons: true,
            confirmDelete: false
        },
        columns: [
            {
                dataField: "Id",
                visible: false
            },
            {
                dataField: "Stt",
                caption: "#",
                width: 60,
                visible: false,
            },
            {
                dataField: "SoKyHieu",
                caption: "Số/Ký hiệu",
                width: "20%"
            },
            {
                dataField: "TrichYeu",
                caption: "Trích yếu",
                width: "40%"
            },
            {
                dataField: "NgayBanHanhFormat",
                caption: "Ngày ban hành",
                width: "15%"
            },
            {
                dataField: "TenLoaiVanBan",
                caption: "Loại văn bản",
                width: "25%"
            }
        ]
    });
}

function clearSelection() {
    $("#dataGirdMultiple").dxDataGrid("instance").clearSelection();
}

function formatDataCSPL() {
    var list = Array(0);
    selectedThuVienVanBans.forEach(function (item) {
        var trichYeu = item.trichYeu;
        if (!item.trichYeu) {
            trichYeu = "";
        }
        list.push({
            Id: item.id,
            SoKyHieu: item.soKyHieu,
            TrichYeu: trichYeu,
            NgayBanHanh: item.ngayBanHanhFormat,
            LoaiVanBan: item.loaiVanBan
        });
    });
    return list;
}

$('#Search_ThuVienVanBan').click(function () {
    Search();
});

function Search() {
    var input = {
        keyword: $("#keyword").val(),
        LoaiVanBan: $("#LoaiVanBan").val(),
        DonViBanHanh: $("#DonViBanHanh").val(),
        SkipCount: 0,
        MaxResultCount: 1000
    }
    abp.ajax({
        url: '/api/app/thuVienVanBan/search',
        type: 'get',
        contentType: "application/json",
        data: { "conditionSearch": JSON.stringify(input) },
    }).done(function (data_result) {
        clearSelection();
        GetDataGridMultiple(data_result.items);
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

function ChiTietCoSoPhapLy(btn) {
    var thuvievanbanId = $(btn).attr("_thuvienvanbanid");
    var idName = $(btn).attr("id");
    var htmlFile = "";

    if (idName == 'view') {
        $("#csplTitle").html(consts.csplTitleView);
    } else {
        $("#csplTitle").html(consts.csplTitleCreateUpdate);
    }

    $.ajax({
        url: '/api/app/thuVienVanBan/{' + thuvievanbanId + '}',
        type: 'get',
        contentType: "application/json; charset=utf-8",
        async: false
    }).done(function (data_result) {
        $('#SoKyHieu').html(data_result.soKyHieu);
        $('#NgayBanHanh').html(formatdate(data_result.ngayBanHanh));
        $('#DonViBanHanh').html(data_result.donViBanHanh);
        var capBanHanh = data_result.capBanHanh;
        if (capBanHanh == 1) {
            $('#CapBanHanh').html("Trung ương");
        } else {
            $('#CapBanHanh').html("Địa phương");
        }
        var loaiVanBanId = data_result.loaiVanBanId;

        $.ajax({
            url: '/api/app/loaiVanBan/{' + loaiVanBanId + '}',
            type: 'get',
            contentType: "application/json; charset=utf-8",
            async: false
        }).done(function (data_result) {
            $('#LoaiVanBan').html(data_result.tenLoaiVanBan);
        });
        var linhVucVanBanId = data_result.linhVucVanBanId;
        if (linhVucVanBanId) {
            $.ajax({
                url: '/api/app/linhVucVanBan/{' + linhVucVanBanId + '}',
                type: 'get',
                contentType: "application/json; charset=utf-8",
                async: false
            }).done(function (data_result) {
                $('#LinhVucVanBan').html(data_result.tenLinhVuc);
            });
        }

        $('#TrichYeu').html(data_result.trichYeu);

    }).fail(function () {

    });

    $.ajax({
        url: '/api/app/fileCuaThuVienVanBan/fileIdList/{' + thuvievanbanId + '}',
        type: 'get',
        contentType: "application/json; charset=utf-8",
        async: false
    }).done(function (data_result) {
        var arraFile = data_result;

        for (var i = 0; i < arraFile.length; i++) {
            $.ajax({
                url: '/api/app/documentStore/{' + arraFile[i] + '}',
                type: 'get',
                contentType: "application/json; charset=utf-8",
                async: false
            }).done(function (data_result) {
                var fileName = data_result.tenFile;
                var array_name = fileName.split('.');
                var kieu = array_name[array_name.length - 1].toLowerCase();
                var imgFile;
                switch (kieu) {
                    case "pdf": {
                        imgFile = "<img src='/img/pdf.svg' class='attached-icon'>";
                        break;
                    }
                    case "doc":
                    case "docx":
                        {
                            imgFile = "<img src='/img/word.svg' class='attached-icon'>";
                            break;
                        }
                    default: {
                        imgFile = "<img src='/img/image.svg' class='attached-icon'>";
                    }
                }
                htmlFile += "<p>" + imgFile + "  <span>" + fileName + "<span><p>"
            });
        }

    });

    $('#FileCoSo').html(htmlFile);
}