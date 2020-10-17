using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.ChuongTrinhMucTieuQuocGias
{
    public class ChuongTrinhMucTieuQuocGiaRepository : EfCoreRepository<CommonDbContext, ChuongTrinhMucTieuQuocGia, Guid>, IChuongTrinhMucTieuQuocGiaRepository
    {
        public ChuongTrinhMucTieuQuocGiaRepository(IDbContextProvider<CommonDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }

        public async Task<List<ChuongTrinhMucTieuQuocGia>> GetAllAsync()
        {
            return await GetQueryable().Where(w=> !w.IsDeleted).OrderBy(x => x.MaChuongTrinhMucTieuQuocGia).ToListAsync();
        }

        public async Task<List<ChuongTrinhMucTieuQuocGia>> SearchAsync(string keyword)
        {
            List<ChuongTrinhMucTieuQuocGia> chuongTrinhMucTieuQuocGiaList = new List<ChuongTrinhMucTieuQuocGia>();
            var chuongTrinhMucTieuQuocGias= GetQueryable().AsEnumerable().Where(w =>
            (Common.ConvertToUnSign(w.MaChuongTrinhMucTieuQuocGia).Contains(keyword)
            || Common.ConvertToUnSign(w.TenChuongTrinhMucTieuQuocGia).Contains(keyword)) && !w.IsDeleted
            ).OrderBy(x => x.MaChuongTrinhMucTieuQuocGia).ToList();

            foreach(var item in chuongTrinhMucTieuQuocGias)
            {
                chuongTrinhMucTieuQuocGiaList.Add(item);
            }

            foreach(var item in chuongTrinhMucTieuQuocGias)
            {
                if(item.ParentId != null)
                {
                    var chuongTrinhMucTieuQuocGia= GetQueryable().AsEnumerable().FirstOrDefault(x=> x.Id==item.ParentId && !x.IsDeleted);
                    if (chuongTrinhMucTieuQuocGia != null)
                    {
                        var itemExist = chuongTrinhMucTieuQuocGiaList.FirstOrDefault(x => x.Id == chuongTrinhMucTieuQuocGia.Id);
                        if (itemExist == null)
                        {
                            chuongTrinhMucTieuQuocGiaList.Add(chuongTrinhMucTieuQuocGia);
                        }
                    }
                    
                }
            }
            return chuongTrinhMucTieuQuocGiaList;
        }

        /// <summary>
        /// Get danh sách id con của chương trình mục tiêu quốc gia bị xóa
        /// </summary>
        /// <param name="id">id của chương trình mục tiêu quốc gia</param>
        /// <returns></returns>
        public async Task<List<Guid>> GetChildIdAsync(Guid id)
        {
            return await GetQueryable().Where(w => w.ParentId == id && !w.IsDeleted).Select(w=>w.Id).ToListAsync();
        }
        /// <summary>
        /// get list mã chương trình mục tiêu cha
        /// </summary>
        /// <returns></returns>
        public async Task<List<ChuongTrinhMucTieuQuocGia>> GetMaChuongTrinhQuocGia()
        {
            return await GetQueryable().Where(w => w.ParentId==null && !w.IsDeleted).OrderBy(x => x.MaChuongTrinhMucTieuQuocGia).ToListAsync();
        }

        public Task<List<ChuongTrinhMucTieuQuocGia>> GetMaConChuongTrinhsAsync()
        {
            return GetQueryable().Where(s => !s.IsDeleted).ToListAsync();
        }
    }
}