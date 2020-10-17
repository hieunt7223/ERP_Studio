using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace xdcb.QuanLyVon.GiaiNgans
{
	/// <summary>
	/// Generated Domain Repositories for Table : GiaiNgan.
	/// </summary>
	public interface IGiaiNganRepository : IBasicRepository<GiaiNgan, Guid>
	{
		Task<string> GetNotificationIsNew(int nam, bool isKeHoachKeoDai, string tenKeHoach, int quyThang, Guid chuDauTuId);
	}
}
