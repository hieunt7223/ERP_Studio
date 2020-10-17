using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGiaDtos;

namespace xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGias
{
    public class ChuongTrinhMucTieuQuocGiaAppService :
        CrudAppService<ChuongTrinhMucTieuQuocGia,
            ChuongTrinhMucTieuQuocGiaDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateChuongTrinhMucTieuQuocGiaDto, CreateUpdateChuongTrinhMucTieuQuocGiaDto>,
        IChuongTrinhMucTieuQuocGiaAppService
    {
        private readonly IChuongTrinhMucTieuQuocGiaRepository _chuongTrinhMucTieuQuocGiaRepository;

        public ChuongTrinhMucTieuQuocGiaAppService(
            IChuongTrinhMucTieuQuocGiaRepository chuongTrinhMucTieuQuocGiaRepository,
            IRepository<ChuongTrinhMucTieuQuocGia, Guid> repository) : base(repository)
        {
            _chuongTrinhMucTieuQuocGiaRepository = chuongTrinhMucTieuQuocGiaRepository;
        }

        [HttpGet, Route("api/ChuongTrinhMucTieuQuocGia/all")]
        public async Task<List<ChuongTrinhMucTieuQuocGiaDto>> GetAllAsync()
        {
            var items = await _chuongTrinhMucTieuQuocGiaRepository.GetAllAsync();
            var chuongTrinhMucTieuQuocGia= ObjectMapper.Map<List<ChuongTrinhMucTieuQuocGia>, List<ChuongTrinhMucTieuQuocGiaDto>>(items);
            return SetSTT(chuongTrinhMucTieuQuocGia);
        }
        [HttpGet]
        public async Task<List<ChuongTrinhMucTieuQuocGiaDto>> SearchAsync(string keyword)
        {
            keyword = Common.ConvertToUnSign(keyword);
            var items = await _chuongTrinhMucTieuQuocGiaRepository.SearchAsync(keyword);
            var chuongTrinhMucTieuQuocGia = ObjectMapper.Map<List<ChuongTrinhMucTieuQuocGia>, List<ChuongTrinhMucTieuQuocGiaDto>>(items);
            return SetSTT(chuongTrinhMucTieuQuocGia);
        }

        public async Task<List<ChuongTrinhMucTieuQuocGiaDto>> GetMaChuongTrinhQuocGia()
        {
            var items = await _chuongTrinhMucTieuQuocGiaRepository.GetMaChuongTrinhQuocGia();
            return ObjectMapper.Map<List<ChuongTrinhMucTieuQuocGia>, List<ChuongTrinhMucTieuQuocGiaDto>>(items).ToList();
        }
        
        public override Task DeleteAsync(Guid id)
        {
            var items =  _chuongTrinhMucTieuQuocGiaRepository.GetChildIdAsync(id).Result;
            foreach(Guid item in items)
            {
                this.DeleteAsync(item);
            }

            return  base.DeleteAsync(id);
        }

        public async Task<List<ChuongTrinhMucTieuQuocGiaDto>> GetMaConChuongTrinhsAsync()
        {
            var items = await _chuongTrinhMucTieuQuocGiaRepository.GetMaConChuongTrinhsAsync();
            return ObjectMapper.Map<List<ChuongTrinhMucTieuQuocGia>, List<ChuongTrinhMucTieuQuocGiaDto>>(items);
        }


        private List<ChuongTrinhMucTieuQuocGiaDto> SetSTT(List<ChuongTrinhMucTieuQuocGiaDto> list)
        {
            int i = 1;
            foreach (var item in list)
            {
                if (item.ParentId == null)
                {
                    int j = 1;
                    item.STT = i + "";
                    foreach (var item1 in list)
                    {
                        if (item1.ParentId == item.Id)
                        {
                            int k = 1;
                            item1.STT = item.STT + "." + j;
                            foreach (var item2 in list)
                            {
                                if (item2.ParentId == item1.Id)
                                {
                                    item2.STT = item1.STT + "." + k;
                                    int l = 1;
                                    foreach (var item3 in list)
                                    {
                                        if (item3.ParentId == item2.Id)
                                        {
                                            item3.STT = item2.STT + "." + l;
                                            int m = 1;
                                            foreach (var item4 in list)
                                            {
                                                if (item4.ParentId == item3.Id)
                                                {
                                                    item4.STT = item3.STT + "." + m;
                                                    int n = 1;
                                                    foreach (var item5 in list)
                                                    {
                                                        if (item5.ParentId == item4.Id)
                                                        {
                                                            item5.STT = item4.STT + "." + n;
                                                            n++;
                                                        }
                                                    }
                                                    m++;
                                                }
                                            }
                                            l++;
                                        }
                                    }
                                    k++;
                                }
                            }
                            j++;
                        }
                    }
                    i++;
                }
            }
            return list;
        }
    }
}