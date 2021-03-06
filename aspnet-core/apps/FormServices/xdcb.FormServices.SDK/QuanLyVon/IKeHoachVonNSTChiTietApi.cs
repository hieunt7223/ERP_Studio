﻿using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using xdcb.QuanLyVon.KeHoachVonNSTChiTiet.Dtos;

namespace xdcb.FormServices.SDK
{
    public interface IKeHoachVonNSTChiTietApi
    {
        #region Generated By Column

        [Get("/api/app/KeHoachVonNSTChiTiet")]
        Task<List<KeHoachVonNSTChiTietDto>> GetListAsync();

        [Post("/api/app/KeHoachVonNSTChiTiet")]
        Task<KeHoachVonNSTChiTietDto> Create([Body] CreateUpdateKeHoachVonNSTChiTietDto info);

        [Get("/api/app/KeHoachVonNSTChiTiet/{Id}")]
        Task<KeHoachVonNSTChiTietDto> GetAsync(Guid Id);

        [Put("/api/app/KeHoachVonNSTChiTiet/{Id}")]
        Task<KeHoachVonNSTChiTietDto> Update(Guid Id, [Body] CreateUpdateKeHoachVonNSTChiTietDto info);

        [Delete("/api/app/KeHoachVonNSTChiTiet/{Id}")]
        Task Delete(Guid Id);

        [Get("/api/app/keHoachVonNST/{id}/keHoachVonNSTChiTiet")]
        Task<List<KeHoachVonNSTChiTietDto>> GetListByKeHoachVonNSTIdAsync(Guid id);

        [Delete("/api/app/keHoachVonNST/{id}/keHoachVonNSTChiTiet")]
        Task DeleteByKeHoachVonNSTId(Guid id);

        [Get("/api/app/congTrinh/{id}/keHoachVonNSTChiTiet")]
        Task<List<KeHoachVonNSTChiTietDto>> GetListByCongTrinhIdAsync(Guid id);

        [Delete("/api/app/congTrinh/{id}/keHoachVonNSTChiTiet")]
        Task DeleteByCongTrinhId(Guid id);

        #endregion Generated By Column

        #region #Property

        [Put("/api/app/keHoachVonNSTDieuChinhChiTietById/{id}")]
        Task DeleteKeHoachVonNSTDieuChinhChiTietById(Guid id);

        [Put("/api/app/keHoachVonNST/{id}keHoachVonNSTDieuChinhChiTiet")]
        Task DeleteDataDieuChinhByKeHoachVonNSTID(Guid id);

        [Get("/api/app/keHoachVonNSTChiTiet/dataLuyKeByNam")]
        Task<List<KeHoachVonNSTChiTietDto>> GetDataLuyKeByNam(int nam);

        #endregion #Property
    }
}