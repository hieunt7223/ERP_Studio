$(function () {
    var l = abp.localization.getResource('xdcb');

    var createModal = new abp.ModalManager(abp.appPath + 'HangMucCongTrinh/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'HangMucCongTrinh/EditModal');

    var dataTable = $('#HangMucCongTrinhTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(xdcb.common.danhMuc.hangMucCongTrinhs.hangMucCongTrinh.getList),
        columnDefs: [

            { data: "maHangMuc" },
            { data: "tenHangMuc" },
            { data: "moTa" },
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                confirmMessage: function (data) {
                                    return l('Xóa dữ liệu này', data.record.name);
                                },
                                action: function (data) {
                                    xdcb.common.danhMuc.hangMucCongTrinhs.hangMucCongTrinh
                                        .delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },

        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewHangMucCongTrinh').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});