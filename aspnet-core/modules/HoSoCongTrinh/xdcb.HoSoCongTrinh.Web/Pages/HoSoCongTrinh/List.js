$(function () {
    var l = abp.localization.getResource('xdcb');

    var chuDauTuId = isChuDauTu == "" ? "" : isChuDauTu;
    var input =
    {
        tenCongTrinh: '',
        trangThaiHoSo: 0,
        loaiHoSoId: '',
        chuDauTuId: chuDauTuId,
        namThucHienCongTrinh: ''
    }
    Load(input);

    function Load(input) {
        var loaiHoSo = JSON.parse($('#loaihoso_select').attr('_loaiHoSo'));
        function isNotEmpty(value) {
            return value !== undefined && value !== null && value !== "";
        }
        var hosoCongTrinhs = new DevExpress.data.CustomStore({
            key: "stt",
            load: function (loadOptions) {
                var deferred = $.Deferred(),
                    args = input;
                [
                    "skip",
                    "take"
                ].forEach(function (i) {
                    if (i in loadOptions && isNotEmpty(loadOptions[i]))
                        args[i] = JSON.stringify(loadOptions[i]);
                });

                abp.ajax({
                    url: '/api/app/hoSoCongTrinh/hoSoCongTrinhs',
                    type: 'get',
                    data: args,
                }).done(function (response) {
                    deferred.resolve(response.items, {
                        totalCount: response.totalCount
                    });
                }).fail(function () { throw "Có lỗi xảy ra trong quá trình xử lý" });

                return deferred.promise();
            },
        });

        $("#hosocongtrinhlist").dxDataGrid({
            dataSource: hosoCongTrinhs,
            rowTemplate: function (container, item) {
                var data = item.data,
                    markup = "<tbody class='rowClass'><tr class='main-row dx-row-alt'><td class='stt' style='width: 50px'>" + data.stt
                        + "</td><td colspan = '4' style='width:100%'><input type='hidden' value='" + data.congTrinh.id + "'/><b class='text-primary'>" + data.congTrinh.ten + "</b>";

                if (isChuDauTu == "") {
                    if (!data.chuDauTu.ten) {
                        markup += "<br /><span><i>Chủ đầu tư:</i></span>"
                    } else {
                        markup += "<br /><span><i>Chủ đầu tư: " + data.chuDauTu.ten + "</i></span>"
                    }
                }
                markup += '</td> <td class="text-center" style="width:150px">';
                if (checkLoaiHoSo(data.hoSos)) {
                    markup += '<div class="btn-group"> <button class="btn-action btn-add dropdown-toggle" data-toggle="dropdown" type="button"><span class="caret"></span><div class="listLoaiHoSo" listId="' + getListId(data.hoSos) + '" hidden></div></button>';

                    var dropdown = '';

                    if (loaiHoSoCount > 0) {
                        dropdown += '<ul class="dropdown-menu" >';
                        dropdown += '<li class="title_loaihoso">Chọn loại hồ sơ</li>';
                        for (var i = 0; i < loaiHoSo.length; i++) {
                            dropdown += " <a href='/HoSoCongTrinh/Create?congTrinhId=" + data.congTrinh.id + "&&loaiHoSoId=" + loaiHoSo[i].Id + "&&thongTinChung=" + GetThongTinChung(data.congTrinh, data.chuDauTu) + "'><li _id=" + loaiHoSo[i].Id + ">" + loaiHoSo[i].Name + "</li></a>";
                        }
                        dropdown += '</ul>'
                    }

                    markup += dropdown + '</div>';
                }
                markup += '</td></tr>';
                if (data.hoSos == null && data.hoSos.Length == 0) {
                    markup += '<tr></tr>';
                } else {
                    markup = markup + FormatItems(data.hoSos, data.congTrinh, data.chuDauTu);
                }
                markup = markup + '</tbody>';

                container.append(markup);
            },
            ColumnAutoWidth: false,
            remoteOperations: true,
            paging: {
                pageSize: 10
            },
            pager: {
                showNavigationButtons: true,
                showInfo: true,
                // TODO hiển thị showinfo phân trang
                infoText: "Hiển thị {2} kết quả"
            },
            columns: [{
                dataField: stt,
                Caption: stt,
                width: 50
            }, {
                dataField: htmldecode(tenCongTrinh),
                Caption: htmldecode(tenCongTrinh)

            }, {
                dataField: "",
                width: 150
            }]
        });
    }

    function Search() {
        var chuDauTuId = isChuDauTu == "" ? $("#ChuDauTu").val() : isChuDauTu;
        var searchInput = {
            tenCongTrinh: $("#keyword").val(),
            trangThaiHoSo: $("#TrangThaiHoSo").val(),
            loaiHoSoId: $("#LoaiHoSo").val(),
            chuDauTuId: chuDauTuId,
            namThucHienCongTrinh: $("#Year").val()
        }
        input = searchInput;

        Load(searchInput);

    }

    $('#Search').click(function () {
        Search();
    });
    $('#keyword').keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            Search();
        }
    });


    function FormatItems(items, congtrinh, chudautu) {
        var ThongTinChung = {
            CongTrinh: {
                Id: congtrinh.id,
                Ten: congtrinh.ten,
                MaCongTrinh: congtrinh.maCongTrinh,
                MaLoaiKhoan: congtrinh.maLoaiKhoan,
                MaChuongTrinhMucTieuQuocGia: congtrinh.maChuongTrinhMucTieuQuocGia,
                NhomCongTrinh: congtrinh.nhomCongTrinh,
                LoaiCongTrinh: congtrinh.loaiCongTrinh,
                ThoiGianThucHienTuNgay: congtrinh.thoiGianThucHienTuNgay,
                ThoiGianThucHienDenNgay: congtrinh.thoiGianThucHienDenNgay,
                DienTich: congtrinh.dienTich
            },
            ChuDauTu: {
                Id: chudautu.id,
                Ten: chudautu.ten
            }
        };

        var output = "";
        for (var i = 0; i < items.length; i++) {
            output = output + "<tr><td class='stt'>" + items[i].stt +
                "</td><td colspan='4'><b>" + items[i].tenLoaiHoSo + "</b><br><div class='row'><div class='col-4'><span>Trạng thái xử lý:  </span>";
            if ("HOAN_THANH" == items[i].trangThaiXuLy.ma) {
                output += "<span class='badge badge-success'>" + items[i].trangThaiXuLy.ten + "</span>";
            } else if ("DANG_SOAN" == items[i].trangThaiXuLy.ma) {
                output += "<span class='badge badge-info'>" + items[i].trangThaiXuLy.ten + "</span>";
            } else if ("DANG_XU_LY" == items[i].trangThaiXuLy.ma) {
                output += "<span class='badge badge-primary'>" + items[i].trangThaiXuLy.ten + "</span>";
            } else {
                output += "<span class='badge badge-warning'>" + items[i].trangThaiXuLy.ten + "</span>";
            }

            if (items[i].hanXuLy != null) {
                if (items[i].ngayXuLy < 0) {
                    output = output + "</div><div class='col-4'><span>Hạn xử lý:  </span><span class='text-danger'>" + items[i].hanXuLy + " - trễ " + items[i].ngayXuLy * (-1) + " ngày</span></div>";
                } else if (items[i].ngayXuLy > 3) {
                    output = output + "</div><div class='col-4'><span>Hạn xử lý:  </span><span>" + items[i].hanXuLy + "</span></div>";
                } else {
                    output = output + "</div><div class='col-4'><span>Hạn xử lý:  </span><span class='text-warning'>" + items[i].hanXuLy + " - còn " + items[i].ngayXuLy + " ngày</span></div>";
                }

            } else {
                output = output + "</div><div class='col-4'></div>";
            }

            if (items[i].soLanDieuChinh != 0) {
                output = output + "<div class='col-4'><span>Số lần điều chỉnh:" + items[i].soLanDieuChinh + "</span></div>";
            } else {
                output = output + "<div class='col-4'></div>";
            }
            output += "</div></td > ";
            output = output + "<td class='text-center button-container'>";

            if (items[i].action.view == true) {
                output = output + "<a href='/HoSoCongTrinh/Detail?hoSoCongTrinhId=" + items[i].hoSoCongTrinhId + "&&congTrinhId=" + congtrinh.id + "&&thongTinChung=" + JSON.stringify(ThongTinChung) + "'><button class='btn-action btn-detail' type='button'><i class='fa fa-eye'></i></button></a>";
            }
            if (items[i].action.edit == true) {
                output = output + "<a href='/HoSoCongTrinh/Edit?hoSoCongTrinhId=" + items[i].hoSoCongTrinhId + "&&congTrinhId=" + congtrinh.id + "&&thongTinChung=" + JSON.stringify(ThongTinChung) + "'><button class='btn-action btn-edit' type='button'><i class='fa fa-pencil-square-o'></i></button></a>";
            }
            if (items[i].action.delete == true) {
                output = output + "<button class='btn-action btn-delete' _type='delete' hoSoCongTrinhId='" + items[i].hoSoCongTrinhId + "' type='button'><i class='fa fa-trash-o'></i></button>";
            }
            if (items[i].action.add == true) {
                output = output + "<a href='/HoSoCongTrinh/Create?hoSoCongTrinhId=" + items[i].hoSoCongTrinhId + "&&congTrinhId=" + congtrinh.id + "&&loaiHoSoId=" + items[i].loaiHoSoId + "&&thongTinChung=" + JSON.stringify(ThongTinChung) + "'><button class='btn-action btn-detail' type='button'><i class='fa fa-plus'></i></button></a>";
            }
            output = output + "</td></tr>";
        }

        return output;
    }

    function getListId(items) {
        var output = "";
        for (var i = 0; i < items.length; i++) {
            output = output + items[i].loaiHoSoId + "/"
        }
        return output;
    }

    function GetThongTinChung(congtrinh, chudautu) {
        var ThongTinChung = {
            CongTrinh: {
                Id: congtrinh.id,
                Ten: congtrinh.ten,
                MaCongTrinh: congtrinh.maCongTrinh,
                MaLoaiKhoan: congtrinh.maLoaiKhoan,
                MaChuongTrinhMucTieuQuocGia: congtrinh.maChuongTrinhMucTieuQuocGia,
                NhomCongTrinh: congtrinh.nhomCongTrinh,
                LoaiCongTrinh: congtrinh.loaiCongTrinh,
                ThoiGianThucHienTuNgay: congtrinh.thoiGianThucHienTuNgay,
                ThoiGianThucHienDenNgay: congtrinh.thoiGianThucHienDenNgay,
                DienTich: congtrinh.dienTich
            },
            ChuDauTu: {
                Id: chudautu.id,
                Ten: chudautu.ten
            }
        };
        return JSON.stringify(ThongTinChung);
    }

    function checkLoaiHoSo(items) {
        if (items.length == loaiHoSoCount) {
            return false;
        } else {
            if (isChuDauTu == "") {
                return true;
            } else {
                for (var i = 0; i < items.length; i++) {
                    if ("DANG_SOAN" == items[i].trangThaiXuLy.ma || "DANG_XU_LY" == items[i].trangThaiXuLy.ma) {
                        return false;
                    }
                }
                return true;
            }

        }
    }

    $('#list').on('click', '.dropdown-toggle', function () {
        var _idLoaiHoSo = $(this).find('.listLoaiHoSo').attr('listId');
        var listLoaiHoSo = _idLoaiHoSo.split('/');
        var button = $(this);
        for (var i = 0; i < listLoaiHoSo.length; i++) {
            button.parent().find('.dropdown-menu').find('li').each(function () {
                if ($(this).attr("_id") == listLoaiHoSo[i]) {
                    $(this).hide();
                }
            });
        }

    });

    $('#hosocongtrinhlist').on('click', '.btn-delete', function () {
        var hoSoCongTrinhId = $(this).attr("hoSoCongTrinhId");
        if ($(this).attr("_type") === "delete") {
            abp.message.confirm(
                messages.delete,
                messages.delete_title,
                function (isConfirmed) {
                    if (isConfirmed) {
                        xdcb.hoSoCongTrinh.services.hoSoCongTrinh
                            .delete(hoSoCongTrinhId)
                            .then(function () {
                                abp.notify.info(messages.SuccessfullyDeleted);
                                Load(input);
                            });
                    }
                }
            );
        }
    });
});