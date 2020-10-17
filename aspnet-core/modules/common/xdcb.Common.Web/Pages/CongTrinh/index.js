$(function () {
    var l = abp.localization.getResource('xdcb');

    var createModal = new abp.ModalManager(abp.appPath + 'CongTrinh/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'CongTrinh/EditModal');

    var dataTable = $('#CongTrinhTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: true,
        fixedColumns: true,
        fixedHeader: true,
        bLengthChange: false,
        scrollCollapse: true,

        ajax: abp.libs.datatables.createAjax(xdcb.common.danhMuc.congTrinhs.congTrinh.search, function () {
            return {
                'keyword': '',
                'chuDauTu': chuDauTuId,
                'SkipCount': 0,
                'MaxResultCount': 10
            };
        })
        ,
        columnDefs: [
            {
                render: function (data, type, full, meta) {
                    var table = $('#CongTrinhTable').DataTable();
                    var info = table.page.info();
                    return info.page * table.page.len() + meta.row + 1;
                }, width: "5%"
            },
            { data: "tenCongTrinh" },
            {
                data: "tenChuDauTu", visible: chuDauTuId === ""
            },
            { data: "tenNhomCongTrinh" },
            { data: "maSoDuAn" },
            { data: "maChuong" },
            { data: "maLoaiKhoan" },
            { data: "soQuyetDinhDauTu" },
            { data: "tongMucDauTu" },
            {

                data: { id: "id", creatorId: "creatorId" },
                "render": function (data) {
                    
                    var str = '<a class="btn_taga" href="/CongTrinh/DetailModal?congTrinhId=' + data.id + '"><button class="btn-action btn-detail" type="button"><i class="fa fa-eye"></i></button></a>';
                    //$.ajax({
                    //    url: '/api/app/hoSoCongTrinh/isHoSoCongTrinhByCongTrinhId/{' + data.id + '}',
                    //    type: 'get',
                    //    contentType: "application/json; charset=utf-8",
                    //    async: false
                    //}).done(function (data_result) {
                       
                    //    if (!chuDauTuId) {
                    //        str += '<a href="/CongTrinh/EditModal?congTrinhId=' + data.id + '"><button class="btn-action btn-edit" type="button"><i class="fa fa-pencil-square-o"></i></button></a>'
                    //    } else if (chuDauTuId && data.creatorId === userId && !data_result) {
                    //        str += '<a href="/CongTrinh/EditModal?congTrinhId=' + data.id + '"><button class="btn-action btn-edit" type="button"><i class="fa fa-pencil-square-o"></i></button></a>'
                    //    }
                    //});

                   
                    //str += ' <button class="btn-action btn-delete" type="button" _id="' + data.id + '"><i class="fa fa-trash-o"></i> </button>';
                    return str;

                }, width: "5%"
            }
        ],
        "fnDrawCallback": function (oSettings) {
            if ($('#CongTrinhTable').DataTable().page.info().pages < 2) {
                $('.dataTable_footer').hide();
            }

        }
    }));

    $('#CongTrinhTable tbody').on('click', '.btn-delete', function () {
        var id = $(this).attr("_id");

        abp.message.confirm(
            messages.delete,
            messages.delete_title,
            function (isConfirmed) {
                if (isConfirmed) {
                    xdcb.common.danhMuc.congTrinhs.congTrinh
                        .deleleDiaDiemXayDungByCongTrinhId(id)
                        .then(function () {
                            xdcb.common.danhMuc.congTrinhs.congTrinh
                                .delete(id)
                                .then(function () {
                                    abp.notify.info(messages.SuccessfullyDeleted);
                                    dataTable.ajax.reload();
                                });
                        });

                }
            }
        );

    });


    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload(null, false);
    });

    $('#NewCongTrinh').click(function (e) {
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
        dataTable = $('#CongTrinhTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            searching: false,
            autoWidth: true,
            fixedColumns: true,
            fixedHeader: true,
            bLengthChange: false,
            scrollCollapse: true,
            ajax: abp.libs.datatables.createAjax(xdcb.common.danhMuc.congTrinhs.congTrinh.search, function () {
                return {
                    'keyword': $("#keyword").val(),
                    'chuDauTu': $("#ChuDauTu").val(),
                    'nhomCongTrinh': $("#NhomCongTrinh").val(),
                    'SkipCount': 0,
                    'MaxResultCount': 10
                };
            }),
            columnDefs: [
                {
                    render: function (data, type, full, meta) {
                        var table = $('#CongTrinhTable').DataTable();
                        var info = table.page.info();
                        return info.page * table.page.len() + meta.row + 1;
                    }, width: "5%"
                },
                { data: "tenCongTrinh" },
                { data: "tenChuDauTu", visible: chuDauTuId === "" },
                { data: "tenNhomCongTrinh" },
                { data: "maSoDuAn" },
                { data: "maChuong" },
                { data: "maLoaiKhoan" },
                { data: "soQuyetDinhDauTu" },
                { data: "tongMucDauTu" },
                {
                    data: { id: "id", creatorId: "creatorId" },
                    "render": function (data) {

                        var str = '<a class="btn_taga" href="/CongTrinh/DetailModal?congTrinhId=' + data.id + '"><button class="btn-action btn-detail" type="button"><i class="fa fa-eye"></i></button></a>';
                        //$.ajax({
                        //    url: '/api/app/hoSoCongTrinh/isHoSoCongTrinhByCongTrinhId/{' + data.id + '}',
                        //    type: 'get',
                        //    contentType: "application/json; charset=utf-8",
                        //    async: false
                        //}).done(function (data_result) {

                        //    if (!chuDauTuId) {
                        //        str += '<a href="/CongTrinh/EditModal?congTrinhId=' + data.id + '"><button class="btn-action btn-edit" type="button"><i class="fa fa-pencil-square-o"></i></button></a>'
                        //    } else if (chuDauTuId && data.creatorId === userId && !data_result) {
                        //        str += '<a href="/CongTrinh/EditModal?congTrinhId=' + data.id + '"><button class="btn-action btn-edit" type="button"><i class="fa fa-pencil-square-o"></i></button></a>'
                        //    }
                        //});


                        //str += ' <button class="btn-action btn-delete" type="button" _id="' + data.id + '"><i class="fa fa-trash-o"></i> </button>';
                        return str;

                    }, width: "5%"
                }
            ],
            "fnDrawCallback": function (oSettings) {
                if ($('#CongTrinhTable').DataTable().page.info().pages < 2) {
                    $('.dataTable_footer').hide();
                }
            }
        }));


    }
});