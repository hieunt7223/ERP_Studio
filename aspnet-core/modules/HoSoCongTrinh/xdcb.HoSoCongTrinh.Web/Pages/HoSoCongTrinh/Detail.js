$(document).ready(function () {
    $(".content-wrapper").addClass("content-wrapper-detail");
    $(".isOpened").addClass("show");
});

var dataThanhPhanHoSo = new Array(0);

function ChiTietHoSo(btn) {
    var id = $(btn).attr("_id");
    var data = dataThanhPhanHoSo.filter(x => x.Id == id);
    var loaiVanBanId = data[0].LoaiVanBanId;

    $.ajax({
        url: '/api/app/loaiVanBan/{' + loaiVanBanId + '}',
        type: 'get',
        contentType: "application/json; charset=utf-8",
        async: false
    }).done(function (data_result) {
        $('#TenVanBan').text(data_result.tenLoaiVanBan);
    });

    if (data[0].ThongTinThanhPhanHoSo) {
        $('#TenThanhPhan').text(data[0].ThongTinThanhPhanHoSo);
    } 

    if (data[0].SoQuyetDinh) {
        $('#soQuyetDinh').text(data[0].SoQuyetDinh);
    } 

    if (data[0].NgayBanHanhFormat) {
        $('#ngayBanHanh').text(data[0].SoQuyetDinh);
    } 

    if (data[0].TenDonViBanHanh) {
        $('#donViBanHanh').text(data[0].TenDonViBanHanh);
    } 

    if (data[0].TrichYeu) {
        $('#trichYeu').text(data[0].TrichYeu);
    } 

    var fileString = $(btn).attr("_files");
    var htmlFile = "";

    if (fileString) {
        var files = new Array(0);
        files = fileString.split('/');
        files.forEach(function (file) {
            var tenFile = file.split(',')[0];
            var kieu = tenFile.substr(tenFile.indexOf('.'));
            var fileId = file.split(',')[1];
            htmlFile += formatHtmlFile(kieu, fileId, tenFile);
        });
        $('#FileHoSo').html(htmlFile);
    }
}

function ChiTietCoSoPhapLy(btn) {
    var thuvievanbanId = $(btn).attr("_thuvienvanbanid");
    var idName = $(btn).attr("id");
    var htmlFile = "";

    if (idName == 'view') {
        $(".csplTitle").html(consts.csplTitleView);
    } else {
        $(".csplTitle").text(consts.csplTitleCreateUpdate);
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
       
        for (var i = 0; i < arraFile.length; i++){
            $.ajax({
                url: '/api/app/documentStore/{' + arraFile[i] + '}',
                type: 'get',
                contentType: "application/json; charset=utf-8",
                async: false
            }).done(function (data_result) {
                var tenFile = data_result.tenFile;
                var kieu = tenFile.substr(tenFile.indexOf('.'));
                var fileId = data_result.id;

                htmlFile += formatHtmlFile(kieu, fileId, tenFile);
            });
        }
        
    });

    $('#FileCoSo').html(htmlFile);
}

function HideButtons(e) {
    var toolbarItems = e.toolbarOptions.items;
    $.each(toolbarItems, function (_, item) {
        if (item.name == "saveButton" || item.name == "revertButton") {
            item.visible = false;
        }
    });
}

function OnContentReadyThanhPhanHoSoView(e) {
    var ds = e.component.getDataSource();
    var filter = e.component.getCombinedFilter();
    ds.store().load({ sort: ds.sort(), filter: filter ? filter : null })
        .done((allData) => {
            dataThanhPhanHoSo = allData;
        });
}

function getGoiThauThamDinhs() {
    return {
        store: new DevExpress.data.CustomStore({
            loadMode: "raw",
            load: function () {
                return $.getJSON("/api/app/goiThau/goiThaus");
            }
        })
    };
}