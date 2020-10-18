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
        public int LocationX;
        public int LocationY;
        public int SizeHeight;
        public int SizeWidth;
        public List<PropertyControl> propertyControl;
    }
}
