using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using xdcb.Common.DanhMuc.CongTrinhs;
using xdcb.Common.DanhMuc.NghiQuyetDtos;

namespace xdcb.Common.DanhMuc.NghiQuyets
{
    public class NghiQuyetAppService :
        CrudAppService<NghiQuyet,
            NghiQuyetDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateNghiQuyetDto, CreateUpdateNghiQuyetDto>,
        INghiQuyetAppService
    {
        private INghiQuyetRepository _nghiQuyetRepository;

        public NghiQuyetAppService(
            INghiQuyetRepository nghiQuyetRepository,
            IRepository<NghiQuyet, Guid> repository) : base(repository)
        {
            _nghiQuyetRepository = nghiQuyetRepository;
        }

        public async override Task<NghiQuyetDto> GetAsync(Guid id)
        {
            var item = _nghiQuyetRepository.GetAsync(id).Result;

            return ObjectMapper.Map<NghiQuyet, NghiQuyetDto>(item);
        }

        [HttpPost,Route("api/NghiQuyet/NghiQuyetCongTrinh")]
        public async Task<NghiQuyetDto> SaveNghiQuyetCongTrinh(CreateUpdateNghiQuyetCongTrinhDto input)
        {
            NghiQuyet item = new NghiQuyet();
            List<NghiQuyetCongTrinh> listNghiQuyetCongTrinh = new List<NghiQuyetCongTrinh>();
            input.NghiQuyetCongTrinhs.ForEach(o =>
            {
                NghiQuyetCongTrinh obj = new NghiQuyetCongTrinh();
                obj.CongTrinhId = o.CongTrinhId;
                obj.NghiQuyetId = o.NghiQuyetId;
                listNghiQuyetCongTrinh.Add(obj);
            });
            item.NghiQuyetCongTrinhs = listNghiQuyetCongTrinh;
            var data = await _nghiQuyetRepository.SaveNghiQuyetCongTrinh(item);
            return ObjectMapper.Map<NghiQuyet, NghiQuyetDto>(data);
        }
        [HttpDelete, Route("api/NghiQuyet/NghiQuyetCongTrinh")]
        public async Task DeleleNghiQuyetCongTrinhByNghiQuyetId(Guid id)
        {
            await _nghiQuyetRepository.DeleleNghiQuyetCongTrinhByNghiQuyetId(id);
            return;
        }


        [HttpGet]
        public async Task<PagedResultDto<NghiQuyetDto>> SearchAsync(ConditionSearch condition)
        {
            condition.keyword = Common.ConvertToUnSign(condition.keyword).ToLower();
            PagedResultDto<NghiQuyet> items = await _nghiQuyetRepository.SearchAsync(condition);
            return new PagedResultDto<NghiQuyetDto>(items.TotalCount, ObjectMapper.Map<List<NghiQuyet>, List<NghiQuyetDto>>(items.Items.ToList()));
        }
    }
}