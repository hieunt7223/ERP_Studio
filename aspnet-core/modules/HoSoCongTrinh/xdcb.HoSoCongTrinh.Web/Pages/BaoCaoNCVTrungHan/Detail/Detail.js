var congTrinhNganSachTinhs = new Array(0);
var congTrinhNganSachTWs = new Array(0);
var congTrinhNganSachODAs = new Array(0);
var baoCaoHangNamDauNams = new Array(0);
var nhuCauVonChiTietDauNam = new Array(0);
var year;
var loaikehoach;
var idBaoCao;
var status_DauNam;
var _tabAdd;

//Load khi chờ xuất file excel
var loadPanel = $(".loadpanel").dxLoadPanel({
    shadingColor: "rgba(0,0,0,0.4)",
    position: { of: "#container-load-page" },
    visible: false,
    message: messages.loading_panel,
    showIndicator: true,
    showPane: true,
    shading: true,
    closeOnOutsideClick: false,
}).dxLoadPanel("instance");

//Ngân sách tỉnh
$(function () {

    loaikehoach = loaiKeHoach;
    abp.ajax({
        url: '/api/app/nhuCauKeHoachVon/' + kehoachNhuCauVonId,
        type: 'get',
        async: false
    }).done(function (result_data) {
        status_DauNam = result_data.trangThaiDauNam;
        year = result_data.tuNam;
    });
    idBaoCao = kehoachNhuCauVonId;
    getNSTEdit();
    getNSTWEdit();
    getNSODAEdit();
    if (loaikehoach === "DIEU_CHINH") {

        LoadNSTDieuChinh(congTrinhNganSachTinhs);
        LoadNSTWDieuChinh(congTrinhNganSachTWs);
        LoadNSODADieuChinh(congTrinhNganSachODAs);
        $('#TW').removeClass('active');
        $('#ODA').removeClass('active');
    } else {
        LoadNST(congTrinhNganSachTinhs);
        LoadTW(congTrinhNganSachTWs);
        LoadNSODA(congTrinhNganSachODAs);
        $('#TW').removeClass('active');
        $('#ODA').removeClass('active');
    }
});
//Get dữ liệu--------------------------------------------------------------
function getNSTEdit() {
    abp.ajax({
        url: '/api/app/nhuCauKeHoachVon/' + kehoachNhuCauVonId +'/nhuCauKeHoachVonChiTiet',
        type: 'get',
        async: false
    }).done(function (result_data) {
        nhuCauVonChiTietDauNam = result_data;
    });
    abp.ajax({
        url: '/api/app/congTrinh/byChuDauTuId/' + chuDauTuId,
        type: 'get',
        async: false
    }).done(function (data) {
        if (loaikehoach === "DIEU_CHINH") {

            for (let i = 0; i < nhuCauVonChiTietDauNam.length; i++) {
                for (let j = 0; j < data.length; j++)
                    if (nhuCauVonChiTietDauNam[i].congTrinhID === data[j].id) {
                        congTrinhNganSachTinhs.push(data[j]);
                        congTrinhNganSachTinhs[i].nST = data[j].nst;
                        congTrinhNganSachTinhs[i].ghiChu_dieuchinh = nhuCauVonChiTietDauNam[i].ghiChuDieuChinhNST;
                        congTrinhNganSachTinhs[i].nST_LuyKeKhoiLuong = nhuCauVonChiTietDauNam[i].luyKeKhoiLuongNamTruocNST;
                        congTrinhNganSachTinhs[i].nST_LuyKeVon = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocNST;
                        congTrinhNganSachTinhs[i].ghiChu = nhuCauVonChiTietDauNam[i].ghiChuDauNamNST;
                        congTrinhNganSachTinhs[i].nST_KeHoachVonDaGiao = 0;
                        congTrinhNganSachTinhs[i].nST_Tang = nhuCauVonChiTietDauNam[i].dieuChinhTangNST;
                        congTrinhNganSachTinhs[i].nST_Giam = nhuCauVonChiTietDauNam[i].dieuChinhGiamNST;
                        congTrinhNganSachTinhs[i].nST_von_dieuchinh = congTrinhNganSachTinhs[i].nST_KeHoachVonDaGiao + congTrinhNganSachTinhs[i].nST_Tang - congTrinhNganSachTinhs[i].nST_Giam;
                        congTrinhNganSachTinhs[i].idChiTiet = nhuCauVonChiTietDauNam[i].id;
                    }
            }

        } else {
            for (let i = 0; i < nhuCauVonChiTietDauNam.length; i++) {
                for (let j = 0; j < data.length; j++)
                    if (nhuCauVonChiTietDauNam[i].congTrinhID === data[j].id) {
                        congTrinhNganSachTinhs.push(data[j]);
                        congTrinhNganSachTinhs[i].nST = data[j].nst;
                        congTrinhNganSachTinhs[i].nST_LuyKeKhoiLuong = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocNST;
                        congTrinhNganSachTinhs[i].nST_LuyKeVon = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocNST;
                        congTrinhNganSachTinhs[i].ghiChu = nhuCauVonChiTietDauNam[i].ghiChuDauNamNST;
                        congTrinhNganSachTinhs[i].nhuCauVon = nhuCauVonChiTietDauNam[i].nhuCauVonDauNamNST;
                        congTrinhNganSachTinhs[i].idChiTiet = nhuCauVonChiTietDauNam[i].id;
                    }
            }
        }
    });
}
function getNSTWEdit() {

    abp.ajax({
        url: '/api/app/congTrinh/byChuDauTuId/' + chuDauTuId,
        type: 'get',
        async: false
    }).done(function (data) {
        if (loaikehoach === "DIEU_CHINH") {

            for (let i = 0; i < nhuCauVonChiTietDauNam.length; i++) {
                for (let j = 0; j < data.length; j++)
                    if (nhuCauVonChiTietDauNam[i].congTrinhID === data[j].id) {
                        congTrinhNganSachTWs.push(data[j]);
                        congTrinhNganSachTWs[i].TW = data[j].nstw;
                        congTrinhNganSachTWs[i].ghiChuTW_dieuchinh = nhuCauVonChiTietDauNam[i].ghiChuDieuChinhNSTW;
                        congTrinhNganSachTWs[i].TW_LuyKeKhoiLuong = nhuCauVonChiTietDauNam[i].luyKeKhoiLuongNamTruocNSTW;
                        congTrinhNganSachTWs[i].TW_LuyKeVon = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocNSTW;
                        congTrinhNganSachTWs[i].ghiChuTW = nhuCauVonChiTietDauNam[i].ghiChuDauNamNSTW;
                        congTrinhNganSachTWs[i].nSTW_KeHoachVonDaGiao = 0;
                        congTrinhNganSachTWs[i].nSTW_Tang = nhuCauVonChiTietDauNam[i].dieuChinhTangNSTW;
                        congTrinhNganSachTWs[i].nSTW_Giam = nhuCauVonChiTietDauNam[i].dieuChinhGiamNSTW;
                        congTrinhNganSachTWs[i].nSTW_von_dieuchinh = congTrinhNganSachTWs[i].nSTW_KeHoachVonDaGiao + congTrinhNganSachTWs[i].nSTW_Tang - congTrinhNganSachTWs[i].nSTW_Giam;
                    }
            }

        } else {
            for (let i = 0; i < nhuCauVonChiTietDauNam.length; i++) {
                for (let j = 0; j < data.length; j++)
                    if (nhuCauVonChiTietDauNam[i].congTrinhID === data[j].id) {
                        congTrinhNganSachTWs.push(data[j]);
                        congTrinhNganSachTWs[i].TW = data[j].nstw;
                        congTrinhNganSachTWs[i].TW_LuyKeKhoiLuong = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocNSTW;
                        congTrinhNganSachTWs[i].TW_LuyKeVon = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocNSTW;
                        congTrinhNganSachTWs[i].ghiChuTW = nhuCauVonChiTietDauNam[i].ghiChuDauNamNSTW;
                        congTrinhNganSachTWs[i].nhuCauVonTW = nhuCauVonChiTietDauNam[i].nhuCauVonDauNamNSTW;
                    }
            }
        }
    });
}
function getNSODAEdit() {
    abp.ajax({
        url: '/api/app/congTrinh/byChuDauTuId/' + chuDauTuId,
        type: 'get',
        async: false
    }).done(function (data) {
        if (loaikehoach === "DIEU_CHINH") {

            for (let i = 0; i < nhuCauVonChiTietDauNam.length; i++) {
                for (let j = 0; j < data.length; j++)
                    if (nhuCauVonChiTietDauNam[i].congTrinhID === data[j].id) {
                        congTrinhNganSachODAs.push(data[j]);
                        congTrinhNganSachODAs[i].nSTODA = data[j].oda;
                        congTrinhNganSachODAs[i].ghiChuODA_dieuchinh = nhuCauVonChiTietDauNam[i].ghiChuDieuChinhODA;
                        congTrinhNganSachODAs[i].nSODA_LuyKeKhoiLuong = nhuCauVonChiTietDauNam[i].luyKeKhoiLuongNamTruocODA;
                        congTrinhNganSachODAs[i].nSODA_LuyKeVon = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocODA;
                        congTrinhNganSachODAs[i].ghiChuODA = nhuCauVonChiTietDauNam[i].ghiChuDauNamODA;
                        congTrinhNganSachODAs[i].nSODA_KeHoachVonDaGiao = 0;
                        congTrinhNganSachODAs[i].nSODA_Tang = nhuCauVonChiTietDauNam[i].dieuChinhTangODA;
                        congTrinhNganSachODAs[i].nSODA_Giam = nhuCauVonChiTietDauNam[i].dieuChinhGiamODA;
                        congTrinhNganSachODAs[i].ghiChuODA_dieuchinh = congTrinhNganSachODAs[i].nSODA_KeHoachVonDaGiao + congTrinhNganSachODAs[i].nSODA_Tang - congTrinhNganSachODAs[i].nSODA_Giam;
                    }
            }

        } else {
            for (let i = 0; i < nhuCauVonChiTietDauNam.length; i++) {
                for (let j = 0; j < data.length; j++)
                    if (nhuCauVonChiTietDauNam[i].congTrinhID === data[j].id) {
                        congTrinhNganSachODAs.push(data[j]);
                        congTrinhNganSachODAs[i].nSTODA = data[j].oda;
                        congTrinhNganSachODAs[i].nSODA_LuyKeKhoiLuong = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocODA;
                        congTrinhNganSachODAs[i].nSODA_LuyKeVon = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocODA;
                        congTrinhNganSachODAs[i].ghiChuODA = nhuCauVonChiTietDauNam[i].ghiChuDauNamODA;
                        congTrinhNganSachODAs[i].nhuCauVonODA = nhuCauVonChiTietDauNam[i].nhuCauVonDauNamODA;
                    }
            }
        }
    });
}
//-------------------------------------------------------------------------

//Load dữ liệu-------------------------------------------------------------
//Load dữ liệu đầu năm
function LoadNST(data) {

    $("#gridNST").dxDataGrid({
        noDataText: messages.no_data,
        dataSource: data,
        columnAutoWidth: true,
        allowColumnReordering: true,
        showBorders: true,
        scrolling: {
            columnRenderingMode: "virtual"
        },
        paging: {
            enabled: false
        },
        columns: [
            {
                caption: "#",
                dataField: "STT",
                alignment: "center",
                allowEditing: false,
                cellTemplate: orderRowItemNo
            },
            {
                caption: "Thông tin chung của công trình",
                alignment: "center",
                columns: [{
                    caption: "Danh sách công Trinh",
                    dataField: "tenCongTrinh",
                    format: "string"
                }, {
                    caption: "Mã số dự án",
                    dataField: "maSoDuAn",
                    format: "string"
                }, {
                    caption: "Mã số chương",
                    dataField: "maChuong",
                    format: "string"
                }, {
                    caption: "Mã loại khoản",
                    dataField: "maLoaiKhoan",
                    format: "string"
                },
                {
                    caption: "Quyết định đầu tư",
                    alignment: "center",
                    columns: [{
                        caption: "Số QĐ, Ngày tháng năm",
                        dataField: "soQuyetDinhDauTu",
                        alignment: "center"
                    },
                    {
                        caption: "Tổng mức đầu tư",
                        alignment: "center",
                        columns: [{
                            caption: "Tổng số",
                            dataField: "tongMucDauTu",
                            dataType: "number",
                            format: {
                                type: "fixedPoint",
                                precision: 2
                            },
                        },
                        {
                            caption: "Trong đó:NST",
                            dataField: "nST",
                            dataType: "number",
                            format: {
                                type: "fixedPoint",
                                precision: 2
                            },
                        }
                        ]
                    }
                    ]
                }]
            },
            {
                caption: "Lũy kế khối lượng thực hiện đến hết năm " + (year - 1),
                alignment: "center",
                columns: [{
                    caption: "Trong đó: NST",
                    dataField: "nST_LuyKeKhoiLuong",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                }
                ]
            },
            {
                caption: "Lũy kế vốn bố trí đến hết năm " + (year - 1),
                alignment: "center",
                columns: [{
                    caption: "Trong đó: NST",
                    dataField: "nST_LuyKeVon",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                }
                ]
            },
            {
                caption: "Nhu cầu kế hoạch vốn",
                dataField: "nhuCauVon",
                dataType: "number",
                format: {
                    type: "fixedPoint",
                    precision: 2
                },
            },
            {
                caption: "Ghi chú",
                dataField: "ghiChu",
                format: "string"
            }
        ],
        summary: {
            totalItems: [{
                column: "tenCongTrinh",
                summaryType: "sum",
                showInColumn: "tenCongTrinh",
                format: "string",
                displayFormat: "Tổng số :"
            }, {
                column: "tongMucDauTu",
                summaryType: "sum",
                showInColumn: "tongMucDauTu",
                dataType: "number",
                    valueFormat: {
                        type: "fixedPoint",
                        precision: 2
                    },
                displayFormat: "{0}"
            }, {
                column: "nST",
                summaryType: "sum",
                showInColumn: "nST",
                dataType: "number",
                    valueFormat: {
                        type: "fixedPoint",
                        precision: 2
                    },
                displayFormat: "{0}"
            },
            {
                column: "nST_LuyKeKhoiLuong",
                summaryType: "sum",
                showInColumn: "nST_LuyKeKhoiLuong",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nST_LuyKeVon",
                summaryType: "sum",
                showInColumn: "nST_LuyKeVon",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nhuCauVon",
                summaryType: "sum",
                showInColumn: "nhuCauVon",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            }
            ]
        }
    });
}

function LoadTW(data) {

    $("#gridTW").dxDataGrid({
        noDataText: messages.no_data,
        dataSource: data,
        columnAutoWidth: true,
        allowColumnReordering: true,
        showBorders: true,
        scrolling: {
            columnRenderingMode: "virtual"
        },
        paging: {
            enabled: false
        },
        columns: [
            {
                caption: "#",
                dataField: "STT",
                alignment: "center",
                allowEditing: false,
                cellTemplate: orderRowItemNo
            },
            {
                caption: "Thông tin chung của công trình",
                alignment: "center",
                columns: [{
                    caption: "Danh sách công Trinh",
                    dataField: "tenCongTrinh",
                    format: "string"
                }, {
                    caption: "Mã số dự án",
                    dataField: "maSoDuAn",
                    format: "string"
                }, {
                    caption: "Mã số chương",
                    dataField: "maChuong",
                    format: "string"
                }, {
                    caption: "Mã loại khoản",
                    dataField: "maLoaiKhoan",
                    format: "string"
                },
                {
                    caption: "Quyết định đầu tư",
                    alignment: "center",
                    columns: [{
                        caption: "Số QĐ, Ngày tháng năm",
                        dataField: "soQuyetDinhDauTu",
                        alignment: "center"
                    },
                    {
                        caption: "Tổng mức đầu tư",
                        alignment: "center",
                        columns: [{
                            caption: "Tổng số",
                            dataField: "tongMucDauTu",
                            dataType: "number",
                            format: {
                                type: "fixedPoint",
                                precision: 2
                            },
                        },
                        {
                            caption: "Trong đó:NSTW",
                            dataField: "TW",
                            dataType: "number",
                            format: {
                                type: "fixedPoint",
                                precision: 2
                            },
                        }
                        ]
                    }
                    ]
                }]
            },
            {
                caption: "Lũy kế khối lượng thực hiện đến hết năm " + (year - 1),
                alignment: "center",
                columns: [{
                    caption: "Trong đó: NSTW",
                    dataField: "TW_LuyKeKhoiLuong",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                }
                ]
            },
            {
                caption: "Lũy kế vốn bố trí đến hết năm " + (year - 1),
                alignment: "center",
                columns: [{
                    caption: "Trong đó: NSTW",
                    dataField: "TW_LuyKeVon",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                }
                ]
            },
            {
                caption: "Nhu cầu kế hoạch vốn",
                dataField: "nhuCauVonTW",
                dataType: "number",
                format: {
                    type: "fixedPoint",
                    precision: 2
                },
            },
            {
                caption: "Ghi chú",
                dataField: "ghiChuTW",
                format: "string"
            }
        ],
        summary: {
            totalItems: [{
                column: "tenCongTrinh",
                summaryType: "sum",
                showInColumn: "tenCongTrinh",
                format: "string",
                displayFormat: "Tổng số :"
            }, {
                column: "TW",
                summaryType: "sum",
                showInColumn: "TW",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "TW_LuyKeKhoiLuong",
                summaryType: "sum",
                showInColumn: "TW_LuyKeKhoiLuong",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "TW_LuyKeVon",
                summaryType: "sum",
                showInColumn: "TW_LuyKeVon",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nhuCauVonTW",
                summaryType: "sum",
                showInColumn: "nhuCauVonTW",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            }
            ]
        }
    });
}

function LoadNSODA(data) {

    $("#gridNSODA").dxDataGrid({
        noDataText: messages.no_data,
        dataSource: data,
        columnAutoWidth: true,
        allowColumnReordering: true,
        showBorders: true,
        scrolling: {
            columnRenderingMode: "virtual"
        },
        paging: {
            enabled: false
        },
        columns: [
            {
                caption: "#",
                dataField: "STT",
                alignment: "center",
                allowEditing: false,
                cellTemplate: orderRowItemNo
            },
            {
                caption: "Thông tin chung của công trình",
                alignment: "center",
                columns: [{
                    caption: "Danh sách công Trinh",
                    dataField: "tenCongTrinh",
                    format: "string"
                }, {
                    caption: "Mã số dự án",
                    dataField: "maSoDuAn",
                    format: "string"
                }, {
                    caption: "Mã số chương",
                    dataField: "maChuong",
                    format: "string"
                }, {
                    caption: "Mã loại khoản",
                    dataField: "maLoaiKhoan",
                    format: "string"
                },
                {
                    caption: "Quyết định đầu tư",
                    alignment: "center",
                    columns: [{
                        caption: "Số QĐ, Ngày tháng năm",
                        dataField: "soQuyetDinhDauTu",
                        alignment: "center"
                    },
                    {
                        caption: "Tổng mức đầu tư",
                        alignment: "center",
                        columns: [{
                            caption: "Tổng số",
                            dataField: "tongMucDauTu",
                            dataType: "number",
                            format: {
                                type: "fixedPoint",
                                precision: 2
                            },
                        },
                        {
                            caption: "Trong đó:NODA",
                            dataField: "nSTODA",
                            dataType: "number",
                            format: {
                                type: "fixedPoint",
                                precision: 2
                            },
                        }
                        ]
                    }
                    ]
                }]
            },
            {
                caption: "Lũy kế khối lượng thực hiện đến hết năm " + (year - 1),
                alignment: "center",
                columns: [{
                    caption: "Trong đó: NODA",
                    dataField: "nSODA_LuyKeKhoiLuong",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                }
                ]
            },
            {
                caption: "Lũy kế vốn bố trí đến hết năm " + (year - 1),
                alignment: "center",
                columns: [{
                    caption: "Trong đó: NODA",
                    dataField: "nSODA_LuyKeVon",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                }
                ]
            },
            {
                caption: "Nhu cầu kế hoạch vốn",
                dataField: "nhuCauVonODA",
                dataType: "number",
                format: {
                    type: "fixedPoint",
                    precision: 2
                },
            },
            {
                caption: "Ghi chú",
                dataField: "ghiChuODA",
                format: "string"
            }
        ],
        summary: {
            totalItems: [{
                column: "tenCongTrinh",
                summaryType: "sum",
                showInColumn: "tenCongTrinh",
                format: "string",
                displayFormat: "Tổng số :"
            }, {
                column: "nSTODA",
                summaryType: "sum",
                showInColumn: "nSTODA",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nSODA_LuyKeKhoiLuong",
                summaryType: "sum",
                showInColumn: "nSODA_LuyKeKhoiLuong",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nSODA_LuyKeVon",
                summaryType: "sum",
                showInColumn: "nSODA_LuyKeVon",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nhuCauVonODA",
                summaryType: "sum",
                showInColumn: "nhuCauVonODA",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            }
            ]
        }
    });
}
//Load dữ liệu điều chỉnh
function LoadNSTDieuChinh(data) {

    $("#gridNST").dxDataGrid({
        noDataText: messages.no_data,
        dataSource: data,
        columnAutoWidth: true,
        allowColumnReordering: true,
        showBorders: true,
        scrolling: {
            columnRenderingMode: "virtual"
        },
        paging: {
            enabled: false
        },
        columns: [
            {
                caption: "#",
                dataField: "STT",
                alignment: "center",
                allowEditing: false,
                cellTemplate: orderRowItemNo
            },
            {
                caption: "Thông tin chung của công trình",
                alignment: "center",
                columns: [{
                    caption: "Danh sách công Trinh",
                    dataField: "tenCongTrinh",
                    format: "string"
                }, {
                    caption: "Mã số dự án",
                    dataField: "maSoDuAn",
                    format: "string"
                }, {
                    caption: "Mã số chương",
                    dataField: "maChuong",
                    format: "string"
                }, {
                    caption: "Mã loại khoản",
                    dataField: "maLoaiKhoan",
                    format: "string"
                },
                {
                    caption: "Quyết định đầu tư",
                    alignment: "center",
                    columns: [{
                        caption: "Số QĐ, Ngày tháng năm",
                        dataField: "soQuyetDinhDauTu",
                        alignment: "center"
                    },
                    {
                        caption: "Tổng mức đầu tư",
                        alignment: "center",
                        columns: [{
                            caption: "Tổng số",
                            dataField: "tongMucDauTu",
                            dataType: "number",
                            format: {
                                type: "fixedPoint",
                                precision: 2
                            },
                        },
                        {
                            caption: "Trong đó:NST",
                            dataField: "nST",
                            dataType: "number",
                            format: {
                                type: "fixedPoint",
                                precision: 2
                            },
                        }
                        ]
                    }
                    ]
                }]
            },
            {
                caption: "Lũy kế khối lượng thực hiện đến hết năm " + (year - 1),
                alignment: "center",
                columns: [{
                    caption: "Trong đó: NST",
                    dataField: "nST_LuyKeKhoiLuong",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                }
                ]
            },
            {
                caption: "Lũy kế vốn bố trí đến hết năm " + (year - 1),
                alignment: "center",
                columns: [{
                    caption: "Trong đó: NST",
                    dataField: "nST_LuyKeVon",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                }
                ]
            },
            {
                caption: "Kế hoạch vốn năm " + year + " đã giao",
                alignment: "center",
                columns: [{
                    caption: "Trong đó: NST",
                    dataField: "nST_KeHoachVonDaGiao",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                }
                ]
            },
            {
                caption: "Đề xuất điều chỉnh kế hoạch vốn năm " + year,
                alignment: "center",
                columns: [{
                    caption: "Điều chỉnh giảm",
                    dataField: "nST_Giam",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                },
                {
                    caption: "Điều chỉnh tăng",
                    dataField: "nST_Tang",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                }
                ]
            },
            {
                caption: "Kế hoạch vốn năm " + year + " sau điều chỉnh",
                dataField: "nST_von_dieuchinh",
                dataType: "number",
                format: {
                    type: "fixedPoint",
                    precision: 2
                },
            },
            {
                caption: "Ghi chú",
                dataField: "ghiChu_dieuchinh",
                format: "string"
            }
        ],
        summary: {
            totalItems: [{
                column: "tenCongTrinh",
                showInColumn: "tenCongTrinh",
                format: "string",
                displayFormat: "Tổng số :"
            }, {
                column: "tongMucDauTu",
                summaryType: "sum",
                showInColumn: "tongMucDauTu",
                dataType: "number",
                    valueFormat: {
                        type: "fixedPoint",
                        precision: 2
                    },
                displayFormat: "{0}"
            },
            {
                column: "nST",
                summaryType: "sum",
                showInColumn: "nST",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nST_LuyKeKhoiLuong",
                summaryType: "sum",
                showInColumn: "nST_LuyKeKhoiLuong",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nST_LuyKeVon",
                summaryType: "sum",
                showInColumn: "nST_LuyKeVon",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nST_KeHoachVonDaGiao",
                summaryType: "sum",
                showInColumn: "nST_KeHoachVonDaGiao",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nST_Tang",
                summaryType: "sum",
                showInColumn: "nST_Tang",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nST_Giam",
                summaryType: "sum",
                showInColumn: "nST_Giam",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nST_von_dieuchinh",
                summaryType: "sum",
                showInColumn: "nST_von_dieuchinh",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            }
            ]
        }
    });
}

function LoadNSTWDieuChinh(data) {

    $("#gridTW").dxDataGrid({
        noDataText: messages.no_data,
        dataSource: data,
        columnAutoWidth: true,
        allowColumnReordering: true,
        showBorders: true,
        scrolling: {
            columnRenderingMode: "virtual"
        },
        paging: {
            enabled: false
        },
        columns: [
            {
                caption: "#",
                dataField: "STT",
                alignment: "center",
                allowEditing: false,
                cellTemplate: orderRowItemNo
            },
            {
                caption: "Thông tin chung của công trình",
                alignment: "center",
                columns: [{
                    caption: "Danh sách công Trinh",
                    dataField: "tenCongTrinh",
                    format: "string"
                }, {
                    caption: "Mã số dự án",
                    dataField: "maSoDuAn",
                    format: "string"
                }, {
                    caption: "Mã số chương",
                    dataField: "maChuong",
                    format: "string"
                }, {
                    caption: "Mã loại khoản",
                    dataField: "maLoaiKhoan",
                    format: "string"
                },
                {
                    caption: "Quyết định đầu tư",
                    alignment: "center",
                    columns: [{
                        caption: "Số QĐ, Ngày tháng năm",
                        dataField: "soQuyetDinhDauTu",
                        alignment: "center"
                    },
                    {
                        caption: "Tổng mức đầu tư",
                        alignment: "center",
                        columns: [{
                            caption: "Tổng số",
                            dataField: "tongMucDauTu",
                            dataType: "number",
                            format: {
                                type: "fixedPoint",
                                precision: 2
                            },
                        },
                        {
                            caption: "Trong đó:NSTW",
                            dataField: "TW",
                            dataType: "number",
                            format: {
                                type: "fixedPoint",
                                precision: 2
                            },
                        }
                        ]
                    }
                    ]
                }]
            },
            {
                caption: "Lũy kế khối lượng thực hiện đến hết năm " + (year - 1),
                alignment: "center",
                columns: [{
                    caption: "Trong đó: NSTW",
                    dataField: "TW_LuyKeKhoiLuong",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                }
                ]
            },
            {
                caption: "Lũy kế vốn bố trí đến hết năm " + (year - 1),
                alignment: "center",
                columns: [{
                    caption: "Trong đó: NSTW",
                    dataField: "TW_LuyKeVon",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                }
                ]
            },
            {
                caption: "Kế hoạch vốn năm " + year + " đã giao",
                alignment: "center",
                columns: [{
                    caption: "Trong đó: NSTW",
                    dataField: "nSTW_KeHoachVonDaGiao",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                }
                ]
            },
            {
                caption: "Đề xuất điều chỉnh kế hoạch vốn năm " + year,
                alignment: "center",
                columns: [{
                    caption: "Điều chỉnh giảm",
                    dataField: "nSTW_Giam",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                },
                {
                    caption: "Điều chỉnh tăng",
                    dataField: "nSTW_Tang",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                }
                ]
            },
            {
                caption: "Kế hoạch vốn năm " + year + " sau điều chỉnh",
                dataField: "nSTW_von_dieuchinh",
                dataType: "number",
                format: {
                    type: "fixedPoint",
                    precision: 2
                },
            },
            {
                caption: "Ghi chú",
                dataField: "ghiChuTW_dieuchinh",
                format: "string"
            }
        ],
        summary: {
            totalItems: [{
                column: "tenCongTrinh",
                summaryType: "sum",
                showInColumn: "tenCongTrinh",
                format: "string",
                displayFormat: "Tổng số :"
            }, {
                column: "TW",
                summaryType: "sum",
                showInColumn: "TW",
                dataType: "number",
                    valueFormat: {
                        type: "fixedPoint",
                        precision: 2
                    },
                displayFormat: "{0}"
            },
            {
                column: "TW_LuyKeKhoiLuong",
                summaryType: "sum",
                showInColumn: "TW_LuyKeKhoiLuong",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "TW_LuyKeVon",
                summaryType: "sum",
                showInColumn: "TW_LuyKeVon",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nSTW_KeHoachVonDaGiao",
                summaryType: "sum",
                showInColumn: "nSTW_KeHoachVonDaGiao",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nSTW_Giam",
                summaryType: "sum",
                showInColumn: "nSTW_Giam",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nSTW_Tang",
                summaryType: "sum",
                showInColumn: "nSTW_Tang",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nSTW_von_dieuchinh",
                summaryType: "sum",
                showInColumn: "nSTW_von_dieuchinh",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            }
            ]
        }
    });
}

function LoadNSODADieuChinh(data) {

    $("#gridNSODA").dxDataGrid({
        noDataText: messages.no_data,
        dataSource: data,
        columnAutoWidth: true,
        allowColumnReordering: true,
        showBorders: true,
        scrolling: {
            columnRenderingMode: "virtual"
        },
        paging: {
            enabled: false
        },
        columns: [
            {
                caption: "#",
                dataField: "STT",
                alignment: "center",
                allowEditing: false,
                cellTemplate: orderRowItemNo
            },
            {
                caption: "Thông tin chung của công trình",
                alignment: "center",
                columns: [{
                    caption: "Danh sách công Trinh",
                    dataField: "tenCongTrinh",
                    format: "string"
                }, {
                    caption: "Mã số dự án",
                    dataField: "maSoDuAn",
                        format: "string"
                }, {
                    caption: "Mã số chương",
                    dataField: "maChuong",
                        format: "string"
                }, {
                    caption: "Mã loại khoản",
                    dataField: "maLoaiKhoan",
                        format: "string"
                },
                {
                    caption: "Quyết định đầu tư",
                    alignment: "center",
                    columns: [{
                        caption: "Số QĐ, Ngày tháng năm",
                        dataField: "soQuyetDinhDauTu",
                        alignment: "center"
                    },
                    {
                        caption: "Tổng mức đầu tư",
                        alignment: "center",
                        columns: [{
                            caption: "Tổng số",
                            dataField: "tongMucDauTu",
                            dataType: "number",
                            format: {
                                type: "fixedPoint",
                                precision: 2
                            },
                        },
                        {
                            caption: "Trong đó:NODA",
                            dataField: "nSTODA",
                            dataType: "number",
                            format: {
                                type: "fixedPoint",
                                precision: 2
                            },
                        }
                        ]
                    }
                    ]
                }]
            },
            {
                caption: "Lũy kế khối lượng thực hiện đến hết năm " + (year - 1),
                alignment: "center",
                columns: [{
                    caption: "Trong đó: NODA",
                    dataField: "nSODA_LuyKeKhoiLuong",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                }
                ]
            },
            {
                caption: "Lũy kế vốn bố trí đến hết năm " + (year - 1),
                alignment: "center",
                columns: [{
                    caption: "Trong đó: NODA",
                    dataField: "nSODA_LuyKeVon",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                }
                ]
            },
            {
                caption: "Kế hoạch vốn năm " + year + " đã giao",
                alignment: "center",
                columns: [{
                    caption: "Trong đó: NODA",
                    dataField: "nSODA_KeHoachVonDaGiao",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                }
                ]
            },
            {
                caption: "Đề xuất điều chỉnh kế hoạch vốn năm " + year,
                alignment: "center",
                columns: [{
                    caption: "Điều chỉnh giảm",
                    dataField: "nSODA_Giam",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                },
                {
                    caption: "Điều chỉnh tăng",
                    dataField: "nSODA_Tang",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                }
                ]
            },
            {
                caption: "Kế hoạch vốn năm "+year+" sau điều chỉnh",
                dataField: "nSODA_von_dieuchinh",
                dataType: "number",
                format: {
                    type: "fixedPoint",
                    precision: 2
                },
            },
            {
                caption: "Ghi chú",
                dataField: "ghiChuODA_dieuchinh",
                format: "string"
            }
        ],
        summary: {
            totalItems: [{
                column: "tenCongTrinh",
                summaryType: "sum",
                showInColumn: "tenCongTrinh",
                format: "string",
                displayFormat: "Tổng số :"
            }, {
                column: "nSTODA",
                summaryType: "sum",
                showInColumn: "nSTODA",
                    dataType: "number",
                    valueFormat: {
                        type: "fixedPoint",
                        precision: 2
                    },
                displayFormat: "{0}"
            },
            {
                column: "nSODA_LuyKeKhoiLuong",
                summaryType: "sum",
                showInColumn: "nSODA_LuyKeKhoiLuong",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nSODA_LuyKeVon",
                summaryType: "sum",
                showInColumn: "nSODA_LuyKeVon",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nSODA_KeHoachVonDaGiao",
                summaryType: "sum",
                showInColumn: "nSODA_KeHoachVonDaGiao",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nSODA_Giam",
                summaryType: "sum",
                showInColumn: "nSODA_Giam",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nSODA_Tang",
                summaryType: "sum",
                showInColumn: "nSODA_Tang",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "nSODA_von_dieuchinh",
                summaryType: "sum",
                showInColumn: "nSODA_von_dieuchinh",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            }
            ]
        }
    });
}

//Xử lý không hiển thị scroll trong tab ngân sách trung ương
$('#tab_TW').click(function (e) {
    $("#gridTW").find('.dx-header-multi-row colgroup').html($("#gridNST").find('.dx-header-multi-row colgroup').html());
    $("#gridTW").find('.dx-datagrid-rowsview colgroup').html($("#gridNST").find('.dx-datagrid-rowsview colgroup').html());
    $("#gridTW").find('.dx-datagrid-total-footer colgroup').html($("#gridNST").find('.dx-datagrid-total-footer colgroup').html());
});

//set số thứ tự
function orderRowItemNo(cellElement, cellInfo) {
    var index = cellInfo.row.rowIndex + 1;
    cellElement.text(index)
}

//xuất file excel trung hạn
$('#Export').click(function () {
    loadPanel.show();
    if (loaikehoach == "DIEU_CHINH") {
        abp.ajax({
            url: '/api/app/nhuCauKeHoachVonChiTiet/exportDieuChinhTrungHanByNhuCauKeHoachVonID?nhuCauKeHoachVonID=' + kehoachNhuCauVonId,
            type: 'get',
            async: true
        }).done(function (data) {
            if (data.isExport) {
                window.location.href = data.path;
            } else {
                abp.notify.info(data.Msg);
            }
            loadPanel.hide();
        });
    } else {
        abp.ajax({
            url: '/api/app/nhuCauKeHoachVonChiTiet/exportDauNamByNhuCauKeHoachVonID?nhuCauKeHoachVonID=' + kehoachNhuCauVonId,
            type: 'get',
            async: true
        }).done(function (data) {
            if (data.isExport) {
                window.location.href = data.path;
            } else {
                abp.notify.info(data.Msg);
            }
            loadPanel.hide();
        });
    }

})
