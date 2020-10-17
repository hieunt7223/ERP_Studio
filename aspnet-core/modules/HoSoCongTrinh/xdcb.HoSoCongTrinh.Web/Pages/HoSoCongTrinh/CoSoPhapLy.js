var idNewCoSoPhaply = 1;
var soKyHieuList = new Array(0);
var csplUploadId = 1;

function insertCoSoPhapLy(btn) {
    var textValidSoKyHieu = $(".soKyHieu-valid-exist").text();
    var textValidNgayBanHanh = $(".ngayBanHanh-valid").text();

    checkValidNgayBanHanh();
    checkValidFileCspl();

    if ($("#coSoPhapLyForm").valid() && textValidSoKyHieu == "" && textValidNgayBanHanh == "") {
        var coSoPhapLyData = formatDataFromNewCoSoPhapLy();
        var data = new Array(0);
        var idIndex = $(btn).attr("_id");

        if (idIndex != 0) {
            for (var i = 0; i < dataCoSoPhapLy.length; i++) {
                if (dataCoSoPhapLy[i].Id == idIndex) {
                    dataCoSoPhapLy[i] = coSoPhapLyData[0];
                    break;
                }
            }
        } else {
            data = coSoPhapLyData;
        }
        $('#modalNewCoSoPhapLy').modal('hide');
        getDataGridCoSoPhapLy(formatDataCSPL(data));
        idNewCoSoPhaply++;
    }
}

function checkValidNgayBanHanh() {
    var ngayBanHanh = $("#ngayBanHanh").val();

    if (ngayBanHanh == "") {
        $(".ngayBanHanh-valid").text("Trường này là bắt buộc nhập");
    } else {
        $(".ngayBanHanh-valid").text("");
    }
}

function checkValidFileCspl() {
    if ($(".cspl-file-list tbody tr").length > 0) {
        $('.file-chooser-cspl__input').attr('name', '');
        $('.cspl-file_validate').attr('data-valmsg-for', '');
        $('.hidden-inputs-cspl input').each(function () {
            $(this).attr('name', '');
        });
    } else {
        $('.file-chooser-cspl__input').attr('name', 'FileUploadsCspl');
        $('.cspl-file_validate').attr('data-valmsg-for', 'FileUploadsCspl');
        $('.hidden-inputs-cspl input').each(function () {
            $(this).attr('name', 'FileUploadsCspl');
        });
    }
}

$("#soKyHieu").blur(function () {
    var soKyHieu = $(this).val();
    if (soKyHieuList.find(x => x == $.trim(soKyHieu))) {
        $(".soKyHieu-valid-exist").text("Dữ liệu đã tồn tại");
        $(".soKyHieu-valid-exist").removeClass("d-none");
    } else {
        $(".soKyHieu-valid-exist").text("");
        $(".soKyHieu-valid-exist").addClass("d-none");
    }
});

$("#ngayBanHanh").blur(function () {
    checkValidNgayBanHanh();
});

$("#ngayBanHanh").datepicker(
    {
        onClose: function () {
            this.focus();
        }
    }
);

function editCoSoPhapLy(btn) {
    var id = $(btn).attr("_id");
    var coSoPhapLyViewModel = dataCoSoPhapLy.filter(x => x.Id == id)[0]["CoSoPhapLyJsonViewModel"];
    var soKyHieu = coSoPhapLyViewModel.SoKyHieu;

    $("#csplSaving").attr("_id", id);
    $(".csplTitle").text(consts.csplTitleUpdate);
    clearNewPopupCoSoPhapLy();
    setValuesPopupCoSoPhapLy(coSoPhapLyViewModel);
    setSoKyKieuList(soKyHieu);
}

function insertThuVienVanBan() {
    var thuVienVanBanData = selectingThuVienVanBans;
    $('#modalNewThuVienVanBan').modal('hide');
    getDataGridCoSoPhapLy(formatDataCSPL(thuVienVanBanData));
}

function formatDataFromNewCoSoPhapLy() {
    var files = new Array(0);
    var soKyHieu = $("#soKyHieu").val();
    var ngayBanHanh = $("#ngayBanHanh").val();
    var donViBanHanh = $("#donViBanHanh").val();
    var capBanHanh = $("#capBanHanh").children("option:selected").val();
    var loaiVanBanId = $("#loaiVanBan").children("option:selected").val();
    var tenLoaiVanBan = $("#loaiVanBan").children("option:selected").text();
    var linhVucVanBan = $("#linhVucVanBan").children("option:selected").val();
    var trichYeu = $("#trichYeu").val();

    if (soKyHieu) {
        soKyHieuList.push(soKyHieu);
    }

    $('.hidden-inputs-cspl.hidden .file-cspl').each(function () {
        files.push({
            Id: $(this).attr("_fileId") != "" ? $(this).attr("_fileId") : null,
            TenFile: $(this).attr("_fileName"),
            Files: $(this)[0].files[0]
        });
    });

    return [
        {
            CoSoPhapLyJsonViewModel: {
                SoKyHieu: $.trim(soKyHieu),
                NgayBanHanh: ngayBanHanh,
                DonViBanHanh: $.trim(donViBanHanh),
                CapBanHanh: capBanHanh,
                LoaiVanBanId: loaiVanBanId,
                TenLoaiVanBan: tenLoaiVanBan,
                LinhVucVanBan: linhVucVanBan != "" ? linhVucVanBan : consts.guid_is_null,
                TrichYeu: trichYeu,
                Files: files
            },
            Id: idNewCoSoPhaply,
            soKyHieu: soKyHieu,
            ngayBanHanhFormat: ngayBanHanh,
            donViBanHanh: donViBanHanh,
            trichYeu: trichYeu,
        }
    ];
}

function setValuesPopupCoSoPhapLy(model) {
    $("#soKyHieu").val(model.SoKyHieu);

    if (model.NgayBanHanh.toString().match(/^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/)) {
        $("#ngayBanHanh").val(model.NgayBanHanh);
    } else {
        $("#ngayBanHanh").datepicker("setDate", new Intl.DateTimeFormat('en-GB').format(model.NgayBanHanh));
    }

    $("#donViBanHanh").val(model.DonViBanHanh);
    $("#capBanHanh").val(model.CapBanHanh).change();
    $("#loaiVanBan").val(model.LoaiVanBanId).change();
    $("#linhVucVanBan").val(model.LinhVucVanBan).change();
    $("#trichYeu").val(model.TrichYeu);
    setHtmlFileUploadCoSoPhapLy(model.Files);
}

function setHtmlFileUploadCoSoPhapLy(data) {
    var fileString = getFileListString(data);
    var files = new Array(0);

    if (fileString != "") {
        var file = fileString.split('/');
        file.forEach(function (item) {
            files.push({
                file: item.split(',')[0],
                fileId: item.split(',')[1]
            });
        });
    }

    if (files.length > 0) {
        renderFilesListCspl(files);
    }
}

function clearNewPopupCoSoPhapLy() {
    $("#soKyHieu").val("");
    $("#ngayBanHanh").val("");
    $("#donViBanHanh").val("");
    $("#capBanHanh").val($("#selectLoaiVanBan option:first").val()).change();
    $("#loaiVanBan").val($("#selectLoaiVanBan option:first").val()).change();
    $("#linhVucVanBan").val($("#selectLoaiVanBan option:first").val()).change();
    $("#trichYeu").val("");
    $(".soKyHieu-valid-exist").text("");
    $(".ngayBanHanh-valid").text("");

    clearValidCspl();
    clearHtmlFileUploadCoSoPhapLy();
}

function clearValidCspl() {
    if ($("#soKyHieu-error").length > 0) {
        $("#soKyHieu-error").remove();
    }
    if ($("#donViBanHanh-error").length > 0) {
        $("#donViBanHanh-error").remove();
    }
    if ($("#loaiVanBan-error").length > 0) {
        $("#loaiVanBan-error").remove();
    }
    if ($("#FileUploadsCspl-error").length > 0) {
        $("#FileUploadsCspl-error").remove();
    }
}

function clearHtmlFileUploadCoSoPhapLy() {
    $(".cspl-file-list tbody").children().remove();
    $('.hidden-inputs-cspl').children().remove();
    $(".cspl-file-list").hide();
}

function clearSelection() {
    $("#dataGirdMultiple").dxDataGrid("instance").clearSelection();
}

$('#Search_ThuVienVanBan').click(function () {
    searchThuVienVanBan();
});

function formatFileStringCoSoPhapLy(data) {
    var fileString = ""
    var thuVienVanBanId = data.ThuVienVanBanId;
    var files = new Array(0);

    if (thuVienVanBanId) {
        files = data.Files;
    } else {
        files = data.CoSoPhapLyJsonViewModel.Files;
    }

    if (files) {
        for (var i = 0; i < files.length; i++) {
            fileString += files[i].TenFile + ',';
            if (typeof files[i].Id != "undefined") {
                fileString += files[i].Id;
            } else {
                fileString += " ";
            }
            fileString += '/';
        }
        if (files.length > 0) {
            fileString += '/';
            fileString = fileString.replace('//', '');
        }
    }
    return fileString;
}

function getDataGridThuVienVanBan(data) {
    data = data.filter(ar => !dataCoSoPhapLy.find(rm => (rm.ThuVienVanBanId === ar.id)));

    $("#dataGirdMultiple").dxDataGrid({
        noDataText: messages.no_data,
        dataSource: data,
        showBorders: true,
        selection: {
            mode: "multiple",
            selectAllMode: "page"
        },
        paging: {
            pageSize: 10
        },
        pager: {
            showNavigationButtons: true,
            showInfo: true,
            // TODO hiển thị showinfo phân trang
            infoText: "Hiển thị {2} kết quả"
        },
        filterRow: {
            visible: false
        },
        wordWrapEnabled: true,
        onSelectionChanged: SelectionChanged,
        columns: [
            {
                dataField: "soKyHieu",
                caption: "Số ký hiệu"
            },
            {
                dataField: "tenLoaiVanBan",
                caption: "Tên loại văn bản"
            },
            {
                dataField: "trichYeu",
                caption: "Trích yếu",
                width: 150
            },
            {
                dataField: "donViBanHanh",
                caption: "Đơn vị ban hành"
            },
            {
                dataField: "ngayBanHanhFormat",
                caption: "Ngày ban hành"
            },
            {
                dataField: "Files",
                caption: "File đính kèm",
                cellTemplate: function (container, item) {
                    var markup = FormatItems(item.data.files);
                    container.append(markup);
                },
                width: 250
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
                            "<button class='btn-action btn-detail' onclick='ChiTietCoSoPhapLy(this)' id='createupdate' _thuvienvanbanid='" + id + "' data-toggle='modal' data-target='.CoSoPhapLyDetail' type='button'>" +
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

function getDataGridCoSoPhapLy(list) {
    $("#cosophaply-table").dxDataGrid({
        noDataText: messages.no_data,
        dataSource: list,
        showBorders: true,
        paging: {
            enabled: false
        },
        wordWrapEnabled: true,
        columns: [
            {
                dataField: "ThuVienVanBanId",
                visible: false
            },
            {
                dataField: "Stt",
                caption: "#",
                width: 60,
                alignment: "left",
                allowEditing: false,
                cellTemplate: orderRowItemNo
            },
            {
                dataField: "NoiDung",
                caption: "Nội dung"
            },
            {
                dataField: "Files",
                caption: "File đính kèm",
                cellTemplate: function (container, data) {
                    var output = formatFilesCoSoPhapLy(data.data);
                    container.append(output);
                },
                width: 350
            },
            {
                width: 100,
                cellTemplate: function (container, item) {
                    var data = item.data,
                        markup = "<div class='text-center'>";
                    if (data.ThuVienVanBanId == null) {
                        markup = markup +
                            "<button class='btn-action btn-edit tphs-edit' _id='" + data.Id + "'" + "_model='" + data.CoSoPhapLyJsonViewModel + "'" + "onclick='editCoSoPhapLy(this)'" + "data-toggle='modal' data-target='#modalNewCoSoPhapLy'>" +
                            "<i class='fa fa-pencil-square-o'></i>" +
                            "</button >";
                        markup = markup +
                            "<button class='btn-action btn-delete' _id='" + data.Id + "'" + "_files='" + formatFileStringCoSoPhapLy(data) + "'" + "onclick='deleteCoSoPhapLyOnRow(this)'" + ">" +
                            "<i class='fa fa-trash-o'></i>" +
                            "</button>" +
                            "</div>";
                    } else {
                        markup = markup +
                            "<button class='btn-action btn-delete' _id='" + data.Id + "'" + "_files=''" + "onclick='deleteCoSoPhapLyOnRow(this)'" + ">" +
                            "<i class='fa fa-trash-o'></i>" +
                            "</button>" +
                            "</div>";
                    }

                    container.append(markup);
                }
            }
        ],
        onContentReady: GetDataCoSoPhapLy
    });
}

function formatDataCSPL(item) {
    var list = Array(0);
    var data = new Array(0);

    if (item.length > 0) {
        data = dataCoSoPhapLy.concat(item);
    } else {
        data = dataCoSoPhapLy;
    }
    
    data.forEach(function (item) {
        var trichYeu = item.trichYeu;
        if (!item.trichYeu) {
            trichYeu = "";
        }
        list.push({
            Id: item.Id,
            ThuVienVanBanId: typeof item.ThuVienVanBanId != "undefined" ? item.ThuVienVanBanId : item.id,
            NoiDung: typeof item.NoiDung != 'undefined' ? item.NoiDung : "Nghị định số " + item.soKyHieu + " ngày " + item.ngayBanHanhFormat + " của " + item.donViBanHanh + " về " + trichYeu,
            CoSoPhapLyJsonViewModel: typeof item.CoSoPhapLyJsonViewModel != "undefined" ? item.CoSoPhapLyJsonViewModel : null,
            Files: typeof item.files != "undefined" ? item.files : item.Files
        });
    });

    return list;
}

function deleteCoSoPhapLyOnRow(btn) {
    var id = $(btn).attr("_id");
    var fileIdString = $(btn).attr("_files");

    if (fileIdString) {
        var files = new Array(0);
        files = fileIdString.split('/');
        files.forEach(function (file) {
            deletedFileIds.push(file.split(',')[1]);
        });
    }
    dataCoSoPhapLy = dataCoSoPhapLy.filter(x => x.Id != id);

    getDataGridCoSoPhapLy(dataCoSoPhapLy);
}

function searchThuVienVanBan() {
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
        getDataGridThuVienVanBan(data_result.items);
    });
}

function getThuVienVanBanModal() {
    abp.ajax({
        url: '/api/app/thuVienVanBan?SkipCount=0&MaxResultCount=1000',
        type: 'get',
    }).done(function (data) {
        getDataGridThuVienVanBan(data.items);
        clearSelection();
    });
}

function getCoSoPhapLyModal() {
    clearNewPopupCoSoPhapLy();
    $("#capBanHanh").val($("#capBanHanh option:first").val()).change()
    $("#csplSaving").attr("_id", "0");
    $(".csplTitle").text(consts.csplTitleCreate);
    $(".soKyHieu-valid-exist").text("");
    setSoKyKieuList();
}

function setSoKyKieuList(soKyHieu) {
    var data = new Array(0);
  
    if (dataCoSoPhapLy.length > 0) {
        dataCoSoPhapLy.forEach(function (item) {
            if (item.CoSoPhapLyJsonViewModel) {
                data.push(item.CoSoPhapLyJsonViewModel.SoKyHieu);
            }
        });
    }

    if (typeof soKyHieu != "undefined") {
        data = data.filter(x => x != soKyHieu);
    }

    soKyHieuList = data;
}

function getFileCspl() {
    dataCoSoPhapLy.forEach(function (item) {
        if (item.CoSoPhapLyJsonViewModel && item.CoSoPhapLyJsonViewModel.Files && item.CoSoPhapLyJsonViewModel.Files.length > 0) {
            item.CoSoPhapLyJsonViewModel.Files.forEach(function (file, index) {
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
                                item.CoSoPhapLyJsonViewModel.Files[index] = {
                                    Id: response.id,
                                    TenFile: response.tenFile,
                                    LinkDownload: response.url
                                };
                            }
                        },
                    });
                }
            });
        }
    });
}

(function ($) {
    $('.cspl-file-list').hide();

    $.fn.uploaderfileCspl = function (options) {
        var settings = $.extend({
            acceptedFileTypes: ['pdf', 'jpg', 'jpeg', 'png', 'doc', 'docx']
        }, options);
        csplUploadId = 1;
        var csplFileList = $('<ul class="cspl-file-list"></ul>');
        var csplHiddenInputs = $('<div class="hidden-inputs-cspl hidden" style="display:none"></div>');
        $('.hidden-inputs-cspl').remove();
        $('.file-uploader__message-area').after(csplFileList);
        $('.cspl-file-list').after(csplHiddenInputs);

        //xử lý khi chọn file
        $('.file-chooser-cspl__input').on('change', function () {
            var file = $('.file-chooser-cspl__input').val();
            var fileName = (file.match(/([^\\\/]+)$/)[0]);
            renderFileCspl(fileName, settings, this);
        });
    };
}(jQuery));

function renderFilesListCspl(files) {
    csplUploadId = 1;
    $.fn.uploaderfileCsplList = function (options) {
        var settings = $.extend({
            acceptedFileTypes: ['pdf', 'jpg', 'jpeg', 'png', 'doc', 'docx']
        }, options);

        var csplFileList = $('<ul class="cspl-file-list"></ul>');
        var csplHiddenInputs = $('<div class="hidden-inputs-cspl hidden" style="display:none"></div>');
        $('.hidden-inputs-cspl').remove();
        $('.file-uploader__message-area').after(csplFileList);
        $('.cspl-file-list').after(csplHiddenInputs);
        files.forEach(function (item) {
            var fileName = item.file;

            if (typeof item.fileId != "undefined") {
                renderFileCspl(fileName, settings, this, item.fileId);
            } else {
                renderFileCspl(fileName, settings, this);
            }
        });
    };
    $('.fileUploadsCspl').uploaderfileCsplList({
    });
}

function renderFileCspl(fileName, settings, current, fileId) {
    //validate the file
    var check = checkFile(fileName, settings, current);
    if (check === "valid") {
        // thêm các file được upload
        $('.hidden-inputs-cspl').append($('.file-chooser-cspl__input'));
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
        $('.file-chooser-cspl').append($('.file-chooser-cspl__input').clone({ withDataAndEvents: true }));

        var bodyContent = '<tr><td>' + imgFile + '<span>'
            + fileName + '</span></td><td class="table_action">' +
            '<button class="btn-action btn-delete removal-button" data-uploadid="' + csplUploadId + '"';
        if (fileId && typeof fileId != "undefined") {
            bodyContent = bodyContent + 'id="' + fileId + '">';
        } else {
            bodyContent = bodyContent + 'id=""' + '>';
        }
        bodyContent = bodyContent + '<i class="fa fa-trash-o"></i>' + '</button></td></tr>';
        $('.cspl-file-list tbody').append(bodyContent);

        $('.hidden-inputs-cspl .file-chooser-cspl__input')
            .removeClass('file-chooser-cspl__input')
            .attr('data-uploadId', csplUploadId)
            .attr('_fileId', typeof fileId != "undefined" ? fileId : "")
            .attr('_fileName', fileName);

        csplUploadId++;

        $('.removal-button').on('click', function (e) {
            e.preventDefault();
            var fileId = $(this).attr("id");
            if (fileId) {
                deletedFileIds.push(fileId);
            }

            $('.hidden-inputs-cspl input[data-uploadid="' + $(this).data('uploadid') + '"]').remove();

            $(this).parent().parent().hide("puff").delay(10).queue(function () { $(this).remove(); });

            function check() {
                if ($('.cspl-file-list tbody tr .table_action')[0]) {
                    $('.cspl-file-list').show();
                } else {
                    $('.cspl-file-list').hide();
                }
            }
            setTimeout(check, 1000);
        });

    }

    if ($('.cspl-file-list tbody tr')) {
        $('.cspl-file-list').show();
    } else {
        $('.cspl-file-list').hide();
    }
};

//init
$(document).ready(function () {
    $('.fileUploadsCspl').uploaderfileCspl({
    });

    $('#modalNewThuVienVanBan').find('.modal-dialog').addClass('modal-dialog-centered-cspl');
});