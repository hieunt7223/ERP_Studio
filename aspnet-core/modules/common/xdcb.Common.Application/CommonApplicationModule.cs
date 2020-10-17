using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace xdcb.Common.DanhMuc
{
    [DependsOn(
       typeof(CommonDomainSharedModule),
        typeof(CommonApplicationContractsModule),
        typeof(CommonEntityFrameworkCoreModule)
   )]
    public class CommonApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<DonViHanhChinhApplicationAutoMapperProfile>();
                options.AddProfile<HangMucCongTrinhApplicationAutoMapperProfile>();
                options.AddProfile<HinhThucChonNhaThauApplicationAutoMapperProfile>();
                options.AddProfile<LinhVucVanBanApplicationAutoMapperProfile>();
                options.AddProfile<HinhThucHopDongApplicationAutoMapperProfile>();
                options.AddProfile<LoaiCongTrinhApplicationAutoMapperProfile>();
                options.AddProfile<NhomCongTrinhApplicationAutoMapperProfile>();
                options.AddProfile<DoUuTienApplicationAutoMapperProfile>();
                options.AddProfile<ChucVuApplicationAutoMapperProfile>();
                options.AddProfile<LoaiVanBanApplicationAutoMapperProfile>();
                options.AddProfile<LoaiKhoanApplicationAutoMapperProfile>();
                options.AddProfile<ChuDauTuApplicationAutoMapperProfile>();
                options.AddProfile<NghiQuyetApplicationAutoMapperProfile>();
                options.AddProfile<PhuongThucDauThauApplicationAutoMapperProfile>();
                options.AddProfile<ChuongTrinhMucTieuQuocGiaApplicationAutoMapperProfile>();
                options.AddProfile<NguonVonApplicationAutoMapperProfile>();
                options.AddProfile<KhoanChiApplicationAutoMapperProfile>();
                options.AddProfile<ThanhPhanHoSoApplicationAutoMapperProfile>();
                options.AddProfile<ChiPhiDauTuApplicationAutoMapperProfile>();
                options.AddProfile<ThuVienVanBanApplicationAutoMapperProfile>();
                options.AddProfile<FileCuaThuVienVanBanApplicationAutoMapperProfile>();
                options.AddProfile<PhongBanApplicationAutoMapperProfile>();
                options.AddProfile<LoaiHoSoApplicationAutoMapperProfile>();
                options.AddProfile<LoaiHoSoThanhPhanHoSoApplicationAutoMapperProfile>();
                options.AddProfile<LoaiHoSoChiPhiDauTuApplicationAutoMapperProfile>();
                options.AddProfile<LoaiHoSoCoSoPhapLyApplicationAutoMapperProfile>();
                options.AddProfile<CongTrinhApplicationAutoMapperProfile>();
                options.AddProfile<NganhLinhVucSuDungApplicationAutoMapperProfile>();
                options.AddProfile<DonViBanHanhApplicationAutoMapperProfile>();
                options.AddProfile<GoiThauApplicationAutoMapperProfile>();
                options.AddProfile<LoaiGoiThauApplicationAutoMapperProfile>();
                options.AddProfile<CongViecGoiThauApplicationAutoMapperProfile>();
            });
        }
    }
}