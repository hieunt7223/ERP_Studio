var selectingNSTs = new Array(0);
var selectingNSTUs = new Array(0);
var selectingNODAs = new Array(0);
var congTrinhNganSachTinhs = new Array(0);
var congTrinhNganSachTWs = new Array(0);
var congTrinhNganSachODAs = new Array(0);
var nganSachHangNams = new Array(0);
var nganSachChiTietByLuyKe = new Array(0);
var nganSachChiTietDauNam = new Array(0);
var year;
var tenKeHoach = "";
var quyThang = 0;
var idBaoCao;
var status_DauNam;
var _tabAdd;
var loaikehoachlast = "daunam";
var tongnhucauvonlast;
var isKeHoachKeoDai = false;
var _quyThang;


//Xử lý với chỉnh sửa
$(function () {
    if (isEdit === 'true') {
        abp.ajax({
            url: '/api/app/giaiNgan/' + giaiNganId,
            type: 'get',
            async: false
        }).done(function (result_data) {
            tenKeHoach = result_data.tenKeHoach;
            trangThai = result_data.trangThai;
            if (result_data.trangThai === "DA_GUI") {
                $('#EditSave').attr('disabled', 'true');
            }
            year = result_data.nam;
            quyThang = result_data.quyThang;
            isKeHoachKeoDai = result_data.isKeHoachKeoDai;
        });

        abp.ajax({
            url: '/api/app/giaiNgan/' + giaiNganId + '/giaiNganChiTiet',
            type: 'get',
            async: false
        }).done(function (result_data) {
            var data = result_data;
            congTrinhNganSachTinhs = data;
            //lấy thông tin công trình 
            for (let i = 0; i < congTrinhNganSachTinhs.length; i++) {
                abp.ajax({
                    url: '/api/app/congTrinh/' + congTrinhNganSachTinhs[i].congTrinhId + '/congTrinhDetail',
                    type: 'get',
                    async: false
                }).done(function (data) {
                    congTrinhNganSachTinhs[i].tenCongTrinh = data.tenCongTrinh;
                    congTrinhNganSachTinhs[i].maSoDuAn = data.maSoDuAn;
                    congTrinhNganSachTinhs[i].soQuyetDinhDauTu = data.soQuyetDinhDauTu;
                    congTrinhNganSachTinhs[i].nST = data.nst;
                    congTrinhNganSachTinhs[i].loaiKhoanId = data.loaiKhoanId;
                    congTrinhNganSachTinhs[i].loaiCongTrinhId = data.loaiCongTrinhId;
                });
            }
            congTrinhNganSachTWs = data;
            //lấy thông tin công trình
            for (let i = 0; i < congTrinhNganSachTWs.length; i++) {
                abp.ajax({
                    url: '/api/app/congTrinh/' + congTrinhNganSachTWs[i].congTrinhId + '/congTrinhDetail',
                    type: 'get',
                    async: false
                }).done(function (data) {
                    congTrinhNganSachTWs[i].tenCongTrinh = data.tenCongTrinh;
                    congTrinhNganSachTWs[i].maSoDuAn = data.maSoDuAn;
                    congTrinhNganSachTWs[i].soQuyetDinhDauTu = data.soQuyetDinhDauTu;
                    congTrinhNganSachTWs[i].nSTW = data.nstw;
                    congTrinhNganSachTWs[i].loaiKhoanId = data.loaiKhoanId;
                    congTrinhNganSachTWs[i].loaiCongTrinhId = data.loaiCongTrinhId;
                });
            }
            LoadNST(congTrinhNganSachTinhs);
            LoadNSTW(congTrinhNganSachTWs);

            LoadODA(data);
            $('#TW').removeClass('active');
            $('#ODA').removeClass('active');
            _quyThang = quyThang;
        });

    }
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
            if (e.dataField === "luyKeVonNamNayNST" || e.dataField === "luyKeGiaiNganNamNayNST"
                || e.dataField === "keHoachVonNamTruocKeoDaiNST" || e.dataField === "keHoachVonNamNayNST"
                || e.dataField === "khoiLuongThucHienNamNayNST" || e.dataField === "giaiNganNamNayNST"
                || e.dataField === "giaiNganNamTruocKeoDaiNST" || e.dataField === "ghiChuNST") {
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
                cssClass: "edit_row"
            },
            {
                caption: "Kế hoạch vốn NS Tỉnh năm " + year + " cho phép kéo dài (nếu có)",
                dataField: "keHoachVonNamTruocKeoDaiNST",
                dataType: "number",
                format: "#,###",
                cssClass: "edit_row"
            },
            {
                caption: "Kế hoạch năm " + year,
                dataField: "keHoachVonNamNayNST",
                dataType: "number",
                format: "#,###",
                cssClass: "edit_row"
            },
            {
                caption: "Khối lượng thực hiện từ khởi công đến hết " + _quyThang + year,
                dataField: "khoiLuongThucHienNamNayNST",
                dataType: "number",
                format: "#,###",
                cssClass: "edit_row"
            },
            {
                caption: "Giải ngân KH năm " + year + "(tính từ 01/01 năm " + year + ") và kế hoạch năm " + (year - 1) + " kéo dài (nếu có) đến hết " + _quyThang + year,
                alignment: "center",
                columns: [
                    {
                        caption: "KH Năm " + year,
                        dataField: "giaiNganNamNayNST",
                        alignment: "center",
                        cssClass: "edit_row",
                        format: "#,###",
                    },
                    {
                        caption: "Kế hoạch năm " + (year - 1) + " kéo dài",
                        dataField: "giaiNganNamTruocKeoDaiNST",
                        dataType: "number",
                        format: "#,###",
                        cssClass: "edit_row"
                    }

                ]
            },
            {
                caption: "Ghi chú",
                dataField: "ghiChuNST",
                format: "string",
                cssClass: "edit_row"
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
            if (e.dataField === "luyKeVonNamNayNSTW" || e.dataField === "luyKeGiaiNganNamNayNSTW"
                || e.dataField === "keHoachVonNamTruocKeoDaiNSTW" || e.dataField === "keHoachVonNamNayNSTW"
                || e.dataField === "khoiLuongThucHienNamNayNSTW" || e.dataField === "giaiNganNamNayNSTW"
                || e.dataField === "giaiNganNamTruocKeoDaiNSTW" || e.dataField === "ghiChuNSTW") {
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
                cssClass: "edit_row"
            },
            {
                caption: "Kế hoạch vốn NSTW năm " + year + " cho phép kéo dài (nếu có)",
                dataField: "keHoachVonNamTruocKeoDaiNSTW",
                dataType: "number",
                format: "#,###",
                cssClass: "edit_row"
            },
            {
                caption: "Kế hoạch năm " + year,
                dataField: "keHoachVonNamNayNSTW",
                dataType: "number",
                format: "#,###",
                cssClass: "edit_row"
            },
            {
                caption: "Khối lượng thực hiện từ khởi công đến hết " + _quyThang + year,
                dataField: "khoiLuongThucHienNamNayNSTW",
                dataType: "number",
                format: "#,###",
                cssClass: "edit_row"
            },
            {
                caption: "Giải ngân KH năm " + year + "(tính từ 01/01 năm " + year + ") và kế hoạch năm " + (year - 1) + " kéo dài (nếu có) đến hết tháng " + _quyThang + year,
                alignment: "center",
                columns: [
                    {
                        caption: "KH Năm " + year,
                        dataField: "giaiNganNamNayNSTW",
                        alignment: "number",
                        format: "#,###",
                        cssClass: "edit_row"
                    },
                    {
                        caption: "Kế hoạch năm " + (year - 1) + " kéo dài",
                        dataField: "giaiNganNamTruocKeoDaiNSTW",
                        dataType: "number",
                        format: "#,###",
                        cssClass: "edit_row"
                    }

                ]
            },
            {
                caption: "Ghi chú",
                dataField: "ghiChuNSTW",
                format: "string",
                cssClass: "edit_row"
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



//Thêm báo cáo---------------------------------------------------------------------------
//change title
$("#Year").on('change', function () {
    $('#title_year').html($(this).val());
});
//Sự kiện check kế hoạch kéo dài
$("#KeHoachKeoGiai").change(function () {
    if (this.checked) {
        $(".isKeoDai").css("display", "flex");
        var dateTitle = "";
        if ($("#GiaiNganTheo").val() === "NAM") {
            dateTitle = "";
        } else if ($("#GiaiNganTheo").val() === "THANG") {
            dateTitle = "tháng " + $("#Thang").val();
        } else {
            dateTitle = "quý " + $("#Quy").val();
        }
        var str = "và kế hoạch năm " + ($('#Year').val() - 1) + " kéo dài đến hết " + dateTitle + " năm " + $('#Year').val()
        $("#kehoach").html(str);
    } else {
        $("#kehoach").html("");
        $(".isKeoDai").css("display", "none");
    }
});

$("#GiaiNganTheo").on('change', function () {
    var dateTitle = "";
    if ($("#GiaiNganTheo").val() === "NAM") {
        $(".thang").css("display", "none");
        $(".quy").css("display", "none");
        dateTitle = "";
    } else if ($("#GiaiNganTheo").val() === "THANG") {
        $(".thang").css("display", "block");
        $(".quy").css("display", "none");
        dateTitle = "tháng " + $("#Thang").val();
    } else {
        $(".quy").css("display", "block");
        $(".thang").css("display", "none");
        dateTitle = "quý " + $("#Quy").val();
    }
    var str = "và kế hoạch năm " + ($('#Year').val() - 1) + " kéo dài đến hết " + dateTitle + " năm " + $('#Year').val()
    $("#kehoach").html(str);
});

$("#Thang").on('change', function () {

    var dateTitle = "tháng " + $("#Thang").val();

    var str = "và kế hoạch năm " + ($('#Year').val() - 1) + " kéo dài đến hết " + dateTitle + " năm " + $('#Year').val()
    $("#kehoach").html(str);
});

$("#Quy").on('change', function () {

    var dateTitle = "quý " + $("#Quy").val();

    var str = "và kế hoạch năm " + ($('#Year').val() - 1) + " kéo dài đến hết " + dateTitle + " năm " + $('#Year').val()
    $("#kehoach").html(str);
});

//thêm nhu cầu vốn
$("#AddGiaiNgan").on('click', function () {
    year = $('#Year').val();
    var strUrl = '';
    if ($("#KeHoachKeoGiai").is(":checked")) {
        isKeHoachKeoDai = true;
        tenKeHoach = $('#GiaiNganTheo').val();
        if ($("#GiaiNganTheo").val() === "NAM") {
            strUrl += '&tenKeHoach=' + tenKeHoach;
            quyThang = 0;
            _quyThang = "";
        } else if ($("#GiaiNganTheo").val() === "THANG") {
            quyThang = $("#Thang").val();
            strUrl += '&tenKeHoach=' + tenKeHoach + '&quyThang=' + quyThang;
            _quyThang = "tháng " + $("#Thang").val()+"/";
        } else {
            quyThang = $("#Quy").val();
            strUrl += '&tenKeHoach=' + tenKeHoach + '&quyThang=' + quyThang;
            _quyThang = "quý " + $("#Quy").val() + "/";
        }
    } else {
        tenKeHoach = "";
        quyThang = 0;
        strUrl = '';
        isKeHoachKeoDai = false;
        _quyThang = "";
    }
    if (chuDauTuId !== '') {
        congTrinhNganSachODAs = [];
        congTrinhNganSachTinhs = [];
        congTrinhNganSachTWs = [];
        abp.ajax({
            url: '/api/app/giaiNgan/notificationIsNew/' + chuDauTuId + '?nam=' + year + strUrl,
            type: 'get',
            async: false
        }).done(function (data) {
            if (data.strNotification !== "") {
                abp.notify.info(data.strNotification);
            }
            else {
                $('#frameGiaiNgan').css("display", "block");
                $('#Year').attr('disabled', 'true');
                $('#KeHoachKeoGiai').attr('disabled', 'true');
                $('#GiaiNganTheo').attr('disabled', 'true');
                $('#Thang').attr('disabled', 'true');
                $('#Quy').attr('disabled', 'true');
                $('#AddGiaiNgan').attr('disabled', 'true');
                abp.ajax({
                    url: '/api/app/giaiNganChiTiet/dataIsNew/' + chuDauTuId + '?nam=' + year,
                    type: 'get',
                    async: false
                }).done(function (data) {
                    congTrinhNganSachTinhs = data;
                    //lấy thông tin công trình 
                    for (let i = 0; i < congTrinhNganSachTinhs.length; i++) {
                        abp.ajax({
                            url: '/api/app/congTrinh/' + congTrinhNganSachTinhs[i].congTrinhId + '/congTrinhDetail',
                            type: 'get',
                            async: false
                        }).done(function (data) {
                            congTrinhNganSachTinhs[i].tenCongTrinh = data.tenCongTrinh;
                            congTrinhNganSachTinhs[i].maSoDuAn = data.maSoDuAn;
                            congTrinhNganSachTinhs[i].soQuyetDinhDauTu = data.soQuyetDinhDauTu;
                            congTrinhNganSachTinhs[i].nST = data.nst;
                            congTrinhNganSachTinhs[i].loaiKhoanId = data.loaiKhoanId;
                            congTrinhNganSachTinhs[i].loaiCongTrinhId = data.loaiCongTrinhId;
                        });
                    }
                    congTrinhNganSachTWs = data;
                    //lấy thông tin công trình
                    for (let i = 0; i < congTrinhNganSachTWs.length; i++) {
                        abp.ajax({
                            url: '/api/app/congTrinh/' + congTrinhNganSachTWs[i].congTrinhId + '/congTrinhDetail',
                            type: 'get',
                            async: false
                        }).done(function (data) {
                            congTrinhNganSachTWs[i].tenCongTrinh = data.tenCongTrinh;
                            congTrinhNganSachTWs[i].maSoDuAn = data.maSoDuAn;
                            congTrinhNganSachTWs[i].soQuyetDinhDauTu = data.soQuyetDinhDauTu;
                            congTrinhNganSachTWs[i].nSTW = data.nstw;
                            congTrinhNganSachTWs[i].loaiKhoanId = data.loaiKhoanId;
                            congTrinhNganSachTWs[i].loaiCongTrinhId = data.loaiCongTrinhId;
                        });
                    }
                    LoadNST(congTrinhNganSachTinhs);
                    LoadNSTW(congTrinhNganSachTWs);
                    $('#TW').removeClass('active');
                    $('#ODA').removeClass('active');
                });
            }

        });
    } else {
        abp.notify.info(messages.NotBaoCao);
    }

});


//Lưu, gửi khi thêm mới------------------------------------------------------------------
//Lưu báo cáo
$("#Save").on('click', function () {
    Save("DANG_SOAN");
});

//Gửi báo cáo
$("#Send").on('click', function () {
    Save("DA_GUI");
});

// Lưu dữ liệu
function Save(status) {
    var date = null;
    if (status=="DA_GUI") {
         date = new Date().getDate() + '/' + (new Date().getMonth() + 1) + '/' + new Date().getFullYear();
    }
    
    var tongGiaiNgan = congTrinhNganSachTinhs.map(o => o.giaiNganNamNayNST).reduce((a, c) => { return a + c }) +
        congTrinhNganSachTinhs.map(o => o.giaiNganNamTruocKeoDaiNST).reduce((a, c) => { return a + c }) +
        congTrinhNganSachTWs.map(o => o.giaiNganNamNayNSTW).reduce((a, c) => { return a + c }) +
        congTrinhNganSachTWs.map(o => o.giaiNganNamTruocKeoDaiNSTW).reduce((a, c) => { return a + c });

    var input = {
        nam: year,
        quyThang: quyThang,
        chuDauTuId: chuDauTuId,
        isKeHoachKeoDai: isKeHoachKeoDai,
        tenKeHoach: tenKeHoach,
        trangThai: status,
        tongGiaiNgan: tongGiaiNgan,
        ngayGui: date
    };

    $.ajax({
        url: '/api/app/giaiNgan',
        type: 'Post',
        contentType: "application/json; charset=utf-8",
        async: false,
        data: JSON.stringify(input)
    }).done(function (data) {

        var giaiNganId = data.id;
        for (var i = 0; i < congTrinhNganSachTinhs.length; i++) {
            abp.ajax({
                url: '/api/app/giaiNganChiTiet',
                type: 'post',
                async: false,
                data: JSON.stringify({
                    "giaiNganId": giaiNganId,
                    "loaiKhoanId": congTrinhNganSachTinhs[i].loaiKhoanId,
                    "loaiCongTrinhId": congTrinhNganSachTinhs[i].loaiCongTrinhId,
                    "congTrinhId": congTrinhNganSachTinhs[i].congTrinhId,

                    "keHoachVonNSTChiTietId": congTrinhNganSachTinhs[i].keHoachVonNSTChiTietId,
                    "keHoachVonNSTWChiTietId": congTrinhNganSachTinhs[i].keHoachVonNSTWChiTietId,
                    "luyKeVonNamNayNST": congTrinhNganSachTinhs[i].luyKeVonNamNayNST,
                    "luyKeGiaiNganNamNayNST": congTrinhNganSachTinhs[i].luyKeGiaiNganNamNayNST,
                    "keHoachVonNamTruocKeoDaiNST": congTrinhNganSachTinhs[i].keHoachVonNamTruocKeoDaiNST,
                    "keHoachVonNamNayNST": congTrinhNganSachTinhs[i].keHoachVonNamNayNST,
                    "khoiLuongThucHienNamNayNST": congTrinhNganSachTinhs[i].khoiLuongThucHienNamNayNST,
                    "giaiNganNamNayNST": congTrinhNganSachTinhs[i].giaiNganNamNayNST,
                    "giaiNganNamTruocKeoDaiNST": congTrinhNganSachTinhs[i].giaiNganNamTruocKeoDaiNST,
                    "ghiChuNST": congTrinhNganSachTinhs[i].ghiChuNST,
                    
                    "luyKeVonNamNayNSTW": congTrinhNganSachTWs[i].luyKeVonNamNayNSTW,
                    "luyKeGiaiNganNamNayNSTW": congTrinhNganSachTWs[i].luyKeGiaiNganNamNayNSTW,
                    "keHoachVonNamTruocKeoDaiNSTW": congTrinhNganSachTWs[i].keHoachVonNamTruocKeoDaiNSTW,
                    "keHoachVonNamNayNSTW": congTrinhNganSachTWs[i].keHoachVonNamNayNSTW,
                    "khoiLuongThucHienNamNayNSTW": congTrinhNganSachTWs[i].khoiLuongThucHienNamNayNSTW,
                    "giaiNganNamNayNSTW": congTrinhNganSachTWs[i].giaiNganNamNayNSTW,
                    "giaiNganNamTruocKeoDaiNSTW": congTrinhNganSachTWs[i].giaiNganNamTruocKeoDaiNSTW,
                    "ghiChuNSTW": congTrinhNganSachTWs[i].ghiChuNSTW,
                    
                    "luyKeVonNamNayODA": 0,
                    "luyKeGiaiNganNamNayODA": 0,
                    "keHoachVonNamTruocKeoDaiODA": 0,
                    "keHoachVonNamNayODA": 0,
                    "khoiLuongThucHienNamNayODA": 0,
                    "giaiNganNamNayODA": 0,
                    "giaiNganNamTruocKeoDaiODA": 0,
                    "ghiChuODA": "",
                })
            }).done(function (data) {
            });
        }
        abp.notify.info(messages.SuccessfullyCreate);
        window.location.href = '/GiaiNgan/List';
    }).fail(function () {
        abp.notify.info(messages.NOtSuccessfullyCreate);
    });
}


//Lưu, gửi dữ liệu chỉnh sửa
//Lưu báo cáo
$("#EditSave").on('click', function () {
    SaveEdit("DANG_SOAN");

});

//Gửi báo cáo
$("#EditSend").on('click', function () {
    SaveEdit("DA_GUI");
});
//Lưu dữ liệu
function SaveEdit(status) {
    var date = null;
    if (status == "DA_GUI") {
        date = new Date().getDate() + '/' + (new Date().getMonth() + 1) + '/' + new Date().getFullYear();
    }
    var tongGiaiNgan = congTrinhNganSachTinhs.map(o => o.giaiNganNamNayNST).reduce((a, c) => { return a + c }) +
        congTrinhNganSachTinhs.map(o => o.giaiNganNamTruocKeoDaiNST).reduce((a, c) => { return a + c }) +
        congTrinhNganSachTWs.map(o => o.giaiNganNamNayNSTW).reduce((a, c) => { return a + c }) +
        congTrinhNganSachTWs.map(o => o.giaiNganNamTruocKeoDaiNSTW).reduce((a, c) => { return a + c });

    var input = {
        nam: year,
        quyThang: quyThang,
        chuDauTuId: chuDauTuId,
        isKeHoachKeoDai: isKeHoachKeoDai,
        tenKeHoach: tenKeHoach,
        trangThai: status,
        tongGiaiNgan: tongGiaiNgan,
        ngayGui: date
    };

    $.ajax({
        url: '/api/app/giaiNgan/' + giaiNganId,
        type: 'Put',
        contentType: "application/json; charset=utf-8",
        async: false,
        data: JSON.stringify(input)
    }).done(function (data) {

        var giaiNganId = data.id;
        for (var i = 0; i < congTrinhNganSachTinhs.length; i++) {
            abp.ajax({
                url: '/api/app/giaiNganChiTiet/' + congTrinhNganSachTinhs[i].id,
                type: 'put',
                async: false,
                data: JSON.stringify({
                    "giaiNganId": giaiNganId,
                    "loaiKhoanId": congTrinhNganSachTinhs[i].loaiKhoanId,
                    "loaiCongTrinhId": congTrinhNganSachTinhs[i].loaiCongTrinhId,
                    "congTrinhId": congTrinhNganSachTinhs[i].congTrinhId,

                    "keHoachVonNSTChiTietId": congTrinhNganSachTinhs[i].keHoachVonNSTChiTietId,
                    "keHoachVonNSTWChiTietId": congTrinhNganSachTinhs[i].keHoachVonNSTWChiTietId,
                    "luyKeVonNamNayNST": congTrinhNganSachTinhs[i].luyKeVonNamNayNST,
                    "luyKeGiaiNganNamNayNST": congTrinhNganSachTinhs[i].luyKeGiaiNganNamNayNST,
                    "keHoachVonNamTruocKeoDaiNST": congTrinhNganSachTinhs[i].keHoachVonNamTruocKeoDaiNST,
                    "keHoachVonNamNayNST": congTrinhNganSachTinhs[i].keHoachVonNamNayNST,
                    "khoiLuongThucHienNamNayNST": congTrinhNganSachTinhs[i].khoiLuongThucHienNamNayNST,
                    "giaiNganNamNayNST": congTrinhNganSachTinhs[i].giaiNganNamNayNST,
                    "giaiNganNamTruocKeoDaiNST": congTrinhNganSachTinhs[i].giaiNganNamTruocKeoDaiNST,
                    "ghiChuNST": congTrinhNganSachTinhs[i].ghiChuNST,

                    "luyKeVonNamNayNSTW": congTrinhNganSachTWs[i].luyKeVonNamNayNSTW,
                    "luyKeGiaiNganNamNayNSTW": congTrinhNganSachTWs[i].luyKeGiaiNganNamNayNSTW,
                    "keHoachVonNamTruocKeoDaiNSTW": congTrinhNganSachTWs[i].keHoachVonNamTruocKeoDaiNSTW,
                    "keHoachVonNamNayNSTW": congTrinhNganSachTWs[i].keHoachVonNamNayNSTW,
                    "khoiLuongThucHienNamNayNSTW": congTrinhNganSachTWs[i].khoiLuongThucHienNamNayNSTW,
                    "giaiNganNamNayNSTW": congTrinhNganSachTWs[i].giaiNganNamNayNSTW,
                    "giaiNganNamTruocKeoDaiNSTW": congTrinhNganSachTWs[i].giaiNganNamTruocKeoDaiNSTW,
                    "ghiChuNSTW": congTrinhNganSachTWs[i].ghiChuNSTW,

                    "luyKeVonNamNayODA": 0,
                    "luyKeGiaiNganNamNayODA": 0,
                    "keHoachVonNamTruocKeoDaiODA": 0,
                    "keHoachVonNamNayODA": 0,
                    "khoiLuongThucHienNamNayODA": 0,
                    "giaiNganNamNayODA": 0,
                    "giaiNganNamTruocKeoDaiODA": 0,
                    "ghiChuODA": "",
                })
            }).done(function (data) {
            });
        }
        abp.notify.info(messages.SuccessfullyCreate);
        window.location.href = '/GiaiNgan/List';
    }).fail(function () {
        abp.notify.info(messages.NOtSuccessfullyCreate);
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

