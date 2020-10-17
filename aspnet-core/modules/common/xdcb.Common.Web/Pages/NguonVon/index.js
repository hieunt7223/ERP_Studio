$(function () {
    var l = abp.localization.getResource('xdcb');

    var createModal = new abp.ModalManager(abp.appPath + 'NguonVon/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'NguonVon/EditModal');

    $('.nguonvon').on('click', 'button', function () {
        var id = $(this).attr("_id");
        if ($(this).attr("_type") === "edit") {
            editModal.open({ id: id });
        } else {
            abp.message.confirm(
                messages.delete_tree,
                messages.delete_title,
                function (isConfirmed) {
                    if (isConfirmed) {
                        xdcb.common.danhMuc.nguonVons.nguonVon
                            .delete(id)
                            .then(function () {
                                abp.notify.info(messages.SuccessfullyDeleted);
                                Load();
                            });
                    }
                }
            );
        }
    });

    createModal.onResult(function () {
        Load();
    });

    editModal.onResult(function () {
        Load();
    });

    $('#NewNguonVon').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
    function Load() {
        abp.ajax({
            url: '/api/NguonVon/all',
            type: 'get'
        }).done(function (data) {
            $("#NguonVon").dxTreeList({
                noDataText: messages.no_data,
                dataSource: data,
                keyExpr: "id",
                parentIdExpr: "parentId",
                autoExpandAll: true,
                columnAutoWidth: false,
                showBorders: true,
                scrolling: {
                    mode: "standard"
                },
                paging: {
                    enabled: true,
                    pageSize: 10
                },
                pager: {
                    showNavigationButtons: true,
                    infoText: "Hiển thị {2} kết quả",
                    showInfo: true
                },
                columns: [
                    {
                        dataField: "stt",
                        caption: "#",
                        width: "15%"
                    },
                    {
                        dataField: "maNguonVon",
                        caption: "Mã nguồn vốn",
                        width: "15%"
                    },
                    {
                        dataField: "tenNguonVon",
                        caption: "Tên nguồn vốn"
                    }
                ]
            });
        });
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

    function Search() {
        abp.ajax({
            url: '/api/app/nguonVon/search?keyword=' + $("#keyword").val(),
            type: 'get'
        }).done(function (data) {
            $("#NguonVon").dxTreeList({
                noDataText: messages.no_data,
                dataSource: data,
                keyExpr: "id",
                parentIdExpr: "parentId",
                autoExpandAll: true,
                columnAutoWidth: false,
                showBorders: true,
                scrolling: {
                    mode: "standard"
                },
                paging: {
                    enabled: true,
                    pageSize: 10
                },
                pager: {
                    showNavigationButtons: true,
                    infoText: "Hiển thị {2} kết quả",
                    showInfo: true
                },
                columns: [
                    {
                        dataField: "stt",
                        caption: "#",
                        width: "15%"
                    },
                    {
                        dataField: "maNguonVon",
                        caption: "Mã nguồn vốn",
                        width: "15%"
                    },
                    {
                        dataField: "tenNguonVon",
                        caption: "Tên nguồn vốn"
                    }
                ]
            });
        });
    }
});