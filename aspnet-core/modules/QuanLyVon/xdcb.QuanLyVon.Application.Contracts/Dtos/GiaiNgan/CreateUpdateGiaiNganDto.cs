using System;
using System.ComponentModel.DataAnnotations;

namespace xdcb.QuanLyVon.GiaiNgan.Dtos
{
	/// <summary>
	/// Generated CreateUpdateDto for Table : GiaiNgan.
	/// </summary>
	public class CreateUpdateGiaiNganDto
	{
		#region Generated By Column
		public int Nam { get; set; }

		public int QuyThang { get; set; }

		public Guid ChuDauTuId { get; set; }

		public bool IsKeHoachKeoDai { get; set; }

		public string TenKeHoach { get; set; }

		public string TrangThai { get; set; }

		public decimal TongGiaiNgan { get; set; }

		public DateTime? NgayGui { get; set; }

		#endregion
	}
}