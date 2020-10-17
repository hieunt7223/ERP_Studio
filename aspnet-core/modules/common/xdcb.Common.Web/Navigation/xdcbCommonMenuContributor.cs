using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;
using xdcb.Common.Permissions;

namespace xdcb.Common
{
    public class xdcbCommonMenuContributor : IMenuContributor
    {
        public virtual async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            // Thư viện văn bản
            var thuVienVanBan = await context.IsGrantedAsync(xdcbCommonPermissions.ThuVienVanBanPermission.Default);
            if (thuVienVanBan)
            {
                context.Menu.AddItem(new ApplicationMenuItem("xdcb.ThuVienVanBan", "Thư viện văn bản", url: "/ThuVienVanBan",icon: "fa fa-file-text-o", order: 3));
            }

            // Danh mục
            context.Menu.AddItem(new ApplicationMenuItem("DanhMuc", "Danh Mục", icon: "fa fa-folder-o", order: 7));

            // Loai công trình
            var loaiCongTrinh = await context.IsGrantedAsync(xdcbCommonPermissions.LoaiCongTrinhPermission.Default);
            if (loaiCongTrinh)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.LoaiCongTrinh", "Loại công trình", url: "/LoaiCongTrinh"));
            }

            // Nhóm công trình
            var nhomCongTrinh = await context.IsGrantedAsync(xdcbCommonPermissions.NhomCongTrinhPermission.Default);
            if (nhomCongTrinh)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.NhomCongTrinh", "Nhóm công trình", url: "/NhomCongTrinh"));
            }

            // Đơn vị hành chính
            var donViHanhChinh = await context.IsGrantedAsync(xdcbCommonPermissions.DonViHanhChinhPermission.Default);
            if (donViHanhChinh)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.DonViHanhChinh", "Đơn vị hành chính", url: "/DonViHanhChinh"));
            }

            // Đơn vị ban hành
            var donViBanHanh = await context.IsGrantedAsync(xdcbCommonPermissions.DonViBanHanhPermission.Default);
            if (donViBanHanh)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.DonViBanHanh", "Đơn vị ban hành", url: "/DonViBanHanh"));
            }

            // DoUuTien
            var doUuTien = await context.IsGrantedAsync(xdcbCommonPermissions.DoUuTienPermission.Default);
            if (doUuTien)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.DoUuTien", "Độ ưu tiên", url: "/DoUuTien"));
            }

            // DoUuTien
            var chucVu = await context.IsGrantedAsync(xdcbCommonPermissions.ChucVuPermission.Default);
            if (chucVu)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.ChucVu", "Chức vụ", url: "/ChucVu"));
            }

            // Loai - Khoan
            var loaiKhoan = await context.IsGrantedAsync(xdcbCommonPermissions.LoaiKhoanPermission.Default);
            if (loaiKhoan)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.LoaiKhoan", "Mã loại - khoản", url: "/LoaiKhoan"));
            }
            
            // Hinh thuc hop dong
            var hinhThucHopDong = await context.IsGrantedAsync(xdcbCommonPermissions.HinhThucHopDongPermission.Default);
            if (hinhThucHopDong)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.HinhThucHopDong", "Loại hợp đồng", url: "/HinhThucHopDong"));
            }

            // LinhVucVanBan 
            var linhVucVanBan = await context.IsGrantedAsync(xdcbCommonPermissions.LinhVucVanBanPermission.Default);
            if (linhVucVanBan)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.LinhVucVanBan", "Lĩnh Vực Văn Bản", url: "/LinhVucVanBan"));
            }

            //NghiQuyet
            var nghiQuyet = await context.IsGrantedAsync(xdcbCommonPermissions.NghiQuyetPermission.Default);
            if (nghiQuyet)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.NghiQuyet", "Nghị quyết", url: "/NghiQuyet"));
            }

            //LoaiVanBan
            var loaiVanBan = await context.IsGrantedAsync(xdcbCommonPermissions.LoaiVanBanPermission.Default);
            if (loaiVanBan)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.LoaiVanBan", "Loại Văn Bản", url: "/LoaiVanBan"));
            }

            // Todo: ChuDauTu
            var ChuDauTu = await context.IsGrantedAsync(xdcbCommonPermissions.ChuDauTuPermission.Default);
            if (ChuDauTu)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.ChuDauTu", "Chủ đầu tư", url: "/ChuDauTu"));
            }

            // HinhThucChonNhaThau
            var hinhThucChonNhaThau = await context.IsGrantedAsync(xdcbCommonPermissions.HinhThucLuaChonNhaThauPermission.Default);
            if (hinhThucChonNhaThau)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.HinhThucChonNhaThau", "Hình thức lựa chọn nhà thầu", url: "/HinhThucChonNhaThau"));
            }

            // PhuongThucDauThau
            var phuongThucDauThau = await context.IsGrantedAsync(xdcbCommonPermissions.PhuongThucDauThauPermission.Default);
            if (phuongThucDauThau)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.PhuongThucDauThau", "Phương thức lựa chọn nhà thầu", url: "/PhuongThucDauThau"));
            }

            // ChuongTrinhMucTieuQuocGia
            var chuongTrinhMucTieuQuocGia = await context.IsGrantedAsync(xdcbCommonPermissions.ChuongTrinhMucTieuVaDuAnQuocGiaPermission.Default);
            if (chuongTrinhMucTieuQuocGia)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.ChuongTrinhMucTieuQuocGia", "Chương trình mục tiêu quốc gia", url: "/ChuongTrinhMucTieuQuocGia"));
            }

            // Nguồn vốn
            var nguonvon = await context.IsGrantedAsync(xdcbCommonPermissions.NguonVonPermission.Default);
            if (nguonvon)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.NguonVon", "Nguồn vốn", url: "/NguonVon"));
            }

            // KhoanChi
            var khoanChi = await context.IsGrantedAsync(xdcbCommonPermissions.KhoanChiPermission.Default);
            if (khoanChi)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.KhoanChi", "Khoản chi", url: "/KhoanChi"));
            }

            // ThanhPhanHoSo
            var thanhPhanHoSo = await context.IsGrantedAsync(xdcbCommonPermissions.ThanhPhanHoSoPermission.Default);
            if (thanhPhanHoSo)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.ThanhPhanHoSo", "Thành phần hồ sơ", url: "/ThanhPhanHoSo"));
            }

            // ChiPhiDauTuPermission
            var chiPhiDauTuPermission = await context.IsGrantedAsync(xdcbCommonPermissions.ChiPhiDauTuPermission.Default);
            if (chiPhiDauTuPermission)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.ChiPhiDauTu", "Chi Phí Đầu Tư", url: "/ChiPhiDauTu"));
            }

            // PhongBan
            var phongBan = await context.IsGrantedAsync(xdcbCommonPermissions.PhongBanPermission.Default);
            if (phongBan)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.PhongBan", "Phòng Ban", url: "/PhongBan"));
            }

            // LoaiHoSo
            var loaiHoSo = await context.IsGrantedAsync(xdcbCommonPermissions.LoaiHoSoPermission.Default);
            if (loaiHoSo)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.LoaiHoSo", "Loại hồ sơ", url: "/LoaiHoSo"));
            }

            // Todo: CongTrinh
            var congTrinh = await context.IsGrantedAsync(xdcbCommonPermissions.CongTrinhPermission.Default);
            if (congTrinh)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.CongTrinh", "Công trình", url: "/CongTrinh"));
            }

            // Ngành lĩnh vực sử dụng
            var nganhLinhVucSuDung = await context.IsGrantedAsync(xdcbCommonPermissions.NganhLinhVucPermission.Default);
            if (nganhLinhVucSuDung)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.NganhLinhVucSuDung", "Ngành lĩnh vực sử dụng", url: "/NganhLinhVucSuDung"));
            }

            // goi thau
            var goiThau = await context.IsGrantedAsync(xdcbCommonPermissions.GoiThauPermission.Default);
            if (goiThau)
            {
                context.Menu.FindMenuItem("DanhMuc").AddItem(new ApplicationMenuItem("xdcb.GoiThau", "Gói thầu", url: "/GoiThau"));
            }
        }
    }
}