$(function () {
    if (chuDauTuId==='') {
        chuDauTuId = '00000000-0000-0000-0000-000000000000';
    }
    var l = abp.localization.getResource('xdcb');

    var dataTable = $('#BaoCaoTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,

        ajax:
            abp.libs.datatables.createAjax(function () {
                return abp.ajax($.extend(true, {
                    url: "/api/app/nhuCauKeHoachVon/search?Tenkehoach=TRUNG_HAN&ChuDauTuId=" + chuDauTuId + "&SkipCount=" + $('#BaoCaoTable').DataTable().page.info().page * $('#BaoCaoTable').DataTable().page.len() + "&MaxResultCount=" + $('#BaoCaoTable').DataTable().page.len(),
                    type: "get"
                }));

            })
        ,
        columnDefs: [
            {
                className: "text_center",
                render: function (data, type, full, meta) {
                    var table = $('#BaoCaoTable').DataTable();
                    var info = table.page.info();
                    return info.page * table.page.len() + meta.row + 1;
                }
            },
            { className: "text_center",data: "giaiDoanNam" },
            {
                className: "text_center",
                data: { id: "id", loaiKeHoach: "loaiKeHoach", tuNam: "tuNam", giaiDoanNam:"giaiDoanNam"}, "render": function (data) {
                    if (data.loaiKeHoach === 'DAU_NAM') {
                        let str = '<a href="/BaoCaoNCVTrungHan/Detail?keHoachNhuCauVonId=' + data.id + '&&loaiKeHoach=' + data.loaiKeHoach + '&&giaiDoanNam=' + data.giaiDoanNam + '">' + "Đầu Năm" + '</a>'
                        return str;
                    } else {
                        str = '<a href="/BaoCaoNCVTrungHan/Detail?keHoachNhuCauVonId=' + data.id + '&&loaiKeHoach=' + data.loaiKeHoach + '&&giaiDoanNam=' + data.giaiDoanNam +'">' + "Điều chỉnh" + '</a>'
                        return str;
                    }
                }
            },
            {
                className: "text_center",
                data: { tongNhuCauVonDauNam: "tongNhuCauVonDauNam", loaiKeHoach: "loaiKeHoach", tongNhuCauVonDieuChinh: "tongNhuCauVonDieuChinh" },
                "render": function (data) {
                    if (data.loaiKeHoach === 'DAU_NAM') {
                      
                        return commaSeparateNumber(data.tongNhuCauVonDauNam);
                    } else {
                        return commaSeparateNumber(data.tongNhuCauVonDieuChinh);
                    }
                }
            },
            {
                className: "text_center",
                data: { trangThaiDauNam: "trangThaiDauNam", loaiKeHoach: "loaiKeHoach", trangThaiDieuChinh: "trangThaiDieuChinh" },
                "render": function (data) {
                    if (data.loaiKeHoach === 'DAU_NAM') {
                        switch (data.trangThaiDauNam) {
                            case "DANG_SOAN": {
                                return "Đang soạn";
                            }
                            case "DA_GUI": {
                                return "Đã gửi";
                            }
                            case "DA_CHOT": {
                                return "Đã chốt báo cáo";
                            }
                        }
                    } else {
                        switch (data.trangThaiDieuChinh) {
                            case "DANG_SOAN": {
                                return "Đang soạn";
                            }
                            case "DA_GUI": {
                                return "Đã gửi";
                            }
                            case "DA_CHOT": {
                                return "Đã chốt báo cáo";
                            }
                        }

                    }
                }
            },
            {
                className: "action_table",
                data: { id: "id", trangThaiDauNam: "trangThaiDauNam", loaiKeHoach: "loaiKeHoach", trangThaiDieuChinh: "trangThaiDieuChinh", tuNam: "tuNam", giaiDoanNam: "giaiDoanNam" },
                "render": function (data) {
                    var str = '';
                    str = '<a href="/BaoCaoNCVTrungHan/Edit?keHoachNhuCauVonId=' + data.id + '&&loaiKeHoach=' + data.loaiKeHoach + '&&giaiDoanNam=' + data.giaiDoanNam + '"><button class="btn-action btn-edit" type="button"><i class="fa fa-pencil-square-o"></i></button></a>';
                    if ((data.loaiKeHoach === 'DAU_NAM' && data.trangThaiDauNam === 'DANG_SOAN') || (data.loaiKeHoach === 'DIEU_CHINH' && data.trangThaiDieuChinh === 'DANG_SOAN')) {
                        str += ' <button class="btn-action btn-delete" type="button" _id="' + data.id + '"_loaiKeHoach="' + data.loaiKeHoach + '"><i class="fa fa-trash-o"></i> </button>';
                    }
                   
                    return str;
                }
            }
        ],
        "fnDrawCallback": function (oSettings) {
            if ($('#BaoCaoTable').DataTable().page.info().pages < 2) {
                $('.dataTable_footer').hide();
            }

        }
    }));

    $('#BaoCaoTable tbody').on('click', '.btn-delete', function () {
        var id = $(this).attr("_id");
        var loaiKeHoach = $(this).attr("_loaiKeHoach");
        abp.message.confirm(
            messages.delete,
            messages.delete_title,
            function (isConfirmed) {
                if (isConfirmed) {
                    if (loaiKeHoach === 'DAU_NAM') {
                        abp.ajax({
                            url: '/api/app/nhuCauKeHoachVon/' + id + '/nhuCauKeHoachVonChiTiet',
                            type: 'delete',
                            async: false
                        }).done(function () {
                            abp.ajax({
                                url: '/api/app/nhuCauKeHoachVon/' + id,
                                type: 'delete',
                                async: false
                            }).done(function () {
                                abp.notify.info(messages.SuccessfullyDeleted);
                                dataTable.ajax.reload();
                            })
                        })

                    } else {
                        abp.ajax({
                            url: '/api/app/nhuCauKeHoachVonDieuChinh/' + id,
                            type: 'put',
                            async: false
                        }).done(function () {
                            abp.ajax({
                                url: '/api/app/nhuCauKeHoachVon/' + id + '/nhuCauKeHoachVonDieuChinhChiTiet',
                                type: 'put',
                                async: false
                            }).done(function () {
                                abp.notify.info(messages.SuccessfullyDeleted);
                                dataTable.ajax.reload();
                            })
                        })
                    }
                }
            }
        );
    });

    $('#Search').click(function () {
        Search();
    });

    function Search() {
        dataTable.destroy();
        dataTable = $('#BaoCaoTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            searching: false,
            autoWidth: false,
            scrollCollapse: true,
            ajax: abp.libs.datatables.createAjax(function () {
                return abp.ajax($.extend(true, {
                    url: "/api/app/nhuCauKeHoachVon/search?Nam=" + $('#Year').val() + "&&Loaikehoach=" + $('#LoaiKeHoach').val() + "&&Tenkehoach=TRUNG_HAN&&ChuDauTuId=" + chuDauTuId + "&&SkipCount=" + $('#BaoCaoTable').DataTable().page.info().page * $('#BaoCaoTable').DataTable().page.len() + "&&MaxResultCount=" + $('#BaoCaoTable').DataTable().page.len(),
                    type: "get"
                }));

            }),
            columnDefs: [
                {
                    className: "text_center",
                    render: function (data, type, full, meta) {
                        var table = $('#BaoCaoTable').DataTable();
                        var info = table.page.info();
                        return info.page * table.page.len() + meta.row + 1;
                    }
                },
                { className: "text_center", data: "giaiDoanNam" },
                {
                    className: "text_center",
                    data: { id: "id", loaiKeHoach: "loaiKeHoach", tuNam: "tuNam", giaiDoanNam: "giaiDoanNam" }, "render": function (data) {
                        if (data.loaiKeHoach === 'DAU_NAM') {
                            let str = '<a href="/BaoCaoNCVTrungHan/Detail?keHoachNhuCauVonId=' + data.id + '&&loaiKeHoach=' + data.loaiKeHoach + '&&giaiDoanNam=' + data.giaiDoanNam + '">' + "Đầu Năm" + '</a>'
                            return str;
                        } else {
                            str = '<a href="/BaoCaoNCVTrungHan/Detail?keHoachNhuCauVonId=' + data.id + '&&loaiKeHoach=' + data.loaiKeHoach + '&&giaiDoanNam=' + data.giaiDoanNam + '">' + "Điều chỉnh" + '</a>'
                            return str;
                        }
                    }
                },
                {
                    className: "text_center",
                    data: { tongNhuCauVonDauNam: "tongNhuCauVonDauNam", loaiKeHoach: "loaiKeHoach", tongNhuCauVonDieuChinh: "tongNhuCauVonDieuChinh" },
                    "render": function (data) {
                        if (data.loaiKeHoach === 'DAU_NAM') {

                            return commaSeparateNumber(data.tongNhuCauVonDauNam);
                        } else {
                            return commaSeparateNumber(data.tongNhuCauVonDieuChinh);
                        }
                    }
                },
                {
                    className: "text_center",
                    data: { trangThaiDauNam: "trangThaiDauNam", loaiKeHoach: "loaiKeHoach", trangThaiDieuChinh: "trangThaiDieuChinh" },
                    "render": function (data) {
                        if (data.loaiKeHoach === 'DAU_NAM') {
                            switch (data.trangThaiDauNam) {
                                case "DANG_SOAN": {
                                    return "Đang soạn";
                                }
                                case "DA_GUI": {
                                    return "Đã gửi";
                                }
                                case "DA_CHOT": {
                                    return "Đã chốt báo cáo";
                                }
                            }
                        } else {
                            switch (data.trangThaiDieuChinh) {
                                case "DANG_SOAN": {
                                    return "Đang soạn";
                                }
                                case "DA_GUI": {
                                    return "Đã gửi";
                                }
                                case "DA_CHOT": {
                                    return "Đã chốt báo cáo";
                                }
                            }

                        }
                    }
                },
                {
                    className: "action_table",
                    data: { id: "id", trangThaiDauNam: "trangThaiDauNam", loaiKeHoach: "loaiKeHoach", trangThaiDieuChinh: "trangThaiDieuChinh", tuNam: "tuNam", giaiDoanNam: "giaiDoanNam" },
                    "render": function (data) {
                        var str = '';
                        str = '<a href="/BaoCaoNCVTrungHan/Edit?keHoachNhuCauVonId=' + data.id + '&&loaiKeHoach=' + data.loaiKeHoach + '&&giaiDoanNam=' + data.giaiDoanNam + '"><button class="btn-action btn-edit" type="button"><i class="fa fa-pencil-square-o"></i></button></a>';
                        if ((data.loaiKeHoach === 'DAU_NAM' && data.trangThaiDauNam === 'DANG_SOAN') || (data.loaiKeHoach === 'DIEU_CHINH' && data.trangThaiDieuChinh === 'DANG_SOAN')) {
                            str += ' <button class="btn-action btn-delete" type="button" _id="' + data.id + '"_loaiKeHoach="' + data.loaiKeHoach + '"><i class="fa fa-trash-o"></i> </button>';
                        }
                      
                        return str;
                    }
                }
            ],
            "fnDrawCallback": function (oSettings) {
                if ($('#BaoCaoTable').DataTable().page.info().pages < 2) {
                    $('.dataTable_footer').hide();
                }
            }
        }));


    }
});