using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using xdcb.Common.DanhMuc.ThanhPhanHoSoDtos;

namespace xdcb.Common.DanhMuc.ThanhPhanHoSos
{
    public class ThanhPhanHoSoAppService :
        CrudAppService<ThanhPhanHoSo,
            ThanhPhanHoSoDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateThanhPhanHoSoDto, CreateUpdateThanhPhanHoSoDto>,
        IThanhPhanHoSoAppService
    {
        private readonly IThanhPhanHoSoRepository _thanhPhanHoSoRepository;

        public ThanhPhanHoSoAppService(
            IThanhPhanHoSoRepository thanhPhanHoSoRepository,
            IRepository<ThanhPhanHoSo, Guid> repository) : base(repository)
        {
            _thanhPhanHoSoRepository = thanhPhanHoSoRepository;
        }
        [HttpGet]
        public async Task<PagedResultDto<ThanhPhanHoSoDto>> SearchAsync(ConditionSearch condition)
        {
            condition.keyword = Common.ConvertToUnSign(condition.keyword);
            PagedResultDto<ThanhPhanHoSo> items = await _thanhPhanHoSoRepository.SearchAsync(condition);
            var thanhPhanHoSoDtoList = new List<ThanhPhanHoSoDto>();
            foreach (var item in items.Items)
            {
                thanhPhanHoSoDtoList.Add(new ThanhPhanHoSoDto
                {
                    Id = item.Id,
                    TenThanhPhanHoSo = item.TenThanhPhanHoSo,
                    LoaiVanBan = item.LoaiVanBan != null ? item.LoaiVanBan.TenLoaiVanBan : "",
                    CreationTime = item.CreationTime,
                    LastModificationTime = item.LastModificationTime
                });
            }

            return new PagedResultDto<ThanhPhanHoSoDto>
            {
                Items = thanhPhanHoSoDtoList,
                TotalCount = items.TotalCount
            };
        }

        public override async Task<PagedResultDto<ThanhPhanHoSoDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var thanhPhanHoSoDtoList = new List<ThanhPhanHoSoDto>();
            var thanhPhanHoSoList = await _thanhPhanHoSoRepository.GetThanhPhanHoSoList(input);

            foreach (var item in thanhPhanHoSoList.Items)
            {
                thanhPhanHoSoDtoList.Add(new ThanhPhanHoSoDto
                {
                    Id = item.Id,
                    TenThanhPhanHoSo = item.TenThanhPhanHoSo,
                    LoaiVanBan = item.LoaiVanBan != null ? item.LoaiVanBan.TenLoaiVanBan : "",
                    CreationTime = item.CreationTime,
                    LastModificationTime = item.LastModificationTime
                });
            }

            return new PagedResultDto<ThanhPhanHoSoDto>
            {
                Items = thanhPhanHoSoDtoList,
                TotalCount = thanhPhanHoSoList.TotalCount
            };
        }

        public async Task<List<ThanhPhanHoSoDto>> GetThanhPhanHoSoByIds(List<Guid> ids)
        {
            var items = await _thanhPhanHoSoRepository.GetThanhPhanHoSoByIds(ids);
            var thanhPhanHoSoDtos = ObjectMapper.Map<List<ThanhPhanHoSo>, List<ThanhPhanHoSoDto>>(items);
            foreach (var item in thanhPhanHoSoDtos)
            {
                item.LoaiVanBan = items.FirstOrDefault(s => s.Id == item.Id) != null ?
                                  items.FirstOrDefault(s => s.Id == item.Id).LoaiVanBan.TenLoaiVanBan : string.Empty;
            }
            return thanhPhanHoSoDtos;
        }

        public async Task<bool> IsByThanhPhanHoSoAsync(Guid id)
        {
            var item = await _thanhPhanHoSoRepository.IsByThanhPhanHoSoAsync(id);
            if (item != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<ThanhPhanHoSoDto>> GetThanhPhanHoSosAsync()
        {
            var items = await _thanhPhanHoSoRepository.GetThanhPhanHoSosAsync();
            var thanhPhanHoSoDtos = ObjectMapper.Map<List<ThanhPhanHoSo>, List<ThanhPhanHoSoDto>>(items);
            foreach (var item in thanhPhanHoSoDtos)
            {
                item.LoaiVanBan = items.FirstOrDefault(s => s.Id == item.Id) != null ?
                                  items.FirstOrDefault(s => s.Id == item.Id).LoaiVanBan.TenLoaiVanBan : string.Empty;
            }
            return thanhPhanHoSoDtos;
        }

        [HttpGet ("api/app/thanhPhanHoSo/thanhPhanHoSoByLoaiVanBanId")]
        public async Task<List<ThanhPhanHoSoDto>> GetThanhPhanHoSoByLoaiVanBanIdAsync(Guid id)
        {
            var items = await _thanhPhanHoSoRepository.GetThanhPhanHoSoByLoaiVanBanIdAsync(id);
            return ObjectMapper.Map<List<ThanhPhanHoSo>, List<ThanhPhanHoSoDto>>(items);
        }
    }
}