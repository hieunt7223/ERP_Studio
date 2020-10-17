using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using xdcb.Common.DanhMuc.NguonVonDtos;

namespace xdcb.Common.DanhMuc.NguonVons
{
    public class NguonVonAppService :
        CrudAppService<NguonVon,
            NguonVonDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateNguonVonDto, CreateUpdateNguonVonDto>,
        INguonVonAppService
    {
        private readonly INguonVonRepository _nguonVonRepository;

        public NguonVonAppService(
            INguonVonRepository nguonVonRepository,
            IRepository<NguonVon, Guid> repository) : base(repository)
        {
            _nguonVonRepository = nguonVonRepository;
        }

        [HttpGet, Route("api/NguonVon/all")]
        public async Task<List<NguonVonDto>> GetAllAsync()
        {
            var items = await _nguonVonRepository.GetAllAsync();
            var nguonVons = ObjectMapper.Map<List<NguonVon>, List<NguonVonDto>>(items);

            return SetSTT(nguonVons);
        }

        public async Task<List<NguonVonDto>> GetListExcludeIdsAsync(List<Guid> ids)
        {
            var items = await _nguonVonRepository.GetListExcludeIdsAsync(ids);
            return ObjectMapper.Map<List<NguonVon>, List<NguonVonDto>>(items);
        }

        public override Task DeleteAsync(Guid id)
        {
            var items = _nguonVonRepository.GetChildIdAsync(id).Result;
            foreach (Guid item in items)
            {
                this.DeleteAsync(item);
            }

            return base.DeleteAsync(id);
        }

        public async Task<List<NguonVonDto>> GetListNguonVonMeAsync()
        {
            var items = await _nguonVonRepository.GetAllAsync();
            return ObjectMapper.Map<List<NguonVon>, List<NguonVonDto>>(items);
        }

        [HttpGet]
        public async Task<List<NguonVonDto>> SearchAsync(string keyword)
        {
            keyword = Common.ConvertToUnSign(keyword);
            var items = await _nguonVonRepository.SearchAsync(keyword);
            var nguonVons = ObjectMapper.Map<List<NguonVon>, List<NguonVonDto>>(items);
            return SetSTT(nguonVons);
        }

        private List<NguonVonDto> SetSTT(List<NguonVonDto> list)
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

        public async Task<List<NguonVonDto>> GetListNotPageAsync()
        {
            var items = await _nguonVonRepository.GetListAsync();
            List<NguonVonDto> data = new List<NguonVonDto>();
            if (items != null && items.Count > 0)
            {
                data = (List<NguonVonDto>)ObjectMapper.Map<List<NguonVon>, List<NguonVonDto>>(items.ToList().Where(x => x.IsDeleted == false).ToList());
                return data;
            }
            return data;
        }

        public async Task<List<NguonVonDto>> GetNguonVonsByIdsAsync(List<Guid> ids)
        {
            var items = await _nguonVonRepository.GetNguonVonsByIdsAsync(ids);
            return ObjectMapper.Map<List<NguonVon>, List<NguonVonDto>>(items);
        }
    }
}