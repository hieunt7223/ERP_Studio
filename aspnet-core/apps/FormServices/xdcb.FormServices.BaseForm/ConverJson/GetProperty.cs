using System;
using System.Reflection;

namespace xdcb.FormServices.BaseForm
{
    public static class GetProperty
    {
        #region GetPropertyStringValue
        public static String GetPropertyStringValue(object obj, String strPropertyName)
        {
            object objValue = GetPropertyValue(obj, strPropertyName);
            if (objValue != null)
                return objValue.ToString();
            return String.Empty;
        }

        public static object GetPropertyValue(object obj, String strPropertyName)
        {
            Type objType = obj.GetType();
            PropertyInfo property = objType.GetProperty(strPropertyName);
            if (property != null)
                return property.GetValue(obj, null);
            return null;
        }
        #endregion
    }
}
