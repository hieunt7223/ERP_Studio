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
//Get dữ liệu --------------------------------------------------
//Get dữ liệu edit
function getNSTEdit() {
    abp.ajax({
        url: '/api/app/nhuCauKeHoachVon/' + kehoachNhuCauVonId + '/nhuCauKeHoachVonChiTiet',
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
            var k = 0;
            for (let i = 0; i < nhuCauVonChiTietDauNam.length; i++) {
                if (!nhuCauVonChiTietDauNam[i].isDeleteDieuChinh) {
                    for (let j = 0; j < data.length; j++)
                        if (nhuCauVonChiTietDauNam[i].congTrinhID === data[j].id) {
                            congTrinhNganSachTinhs.push(data[j]);
                            congTrinhNganSachTinhs[k].nST = data[j].nst;
                            congTrinhNganSachTinhs[k].ghiChu_dieuchinh = nhuCauVonChiTietDauNam[i].ghiChuDieuChinhNST;
                            congTrinhNganSachTinhs[k].nST_LuyKeKhoiLuong = nhuCauVonChiTietDauNam[i].luyKeKhoiLuongNamTruocNST;
                            congTrinhNganSachTinhs[k].nST_LuyKeVon = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocNST;
                            congTrinhNganSachTinhs[k].ghiChu = nhuCauVonChiTietDauNam[i].ghiChuDauNamNST;
                            congTrinhNganSachTinhs[k].nST_KeHoachVonDaGiao = 0;
                            congTrinhNganSachTinhs[k].nST_Tang = nhuCauVonChiTietDauNam[i].dieuChinhTangNST;
                            congTrinhNganSachTinhs[k].nST_Giam = nhuCauVonChiTietDauNam[i].dieuChinhGiamNST;
                            congTrinhNganSachTinhs[k].nST_von_dieuchinh = congTrinhNganSachTinhs[k].nST_KeHoachVonDaGiao + congTrinhNganSachTinhs[k].nST_Tang - congTrinhNganSachTinhs[k].nST_Giam;
                            congTrinhNganSachTinhs[k].idChiTiet = nhuCauVonChiTietDauNam[i].id;
                            k=k+1;
                        }
                }

            }

        } else {
            var k = 0;
            for (let i = 0; i < nhuCauVonChiTietDauNam.length; i++) {
                if (!nhuCauVonChiTietDauNam[i].isSelectDieuChinh) {
                    for (let j = 0; j < data.length; j++)
                        if (nhuCauVonChiTietDauNam[i].congTrinhID === data[j].id) {
                            congTrinhNganSachTinhs.push(data[j]);
                            congTrinhNganSachTinhs[k].nST = data[j].nst;
                            congTrinhNganSachTinhs[k].nST_LuyKeKhoiLuong = nhuCauVonChiTietDauNam[i].luyKeKhoiLuongNamTruocNST;
                            congTrinhNganSachTinhs[k].nST_LuyKeVon = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocNST;
                            congTrinhNganSachTinhs[k].ghiChu = nhuCauVonChiTietDauNam[i].ghiChuDauNamNST;
                            congTrinhNganSachTinhs[k].nhuCauVon = nhuCauVonChiTietDauNam[i].nhuCauVonDauNamNST;
                            congTrinhNganSachTinhs[k].idChiTiet = nhuCauVonChiTietDauNam[i].id;
                            k=k+1;
                        }
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
            let k = 0;
            for (let i = 0; i < nhuCauVonChiTietDauNam.length; i++) {
                if (!nhuCauVonChiTietDauNam[i].isDeleteDieuChinh) {
                    for (let j = 0; j < data.length; j++)
                        if (nhuCauVonChiTietDauNam[i].congTrinhID === data[j].id) {
                            congTrinhNganSachTWs.push(data[j]);
                            congTrinhNganSachTWs[k].TW = data[j].nstw;
                            congTrinhNganSachTWs[k].ghiChuTW_dieuchinh = nhuCauVonChiTietDauNam[i].ghiChuDieuChinhNSTW;
                            congTrinhNganSachTWs[k].TW_LuyKeKhoiLuong = nhuCauVonChiTietDauNam[i].luyKeKhoiLuongNamTruocNSTW;
                            congTrinhNganSachTWs[k].TW_LuyKeVon = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocNSTW;
                            congTrinhNganSachTWs[k].ghiChuTW = nhuCauVonChiTietDauNam[i].ghiChuDauNamNSTW;
                            congTrinhNganSachTWs[k].nSTW_KeHoachVonDaGiao = 0;
                            congTrinhNganSachTWs[k].nSTW_Tang = nhuCauVonChiTietDauNam[i].dieuChinhTangNSTW;
                            congTrinhNganSachTWs[k].nSTW_Giam = nhuCauVonChiTietDauNam[i].dieuChinhGiamNSTW;
                            congTrinhNganSachTWs[k].nSTW_von_dieuchinh = congTrinhNganSachTWs[k].nSTW_KeHoachVonDaGiao + congTrinhNganSachTWs[k].nSTW_Tang - congTrinhNganSachTWs[k].nSTW_Giam;
                            k=k+1;
                        }
                }

            }

        } else {
            var k = 0;
            for (let i = 0; i < nhuCauVonChiTietDauNam.length; i++) {
                if (!nhuCauVonChiTietDauNam[i].isSelectDieuChinh) {
                    for (let j = 0; j < data.length; j++)
                        if (nhuCauVonChiTietDauNam[i].congTrinhID === data[j].id) {
                            congTrinhNganSachTWs.push(data[j]);
                            congTrinhNganSachTWs[k].TW = data[j].nstw;
                            congTrinhNganSachTWs[k].TW_LuyKeKhoiLuong = nhuCauVonChiTietDauNam[i].luyKeKhoiLuongNamTruocNSTW;
                            congTrinhNganSachTWs[k].TW_LuyKeVon = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocNSTW;
                            congTrinhNganSachTWs[k].ghiChuTW = nhuCauVonChiTietDauNam[i].ghiChuDauNamNSTW;
                            congTrinhNganSachTWs[k].nhuCauVonTW = nhuCauVonChiTietDauNam[i].nhuCauVonDauNamNSTW;
                            k=k+1;
                        }
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
            var k = 0;
            for (let i = 0; i < nhuCauVonChiTietDauNam.length; i++) {
                if (!nhuCauVonChiTietDauNam[i].isDeleteDieuChinh) {
                    for (let j = 0; j < data.length; j++)
                        if (nhuCauVonChiTietDauNam[i].congTrinhID === data[j].id) {
                            congTrinhNganSachODAs.push(data[j]);
                            congTrinhNganSachODAs[k].nSTODA = data[j].oda;
                            congTrinhNganSachODAs[k].ghiChuODA_dieuchinh = nhuCauVonChiTietDauNam[i].ghiChuDieuChinhODA;
                            congTrinhNganSachODAs[k].nSODA_LuyKeKhoiLuong = nhuCauVonChiTietDauNam[i].luyKeKhoiLuongNamTruocODA;
                            congTrinhNganSachODAs[k].nSODA_LuyKeVon = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocODA;
                            congTrinhNganSachODAs[k].ghiChuODA = nhuCauVonChiTietDauNam[i].ghiChuDauNamODA;
                            congTrinhNganSachODAs[k].nSODA_KeHoachVonDaGiao = 0;
                            congTrinhNganSachODAs[k].nSODA_Tang = nhuCauVonChiTietDauNam[i].dieuChinhTangODA;
                            congTrinhNganSachODAs[k].nSODA_Giam = nhuCauVonChiTietDauNam[i].dieuChinhGiamODA;
                            congTrinhNganSachODAs[k].ghiChuODA_dieuchinh = congTrinhNganSachODAs[k].nSODA_KeHoachVonDaGiao + congTrinhNganSachODAs[k].nSODA_Tang - congTrinhNganSachODAs[k].nSODA_Giam;
                            k=k+1;
                        }
                }

            }

        } else {
            var k = 0;
            for (let i = 0; i < nhuCauVonChiTietDauNam.length; i++) {
                if (!nhuCauVonChiTietDauNam[i].isSelectDieuChinh) {
                    for (let j = 0; j < data.length; j++)
                        if (nhuCauVonChiTietDauNam[i].congTrinhID === data[j].id) {
                            congTrinhNganSachODAs.push(data[j]);
                            congTrinhNganSachODAs[k].nSTODA = data[j].oda;
                            congTrinhNganSachODAs[k].nSODA_LuyKeKhoiLuong = nhuCauVonChiTietDauNam[i].luyKeKhoiLuongNamTruocODA;
                            congTrinhNganSachODAs[k].nSODA_LuyKeVon = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocODA;
                            congTrinhNganSachODAs[k].ghiChuODA = nhuCauVonChiTietDauNam[i].ghiChuDauNamODA;
                            congTrinhNganSachODAs[k].nhuCauVonODA = nhuCauVonChiTietDauNam[i].nhuCauVonDauNamODA;
                            k=k+1;
                        }
                }
            }
        }
    });
}

//--------------------------------------------------------------

//Load dữ liệu--------------------------------------------------
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
                        alignment: "center",
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
                dataType: "number",
                displayFormat: "Tổng số :"

            }, {
                column: "tongMucDauTu",
                summaryType: "sum",
                showInColumn: "tongMucDauTu",
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
                displayFormat: "{0}",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
            },
            {
                column: "nST_LuyKeKhoiLuong",
                summaryType: "sum",
                showInColumn: "nST_LuyKeKhoiLuong",
                dataType: "number",
                displayFormat: "{0}",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
            },
            {
                column: "nST_LuyKeVon",
                summaryType: "sum",
                showInColumn: "nST_LuyKeVon",
                dataType: "number",
                displayFormat: "{0}",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
            },
            {
                column: "nhuCauVon",
                summaryType: "sum",
                showInColumn: "nhuCauVon",
                displayFormat: "{0}",
                showBorders: true,
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
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
                format: "string",
                showInColumn: "tenCongTrinh",
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
                            caption: "Trong đó:ODA",
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
                    caption: "Trong đó: ODA",
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
                    caption: "Trong đó: ODA",
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
                            format: {
                                type: "fixedPoint",
                                precision: 2
                            },
                            dataType: "number"
                        },
                        {
                            caption: "Trong đó:NST",
                            dataField: "nST",
                            format: {
                                type: "fixedPoint",
                                precision: 2
                            },
                            dataType: "number"
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
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                    dataType: "number"
                }
                ]
            },
            {
                caption: "Lũy kế vốn bố trí đến hết năm " + (year - 1),
                alignment: "center",
                columns: [{
                    caption: "Trong đó: NST",
                    dataField: "nST_LuyKeVon",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                    dataType: "number"
                }
                ]
            },
            {
                caption: "Kế hoạch vốn năm " + year + " đã giao",
                alignment: "center",
                columns: [{
                    caption: "Trong đó: NST",
                    dataField: "nST_KeHoachVonDaGiao",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                    dataType: "number"
                }
                ]
            },
            {
                caption: "Đề xuất điều chỉnh kế hoạch vốn năm " + year,
                alignment: "center",
                columns: [{
                    caption: "Điều chỉnh giảm",
                    dataField: "nST_Giam",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                    dataType: "number"
                },
                {
                    caption: "Điều chỉnh tăng",
                    dataField: "nST_Tang",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                    dataType: "number"
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
                    caption: "Trong đó: NST",
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
                            caption: "Trong đó:NST",
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
                    caption: "Trong đó: NST",
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
                    caption: "Trong đó: NST",
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
                    caption: "Trong đó: NST",
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
                caption: "Kế hoạch vốn năm " + year + " sau điều chỉnh",
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

//Xử lý không hiển thị scroll trong tab ngân sách đầu tư
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

//Xuất excel
$('#Export').click(function () {
    loadPanel.show();
    if (loaikehoach == "DIEU_CHINH") {
        
        abp.ajax({
            url: '/api/app/nhuCauKeHoachVonChiTiet/exportDieuChinhHangNamByNhuCauKeHoachVonID?nhuCauKeHoachVonID=' + kehoachNhuCauVonId,
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








