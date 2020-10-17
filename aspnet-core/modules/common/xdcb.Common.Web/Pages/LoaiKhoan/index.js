$(function () {
    var l = abp.localization.getResource('xdcb');

    var createModal = new abp.ModalManager(abp.appPath + 'LoaiKhoan/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'LoaiKhoan/EditModal');

    $('.loaikhoan').on('click', 'button', function () {
        var id = $(this).attr("_id");
        if ($(this).attr("_type") === "edit") {
            detailModal.open({ id: id });
        }
    });

    createModal.onResult(function () {
        Load();
    });

    editModal.onResult(function () {
        Load();
    });

    $('#NewLoaiKhoan').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
    function Load() {
        abp.ajax({
            url: '/api/LoaiKhoan/all',
            type: 'get'
        }).done(function (data) {
            $("#LoaiKhoan").dxTreeList({
                noDataText: messages.no_data,
                dataSource: data,
                keyExpr: "id",
                parentIdExpr: "loaiKhoanChaID",
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
                columns: [{
                    dataField: "stt",
                    caption: htmldecode(title.stt),
                    width: "10%"
                }, {
                        dataField: "tenLoaiLoaiKhoan",
                        caption: htmldecode(title.loaiLoaiKhoan)
                },
                {
                    dataField: "maSo",
                    caption: htmldecode(title.maSo)
                },
                {
                    dataField: "tenLoaiKhoan",
                    caption: htmldecode(title.tenGoi)
                    }, {
                    dataField: "ghiChu",
                    caption: htmldecode(title.ghiChu)
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
        var input = {
            'keyword': $("#keyword").val(),
            'SkipCount': 0,
            'MaxResultCount': 10
        }

        abp.ajax({
            url: '/api/app/loaiKhoan/search',
            data: JSON.stringify(input)
        }).done(function (data) {
            $("#LoaiKhoan").dxTreeList({
                noDataText: messages.no_data,
                dataSource: data,
                keyExpr: "id",
                parentIdExpr: "loaiKhoanChaID",
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
                columns: [{
                    dataField: "stt",
                    caption: htmldecode(title.stt),
                    width: "10%"
                }, {
                    dataField: "tenLoaiLoaiKhoan",
                    caption: htmldecode(title.loaiLoaiKhoan)
                },
                {
                    dataField: "maSo",
                    caption: htmldecode(title.maSo)
                },
                {
                    dataField: "tenLoaiKhoan",
                    caption: htmldecode(title.tenGoi)
                }, {
                    dataField: "ghiChu",
                    caption: htmldecode(title.ghiChu)
                }
                ]
            });
        });
    }
});