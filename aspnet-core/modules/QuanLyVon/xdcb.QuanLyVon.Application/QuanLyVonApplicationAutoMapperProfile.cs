using AutoMapper;
using xdcb.QuanLyVon.KeHoachTongNguon.Dtos;
using xdcb.QuanLyVon.KeHoachTongNguonChiTiet.Dtos;
using xdcb.QuanLyVon.KeHoachVonNQ.Dtos;
using xdcb.QuanLyVon.KeHoachVonNQChiTiet.Dtos;
using xdcb.QuanLyVon.KeHoachVonNSTW.Dtos;
using xdcb.QuanLyVon.KeHoachVonNSTWChiTiet.Dtos;
using xdcb.QuanLyVon.KeHoachVonNST.Dtos;
using xdcb.QuanLyVon.KeHoachVonNSTChiTiet.Dtos;
using xdcb.QuanLyVon.NhuCauKeHoachVon.Dtos;
using xdcb.QuanLyVon.NhuCauKeHoachVonChiTiet.Dtos;
using xdcb.QuanLyVon.GiaiNgan.Dtos;
using xdcb.QuanLyVon.GiaiNganChiTiet.Dtos;

namespace xdcb.QuanLyVon
{
    public class QuanLyVonApplicationAutoMapperProfile : Profile
    {
        public QuanLyVonApplicationAutoMapperProfile()
        {
            #region KeHoachTongNguon

            CreateMap<KeHoachTongNguons.KeHoachTongNguon, KeHoachTongNguonDto>();
            CreateMap<CreateUpdateKeHoachTongNguonDto, KeHoachTongNguons.KeHoachTongNguon>();
            CreateMap<KeHoachTongNguonDto, CreateUpdateKeHoachTongNguonDto>();

            #endregion KeHoachTongNguon

            #region KeHoachTongNguonChiTiet

            CreateMap<KeHoachTongNguonChiTiets.KeHoachTongNguonChiTiet, KeHoachTongNguonChiTietDto>();
            CreateMap<CreateUpdateKeHoachTongNguonChiTietDto, KeHoachTongNguonChiTiets.KeHoachTongNguonChiTiet>();

            #endregion KeHoachTongNguonChiTiet

            #region NhuCauKeHoachVon

            CreateMap<NhuCauKeHoachVons.NhuCauKeHoachVon, NhuCauKeHoachVonDto>();
            CreateMap<CreateUpdateNhuCauKeHoachVonDto, NhuCauKeHoachVons.NhuCauKeHoachVon>();
            CreateMap<NhuCauKeHoachVonDto, CreateUpdateNhuCauKeHoachVonDto>();

            #endregion NhuCauKeHoachVon

            #region NhuCauKeHoachVonChiTiet

            CreateMap<NhuCauKeHoachVonChiTiets.NhuCauKeHoachVonChiTiet, NhuCauKeHoachVonChiTietDto>();
            CreateMap<CreateUpdateNhuCauKeHoachVonChiTietDto, NhuCauKeHoachVonChiTiets.NhuCauKeHoachVonChiTiet>();
            CreateMap<NhuCauKeHoachVonChiTietDto, CreateUpdateNhuCauKeHoachVonChiTietDto>();

            #endregion NhuCauKeHoachVonChiTiet

            #region KeHoachVonNQ

            CreateMap<KeHoachVonNQs.KeHoachVonNQ, KeHoachVonNQDto>();
            CreateMap<CreateUpdateKeHoachVonNQDto, KeHoachVonNQs.KeHoachVonNQ>();
            CreateMap<KeHoachVonNQDto, CreateUpdateKeHoachVonNQDto>();

            #endregion KeHoachVonNQ

            #region KeHoachVonNQChiTiet

            CreateMap<KeHoachVonNQChiTiets.KeHoachVonNQChiTiet, KeHoachVonNQChiTietDto>();
            CreateMap<CreateUpdateKeHoachVonNQChiTietDto, KeHoachVonNQChiTiets.KeHoachVonNQChiTiet>();
            CreateMap<KeHoachVonNQChiTietDto, CreateUpdateKeHoachVonNQChiTietDto>();
            #endregion

            #region KeHoachVonNSTW
            CreateMap<KeHoachVonNSTWs.KeHoachVonNSTW, KeHoachVonNSTWDto>();
            CreateMap<CreateUpdateKeHoachVonNSTWDto, KeHoachVonNSTWs.KeHoachVonNSTW>();
            CreateMap<KeHoachVonNSTWDto, CreateUpdateKeHoachVonNSTWDto>();
            #endregion

            #region KeHoachVonNSTWChiTiet
            CreateMap<KeHoachVonNSTWChiTiets.KeHoachVonNSTWChiTiet, KeHoachVonNSTWChiTietDto>();
            CreateMap<CreateUpdateKeHoachVonNSTWChiTietDto, KeHoachVonNSTWChiTiets.KeHoachVonNSTWChiTiet>();
            CreateMap<KeHoachVonNSTWChiTietDto, CreateUpdateKeHoachVonNSTWChiTietDto>();
            #endregion


            #region KeHoachVonNST

            CreateMap<KeHoachVonNSTs.KeHoachVonNST, KeHoachVonNSTDto>();
            CreateMap<CreateUpdateKeHoachVonNSTDto, KeHoachVonNSTs.KeHoachVonNST>();
            CreateMap<KeHoachVonNSTDto, CreateUpdateKeHoachVonNSTDto>();

            #endregion KeHoachVonNST

            #region KeHoachVonNSTChiTiet

            CreateMap<KeHoachVonNSTChiTiets.KeHoachVonNSTChiTiet, KeHoachVonNSTChiTietDto>();
            CreateMap<CreateUpdateKeHoachVonNSTChiTietDto, KeHoachVonNSTChiTiets.KeHoachVonNSTChiTiet>();
            CreateMap<KeHoachVonNSTChiTietDto, CreateUpdateKeHoachVonNSTChiTietDto>();

            #endregion KeHoachVonNSTChiTiet

            #region GiaiNgan
            CreateMap<GiaiNgans.GiaiNgan, GiaiNganDto>();
            CreateMap<CreateUpdateGiaiNganDto, GiaiNgans.GiaiNgan>();
            CreateMap<GiaiNganDto, CreateUpdateGiaiNganDto>();
            #endregion

            #region GiaiNganChiTiet
            CreateMap<GiaiNganChiTiets.GiaiNganChiTiet, GiaiNganChiTietDto>();
            CreateMap<CreateUpdateGiaiNganChiTietDto, GiaiNganChiTiets.GiaiNganChiTiet>();
            CreateMap<GiaiNganChiTietDto, CreateUpdateGiaiNganChiTietDto>();
            #endregion

        }
    }
}