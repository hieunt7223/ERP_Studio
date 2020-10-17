var createModal = new abp.ModalManager(abp.appPath + 'BaoCaoNCVHangNam/CongTrinh/CreateModal');
var selectingNSTs = new Array(0);
var selectingNSTUs = new Array(0);
var selectingNODAs = new Array(0);
var congTrinhNganSachTinhs = new Array(0);
var congTrinhNganSachTWs = new Array(0);
var congTrinhNganSachODAs = new Array(0);
var baoCaoHangNamDauNams = new Array(0);
var nhuCauVonChiTietByLuyKe = new Array(0);
var nhuCauVonChiTietDauNam = new Array(0);
var year;
var loaikehoach;
var idBaoCao;
var status_DauNam;
var status_DieuChinh=null;
var _tabAdd;
var loaikehoachlast = "daunam";
var tongnhucauvonlast;
var thoiGiaGuiDauNam = null;


//Xử lý với chỉnh sửa
$(function () {
    if (isEdit === 'true') {
        loaikehoach = loaiKeHoach;
        abp.ajax({
            url: '/api/app/nhuCauKeHoachVon/' + kehoachNhuCauVonId,
            type: 'get',
            async: false
        }).done(function (result_data) {
            status_DauNam = result_data.trangThaiDauNam;
            status_DieuChinh = result_data.trangThaiDieuChinh;
            thoiGiaGuiDauNam = result_data.thoiGianGuiBaoCaoDauNam;
            year = result_data.tuNam;
            tongnhucauvonlast = result_data.tongNhuCauVonDauNam;
            if (status_DauNam == "DA_GUI" && loaikehoach === "DAU_NAM") {
                $('#EditSave').attr('disabled','true');
            }

            if (status_DieuChinh == "DA_GUI" && loaikehoach === "DIEU_CHINH") {
                $('#EditSave').attr('disabled', 'true');
            }
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

        ReplaceTextNoData();
    }
});


//Get dữ liệu ----------------------------------------------------------------------------

//Get dữ liệu edit------------------------------------------------------------------------
function getNSTEdit() {
    abp.ajax({
        url: '/api/app/nhuCauKeHoachVon/' + kehoachNhuCauVonId + '/nhuCauKeHoachVonChiTiet',
        type: 'get',
        async: false
    }).done(function (result_data) {
        nhuCauVonChiTietDauNam = result_data;
    });
    abp.ajax({
        url: '/api/app/congTrinh/byChuDauTuID/' + chuDauTuId,
        type: 'get',
        async: false
    }).done(function (data) {
        if (loaikehoach === "DIEU_CHINH") {
            let k = 0;
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
                            congTrinhNganSachTinhs[k].nST_von_dieuchinh = nhuCauVonChiTietDauNam[i].nhuCauVonDieuChinhNST;;
                            congTrinhNganSachTinhs[k].idChiTiet = nhuCauVonChiTietDauNam[i].id;
                            congTrinhNganSachTinhs[k].nhuCauVon = nhuCauVonChiTietDauNam[i].nhuCauVonDauNamNST;
                            k++;
                        }
                }

            }

        } else {
            let k = 0;
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
                            k++;
                        }
                }

            }
        }
    });
}
function getNSTWEdit() {

    abp.ajax({
        url: '/api/app/congTrinh/byChuDauTuID/' + chuDauTuId,
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
                            congTrinhNganSachTWs[k].nSTW_von_dieuchinh = nhuCauVonChiTietDauNam[i].nhuCauVonDieuChinhNSTW;
                            congTrinhNganSachTWs[k].nhuCauVonTW = nhuCauVonChiTietDauNam[i].nhuCauVonDauNamNSTW;
                            k++;
                        }
                }

            }

        } else {
            let k = 0;
            for (let i = 0; i < nhuCauVonChiTietDauNam.length; i++) {
                if (!nhuCauVonChiTietDauNam[i].isSelectDieuChinh) {
                    for (let j = 0; j < data.length; j++)
                        if (nhuCauVonChiTietDauNam[i].congTrinhID === data[j].id) {
                            congTrinhNganSachTWs.push(data[j]);
                            congTrinhNganSachTWs[k].TW = data[j].nstw;
                            congTrinhNganSachTWs[k].TW_LuyKeKhoiLuong = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocNSTW;
                            congTrinhNganSachTWs[k].TW_LuyKeVon = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocNSTW;
                            congTrinhNganSachTWs[k].ghiChuTW = nhuCauVonChiTietDauNam[i].ghiChuDauNamNSTW;
                            congTrinhNganSachTWs[k].nhuCauVonTW = nhuCauVonChiTietDauNam[i].nhuCauVonDauNamNSTW;
                            k++;
                        }
                }

            }
        }
    });
}
function getNSODAEdit() {
    abp.ajax({
        url: '/api/app/congTrinh/byChuDauTuID/' + chuDauTuId,
        type: 'get',
        async: false
    }).done(function (data) {
        if (loaikehoach === "DIEU_CHINH") {
            let k = 0;
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
                            congTrinhNganSachODAs[k].ghiChuODA_dieuchinh = nhuCauVonChiTietDauNam[i].nhuCauVonDieuChinhODA;
                            congTrinhNganSachODAs[k].nhuCauVonODA = nhuCauVonChiTietDauNam[i].nhuCauVonDauNamODA;
                            k++;
                        }
                }

            }

        } else {
            let k = 0;
            for (let i = 0; i < nhuCauVonChiTietDauNam.length; i++) {
                if (!nhuCauVonChiTietDauNam[i].isSelectDieuChinh) {
                    for (let j = 0; j < data.length; j++)
                        if (nhuCauVonChiTietDauNam[i].congTrinhID === data[j].id) {
                            congTrinhNganSachODAs.push(data[j]);
                            congTrinhNganSachODAs[k].nSTODA = data[j].oda;
                            congTrinhNganSachODAs[k].nSODA_LuyKeKhoiLuong = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocODA;
                            congTrinhNganSachODAs[k].nSODA_LuyKeVon = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocODA;
                            congTrinhNganSachODAs[k].ghiChuODA = nhuCauVonChiTietDauNam[i].ghiChuDauNamODA;
                            congTrinhNganSachODAs[k].nhuCauVonODA = nhuCauVonChiTietDauNam[i].nhuCauVonDauNamODA;
                            k++;
                        }
                }

            }
        }
    });
}
//----------------------------------------------------------------------------------------

// Get dữ liệu bởi chủ đầu tư--------------------------------------------------------------
// Ngân sách tỉnh
function getNSTByChuDauTuId() {
    abp.ajax({
        url: '/api/app/congTrinh/byChuDauTuID/' + chuDauTuId,
        type: 'get',
        async: false
    }).done(function (data) {

        if (loaikehoach === "DIEU_CHINH") {
            let k = 0;
            for (let j = 0; j < nhuCauVonChiTietDauNam.length; j++) {
                if (!nhuCauVonChiTietDauNam[j].isDeleteDieuChinh) {
                    for (let i = 0; i < data.length; i++) {
                        if (nhuCauVonChiTietDauNam[j].congTrinhID === data[i].id) {
                            congTrinhNganSachTinhs.push(data[i]);
                            congTrinhNganSachTinhs[k].nST = data[i].nst;
                            congTrinhNganSachTinhs[k].ghiChu_dieuchinh = "";
                            congTrinhNganSachTinhs[k].nST_LuyKeKhoiLuong = nhuCauVonChiTietDauNam[j].luyKeKhoiLuongNamTruocNST;
                            congTrinhNganSachTinhs[k].nST_LuyKeVon = nhuCauVonChiTietDauNam[j].nhuCauVonDauNamNST;
                            congTrinhNganSachTinhs[k].nhuCauVon = nhuCauVonChiTietDauNam[j].nhuCauVonDauNamNST;
                            congTrinhNganSachTinhs[k].ghiChu = nhuCauVonChiTietDauNam[j].ghiChuDauNamNST;
                            congTrinhNganSachTinhs[k].nST_KeHoachVonDaGiao = 0;
                            congTrinhNganSachTinhs[k].nST_Tang = 0;
                            congTrinhNganSachTinhs[k].nST_Giam = 0;
                            congTrinhNganSachTinhs[k].nST_von_dieuchinh = congTrinhNganSachTinhs[k].nST_KeHoachVonDaGiao + congTrinhNganSachTinhs[k].nST_Tang - congTrinhNganSachTinhs[k].nST_Giam;
                            congTrinhNganSachTinhs[k].idChiTiet = nhuCauVonChiTietDauNam[j].id;
                            k++;
                        }
                    }
                }

            }
        } else {
            data = data.filter(item => new Date(item.thoiGianThucHienTuNgay).getFullYear() <= year && new Date(item.thoiGianThucHienDenNgay).getFullYear() >= year);
            for (var i = 0; i < data.length; i++) {
                congTrinhNganSachTinhs.push(data[i]);
                congTrinhNganSachTinhs[i].nST = data[i].nst;
                congTrinhNganSachTinhs[i].nST_LuyKeKhoiLuong = 0;
                congTrinhNganSachTinhs[i].nST_LuyKeVon = 0;
                congTrinhNganSachTinhs[i].ghiChu = "";
                congTrinhNganSachTinhs[i].nhuCauVon = 0;
            }
            if (loaikehoachlast === 'daunam') {
                for (let j = 0; j < nhuCauVonChiTietByLuyKe.length; j++) {
                    if (!nhuCauVonChiTietByLuyKe[j].isSelectDieuChinh) {
                        for (let k = 0; k < congTrinhNganSachTinhs.length; k++) {

                            if (nhuCauVonChiTietByLuyKe[j].congTrinhID === congTrinhNganSachTinhs[k].id) {
                                congTrinhNganSachTinhs[k].nST_LuyKeKhoiLuong = nhuCauVonChiTietByLuyKe[j].luyKeKhoiLuongNamTruocNST;
                                congTrinhNganSachTinhs[k].nST_LuyKeVon = nhuCauVonChiTietByLuyKe[j].nhuCauVonDauNamNST;
                            }
                        }

                    }
                }
            } else {
                for (let j = 0; j < nhuCauVonChiTietByLuyKe.length; j++) {
                    if (!nhuCauVonChiTietByLuyKe[j].isDeleteDieuChinh) {
                        for (let k = 0; k < congTrinhNganSachTinhs.length; k++) {

                            if (nhuCauVonChiTietByLuyKe[j].congTrinhID === congTrinhNganSachTinhs[k].id) {
                                congTrinhNganSachTinhs[k].nST_LuyKeKhoiLuong = nhuCauVonChiTietByLuyKe[j].luyKeKhoiLuongNamTruocNST;
                                congTrinhNganSachTinhs[k].nST_LuyKeVon = nhuCauVonChiTietByLuyKe[j].nhuCauVonDieuChinhNST;
                            }
                        }
                    }

                }
            }

        }

        return congTrinhNganSachTinhs;
    });
}
// Ngân sách trung ương
function getTWByChuDauTuId() {
    abp.ajax({
        url: '/api/app/congTrinh/byChuDauTuID/' + chuDauTuId,
        type: 'get',
        async: false
    }).done(function (data) {

        if (loaikehoach === "DIEU_CHINH") {
            let k = 0;
            for (let j = 0; j < nhuCauVonChiTietDauNam.length; j++) {
                if (!nhuCauVonChiTietDauNam[j].isDeleteDieuChinh) {
                    for (let i = 0; i < data.length; i++) {
                        if (nhuCauVonChiTietDauNam[j].congTrinhID === data[i].id) {
                            congTrinhNganSachTWs.push(data[i]);
                            congTrinhNganSachTWs[k].TW = data[i].nstw;
                            congTrinhNganSachTinhs[k].ghiChuTW_dieuchinh = "";
                            congTrinhNganSachTWs[k].TW_LuyKeKhoiLuong = nhuCauVonChiTietDauNam[j].luyKeKhoiLuongNamTruocNSTW;
                            congTrinhNganSachTWs[k].TW_LuyKeVon = nhuCauVonChiTietDauNam[j].nhuCauVonDauNamNSTW;
                            congTrinhNganSachTWs[k].nhuCauVonTW = nhuCauVonChiTietDauNam[j].nhuCauVonDauNamNSTW;
                            congTrinhNganSachTWs[k].ghiChuTW = nhuCauVonChiTietDauNam[j].ghiChuDauNamNSTW;
                            congTrinhNganSachTWs[k].nSTW_KeHoachVonDaGiao = 0;
                            congTrinhNganSachTWs[k].nSTW_Tang = 0;
                            congTrinhNganSachTWs[k].nSTW_Giam = 0;
                            congTrinhNganSachTWs[k].nSTW_von_dieuchinh = congTrinhNganSachTWs[k].nSTW_KeHoachVonDaGiao + congTrinhNganSachTWs[k].nSTW_Tang - congTrinhNganSachTWs[k].nSTW_Giam;
                            k++;
                        }
                    }
                }


            }
        } else {
            data = data.filter(item => new Date(item.thoiGianThucHienTuNgay).getFullYear() <= year && new Date(item.thoiGianThucHienDenNgay).getFullYear() >= year);
            for (var i = 0; i < data.length; i++) {
                congTrinhNganSachTWs.push(data[i]);
                congTrinhNganSachTWs[i].TW = data[i].nstw;
                congTrinhNganSachTWs[i].TW_LuyKeKhoiLuong = 0;
                congTrinhNganSachTWs[i].TW_LuyKeVon = 0;
                congTrinhNganSachTWs[i].ghiChuTW = "";
                congTrinhNganSachTWs[i].nhuCauVonTW = 0;
            }
            if (loaikehoachlast === 'daunam') {
                for (let j = 0; j < nhuCauVonChiTietByLuyKe.length; j++) {
                    for (let k = 0; k < congTrinhNganSachTWs.length; k++) {
                        if (nhuCauVonChiTietByLuyKe[j].congTrinhID === congTrinhNganSachTWs[k].id) {
                            congTrinhNganSachTWs[k].TW_LuyKeKhoiLuong = nhuCauVonChiTietByLuyKe[j].luyKeKhoiLuongNamTruocNSTW;
                            congTrinhNganSachTWs[k].TW_LuyKeVon = nhuCauVonChiTietByLuyKe[j].nhuCauVonDauNamNSTW;
                        }
                    }
                }
            } else {
                for (let j = 0; j < nhuCauVonChiTietByLuyKe.length; j++) {
                    for (let k = 0; k < congTrinhNganSachTWs.length; k++) {
                        if (nhuCauVonChiTietByLuyKe[j].congTrinhID === congTrinhNganSachTWs[k].id) {
                            congTrinhNganSachTWs[k].TW_LuyKeKhoiLuong = nhuCauVonChiTietByLuyKe[j].luyKeKhoiLuongNamTruocNSTW;
                            congTrinhNganSachTWs[k].TW_LuyKeVon = nhuCauVonChiTietByLuyKe[j].nhuCauVonDieuChinhNSTW;
                        }
                    }
                }
            }

        }

        return congTrinhNganSachTWs;
    });
}
//Ngân sách ODA
function getNSODAByChuDauTuId() {
    abp.ajax({
        url: '/api/app/congTrinh/byChuDauTuID/' + chuDauTuId,
        type: 'get',
        async: false
    }).done(function (data) {
        data = data.filter(item => new Date(item.thoiGianThucHienTuNgay).getFullYear() <= year && new Date(item.thoiGianThucHienDenNgay).getFullYear() >= year);
        if (loaikehoach === "DIEU_CHINH") {
            let k = 0;
            for (let j = 0; j < nhuCauVonChiTietDauNam.length; j++) {
                if (!nhuCauVonChiTietDauNam[j].isDeleteDieuChinh) {
                    for (let i = 0; i < data.length; i++) {
                        if (nhuCauVonChiTietDauNam[j].congTrinhID === data[i].id) {
                            congTrinhNganSachODAs.push(data[i]);
                            congTrinhNganSachODAs[k].nSODA = data[i].oda;
                            congTrinhNganSachTinhs[k].ghiChuODA_dieuchinh = "";
                            congTrinhNganSachODAs[k].nSODA_LuyKeKhoiLuong = nhuCauVonChiTietDauNam[j].luyKeKhoiLuongNamTruocODA;
                            congTrinhNganSachODAs[k].nSODA_LuyKeVon = nhuCauVonChiTietDauNam[j].nhuCauVonDauNamODA;
                            congTrinhNganSachODAs[k].nhuCauVonODA = nhuCauVonChiTietDauNam[j].nhuCauVonDauNamODA;
                            congTrinhNganSachODAs[k].ghiChuODA = nhuCauVonChiTietDauNam[j].ghiChuDauNamODA;
                            congTrinhNganSachODAs[k].nSODA_KeHoachVonDaGiao = 0;
                            congTrinhNganSachODAs[k].nSODA_Giam = 0;
                            congTrinhNganSachODAs[k].nSODA_Tang = 0;
                            congTrinhNganSachODAs[k].nSODA_von_dieuchinh = congTrinhNganSachODAs[k].nSODA_KeHoachVonDaGiao + congTrinhNganSachODAs[k].nSODA_Tang - congTrinhNganSachODAs[k].nSODA_Giam;
                            k++;
                        }
                    }
                }

            }
        } else {
            for (var i = 0; i < data.length; i++) {
                congTrinhNganSachODAs.push(data[i]);
                congTrinhNganSachODAs[i].nSODA = data[i].oda;
                congTrinhNganSachODAs[i].nSODA_LuyKeKhoiLuong = 0;
                congTrinhNganSachODAs[i].nSODA_LuyKeVon = 0;
                congTrinhNganSachODAs[i].ghiChuODA = "";
                congTrinhNganSachODAs[i].nhuCauVonODA = 0;
            }
            if (loaikehoachlast === 'daunam') {
                for (let j = 0; j < nhuCauVonChiTietByLuyKe.length; j++) {
                    for (let k = 0; k < congTrinhNganSachODAs.length; k++) {
                        if (nhuCauVonChiTietByLuyKe[j].congTrinhID === congTrinhNganSachODAs[k].id) {
                            congTrinhNganSachODAs[k].nSODA_LuyKeKhoiLuong = nhuCauVonChiTietByLuyKe[j].luyKeKhoiLuongNamTruocODA;
                            congTrinhNganSachODAs[k].nSODA_LuyKeVon = nhuCauVonChiTietByLuyKe[j].nhuCauVonDieuChinhODA;
                        }
                    }
                }
            } else {
                for (let j = 0; j < nhuCauVonChiTietByLuyKe.length; j++) {
                    for (let k = 0; k < congTrinhNganSachODAs.length; k++) {
                        if (nhuCauVonChiTietByLuyKe[j].congTrinhID === congTrinhNganSachODAs[k].id) {
                            congTrinhNganSachODAs[k].nSODA_LuyKeKhoiLuong = nhuCauVonChiTietByLuyKe[j].luyKeKhoiLuongNamTruocODA;
                            congTrinhNganSachODAs[k].nSODA_LuyKeVon = nhuCauVonChiTietByLuyKe[j].nhuCauVonDieuChinhODA;
                        }
                    }
                }
            }


        }
        return congTrinhNganSachODAs;
    });
}
//-----------------------------------------------------------------------------------------

// Load dữ liệu đầu năm-------------------------------------------------------------------

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
                caption: "Thông tin chung của công trình",
                alignment: "center",
                columns: [{
                    caption: "Danh sách công trình",
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
                    caption: "Mã Loại - Khoản",
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
                            caption: "Trong đó: NST",
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
                editorOptions: {
                    format: "#,###.##",
                    showClearButton: true
                },
                cssClass: "edit_row"
            },
            {
                caption: "Ghi chú",
                dataField: "ghiChu",
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

// Ngân sách trung ương
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
        editing: {
            mode: "cell",
            allowUpdating: true,
            allowDeleting: true,
            useIcons: true,
            confirmDelete: false
        },
        onEditorPreparing: function (e) {
            if (e.dataField === "nhuCauVonTW" || e.dataField === "ghiChuTW") {
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
                caption: "Thông tin chung của công trình",
                alignment: "center",
                columns: [{
                    caption: "Danh sách công trình",
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
                    caption: "Mã Loại - Khoản",
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
                            caption: "Trong đó: NSTW",
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
                editorOptions: {
                    format: "#,###.##",
                    showClearButton: true
                },
                cssClass: "edit_row"
            },
            {
                caption: "Ghi chú",
                dataField: "ghiChuTW",
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

// Ngân sách ODA
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
        editing: {
            mode: "cell",
            allowUpdating: true,
            allowDeleting: true,
            useIcons: true,
            confirmDelete: false
        },
        onEditorPreparing: function (e) {
            if (e.dataField === "nhuCauVonODA" || e.dataField === "ghiChuODA") {
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
                caption: "Thông tin chung của công trình",
                alignment: "center",
                columns: [{
                    caption: "Danh sách công trình",
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
                    caption: "Mã Loại - Khoản",
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
                            caption: "Trong đó: NODA",
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
                editorOptions: {
                    format: "#,###.##",
                    showClearButton: true
                },
                cssClass: "edit_row"
            },
            {
                caption: "Ghi chú",
                dataField: "ghiChuODA",
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
//----------------------------------------------------------------------------------------

// Load dữ liệu điều chỉnh----------------------------------------------------------------
// Ngân sách tỉnh
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
        editing: {
            mode: "cell",
            allowUpdating: true,
            allowDeleting: true,
            useIcons: true,
            confirmDelete: false
        },
        onEditorPreparing: function (e) {
            if (e.dataField === "nST_Tang" || e.dataField === "nST_Giam" || e.dataField === "ghiChu_dieuchinh") {
                e.editorOptions.disabled = false;
            } else {
                e.editorOptions.disabled = true;
            }
        },
        onRowUpdated: setValueNcvSauDieuChinhNST,
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
                    caption: "Danh sách công trình",
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
                    caption: "Mã Loại - Khoản",
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
                            caption: "Trong đó: NST",
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
                    editorOptions: {
                        format: "#,###.##",
                        showClearButton: true
                    },
                    cssClass: "edit_row"
                },
                {
                    caption: "Điều chỉnh tăng",
                    dataField: "nST_Tang",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                    editorOptions: {
                        format: "#,###.##",
                        showClearButton: true
                    },
                    cssClass: "edit_row"

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
// Ngân sách trung ương
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
        editing: {
            mode: "cell",
            allowUpdating: true,
            allowDeleting: true,
            useIcons: true,
            confirmDelete: false
        },
        onEditorPreparing: function (e) {
            if (e.dataField === "nSTW_Giam" || e.dataField === "nSTW_Tang" || e.dataField === "ghiChuTW_dieuchinh") {
                e.editorOptions.disabled = false;
            } else {
                e.editorOptions.disabled = true;
            }
        },
        onRowUpdated: setValueNcvSauDieuChinhTW,
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
                    caption: "Danh sách công trình",
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
                    caption: "Mã Loại - Khoản",
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
                            caption: "Trong đó: NSTW",
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
                    editorOptions: {
                        format: "#,###.##",
                        showClearButton: true
                    },
                    cssClass: "edit_row"
                },
                {
                    caption: "Điều chỉnh tăng",
                    dataField: "nSTW_Tang",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                    editorOptions: {
                        format: "#,###.##",
                        showClearButton: true
                    },
                    cssClass: "edit_row"
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
// Ngân sách địa phương
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
        editing: {
            mode: "cell",
            allowUpdating: true,
            allowDeleting: true,
            useIcons: true,
            confirmDelete: false
        },
        onEditorPreparing: function (e) {
            if (e.dataField === "nSODA_Giam" || e.dataField === "nSODA_Tang" || e.dataField === "ghiChuODA_dieuchinh") {
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
                caption: "Thông tin chung của công trình",
                alignment: "center",
                columns: [{
                    caption: "Danh sách công trình",
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
                    caption: "Mã Loại - Khoản",
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
                            caption: "Trong đó: NODA",
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
                    editorOptions: {
                        format: "#,###.##",
                        showClearButton: true
                    },
                    cssClass: "edit_row"
                },
                {
                    caption: "Điều chỉnh tăng",
                    dataField: "nSODA_Tang",
                    dataType: "number",
                    format: {
                        type: "fixedPoint",
                        precision: 2
                    },
                    editorOptions: {
                        format: "#,###.##",
                        showClearButton: true
                    },
                    cssClass: "edit_row"
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
//----------------------------------------------------------------------------------------

// Sự kiện -------------------------------------------------------------------------------
// Thêm công trình vào báo cáo------------------------------------------------------------
// Tìm kiếm công trình
$('#Search_CongTrinh').click(function () {
    abp.ajax({
        url: '/api/app/congTrinh/search?keyword=' + $('#keyword').val() + '&&chuDauTu=' + chuDauTuId + '&&SkipCount=0&&MaxResultCount=1000',
        type: 'get',
        async: false
    }).done(function (data) {
        GetDataGridMultiple(data.items);
    });
});

function OpenModal(btn) {
    _tabAdd = $(btn).attr("_typeAdd");
    abp.ajax({
        url: '/api/app/congTrinh/byChuDauTuID/' + chuDauTuId,
        type: 'get',
        async: false
    }).done(function (data) {
        GetDataGridMultiple(data);
    });
}
// Get dữ liệu vào data grid
function GetDataGridMultiple(data) {
    switch (_tabAdd) {
        case "NST": {
            data = data.filter(ar => !congTrinhNganSachTinhs.find(rm => (rm.id === ar.id)));
            break;
        }
        case "TW": {
            data = data.filter(ar => !congTrinhNganSachTWs.find(rm => (rm.id === ar.id)));
            break;
        }
        case "ODA": {
            data = data.filter(ar => !congTrinhNganSachODAs.find(rm => (rm.id === ar.id)));
            break;
        }
    }

   

    $("#dataGirdMultiple").dxDataGrid({
        noDataText: messages.no_data,
        dataSource: data,
        showBorders: true,
        selection: {
            mode: "multiple"
        },
        paging: {
            pageSize: 10
        },
        filterRow: {
            visible: false
        },
        selection: {
            mode: "multiple",
           
        },
        onSelectionChanged: SelectionChanged,
        columns: [
            {
                dataField: "tenCongTrinh",
                caption: "Tên công trình"
            },
            {
                dataField: "chuDauTu",
                caption: "Chủ đầu tư"
            },
            {
                dataField: "maSoDuAn",
                caption: "Mã số dự án"
            },
            {
                dataField: "maChuong",
                caption: "Mã chương"
            },
            {
                dataField: "maLoaiKhoan",
                caption: "Mã loại - khoản"
            }
        ]
    });

    // xóa select all
    var dataGrid = $("#dataGirdMultiple").dxDataGrid("instance");
    dataGrid.clearSelection();


}
// Select data
function SelectionChanged(selectedItems) {
    switch (_tabAdd) {
        case "NST": {
            selectingNSTs = selectedItems.selectedRowsData;
            break;
        }
        case "TW": {
            selectingNSTUs = selectedItems.selectedRowsData;
            break;
        }
        case "ODA": {
            selectingNODAs = selectedItems.selectedRowsData;
            break;
        }
    }

}
// Thêm công trình vào báo cáo
function InsertDataRow() {
    switch (_tabAdd) {
        case "NST": {
            for (let i = 0; i < selectingNSTs.length; i++) {
                congTrinhNganSachTinhs.push(selectingNSTs[i]);
                if (loaikehoach === "DIEU_CHINH") {
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].nST = selectingNSTs[i].nst;
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].ghiChu_dieuchinh = "";
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].nST_LuyKeKhoiLuong = 0;
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].nST_LuyKeVon = 0;
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].ghiChu = "";
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].nST_KeHoachVonDaGiao = 0;
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].nST_Giam = 0;
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].nST_Tang = 0;
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].nST_von_dieuchinh = 0;
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].nhuCauVon = 0;
                } else {
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].nST = selectingNSTs[i].nst;
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].nST_LuyKeKhoiLuong = 0;
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].nST_LuyKeVon = 0;
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].ghiChu = "";
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].nhuCauVon = 0;
                }
            }
            $("#gridNST").dxDataGrid("instance").refresh();
            break;
        }
        case "TW": {
            for (let i = 0; i < selectingNSTUs.length; i++) {
                congTrinhNganSachTWs.push(selectingNSTUs[i]);
                if (loaikehoach === "DIEU_CHINH") {
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].TW = selectingNSTs[i].nstw;
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].ghiChuTW_dieuchinh = "";
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].TW_LuyKeKhoiLuong = 0;
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].TW_LuyKeVon = 0;
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].ghiChuTW = "";
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].nSTW_KeHoachVonDaGiao = 0;
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].nSTW_Giam = 0;
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].nSTW_Tang = 0;
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].nSTW_von_dieuchinh = 0;
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].nhuCauVonTW = 0;
                } else {
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].TW = selectingNSTs[i].nstw;
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].TW_LuyKeKhoiLuong = 0;
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].TW_LuyKeVon = 0;
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].ghiChuTW = "";
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].nhuCauVonTW = 0;
                }
            }
            $("#gridTW").dxDataGrid("instance").refresh();
            break;
        }
        case "ODA": {
            for (let i = 0; i < selectingNODAs.length; i++) {
                congTrinhNganSachODAs.push(selectingNODAs[i]);
                if (loaikehoach === "DIEU_CHINH") {
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].nSODA = selectingNSTs[i].oda;
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].ghiChuODA_dieuchinh = "";
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].nSODA_LuyKeKhoiLuong = 0;
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].nSODA_LuyKeVon = 0;
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].ghiChuODA = "";
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].nSODA_KeHoachVonDaGiao = 0;
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].nSODA_Giam = 0;
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].nSODA_Tang = 0;
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].nSODA_von_dieuchinh = 0;
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].nhuCauVonODA = 0;
                } else {
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].nSODA = selectingNSTs[i].oda;
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].nSODA_LuyKeKhoiLuong = 0;
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].nSODA_LuyKeVon = 0;
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].ghiChuODA = "";
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].nhuCauVonODA = 0;
                }
            }
            $("#gridNSODA").dxDataGrid("instance").refresh();
            break;
        }
    }
    $('#myModal').modal('hide');

}
// Thêm công trình
$('.row_congtrinh').on('click', '.btn_add_congtrinh', function () {
    $('#myModal').modal('hide');
    createModal.open();
});
//Hiển thị dữ liệu sau khi thêm mới công trình
createModal.onResult(function () {
    abp.ajax({
        url: '/api/app/congTrinh/byChuDauTuID/' + chuDauTuId,
        type: 'get',
        async: false
    }).done(function (data) {
        GetDataGridMultiple(data);
        $('#myModal').modal('show');
    });
});

//---------------------------------------------------------------------------------------

// Tổng hợp dữ liệu báo cáo--------------------------------------------------------------
function getDataBaoCao() {
    baoCaoHangNamDauNams = [];
    //ẩn Oda
    congTrinhNganSachODAs = [];
    if (loaikehoach === "DIEU_CHINH") {
        for (let i = 0; i < congTrinhNganSachTinhs.length; i++) {
            baoCaoHangNamDauNams.push(congTrinhNganSachTinhs[i]);
        }
        for (let j = 0; j < congTrinhNganSachTWs.length; j++) {
            let kt = baoCaoHangNamDauNams.find(x => x.id === congTrinhNganSachTWs[j].id);
            if (kt) {
                kt.TW = congTrinhNganSachTWs[j].TW;
                kt.TW_LuyKeKhoiLuong = congTrinhNganSachTWs[j].TW_LuyKeKhoiLuong;
                kt.TW_LuyKeVon = congTrinhNganSachTWs[j].TW_LuyKeVon;
                kt.ghiChuTW = congTrinhNganSachTWs[j].ghiChuTW;
                kt.nSTW_KeHoachVonDaGiao = congTrinhNganSachTWs[j].nSTW_KeHoachVonDaGiao;
                kt.nSTW_Giam = congTrinhNganSachTWs[j].nSTW_Giam;
                kt.nSTW_Tang = congTrinhNganSachTWs[j].nSTW_Tang;
                kt.ghiChuTW_dieuchinh = congTrinhNganSachTWs[j].ghiChuTW_dieuchinh;
                kt.nhuCauVonTW = congTrinhNganSachTWs[j].nhuCauVonTW;
            } else {
                baoCaoHangNamDauNams.push(congTrinhNganSachTWs[j]);
            }
        }
        for (let k = 0; k < congTrinhNganSachODAs.length; k++) {
            let kt = baoCaoHangNamDauNams.find(x => x.id === congTrinhNganSachODAs[k].id);
            if (kt) {

                kt.nSODA = congTrinhNganSachODAs[k].nSODA;
                kt.nSODA_LuyKeKhoiLuong = congTrinhNganSachODAs[k].nSODA_LuyKeKhoiLuong;
                kt.nSODA_LuyKeVon = congTrinhNganSachODAs[k].nSODA_LuyKeVon;
                kt.ghiChuODA = congTrinhNganSachODAs[k].ghiChuODA;
                kt.nSODA_KeHoachVonDaGiao = congTrinhNganSachODAs[k].nSODA_KeHoachVonDaGiao;
                kt.nSODA_Giam = congTrinhNganSachODAs[k].nSODA_Giam;
                kt.nSODA_Tang = congTrinhNganSachODAs[k].nSODA_Tang;
                kt.ghiChuODA_dieuchinh = congTrinhNganSachODAs[k].ghiChuODA_dieuchinh;
                kt.nhuCauVonODA = congTrinhNganSachODAs[k].nhuCauVonODA;
            } else {
                baoCaoHangNamDauNams.push(congTrinhNganSachODAs[k]);
            }
        }
    } else {
        for (let i = 0; i < congTrinhNganSachTinhs.length; i++) {
            baoCaoHangNamDauNams.push(congTrinhNganSachTinhs[i]);
        }
        for (let j = 0; j < congTrinhNganSachTWs.length; j++) {
            let kt = baoCaoHangNamDauNams.find(x => x.id === congTrinhNganSachTWs[j].id);
            if (kt) {
                kt.TW = congTrinhNganSachTWs[j].TW;
                kt.TW_LuyKeKhoiLuong = congTrinhNganSachTWs[j].TW_LuyKeKhoiLuong;
                kt.TW_LuyKeVon = congTrinhNganSachTWs[j].TW_LuyKeVon;
                kt.ghiChuTW = congTrinhNganSachTWs[j].ghiChuTW;
                kt.nhuCauVonTW = congTrinhNganSachTWs[j].nhuCauVonTW;
            } else {
                baoCaoHangNamDauNams.push(congTrinhNganSachTWs[j]);
            }
        }
        for (let k = 0; k < congTrinhNganSachODAs.length; k++) {
            let kt = baoCaoHangNamDauNams.find(x => x.id === congTrinhNganSachODAs[k].id);
            if (kt) {

                kt.nSODA = congTrinhNganSachODAs[k].nSODA;
                kt.nSODA_LuyKeKhoiLuong = congTrinhNganSachODAs[k].nSODA_LuyKeKhoiLuong;
                kt.nSODA_LuyKeVon = congTrinhNganSachODAs[k].nSODA_LuyKeVon;
                kt.ghiChuODA = congTrinhNganSachODAs[k].ghiChuODA;
                kt.nhuCauVonODA = congTrinhNganSachODAs[k].nhuCauVonODA;
            } else {
                baoCaoHangNamDauNams.push(congTrinhNganSachODAs[k]);
            }
        }

    }
}
//---------------------------------------------------------------------------------------

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

    getDataBaoCao();
    if (loaikehoach === 'DIEU_CHINH') {

        let data = nhuCauVonChiTietDauNam.filter(ar => !baoCaoHangNamDauNams.find(rm => (rm.idChiTiet === ar.id)));
        for (let i = 0; i < data.length; i++) {
            abp.ajax({
                url: '/api/app/nhuCauKeHoachVonDieuChinhChiTiet/' + data[i].id,
                type: 'put',
                async: false
            }).done(function () {

            });
        }

        let tongNcvNST = 0;
        let tongNcvNSTW = 0;

        let tongNcvNSTTang = 0;
        let tongNcvNSTWTang = 0;

        let tongNcvNSTGiam = 0;
        let tongNcvNSTWGiam = 0;
        if (congTrinhNganSachTinhs.length > 0) {
            tongNcvNST = congTrinhNganSachTinhs.map(o => o.nST_KeHoachVonDaGiao).reduce((a, c) => { return a + c });
            tongNcvNSTTang = congTrinhNganSachTinhs.map(o => o.nST_Tang).reduce((a, c) => { return a + c });
            tongNcvNSTGiam = congTrinhNganSachTinhs.map(o => o.nST_Giam).reduce((a, c) => { return a + c });
        }

        if (congTrinhNganSachTWs.length > 0) {
            tongNcvNSTW = congTrinhNganSachTWs.map(o => o.nSTW_KeHoachVonDaGiao).reduce((a, c) => { return a + c });
            tongNcvNSTWGiam = congTrinhNganSachTWs.map(o => o.nSTW_Giam).reduce((a, c) => { return a + c });
            tongNcvNSTWTang = congTrinhNganSachTWs.map(o => o.nSTW_Tang).reduce((a, c) => { return a + c });
        }

        let tongNhuCauVon = tongNcvNST + tongNcvNSTW;

        let giam = tongNcvNSTGiam + tongNcvNSTWGiam;

        let tang = tongNcvNSTTang + tongNcvNSTWTang;

        var date = null;

        if (status === "DA_GUI") {
            var today = new Date();
            date = today.getDate() + '/' + (today.getMonth() + 1) + '/' + today.getFullYear();
        }

        let input = {
            tuNam: year,
            denNam: year,
            giaiDoanNam: year,
            chuDauTuID: chuDauTuId,
            tenKeHoach: "HANG_NAM",
            trangThaiDauNam: status_DauNam,
            trangThaiDieuChinh: status,
            tongNhuCauVonDauNam: tongnhucauvonlast,
            tongNhuCauVonDieuChinh: tongNhuCauVon + tang - giam,
            thoiGianGuiBaoCaoDauNam: thoiGiaGuiDauNam,
            thoiGianGuiBaoCaoDieuChinh:date
        };

        $.ajax({
            url: '/api/app/nhuCauKeHoachVon/' + idBaoCao,
            type: 'Put',
            contentType: "application/json; charset=utf-8",
            async: false,
            data: JSON.stringify(input)
        }).done(function (data) {
            let idNhuCauVon = data.id;
            for (let i = 0; i < baoCaoHangNamDauNams.length; i++) {
                let input = {
                    "nhuCauKeHoachVonID": idNhuCauVon,
                    "congTrinhID": baoCaoHangNamDauNams[i].id,
                    "luyKeKhoiLuongNamTruocNST": baoCaoHangNamDauNams[i].nST_LuyKeKhoiLuong,
                    "luyKeVonNamTruocNST": baoCaoHangNamDauNams[i].nST_LuyKeVon,
                    "nhuCauVonDauNamNST": baoCaoHangNamDauNams[i].nhuCauVon,
                    "dieuChinhGiamNST": baoCaoHangNamDauNams[i].nST_Giam,
                    "dieuChinhTangNST": baoCaoHangNamDauNams[i].nST_Tang,
                    "nhuCauVonDieuChinhNST": (baoCaoHangNamDauNams[i].nST_KeHoachVonDaGiao + baoCaoHangNamDauNams[i].nST_Tang - baoCaoHangNamDauNams[i].nST_Giam),
                    "ghiChuDauNamNST": baoCaoHangNamDauNams[i].ghiChu,
                    "ghiChuDieuChinhNST": baoCaoHangNamDauNams[i].ghiChu_dieuchinh,
                    "ghiChuChuyenVienDauNamNST": "",
                    "ghiChuChuyenVienDieuChinhNST": "",
                    "isSelectNST": false,
                    "luyKeKhoiLuongNamTruocNSTW": baoCaoHangNamDauNams[i].TW_LuyKeKhoiLuong,
                    "luyKeVonNamTruocNSTW": baoCaoHangNamDauNams[i].TW_LuyKeVon,
                    "nhuCauVonDauNamNSTW": baoCaoHangNamDauNams[i].nhuCauVonTW,
                    "dieuChinhGiamNSTW": baoCaoHangNamDauNams[i].nSTW_Giam,
                    "dieuChinhTangNSTW": baoCaoHangNamDauNams[i].nSTW_Tang,
                    "nhuCauVonDieuChinhNSTW": baoCaoHangNamDauNams[i].nSTW_KeHoachVonDaGiao + baoCaoHangNamDauNams[i].nSTW_Tang - baoCaoHangNamDauNams[i].nSTW_Giam,
                    "ghiChuDauNamNSTW": baoCaoHangNamDauNams[i].ghiChuTW,
                    "ghiChuDieuChinhNSTW": baoCaoHangNamDauNams[i].ghiChuTW_dieuchinh,
                    "ghiChuChuyenVienDauNamNSTW": "",
                    "ghiChuChuyenVienDieuChinhNSTW": "",
                    "isSelectNSTW": false,
                    "luyKeKhoiLuongNamTruocODA": 0,
                    "luyKeVonNamTruocODA": 0,
                    "nhuCauVonDauNamODA": 0,
                    "dieuChinhGiamODA": 0,
                    "dieuChinhTangODA": 0,
                    "nhuCauVonDieuChinhODA": 0,
                    "ghiChuDauNamODA": "",
                    "ghiChuDieuChinhODA": "",
                    "ghiChuChuyenVienDauNamODA": "",
                    "ghiChuChuyenVienDieuChinhODA": "",
                    "isSelectODA": false,
                    "isSelect": false,
                    "isDeleteDieuChinh": false
                };
                if (baoCaoHangNamDauNams[i].idChiTiet !== undefined) {
                    abp.ajax({
                        url: '/api/app/nhuCauKeHoachVonChiTiet/' + baoCaoHangNamDauNams[i].idChiTiet,
                        type: 'Put',
                        async: false,
                        data: JSON.stringify(input)
                    }).done(function (data) {
                    });
                } else {
                    input = checkUndefinded(input);
                    input.isSelectDieuChinh = true;
                    abp.ajax({
                        url: '/api/app/nhuCauKeHoachVonChiTiet',
                        type: 'post',
                        async: false,
                        data: JSON.stringify(input)
                    }).done(function (data) {
                    });
                }

            }
            abp.notify.info(messages.SuccessfullyCreate);
            window.location.href = '/BaoCaoNCVHangNam/List';
        }).fail(function () {
            abp.notify.info(messages.NOtSuccessfullyCreate);
        });
    } else {

        let tongNcvNST = 0;
        let tongNcvNSTW = 0;
        if (congTrinhNganSachTinhs.length > 0) {
            tongNcvNST = congTrinhNganSachTinhs.map(o => o.nhuCauVon).reduce((a, c) => { return a + c });
        }
        if (congTrinhNganSachTWs.length > 0) {
            tongNcvNSTW = congTrinhNganSachTWs.map(o => o.nhuCauVonTW).reduce((a, c) => { return a + c });
        }
        var tongNhuCauVon = tongNcvNST + tongNcvNSTW;
        var date = null;
        if (status === "DA_GUI") {
            var today = new Date();
            date = today.getDate() + '/' + (today.getMonth() + 1) + '/' + today.getFullYear();
        }
        var input = {
            tuNam: year,
            denNam: year,
            giaiDoanNam: year,
            chuDauTuID: chuDauTuId,
            tenKeHoach: "HANG_NAM",
            trangThaiDauNam: status,
            tongNhuCauVonDauNam: tongNhuCauVon,
            tongNhuCauVonDieuChinh: 0,
            thoiGianGuiBaoCaoDauNam: date,
            thoiGianGuiBaoCaoDieuChinh: null,
            trangThaiDieuChinh: status_DieuChinh,
        };

        $.ajax({
            url: '/api/app/nhuCauKeHoachVon',
            type: 'Post',
            contentType: "application/json; charset=utf-8",
            async: false,
            data: JSON.stringify(input)
        }).done(function (data) {

            var idNhuCauVon = data.id;
            for (var i = 0; i < baoCaoHangNamDauNams.length; i++) {
                abp.ajax({
                    url: '/api/app/nhuCauKeHoachVonChiTiet',
                    type: 'post',
                    async: false,
                    data: JSON.stringify({
                        "nhuCauKeHoachVonID": idNhuCauVon,
                        "congTrinhID": baoCaoHangNamDauNams[i].id,
                        "luyKeKhoiLuongNamTruocNST": baoCaoHangNamDauNams[i].nST_LuyKeKhoiLuong,
                        "luyKeVonNamTruocNST": baoCaoHangNamDauNams[i].nST_LuyKeVon,
                        "nhuCauVonDauNamNST": baoCaoHangNamDauNams[i].nhuCauVon,
                        "dieuChinhGiamNST": 0,
                        "dieuChinhTangNST": 0,
                        "nhuCauVonDieuChinhNST": 0,
                        "ghiChuDauNamNST": baoCaoHangNamDauNams[i].ghiChu,
                        "ghiChuDieuChinhNST": "",
                        "ghiChuChuyenVienDauNamNST": "",
                        "ghiChuChuyenVienDieuChinhNST": "",
                        "isSelectNST": false,
                        "luyKeKhoiLuongNamTruocNSTW": baoCaoHangNamDauNams[i].TW_LuyKeKhoiLuong,
                        "luyKeVonNamTruocNSTW": baoCaoHangNamDauNams[i].TW_LuyKeVon,
                        "nhuCauVonDauNamNSTW": baoCaoHangNamDauNams[i].nhuCauVonTW,
                        "dieuChinhGiamNSTW": 0,
                        "dieuChinhTangNSTW": 0,
                        "nhuCauVonDieuChinhNSTW": 0,
                        "ghiChuDauNamNSTW": baoCaoHangNamDauNams[i].ghiChuTW,
                        "ghiChuDieuChinhNSTW": "",
                        "ghiChuChuyenVienDauNamNSTW": "",
                        "ghiChuChuyenVienDieuChinhNSTW": "",
                        "isSelectNSTW": false,
                        "luyKeKhoiLuongNamTruocODA": 0,
                        "luyKeVonNamTruocODA": 0,
                        "nhuCauVonDauNamODA": 0,
                        "dieuChinhGiamODA": 0,
                        "dieuChinhTangODA": 0,
                        "nhuCauVonDieuChinhODA": 0,
                        "ghiChuDauNamODA": '',
                        "ghiChuDieuChinhODA": "",
                        "ghiChuChuyenVienDauNamODA": "",
                        "ghiChuChuyenVienDieuChinhODA": "",
                        "isSelectODA": false,
                        "isSelect": false,
                        "isDeleteDieuChinh": false
                    })
                }).done(function (data) {
                });
            }
            abp.notify.info(messages.SuccessfullyCreate);
            window.location.href = '/BaoCaoNCVHangNam/List';
        }).fail(function () {
            abp.notify.info(messages.NOtSuccessfullyCreate);
        });
    }
}
//---------------------------------------------------------------------------------------

//Lưu, gửi khi edit----------------------------------------------------------------------
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
    getDataBaoCao();
    if (loaikehoach === 'DIEU_CHINH') {
        let data = nhuCauVonChiTietDauNam.filter(ar => !baoCaoHangNamDauNams.find(rm => (rm.idChiTiet === ar.id)));
        for (let i = 0; i < data.length; i++) {
            abp.ajax({
                url: '/api/app/nhuCauKeHoachVonDieuChinhChiTiet/' + data[i].id,
                type: 'put',
                async: false
            }).done(function () {

            });
        }
        let tongNcvNST = 0;
        let tongNcvNSTW = 0;

        let tongNcvNSTTang = 0;
        let tongNcvNSTWTang = 0;

        let tongNcvNSTGiam = 0;
        let tongNcvNSTWGiam = 0;
        if (congTrinhNganSachTinhs.length > 0) {
            tongNcvNST = congTrinhNganSachTinhs.map(o => o.nST_KeHoachVonDaGiao).reduce((a, c) => { return a + c });
            tongNcvNSTTang = congTrinhNganSachTinhs.map(o => o.nST_Tang).reduce((a, c) => { return a + c });
            tongNcvNSTGiam = congTrinhNganSachTinhs.map(o => o.nST_Giam).reduce((a, c) => { return a + c });
        }

        if (congTrinhNganSachTWs.length > 0) {
            tongNcvNSTW = congTrinhNganSachTWs.map(o => o.nSTW_KeHoachVonDaGiao).reduce((a, c) => { return a + c });
            tongNcvNSTWGiam = congTrinhNganSachTWs.map(o => o.nSTW_Giam).reduce((a, c) => { return a + c });
            tongNcvNSTWTang = congTrinhNganSachTWs.map(o => o.nSTW_Tang).reduce((a, c) => { return a + c });
        }

        let tongNhuCauVon = tongNcvNST + tongNcvNSTW;
        let giam = tongNcvNSTGiam + tongNcvNSTWGiam;
        let tang = tongNcvNSTTang + tongNcvNSTWTang;

        var date = null;
        if (status === "DA_GUI") {
            var today = new Date();
            date = today.getDate() + '/' + (today.getMonth() + 1) + '/' + today.getFullYear();
        }

        let input = {
            tuNam: year,
            denNam: year,
            giaiDoanNam: year,
            chuDauTuID: chuDauTuId,
            tenKeHoach: "HANG_NAM",
            trangThaiDauNam: status_DauNam,
            trangThaiDieuChinh: status,
            tongNhuCauVonDauNam: tongnhucauvonlast,
            tongNhuCauVonDieuChinh: tongNhuCauVon + tang - giam,
            thoiGianGuiBaoCaoDauNam: thoiGiaGuiDauNam,
            thoiGianGuiBaoCaoDieuChinh: date
        };

        $.ajax({
            url: '/api/app/nhuCauKeHoachVon/' + idBaoCao,
            type: 'Put',
            contentType: "application/json; charset=utf-8",
            async: false,
            data: JSON.stringify(input)
        }).done(function (data) {
            let idNhuCauVon = data.id;
            for (let i = 0; i < baoCaoHangNamDauNams.length; i++) {
                let input = {
                    "nhuCauKeHoachVonID": idNhuCauVon,
                    "congTrinhID": baoCaoHangNamDauNams[i].id,
                    "luyKeKhoiLuongNamTruocNST": baoCaoHangNamDauNams[i].nST_LuyKeKhoiLuong,
                    "luyKeVonNamTruocNST": baoCaoHangNamDauNams[i].nST_LuyKeVon,
                    "nhuCauVonDauNamNST": baoCaoHangNamDauNams[i].nhuCauVon,
                    "dieuChinhGiamNST": baoCaoHangNamDauNams[i].nST_Giam,
                    "dieuChinhTangNST": baoCaoHangNamDauNams[i].nST_Tang,
                    "nhuCauVonDieuChinhNST": (baoCaoHangNamDauNams[i].nST_KeHoachVonDaGiao + baoCaoHangNamDauNams[i].nST_Tang - baoCaoHangNamDauNams[i].nST_Giam),
                    "ghiChuDauNamNST": baoCaoHangNamDauNams[i].ghiChu,
                    "ghiChuDieuChinhNST": baoCaoHangNamDauNams[i].ghiChu_dieuchinh,
                    "ghiChuChuyenVienDauNamNST": "",
                    "ghiChuChuyenVienDieuChinhNST": "",
                    "isSelectNST": false,
                    "luyKeKhoiLuongNamTruocNSTW": baoCaoHangNamDauNams[i].TW_LuyKeKhoiLuong,
                    "luyKeVonNamTruocNSTW": baoCaoHangNamDauNams[i].TW_LuyKeVon,
                    "nhuCauVonDauNamNSTW": baoCaoHangNamDauNams[i].nhuCauVonTW,
                    "dieuChinhGiamNSTW": baoCaoHangNamDauNams[i].nSTW_Giam,
                    "dieuChinhTangNSTW": baoCaoHangNamDauNams[i].nSTW_Tang,
                    "nhuCauVonDieuChinhNSTW": baoCaoHangNamDauNams[i].nSTW_KeHoachVonDaGiao + baoCaoHangNamDauNams[i].nSTW_Tang - baoCaoHangNamDauNams[i].nSTW_Giam,
                    "ghiChuDauNamNSTW": baoCaoHangNamDauNams[i].ghiChuTW,
                    "ghiChuDieuChinhNSTW": baoCaoHangNamDauNams[i].ghiChuTW_dieuchinh,
                    "ghiChuChuyenVienDauNamNSTW": "",
                    "ghiChuChuyenVienDieuChinhNSTW": "",
                    "isSelectNSTW": false,
                    "luyKeKhoiLuongNamTruocODA": 0,
                    "luyKeVonNamTruocODA": 0,
                    "nhuCauVonDauNamODA": 0,
                    "dieuChinhGiamODA": 0,
                    "dieuChinhTangODA": 0,
                    "nhuCauVonDieuChinhODA": 0,
                    "ghiChuDauNamODA": "",
                    "ghiChuDieuChinhODA": "",
                    "ghiChuChuyenVienDauNamODA": "",
                    "ghiChuChuyenVienDieuChinhODA": "",
                    "isSelectODA": false,
                    "isSelect": false,
                    "isDeleteDieuChinh": false
                };
                if (baoCaoHangNamDauNams[i].idChiTiet !== undefined) {
                    abp.ajax({
                        url: '/api/app/nhuCauKeHoachVonChiTiet/' + baoCaoHangNamDauNams[i].idChiTiet,
                        type: 'Put',
                        async: false,
                        data: JSON.stringify(input)
                    }).done(function (data) {
                    });
                } else {
                    input = checkUndefinded(input);
                    input.isSelectDieuChinh = true;
                    abp.ajax({
                        url: '/api/app/nhuCauKeHoachVonChiTiet',
                        type: 'post',
                        async: false,
                        data: JSON.stringify(input)
                    }).done(function (data) {
                    });
                }

            }
            abp.notify.info(messages.SuccessfullyCreate);
            window.location.href = '/BaoCaoNCVHangNam/List';
        }).fail(function () {
            abp.notify.info(messages.NOtSuccessfullyCreate);
        });
    } else {
        let data = nhuCauVonChiTietDauNam.filter(ar => !baoCaoHangNamDauNams.find(rm => (rm.idChiTiet === ar.id)));
        for (let i = 0; i < data.length; i++) {
            abp.ajax({
                url: '/api/app/nhuCauKeHoachVonChiTiet/' + data[i].id,
                type: 'delete',
                async: false
            }).done(function () {

            });
        }
        let tongNcvNST = 0;
        let tongNcvNSTW = 0;
        if (congTrinhNganSachTinhs.length > 0) {
            tongNcvNST = congTrinhNganSachTinhs.map(o => o.nhuCauVon).reduce((a, c) => { return a + c });
        }
        if (congTrinhNganSachTWs.length > 0) {
            tongNcvNSTW = congTrinhNganSachTWs.map(o => o.nhuCauVonTW).reduce((a, c) => { return a + c });
        }
        var tongNhuCauVon = tongNcvNST + tongNcvNSTW;

        //+ congTrinhNganSachODAs.map(o => o.nhuCauVonODA).reduce((a, c) => { return a + c });

        var date = null;
        if (status === "DA_GUI") {
            var today = new Date();
            date = today.getDate() + '/' + (today.getMonth() + 1) + '/' + today.getFullYear();
        }

        var input = {
            tuNam: year,
            denNam: year,
            giaiDoanNam: year,
            chuDauTuID: chuDauTuId,
            tenKeHoach: "HANG_NAM",
            trangThaiDauNam: status,
            trangThaiDieuChinh: status_DieuChinh,
            tongNhuCauVonDauNam: tongNhuCauVon,
            tongNhuCauVonDieuChinh: 0,
            thoiGianGuiBaoCaoDauNam: date,
            thoiGianGuiBaoCaoDieuChinh:null
        };

        $.ajax({
            url: '/api/app/nhuCauKeHoachVon/' + idBaoCao,
            type: 'Put',
            contentType: "application/json; charset=utf-8",
            async: false,
            data: JSON.stringify(input)
        }).done(function (data) {

            var idNhuCauVon = data.id;
            for (var i = 0; i < baoCaoHangNamDauNams.length; i++) {
                let input = {
                    "nhuCauKeHoachVonID": idNhuCauVon,
                    "congTrinhID": baoCaoHangNamDauNams[i].id,
                    "luyKeKhoiLuongNamTruocNST": baoCaoHangNamDauNams[i].nST_LuyKeKhoiLuong,
                    "luyKeVonNamTruocNST": baoCaoHangNamDauNams[i].nST_LuyKeVon,
                    "nhuCauVonDauNamNST": baoCaoHangNamDauNams[i].nhuCauVon,
                    "dieuChinhGiamNST": 0,
                    "dieuChinhTangNST": 0,
                    "nhuCauVonDieuChinhNST": 0,
                    "ghiChuDauNamNST": baoCaoHangNamDauNams[i].ghiChu,
                    "ghiChuDieuChinhNST": "",
                    "ghiChuChuyenVienDauNamNST": "",
                    "ghiChuChuyenVienDieuChinhNST": "",
                    "isSelectNST": false,
                    "luyKeKhoiLuongNamTruocNSTW": baoCaoHangNamDauNams[i].TW_LuyKeKhoiLuong,
                    "luyKeVonNamTruocNSTW": baoCaoHangNamDauNams[i].TW_LuyKeVon,
                    "nhuCauVonDauNamNSTW": baoCaoHangNamDauNams[i].nhuCauVonTW,
                    "dieuChinhGiamNSTW": 0,
                    "dieuChinhTangNSTW": 0,
                    "nhuCauVonDieuChinhNSTW": 0,
                    "ghiChuDauNamNSTW": baoCaoHangNamDauNams[i].ghiChuTW,
                    "ghiChuDieuChinhNSTW": "",
                    "ghiChuChuyenVienDauNamNSTW": "",
                    "ghiChuChuyenVienDieuChinhNSTW": "",
                    "isSelectNSTW": false,
                    "luyKeKhoiLuongNamTruocODA": 0,
                    "luyKeVonNamTruocODA": 0,
                    "nhuCauVonDauNamODA": 0,
                    "dieuChinhGiamODA": 0,
                    "dieuChinhTangODA": 0,
                    "nhuCauVonDieuChinhODA": 0,
                    "ghiChuDauNamODA": "",
                    "ghiChuDieuChinhODA": "",
                    "ghiChuChuyenVienDauNamODA": "",
                    "ghiChuChuyenVienDieuChinhODA": "",
                    "isSelectODA": false,
                    "isSelect": false,
                    "isDeleteDieuChinh": false
                };
                if (baoCaoHangNamDauNams[i].idChiTiet !== undefined) {
                    abp.ajax({
                        url: '/api/app/nhuCauKeHoachVonChiTiet/' + baoCaoHangNamDauNams[i].idChiTiet,
                        type: 'put',
                        async: false,
                        data: JSON.stringify(input)
                    }).done(function (data) {
                    });
                } else {
                    abp.ajax({
                        url: '/api/app/nhuCauKeHoachVonChiTiet',
                        type: 'post',
                        async: false,
                        data: JSON.stringify(input)
                    }).done(function (data) {
                    });
                }

            }
            abp.notify.info(messages.SuccessfullyCreate);
            window.location.href = '/BaoCaoNCVHangNam/List';
        }).fail(function () {
            abp.notify.info(messages.NOtSuccessfullyCreate);
        });
    }
}

//xuất excel
$('#Export').click(function () {
    loadPanel.show();
    if (loaiKeHoach == "DIEU_CHINH") {
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
        })
    }

})

//---------------------------------------------------------------------------------------

//Thêm báo cáo---------------------------------------------------------------------------
//change title
$("#Year").on('change', function () {
    $('#title_year').html($(this).val());
});
$("#LoaiKeHoach").on('change', function () {
    $('#title_loaikehoach').html($("#LoaiKeHoach option:selected").text());
});

//thêm nhu cầu vốn
$("#AddKeHoachNhuCauVon").on('click', function () {
    year = $('#Year').val();
    loaikehoach = $("#LoaiKeHoach").val();

    if (chuDauTuId !== '') {
        congTrinhNganSachODAs = [];
        congTrinhNganSachTinhs = [];
        congTrinhNganSachTWs = [];
        abp.ajax({
            url: '/api/app/nhuCauKeHoachVon/notificationIsNew?tenKeHoach=HANG_NAM&loaikehoach=' + loaikehoach + '&nam=' + year + '&chuDauTuID=' + chuDauTuId,
            type: 'get',
            async: false
        }).done(function (data) {
            if (data.strNotification !== null) {
                abp.notify.info(data.strNotification);
            }
            else if (data.strNotification === null && data.id !== "00000000-0000-0000-0000-000000000000") {
                idBaoCao = data.id;
                status_DauNam = data.trangThaiDauNam;
                status_DieuChinh = data.trangThaiDieuChinh;
                thoiGiaGuiDauNam = data.thoiGianGuiBaoCaoDauNam;
                abp.ajax({
                    url: '/api/app/nhuCauKeHoachVon/' + data.id,
                    type: 'get',
                    async: false
                }).done(function (result_data) {
                    tongnhucauvonlast = result_data.tongNhuCauVonDauNam;
                });
                abp.ajax({
                    url: '/api/app/nhuCauKeHoachVon/' + data.id + '/nhuCauKeHoachVonChiTiet',
                    type: 'get',
                    async: false
                }).done(function (result_data) {

                    nhuCauVonChiTietDauNam = result_data;
                    for (var i = 0; i < nhuCauVonChiTietDauNam.length; i++) {
                        if (!nhuCauVonChiTietDauNam[i].isSelectDieuChinh) {
                            nhuCauVonChiTietDauNam[i].isDeleteDieuChinh = false;
                        }

                    }
                    

                });
                $('#frameBaoCao').show();
                getNSTByChuDauTuId();
                LoadNSTDieuChinh(congTrinhNganSachTinhs);
                getTWByChuDauTuId();
                LoadNSTWDieuChinh(congTrinhNganSachTWs);
                getNSODAByChuDauTuId();
                LoadNSODADieuChinh(congTrinhNganSachODAs);
                $('#TW').removeClass('active');
                $('#ODA').removeClass('active');
                $('#AddKeHoachNhuCauVon').attr('disabled', 'true');
                $('#Year').attr('disabled', 'true');
                $('#LoaiKeHoach').attr('disabled', 'true');
            } else if (data.strNotification === null && data.idNhuCauKeHoachVonLuyKe !== "00000000-0000-0000-0000-000000000000") {
                abp.ajax({
                    url: '/api/app/nhuCauKeHoachVon/' + data.idNhuCauKeHoachVonLuyKe + '/nhuCauKeHoachVonChiTiet',
                    type: 'get',
                    async: false
                }).done(function (result_data) {
                    status_DauNam = result_data.trangThaiDauNam;
                    status_DieuChinh = result_data.trangThaiDieuChinh;
                    nhuCauVonChiTietByLuyKe = result_data;
                    if (result_data.trangThaiDieuChinh !== null) {
                        loaikehoachlast = 'dieuchinh';

                    }
                    thoiGiaGuiDauNam = result_data.thoiGianGuiBaoCaoDauNam;
                });

                $('#frameBaoCao').show();
                getNSTByChuDauTuId();
                LoadNST(congTrinhNganSachTinhs);
                getTWByChuDauTuId();
                LoadTW(congTrinhNganSachTWs);
                getNSODAByChuDauTuId();
                LoadNSODA(congTrinhNganSachODAs);
                $('#TW').removeClass('active');
                $('#ODA').removeClass('active');
                $('#AddKeHoachNhuCauVon').attr('disabled', 'true');
                $('#Year').attr('disabled', 'true');
                $('#LoaiKeHoach').attr('disabled', 'true');
            } else {
                $('#frameBaoCao').show();
                getNSTByChuDauTuId();
                LoadNST(congTrinhNganSachTinhs);
                getTWByChuDauTuId();
                LoadTW(congTrinhNganSachTWs);
                getNSODAByChuDauTuId();
                LoadNSODA(congTrinhNganSachODAs);
                $('#TW').removeClass('active');
                $('#ODA').removeClass('active');
                $('#AddKeHoachNhuCauVon').attr('disabled', 'true');
                $('#Year').attr('disabled', 'true');
                $('#LoaiKeHoach').attr('disabled', 'true');
            }

        });
    } else {
        abp.notify.info(messages.NotBaoCao);
    }
    
});
//--------------------------------------------------------------------------------------


//Check Undefinded----------------------------------------------------------------------
function checkUndefinded(input) {
    input.nhuCauVonDieuChinhNST = 0;
    input.nhuCauVonDieuChinhNSTW = 0;
    input.nhuCauVonDieuChinhODA = 0;
    if (input.dieuChinhTangNST !== undefined) {
        input.nhuCauVonDieuChinhNST = input.dieuChinhTangNST - input.dieuChinhGiamNST;
    }
    if (input.dieuChinhTangNSTW !== undefined) {
        input.nhuCauVonDieuChinhNSTW = input.dieuChinhTangNSTW - input.dieuChinhGiamNSTW;
    }
    if (input.dieuChinhTangODA !== undefined) {
        input.nhuCauVonDieuChinhODA = input.dieuChinhTangODA - input.dieuChinhGiamODA;
    }
    return input;
}

//set số thứ tự
function orderRowItemNo(cellElement, cellInfo) {
    var index = cellInfo.row.rowIndex + 1;
    cellElement.text(index)
}
//set giá trị sau khi điều chỉnh
function setValueNcvSauDieuChinhNST(e) {
    var ds = e.data;
    let kt = congTrinhNganSachTinhs.find(x => x.id === ds.id);
    kt.nST_von_dieuchinh = kt.nST_Tang - kt.nST_Giam;
    $("#gridNST").dxDataGrid("instance").refresh();
}

function setValueNcvSauDieuChinhTW(e) {
    var ds = e.data;
    let kt = congTrinhNganSachTWs.find(x => x.id === ds.id);
    kt.nSTW_von_dieuchinh = kt.nSTW_Tang - kt.nSTW_Giam;
    $("#gridTW").dxDataGrid("instance").refresh();
}

// Xử lý không scroll trong tab ngân sách trung ương
$('#tab_TW').click(function (e) {
    $("#gridTW").find('.dx-header-multi-row colgroup').html($("#gridNST").find('.dx-header-multi-row colgroup').html());
    $("#gridTW").find('.dx-datagrid-rowsview colgroup').html($("#gridNST").find('.dx-datagrid-rowsview colgroup').html());
    $("#gridTW").find('.dx-datagrid-total-footer colgroup').html($("#gridNST").find('.dx-datagrid-total-footer colgroup').html());
});

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


