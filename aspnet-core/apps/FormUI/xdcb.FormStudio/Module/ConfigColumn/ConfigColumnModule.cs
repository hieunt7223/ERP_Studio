using xdcb.FormServices.BaseForm;
using xdcb.FormServices.ConfigColumns.Dtos;
using xdcb.FormServices.SDK;
using xdcb.FormServices.Shared;
using xdcb.FormStudio.Form.ConfigColumn;

namespace xdcb.FormStudio.ConfigColumn
{
    public class ConfigColumnModule : BaseModule
    {
        public ConfigColumnModule()
        {
            Name = ModuleName.ConfigColumn.ToString();
            frmConfigColumn frm = new frmConfigColumn();
            UIPanel = frm.pnview;
            DataSourceSearch = "ConfigColumns";
            InitializeModule();
        }

        public override void InitMainObject()
        {
            MainObject = new ConfigColumnDto();
        }

        /// <summary>
        /// Set lại dữ liệu khi tạo mới
        /// </summary>
        public override void SetDefaultMainOject()
        {
            MainObject = new ConfigColumnDto();
            ConfigColumnDto obj = (ConfigColumnDto)MainObject;
            obj.Status = Status.Alive.ToString();
            obj.ConfigColumnAllowEdit = false;
            obj.ConfigColumnIsVisible = true;
            obj.ConfigColumnVisibleIndex = 1;
            obj.ConfigColumnDisplayFormat = "''";
            obj.ConfigColumnDataType = "nvarchar";
            obj.ConfigColumnFunctionCode = ConfigColumnFunctionCode.Module.ToString();
            UpdateMainObjectBindingSource();
        }

        public override int ActionSave()
        {
            var api = ConfigManager.GetAPIByService<IConfigColumnsApi>();
            ConfigColumnDto obj = (ConfigColumnDto)MainObject;
            if (obj.Id > 0)
            {
                api.Update(obj.Id, obj);
            }
            else
            {
                var data = api.Create(obj);
                obj.Id = data.Id;
            }

            return obj.Id;
        }

        public override void ActionDelete()
        {
            //var api = ConfigManager.GetAPIByService<IConfigColumnsApi>();
            //ConfigColumnDto obj = (ConfigColumnDto)MainObject;
            //if (obj.Id > 0)
            //{
            //    api.Delete(obj.Id);
            //}
            //else
            //{
            //    GGFunctions.ShowMessage("Dữ liệu chưa được lưu nên không thể xóa");
            //    return;
            //}
        }

        public override object[] GetDataSearch()
        {
            var api = ConfigManager.GetAPIByService<IConfigColumnsApi>();
            var obj = api.GetAll().GetAwaiter().GetResult().ToArray();
            return obj;
        }

        public override void Invalidate()
        {
            var api = ConfigManager.GetAPIByService<IConfigColumnsApi>();
            MainObject = api.GetObjectByID((int)CurrentObjectID).GetAwaiter().GetResult();
            UpdateMainObjectBindingSource();
        }
    }
}
