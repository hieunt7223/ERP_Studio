using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace xdcb.FormServices.Shared
{
    public static class EnumHelper
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

        public static List<EnumDescriptionViewModel> ToListModel(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            List<EnumDescriptionViewModel> list = new List<EnumDescriptionViewModel>();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                EnumDescriptionViewModel obj = new EnumDescriptionViewModel();
                obj.Key = value.ToString();
                obj.Value = value.GetDescription();
                list.Add(obj);
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
        public static string GetValueByKeyAndValue(this Type type, Enum key, string strValue)
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
            if (value != strValue)
            {
                value = string.Empty;
            }

            return value;
        }
    }
}
