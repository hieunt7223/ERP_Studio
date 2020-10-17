using EnumsNET;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.DonViHanhChinhs
{
    public class DonViHanhChinhRepository : EfCoreRepository<CommonDbContext, DonViHanhChinh, Guid>, IDonViHanhChinhRepository
    {
        public DonViHanhChinhRepository(IDbContextProvider<CommonDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }

        public async Task<List<DonViHanhChinh>> GetAllAsync()
        {
            return await GetQueryable().Where(w => !w.IsDeleted).OrderBy(x => x.CapDonViHanhChinh).OrderBy(x => x.MaDonViHanhChinh).ToListAsync();
        }

        public async Task<List<DonViHanhChinh>> SearchAsync(string keyword)
        {
            List<DonViHanhChinh> donViHanhChinhList = new List<DonViHanhChinh>();
            string checkCap = "";
            for (int i = 0; i < 9; i++)
            {
                string donViHanhChinh = ((CapDonVi)i).AsString(EnumFormat.Description);
                if (Common.ConvertToUnSign(donViHanhChinh).Contains(keyword))
                {
                    checkCap += i;
                }
            }
            var donViHanhChinhs = GetQueryable().AsEnumerable().Where(w =>
              (Common.ConvertToUnSign(w.MaDonViHanhChinh).Contains(keyword)
              || Common.ConvertToUnSign(w.TenDonViHanhChinh).Contains(keyword) ||
              string.Compare(w.CapDonViHanhChinh.ToString(), checkCap) == 0) && !w.IsDeleted
            ).OrderBy(x => x.CapDonViHanhChinh).OrderBy(x => x.MaDonViHanhChinh).ToList();
            foreach (var item in donViHanhChinhs)
            {
                donViHanhChinhList.Add(item);
            }
            foreach (var item in donViHanhChinhs)
            {
                if (item.ParentId != null)
                {
                    var donViHanhChinh = GetQueryable().AsEnumerable().Where(x => x.Id == item.ParentId && !x.IsDeleted).FirstOrDefault();
                    var itemExits =donViHanhChinhList.FirstOrDefault(x => x.Id == donViHanhChinh.Id);
                    if (itemExits == null)
                    {
                        donViHanhChinhList.Add(donViHanhChinh);
                    }
                    
                    if(donViHanhChinh.ParentId != null)
                    {
                        donViHanhChinh= GetQueryable().AsEnumerable().Where(x => x.Id == donViHanhChinh.ParentId && !x.IsDeleted).FirstOrDefault();
                        itemExits = donViHanhChinhList.FirstOrDefault(x => x.Id == donViHanhChinh.Id);
                        if (itemExits == null)
                        {
                            donViHanhChinhList.Add(donViHanhChinh);
                        }
                    }
                }
            }
            return donViHanhChinhList;
        }

        /// <summary>
        /// get các id con của nguồn vốn bị xóa
        /// </summary>
        /// <param name="id">id nguồn vốn</param>
        /// <returns></returns>
        public async Task<List<Guid>> GetChildIdAsync(Guid id)
        {
            return await GetQueryable().Where(w => w.ParentId == id && !w.IsDeleted).Select(w => w.Id).ToListAsync();
        }

        public async Task<List<DonViHanhChinh>> GetListByIdsAsync(List<Guid> ids)
        {
            return await GetQueryable().Where(w => !w.IsDeleted && ids.Contains(w.Id)).ToListAsync();
        }

        public async Task<List<DonViHanhChinh>> GetParentsAsync()
        {
            return await GetQueryable().Where(s => !s.IsDeleted && s.ParentId == null).AsNoTracking().ToListAsync();
        }

        public async Task<List<DonViHanhChinh>> GetChildsAsync()
        {
            return await GetQueryable().Where(s => !s.IsDeleted && s.ParentId != null).AsNoTracking().ToListAsync();
        }

        public async Task<List<DonViHanhChinh>> GetDonViCapThanhPhoHuyenThiXa()
        {
            var capThanhPhoHuyenThiXa = new List<int>()
            {
                (int)CapDonVi.ThanhPho,
                (int)CapDonVi.Huyen,
                (int)CapDonVi.ThiXa
            };
            return await GetQueryable().Where(s => !s.IsDeleted && capThanhPhoHuyenThiXa.Contains(s.CapDonViHanhChinh)).AsNoTracking().ToListAsync();
        }

        public async Task<List<DonViHanhChinh>> GetDonViCapPhuongXaThiTranExcludeIdsAsync(List<Guid> ids)
        {
            var capPhuongXaThiTran = new List<int>()
            {
                (int)CapDonVi.Phuong,
                (int)CapDonVi.Xa,
                (int)CapDonVi.ThiTran
            };
            return await GetQueryable().Where(s => !s.IsDeleted && capPhuongXaThiTran.Contains(s.CapDonViHanhChinh) && !ids.Contains(s.Id)).AsNoTracking().ToListAsync();
        }

        public bool IsMaExist(string ma, Guid id)
        {
            
           var item = GetQueryable().Where(x => x.Id != id && string.Compare(x.MaDonViHanhChinh.ToLower(), ma.ToLower()) == 0 && !x.IsDeleted).FirstOrDefault();
           if (item != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsNameExist(string name, Guid id, Guid? parentId)
        {
            if (id == null)
            {
                id = new Guid();
            }
            if(parentId==new Guid("00000000-0000-0000-0000-000000000000"))
            {
                parentId = null;
            }
            var item = GetQueryable().Where(x => x.Id != id && x.ParentId == parentId && string.Compare(x.TenDonViHanhChinh.ToLower(), name.ToLower()) == 0 && !x.IsDeleted).FirstOrDefault();
            if (item != null)
            {
                return true;
            }
            else
           {
               return false;
           }
        }
    }
}