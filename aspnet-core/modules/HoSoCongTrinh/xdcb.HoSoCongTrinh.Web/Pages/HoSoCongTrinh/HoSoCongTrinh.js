function getFileListString(data) {
    var file = ""
    if (data) {
        for (var i = 0; i < data.length; i++) {
            file += data[i].TenFile + ',';
            if (typeof data[i].Id != "undefined") {
                file += data[i].Id;
            } else {
                file += " ";
            }
            file += '/';
        }
        if (data.length > 0) {
            file += '/';
            file = file.replace('//', '');
        }
    }
    return file;
}

function FormatItems(items) {
    var output = "";
    if (items != null && items.length > 0) {
        for (var i = 0; i < items.length; i++) {
            var tenFile = typeof items[i].TenFile != "undefined" ? items[i].TenFile : items[i].tenFile;
            var kieu = tenFile.substr(tenFile.indexOf('.'));
            var fileId = null;

            if (typeof items[i].Id != "undefined") {
                fileId = items[i].Id;
            }
            if (typeof items[i].fileId != "undefined") {
                fileId = items[i].fileId;
            }

            output += formatHtmlFile(kieu, fileId, tenFile);
        }
    }
    else {
        output += "<div></div>";
    }

    return output;
}

function formatFilesCoSoPhapLy(data) {
    var output = "";
    var thuVienVanBanId = data.ThuVienVanBanId;
    var files = new Array(0);

    if (thuVienVanBanId) {
        files = data.Files;
    } else {
        files = data.CoSoPhapLyJsonViewModel.Files;
    }

    if (files && files.length > 0) {
        for (var i = 0; i < files.length; i++) {
            var tenFile = typeof files[i].TenFile != "undefined" ? files[i].TenFile : files[i].tenFile
            var kieu = tenFile.substr(tenFile.indexOf('.'));
            var fileId = null;

            if (typeof files[i].Id != "undefined") {
                fileId = files[i].Id;
            }
            if (typeof files[i].fileId != "undefined") {
                fileId = files[i].fileId;
            }

            output += formatHtmlFile(kieu, fileId, tenFile);
        }
    }
    else {
        output += "<div></div>";
    }

    return output;
}

function formatHtmlFile(kieu, fileId, tenFile) {
    var output = "<div>";
    kieu = kieu.toLowerCase();
    if (fileId && fileId != "null") {
        output += "<a href='/api/app/documentStore/download/" + fileId + "'" + "download='" + tenFile + "'" + ">";
    }

    if (kieu == ".pdf") {
        output += "<img src='/img/pdf.svg' class='attached-icon'>";
    }
    else if (kieu == ".doc" || kieu == ".docx") {
        output += "<img src='/img/word.svg' class='attached-icon'>";
    }
    else {
        output += "<img src='/img/image.svg' class='attached-icon'>";
    }
    output += "<span>" + tenFile + "</span>";

    if (fileId && fileId != "null") {
        output += "</a>";
    }
    output += "</div>";

    return output;
}

function orderRowItemNo(cellElement, cellInfo) {
    var index = cellInfo.row.rowIndex + 1;
    cellElement.text(index)
}

function renderTenThanhPhanHoSoTemplate(container, item) {
    var data = item.data
    var markup = "";
    var trichYeu = data.TrichYeu ? data.TrichYeu : "";

    if (data.BatBuoc) {
        markup = markup + "<span>" + data.ThongTinThanhPhanHoSo + "</span>" + "<span><i><small>" + trichYeu + "</small></i><span class='text-danger'> *</span></span>";
    } else {
        markup = markup + "<span>" + data.ThongTinThanhPhanHoSo + "</span>" + "<span><i><small> " + trichYeu + "</small></i></span>";
    }
    container.append(markup);
}

function checkTemplateByLoaiHoSo(tenviewloaihoso) {
    if (tenviewloaihoso == "ThamDinhDeXuatChuTruongDauTu") {
        if (!$('#baoCaoDieuChinhTemplate').hasClass('d-none')) {
            $('#baoCaoDieuChinhTemplate').addClass('d-none');
        }
        if (!$('#noDataTemplate').hasClass('d-none')) {
            $('#noDataTemplate').addClass('d-none');
        }
        $('#baoCaoDeXuatTemplate').removeClass('d-none');
    } else if (tenviewloaihoso == "ThamDinhDieuChinhChuTruongDauTu") {
        if (!$('#baoCaoDeXuatTemplate').hasClass('d-none')) {
            $('#baoCaoDeXuatTemplate').addClass('d-none');
        }
        $('#noDataTemplate').removeClass('d-none');
    } else {
        if (!$('#baoCaoDeXuatTemplate').hasClass('d-none')) {
            $('#baoCaoDeXuatTemplate').addClass('d-none');
        }
        if (!$('#baoCaoDieuChinhTemplate').hasClass('d-none')) {
            $('#baoCaoDieuChinhTemplate').addClass('d-none');
        }
        $('#noDataTemplate').removeClass('d-none');
    }
}

$(".xuatfile-btn").on('click', function () {
    var hosocongtrinhchitietid = $(this).attr("hosocongtrinhchitietid");
    var hosocongtrinhid = $(this).attr("hosocongtrinhid");
    var tenviewloaihoso = $(this).attr("tenviewloaihoso");

    reportLoaiHoSo(hosocongtrinhid, hosocongtrinhchitietid, tenviewloaihoso);
});

$('#report').on('click', function () {
    var baoCaoDeXuat = $('#BaoCaoDeXuat').is(":checked");
    var hosocongtrinhid = $(this).attr("hosocongtrinhid");
    var hosocongtrinhchitietid = $(this).attr("hosocongtrinhchitietid");
    var tenviewloaihoso = $(this).attr("tenviewloaihoso");
    var url = consts.report + "/thamdinh?data=";

    if (!baoCaoDeXuat) {
        abp.notify.info(messages.NotFileCheck);
        return false;
    }

    $.ajax({
        url: '/api/app/hoSoCongTrinhChiTiet/' + hosocongtrinhid + '/report/' + hosocongtrinhchitietid,
        type: 'get',
        contentType: "application/json; charset=utf-8",
        async: false
    }).done(function (data_result) {
        url += data_result + "&&view=" + tenviewloaihoso;
        window.location.href = url;
        return true;
    }).fail(function () {
        return false;
    });
});

function downloadFromAjaxPost(url, params, headers, callback) {
    var xhr = new XMLHttpRequest();
    xhr.open('POST', url, true);
    xhr.responseType = 'arraybuffer';
    xhr.onload = function () {
        if (this.status === 200) {
            var filename = params.view +".docx";
            var type = xhr.getResponseHeader('Content-Type');

            var blob = new Blob([this.response], { type: type });
            if (typeof window.navigator.msSaveBlob !== 'undefined') {
                // IE workaround for "HTML7007: One or more blob URLs were revoked by closing the blob for which they were created. These URLs will no longer resolve as the data backing the URL has been freed."
                window.navigator.msSaveBlob(blob, filename);
            } else {
                var URL = window.URL || window.webkitURL;
                var downloadUrl = URL.createObjectURL(blob);

                if (filename) {
                    // use HTML5 a[download] attribute to specify filename
                    var a = document.createElement("a");
                    // safari doesn't support this yet
                    if (typeof a.download === 'undefined') {
                        window.location = downloadUrl;
                    } else {
                        a.href = downloadUrl;
                        a.download = filename;
                        document.body.appendChild(a);
                        a.click();
                    }
                } else {
                    window.location = downloadUrl;
                }

                setTimeout(function () { URL.revokeObjectURL(downloadUrl); }, 100); // cleanup
            }
        }
        if (callback) {
            callback();
        }
    };
    xhr.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
    $.each(headers, function (key, value) {
        xhr.setRequestHeader(key, value);
    });

    xhr.send($.param(params));
}

function reportLoaiHoSo(hosocongtrinhid, hosocongtrinhchitietid, tenviewloaihoso) {
    var url = consts.report + '/thamdinh';
    var urldataReport = '/api/app/hoSoCongTrinhChiTiet/' + hosocongtrinhid;
    switch (tenviewloaihoso) {
        case "ThamDinhDeXuatChuTruongDauTu":
            urldataReport = urldataReport + '/dataDeXuat/' + hosocongtrinhchitietid;
            break;
        case "ThamDinhDieuChinhChuTruongDauTu":
            urldataReport = urldataReport + '/dataDeXuatDieuChinh/' + hosocongtrinhchitietid;
            break;
        case "ThamDinhKeHoachLuaChonNhaThau":
            urldataReport = urldataReport + '/dataReport/' + hosocongtrinhchitietid;
            break;
        case "ThamDinhDieuChinhKeHoachLuaChonNhaThau":
            urldataReport = urldataReport + '/dataDieuChinhReport/' + hosocongtrinhchitietid;
            break;
        case "ThamDinhBaoCaoKinhTeKyThuat":
            urldataReport = urldataReport + '/dataDeXuat/' + hosocongtrinhchitietid;
            break;
        case "ThamDinhDuAnDauTu":
            urldataReport = urldataReport + '/dataDeXuat/' + hosocongtrinhchitietid;
            break;
        case "ThamDinhHoSoMoiThau":
            urldataReport = urldataReport + '/dataDeXuat/' + hosocongtrinhchitietid;
            break;
    }

    $.ajax({
        url: urldataReport,
        type: 'get',
        contentType: "application/json; charset=utf-8",
        async: false
    }).done(function (data_result) {

        event.preventDefault();
        var target = $(event.target);
        var params = {
            data: data_result,
            view: tenviewloaihoso
        };

        downloadFromAjaxPost(url, params, null);
       
    }).fail(function () {
        return false;
    });
}

