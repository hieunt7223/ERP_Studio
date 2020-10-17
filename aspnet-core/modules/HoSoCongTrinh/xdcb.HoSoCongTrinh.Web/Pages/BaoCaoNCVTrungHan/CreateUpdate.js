var createModal = new abp.ModalManager(abp.appPath + 'BaoCaoNCVTrungHan/CongTrinh/CreateModal');
var selectingNSTs = new Array(0);
var selectingNSTUs = new Array(0);
var selectingNODAs = new Array(0);
var congTrinhNganSachTinhs = new Array(0);
var congTrinhNganSachTWs = new Array(0);
var congTrinhNganSachODAs = new Array(0);
var baoCaoTrungHanDauNams = new Array(0);
var nhuCauVonChiTietByLuyKe = new Array(0);
var nhuCauVonChiTietDauNam = new Array(0);
var year;
var to_year;
var loaikehoach;
var idBaoCao;
var status_DauNam;
var status_DieuChinh = null;
var _tabAdd;
var giai_doan;
var loaikehoachlast = "daunam";
var year_last;
var to_year_last;
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
            year = result_data.tuNam;
            to_year = result_data.denNam;
            giai_doan = result_data.giaiDoanNam;
            if (status_DauNam == "DA_GUI" && loaikehoach === "DAU_NAM") {
                $('#EditSave').attr('disabled', 'true');
            }

            if (status_DieuChinh == "DA_GUI" && loaikehoach === "DIEU_CHINH") {
                $('#EditSave').attr('disabled', 'true');
            }
            thoiGiaGuiDauNam = result_data.thoiGianGuiBaoCaoDauNam;
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

    }
});

//Get dữ liệu--------------------------------------------------------------
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
        url: '/api/app/congTrinh/byChuDauTuID/' + chuDauTuId,
        type: 'get',
        async: false
    }).done(function (data) {
        if (loaikehoach === "DIEU_CHINH") {

            for (let i = 0; i < nhuCauVonChiTietDauNam.length; i++) {
                for (let j = 0; j < data.length; j++)
                    if (nhuCauVonChiTietDauNam[i].congTrinhID === data[j].id) {
                        congTrinhNganSachTinhs.push(data[i]);
                        congTrinhNganSachTinhs[i].nST = data[j].nst;
                        congTrinhNganSachTinhs[i].ghiChu_dieuchinh = nhuCauVonChiTietDauNam[i].ghiChuDieuChinhNST;
                        congTrinhNganSachTinhs[i].nST_LuyKeVon = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocNST;
                        congTrinhNganSachTinhs[i].ghiChu = nhuCauVonChiTietDauNam[i].ghiChuDauNamNST;
                        congTrinhNganSachTinhs[i].nST_KeHoachVonDaGiao = 0;
                        congTrinhNganSachTinhs[i].nST_TongKeHoachVonDaGiao = 0;
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
        url: '/api/app/congTrinh/byChuDauTuID/' + chuDauTuId,
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
                        congTrinhNganSachTWs[i].TW_LuyKeVon = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocNSTW;
                        congTrinhNganSachTWs[i].ghiChuTW = nhuCauVonChiTietDauNam[i].ghiChuDauNamNSTW;
                        congTrinhNganSachTWs[i].nSTW_KeHoachVonDaGiao = 0;
                        congTrinhNganSachTWs[i].nSTW_TongKeHoachVonDaGiao = 0;
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
        url: '/api/app/congTrinh/byChuDauTuID/' + chuDauTuId,
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
                        congTrinhNganSachODAs[i].nSODA_LuyKeVon = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocODA;
                        congTrinhNganSachODAs[i].ghiChuODA = nhuCauVonChiTietDauNam[i].ghiChuDauNamODA;
                        congTrinhNganSachODAs[i].nSODA_KeHoachVonDaGiao = 0;
                        congTrinhNganSachODAs[i].nSODA_TongKeHoachVonDaGiao = 0;
                        congTrinhNganSachODAs[i].nSODA_Tang = nhuCauVonChiTietDauNam[i].dieuChinhTangODA;
                        congTrinhNganSachODAs[i].nSODA_Giam = nhuCauVonChiTietDauNam[i].dieuChinhGiamODA;
                        congTrinhNganSachODAs[i].nSODA_von_dieuchinh = congTrinhNganSachODAs[i].nSODA_KeHoachVonDaGiao + congTrinhNganSachODAs[i].nSODA_Tang - congTrinhNganSachODAs[i].nSODA_Giam;
                    }
            }

        } else {
            for (let i = 0; i < nhuCauVonChiTietDauNam.length; i++) {
                for (let j = 0; j < data.length; j++)
                    if (nhuCauVonChiTietDauNam[i].congTrinhID === data[j].id) {
                        congTrinhNganSachODAs.push(data[j]);
                        congTrinhNganSachODAs[i].nSTODA = data[j].oda;
                        congTrinhNganSachODAs[i].nSODA_LuyKeVon = nhuCauVonChiTietDauNam[i].luyKeVonNamTruocODA;
                        congTrinhNganSachODAs[i].ghiChuODA = nhuCauVonChiTietDauNam[i].ghiChuDauNamODA;
                        congTrinhNganSachODAs[i].nhuCauVonODA = nhuCauVonChiTietDauNam[i].nhuCauVonDauNamODA;
                    }
            }
        }
    });
}

//Get dữ liệu bởi chủ đầu tư
function getNSTByChuDauTuId() {
    abp.ajax({
        url: '/api/app/congTrinh/byChuDauTuID/' + chuDauTuId,
        type: 'get',
        async: false
    }).done(function (data) {

        if (loaikehoach === "DIEU_CHINH") {
            if (loaikehoachlast === "daunam") {
                for (let j = 0; j < nhuCauVonChiTietDauNam.length; j++) {
                    for (let i = 0; i < data.length; i++) {
                        if (nhuCauVonChiTietDauNam[j].congTrinhID === data[i].id) {
                            congTrinhNganSachTinhs.push(data[i]);
                            congTrinhNganSachTinhs[j].nST = data[i].nst;
                            congTrinhNganSachTinhs[j].ghiChu_dieuchinh = "";
                            congTrinhNganSachTinhs[j].nST_LuyKeVon = nhuCauVonChiTietDauNam[j].nhuCauVonDauNamNST;
                            congTrinhNganSachTinhs[j].ghiChu = nhuCauVonChiTietDauNam[j].ghiChuDauNamNST;
                            congTrinhNganSachTinhs[j].nST_KeHoachVonDaGiao = 0;
                            congTrinhNganSachTinhs[j].nST_TongKeHoachVonDaGiao = 0;
                            congTrinhNganSachTinhs[j].nST_Tang = 0;
                            congTrinhNganSachTinhs[j].nST_Giam = 0;
                            congTrinhNganSachTinhs[j].nST_von_dieuchinh = congTrinhNganSachTinhs[j].nST_KeHoachVonDaGiao + congTrinhNganSachTinhs[j].nST_Tang - congTrinhNganSachTinhs[j].nST_Giam;
                            congTrinhNganSachTinhs[j].idChiTiet = nhuCauVonChiTietDauNam[j].id;
                        }
                    }
                }
            } else {
                for (let j = 0; j < nhuCauVonChiTietDauNam.length; j++) {
                    for (let i = 0; i < data.length; i++) {
                        if (nhuCauVonChiTietDauNam[j].congTrinhID === data[i].id) {
                            congTrinhNganSachTinhs.push(data[i]);
                            congTrinhNganSachTinhs[j].nST = data[i].nst;
                            congTrinhNganSachTinhs[j].ghiChu_dieuchinh = "";
                            congTrinhNganSachTinhs[j].nST_LuyKeVon = nhuCauVonChiTietDauNam[j].nhuCauVonDieuChinhNST;
                            congTrinhNganSachTinhs[j].ghiChu = nhuCauVonChiTietDauNam[j].ghiChuDauNamNST;
                            congTrinhNganSachTinhs[j].nST_KeHoachVonDaGiao = 0;
                            congTrinhNganSachTinhs[j].nST_TongKeHoachVonDaGiao = 0;
                            congTrinhNganSachTinhs[j].nST_Tang = 0;
                            congTrinhNganSachTinhs[j].nST_Giam = 0;
                            congTrinhNganSachTinhs[j].nST_von_dieuchinh = congTrinhNganSachTinhs[j].nST_KeHoachVonDaGiao + congTrinhNganSachTinhs[j].nST_Tang - congTrinhNganSachTinhs[j].nST_Giam;
                            congTrinhNganSachTinhs[j].idChiTiet = nhuCauVonChiTietDauNam[j].id;
                        }
                    }
                }
            }

        } else {
            data = data.filter(item => (new Date(item.thoiGianThucHienTuNgay).getFullYear() >= year && new Date(item.thoiGianThucHienTuNgay).getFullYear() <= to_year) || (new Date(item.thoiGianThucHienDenNgay).getFullYear() >= year && new Date(item.thoiGianThucHienDenNgay).getFullYear() <= to_year));
            for (var i = 0; i < data.length; i++) {
                congTrinhNganSachTinhs.push(data[i]);
                congTrinhNganSachTinhs[i].nST = data[i].nst;
                congTrinhNganSachTinhs[i].nST_LuyKeVon = 0;
                congTrinhNganSachTinhs[i].ghiChu = "";
                congTrinhNganSachTinhs[i].nhuCauVon = 0;
            }
            if (loaikehoachlast === "daunam") {
                for (let j = 0; j < nhuCauVonChiTietDauNam.length; j++) {
                    for (let k = 0; k < congTrinhNganSachTinhs.length; k++) {
                        if (nhuCauVonChiTietDauNam[j].congTrinhID === congTrinhNganSachTinhs[k].id) {
                            congTrinhNganSachTinhs[k].nST_LuyKeVon = nhuCauVonChiTietDauNam[j].nhuCauVonDauNamNST;
                        }
                    }
                }
            } else {
                for (let j = 0; j < nhuCauVonChiTietDauNam.length; j++) {
                    for (let k = 0; k < congTrinhNganSachTinhs.length; k++) {
                        if (nhuCauVonChiTietDauNam[j].congTrinhID === congTrinhNganSachTinhs[k].id) {
                            congTrinhNganSachTinhs[k].nST_LuyKeVon = nhuCauVonChiTietDauNam[j].nhuCauVonDieuChinhNST;
                        }
                    }
                }
            }

        }

        return congTrinhNganSachTinhs;
    });
}

function getTWByChuDauTuId() {
    abp.ajax({
        url: '/api/app/congTrinh/byChuDauTuID/' + chuDauTuId,
        type: 'get',
        async: false
    }).done(function (data) {

        if (loaikehoach === "DIEU_CHINH") {
            if (loaikehoachlast === 'daunam') {
                for (let j = 0; j < nhuCauVonChiTietDauNam.length; j++) {
                    for (let i = 0; i < data.length; i++) {
                        if (nhuCauVonChiTietDauNam[j].congTrinhID === data[i].id) {
                            congTrinhNganSachTWs.push(data[i]);
                            congTrinhNganSachTWs[j].TW = data[i].nstw;
                            congTrinhNganSachTinhs[j].ghiChuTW_dieuchinh = "";
                            congTrinhNganSachTWs[j].TW_LuyKeVon = nhuCauVonChiTietDauNam[j].nhuCauVonDauNamNSTW;
                            congTrinhNganSachTWs[j].ghiChuTW = nhuCauVonChiTietDauNam[j].ghiChuDauNamNSTW;
                            congTrinhNganSachTWs[j].nSTW_KeHoachVonDaGiao = 0;
                            congTrinhNganSachTWs[j].nSTW_TongKeHoachVonDaGiao = 0;
                            congTrinhNganSachTWs[j].nSTW_Tang = 0;
                            congTrinhNganSachTWs[j].nSTW_Giam = 0;
                            congTrinhNganSachTWs[j].nSTW_von_dieuchinh = congTrinhNganSachTWs[j].nSTW_KeHoachVonDaGiao + congTrinhNganSachTWs[j].nSTW_Tang - congTrinhNganSachTWs[j].nSTW_Giam;
                        }
                    }

                }
            } else {
                for (let j = 0; j < nhuCauVonChiTietDauNam.length; j++) {
                    for (let i = 0; i < data.length; i++) {
                        if (nhuCauVonChiTietDauNam[j].congTrinhID === data[i].id) {
                            congTrinhNganSachTWs.push(data[i]);
                            congTrinhNganSachTWs[j].TW = data[i].nstw;
                            congTrinhNganSachTinhs[j].ghiChuTW_dieuchinh = "";
                            congTrinhNganSachTWs[j].TW_LuyKeVon = nhuCauVonChiTietDauNam[j].nhuCauVonDieuChinhNSTW;
                            congTrinhNganSachTWs[j].ghiChuTW = nhuCauVonChiTietDauNam[j].ghiChuDauNamNSTW;
                            congTrinhNganSachTWs[j].nSTW_KeHoachVonDaGiao = 0;
                            congTrinhNganSachTWs[j].nSTW_TongKeHoachVonDaGiao = 0;
                            congTrinhNganSachTWs[j].nSTW_Tang = 0;
                            congTrinhNganSachTWs[j].nSTW_Giam = 0;
                            congTrinhNganSachTWs[j].nSTW_von_dieuchinh = congTrinhNganSachTWs[j].nSTW_KeHoachVonDaGiao + congTrinhNganSachTWs[j].nSTW_Tang - congTrinhNganSachTWs[j].nSTW_Giam;
                        }
                    }

                }
            }

        } else {
            data = data.filter(item => (new Date(item.thoiGianThucHienTuNgay).getFullYear() >= year && new Date(item.thoiGianThucHienTuNgay).getFullYear() <= to_year) || (new Date(item.thoiGianThucHienDenNgay).getFullYear() >= year && new Date(item.thoiGianThucHienDenNgay).getFullYear() <= to_year));
            for (var i = 0; i < data.length; i++) {
                congTrinhNganSachTWs.push(data[i]);
                congTrinhNganSachTWs[i].TW = data[i].nstw;
                congTrinhNganSachTWs[i].TW_LuyKeVon = 0;
                congTrinhNganSachTWs[i].ghiChuTW = "";
                congTrinhNganSachTWs[i].nhuCauVonTW = 0;
            }
            if (loaikehoachlast === 'daunam') {
                for (let j = 0; j < nhuCauVonChiTietDauNam.length; j++) {
                    for (let k = 0; k < congTrinhNganSachTWs.length; k++) {
                        if (nhuCauVonChiTietDauNam[j].congTrinhID === congTrinhNganSachTWs[k].id) {
                            congTrinhNganSachTWs[k].TW_LuyKeVon = nhuCauVonChiTietDauNam[j].nhuCauVonDauNamNSTW;
                        }
                    }
                }
            } else {
                for (let j = 0; j < nhuCauVonChiTietDauNam.length; j++) {
                    for (let k = 0; k < congTrinhNganSachTWs.length; k++) {
                        if (nhuCauVonChiTietDauNam[j].congTrinhID === congTrinhNganSachTWs[k].id) {
                            congTrinhNganSachTWs[k].TW_LuyKeVon = nhuCauVonChiTietDauNam[j].nhuCauVonDieuChinhNSTW;
                        }
                    }
                }
            }

        }
        return congTrinhNganSachTWs;
    });
}

function getNSODAByChuDauTuId() {
    abp.ajax({
        url: '/api/app/congTrinh/byChuDauTuID/' + chuDauTuId,
        type: 'get',
        async: false
    }).done(function (data) {
        data = data.filter(item => (new Date(item.thoiGianThucHienTuNgay).getFullYear() >= year && new Date(item.thoiGianThucHienTuNgay).getFullYear() <= to_year) || (new Date(item.thoiGianThucHienDenNgay).getFullYear() >= year && new Date(item.thoiGianThucHienDenNgay).getFullYear() <= to_year));
        if (loaikehoach === "DIEU_CHINH") {
            if (loaikehoachlast === 'daunam') {
                for (let j = 0; j < nhuCauVonChiTietDauNam.length; j++) {
                    for (let i = 0; i < data.length; i++) {
                        if (nhuCauVonChiTietDauNam[j].congTrinhID === data[i].id) {
                            congTrinhNganSachODAs.push(data[i]);
                            congTrinhNganSachODAs[j].nSODA = data[i].oda;
                            congTrinhNganSachTinhs[j].ghiChuODA_dieuchinh = "";
                            congTrinhNganSachODAs[j].nSODA_LuyKeVon = nhuCauVonChiTietDauNam[j].nhuCauVonDauNamODA;
                            congTrinhNganSachODAs[j].ghiChuODA = nhuCauVonChiTietDauNam[j].ghiChuDauNamODA;
                            congTrinhNganSachODAs[j].nSODA_KeHoachVonDaGiao = 0;
                            congTrinhNganSachODAs[j].nSODA_TongKeHoachVonDaGiao = 0;
                            congTrinhNganSachODAs[j].nSODA_Giam = 0;
                            congTrinhNganSachODAs[j].nSODA_Tang = 0;
                            congTrinhNganSachODAs[j].nSODA_von_dieuchinh = congTrinhNganSachODAs[j].nSODA_KeHoachVonDaGiao + congTrinhNganSachODAs[j].nSODA_Tang - congTrinhNganSachODAs[j].nSODA_Giam;
                        }
                    }
                }
            } else {
                for (let j = 0; j < nhuCauVonChiTietDauNam.length; j++) {
                    for (let i = 0; i < data.length; i++) {
                        if (nhuCauVonChiTietDauNam[j].congTrinhID === data[i].id) {
                            congTrinhNganSachODAs.push(data[i]);
                            congTrinhNganSachODAs[j].nSODA = data[i].oda;
                            congTrinhNganSachTinhs[j].ghiChuODA_dieuchinh = "";
                            congTrinhNganSachODAs[j].nSODA_LuyKeVon = nhuCauVonChiTietDauNam[j].nhuCauVonDieuChinhODA;
                            congTrinhNganSachODAs[j].ghiChuODA = nhuCauVonChiTietDauNam[j].ghiChuDauNamODA;
                            congTrinhNganSachODAs[j].nSODA_KeHoachVonDaGiao = 0;
                            congTrinhNganSachODAs[j].nSODA_TongKeHoachVonDaGiao = 0;
                            congTrinhNganSachODAs[j].nSODA_Giam = 0;
                            congTrinhNganSachODAs[j].nSODA_Tang = 0;
                            congTrinhNganSachODAs[j].nSODA_von_dieuchinh = congTrinhNganSachODAs[j].nSODA_KeHoachVonDaGiao + congTrinhNganSachODAs[j].nSODA_Tang - congTrinhNganSachODAs[j].nSODA_Giam;
                        }
                    }
                }
            }

        } else {
            for (var i = 0; i < data.length; i++) {
                congTrinhNganSachODAs.push(data[i]);
                congTrinhNganSachODAs[i].nSODA = data[i].oda;
                congTrinhNganSachODAs[i].nSODA_LuyKeVon = 0;
                congTrinhNganSachODAs[i].ghiChuODA = "";
                congTrinhNganSachODAs[i].nhuCauVonODA = 0;
            }
            if (loaikehoachlast === 'daunam') {
                for (let j = 0; j < nhuCauVonChiTietDauNam.length; j++) {
                    for (let k = 0; k < congTrinhNganSachODAs.length; k++) {
                        if (nhuCauVonChiTietDauNam[j].congTrinhID === congTrinhNganSachODAs[k].id) {
                            congTrinhNganSachODAs[k].nSODA_LuyKeVon = nhuCauVonChiTietDauNam[j].nhuCauVonDauNamODA;
                        }
                    }
                }
            } else {
                for (let j = 0; j < nhuCauVonChiTietDauNam.length; j++) {
                    for (let k = 0; k < congTrinhNganSachODAs.length; k++) {
                        if (nhuCauVonChiTietDauNam[j].congTrinhID === congTrinhNganSachODAs[k].id) {
                            congTrinhNganSachODAs[k].nSODA_LuyKeVon = nhuCauVonChiTietDauNam[j].nhuCauVonDieuChinhODA;
                        }
                    }
                }
            }

        }
        return congTrinhNganSachODAs;
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
                caption: "Nhu cầu kế hoạch vốn trung hạn giai đoạn " + year + '-' + to_year,
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
                caption: "Nhu cầu kế hoạch vốn trung hạn giai đoạn " + year + '-' + to_year,
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
                caption: "Nhu cầu kế hoạch vốn trung hạn giai đoạn " + year + '-' + to_year,
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
                caption: "Kế hoạch vốn trung hạn giai đoạn " + giai_doan + " đã giao",
                alignment: "center",
                columns: [
                    {
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
                caption: "Đề xuất điều chỉnh kế hoạch vốn trung hạn",
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
                caption: "Kế hoạch vốn trung hạn giai đoạn " + giai_doan + " sau điều chỉnh",
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
                column: "nST_TongKeHoachVonDaGiao",
                summaryType: "sum",
                showInColumn: "nST_TongKeHoachVonDaGiao",
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
                caption: "Kế hoạch vốn trung hạn giai đoạn " + giai_doan + " đã giao",
                alignment: "center",
                columns: [
                    {
                        caption: "Trong đó: NSTW",
                        dataField: "nSTW_KeHoachVonDaGiao",
                        dataType: "number",
                        format: {
                            type: "fixedPoint",
                            precision: 2
                        },
                    }]
            },
            {
                caption: "Đề xuất điều chỉnh kế hoạch vốn trung hạn",
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
                caption: "Kế hoạch vốn trung hạn giai đoạn " + giai_doan + " sau điều chỉnh",
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
            }, {
                column: "nSTW_TongKeHoachVonDaGiao",
                summaryType: "sum",
                showInColumn: "nSTW_TongKeHoachVonDaGiao",
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
                caption: "Kế hoạch vốn trung hạn giai đoạn " + giai_doan + " đã giao",
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
                caption: "Đề xuất điều chỉnh kế hoạch vốn trung hạn",
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
                caption: "Kế hoạch vốn trung hạn giai đoạn " + giai_doan + " sau điều chỉnh",
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
                column: "nSODA_TongKeHoachVonDaGiao",
                summaryType: "sum",
                showInColumn: "nSODA_TongKeHoachVonDaGiao",
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
//-------------------------------------------------------------------------

//Sự kiện -----------------------------------------------------------------

//Thêm công trình vào báo cáo
//Tìm kiếm công trình 
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
//Hiển thị dữ liệu tại data gird
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
            },
        ]
    });

    // xóa select all
    var dataGrid = $("#dataGirdMultiple").dxDataGrid("instance");
    dataGrid.clearSelection();
}
//Chọn công trình
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
//Thêm công trình vào báo cáo
function InsertDataRow() {
    switch (_tabAdd) {
        case "NST": {
            for (let i = 0; i < selectingNSTs.length; i++) {
                congTrinhNganSachTinhs.push(selectingNSTs[i]);
                if (loaikehoach === "DIEU_CHINH") {
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].nST = 0;
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].ghiChu_dieuchinh = "";
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].nST_LuyKeKhoiLuong = 0;
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].nST_LuyKeVon = 0;
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].ghiChu = "";
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].nST_KeHoachVonDaGiao = 0;
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].nST_Giam = 0;
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].nST_Tang = 0;
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].nST_von_dieuchinh = 0;
                } else {
                    congTrinhNganSachTinhs[congTrinhNganSachTinhs.length - 1].nST = 0;
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
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].TW = 0;
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].ghiChuTW_dieuchinh = "";
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].TW_LuyKeKhoiLuong = 0;
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].TW_LuyKeVon = 0;
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].ghiChuTW = "";
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].nSTW_KeHoachVonDaGiao = 0;
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].nSTW_Giam = 0;
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].nSTW_Tang = 0;
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].nSTW_von_dieuchinh = 0;
                } else {
                    congTrinhNganSachTWs[congTrinhNganSachTWs.length - 1].TW = 0;
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
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].nSODA = 0;
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].ghiChuODA_dieuchinh = "";
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].nSODA_LuyKeKhoiLuong = 0;
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].nSODA_LuyKeVon = 0;
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].ghiChuODA = "";
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].nSODA_KeHoachVonDaGiao = 0;
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].nSODA_Giam = 0;
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].nSODA_Tang = 0;
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].nSODA_von_dieuchinh = 0;
                } else {
                    congTrinhNganSachODAs[congTrinhNganSachODAs.length - 1].nSODA = 0;
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
//Thêm mới công trình
$('.row_congtrinh').on('click', '.btn_add_congtrinh', function () {
    $('#myModal').modal('hide');
    createModal.open();
});

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

//Lưu dữ liệu
//Tổng hợp dữ liệu
function getDataBaoCao() {
    baoCaoTrungHanDauNams = [];
    //ẩn Oda
    congTrinhNganSachODAs = [];
    if (loaikehoach === "DIEU_CHINH") {
        for (let i = 0; i < congTrinhNganSachTinhs.length; i++) {
            baoCaoTrungHanDauNams.push(congTrinhNganSachTinhs[i]);
        }
        for (let j = 0; j < congTrinhNganSachTWs.length; j++) {
            let kt = baoCaoTrungHanDauNams.find(x => x.id === congTrinhNganSachTWs[j].id);
            if (kt) {
                kt.TW = congTrinhNganSachTWs[j].TW;
                kt.TW_LuyKeKhoiLuong = congTrinhNganSachTWs[j].TW_LuyKeKhoiLuong;
                kt.TW_LuyKeVon = congTrinhNganSachTWs[j].TW_LuyKeVon;
                kt.ghiChuTW = congTrinhNganSachTWs[j].ghiChuTW;
                kt.nSTW_KeHoachVonDaGiao = congTrinhNganSachTWs[j].nSTW_KeHoachVonDaGiao;
                kt.nSTW_Giam = congTrinhNganSachTWs[j].nSTW_Giam;
                kt.nSTW_Tang = congTrinhNganSachTWs[j].nSTW_Tang;
                kt.ghiChuTW_dieuchinh = congTrinhNganSachTWs[j].ghiChuTW_dieuchinh;
            } else {
                baoCaoTrungHanDauNams.push(congTrinhNganSachTWs[j]);
            }
        }
        for (let k = 0; k < congTrinhNganSachODAs.length; k++) {
            let kt = baoCaoTrungHanDauNams.find(x => x.id === congTrinhNganSachODAs[k].id);
            if (kt) {

                kt.nSODA = congTrinhNganSachODAs[k].nSODA;
                kt.nSODA_LuyKeKhoiLuong = congTrinhNganSachODAs[k].nSODA_LuyKeKhoiLuong;
                kt.nSODA_LuyKeVon = congTrinhNganSachODAs[k].nSODA_LuyKeVon;
                kt.ghiChuODA = congTrinhNganSachODAs[k].ghiChuODA;
                kt.nSODA_KeHoachVonDaGiao = congTrinhNganSachODAs[k].nSODA_KeHoachVonDaGiao;
                kt.nSODA_Giam = congTrinhNganSachODAs[k].nSODA_Giam;
                kt.nSODA_Tang = congTrinhNganSachODAs[k].nSODA_Tang;
                kt.ghiChuODA_dieuchinh = congTrinhNganSachODAs[k].ghiChuODA_dieuchinh;
            } else {
                baoCaoTrungHanDauNams.push(congTrinhNganSachODAs[k]);
            }
        }

    } else {
        for (let i = 0; i < congTrinhNganSachTinhs.length; i++) {
            baoCaoTrungHanDauNams.push(congTrinhNganSachTinhs[i]);
        }
        for (let j = 0; j < congTrinhNganSachTWs.length; j++) {
            let kt = baoCaoTrungHanDauNams.find(x => x.id === congTrinhNganSachTWs[j].id);
            if (kt) {
                kt.TW = congTrinhNganSachTWs[j].TW;
                kt.TW_LuyKeKhoiLuong = congTrinhNganSachTWs[j].TW_LuyKeKhoiLuong;
                kt.TW_LuyKeVon = congTrinhNganSachTWs[j].TW_LuyKeVon;
                kt.ghiChuTW = congTrinhNganSachTWs[j].ghiChuTW;
                kt.nhuCauVonTW = congTrinhNganSachTWs[j].nhuCauVonTW;
            } else {
                baoCaoTrungHanDauNams.push(congTrinhNganSachTWs[j]);
            }
        }
        for (let k = 0; k < congTrinhNganSachODAs.length; k++) {
            let kt = baoCaoTrungHanDauNams.find(x => x.id === congTrinhNganSachODAs[k].id);
            if (kt) {

                kt.nSODA = congTrinhNganSachODAs[k].nSODA;
                kt.nSODA_LuyKeKhoiLuong = congTrinhNganSachODAs[k].nSODA_LuyKeKhoiLuong;
                kt.nSODA_LuyKeVon = congTrinhNganSachODAs[k].nSODA_LuyKeVon;
                kt.ghiChuODA = congTrinhNganSachODAs[k].ghiChuODA;
                kt.nhuCauVonODA = congTrinhNganSachODAs[k].nhuCauVonODA;
            } else {
                baoCaoTrungHanDauNams.push(congTrinhNganSachODAs[k]);
            }
        }

    }
}

//Lưu, gửi dữ liệu thêm mới
//Lưu báo cáo
$("#Save").on('click', function () {
    Save("DANG_SOAN");
});

//Gửi báo cáo
$("#Send").on('click', function () {
    Save("DA_GUI");
});
//Lưu dữ liệu
function Save(status) {
    getDataBaoCao();
    if (loaikehoach === 'DIEU_CHINH') {
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
            tuNam: year_last,
            denNam: to_year_last,
            giaiDoanNam: giai_doan,
            chuDauTuID: chuDauTuId,
            tenKeHoach: "TRUNG_HAN",
            trangThaiDieuChinh: status,
            tongNhuCauVonDauNam: tongNhuCauVon,
            tongNhuCauVonDieuChinh: tongNhuCauVon + tang - giam,
            thoiGianGuiBaoCaoDauNam: thoiGiaGuiDauNam,
            thoiGianGuiBaoCaoDieuChinh: date
        };

        $.ajax({
            url: '/api/app/nhuCauKeHoachVon',
            type: 'Post',
            contentType: "application/json; charset=utf-8",
            async: false,
            data: JSON.stringify(input)
        }).done(function (data) {
            let idNhuCauVon = data.id;
            for (let i = 0; i < baoCaoTrungHanDauNams.length; i++) {
                let input = {
                    "nhuCauKeHoachVonID": idNhuCauVon,
                    "congTrinhID": baoCaoTrungHanDauNams[i].id,
                    "luyKeKhoiLuongNamTruocNST": 0,
                    "luyKeVonNamTruocNST": baoCaoTrungHanDauNams[i].nST_LuyKeVon,
                    "nhuCauVonDauNamNST": 0,
                    "dieuChinhGiamNST": baoCaoTrungHanDauNams[i].nST_Giam,
                    "dieuChinhTangNST": baoCaoTrungHanDauNams[i].nST_Tang,
                    "nhuCauVonDieuChinhNST": (baoCaoTrungHanDauNams[i].nST_KeHoachVonDaGiao + baoCaoTrungHanDauNams[i].nST_Tang - baoCaoTrungHanDauNams[i].nST_Giam),
                    "ghiChuDauNamNST": '',
                    "ghiChuDieuChinhNST": baoCaoTrungHanDauNams[i].ghiChu_dieuchinh,
                    "ghiChuChuyenVienDauNamNST": "",
                    "ghiChuChuyenVienDieuChinhNST": "",
                    "isSelectNST": false,
                    "luyKeKhoiLuongNamTruocNSTW": 0,
                    "luyKeVonNamTruocNSTW": baoCaoTrungHanDauNams[i].TW_LuyKeVon,
                    "nhuCauVonDauNamNSTW": 0,
                    "dieuChinhGiamNSTW": baoCaoTrungHanDauNams[i].nSTW_Giam,
                    "dieuChinhTangNSTW": baoCaoTrungHanDauNams[i].nSTW_Tang,
                    "nhuCauVonDieuChinhNSTW": baoCaoTrungHanDauNams[i].nSTW_KeHoachVonDaGiao + baoCaoTrungHanDauNams[i].nSTW_Tang - baoCaoTrungHanDauNams[i].nSTW_Giam,
                    "ghiChuDauNamNSTW": '',
                    "ghiChuDieuChinhNSTW": baoCaoTrungHanDauNams[i].ghiChuTW_dieuchinh,
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
                    "ghiChuDieuChinhODA": '',
                    "ghiChuChuyenVienDauNamODA": "",
                    "ghiChuChuyenVienDieuChinhODA": "",
                    "isSelectODA": false,
                    "isSelect": false
                };
                input = checkUndefinded(input);
                abp.ajax({
                    url: '/api/app/nhuCauKeHoachVonChiTiet',
                    type: 'post',
                    async: false,
                    data: JSON.stringify(input)
                }).done(function (data) {
                });
            }
            abp.notify.info(messages.SuccessfullyCreate);
            window.location.href = '/BaoCaoNCVTrungHan/List';
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
            denNam: to_year,
            giaiDoanNam: year + '-' + to_year,
            chuDauTuID: chuDauTuId,
            tenKeHoach: "TRUNG_HAN",
            trangThaiDauNam: status,
            trangThaiDieuChinh: status_DieuChinh,
            tongNhuCauVonDauNam: tongNhuCauVon,
            tongNhuCauVonDieuChinh: 0,
            thoiGianGuiBaoCaoDauNam: date,
            thoiGianGuiBaoCaoDieuChinh: null
        };

        $.ajax({
            url: '/api/app/nhuCauKeHoachVon',
            type: 'Post',
            contentType: "application/json; charset=utf-8",
            async: false,
            data: JSON.stringify(input)
        }).done(function (data) {

            var idNhuCauVon = data.id;
            for (var i = 0; i < baoCaoTrungHanDauNams.length; i++) {
                let input = {
                    "nhuCauKeHoachVonID": idNhuCauVon,
                    "congTrinhID": baoCaoTrungHanDauNams[i].id,
                    "luyKeKhoiLuongNamTruocNST": baoCaoTrungHanDauNams[i].nST_LuyKeKhoiLuong,
                    "luyKeVonNamTruocNST": baoCaoTrungHanDauNams[i].nST_LuyKeVon,
                    "nhuCauVonDauNamNST": baoCaoTrungHanDauNams[i].nhuCauVon,
                    "dieuChinhGiamNST": 0,
                    "dieuChinhTangNST": 0,
                    "nhuCauVonDieuChinhNST": 0,
                    "ghiChuDauNamNST": baoCaoTrungHanDauNams[i].ghiChu,
                    "ghiChuDieuChinhNST": "",
                    "ghiChuChuyenVienDauNamNST": "",
                    "ghiChuChuyenVienDieuChinhNST": "",
                    "isSelectNST": false,
                    "luyKeKhoiLuongNamTruocNSTW": baoCaoTrungHanDauNams[i].TW_LuyKeKhoiLuong,
                    "luyKeVonNamTruocNSTW": baoCaoTrungHanDauNams[i].TW_LuyKeVon,
                    "nhuCauVonDauNamNSTW": baoCaoTrungHanDauNams[i].nhuCauVonTW,
                    "dieuChinhGiamNSTW": 0,
                    "dieuChinhTangNSTW": 0,
                    "nhuCauVonDieuChinhNSTW": 0,
                    "ghiChuDauNamNSTW": baoCaoTrungHanDauNams[i].ghiChuTW,
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
                    "isSelect": false
                };
                abp.ajax({
                    url: '/api/app/nhuCauKeHoachVonChiTiet',
                    type: 'post',
                    async: false,
                    data: JSON.stringify(input)
                }).done(function (data) {
                });
            }
            abp.notify.info(messages.SuccessfullyCreate);
            window.location.href = '/BaoCaoNCVTrungHan/List';
        }).fail(function () {
            abp.notify.info(messages.NOtSuccessfullyCreate);
        });
    }
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
    getDataBaoCao();
    if (loaikehoach === 'DIEU_CHINH') {
        let data = nhuCauVonChiTietDauNam.filter(ar => !baoCaoTrungHanDauNams.find(rm => (rm.idChiTiet === ar.id)));
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
            denNam: to_year,
            giaiDoanNam: giai_doan,
            chuDauTuID: chuDauTuId,
            tenKeHoach: "TRUNG_HAN",
            trangThaiDieuChinh: status,
            tongNhuCauVonDauNam: tongNhuCauVon,
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
            for (let i = 0; i < baoCaoTrungHanDauNams.length; i++) {
                let input = {
                    "nhuCauKeHoachVonID": idNhuCauVon,
                    "congTrinhID": baoCaoTrungHanDauNams[i].id,
                    "luyKeKhoiLuongNamTruocNST": baoCaoTrungHanDauNams[i].nST_LuyKeKhoiLuong,
                    "luyKeVonNamTruocNST": baoCaoTrungHanDauNams[i].nST_LuyKeVon,
                    "nhuCauVonDauNamNST": baoCaoTrungHanDauNams[i].nST_KeHoachVonDaGiao,
                    "dieuChinhGiamNST": baoCaoTrungHanDauNams[i].nST_Giam,
                    "dieuChinhTangNST": baoCaoTrungHanDauNams[i].nST_Tang,
                    "nhuCauVonDieuChinhNST": (baoCaoTrungHanDauNams[i].nST_KeHoachVonDaGiao + baoCaoTrungHanDauNams[i].nST_Tang - baoCaoTrungHanDauNams[i].nST_Giam),
                    "ghiChuDauNamNST": '',
                    "ghiChuDieuChinhNST": baoCaoTrungHanDauNams[i].ghiChu_dieuchinh,
                    "ghiChuChuyenVienDauNamNST": "",
                    "ghiChuChuyenVienDieuChinhNST": "",
                    "isSelectNST": false,
                    "luyKeKhoiLuongNamTruocNSTW": baoCaoTrungHanDauNams[i].TW_LuyKeKhoiLuong,
                    "luyKeVonNamTruocNSTW": baoCaoTrungHanDauNams[i].TW_LuyKeVon,
                    "nhuCauVonDauNamNSTW": baoCaoTrungHanDauNams[i].nSTW_KeHoachVonDaGiao,
                    "dieuChinhGiamNSTW": baoCaoTrungHanDauNams[i].nSTW_Giam,
                    "dieuChinhTangNSTW": baoCaoTrungHanDauNams[i].nSTW_Tang,
                    "nhuCauVonDieuChinhNSTW": baoCaoTrungHanDauNams[i].nSTW_KeHoachVonDaGiao + baoCaoTrungHanDauNams[i].nSTW_Tang - baoCaoTrungHanDauNams[i].nSTW_Giam,
                    "ghiChuDauNamNSTW": '',
                    "ghiChuDieuChinhNSTW": baoCaoTrungHanDauNams[i].ghiChuTW_dieuchinh,
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
                    "isSelect": false
                };
                if (baoCaoTrungHanDauNams[i].idChiTiet !== undefined) {
                    abp.ajax({
                        url: '/api/app/nhuCauKeHoachVonChiTiet/' + baoCaoTrungHanDauNams[i].idChiTiet,
                        type: 'Put',
                        async: false,
                        data: JSON.stringify(input)
                    }).done(function (data) {
                    });
                } else {
                    input = checkUndefinded(input);
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
            window.location.href = '/BaoCaoNCVTrungHan/List';
        }).fail(function () {
            abp.notify.info(messages.NOtSuccessfullyCreate);
        });
    } else {
        let data = nhuCauVonChiTietDauNam.filter(ar => !baoCaoTrungHanDauNams.find(rm => (rm.idChiTiet === ar.id)));
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

        var date = null;
        if (status === "DA_GUI") {
            var today = new Date();
            date = today.getDate() + '/' + (today.getMonth() + 1) + '/' + today.getFullYear();
        }

        var input = {
            tuNam: year,
            denNam: to_year,
            giaiDoanNam: giai_doan,
            chuDauTuID: chuDauTuId,
            tenKeHoach: "TRUNG_HAN",
            trangThaiDauNam: status,
            trangThaiDieuChinh: status_DieuChinh,
            tongNhuCauVonDauNam: tongNhuCauVon,
            tongNhuCauVonDieuChinh: 0,
            thoiGianGuiBaoCaoDauNam: date,
            thoiGianGuiBaoCaoDieuChinh: null
        };

        $.ajax({
            url: '/api/app/nhuCauKeHoachVon/' + idBaoCao,
            type: 'Put',
            contentType: "application/json; charset=utf-8",
            async: false,
            data: JSON.stringify(input)
        }).done(function (data) {

            var idNhuCauVon = data.id;
            for (var i = 0; i < baoCaoTrungHanDauNams.length; i++) {
                let input = {
                    "nhuCauKeHoachVonID": idNhuCauVon,
                    "congTrinhID": baoCaoTrungHanDauNams[i].id,
                    "luyKeKhoiLuongNamTruocNST": baoCaoTrungHanDauNams[i].nST_LuyKeKhoiLuong,
                    "luyKeVonNamTruocNST": baoCaoTrungHanDauNams[i].nST_LuyKeVon,
                    "nhuCauVonDauNamNST": baoCaoTrungHanDauNams[i].nhuCauVon,
                    "dieuChinhGiamNST": 0,
                    "dieuChinhTangNST": 0,
                    "nhuCauVonDieuChinhNST": 0,
                    "ghiChuDauNamNST": baoCaoTrungHanDauNams[i].ghiChu,
                    "ghiChuDieuChinhNST": "",
                    "ghiChuChuyenVienDauNamNST": "",
                    "ghiChuChuyenVienDieuChinhNST": "",
                    "isSelectNST": false,
                    "luyKeKhoiLuongNamTruocNSTW": baoCaoTrungHanDauNams[i].TW_LuyKeKhoiLuong,
                    "luyKeVonNamTruocNSTW": baoCaoTrungHanDauNams[i].TW_LuyKeVon,
                    "nhuCauVonDauNamNSTW": baoCaoTrungHanDauNams[i].nhuCauVonTW,
                    "dieuChinhGiamNSTW": 0,
                    "dieuChinhTangNSTW": 0,
                    "nhuCauVonDieuChinhNSTW": 0,
                    "ghiChuDauNamNSTW": baoCaoTrungHanDauNams[i].ghiChuTW,
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
                    "ghiChuDauNamODA": 0,
                    "ghiChuDieuChinhODA": "",
                    "ghiChuChuyenVienDauNamODA": "",
                    "ghiChuChuyenVienDieuChinhODA": "",
                    "isSelectODA": false,
                    "isSelect": false
                };
                if (baoCaoTrungHanDauNams[i].idChiTiet !== undefined) {
                    abp.ajax({
                        url: '/api/app/nhuCauKeHoachVonChiTiet/' + baoCaoTrungHanDauNams[i].idChiTiet,
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
            window.location.href = '/BaoCaoNCVTrungHan/List';
        }).fail(function () {
            abp.notify.info(messages.NOtSuccessfullyCreate);
        });
    }
}


//Xử lý không hiển thị scroll tại tab ngân sách trung ương
$('#tab_TW').click(function (e) {
    $("#gridTW").find('.dx-header-multi-row colgroup').html($("#gridNST").find('.dx-header-multi-row colgroup').html());
    $("#gridTW").find('.dx-datagrid-rowsview colgroup').html($("#gridNST").find('.dx-datagrid-rowsview colgroup').html());
    $("#gridTW").find('.dx-datagrid-total-footer colgroup').html($("#gridNST").find('.dx-datagrid-total-footer colgroup').html());
});

//Thêm mới báo cáo
//change title
$("#Year").on('change', function () {
    abp.ajax({
        url: '/api/app/nhuCauKeHoachVon/dataTrungHanDauNam?nam=' + $('#Year').val() + '&&chuDauTuID=' + chuDauTuId,
        type: 'get',
        async: false
    }).done(function (data) {
        $('#titile_giaidoan').html(data.giaiDoanNam);
    });
    $('#title_fromyear').html($(this).val());
    $('#title_toyear').html('');

});
$("#FromYear").on('change', function () {
    $('#title_fromyear').html($(this).val());
    var html_to_year = '';
    let from_year = parseInt($('#FromYear').val());
    for (let i = 1; i < 16; i++) {
        html_to_year += '<option value="' + parseInt(from_year + i) + '">' + parseInt(from_year + i) + '</option>';
    }
    $('#ToYear').html(html_to_year);
    $('#title_toyear').html('-' + parseInt(from_year + 1));
});

$("#ToYear").on('change', function () {
    $('#title_toyear').html('-' + $('#ToYear').val());

});

$("#LoaiKeHoach").on('change', function () {
    $('#title_loaikehoach').html($("#LoaiKeHoach option:selected").text());
    if ($("#LoaiKeHoach").val() === 'DIEU_CHINH') {
        abp.ajax({
            url: '/api/app/nhuCauKeHoachVon/dataTrungHanDauNam?nam=' + $('#Year').val() + '&&chuDauTuID=' + chuDauTuId,
            type: 'get',
            async: false
        }).done(function (data) {
            $('#titile_giaidoan').html(data.giaiDoanNam);
        });
        $(".dieuchinh").show();
        $(".daunam").hide();
        $('#title_fromyear').html($('#Year').val());
        $('#title_toyear').html('');
    } else {
        $(".dieuchinh").hide();
        $(".daunam").show();
        $('#title_fromyear').html($('#FromYear').val());
        $('#title_toyear').html('-' + $('#ToYear').val());
    }
});

//thêm nhu cầu vốn
$("#AddKeHoachNhuCauVon").on('click', function () {

    loaikehoach = $("#LoaiKeHoach").val();
    if (loaikehoach === 'DIEU_CHINH') {
        year = $('#Year').val();
    } else {
        year = $('#FromYear').val();
        to_year = $('#ToYear').val();
    }

    if (chuDauTuId !== '') {
        congTrinhNganSachODAs = [];
        congTrinhNganSachTinhs = [];
        congTrinhNganSachTWs = [];
        abp.ajax({
            url: '/api/app/nhuCauKeHoachVon/notificationIsNew?tenKeHoach=TRUNG_HAN&loaikehoach=' + loaikehoach + '&nam=' + year + '&chuDauTuID=' + chuDauTuId,
            type: 'get',
            async: false
        }).done(function (data) {
            if (data.strNotification !== null) {
                abp.notify.info(data.strNotification);
            }
            else if (data.strNotification === null && data.idNhuCauKeHoachVonLuyKe !== "00000000-0000-0000-0000-000000000000") {
                if (loaikehoach === 'DIEU_CHINH') {
                    idBaoCao = data.idNhuCauKeHoachVonLuyKe;
                    abp.ajax({
                        url: '/api/app/nhuCauKeHoachVon/' + data.idNhuCauKeHoachVonLuyKe,
                        type: 'get',
                        async: false
                    }).done(function (result_data) {
                        status_DauNam = result_data.trangThaiDauNam;
                        status_DieuChinh = result_data.trangThaiDieuChinh;
                        thoiGiaGuiDauNam = result_data.thoiGianGuiBaoCaoDauNam;
                        year_last = result_data.tuNam;
                        to_year_last = result_data.denNam;
                        giai_doan = $('#Year').val();
                        if (status_DauNam === null) {
                            loaikehoachlast = 'dieuchinh';
                        }

                    });
                    abp.ajax({
                        url: '/api/app/nhuCauKeHoachVon/' + data.idNhuCauKeHoachVonLuyKe + '/nhuCauKeHoachVonChiTiet',
                        type: 'get',
                        async: false
                    }).done(function (result_data) {
                        nhuCauVonChiTietDauNam = result_data;
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
                } else {
                    abp.ajax({
                        url: '/api/app/nhuCauKeHoachVon/' + data.idNhuCauKeHoachVonLuyKe,
                        type: 'get',
                        async: false
                    }).done(function (result_data) {
                        status_DauNam = result_data.trangThaiDauNam;
                        status_DieuChinh = result_data.trangThaiDieuChinh;
                        thoiGiaGuiDauNam = result_data.thoiGianGuiBaoCaoDauNam;
                        year_last = result_data.tuNam;
                        to_year_last = result_data.denNam;
                        giai_doan = $('#Year').val();
                        if (status_DauNam === null) {
                            loaikehoachlast = 'dieuchinh';
                        }
                    });
                    abp.ajax({
                        url: '/api/app/nhuCauKeHoachVon/' + data.idNhuCauKeHoachVonLuyKe + '/nhuCauKeHoachVonChiTiet',
                        type: 'get',
                        async: false
                    }).done(function (result_data) {
                        nhuCauVonChiTietDauNam = result_data;
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
                }


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

//Xuất file excel
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

//-------------------------------------------------------------------------

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


