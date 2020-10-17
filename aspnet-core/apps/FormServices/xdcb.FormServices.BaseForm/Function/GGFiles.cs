using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using xdcb.FormServices.Shared;

namespace xdcb.FormServices.BaseForm
{
    public static class GGFiles
    {

        #region Post file
        public static string UploadFile(string path, string SafeFileName)
        {
            string content = string.Empty;
            FileInfo fInfo = new FileInfo(Path.Combine(path));
            if (fInfo.Length > 0)
            {
                FileColumnViewModel model = new FileColumnViewModel();
                string typeFile = Path.GetExtension(path);
                string nameFile = SafeFileName.Replace(typeFile, "").ToString();
                nameFile = GGFunctions.ConvertUnicode(nameFile).Replace(";", "").Replace(" ", "-").ToString().ToLower();

                model.Length = fInfo.Length;
                model.Name = nameFile;
                model.FileName = string.Format("{0}{1}", nameFile, typeFile);
                model.TypeFile = typeFile.ToLower().Trim();
                model.ContentType = GGFiles.GetContentType(model.TypeFile);
                model.path = path;
                content = Upload(model);
            }
            return content;
        }
        public static string Upload(FileColumnViewModel model)
        {
            string stringContent = string.Empty;
            string url = ConfigManager.RemoteAPIURL() + pathUploadFile.pathPost.ToString();
            using (var httpClient = new HttpClient())
            {
                using (var form = new MultipartFormDataContent())
                {
                    using (var fs = File.OpenRead(model.path))
                    {
                        using (var streamContent = new StreamContent(fs))
                        {
                            using (var fileContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result))
                            {
                                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(GGFiles.GetContentType(model.TypeFile));

                                form.Add(fileContent, "file", model.FileName);
                                HttpResponseMessage response = httpClient.PostAsync(url, form).Result;
                                if (response.IsSuccessStatusCode)
                                {
                                    stringContent = response.Content.ReadAsStringAsync().Result;
                                }
                            }
                            streamContent.Dispose();
                        }
                        fs.Close();
                        fs.Dispose();
                    }
                }
            }
            return stringContent;
        }
        public static string GetContentType(string typeFile)
        {
            string content = string.Empty;
            if (typeFile == ".txt")
            {
                content = "text/plain";
            }
            else if (typeFile == ".pdf")
            {
                content = "application/pdf";
            }
            else if (typeFile == ".doc")
            {
                content = "application/vnd.ms-word";
            }
            else if (typeFile == ".docx")
            {
                content = "application/vnd.ms-word";
            }
            else if (typeFile == ".xls")
            {
                content = "application/vnd.ms-excel";
            }
            else if (typeFile == ".xlsx")
            {
                content = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            }
            else if (typeFile == ".png")
            {
                content = "image/png";
            }
            else if (typeFile == ".jpg")
            {
                content = "image/jpeg";
            }
            else if (typeFile == ".jpeg")
            {
                content = "image/jpeg";
            }
            else if (typeFile == ".gif")
            {
                content = "image/gif";
            }
            else if (typeFile == ".csv")
            {
                content = "text/csv";
            }
            return content;

        }
        #endregion

        #region Get List
        public static string GetValueByListGuid(List<Guid> guids)
        {
            string stringContent = string.Empty;
            if (guids != null && guids.Count > 0)
            {
                string url = ConfigManager.RemoteAPIURL() + pathUploadFile.pathGetList.ToString();
                int i = 0;
                guids.ForEach(o =>
                {
                    url += (i == 0 ? "?ids=" + o.ToString() : "&ids=" + o.ToString());
                    i++;
                });
                HttpClient client = new HttpClient();
                stringContent = client.GetStringAsync(url).Result;
                client.Dispose();
            }
            return stringContent;
        }
        #endregion

        #region Download File
        public static string DownloadFile(string pathLocal, FileColumnViewModel objModel)
        {
            string path = string.Empty;
            if (objModel != null)
            {
                string url = ConfigManager.RemoteAPIURL() + pathUploadFile.pathDownload.ToString();
                string uriBuilder = string.Format("{0}/{1}", url, objModel.Id.ToString());
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(uriBuilder.ToString()).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    FileStream fs;
                    try
                    {
                        fs = File.Create(pathLocal);
                    }
                    catch (Exception ex)
                    {
                        GGFunctions.ShowMessage("Vui lòng đóng file excel đang mở trước khi tải file!");
                        return path;
                    }
                    response.Content.ReadAsStreamAsync().GetAwaiter().GetResult().CopyTo(fs);
                    fs.Dispose();
                    path = pathLocal;
                }
                response.Dispose();
                client.Dispose();
            }
            return path;
        }
        #endregion

        public static bool FileIsLocked(string strFullFileName)
        {
            bool blnReturn = false;
            FileStream fs;
            try
            {
                fs = File.Open(strFullFileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
                fs.Close();
            }
            catch (IOException ex)
            {
                blnReturn = true;
            }
            return blnReturn;
        }
    }
}
