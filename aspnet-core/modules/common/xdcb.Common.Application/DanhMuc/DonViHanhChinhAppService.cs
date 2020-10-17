using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using xdcb.Common.DanhMuc.DonViHanhChinhDtos;
using xdcb.Common.Extensions;

namespace xdcb.Common.DanhMuc.DonViHanhChinhs
{
    public class DonViHanhChinhAppService :
        CrudAppService<DonViHanhChinh, DonViHanhChinhDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateDonViHanhChinhDto, CreateUpdateDonViHanhChinhDto>,
        IDonViHanhChinhAppService
    {
        private readonly IDonViHanhChinhRepository _donViHanhChinhRepository;

        public DonViHanhChinhAppService(IRepository<DonViHanhChinh, Guid> repository, IDonViHanhChinhRepository donViHanhChinhRepository)
            : base(repository)
        {
            _donViHanhChinhRepository = donViHanhChinhRepository;
        }

        [HttpGet,Route("api/DonViHanhChinh/all")]
        public async Task<List<DonViHanhChinhDto>> GetAllAsync()
        {
            var items = await _donViHanhChinhRepository.GetAllAsync();
            var donViHanhChinhs= ObjectMapper.Map<List<DonViHanhChinh>, List<DonViHanhChinhDto>>(items);
            foreach (var item in donViHanhChinhs)
            {
                item.TenCapDonVi = this.getNameCapDonVi((int)item.CapDonViHanhChinh);
            }
            return SetSTT(donViHanhChinhs);
        }

        public override Task DeleteAsync(Guid id)
        {
            var items = _donViHanhChinhRepository.GetChildIdAsync(id).Result;
            foreach (Guid item in items)
            {
                this.DeleteAsync(item);
            }

            return base.DeleteAsync(id);
        }

        private string getNameCapDonVi(int input)
        {
            switch (input)
            {
                case 0:
                    return "Tỉnh";
                case 1:
                    return "Thành phố trực thuộc trung ương";
                case 2:
                    return "Thành phố";
                case 3:
                    return "Quận";
                case 4:
                    return "Huyện";
                case 5:
                    return "Thị xã";
                case 6:
                    return "Thị trấn";
                case 7:
                    return "Phường";
                default:
                    return "Xã";
    
            }
        }

        public async Task<List<DonViHanhChinhDto>> GetSelectAsync()
        {
            var items = await _donViHanhChinhRepository.GetAllAsync();

            var donViHanhChinhs= ObjectMapper.Map<List<DonViHanhChinh>, List<DonViHanhChinhDto>>(items);

            List<DonViHanhChinhDto> listSelect = new List<DonViHanhChinhDto>();
            foreach(var item in donViHanhChinhs)
            {
                if (item.ParentId == null)
                {
                    listSelect.Add(item);
                }
                foreach(var item1 in donViHanhChinhs)
                {
                    if (item1.ParentId == item.Id)
                    {
                        item1.TenDonViHanhChinh = "---" + item1.TenDonViHanhChinh;
                        listSelect.Add(item1);
                    }
                }
            }

            return listSelect;
        }
        [HttpGet]
        public async Task<List<DonViHanhChinhDto>> SearchAsync(string keyword)
        {
            keyword = Common.ConvertToUnSign(keyword);
            var items = await _donViHanhChinhRepository.SearchAsync(keyword);
            var donViHanhChinhs= ObjectMapper.Map<List<DonViHanhChinh>, List<DonViHanhChinhDto>>(items);
            foreach (var item in donViHanhChinhs)
            {
                item.TenCapDonVi = this.getNameCapDonVi((int)item.CapDonViHanhChinh);
            }
            return SetSTT(donViHanhChinhs);
        }

        private List<DonViHanhChinhDto> SetSTT(List<DonViHanhChinhDto> list)
        {
            int i = 1;
            foreach(var item in list)
            {
                if (item.ParentId == null)
                {
                    int j = 1;
                    item.STT = i + "";
                    foreach(var item1 in list)
                    {
                        
                        if (item1.ParentId == item.Id)
                        {
                            int k = 1;
                            item1.STT = item.STT +"."+ j;
                            foreach(var item2 in list)
                            {
                                if (item2.ParentId == item1.Id)
                                {
                                    item2.STT = item1.STT + "." + k;
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

        public async Task<List<DonViHanhChinhDto>> GetListByIdsAsync(List<Guid> ids)
        {
            var items = await _donViHanhChinhRepository.GetListByIdsAsync(ids);
            return ObjectMapper.Map<List<DonViHanhChinh>, List<DonViHanhChinhDto>>(items);
        }

        public async Task<List<DonViHanhChinhDto>> GetParentsAsync()
        {
            var items = await _donViHanhChinhRepository.GetParentsAsync();
            return ObjectMapper.Map<List<DonViHanhChinh>, List<DonViHanhChinhDto>>(items);
        }

        public async Task<List<DonViHanhChinhDto>> GetChildsAsync()
        {
            var items = await _donViHanhChinhRepository.GetChildsAsync();
            return ObjectMapper.Map<List<DonViHanhChinh>, List<DonViHanhChinhDto>>(items);
        }

        public Dictionary<int, string> GetCapDonVis()
        {
            return Enum.GetValues(typeof(CapDonVi))
                       .Cast<CapDonVi>()
                       .ToDictionary(t => (int)t, t => t.GetDescription());
        }

        public async Task<List<DonViHanhChinhDto>> GetDonViCapThanhPhoHuyenThiXa()
        {
            var items = await _donViHanhChinhRepository.GetDonViCapThanhPhoHuyenThiXa();
            return ObjectMapper.Map<List<DonViHanhChinh>, List<DonViHanhChinhDto>>(items);
        }

        [HttpGet, Route("api/app/donViHanhChinh/donViCapPhuongXaThiTran/excludeIds")]
        public async Task<List<DonViHanhChinhDto>> GetDonViCapPhuongXaThiTranExcludeIdsAsync(List<Guid> ids)
        {
            var items = await _donViHanhChinhRepository.GetDonViCapPhuongXaThiTranExcludeIdsAsync(ids);
            return ObjectMapper.Map<List<DonViHanhChinh>, List<DonViHanhChinhDto>>(items);
        }

        [HttpGet]
        public bool IsMaExist(string ma, Guid id)
        {
            return _donViHanhChinhRepository.IsMaExist(ma, id);
        }
        [HttpGet]
        public bool IsNameExist(string name, Guid id, Guid? parentId)
        {
            return _donViHanhChinhRepository.IsNameExist(name, id, parentId);
        }
    }
}