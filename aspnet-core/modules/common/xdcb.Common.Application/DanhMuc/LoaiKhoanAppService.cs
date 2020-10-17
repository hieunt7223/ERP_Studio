using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using xdcb.Common.DanhMuc.LoaiKhoanDtos;
using xdcb.Common.Extensions;

namespace xdcb.Common.DanhMuc.LoaiKhoans
{
    public class LoaiKhoanAppService :
        CrudAppService<LoaiKhoan,
            LoaiKhoanDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateLoaiKhoanDto, CreateUpdateLoaiKhoanDto>,
        ILoaiKhoanAppService
    {
        private ILoaiKhoanRepository _loaiKhoanRepository;

        public LoaiKhoanAppService(
            ILoaiKhoanRepository loaiKhoanRepository,
            IRepository<LoaiKhoan, Guid> repository) : base(repository)
        {
            _loaiKhoanRepository = loaiKhoanRepository;
        }

        [HttpGet, Route("api/LoaiKhoan/all")]
        public async Task<List<LoaiKhoanDto>> GetAllAsync()
        {
            var items = await _loaiKhoanRepository.GetAllAsync();
            var loaiKhoans = ObjectMapper.Map<List<LoaiKhoan>, List<LoaiKhoanDto>>(items);
            foreach (var item in loaiKhoans)
            {
                item.TenLoaiLoaiKhoan = this.getNameLoaiLoaiKhoan((int)item.LoaiLoaiKhoan);
            }
            return SetSTT(loaiKhoans);
        }

        public override async Task<LoaiKhoanDto> GetAsync(Guid id)
        {
            var items = await _loaiKhoanRepository.GetAsync(id);
            var loaiKhoans = ObjectMapper.Map<LoaiKhoan, LoaiKhoanDto>(items);
            loaiKhoans.TenLoaiLoaiKhoan = getNameLoaiLoaiKhoan((int)loaiKhoans.LoaiLoaiKhoan);

            return loaiKhoans;
        }

        public override Task DeleteAsync(Guid id)
        {
            var items = _loaiKhoanRepository.GetChildIdAsync(id).Result;
            foreach (Guid item in items)
            {
                this.DeleteAsync(item);
            }

            return base.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<List<LoaiKhoanDto>> SearchAsync(ConditionSearch condition)
        {
            condition.keyword = Common.ConvertToUnSign(condition.keyword);
            var items = await _loaiKhoanRepository.SearchAsync(condition);
            var loaiKhoans = ObjectMapper.Map<List<LoaiKhoan>, List<LoaiKhoanDto>>(items);
            foreach (var item in loaiKhoans)
            {
                item.TenLoaiLoaiKhoan = this.getNameLoaiLoaiKhoan((int)item.LoaiLoaiKhoan);
            }
            return SetSTT(loaiKhoans);
        }

        public async Task<IList<LoaiKhoanDto>> GetLoaiAsync()
        {
            var items = await _loaiKhoanRepository.GetLoaiAsync();
            return ObjectMapper.Map<List<LoaiKhoan>, List<LoaiKhoanDto>>(items.ToList());
        }

        private string getNameLoaiLoaiKhoan(int input)
        {
            switch (input)
            {
                case 1:
                    return "Loại";
                default:
                    return "Khoản";

            }
        }

        private List<LoaiKhoanDto> SetSTT(List<LoaiKhoanDto> list)
        {
            int i = 1;
            foreach (var item in list)
            {
                if (item.LoaiKhoanChaID == null)
                {
                    int j = 1;
                    item.STT = i + "";
                    foreach (var item1 in list)
                    {
                        if (item1.LoaiKhoanChaID == item.Id)
                        {
                            item1.STT = item.STT + "." + j;
                            j++;
                        }
                    }
                    i++;
                }
            }
            return list;
        }

        public Dictionary<int, string> GetLoaiKhoanTypes()
        {
            return Enum.GetValues(typeof(LoaiKhoanType))
                       .Cast<LoaiKhoanType>()
                       .ToDictionary(t => (int)t, t => t.GetDescription());

        }
    }
}