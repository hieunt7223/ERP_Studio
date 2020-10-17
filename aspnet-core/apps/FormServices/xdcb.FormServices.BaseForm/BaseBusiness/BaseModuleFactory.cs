using System;
using System.Reflection;
using System.Windows.Forms;

namespace xdcb.FormServices.BaseForm
{
    public class BaseModuleFactory
    {
        public static BaseModule GetModule(String moduleName,string projectName)
        {
            try
            {
                projectName = "xdcb.FormStudio";
                Type moduleType = Assembly.LoadFrom(Application.StartupPath + "\\"+ projectName + ".dll").GetType(projectName+"." + moduleName + "." + moduleName + "Module");
                if(moduleType==null)
                {
                    projectName = "xdcb.FormQLV";
                    moduleType = Assembly.LoadFrom(Application.StartupPath + "\\" + projectName + ".dll").GetType(projectName + "." + moduleName + "." + moduleName + "Module");
                }
                return (BaseModule)moduleType.InvokeMember("", BindingFlags.CreateInstance, null, null, null);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
