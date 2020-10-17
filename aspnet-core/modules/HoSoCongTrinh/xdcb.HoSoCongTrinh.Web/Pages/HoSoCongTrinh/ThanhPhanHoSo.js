var uploadId = 1;
var gridId = 1;
var soQuyetDinhList = new Array(0);

function insertThanhPhanHoSo(btn) {
    var idIndex = $(btn).attr("_id");
    var data = new Array(0);
    var textValidSoQuyetDinh = $(".soQuyetDinh-valid-exist").text();

    if ($("#thanhPhanHoSoForm").valid() && textValidSoQuyetDinh == "") {
        if (idIndex != 0) {
            for (var i = 0; i < dataThanhPhanHoSo.length; i++) {
                if (dataThanhPhanHoSo[i].ThanhPhanHoSoId == idIndex) {
                    dataThanhPhanHoSo[i] = getThanhPhanHoSoInserting();
                    break;
                }
            }
            data = dataThanhPhanHoSo;
        } else {
            data = dataThanhPhanHoSo.concat(getThanhPhanHoSoInserting());
        }
        getDataGridThanhPhanHoSo(data);
        $('#modalNewThanhPhanHoSo').modal('hide');
    }
}

$("#soQuyetDinh").blur(function () {
    var soQuyetDinh = $(this).val();
    if (soQuyetDinhList.find(x => x == $.trim(soQuyetDinh))) {
        $(".soQuyetDinh-valid-exist").text("Dữ liệu đã tồn tại");
        $(".soQuyetDinh-valid-exist").removeClass("d-none");
    } else {
        $(".soQuyetDinh-valid-exist").text("");
        $(".soQuyetDinh-valid-exist").addClass("d-none");
    }
});

function setSoQuyetDinhList(soQuyetDinh) {
    var data = new Array(0);

    if (dataThanhPhanHoSo.length > 0) {
        dataThanhPhanHoSo.forEach(function (item) {
            if (item.SoQuyetDinh) {
                data.push(item.SoQuyetDinh);
            }
        });
    }

    if (typeof soQuyetDinh != "undefined") {
        data = data.filter(x => x != soQuyetDinh);
    }

    soQuyetDinhList = data;
}

function renderSoQuyetDinhTemplate(container, item) {
    var data = item.data
    var markup = "";

    if (data.BatBuoc) {
        if (data.SoQuyetDinh) {
            markup = markup + data.SoQuyetDinh;
        } else {
            markup = markup + "<span class='valid-tphs-macdinh d-none'></span>"
        }
    } else {
        if (data.SoQuyetDinh) {
            markup = markup + data.SoQuyetDinh;
        }
    }
    container.append(markup);
}

function renderNgaybanHanhTemplate(container, item) {
    var data = item.data
    var markup = "";

    if (data.BatBuoc) {
        if (data.NgayBanHanhFormat) {
            markup = markup + data.NgayBanHanhFormat;
        } else {
            markup = markup + "<span class='valid-tphs-macdinh d-none'></span>"
        }
    } else {
        if (data.NgayBanHanhFormat) {
            markup = markup + data.NgayBanHanhFormat;
        }
    }
    container.append(markup);
}

function renderDonViBanHanhTemplate(container, item) {
    var data = item.data
    var markup = "";

    if (data.BatBuoc) {
        if (data.DonViBanHanhId) {
            markup = markup + data.TenDonViBanHanh;
        } else {
            markup = markup + "<span class='valid-tphs-macdinh d-none'></span>"
        }
    } else {
        if (data.DonViBanHanhId) {
            markup = markup + data.TenDonViBanHanh;
        }
    }
    container.append(markup);
}

function renderFileTemplate(container, item) {
    var data = item.data
    var files = data.Files;
    var markup = "";

    if (data.BatBuoc) {
        if (files != null && files.length > 0) {
            for (var i = 0; i < files.length; i++) {
                var tenFile = typeof files[i].TenFile != "undefined" ? files[i].TenFile : files[i].tenFile;
                var kieu = tenFile.substr(tenFile.indexOf('.'));
                var fileId = null;

                if (typeof files[i].Id != "undefined") {
                    fileId = files[i].Id;
                }
                if (typeof files[i].fileId != "undefined") {
                    fileId = files[i].fileId;
                }

                markup += formatHtmlFile(kieu, fileId, tenFile);
            }
        } else {
            markup = markup + "<span class='valid-tphs-macdinh d-none'></span>"
        }
    } else {
        markup = FormatItems(files);
    }
    container.append(markup);
}

function getThanhPhanHoSoInserting() {
    var files = Array(0);
    var loaiVanBanId,
        thanhPhanHoSoId,
        tenThanhPhanHoSo,
        soQuyetDinh,
        ngayBanHanh,
        donViBanHanhId,
        tenDonViBanHanh,
        trichYeu = null;

    if (soQuyetDinh) {
        soQuyetDinhList.push(soQuyetDinh);
    }

    $('.hidden-inputs-tphs.hidden .file-tphs ').each(function () {
        files.push({
            Id: $(this).attr("_fileId") != "" ? $(this).attr("_fileId") : null,
            TenFile: $(this).attr("_fileName"),
            Files: $(this)[0].files[0]
        });
    });

    loaiVanBanId = $("#selectLoaiVanBan").children("option:selected").val();
    thanhPhanHoSoId = $("#thanhPhanHoSo").children("option:selected").val();
    tenThanhPhanHoSo = $("#thanhPhanHoSo").children("option:selected").text();
    soQuyetDinh = $("#soQuyetDinh").val();
    ngayBanHanh = $("#ngayBanHanhTphs").val();
    donViBanHanhId = $("#donViBanHanhTphs").val();
    tenDonViBanHanh = $("#donViBanHanhTphs").children("option:selected").text();
    trichYeu = $("#trichYeuTphs").val();
    isBatBuoc = $("#batBuocTphs").val() == "false" ? false : true;

    return {
        LoaiVanBanId: loaiVanBanId,
        ThanhPhanHoSoId: thanhPhanHoSoId,
        ThongTinThanhPhanHoSo: tenThanhPhanHoSo,
        SoQuyetDinh: soQuyetDinh,
        NgayBanHanhFormat: ngayBanHanh,
        DonViBanHanhId: donViBanHanhId,
        TenDonViBanHanh: tenDonViBanHanh,
        TrichYeu: trichYeu,
        Files: files,
        BatBuoc: isBatBuoc
    };
}

function getDataGridThanhPhanHoSo(data) {
    $("#thanhphanhoso-table").dxDataGrid({
        noDataText: messages.no_data,
        dataSource: data,
        showBorders: true,
        paging: {
            enabled: false
        },
        wordWrapEnabled: true,
        columns: [
            {
                dataField: "Stt",
                caption: "#",
                width: 60,
                alignment: "left",
                allowEditing: false,
                cellTemplate: orderRowItemNo
            },
            {
                dataField: "ThanhPhanHoSoId",
                visible: false
            },
            {
                dataField: "LoaiVanBanId",
                visible: false
            },
            {
                caption: "Tên thành phần hồ sơ",
                width: 350,
                cellTemplate: renderTenThanhPhanHoSoTemplate
            },
            {
                dataField: "SoQuyetDinh",
                caption: "Số quyết định",
                width: 120,
                cellTemplate: renderSoQuyetDinhTemplate
            },
            {
                dataField: "NgayBanHanhFormat",
                caption: "Ngày ban hành",
                width: 120,
                cellTemplate: renderNgaybanHanhTemplate
            },
            {
                dataField: "TenDonViBanHanh",
                caption: "Đơn vị ban hành",
                cellTemplate: renderDonViBanHanhTemplate
            },
            {
                dataField: "Files",
                caption: "File đính kèm",
                cellTemplate: renderFileTemplate
            },
            {
                width: 100,
                cellTemplate: function (container, item) {
                    var data = item.data,
                        markup = "";
                    if (data.BatBuoc) {
                        markup = markup + "<div class='text-center'>" +
                            "<button class='btn-action btn-edit tphs-edit' _id='" + data.ThanhPhanHoSoId + "'" + "_files='" + getFileListString(data.Files) + "'" + "onclick='editThanhPhanHoSoDefault(this)'" + "data-toggle='modal' data-target='#modalNewThanhPhanHoSo'>" +
                            "<i class='fa fa-pencil-square-o'></i>" +
                            "</button >" +
                            "</div>";
                    } else {
                        markup = markup + "<div class='text-center'>" +
                            "<button class='btn-action btn-edit tphs-edit' _id='" + data.ThanhPhanHoSoId + "'" + "_files='" + getFileListString(data.Files) + "'" + "onclick='editThanhPhanHoSo(this)'" + "data-toggle='modal' data-target='#modalNewThanhPhanHoSo'>" +
                            "<i class='fa fa-pencil-square-o'></i>" +
                            "</button >" +
                            "<button class='btn-action btn-delete' _id='" + data.ThanhPhanHoSoId + "'" + "_files='" + getFileListString(data.Files) + "'" + "onclick='deleteThanhPhanHoSoOnRow(this)'" + ">" +
                            "<i class='fa fa-trash-o'></i>" +
                            "</button>" +
                            "</div>";
                    }

                    container.append(markup);
                }
            }
        ],
        onContentReady: GetDataThanhPhanHoSo
    });
}

function deleteThanhPhanHoSoOnRow(btn) {
    var id = $(btn).attr("_id");
    var fileIdString = $(btn).attr("_files");
    console.log(dataThanhPhanHoSo);
    if (fileIdString) {
        var files = new Array(0);
        files = fileIdString.split('/');
        files.forEach(function (file) {
            deletedFileIds.push(file.split(',')[1]);
        });
    }
    dataThanhPhanHoSo = dataThanhPhanHoSo.filter(x => x.ThanhPhanHoSoId != id);

    getDataGridThanhPhanHoSo(dataThanhPhanHoSo);
}

function editThanhPhanHoSoDefault(btn) {
    editThanhPhanHoSo(btn);
    $("#selectLoaiVanBan").prop('disabled', true);
    $("#thanhPhanHoSo").prop('disabled', true);
}

function editThanhPhanHoSo(btn) {
    var dataDefault = dataThanhPhanHoSo.filter(x => x.ThanhPhanHoSoId == $(btn).attr("_id"));

    setvalueDefaultThanhPhanHoSoPopup(dataDefault);

    var loaiVanBanId = $("#selectLoaiVanBan").children("option:selected").val();
    var fileString = $(btn).attr("_files");
    var selectedThanhPhanHoSoIds = new Array(0);
    var files = new Array(0);

    thanhPhanHoSoId = dataDefault[0].ThanhPhanHoSoId;

    if (fileString != "") {
        var file = fileString.split('/');
        file.forEach(function (item) {
            files.push({
                file: item.split(',')[0],
                fileId: item.split(',')[1]
            });
        });
    }

    if (dataThanhPhanHoSo.length > 0) {
        selectedThanhPhanHoSoIds = dataThanhPhanHoSo.map(a => a.ThanhPhanHoSoId);
    }

    if (loaiVanBanId) {
        getThanhPhanHoSoByLoaiVanBanId(loaiVanBanId, selectedThanhPhanHoSoIds, thanhPhanHoSoId);
    }

    clearValidTphs();
    clearHtmlFileUploadTphs();

    if (files.length > 0) {
        renderFilesList(files);
    }
    $("#selectLoaiVanBan").prop('disabled', false);
    $("#thanhPhanHoSo").prop('disabled', false);
}

$("#NewThanhPhanHoSo").click(function () {
    $("#tphsTitle").text("");
    $("#tphsTitle").text(consts.tphsTitleCreate);
    $("#tphsSaving").attr("_id", "0");
    resetThanhPhanHoSoPopup();
    setSoQuyetDinhList();
});

function setvalueDefaultThanhPhanHoSoPopup(dataDefault) {
    $("#tphsTitle").text("");
    $("#tphsTitle").text(consts.tphsTitleUpdate);
    $("#selectLoaiVanBan").val(dataDefault[0].LoaiVanBanId).change();
    $("#tphsSaving").attr("_id", dataDefault[0].ThanhPhanHoSoId);
    $("#soQuyetDinh").val(dataDefault[0].SoQuyetDinh);
    $("#ngayBanHanhTphs").val(dataDefault[0].NgayBanHanhFormat);
    $("#donViBanHanhTphs").val(dataDefault[0].DonViBanHanhId).change();
    $("#trichYeuTphs").val(dataDefault[0].TrichYeu);
    $("#batBuocTphs").val(dataDefault[0].BatBuoc);
    setSoQuyetDinhList(dataDefault[0].SoQuyetDinh);
}

function resetThanhPhanHoSoPopup() {
    $("#selectLoaiVanBan").val($("#selectLoaiVanBan option:first").val()).change();
    $("#soQuyetDinh").val("");
    $("#ngayBanHanhTphs").val("");
    $("#donViBanHanhTphs").val($("#selectLoaiVanBan option:first").val()).change();
    $("#trichYeuTphs").val("");
    $("#batBuocTphs").val("false");

    var loaiVanBanId = $("#selectLoaiVanBan").children("option:selected").val();
    var selectedThanhPhanHoSoIds = new Array(0);

    if (dataThanhPhanHoSo.length > 0) {
        selectedThanhPhanHoSoIds = dataThanhPhanHoSo.map(a => a.ThanhPhanHoSoId);
    }

    if (loaiVanBanId) {
        getThanhPhanHoSoByLoaiVanBanId(loaiVanBanId, selectedThanhPhanHoSoIds);
    }

    clearValidTphs();
    clearHtmlFileUploadTphs();
    thanhPhanHoSoId = null;
    $("#selectLoaiVanBan").prop('disabled', false);
    $("#thanhPhanHoSo").prop('disabled', false);
}

function clearHtmlFileUploadTphs() {
    $(".tphs-file-list tbody").children().remove();
    $('.hidden-inputs-tphs').children().remove();
    $(".tphs-file-list").hide();
}

function clearValidTphs() {
    if ($("#thanhPhanHoSo-error").length > 0) {
        $("#thanhPhanHoSo-error").remove();
    }
    if ($("#selectLoaiVanBan-error").length > 0) {
        $("#selectLoaiVanBan-error").remove();
    }
    if ($("#FileUploadsTphs-error").length > 0) {
        $("#FileUploadsTphs-error").remove();
    }
    $(".soQuyetDinh-valid-exist").text("");
}

function checkValidFileTphs() {
    if ($(".tphs-file-list tbody tr").length > 0) {
        $('.file-chooser-tphs__input').attr('name', '');
        $('.tphs-file_validate').attr('data-valmsg-for', '');
        $('.hidden-inputs-tphs input').each(function () {
            $(this).attr('name', '');
        });
    } else {
        $('.file-chooser-tphs__input').attr('name', 'FileUploadsTphs');
        $('.tphs-file_validate').attr('data-valmsg-for', 'FileUploadsTphs');
        $('.hidden-inputs-tphs input').each(function () {
            $(this).attr('name', 'FileUploadsTphs');
        });
    }
}

function checkValidNgayBanHanhTphs() {
    var ngayBanHanh = $("#ngayBanHanhTphs").val();

    if (ngayBanHanh == "") {
        $(".ngayBanHanhTphs-valid").text("Trường này là bắt buộc nhập");
    } else {
        $(".ngayBanHanhTphs-valid").text("");
    }
}

$("#selectLoaiVanBan").change(function () {
    var loaiVanBanId = $(this).children("option:selected").val();
    var selectedThanhPhanHoSoIds = new Array(0);

    if (dataThanhPhanHoSo.length > 0) {
        selectedThanhPhanHoSoIds = dataThanhPhanHoSo.map(a => a.ThanhPhanHoSoId);
    }

    if (loaiVanBanId) {
        getThanhPhanHoSoByLoaiVanBanId(loaiVanBanId, selectedThanhPhanHoSoIds, thanhPhanHoSoId);
    } else {
        $("#thanhPhanHoSo option").remove();
        $("#thanhPhanHoSo").append("<option value=''></option>");
    }
});

function getThanhPhanHoSoByLoaiVanBanId(loaiVanBanId, selectedThanhPhanHoSoIds, thanhPhanHoSoId) {
    $.ajax("/api/app/thanhPhanHoSo/thanhPhanHoSoByLoaiVanBanId?id=" + loaiVanBanId, {
        method: "GET",
        type: "GET",
        dataType: "json",
        contentType: "application/json",
        cache: false,
        xhrFields: { withCredentials: true },
        async: false
    }).done(function (data) {
        $("#thanhPhanHoSo option").remove();
        var optionsHtml = "";
        if (typeof selectedThanhPhanHoSoIds != "undefined" && selectedThanhPhanHoSoIds.length > 0) {
            selectedThanhPhanHoSoIds = selectedThanhPhanHoSoIds.map(function (x) {
                return x;
            }).filter(function (e) {
                return e != thanhPhanHoSoId;
            });
            data = data.filter(x => !selectedThanhPhanHoSoIds.find(s => x.id == s));
        }
        if (data.length > 0) {
            data.forEach(function (item) {
                optionsHtml = optionsHtml + "<option value=" + item.id + ">" + item.tenThanhPhanHoSo + "</option>";
            });
        } else {
            optionsHtml = optionsHtml + "<option value=''></option>";
        }

        $("#thanhPhanHoSo").append(optionsHtml);

        if (thanhPhanHoSoId && typeof thanhPhanHoSoId != "undefined") {
            $("#thanhPhanHoSo").val(thanhPhanHoSoId).change();
        }
    });
}

function getFileIdsTphs() {
    dataThanhPhanHoSo.forEach(function (item) {
        if (item.Files && item.Files.length > 0) {
            item.Files.forEach(function (file) {
                if (file.Id == null || file.Id == "null") {
                    var fd = new FormData();
                    var files = file.Files;
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
                                file.Id = response.id;
                            }
                        },
                    });
                }
            });
        }
    });
}

(function ($) {
    $('.tphs-file-list').hide();

    $.fn.uploaderfileTphs = function (options) {
        var settings = $.extend({
            acceptedFileTypes: ['pdf', 'jpg', 'jpeg', 'png', 'doc', 'docx']
        }, options);
        uploadId = 1;
        var tphsFileList = $('<ul class="tphs-file-list"></ul>');
        var tphsHiddenInputs = $('<div class="hidden-inputs-tphs hidden" style="display:none"></div>');
        $('.hidden-inputs-tphs').remove();
        $('.file-uploader__message-area').after(tphsFileList);
        $('.tphs-file-list').after(tphsHiddenInputs);

        //xử lý khi chọn file
        $('.file-chooser-tphs__input').on('change', function () {
            var file = $('.file-chooser-tphs__input').val();
            var fileName = (file.match(/([^\\\/]+)$/)[0]);
            renderFile(fileName, settings, this);
        });
    };
}(jQuery));

function renderFilesList(files) {
    uploadId = 1;
    $.fn.uploaderfileTphsList = function (options) {
        var settings = $.extend({
            acceptedFileTypes: ['pdf', 'jpg', 'jpeg', 'png', 'doc', 'docx']
        }, options);

        var tphsFileList = $('<ul class="tphs-file-list"></ul>');
        var tphsHiddenInputs = $('<div class="hidden-inputs-tphs hidden" style="display:none"></div>');
        $('.hidden-inputs-tphs').remove();
        $('.file-uploader__message-area').after(tphsFileList);
        $('.tphs-file-list').after(tphsHiddenInputs);
        files.forEach(function (item) {
            var fileName = item.file;

            if (typeof item.fileId != "undefined") {
                renderFile(fileName, settings, this, item.fileId);
            } else {
                renderFile(fileName, settings, this);
            }
        });
    };
    $('.fileUploadsTphs').uploaderfileTphsList({
    });
}

function renderFile(fileName, settings, current, fileId) {
    //validate the file
    var check = checkFile(fileName, settings, current);
    if (check === "valid") {
        // thêm các file được upload
        $('.hidden-inputs-tphs').append($('.file-chooser-tphs__input'));
        var array_name = fileName.split('.');
        var kieu = array_name[array_name.length - 1];
        var imgFile;
        if (kieu == "pdf") {
            imgFile = "<img src='/img/pdf.svg' class='attached-icon'>";
        }
        else if (kieu == "doc" || kieu == "docx") {
            imgFile = "<img src='/img/word.svg' class='attached-icon'>";
        }
        else {
            imgFile = "<img src='/img/image.svg' class='attached-icon'>";
        }
        $('.file-chooser-tphs').append($('.file-chooser-tphs__input').clone({ withDataAndEvents: true }));

        var bodyContent = '<tr><td>' + imgFile + '<span>'
            + fileName + '</span></td><td class="table_action">' +
            '<button class="btn-action btn-delete removal-button" data-uploadid="' + uploadId + '"';
        if (fileId && typeof fileId != "undefined") {
            bodyContent = bodyContent + 'id="' + fileId + '">';
        } else {
            bodyContent = bodyContent + 'id=""' + '>';
        }
        bodyContent = bodyContent + '<i class="fa fa-trash-o"></i>' + '</button></td></tr>';
        $('.tphs-file-list tbody').append(bodyContent);

        $('.hidden-inputs-tphs .file-chooser-tphs__input')
            .removeClass('file-chooser-tphs__input')
            .attr('data-uploadId', uploadId)
            .attr('_fileId', typeof fileId != "undefined" ? fileId : "")
            .attr('_fileName', fileName);

        uploadId++;

        $('.removal-button').on('click', function (e) {
            e.preventDefault();
            var fileId = $(this).attr("id");
            if (fileId) {
                deletedFileIds.push(fileId);
            }

            $('.hidden-inputs-tphs input[data-uploadid="' + $(this).data('uploadid') + '"]').remove();

            $(this).parent().parent().hide("puff").delay(10).queue(function () { $(this).remove(); });

            function check() {
                if ($('.tphs-file-list tbody tr .table_action')[0]) {
                    $('.tphs-file-list').show();
                } else {
                    $('.tphs-file-list').hide();
                }
            }
            setTimeout(check, 1000);


        });

    }

    if ($('.tphs-file-list tbody tr')) {
        $('.tphs-file-list').show();
    } else {
        $('.tphs-file-list').hide();
    }
};

//init
$(document).ready(function () {
    $('.fileUploadsTphs').uploaderfileTphs({
    });
});