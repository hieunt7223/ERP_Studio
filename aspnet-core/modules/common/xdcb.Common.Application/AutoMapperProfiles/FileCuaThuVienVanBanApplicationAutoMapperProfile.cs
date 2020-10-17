using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using xdcb.Common.DanhMuc.FileCuaThuVienVanBanDtos;
using xdcb.Common.DanhMuc.FileCuaThuVienVanBans;

namespace xdcb.Common.DanhMuc
{
    public class FileCuaThuVienVanBanApplicationAutoMapperProfile : Profile
    {
        public FileCuaThuVienVanBanApplicationAutoMapperProfile()
        {
            CreateMap<FileCuaThuVienVanBan, FileCuaThuVienVanBanDto>();
            CreateMap<CreateUpdateFileCuaThuVienVanBanDto, FileCuaThuVienVanBan>();
            CreateMap<FileCuaThuVienVanBanDto, CreateUpdateFileCuaThuVienVanBanDto>();
        }
    }
}
