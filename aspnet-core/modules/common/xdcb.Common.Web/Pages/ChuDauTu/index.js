﻿$(function () {
    var l = abp.localization.getResource('xdcb');
    var createModal = new abp.ModalManager(abp.appPath + 'ChuDauTu/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'ChuDauTu/EditModal');

    var dataTable = $('#ChuDauTuTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: true,
        fixedColumns: true,
        fixedHeader: true,
        bLengthChange: false,
        scrollCollapse: true,
        ajax: abp.libs.datatables.createAjax(xdcb.common.danhMuc.chuDauTus.chuDauTu.getList),
        columnDefs: [
            {
                render: function (data, type, full, meta) {
                    var table = $('#ChuDauTuTable').DataTable();
                    var info = table.page.info();
                    return info.page * table.page.len() + meta.row + 1;
                },
                width: "5%"
            },
            { data: "maSoChuong", width: "10%"},
            { data: "ten", width: "30%" },
            { data: "diaChi", width: "20%" },
            { data: "soDienThoai", width: "10%" },
            { data: "email", width: "15%" },
            {
                className: "action_table",
                data: "id", render: function (data) {
                    return '<button class="btn-action btn-edit" type="button" _type="edit" _id="' + data + '"><i class="fa fa-pencil-square-o"></i></button>' +
                        ' <button class="btn-action btn-delete" type="button" _id="' + data + '"><i class="fa fa-trash-o"></i> </button>'
                },
                width: "10%"
            }
        ],
        "fnDrawCallback": function (oSettings) {
            if ($('#ChuDauTuTable').DataTable().page.info().pages < 2) {
                $('.dataTable_footer').hide();
            }
        }
    }));

    $('#ChuDauTuTable tbody').on('click', 'button', function () {
        var id = $(this).attr("_id");
        if ($(this).attr("_type") === "edit") {
            editModal.open({ id: id });
        } else {
            abp.message.confirm(
                messages.delete,
                messages.delete_title,
                function (isConfirmed) {
                    if (isConfirmed) {
                        xdcb.common.danhMuc.chuDauTus.chuDauTu
                            .delete(id)
                            .then(function () {
                                abp.notify.info(messages.SuccessfullyDeleted);
                                dataTable.ajax.reload();
                            });
                    }
                }
            );
        }
    });

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload(null, false);
    });

    $('#NewChuDauTu').click(function (e) {
        e.preventDefault();
        createModal.open();
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

        dataTable = $('#ChuDauTuTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            searching: false,
            autoWidth: true,
            fixedColumns: true,
            fixedHeader: true,
            bLengthChange: false,
            scrollCollapse: true,
            ajax: abp.libs.datatables.createAjax(xdcb.common.danhMuc.chuDauTus.chuDauTu.search, function () {
                return input;
            }),
            columnDefs: [
                {
                    render: function (data, type, full, meta) {
                        var table = $('#ChuDauTuTable').DataTable();
                        var info = table.page.info();
                        return info.page * table.page.len() + meta.row + 1;
                    },
                    width: "5%"
                },
                { data: "maSoChuong", width: "10%" },
                { data: "ten", width: "30%" },
                { data: "diaChi", width: "20%" },
                { data: "soDienThoai", width: "10%" },
                { data: "email", width: "15%" },
                {
                    className: "action_table",
                    data: "id", render: function (data) {
                        return '<button class="btn-action btn-edit" type="button" _type="edit" _id="' + data + '"><i class="fa fa-pencil-square-o"></i></button>' +
                            ' <button class="btn-action btn-delete" type="button" _id="' + data + '"><i class="fa fa-trash-o"></i> </button>'
                    },
                    width: "10%"
                }
            ],
            "fnDrawCallback": function (oSettings) {
                if ($('#ChuDauTuTable').DataTable().page.info().pages < 2) {
                    $('.dataTable_footer').hide();
                }
            }
        }));
    }
});