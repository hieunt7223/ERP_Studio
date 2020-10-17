using System.Collections.Generic;

namespace xdcb.FormServices.Shared
{
    public class FieldControl
    {
        public string id;
        public string name;
        public string key;
        public string description;
        public string version;
        public string lastUpdatedBy;
        public string lastUpdated;
        public List<PropertyControl> propertyControl;
    }
}
