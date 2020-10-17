using System;

namespace xdcb.Common.Extensions
{
    public static class HoSoDateTimeExtensions
    {
        /// <summary>
        /// Format DateTime sang định dạng cần format
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="format">định dạng format</param>
        /// <returns>chuỗi datetime đc format or empty</returns>
        public static string ToDateTimeDefault(this DateTime? dt, string format)
                                         => dt == null ? string.Empty : ((DateTime)dt).ToString(format);

        /// <summary>
        /// Format DateTime sang định dạng cần format
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="format">định dạng format</param>
        /// <returns>chuỗi datetime đc format or empty</returns>
        public static string ToDateTimeDefault(this DateTime dt, string format) => dt.ToString(format);

        /// <summary>
        /// Convert DateTime thành DateTime local theo múi giờ
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="timezone">Múi giờ muốn lấy giờ theo số phút offset từ +0. VD: +420 là +7h của VN</param>
        /// <returns>DateTime local</returns>
        public static DateTime ToLocalDate(this DateTime datetime, int timezone = 420)
        {
            return datetime.AddMinutes(timezone);
        }

        /// <summary>
        /// Convert DateTime nullable thành DateTime nullable local theo múi giờ
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="timezone">Múi giờ muốn lấy giờ theo số phút offset từ +0. VD: +420 là +7h của VN</param>
        /// <returns>DateTime local hoặc null</returns>
        public static DateTime? ToLocalDate(this DateTime? datetime, int timezone)
        {
            return datetime?.AddMinutes(timezone);
        }

        /// <summary>
        /// Tính ngày hạn xử lý hồ sơ
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime AddWorkdays(this DateTime originalDate, int workDays)
        {
            DateTime tmpDate = originalDate;
            while (workDays > 0)
            {
                tmpDate = tmpDate.AddDays(1);
                if (tmpDate.DayOfWeek < DayOfWeek.Saturday &&
                    tmpDate.DayOfWeek > DayOfWeek.Sunday)
                    workDays--;
            }
            return tmpDate;
        }
    }
}