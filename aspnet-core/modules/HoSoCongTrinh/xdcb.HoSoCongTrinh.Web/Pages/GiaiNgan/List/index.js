$(function () {
    if (chuDauTuId === '') {
        chuDauTuId = '00000000-0000-0000-0000-000000000000';
    }
    var l = abp.localization.getResource('xdcb');

    var dataTable = $('#GiaiNganTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        ajax:
            abp.libs.datatables.createAjax(function () {
                return abp.ajax($.extend(true, {
                    url: '/api/app/giaiNgan/search?ChuDauTuId=' + chuDauTuId + "&&SkipCount=" + $('#GiaiNganTable').DataTable().page.info().page * $('#GiaiNganTable').DataTable().page.len() + "&&MaxResultCount=" + $('#GiaiNganTable').DataTable().page.len(),
                    type: "get"
                }));

            })
        ,
        columnDefs: [
            {
                className: "text_center",
                render: function (data, type, full, meta) {
                    var table = $('#GiaiNganTable').DataTable();
                    var info = table.page.info();
                    return info.page * table.page.len() + meta.row + 1;
                }
            },
            {
                className: "text_center",
                data: { id: "id", nam: "nam" }, "render": function (data) {

                    let str = '<a href="/GiaiNgan/Detail?giaiNganId=' + data.id +'">' + data.nam + '</a>'
                    return str;

                }
            },
            {
                className: "text_center",
                data: "keHoachGiaiNgan" 
                
            },
            {
                className: "text_center",
                data: { tongGiaiNgan: "tongGiaiNgan" },
                "render": function (data) {
                    return commaSeparateNumber(data.tongGiaiNgan)
                }
            },
            {
                className: "text_center",
                data: { trangThai: "trangThai" },
                "render": function (data) {
                    switch (data.trangThai) {
                        case "DANG_SOAN": {
                            return "Đang soạn";
                        }
                        case "DA_GUI": {
                            return "Đã gửi";
                        }
                    }

                }
            },
            {
                className: "action_table",
                data: { id: "id", trangThai: "trangThai", nam: "nam" },
                "render": function (data) {
                    var str = '';
                    str = '<a href="/GiaiNgan/Edit?giaiNganId=' + data.id +  '"><button class="btn-action btn-edit" type="button"><i class="fa fa-pencil-square-o"></i></button></a>';
                    if (data.trangThai === 'DANG_SOAN') {
                        str += ' <button class="btn-action btn-delete" type="button" _id="' + data.id + '"><i class="fa fa-trash-o"></i> </button>';
                    }

                    return str;
                }
            }
        ],
        "fnDrawCallback": function (oSettings) {
            if ($('#GiaiNganTable').DataTable().page.info().pages < 2) {
                $('.dataTable_footer').hide();
            }

        }
    }));

    $('#GiaiNganTable tbody').on('click', '.btn-delete', function () {
        var id = $(this).attr("_id");
        abp.message.confirm(
            messages.delete,
            messages.delete_title,
            function (isConfirmed) {
                if (isConfirmed) {
                    abp.ajax({
                        url: '/api/app/giaiNgan/'+id+'/giaiNganChiTiet',
                        type: 'delete',
                        async: false
                    }).done(function () {
                        abp.ajax({
                            url: '/api/app/giaiNgan/' + id,
                            type: 'delete',
                            async: false
                        }).done(function () {
                            abp.notify.info(messages.SuccessfullyDeleted);
                            dataTable.ajax.reload();
                        })
                    })
                }
            }
        );
    });

    $('#Search').click(function () {
        Search();
    });

    function Search() {
        dataTable.destroy();
        var dataTable = $('#GiaiNganTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            searching: false,
            autoWidth: false,
            scrollCollapse: true,
            ajax:
                abp.libs.datatables.createAjax(function () {
                    return abp.ajax($.extend(true, {
                        url: '/api/app/giaiNgan/search?ChuDauTuId=' + chuDauTuId + "&&SkipCount=" + $('#GiaiNganTable').DataTable().page.info().page * $('#GiaiNganTable').DataTable().page.len() + "&&MaxResultCount=" + $('#GiaiNganTable').DataTable().page.len(),
                        type: "get"
                    }));

                })
            ,
            columnDefs: [
                {
                    className: "text_center",
                    render: function (data, type, full, meta) {
                        var table = $('#GiaiNganTable').DataTable();
                        var info = table.page.info();
                        return info.page * table.page.len() + meta.row + 1;
                    }
                },
                {
                    className: "text_center",
                    data: { id: "id", nam: "nam" }, "render": function (data) {

                        let str = '<a href="/GiaiNgan/Detail?giaiNganId=' + data.id + '">' + data.nam + '</a>'
                        return str;

                    }
                },
                {
                    className: "text_center",
                    data: "keHoachGiaiNgan"

                },
                {
                    className: "text_center",
                    data: { tongGiaiNgan: "tongGiaiNgan" },
                    "render": function (data) {
                        return commaSeparateNumber(data.tongGiaiNgan)
                    }
                },
                {
                    className: "text_center",
                    data: { trangThai: "trangThai" },
                    "render": function (data) {
                        switch (data.trangThai) {
                            case "DANG_SOAN": {
                                return "Đang soạn";
                            }
                            case "DA_GUI": {
                                return "Đã gửi";
                            }
                        }

                    }
                },
                {
                    className: "action_table",
                    data: { id: "id", trangThai: "trangThai", nam: "nam" },
                    "render": function (data) {
                        var str = '';
                        str = '<a href="/GiaiNgan/Edit?giaiNganId=' + data.id + '"><button class="btn-action btn-edit" type="button"><i class="fa fa-pencil-square-o"></i></button></a>';
                        if (data.trangThai === 'DANG_SOAN') {
                            str += ' <button class="btn-action btn-delete" type="button" _id="' + data.id + '"><i class="fa fa-trash-o"></i> </button>';
                        }

                        return str;
                    }
                }
            ],
            "fnDrawCallback": function (oSettings) {
                if ($('#GiaiNganTable').DataTable().page.info().pages < 2) {
                    $('.dataTable_footer').hide();
                }

            }
        }));
    }
});