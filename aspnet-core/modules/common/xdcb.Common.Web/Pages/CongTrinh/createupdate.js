var dataDiaDiemThucHien = new Array(0);
function GetDataDiaDiemThucHien(e) {
    ReplaceTextNoData();
    var ds = e.component.getDataSource();
    var filter = e.component.getCombinedFilter();
    ds.store().load({ sort: ds.sort(), filter: filter ? filter : null })
        .done((allData) => {
            dataDiaDiemThucHien = allData;
        });
}

function OnToolbarPreparingDiaDiemThucHien(e) {
    e.toolbarOptions.items.unshift({
        location: "before",
        template: function () {
            return $("<div/>")
                .append(
                    $("<h6 />")
                        .text(consts.diaDiemThucHienTitle)
                );
        }
    });
}

function onEditorPreparingDiaDiemThucHien(e) {
    if ((e.dataField === "ThanhPho" || e.dataField === "DonViHanhChinhId") && e.parentType === "dataRow") {
        e.editorOptions.placeholder = consts.textPlaceholder.selectBox;
    }
}

function onEditingStartDiaDiemThucHien(e) {
    selectingPhuongValue = e.data.DonViHanhChinhId;
}

function onInitNewRowDiaDiemThucHien() {
    selectingPhuongValue = null;
}

function OrderRowDiaDiemThucHienCreateUpdate() {
    var output = "";
    if (orderDiaDiemThucHienCreateUpdate == 0) {
        orderDiaDiemThucHienCreateUpdate = 1;
    } else {
        orderDiaDiemThucHienCreateUpdate++;
    }

    output = orderDiaDiemThucHienCreateUpdate;
    return output;
}

function setThanhPhoValue(rowData, value) {
    rowData.DonViHanhChinhChaId = value;
    rowData.DonViHanhChinhId = null;
}

function getPhuongs(options) {
    var exceptedDataString = null;

    dataDiaDiemThucHien.forEach(function (item) {
        if (item.DonViHanhChinhId != selectingPhuongValue) {
            if (exceptedDataString != null) {
                if (item.DonViHanhChinhId) {
                    exceptedDataString = exceptedDataString + "&ids=" + item.DonViHanhChinhId;
                }
            } else {
                exceptedDataString = "ids=" + item.DonViHanhChinhId;
            }
        }
    });

    return {
        store: new DevExpress.data.CustomStore({
            loadMode: "raw",
            load: function () {
                return $.getJSON("/api/app/donViHanhChinh/donViCapPhuongXaThiTran/excludeIds?" + exceptedDataString);
            }
        }),
        filter: options.data ? [
            "parentId", "=", options.data.DonViHanhChinhChaId
        ] : null,
    };
}

function ReplaceTextNoData() {
    $(".dx-datagrid-nodata").text(messages.no_data);
}


function completed(xhr) {

    if (xhr.responseText === "create") {
        abp.notify.info(messages.SuccessfullyCreate);
        window.location.href = 'Index';
    } else if (xhr.responseText === "update") {
        abp.notify.info(messages.SuccessfullyUpdate);
        window.location.href = 'Index';
    } else if (xhr.responseText === "error_permission") {
        abp.notify.info(messages.Permission);
    } else {
        abp.notify.info(messages.NOtSuccessfullyUpdate);
    }
};

$('#Save').click(function (e) {
    var id = $('#Id').val();
    if (id === undefined) {
        id ='00000000-0000-0000-0000-000000000000'
    }
    if ($('#Save').attr('type') == 'button') {
        if ($('#CongTrinh_TenCongTrinh').val() === "") {
            $('#Save').attr('type', 'submit');
            $('#Save').trigger("click");
            $('#Save').attr('type', 'button');
            return true;
        }
        var e = event;
        e.preventDefault();
        var str = JSON.stringify(dataDiaDiemThucHien);
        $('#diaDiemXayDungStr').val(str);
        e.preventDefault();
        $.ajax({
            url: '/api/app/congTrinh/'+id+'/isMaExist?ma=' + $('#CongTrinh_MaCongTrinh').val(),
            type: 'get',
            contentType: "application/json; charset=utf-8",
            async: false
        }).done(function (data_result) {
            e.preventDefault();
            if (data_result && $('#CongTrinh_MaCongTrinh').val() !== "") {
                e.preventDefault();
                $('#CongTrinh_MaCongTrinh').parent().find('.text-danger').first().html('<span class="text-danger field-validation-error" data-valmsg-for="CongTrinh.TenCongTrinh" data-valmsg-replace="true"><span id="CongTrinh_TenCongTrinh-error" class="">Mã công trình đã được sử dụng trong hệ thống</span></span>');
                return false;
            } else {
                $.ajax({
                    url: '/api/app/congTrinh/' + id+'/isNameExist?name=' + $('#CongTrinh_TenCongTrinh').val(),
                    type: 'get',
                    contentType: "application/json; charset=utf-8",
                    async: false
                }).done(function (data_result) {
                    if (data_result) {
                        e.preventDefault();
                        $('#CongTrinh_TenCongTrinh').parent().find('.text-danger').first().html('<span class="text-danger field-validation-error" data-valmsg-for="CongTrinh.TenCongTrinh" data-valmsg-replace="true"><span id="CongTrinh_TenCongTrinh-error" class="">Tên công trình đã được sử dụng trong hệ thống</span></span>');
                        return false;
                    } else {
                        $('#Save').attr('type', 'submit');
                        $('#Save').trigger("click");
                        return true;
                    }
                });
            }
        });
    }

});

$("#CongTrinh_NST").on('change', function () {
    tongmucdautu();
});
$("#CongTrinh_NSTW").on('change', function () {
    tongmucdautu();
});
$("#CongTrinh_ODA").on('change', function () {
    tongmucdautu();
});

function tongmucdautu() {
    if ($('#CongTrinh_NST').val() !== '') {
        var nst = parseInt($('#CongTrinh_NST').val());
    } else {
        nst = 0;
    }
    if ($('#CongTrinh_NSTW').val() !== '') {
        var nstw = parseInt($('#CongTrinh_NSTW').val());
    } else {
        nstw = 0;
    }
    if ($('#CongTrinh_ODA').val() !== '') {
        var oda = parseInt($('#CongTrinh_ODA').val());
    } else {
        oda = 0;
    }

    $('#CongTrinh_TongMucDauTu').val(nst + nstw+oda);
}





