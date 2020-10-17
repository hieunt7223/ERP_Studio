using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using xdcb.Common.DanhMuc.ChuDauTuDtos;

namespace xdcb.Common.DanhMuc.ChuDauTus
{
    public class ChuDauTuAppService :
        CrudAppService<ChuDauTu,
            ChuDauTuDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateChuDauTuDto, CreateUpdateChuDauTuDto>,
        IChuDauTuAppService
    {
        private readonly IChuDauTuRepository _chuDauTuRepository;

        public ChuDauTuAppService(
            IChuDauTuRepository chuDauTuRepository) : base(chuDauTuRepository)
        {
            _chuDauTuRepository = chuDauTuRepository;
        }

        [HttpGet]
        public async Task<PagedResultDto<ChuDauTuDto>> SearchAsync(ConditionSearch condition)
        {
            condition.keyword = Common.ConvertToUnSign(condition.keyword).ToLower();
            PagedResultDto<ChuDauTu> items = await _chuDauTuRepository.SearchAsync(condition);
            return new PagedResultDto<ChuDauTuDto>(items.TotalCount, ObjectMapper.Map<List<ChuDauTu>, List<ChuDauTuDto>>(items.Items.ToList()));
        }

        public async Task<IList<ChuDauTuDto>> GetChuDauTuListAsync()
        {
            IList<ChuDauTu> items = await _chuDauTuRepository.GetListAsync();
            return ObjectMapper.Map<IList<ChuDauTu>, IList<ChuDauTuDto>>(items);
        }

        public async Task<Guid?> CheckChuDauTuAsync(Guid id)
        {
            IList<ChuDauTu> items = await _chuDauTuRepository.GetListAsync();
            var chuDauTuList = ObjectMapper.Map<IList<ChuDauTu>, IList<ChuDauTuDto>>(items);
            foreach (var item in chuDauTuList)
            {
                if (item.NguoiDung != null)
                {
                    List<NguoiDungDto> nguoiDungDtos = JsonConvert.DeserializeObject<List<NguoiDungDto>>(item.NguoiDung);
                    if (nguoiDungDtos != null)
                    {
                        foreach (var item1 in nguoiDungDtos)
                        {
                            if (item1.Id == id)
                            {
                                return item.Id;
                            }
                        }
                    }
                }
            }
            return null;
        }

        public async Task<List<ChuDauTuDto>> GetListByIdsAsync(List<Guid> ids)
        {
            var items = await _chuDauTuRepository.GetListByIdsAsync(ids);
            return ObjectMapper.Map<List<ChuDauTu>, List<ChuDauTuDto>>(items);
        }
    }
}