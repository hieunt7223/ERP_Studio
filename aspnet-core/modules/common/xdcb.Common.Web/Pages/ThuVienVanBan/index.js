$(function () {
    var l = abp.localization.getResource('xdcb');
    var createModal = new abp.ModalManager(abp.appPath + 'ThuVienVanBan/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'ThuVienVanBan/EditModal');

    var dataTable = $('#ThuVienVanBanTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        ajax: abp.libs.datatables.createAjax(xdcb.common.danhMuc.thuVienVanBans.thuVienVanBan.getList),
        columnDefs: [
            {
                render: function (data, type, full, meta) {
                    var table = $('#ThuVienVanBanTable').DataTable();
                    var info = table.page.info();
                    return info.page * table.page.len() + meta.row + 1;
                }
            },
            {
                data: "soKyHieu"
            },
            { data: "tenLoaiVanBan" },
            { data: "trichYeu" },
            { data: "donViBanHanh" },
            { data: "ngayBanHanhFormat" },
            {
                className: "action_table",
                data: "id", render: function (data) {
                    return '<button class="btn-action btn-edit" type="button" _type="edit" _id="' + data + '"><i class="fa fa-pencil-square-o"></i></button>' +
                        ' <button class="btn-action btn-delete" type="button" _id="' + data + '"><i class="fa fa-trash-o"></i> </button>'
                }
            }
        ],
        "fnDrawCallback": function (oSettings) {
            if ($('#ThuVienVanBanTable').DataTable().page.info().pages < 2) {
                $('.dataTable_footer').hide();
            }
        }
    }));

    $('#ThuVienVanBanTable tbody').on('click', 'button', function () {
        var id = $(this).attr("_id");
        if ($(this).attr("_type") === "edit") {
            editModal.open({ id: id });
        } else {
            abp.message.confirm(
                messages.delete,
                messages.delete_title,
                function (isConfirmed) {
                    if (isConfirmed) {
                        xdcb.common.danhMuc.thuVienVanBans.thuVienVanBan
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

    $('#NewThuVienVanBan').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

    $('#Search').click(function () {
        Search();
    });

    function Search() {
        dataTable.destroy();
        var input = {
            keyword: $("#keyword").val(),
            CapBanHanh: $("#CapBanHanh").val(),
            LoaiVanBan: $("#LoaiVanBan").val(),
            DonViBanHanh: $("#DonViBanHanh").val(),
            TuNgay: $("#StartDate").val(),
            DenNgay: $("#EndDate").val(),
            SkipCount: 0,
            MaxResultCount: 10
        }
        console.log(input);
        dataTable = $('#ThuVienVanBanTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            searching: false,
            autoWidth: false,
            scrollCollapse: true,
            ajax: abp.libs.datatables.createAjax(xdcb.common.danhMuc.thuVienVanBans.thuVienVanBan.search, function () {
                return JSON.stringify(input);
            }),

            columnDefs: [
                {
                    render: function (data, type, full, meta) {
                        var table = $('#ThuVienVanBanTable').DataTable();
                        var info = table.page.info();
                        return info.page * table.page.len() + meta.row + 1;
                    }
                },
                {
                    data: "soKyHieu"
                },
                { data: "tenLoaiVanBan" },
                { data: "trichYeu" },
                { data: "donViBanHanh" },
                { data: "ngayBanHanhFormat" },
                {
                    className: "action_table",
                    data: "id", render: function (data) {
                        return '<button class="btn-action btn-edit" type="button" _type="edit" _id="' + data + '"><i class="fa fa-pencil-square-o"></i></button>' +
                            ' <button class="btn-action btn-delete" type="button" _id="' + data + '"><i class="fa fa-trash-o"></i> </button>'
                    }
                }
            ],
            "fnDrawCallback": function (oSettings) {
                if ($('#ThuVienVanBanTable').DataTable().page.info().pages < 2) {
                    $('.dataTable_footer').hide();
                }
            }
        }));
    }
});