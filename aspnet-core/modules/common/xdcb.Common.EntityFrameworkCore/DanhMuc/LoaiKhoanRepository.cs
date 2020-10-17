using EnumsNET;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace xdcb.Common.DanhMuc.LoaiKhoans
{
    public class LoaiKhoanRepository : EfCoreRepository<CommonDbContext, LoaiKhoan, Guid>, ILoaiKhoanRepository
    {
        public LoaiKhoanRepository(IDbContextProvider<CommonDbContext> dbContextProvider, CommonDbContext context)
           : base(dbContextProvider)
        {
        }

        public async Task<List<LoaiKhoan>> SearchAsync(ConditionSearch condition)
        {
            List<LoaiKhoan> loaiKhoanList = new List<LoaiKhoan>();
            string checkLoaiLoaiKhoan = "";
            for (int i = 0; i < 2; i++)
            {
                string loaiLoaiKhoan = ((LoaiKhoanType)i).AsString(EnumFormat.Description);
                if (Common.ConvertToUnSign(loaiLoaiKhoan).Contains(condition.keyword))
                {
                    checkLoaiLoaiKhoan += i;
                    break;
                }
            }

            var loaiKhoans= GetQueryable().AsEnumerable().Where(w =>
            (Common.ConvertToUnSign(w.TenLoaiKhoan).Contains(condition.keyword)
            || Common.ConvertToUnSign(w.GhiChu).Contains(condition.keyword) 
            || string.Compare(w.LoaiLoaiKhoan.ToString(), checkLoaiLoaiKhoan) == 0) && !w.IsDeleted
            ).OrderBy(x => x.MaSo).OrderBy(x => x.LoaiLoaiKhoan).OrderByDescending(x => x.CreationTime).ToList();

            foreach(var item in loaiKhoans)
            {
                loaiKhoanList.Add(item);
            }

            foreach(var item in loaiKhoans)
            {
                if (item.LoaiKhoanChaID != null)
                {
                    var loaiKhoan = GetQueryable().AsEnumerable().FirstOrDefault(x => x.Id == item.LoaiKhoanChaID && !x.IsDeleted);
                    var itemExist = loaiKhoanList.FirstOrDefault(x => x.Id == loaiKhoan.Id);
                    if (itemExist == null)
                    {
                        loaiKhoanList.Add(loaiKhoan);
                    }
                }
            }

            return loaiKhoanList;
        }

        public async Task<List<LoaiKhoan>> GetAllAsync()
        {
            return await GetQueryable().Where(w=> !w.IsDeleted).OrderBy(w => w.MaSo).OrderBy(x => x.LoaiLoaiKhoan).OrderByDescending(x => x.CreationTime).ToListAsync();
        }

        /// <summary>
        /// get list loại
        /// </summary>
        /// <returns></returns>
        public async Task<IList<LoaiKhoan>> GetLoaiAsync()
        {
            return await GetQueryable().Where(w => w.LoaiLoaiKhoan == 1 && !w.IsDeleted).ToListAsync();
        }

        /// <summary>
        /// get các id con của nguồn vốn bị xóa
        /// </summary>
        /// <param name="id">id nguồn vốn</param>
        /// <returns></returns>
        public async Task<List<Guid>> GetChildIdAsync(Guid id)
        {
            return await GetQueryable().Where(w => w.LoaiKhoanChaID == id && !w.IsDeleted).Select(w => w.Id).ToListAsync();
        }
    }
}