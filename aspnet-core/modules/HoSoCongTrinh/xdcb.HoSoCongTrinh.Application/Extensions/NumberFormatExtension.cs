using System.Globalization;

namespace xdcb.HoSoCongTrinh.Extensions
{
    public static class NumberFormatExtension
    {
        /// <summary>
        /// extension format decimal sang việt nam đồng
        /// 123 -> 123
        /// 123456 -> 123.456
        /// 123456.78 -> 123.456,78
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FormatCurrency(this decimal value)
        {
            return value.ToString("#,###.##", new CultureInfo("vi-VN"));
        }

        public static string FormatCurrency(this decimal? value)
        {
            if (value == null) return string.Empty;
            return value.Value.ToString("#,###.##", new CultureInfo("vi-VN"));
        }
    }
}