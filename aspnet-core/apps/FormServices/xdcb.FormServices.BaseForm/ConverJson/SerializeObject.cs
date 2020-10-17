using Newtonsoft.Json;
using xdcb.FormServices.Shared;

namespace xdcb.FormServices.BaseForm
{
    public static class SerializeObject
    {
        public static string SerializeObjectByFieldControl(FieldControl field)
        {
            string json = JsonConvert.SerializeObject(field, Newtonsoft.Json.Formatting.Indented);
            return json;
        }
    }
}
