$(function () {
    var l = abp.localization.getResource('xdcb');
    var createModal = new abp.ModalManager(abp.appPath + 'NghiQuyet/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'NghiQuyet/EditModal');

    var dataTable = $('#NghiQuyetTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: true,
        fixedColumns: true,
        fixedHeader: true,
        bLengthChange: false,
        scrollCollapse: true,
        fixedColumns : true,
        ajax: abp.libs.datatables.createAjax(xdcb.common.danhMuc.nghiQuyets.nghiQuyet.getList),
        columnDefs: [
            {
                render: function (data, type, full, meta) {
                    var table = $('#NghiQuyetTable').DataTable();
                    var info = table.page.info();
                    return info.page * table.page.len() + meta.row + 1;
                }, width: "5%"
            },
            { data: "soVanBan" },
            {
                data: "ngayBanHanh", render: function (data) {
                    if (data != null) {
                        var d = new Date(data);
                        var day = d.getDate();
                        var month = d.getMonth() + 1;
                        var year = d.getFullYear();
                        if (day < 10) {
                            day = "0" + day;
                        }
                        if (month < 10) {
                            month = "0" + month;
                        }
                        var date = day + "/" + month + "/" + year;

                        return date;
                    } else {
                        return data;
                    }
                    
                },
                width: "15%"
            },
            { data: "trichYeu", width: "60%"},
            {
                data: "isTheoDoi", render: function (data) {
                    var output = "";
                    if (data) {
                        output = "<div class='text-center'><div class='dx-checkbox-container'><span class='dx-checkbox-icon'><i class='fas fa-check'></i></span></div></div>";
                    } else {
                        output = "<div class='text-center'><div class='dx-checkbox-container'><span class='dx-checkbox-icon'></span></div></div>";
                    }
                    return output;
                }
            }
        ],
        "fnDrawCallback": function (oSettings) {
            if ($('#NghiQuyetTable').DataTable().page.info().pages < 2) {
                $('.dataTable_footer').hide();
            }
            $('div.dataTables_paginate')[0].style.display = "block";
            $('div.dataTables_length')[0].style.display = "none";
        }
    }));

    $('#NghiQuyetTable tbody').on('click', 'button', function () {
        var id = $(this).attr("_id");
        if ($(this).attr("_type") === "edit") {
            editModal.open({ id: id });
        }
    });

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload(null, false);
    });

    $('#NewNghiQuyet').click(function (e) {
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

        dataTable = $('#NghiQuyetTable').DataTable(abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            searching: false,
            autoWidth: true,
            fixedColumns: true,
            fixedHeader: true,
            bLengthChange: false,
            scrollCollapse: true,
            fixedColumns: true,
            ajax: abp.libs.datatables.createAjax(xdcb.common.danhMuc.nghiQuyets.nghiQuyet.search, function () {
                return input;
            }),

            columnDefs: [
                {
                    render: function (data, type, full, meta) {
                        var table = $('#NghiQuyetTable').DataTable();
                        var info = table.page.info();
                        return info.page * table.page.len() + meta.row + 1;
                    }, width: "5%"
                },
                { data: "soVanBan" },
                {
                    data: "ngayBanHanh", render: function (data) {
                        if (data != null) {
                            var d = new Date(data);
                            var day = d.getDate();
                            var month = d.getMonth() + 1;
                            var year = d.getFullYear();
                            if (day < 10) {
                                day = "0" + day;
                            }
                            if (month < 10) {
                                month = "0" + month;
                            }
                            var date = day + "/" + month + "/" + year;

                            return date;
                        } else {
                            return data;
                        }

                    },
                    width: "15%", "targets": 1
                },
                { data: "trichYeu" , width: "60%", "targets": 2},
                {
                    data: "isTheoDoi", render: function (data) {
                        var output = "";
                        if (data) {
                            output = "<div class='text-center'><div class='dx-checkbox-container'><span class='dx-checkbox-icon'><i class='fas fa-check'></i></span></div></div>";
                        } else {
                            output = "<div class='text-center'><div class='dx-checkbox-container'><span class='dx-checkbox-icon'></span></div></div>";
                        }
                        return output;
                    }
                }
            ],
            "fnDrawCallback": function (oSettings) {
                if ($('#NghiQuyetTable').DataTable().page.info().pages < 2) {
                    $('.dataTable_footer').hide();
                }
                $('div.dataTables_paginate')[0].style.display = "block";
                $('div.dataTables_length')[0].style.display = "none";
            }
        }));
    }
});