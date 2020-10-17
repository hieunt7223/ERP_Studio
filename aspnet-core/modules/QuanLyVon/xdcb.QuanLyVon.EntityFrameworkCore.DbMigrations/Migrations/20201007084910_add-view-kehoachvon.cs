using Microsoft.EntityFrameworkCore.Migrations;

namespace xdcb.QuanLyVon.Migrations
{
    public partial class addviewkehoachvon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var script = @"
                CREATE VIEW [von].[vKeHoachVons]
				AS
				--KeHoachVonTheoNST
				SELECT			ct.Id
								, vct.Id											AS	KeHoachVonNSTChiTietId
								, NULL												AS  KeHoachVonNSTWChiTietId
								, NULL												AS  KeHoachVonODAChiTietId
								, v.Nam
								, v.LoaiKeHoach
								, vct.CongTrinhId
								, ct.MaCongTrinh
								, ct.TenCongTrinh
								, ct.ChuDauTuId
								, cdt.Ten											AS TenChuDauTu
								, ct.SoQuyetDinhDauTu
								, ct.NgayQuyetDinhDauTu
								, CAST(ISNULL(ct.NST,0) AS decimal(22,6)) 			AS	MucDauTuNST
								, CAST(ISNULL(ct.NSTW,0) AS decimal(22,6))			AS	MucDauTuNSTW
								, CAST(ISNULL(ct.ODA,0) AS decimal(22,6))			AS	MucDauTuODA
								, CAST(ISNULL(ct.TongMucDauTu,0) AS decimal(22,6))	AS	TongMucDauTu
								, CAST(	(CASE 
											WHEN v.LoaiKeHoach=N'DIEU_CHINH'
												THEN	vct.KeHoachVonDieuChinhDuocDuyet
											ELSE	vct.KeHoachVonDauNamDuocDuyet
										 END) AS decimal(22,6))	AS KeHoachVon 				
				FROM			von.KeHoachVonNSTChiTiets	vct	WITH(NOLOCK)
					INNER JOIN	common.CongTrinhs			ct	WITH(NOLOCK)	ON	vct.CongTrinhId=ct.Id
					INNER JOIN  common.ChuDauTus			cdt WITH(NOLOCK)	ON  ct.ChuDauTuId=cdt.Id
					OUTER APPLY (SELECT	(CASE 
											WHEN ISNULL(vs.TrangThaiDieuChinh,'')<>''
												THEN	N'DIEU_CHINH'
											ELSE	N'DAU_NAM'
										 END) AS LoaiKeHoach
										,(CASE 
												WHEN ISNULL(vs.TrangThaiDieuChinh,'')<>''
													THEN	vs.TrangThaiDieuChinh
												ELSE	vs.TrangThaiDauNam
										 END) AS TrangThai
										,  vs.Nam
								FROM	von.KeHoachVonNSTs  vs	WITH(NOLOCK)
								WHERE	vs.IsDeleted=0
									AND	vct.KeHoachVonNSTId=vs.Id
								)v
				WHERE			vct.IsDeleted=0
					AND			ct.IsDeleted=0
					AND			vct.CongTrinhId<>'00000000-0000-0000-0000-000000000000'
					AND			vct.CongTrinhId IS NOT NULL
					AND			v.TrangThai='HOAN_THANH'
					AND			(CASE 
									WHEN v.LoaiKeHoach=N'DIEU_CHINH'
										THEN	vct.IsDeleteDieuChinh
									ELSE	vct.IsSelectDieuChinh
								 END)=0
		
				UNION ALL

				--KeHoachVonTheoNSTW
				SELECT			ct.Id
								, NULL												AS	KeHoachVonNSTChiTietId
								, vct.Id											AS  KeHoachVonNSTWChiTietId
								, NULL												AS  KeHoachVonODAChiTietId
								, v.Nam
								, v.LoaiKeHoach
								, vct.CongTrinhId
								, ct.MaCongTrinh
								, ct.TenCongTrinh
								, ct.ChuDauTuId
								, cdt.Ten											AS TenChuDauTu
								, ct.SoQuyetDinhDauTu
								, ct.NgayQuyetDinhDauTu
								, CAST(ISNULL(ct.NST,0) AS decimal(22,6)) 			AS	MucDauTuNST
								, CAST(ISNULL(ct.NSTW,0) AS decimal(22,6))			AS	MucDauTuNSTW
								, CAST(ISNULL(ct.ODA,0) AS decimal(22,6))			AS	MucDauTuODA
								, CAST(ISNULL(ct.TongMucDauTu,0) AS decimal(22,6))	AS	TongMucDauTu
								, CAST(	(CASE 
											WHEN v.LoaiKeHoach=N'DIEU_CHINH'
												THEN	vct.KeHoachVonDieuChinhDuocDuyet
											ELSE	vct.KeHoachVonDauNamDuocDuyet
										 END) AS decimal(22,6))	AS KeHoachVon 				
				FROM			von.KeHoachVonNSTWChiTiets	vct	WITH(NOLOCK)
					INNER JOIN	common.CongTrinhs			ct	WITH(NOLOCK)	ON	vct.CongTrinhId=ct.Id
					INNER JOIN  common.ChuDauTus			cdt WITH(NOLOCK)	ON  ct.ChuDauTuId=cdt.Id
					OUTER APPLY (SELECT	(CASE 
											WHEN ISNULL(vs.TrangThaiDieuChinh,'')<>''
												THEN	N'DIEU_CHINH'
											ELSE	N'DAU_NAM'
										 END) AS LoaiKeHoach
										,(CASE 
												WHEN ISNULL(vs.TrangThaiDieuChinh,'')<>''
													THEN	vs.TrangThaiDieuChinh
												ELSE	vs.TrangThaiDauNam
										 END) AS TrangThai
										,  vs.Nam
								FROM	von.KeHoachVonNSTWs  vs	WITH(NOLOCK)
								WHERE	vs.IsDeleted=0
									AND	vct.KeHoachVonNSTWId=vs.Id
								)v
				WHERE			vct.IsDeleted=0
					AND			ct.IsDeleted=0
					AND			vct.CongTrinhId<>'00000000-0000-0000-0000-000000000000'
					AND			vct.CongTrinhId IS NOT NULL
					AND			v.TrangThai='HOAN_THANH'
					AND			(CASE 
									WHEN v.LoaiKeHoach=N'DIEU_CHINH'
										THEN	vct.IsDeleteDieuChinh
									ELSE	vct.IsSelectDieuChinh
								 END)=0
				GO

            ";
            migrationBuilder.Sql(script);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
