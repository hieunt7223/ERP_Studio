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


//Ngân sách tỉnh
$(function () {
    abp.ajax({
        url: '/api/app/giaiNgan/' + giaiNganId+'/giaiNganChiTiet',
        type: 'get',
        async: false
    }).done(function (result_data) {
        var data = result_data;
        LoadNST(data);
        LoadNSTW(data);
        LoadODA(data);
        $('#TW').removeClass('active');
        $('#ODA').removeClass('active');
    });
});


// Ngân sách tỉnh
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
        editing: {
            mode: "cell",
            allowUpdating: true,
            allowDeleting: false,
            useIcons: true,
            confirmDelete: false
        },
        onEditorPreparing: function (e) {
            if (false) {
                e.editorOptions.disabled = false;
            } else {
                e.editorOptions.disabled = true;
            }
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
                caption: "Danh mục dự án",
                dataField: "tenCongTrinh",
                format: "string",
            },
            {
                caption: "Mã số dự án",
                dataField: "maSoDuAn",
                format: "string",
            },
            {
                caption: "Quyết định đầu tư",
                alignment: "center",
                columns: [
                    {
                        caption: "Số QĐ, Ngày tháng năm",
                        dataField: "soQuyetDinhDauTu",
                        alignment: "center"
                    },
                    {
                        caption: "NS Tỉnh",
                        dataField: "nST",
                        dataType: "number",
                        format: "#,###",
                    }

                ]
            },
            {
                caption: "Lũy kế bố trí vốn đến hết kế hoạch năm " + year,
                dataField: "luyKeVonNamNayNST",
                dataType: "number",
                format: "#,###",
            },
            {
                caption: "Lũy kế vốn giải ngân từ khởi công đến hết ngày 31/12/" + year,
                dataField: "luyKeGiaiNganNamNayNST",
                dataType: "number",
                format: "#,###",
            },
            {
                caption: "Kế hoạch vốn NS Tỉnh năm " + year + " cho phép kéo dài (nếu có)",
                dataField: "keHoachVonNamTruocKeoDaiNST",
                dataType: "number",
                format: "#,###",
            },
            {
                caption: "Kế hoạch năm " + year,
                dataField: "keHoachVonNamNayNST",
                dataType: "number",
                format: "#,###",
            },
            {
                caption: "Khối lượng thực hiện từ khởi công đến hết " + htmldecode(quyThang) + year,
                dataField: "khoiLuongThucHienNamNayNST",
                dataType: "number",
                format: "#,###",
            },
            {
                caption: "Giải ngân KH năm " + year + "(tính từ 01/01 năm " + year + ") và kế hoạch năm " + (year - 1) + " kéo dài (nếu có) đến hết " + htmldecode(quyThang)  + year,
                alignment: "center",
                columns: [
                    {
                        caption: "KH Năm " + year,
                        dataField: "giaiNganNamNayNST",
                        alignment: "center",
                        format: "#,###",
                    },
                    {
                        caption: "Kế hoạch năm " + (year - 1) + " kéo dài",
                        dataField: "giaiNganNamTruocKeoDaiNST",
                        dataType: "number",
                        format: "#,###",
                    }

                ]
            },
            {
                caption: "Ghi chú",
                dataField: "ghiChuNST",
                format: "string",
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
                column: "luyKeVonNamNayNST",
                summaryType: "sum",
                showInColumn: "luyKeVonNamNayNST",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            }, {
                column: "luyKeGiaiNganNamNayNST",
                summaryType: "sum",
                showInColumn: "luyKeGiaiNganNamNayNST",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "keHoachVonNamTruocKeoDaiNST",
                summaryType: "sum",
                showInColumn: "keHoachVonNamTruocKeoDaiNST",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "keHoachVonNamNayNST",
                summaryType: "sum",
                showInColumn: "keHoachVonNamNayNST",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "khoiLuongThucHienNamNayNST",
                summaryType: "sum",
                showInColumn: "khoiLuongThucHienNamNayNST",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "giaiNganNamNayNST",
                summaryType: "sum",
                showInColumn: "giaiNganNamNayNST",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "giaiNganNamTruocKeoDaiNST",
                summaryType: "sum",
                showInColumn: "giaiNganNamTruocKeoDaiNST",
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

// Ngân sách trung ương
function LoadNSTW(data) {
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
        editing: {
            mode: "cell",
            allowUpdating: true,
            allowDeleting: false,

        },
        onEditorPreparing: function (e) {
            if (false) {
                e.editorOptions.disabled = false;
            } else {
                e.editorOptions.disabled = true;
            }
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
                caption: "Danh mục dự án",
                dataField: "tenCongTrinh",
                format: "string",
            },
            {
                caption: "Mã số dự án",
                dataField: "maSoDuAn",
                format: "string",
            },
            {
                caption: "Quyết định đầu tư",
                alignment: "center",
                columns: [
                    {
                        caption: "Số QĐ, Ngày tháng năm",
                        dataField: "soQuyetDinhDauTu",
                        alignment: "center"
                    },
                    {
                        caption: "NSTW",
                        dataField: "nSTW",
                        dataType: "number",
                        format: "#,###",
                    }

                ]
            },
            {
                caption: "Lũy kế bố trí vốn đến hết kế hoạch năm " + year,
                dataField: "luyKeVonNamNayNSTW",
                dataType: "number",
                format: "#,###",
            },
            {
                caption: "Lũy kế vốn giải ngân từ khởi công đến hết ngày 31/12/" + year,
                dataField: "luyKeGiaiNganNamNayNSTW",
                dataType: "number",
                format: "#,###",
            },
            {
                caption: "Kế hoạch vốn NSTW năm " + year + " cho phép kéo dài (nếu có)",
                dataField: "keHoachVonNamTruocKeoDaiNSTW",
                dataType: "number",
                format: "#,###",
            },
            {
                caption: "Kế hoạch năm " + year,
                dataField: "keHoachVonNamNayNSTW",
                dataType: "number",
                format: "#,###",
            },
            {
                caption: "Khối lượng thực hiện từ khởi công đến hết " + htmldecode(quyThang)  + year,
                dataField: "khoiLuongThucHienNamNayNSTW",
                dataType: "number",
                format: "#,###",
            },
            {
                caption: "Giải ngân KH năm " + year + "(tính từ 01/01 năm " + year + ") và kế hoạch năm " + (year - 1) + " kéo dài (nếu có) đến hết " + htmldecode(quyThang)  + year,
                alignment: "center",
                columns: [
                    {
                        caption: "KH Năm " + year,
                        dataField: "giaiNganNamNayNSTW",
                        alignment: "number",
                        format: "#,###",
                    },
                    {
                        caption: "Kế hoạch năm " + (year - 1) + " kéo dài",
                        dataField: "giaiNganNamTruocKeoDaiNSTW",
                        dataType: "number",
                        format: "#,###",
                    }

                ]
            },
            {
                caption: "Ghi chú",
                dataField: "ghiChuNSTW",
                format: "string",
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
                column: "nSTW",
                summaryType: "sum",
                showInColumn: "nSTW",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "luyKeVonNamNayNSTW",
                summaryType: "sum",
                showInColumn: "luyKeVonNamNayNSTW",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            }, {
                column: "luyKeGiaiNganNamNayNSTW",
                summaryType: "sum",
                showInColumn: "luyKeGiaiNganNamNayNSTW",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "keHoachVonNamTruocKeoDaiNSTW",
                summaryType: "sum",
                showInColumn: "keHoachVonNamTruocKeoDaiNSTW",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "keHoachVonNamNayNSTW",
                summaryType: "sum",
                showInColumn: "keHoachVonNamNayNSTW",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "khoiLuongThucHienNamNayNSTW",
                summaryType: "sum",
                showInColumn: "khoiLuongThucHienNamNayNSTW",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "giaiNganNamNayNSTW",
                summaryType: "sum",
                showInColumn: "giaiNganNamNayNSTW",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "giaiNganNamTruocKeoDaiNSTW",
                summaryType: "sum",
                showInColumn: "giaiNganNamTruocKeoDaiNSTW",
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

// Load Oda

function LoadODA(data) {
    $("#gridODA").dxDataGrid({
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
        editing: {
            mode: "cell",
            allowUpdating: true,
            allowDeleting: true,
            useIcons: true,
            confirmDelete: false
        },
        onEditorPreparing: function (e) {
            if (e.dataField === "nhuCauVon" || e.dataField === "ghiChu") {
                e.editorOptions.disabled = false;
            } else {
                e.editorOptions.disabled = true;
            }
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
                caption: "Danh mục ngành/dự án",
                dataField: "tenCongTrinh",
                format: "string",
            },
            {
                caption: "Quyết định đầu tư được Thủ tướng chính phủ giao kế hoạch trung hạn",
                alignment: "center",
                columns: [
                    {
                        caption: "Số QĐ, Ngày, tháng, năm",
                        dataField: "soQuyetDinhDauTu",
                        alignment: "center"
                    },
                    {
                        caption: "Tổng mức đầu tư",
                        alignment: "center",
                        columns: [
                            {
                                caption: "Tổng số",
                                dataField: "tongSo",
                                dataType: "number",
                                format: {
                                    type: "fixedPoint",
                                    precision: 2
                                },
                            }, {
                                caption: "Trong đó",
                                alignment: "center",
                                columns: [
                                    {
                                        caption: "Vốn đối ứng",
                                        alignment: "center",
                                        columns: [
                                            {
                                                caption: "Tổng số",
                                                dataField: "tongSoDU1",
                                                dataType: "number",
                                                format: {
                                                    type: "fixedPoint",
                                                    precision: 2
                                                },
                                            },
                                            {
                                                caption: "Trong đó: ODA",
                                                dataField: "ODADU1",
                                                dataType: "number",
                                                format: {
                                                    type: "fixedPoint",
                                                    precision: 2
                                                },
                                            }
                                        ]
                                    },
                                    {
                                        caption: "Vốn nước ngoài",
                                        alignment: "center",
                                        columns: [
                                            {
                                                caption: "Tính bằng ngoại tệ",
                                                dataField: "NgoaiTe",
                                                dataType: "number",
                                                format: {
                                                    type: "fixedPoint",
                                                    precision: 2
                                                },
                                            },
                                            {
                                                caption: "Quy đổi ra tiền việt",
                                                dataField: "QuyDoiDU",
                                                dataType: "number",
                                                format: {
                                                    type: "fixedPoint",
                                                    precision: 2
                                                },
                                            }
                                        ]
                                    }
                                ]
                            }
                        ]
                    }

                ]
            },
            {
                caption: "Lũy kế bố trí kế hoạch vốn từ khởi công đến hết năm " + (year - 1),
                alignment: "center",
                columns: [
                    {
                        caption: "Tổng số",
                        dataField: "tongSoLuyKe",
                        dataType: "number",
                        format: {
                            type: "fixedPoint",
                            precision: 2
                        },
                    },
                    {
                        caption: "Vốn đối ứng",
                        alignment: "center",
                        columns: [
                            {
                                caption: "Tổng số",
                                dataField: "tongSoDU",
                                dataType: "number",
                                format: {
                                    type: "fixedPoint",
                                    precision: 2
                                },
                            }, {
                                caption: "Trong đó: ODA",
                                dataField: "ODADU",
                                dataType: "number",
                                format: {
                                    type: "fixedPoint",
                                    precision: 2
                                },
                            }
                        ]
                    },
                    {
                        caption: "Vốn nước ngoài (tính theo tiền việt)",
                        dataField: "vonNuocNgoai",
                        dataType: "number",
                        format: {
                            type: "fixedPoint",
                            precision: 2
                        },
                    }
                ]
            },
            {
                caption: "Lũy kế giải ngân từ khởi công đến hết 31/01 Năm " + year,
                alignment: "center",
                columns: [
                    {
                        caption: "Tổng số",
                        dataField: "tongSoLuyKe",
                        dataType: "number",
                        format: {
                            type: "fixedPoint",
                            precision: 2
                        },
                    },
                    {
                        caption: "Vốn đối ứng",
                        alignment: "center",
                        columns: [
                            {
                                caption: "Tổng số",
                                dataField: "tongSoDU",
                                dataType: "number",
                                format: {
                                    type: "fixedPoint",
                                    precision: 2
                                },
                            }, {
                                caption: "Trong đó: ODA",
                                dataField: "ODADU",
                                dataType: "number",
                                format: {
                                    type: "fixedPoint",
                                    precision: 2
                                },
                            }
                        ]
                    },
                    {
                        caption: "Vốn nước ngoài (tính theo tiền việt)",
                        dataField: "vonNuocNgoai",
                        dataType: "number",
                        format: {
                            type: "fixedPoint",
                            precision: 2
                        },
                    }
                ]
            },
            {
                caption: "Kế hoạch vốn đối ứng năm" + (year - 1) + " cho phép kéo dài (nếu có)",
                dataField: "luyKeGiaiNganNamNayNSTW",
                dataType: "number",
                format: {
                    type: "fixedPoint",
                    precision: 2
                },
            },
            {
                caption: "Kế hoạch năm " + year,
                alignment: "center",
                columns: [
                    {
                        caption: "Tổng số",
                        dataField: "tongSoLuyKe",
                        dataType: "number",
                        format: {
                            type: "fixedPoint",
                            precision: 2
                        },
                    },
                    {
                        caption: "Trong đó",
                        alignment: "center",
                        columns: [
                            {
                                caption: "Vốn đối ứng",
                                alignment: "center",
                                columns: [
                                    {
                                        caption: "Tổng số",
                                        dataField: "tongSoDU",
                                        dataType: "number",
                                        format: {
                                            type: "fixedPoint",
                                            precision: 2
                                        },
                                    }, {
                                        caption: "Trong đó: ODA",
                                        dataField: "ODADU",
                                        dataType: "number",
                                        format: {
                                            type: "fixedPoint",
                                            precision: 2
                                        },
                                    }
                                ]
                            },
                            {
                                caption: "Vốn nước ngoài (tính theo tiền việt)",
                                dataField: "vonNuocNgoai",
                                dataType: "number",
                                format: {
                                    type: "fixedPoint",
                                    precision: 2
                                },
                            }
                        ]
                    }

                ]
            },
            {
                caption: "Khối lượng thực hiện kể từ khởi công đến hết năm " + year,
                alignment: "center",
                columns: [
                    {
                        caption: "Tổng số",
                        dataField: "tongSoLuyKe",
                        dataType: "number",
                        format: {
                            type: "fixedPoint",
                            precision: 2
                        },
                    },
                    {
                        caption: "Trong đó",
                        alignment: "center",
                        columns: [
                            {
                                caption: "Vốn đối ứng",
                                alignment: "center",
                                columns: [
                                    {
                                        caption: "Tổng số",
                                        dataField: "tongSoDU",
                                        dataType: "number",
                                        format: {
                                            type: "fixedPoint",
                                            precision: 2
                                        },
                                    }, {
                                        caption: "Trong đó: ODA",
                                        dataField: "ODADU",
                                        dataType: "number",
                                        format: {
                                            type: "fixedPoint",
                                            precision: 2
                                        },
                                    }
                                ]
                            },
                            {
                                caption: "Vốn nước ngoài (tính theo tiền việt)",
                                dataField: "vonNuocNgoai",
                                dataType: "number",
                                format: {
                                    type: "fixedPoint",
                                    precision: 2
                                },
                            }
                        ]
                    }

                ]
            },
            {
                caption: "Giải ngân kế hoạch năm " + year + " (tính từ 01/01/ năm " + year + ") và KH năm " + (year - 1) + " kéo dài (nếu có) thực hiện từ khơi công đến hết tháng .../năm " + year,
                alignment: "center",
                columns: [
                    {
                        caption: "Tổng số",
                        dataField: "tongSoLuyKe",
                        dataType: "number",
                        format: {
                            type: "fixedPoint",
                            precision: 2
                        },
                    },
                    {
                        caption: "Trong đó",
                        alignment: "center",
                        columns: [
                            {
                                caption: "Vốn đối ứng",
                                alignment: "center",
                                columns: [
                                    {
                                        caption: "Tổng số",
                                        dataField: "tongSoDU",
                                        dataType: "number",
                                        format: {
                                            type: "fixedPoint",
                                            precision: 2
                                        },
                                    }, {
                                        caption: "Trong đó: ODA",
                                        dataField: "ODADU",
                                        dataType: "number",
                                        format: {
                                            type: "fixedPoint",
                                            precision: 2
                                        },
                                    }
                                ]
                            },
                            {
                                caption: "Vốn nước ngoài (tính theo tiền việt)",
                                dataField: "vonNuocNgoai",
                                dataType: "number",
                                format: {
                                    type: "fixedPoint",
                                    precision: 2
                                },
                            }
                        ]
                    }

                ]
            },
            {
                caption: "Ghi chú",
                dataField: "ghiChuNSTWa",
                format: "string"
            },
            {
                caption: "Thao tác",
                type: "buttons",
                alignment: "center",
                width: 110,
                buttons: ["edit", "delete"]
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
                column: "nSTW",
                summaryType: "sum",
                showInColumn: "nSTW",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "luyKeVonNamNayNSTW",
                summaryType: "sum",
                showInColumn: "luyKeVonNamNayNSTW",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            }, {
                column: "luyKeGiaiNganNamNayNSTW",
                summaryType: "sum",
                showInColumn: "luyKeGiaiNganNamNayNSTW",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "keHoachVonNamTruocKeoDaiNSTW",
                summaryType: "sum",
                showInColumn: "keHoachVonNamTruocKeoDaiNSTW",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "keHoachVonNamNayNSTW",
                summaryType: "sum",
                showInColumn: "keHoachVonNamNayNSTW",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "khoiLuongThucHienNamNayNSTW",
                summaryType: "sum",
                showInColumn: "khoiLuongThucHienNamNayNSTW",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "giaiNganNamNayNSTW",
                summaryType: "sum",
                showInColumn: "giaiNganNamNayNSTW",
                dataType: "number",
                valueFormat: {
                    type: "fixedPoint",
                    precision: 2
                },
                displayFormat: "{0}"
            },
            {
                column: "giaiNganNamTruocKeoDaiNSTW",
                summaryType: "sum",
                showInColumn: "giaiNganNamTruocKeoDaiNSTW",
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
    
    
})






