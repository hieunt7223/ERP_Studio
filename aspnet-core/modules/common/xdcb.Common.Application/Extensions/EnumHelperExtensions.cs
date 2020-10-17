using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using xdcb.Common.Attributes;

namespace xdcb.Common.Extensions
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

            Array enumValues = Enum.GetValues(type);
            if (enumValues != null)
            {
                value = GetDescription(key);
            }

            return value;
        }
    }
}