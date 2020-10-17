using System;
using System.Collections.Generic;
using System.Text;

namespace xdcb.HoSoCongTrinh.Constants
{
    public class Query
    {
        public const string UpdateHoSoCongTrinh = "UPDATE [hsct].[HoSoCongTrinhs] SET TrangThai = {0}, SoLanDieuChinh = {1}, LastModificationTime = {2} WHERE Id = {3}";

        public const string UpdateHoSoCongTrinhChiTiet =
            "UPDATE [hsct].[HoSoCongTrinhChiTiets] SET TrangThai = {0}, SoLanDieuChinh = {1}, SuCanThietDauTu = {2}, QuyMoDauTu = {3}, NguonVonDauTu = {4}, LastModificationTime = {5} WHERE Id = {6}";

        public const string InsertHSCTChiTietDiaDiem =
            "INSERT INTO [hsct].[HoSoCongTrinhChiTietDiaDiems] (Id, CreationTime, HoSoCongTrinhChiTietId, DonViHanhChinhId, GhiChu, IsDeleted) VALUES ({0},{1},{2},{3},{4},{5})";

        public const string UpdateHSCTChiTietDiaDiem =
            "UPDATE [hsct].[HoSoCongTrinhChiTietDiaDiems] SET GhiChu = {0}, DonViHanhChinhId = {1}, LastModificationTime = {2} WHERE Id = {3}";

        public const string DeleteHSCTChiTietDiaDiem =
            "UPDATE [hsct].[HoSoCongTrinhChiTietDiaDiems] SET IsDeleted = {0}, DeletionTime = {1} WHERE Id = {2}";

        public const string InsertHSCTChiTietMucDauTu =
            "INSERT INTO [hsct].[HoSoCongTrinhChiTietMucDauTus] (Id, CreationTime, HoSoCongTrinhChiTietId, ChiPhiDauTuId, SoTien, SoTienThamDinh, IsDeleted) VALUES ({0},{1},{2},{3},{4},{5},{6})";

        public const string UpdateHSCTChiTietMucDauTu =
            "UPDATE [hsct].[HoSoCongTrinhChiTietMucDauTus] SET ChiPhiDauTuId = {0}, SoTien = {1}, SoTienThamDinh = {2}, LastModificationTime = {3} WHERE Id = {4}";

        public const string DeleteHSCTChiTietMucDauTu =
            "UPDATE [hsct].[HoSoCongTrinhChiTietMucDauTus] SET IsDeleted = {0}, DeletionTime = {1} WHERE Id = {2}";

        public const string InsertHSCTChiTietThanhPhanHoSo =
            "INSERT INTO [hsct].[HoSoCongTrinhChiTietThanhPhanHoSos] (Id, CreationTime, HoSoCongTrinhChiTietId, ThanhPhanHoSoId, IsDeleted) VALUES ({0},{1},{2},{3},{4})";

        public const string UpdateHSCTChiTietThanhPhanHoSo =
            "UPDATE [hsct].[HoSoCongTrinhChiTietThanhPhanHoSos] SET ThanhPhanHoSoId = {0}, LastModificationTime = {1} WHERE Id = {2}";

        public const string DeleteHSCTChiTietThanhPhanHoSo =
            "UPDATE [hsct].[HoSoCongTrinhChiTietThanhPhanHoSos] SET IsDeleted = {0}, DeletionTime = {1} WHERE Id = {2}";

        public const string InsertHSCTChiTietCoSoPhapLy =
            "INSERT INTO [hsct].[HoSoCongTrinhChiTietCoSoPhapLys] (Id, CreationTime, HoSoCongTrinhChiTietId, ThuVienVanBanId, NoiDungJson, IsDeleted) VALUES ({0},{1},{2},{3},{4},{5})";

        public const string UpdateHSCTChiTietCoSoPhapLy =
            "UPDATE [hsct].[HoSoCongTrinhChiTietCoSoPhapLys] SET ThuVienVanBanId = {0}, NoiDungJson = {1}, LastModificationTime = {2} WHERE Id = {3}";

        public const string DeleteHSCTChiTietCoSoPhapLy =
            "UPDATE [hsct].[HoSoCongTrinhChiTietCoSoPhapLys] SET IsDeleted = {0}, DeletionTime = {1} WHERE Id = {2}";

        public const string InsertHSCTChiTietKetQuaThamDinh =
            "INSERT INTO [hsct].[HoSoCongTrinhChiTietKetQuaThamDinhs] (Id, CreationTime, HoSoCongTrinhChiTietId, FileId, IsDeleted) VALUES ({0},{1},{2},{3},{4})";

        public const string UpdateHSCTChiTietKetQuaThamDinh =
            "UPDATE [hsct].[HoSoCongTrinhChiTietKetQuaThamDinhs] SET FileId = {0}, LastModificationTime = {1} WHERE Id = {2}";

        public const string DeleteHSCTChiTietKetQuaThamDinh =
            "UPDATE [hsct].[HoSoCongTrinhChiTietKetQuaThamDinhs] SET IsDeleted = {0}, DeletionTime = {1} WHERE Id = {2}";
    }
}
