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
    rowData.Id = value;
    rowData.DonViHanhChinhId = null;
}

function getPhuongs(options) {
    var exceptedDataString = null;

    dataDiaDiemThucHien.forEach(function (item) {
        if (item.DonViHanhChinhId != selectingPhuongValue) {
            if (exceptedDataString != null) {
                exceptedDataString = exceptedDataString + "&ids=" + item.DonViHanhChinhId;
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
            "parentId", "=", options.data.Id
        ] : null,
    };
}
function ReplaceTextNoData() {
    $(".dx-datagrid-nodata").text(messages.no_data);
}







