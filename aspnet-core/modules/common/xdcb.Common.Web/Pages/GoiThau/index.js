$(function () {
    var l = abp.localization.getResource('xdcb');

    var createModal = new abp.ModalManager(abp.appPath + 'GoiThau/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'GoiThau/EditModal');

    $('#GoiThauTreeList').on('click', 'button', function () {
        var id = $(this).attr("_id");
        if ($(this).attr("_type") === "edit") {
            editModal.open({ id: id });
        } else {
            abp.message.confirm(
                messages.delete_tree,
                messages.delete_title,
                function (isConfirmed) {
                    if (isConfirmed) {
                        xdcb.common.danhMuc.goiThaus.goiThau
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

    $('#NewGoiThau').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
    function Load() {
        abp.ajax({
            url: '/api/app/goiThau/goiThaus',
            type: 'get'
        }).done(function (data) {
            $("#GoiThauTreeList").dxTreeList({
                noDataText: messages.no_data,
                dataSource: data,
                keyExpr: "id",
                parentIdExpr: "goiThauParentId",
                autoExpandAll: true,
                columnAutoWidth: true,
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
                    showInfo: true,
                    infoText: "Hiển thị {2} kết quả"
                },
                columns: [

                    {
                        dataField: "tenGoiThau",
                        caption: "Tên"
                    },
                    {
                        dataField: "id",
                        caption: "",
                        width:"10%",
                        cellTemplate: function (container, options) {
                            var id = options.data.id;
                            if (id) {
                                var div = "<div class='text-center'>" +
                                    "<button class='btn-action btn-edit' type='button' _type='edit' _id='" + id + "'><i class='fa fa-pencil-square-o'></i></button>" +
                                    "<button class='btn-action btn-delete' type='button' _id='" + id + "'><i class='fa fa-trash-o'></i> </button>" +
                                    "</div>";
                                container.append(div);
                            }
                        }
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
        var name = $("#keyword").val();
        abp.ajax({
            url: '/api/app/goiThau/search?name=' + name,
            type: 'get',
            accept:'application/json'
        }).done(function (data) {
            $("#GoiThauTreeList").dxTreeList({
                noDataText: messages.no_data,
                dataSource: data,
                keyExpr: "id",
                parentIdExpr: "goiThauParentId",
                autoExpandAll: true,
                columnAutoWidth: true,
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
                    showInfo: true,
                    infoText: "Hiển thị {2} kết quả"
                },
                columns: [

                    {
                        dataField: "tenGoiThau",
                        caption: "Tên"
                    },
                    {
                        dataField: "id",
                        caption: "",
                        width: "10%",
                        cellTemplate: function (container, options) {
                            var id = options.data.id;
                            if (id) {
                                var div = "<div class='text-center'>" +
                                    "<button class='btn-action btn-edit' type='button' _type='edit' _id='" + id + "'><i class='fa fa-pencil-square-o'></i></button>" +
                                    "<button class='btn-action btn-delete' type='button' _id='" + id + "'><i class='fa fa-trash-o'></i> </button>" +
                                    "</div>";
                                container.append(div);
                            }
                        }
                    }

                ]
            });
        });
    }
});