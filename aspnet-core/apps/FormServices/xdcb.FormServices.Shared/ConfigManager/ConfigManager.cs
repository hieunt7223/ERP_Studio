using Refit;
using System.Collections.Specialized;
using System.Configuration;
using System.Windows.Forms;

namespace xdcb.FormServices.Shared
{
    public static class ConfigManager
    {
        public static string ServerName()
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            string url = appSettings["ServerName"];
            return url;
        }

        public static string UserName()
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            string url = appSettings["UserName"];
            return url;
        }

        public static string Password()
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            string url = appSettings["Password"];
            return url;
        }

        public static string DatabaseName()
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            string url = appSettings["DatabaseName"];
            return url;
        }

        public static string PathDesignUI()
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            string url = appSettings["PathDesignUI"];
            return url;
        }

        public static string NamespareProject()
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            string url = appSettings["NamespareProject"];
            return url;
        }

        public static string NamespareSDK()
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            string url = appSettings["NamespareSDK"];
            return url;
        }

        public static string NamespareService()
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            string url = appSettings["NamespareService"];
            return url;
        }

        public static string NamespareSchema()
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            string url = appSettings["NamespareSchema"];
            return url;
        }

        public static string PathGenerate()
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            string url = appSettings["PathGenerate"];
            return url;
        }

        public static string PathTemplate()
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            return Application.StartupPath + appSettings["PathTemplate"] + @"Excel\";
        }

        public static string PathGridViewXML()
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            return Application.StartupPath + appSettings["PathTemplate"] + @"GridViewXML\";
        }

        public static string PathTreeListXML()
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            return Application.StartupPath + appSettings["PathTemplate"] + @"TreeListXML\";
        }

        public static string RemoteAPIURL()
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            string url = appSettings["RemoteAPI"];
            return url;
        }

        public static T GetAPIByService<T>()
        {
            T obj = RestService.For<T>(RemoteAPIURL(),
              new RefitSettings
              {
                  CollectionFormat = CollectionFormat.Multi
              });
            return obj;
        }
    }
}
