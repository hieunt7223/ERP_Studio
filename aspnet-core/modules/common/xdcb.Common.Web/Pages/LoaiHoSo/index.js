$(function () {
    var l = abp.localization.getResource('xdcb');

    var dataTable = $('#LoaiHoSoTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: false,
        ajax: abp.libs.datatables.createAjax(xdcb.common.danhMuc.loaiHoSos.loaiHoSo.getList),
        columnDefs: [
            {
                width: "5%",
                render: function (data, type, full, meta) {
                    var table = $('#LoaiHoSoTable').DataTable();
                    var info = table.page.info();
                    return info.page * table.page.len() + meta.row + 1;
                },
            },
            { width: "50%", data: "tenLoaiHoSo"},
            {
                width: "35%",
                data: "isTrangThai", render: function (data) {
                    if (data) {
                        return "Áp dụng";
                    } else {
                        return "Không áp dụng";
                    }
                },
            },
            {
                width: "10%",
                data: "id", render: function (data) {
                    return "<a class='btn_taga' href='/LoaiHoSo/DetailModal?loaiHoSoId=" + data + "'><button class='btn-action btn-detail' type='button'><i class='fa fa-eye'></i></button></a>" +
                        "<a href='/LoaiHoSo/EditModal?loaiHoSoId=" + data + "'><button class='btn-action btn-edit' type='button' _type='edit'><i class='fa fa-pencil-square-o'></i></button></a>"
                },
            }
        ],
        "fnDrawCallback": function (oSettings) {
            if ($('#LoaiHoSoTable').DataTable().page.info().pages < 2) {
                $('.dataTable_footer').hide();
            }
        }
    }));

    $('#LoaiHoSoTable tbody').on('click', 'button.btn-delete', function () {
        var id = $(this).attr("_id");
        abp.message.confirm(
            messages.delete,
            messages.delete_title,
            function (isConfirmed) {
                if (isConfirmed) {
                    xdcb.common.danhMuc.loaiHoSos.loaiHoSo
                        .delete(id)
                        .then(function () {
                            abp.notify.info(messages.SuccessfullyDeleted);
                            dataTable.ajax.reload();
                        });
                }
            }
        );
    });

    $('#xuatExcel').click(function (e) {
        e.preventDefault();
        var url = "/api/app/loaiHoSo/export";
        window.location.href = url;
    });

    $('#Search').click(function () {
        Search();
    });

    $('#keyword').keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            Search();
        }
    });

    function Search() {
        dataTable.destroy();
        var input = {
            'keyword': $("#keyword").val(),
            'SkipCount': 0,
            'MaxResultCount': 10
        }

        dataTable = $('#LoaiHoSoTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            searching: false,
            autoWidth: false,
            scrollCollapse: true,
            ajax: abp.libs.datatables.createAjax(xdcb.common.danhMuc.loaiHoSos.loaiHoSo.search, function () {
                return input;
            }),

            columnDefs: [
                {
                    width: "5%",
                    render: function (data, type, full, meta) {
                        var table = $('#LoaiHoSoTable').DataTable();
                        var info = table.page.info();
                        return info.page * table.page.len() + meta.row + 1;
                    }
                },
                { width: "50%",data: "tenLoaiHoSo" },
                {
                    width: "35%",
                    data: "isTrangThai", render: function (data) {
                        if (data) {
                            return "Áp dụng";
                        } else {
                            return "Không áp dụng";
                        }
                    }
                },
                {
                    width: "10%",
                    data: "id", render: function (data) {
                        return "<a class='btn_taga' href='/LoaiHoSo/DetailModal?loaiHoSoId=" + data + "'><button class='btn-action btn-detail' type='button'><i class='fa fa-eye'></i></button></a>" +
                            "<a href='/LoaiHoSo/EditModal?loaiHoSoId=" + data + "'><button class='btn-action btn-edit' type='button' _type='edit'><i class='fa fa-pencil-square-o'></i></button></a>"
                    }
                }
            ],
            "fnDrawCallback": function (oSettings) {
                if ($('#LoaiHoSoTable').DataTable().page.info().pages < 2) {
                    $('.dataTable_footer').hide();
                }
            }
        }));
    }
});