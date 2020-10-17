using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using xdcb.Common.Localization;

namespace xdcb.Common.Permissions
{
    public class xdcbPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(xdcbCommonPermissions.GroupName);

            //Define your own permissions here. Example:
            var loaiCongTrinh = myGroup.AddPermission(xdcbCommonPermissions.LoaiCongTrinhPermission.Default, L("Permission:Loại Công Trình"));
            loaiCongTrinh.AddChild(xdcbCommonPermissions.LoaiCongTrinhPermission.Management, L("Read"));
            loaiCongTrinh.AddChild(xdcbCommonPermissions.LoaiCongTrinhPermission.Update, L("Edit"));
            loaiCongTrinh.AddChild(xdcbCommonPermissions.LoaiCongTrinhPermission.Delete, L("Delete"));
            loaiCongTrinh.AddChild(xdcbCommonPermissions.LoaiCongTrinhPermission.Create, L("Create"));

            // Đơn vị hành chính
            var donViHanhChinh = myGroup.AddPermission(xdcbCommonPermissions.DonViHanhChinhPermission.Default, L("Permission:Đơn vị hành chính"));
            donViHanhChinh.AddChild(xdcbCommonPermissions.DonViHanhChinhPermission.Management, L("Read"));
            donViHanhChinh.AddChild(xdcbCommonPermissions.DonViHanhChinhPermission.Update, L("Edit"));
            donViHanhChinh.AddChild(xdcbCommonPermissions.DonViHanhChinhPermission.Delete, L("Delete"));
            donViHanhChinh.AddChild(xdcbCommonPermissions.DonViHanhChinhPermission.Create, L("Create"));

            // Đơn vị ban hành
            var donViBanHanh = myGroup.AddPermission(xdcbCommonPermissions.DonViBanHanhPermission.Default, L("Permission:Đơn vị ban hành"));
            donViBanHanh.AddChild(xdcbCommonPermissions.DonViBanHanhPermission.Management, L("Read"));
            donViBanHanh.AddChild(xdcbCommonPermissions.DonViBanHanhPermission.Update, L("Edit"));
            donViBanHanh.AddChild(xdcbCommonPermissions.DonViBanHanhPermission.Delete, L("Delete"));
            donViBanHanh.AddChild(xdcbCommonPermissions.DonViBanHanhPermission.Create, L("Create"));

            // Loại văn bản
            var loaiVanBan = myGroup.AddPermission(xdcbCommonPermissions.LoaiVanBanPermission.Default, L("Permission:Loại văn bản"));
            loaiVanBan.AddChild(xdcbCommonPermissions.LoaiVanBanPermission.Management, L("Read"));
            loaiVanBan.AddChild(xdcbCommonPermissions.LoaiVanBanPermission.Update, L("Edit"));
            loaiVanBan.AddChild(xdcbCommonPermissions.LoaiVanBanPermission.Delete, L("Delete"));
            loaiVanBan.AddChild(xdcbCommonPermissions.LoaiVanBanPermission.Create, L("Create"));

            // Độ ưu tiên
            var doUuTien = myGroup.AddPermission(xdcbCommonPermissions.DoUuTienPermission.Default, L("Permission:Độ ưu tiên"));
            doUuTien.AddChild(xdcbCommonPermissions.DoUuTienPermission.Management, L("Read"));
            doUuTien.AddChild(xdcbCommonPermissions.DoUuTienPermission.Update, L("Edit"));
            doUuTien.AddChild(xdcbCommonPermissions.DoUuTienPermission.Delete, L("Delete"));
            doUuTien.AddChild(xdcbCommonPermissions.DoUuTienPermission.Create, L("Create"));

            // Lĩnh vực văn bản
            var linhVucVanBan = myGroup.AddPermission(xdcbCommonPermissions.LinhVucVanBanPermission.Default, L("Permission:Lĩnh vực văn bản"));
            linhVucVanBan.AddChild(xdcbCommonPermissions.LinhVucVanBanPermission.Management, L("Read"));
            linhVucVanBan.AddChild(xdcbCommonPermissions.LinhVucVanBanPermission.Update, L("Edit"));
            linhVucVanBan.AddChild(xdcbCommonPermissions.LinhVucVanBanPermission.Delete, L("Delete"));
            linhVucVanBan.AddChild(xdcbCommonPermissions.LinhVucVanBanPermission.Create, L("Create"));

            // Nhóm công trình
            var nhomCongTrinh = myGroup.AddPermission(xdcbCommonPermissions.NhomCongTrinhPermission.Default, L("Permission:Nhóm công trình"));
            nhomCongTrinh.AddChild(xdcbCommonPermissions.NhomCongTrinhPermission.Management, L("Read"));
            nhomCongTrinh.AddChild(xdcbCommonPermissions.NhomCongTrinhPermission.Update, L("Edit"));
            nhomCongTrinh.AddChild(xdcbCommonPermissions.NhomCongTrinhPermission.Delete, L("Delete"));
            nhomCongTrinh.AddChild(xdcbCommonPermissions.NhomCongTrinhPermission.Create, L("Create"));

            // Loại khoản
            var loaiKhoan = myGroup.AddPermission(xdcbCommonPermissions.LoaiKhoanPermission.Default, L("Permission:Loại khoản"));
            loaiKhoan.AddChild(xdcbCommonPermissions.LoaiKhoanPermission.Management, L("Read"));
            loaiKhoan.AddChild(xdcbCommonPermissions.LoaiKhoanPermission.Update, L("Edit"));
            loaiKhoan.AddChild(xdcbCommonPermissions.LoaiKhoanPermission.Delete, L("Delete"));
            loaiKhoan.AddChild(xdcbCommonPermissions.LoaiKhoanPermission.Create, L("Create"));

            // nguồn vốn
            var nguonVon = myGroup.AddPermission(xdcbCommonPermissions.NguonVonPermission.Default, L("Permission:Nguồn vốn"));
            nguonVon.AddChild(xdcbCommonPermissions.NguonVonPermission.Management, L("Read"));
            nguonVon.AddChild(xdcbCommonPermissions.NguonVonPermission.Update, L("Edit"));
            nguonVon.AddChild(xdcbCommonPermissions.NguonVonPermission.Delete, L("Delete"));
            nguonVon.AddChild(xdcbCommonPermissions.NguonVonPermission.Create, L("Create"));

            // khoản chi
            var khoanChi = myGroup.AddPermission(xdcbCommonPermissions.KhoanChiPermission.Default, L("Permission:Khoản chi"));
            khoanChi.AddChild(xdcbCommonPermissions.KhoanChiPermission.Management, L("Read"));
            khoanChi.AddChild(xdcbCommonPermissions.KhoanChiPermission.Update, L("Edit"));
            khoanChi.AddChild(xdcbCommonPermissions.KhoanChiPermission.Delete, L("Delete"));
            khoanChi.AddChild(xdcbCommonPermissions.KhoanChiPermission.Create, L("Create"));

            // hạng mục công trình
            var hangMucCongTrinh = myGroup.AddPermission(xdcbCommonPermissions.HangMucCongTrinhPermission.Default, L("Permission:Hạng mục công trình"));
            hangMucCongTrinh.AddChild(xdcbCommonPermissions.HangMucCongTrinhPermission.Management, L("Read"));
            hangMucCongTrinh.AddChild(xdcbCommonPermissions.HangMucCongTrinhPermission.Update, L("Edit"));
            hangMucCongTrinh.AddChild(xdcbCommonPermissions.HangMucCongTrinhPermission.Delete, L("Delete"));
            hangMucCongTrinh.AddChild(xdcbCommonPermissions.HangMucCongTrinhPermission.Create, L("Create"));

            // thành phần hồ sơ
            var thanhPhanHoSo = myGroup.AddPermission(xdcbCommonPermissions.ThanhPhanHoSoPermission.Default, L("Permission:Thành phần hồ sơ"));
            thanhPhanHoSo.AddChild(xdcbCommonPermissions.ThanhPhanHoSoPermission.Management, L("Read"));
            thanhPhanHoSo.AddChild(xdcbCommonPermissions.ThanhPhanHoSoPermission.Update, L("Edit"));
            thanhPhanHoSo.AddChild(xdcbCommonPermissions.ThanhPhanHoSoPermission.Delete, L("Delete"));
            thanhPhanHoSo.AddChild(xdcbCommonPermissions.ThanhPhanHoSoPermission.Create, L("Create"));

            // chức vụ
            var chucVu = myGroup.AddPermission(xdcbCommonPermissions.ChucVuPermission.Default, L("Permission:Chức vụ"));
            chucVu.AddChild(xdcbCommonPermissions.ChucVuPermission.Management, L("Read"));
            chucVu.AddChild(xdcbCommonPermissions.ChucVuPermission.Update, L("Edit"));
            chucVu.AddChild(xdcbCommonPermissions.ChucVuPermission.Delete, L("Delete"));
            chucVu.AddChild(xdcbCommonPermissions.ChucVuPermission.Create, L("Create"));

            // hình thức hợp đồng
            var hinhThucHopDong = myGroup.AddPermission(xdcbCommonPermissions.HinhThucHopDongPermission.Default, L("Permission:Hình thức hợp đồng"));
            hinhThucHopDong.AddChild(xdcbCommonPermissions.HinhThucHopDongPermission.Management, L("Read"));
            hinhThucHopDong.AddChild(xdcbCommonPermissions.HinhThucHopDongPermission.Update, L("Edit"));
            hinhThucHopDong.AddChild(xdcbCommonPermissions.HinhThucHopDongPermission.Delete, L("Delete"));
            hinhThucHopDong.AddChild(xdcbCommonPermissions.HinhThucHopDongPermission.Create, L("Create"));

            // hình thức lựa chọn nhà thầu
            var hinhThucLuaChonNhaThau = myGroup.AddPermission(xdcbCommonPermissions.HinhThucLuaChonNhaThauPermission.Default, L("Permission:Hình thức lựa chọn nhà thầu"));
            hinhThucLuaChonNhaThau.AddChild(xdcbCommonPermissions.HinhThucLuaChonNhaThauPermission.Management, L("Read"));
            hinhThucLuaChonNhaThau.AddChild(xdcbCommonPermissions.HinhThucLuaChonNhaThauPermission.Update, L("Edit"));
            hinhThucLuaChonNhaThau.AddChild(xdcbCommonPermissions.HinhThucLuaChonNhaThauPermission.Delete, L("Delete"));
            hinhThucLuaChonNhaThau.AddChild(xdcbCommonPermissions.HinhThucLuaChonNhaThauPermission.Create, L("Create"));

            // phương thức đấu thầu
            var phuongThucDauThau = myGroup.AddPermission(xdcbCommonPermissions.PhuongThucDauThauPermission.Default, L("Permission:Phương thức đấu thầu"));
            phuongThucDauThau.AddChild(xdcbCommonPermissions.PhuongThucDauThauPermission.Management, L("Read"));
            phuongThucDauThau.AddChild(xdcbCommonPermissions.PhuongThucDauThauPermission.Update, L("Edit"));
            phuongThucDauThau.AddChild(xdcbCommonPermissions.PhuongThucDauThauPermission.Delete, L("Delete"));
            phuongThucDauThau.AddChild(xdcbCommonPermissions.PhuongThucDauThauPermission.Create, L("Create"));

            // mã chương
            var maChuong = myGroup.AddPermission(xdcbCommonPermissions.MaChuongPermission.Default, L("Permission:Mã chương"));
            maChuong.AddChild(xdcbCommonPermissions.MaChuongPermission.Management, L("Read"));
            maChuong.AddChild(xdcbCommonPermissions.MaChuongPermission.Update, L("Edit"));
            maChuong.AddChild(xdcbCommonPermissions.MaChuongPermission.Delete, L("Delete"));
            maChuong.AddChild(xdcbCommonPermissions.MaChuongPermission.Create, L("Create"));

            // nghị quyết
            var nghiQuyet = myGroup.AddPermission(xdcbCommonPermissions.NghiQuyetPermission.Default, L("Permission:Nghị quyết"));
            nghiQuyet.AddChild(xdcbCommonPermissions.NghiQuyetPermission.Management, L("Read"));
            nghiQuyet.AddChild(xdcbCommonPermissions.NghiQuyetPermission.Update, L("Edit"));
            nghiQuyet.AddChild(xdcbCommonPermissions.NghiQuyetPermission.Delete, L("Delete"));
            nghiQuyet.AddChild(xdcbCommonPermissions.NghiQuyetPermission.Create, L("Create"));

            // chương trình mục tiêu và dự án quốc gia
            var chuongTrinhMucTieuVaDuAnQuocGia = myGroup.AddPermission(xdcbCommonPermissions.ChuongTrinhMucTieuVaDuAnQuocGiaPermission.Default, L("Permission:Chương trình mục tiêu và dự án quốc gia"));
            chuongTrinhMucTieuVaDuAnQuocGia.AddChild(xdcbCommonPermissions.ChuongTrinhMucTieuVaDuAnQuocGiaPermission.Management, L("Read"));
            chuongTrinhMucTieuVaDuAnQuocGia.AddChild(xdcbCommonPermissions.ChuongTrinhMucTieuVaDuAnQuocGiaPermission.Update, L("Edit"));
            chuongTrinhMucTieuVaDuAnQuocGia.AddChild(xdcbCommonPermissions.ChuongTrinhMucTieuVaDuAnQuocGiaPermission.Delete, L("Delete"));
            chuongTrinhMucTieuVaDuAnQuocGia.AddChild(xdcbCommonPermissions.ChuongTrinhMucTieuVaDuAnQuocGiaPermission.Create, L("Create"));

            // chi phí đầu tư
            var chiPhiDauTu = myGroup.AddPermission(xdcbCommonPermissions.ChiPhiDauTuPermission.Default, L("Permission:Chí phí đầu tư"));
            chiPhiDauTu.AddChild(xdcbCommonPermissions.ChiPhiDauTuPermission.Management, L("Read"));
            chiPhiDauTu.AddChild(xdcbCommonPermissions.ChiPhiDauTuPermission.Update, L("Edit"));
            chiPhiDauTu.AddChild(xdcbCommonPermissions.ChiPhiDauTuPermission.Delete, L("Delete"));
            chiPhiDauTu.AddChild(xdcbCommonPermissions.ChiPhiDauTuPermission.Create, L("Create"));

            // thư viện văn bản
            var thuVienVanBan = myGroup.AddPermission(xdcbCommonPermissions.ThuVienVanBanPermission.Default, L("Permission:Thư viện văn bản"));
            thuVienVanBan.AddChild(xdcbCommonPermissions.ThuVienVanBanPermission.Management, L("Read"));
            thuVienVanBan.AddChild(xdcbCommonPermissions.ThuVienVanBanPermission.Update, L("Edit"));
            thuVienVanBan.AddChild(xdcbCommonPermissions.ThuVienVanBanPermission.Delete, L("Delete"));
            thuVienVanBan.AddChild(xdcbCommonPermissions.ThuVienVanBanPermission.Create, L("Create"));

            // phòng ban
            var phongBan = myGroup.AddPermission(xdcbCommonPermissions.PhongBanPermission.Default, L("Permission:Phòng ban"));
            phongBan.AddChild(xdcbCommonPermissions.PhongBanPermission.Management, L("Read"));
            phongBan.AddChild(xdcbCommonPermissions.PhongBanPermission.Update, L("Edit"));
            phongBan.AddChild(xdcbCommonPermissions.PhongBanPermission.Delete, L("Delete"));
            phongBan.AddChild(xdcbCommonPermissions.PhongBanPermission.Create, L("Create"));

            // loại hồ sơ
            var loaiHoSo = myGroup.AddPermission(xdcbCommonPermissions.LoaiHoSoPermission.Default, L("Permission:Loại hồ sơ"));
            loaiHoSo.AddChild(xdcbCommonPermissions.LoaiHoSoPermission.Management, L("Read"));
            loaiHoSo.AddChild(xdcbCommonPermissions.LoaiHoSoPermission.Update, L("Edit"));
            loaiHoSo.AddChild(xdcbCommonPermissions.LoaiHoSoPermission.Delete, L("Delete"));
            loaiHoSo.AddChild(xdcbCommonPermissions.LoaiHoSoPermission.Create, L("Create"));

            // công trình
            var congTrinh = myGroup.AddPermission(xdcbCommonPermissions.CongTrinhPermission.Default, L("Permission:Công trình"));
            congTrinh.AddChild(xdcbCommonPermissions.CongTrinhPermission.Management, L("Read"));
            congTrinh.AddChild(xdcbCommonPermissions.CongTrinhPermission.Update, L("Edit"));
            congTrinh.AddChild(xdcbCommonPermissions.CongTrinhPermission.Delete, L("Delete"));
            congTrinh.AddChild(xdcbCommonPermissions.CongTrinhPermission.Create, L("Create"));

            // chủ đầu tư
            var chuDauTu = myGroup.AddPermission(xdcbCommonPermissions.ChuDauTuPermission.Default, L("Permission:Chủ đầu tư"));
            chuDauTu.AddChild(xdcbCommonPermissions.ChuDauTuPermission.Management, L("Read"));
            chuDauTu.AddChild(xdcbCommonPermissions.ChuDauTuPermission.Update, L("Edit"));
            chuDauTu.AddChild(xdcbCommonPermissions.ChuDauTuPermission.Delete, L("Delete"));
            chuDauTu.AddChild(xdcbCommonPermissions.ChuDauTuPermission.Create, L("Create"));

            // Ngành lĩnh vực sử dụng
            var nganhLinhVuc = myGroup.AddPermission(xdcbCommonPermissions.NganhLinhVucPermission.Default, L("Permission:Ngành lĩnh vực sử dụng"));
            nganhLinhVuc.AddChild(xdcbCommonPermissions.NganhLinhVucPermission.Management, L("Read"));
            nganhLinhVuc.AddChild(xdcbCommonPermissions.NganhLinhVucPermission.Update, L("Edit"));
            nganhLinhVuc.AddChild(xdcbCommonPermissions.NganhLinhVucPermission.Delete, L("Delete"));
            nganhLinhVuc.AddChild(xdcbCommonPermissions.NganhLinhVucPermission.Create, L("Create"));

            // gói thầu
            var goiThau = myGroup.AddPermission(xdcbCommonPermissions.GoiThauPermission.Default, L("Permission:Gói thầu"));
            goiThau.AddChild(xdcbCommonPermissions.GoiThauPermission.Management, L("Read"));
            goiThau.AddChild(xdcbCommonPermissions.GoiThauPermission.Update, L("Edit"));
            goiThau.AddChild(xdcbCommonPermissions.GoiThauPermission.Delete, L("Delete"));
            goiThau.AddChild(xdcbCommonPermissions.GoiThauPermission.Create, L("Create"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<xdcbCommonResource>(name);
        }

    }
}
