$(function () {
    var l = abp.localization.getResource('xdcb');

    var createModal = new abp.ModalManager(abp.appPath + 'ChuongTrinhMucTieuQuocGia/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'ChuongTrinhMucTieuQuocGia/EditModal');

    $('.chuongtrinhmuctieuquocgia').on('click', 'button', function () {
        var id = $(this).attr("_id");
        if ($(this).attr("_type") === "edit") {
            editModal.open({ id: id });
        } 
    });

    createModal.onResult(function () {
        Load();
    });

    editModal.onResult(function () {
        Load();
    });

    $('#NewChuongTrinhMucTieuQuocGia').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
    function Load() {
        abp.ajax({
            url: '/api/ChuongTrinhMucTieuQuocGia/all',
            type: 'get'
        }).done(function (data) {
            $("#ChuongTrinhMucTieuQuocGia").dxTreeList({
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
                    showInfo: true,
                    infoText: "Hiển thị {2} kết quả"
                },
                columns: [
                    {
                        dataField: "maChuongTrinhMucTieuQuocGia",
                        caption: htmldecode(chuongTrinhMucTieuQuocGia.ma),
                        width: "10%"
                    },
                    {
                        dataField: "tenChuongTrinhMucTieuQuocGia",
                        caption: htmldecode(chuongTrinhMucTieuQuocGia.ten)
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
            url: '/api/app/chuongTrinhMucTieuQuocGia/search?keyword=' + $("#keyword").val(),
            type: 'get'
        }).done(function (data) {
            $("#ChuongTrinhMucTieuQuocGia").dxTreeList({
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
                    showInfo: true,
                    infoText: "Hiển thị {2} kết quả"
                },
                columns: [
                     {
                        dataField: "maChuongTrinhMucTieuQuocGia",
                        caption: htmldecode(chuongTrinhMucTieuQuocGia.ma),
                        width: "10%"
                    },
                    {
                        dataField: "tenChuongTrinhMucTieuQuocGia",
                        caption: htmldecode(chuongTrinhMucTieuQuocGia.ten)
                    },
                ]
            });
        });

    }
});