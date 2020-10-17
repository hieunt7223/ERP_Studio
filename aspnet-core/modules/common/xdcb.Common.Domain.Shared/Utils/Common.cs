using System;
using System.Text;
using System.Text.RegularExpressions;

namespace xdcb.Common
{
    public static class Common
    {
        public static string ConvertToUnSign(string input)
        {
            if (input != null)
            {
                input = input.Trim().ToLower();
                for (int i = 0x20; i < 0x30; i++)
                {
                    input = input.Replace(((char)i).ToString(), " ");
                }
                Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
                string str = input.Normalize(NormalizationForm.FormD);
                string str2 = regex.Replace(str, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
                while (str2.IndexOf("?") >= 0)
                {
                    str2 = str2.Remove(str2.IndexOf("?"), 1);
                }
                return str2;
            }
            else
            {
                return "";
            }
          
        }
    }
}