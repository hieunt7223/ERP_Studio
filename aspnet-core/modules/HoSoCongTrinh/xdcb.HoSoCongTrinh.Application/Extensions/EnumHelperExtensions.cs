using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using xdcb.HoSoCongTrinh.Attributes;

namespace xdcb.HoSoCongTrinh.Extensions
{
    public static class EnumHelperExtensions
    {
        public static string GetDescription(this Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            string description = value.ToString();
            FieldInfo fieldInfo = value.GetType().GetField(description);
            EnumDescriptionAttribute[] attributes =
               (EnumDescriptionAttribute[])
             fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                description = attributes[0].Description;
            }
            return description;
        }

        public static Dictionary<int, string> GetEnumDictionary<T>() where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T is not an Enum type");

            return Enum.GetValues(typeof(T))
                .Cast<object>()
                .ToDictionary(k => (int)k, v => ((Enum)v).GetDescription());
        }

        public static IList ToList(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                list.Add(new KeyValuePair<Enum, string>(value, GetDescription(value)));
            }

            return list;
        }

        public static string GetValueByKey(this Type type, Enum key)
        {
            string value = string.Empty;
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(type);
            if (enumValues != null)
            {
                value = GetDescription(key);
            }

            return value;
        }
    }
}