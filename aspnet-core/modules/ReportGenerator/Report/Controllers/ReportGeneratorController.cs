using Aspose.Words;
using Aspose.Words.Reporting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OpenXMLTemplates.Documents;
using OpenXMLTemplates.Engine;
using OpenXMLTemplates.Variables;
using Report.Common;
using Report.Models;
using System.IO;
using System.Threading.Tasks;

namespace Report.Controllers
{
    [ApiController]
    [Route("report")]
    public class ReportGeneratorController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<ReportGeneratorController> _logger;

        public ReportGeneratorController(ILogger<ReportGeneratorController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> Post(dynamic data)
        {
            var templateName = "BaoCaoDeXuatChuTruongDauTu_Template.docx";
            var templatePath = Path.Combine(_env.ContentRootPath, "Template", templateName);

            var doc = new TemplateDocument(templatePath);
            var src = new VariableSource(data.ToString());

            var engine = new DefaultOpenXmlTemplateEngine();
            engine.ReplaceAll(doc, src);

            var tmp = new TempFile();

            doc.SaveAs(tmp.Path);

            var memory = new MemoryStream();
            using (var stream = new FileStream(tmp.Path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "BaoCaoDeXuatChuTruongDauTu.docx");
        }

        [HttpGet]
        public async Task<IActionResult> Get(string data)
        {
            var templateName = "BaoCaoDeXuatChuTruongDauTu_Template.docx";
            var templatePath = Path.Combine(_env.ContentRootPath, "Template", templateName);

            var doc = new TemplateDocument(templatePath);
            var src = new VariableSource(data.ToString());

            var engine = new DefaultOpenXmlTemplateEngine();
            engine.ReplaceAll(doc, src);

            var tmp = new TempFile();

            doc.SaveAs(tmp.Path);

            var memory = new MemoryStream();
            using (var stream = new FileStream(tmp.Path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "BaoCaoDeXuatChuTruongDauTu.docx");
        }

        [HttpPost("thamdinh")]
        public async Task<IActionResult> XuatFileThamDinhNhaThau([FromForm] string data, [FromForm] string view)
        {
            var templateName = "";
            var outputFileTemplate = "";
            object reportData = null;
            switch (view)
            {
                case "ThamDinhDeXuatChuTruongDauTu":
                    templateName = "ThamDinh_DeXuatChuTruongDauTu_Template.docx";
                    outputFileTemplate = "ThamDinhDeXuatChuTruongDauTu.docx";
                    reportData = JsonConvert.DeserializeObject<BaoCaoDeXuatChuTruongDauTu>(data);
                    break;

                case "ThamDinhDieuChinhChuTruongDauTu":
                    templateName = "ThamDinh_DieuChinhChuTruongDauTu_Template.docx";
                    outputFileTemplate = "ThamDinhDieuChinhChuTruongDauTu.docx";
                    reportData = JsonConvert.DeserializeObject<BaoCaoDieuChinhChuTruongDauTu>(data);
                    break;

                case "ThamDinhKeHoachLuaChonNhaThau":
                    templateName = "ThamDinh_KeHoachLuaChonNhaThau_Template.docx";
                    outputFileTemplate = "ThamDinhKeHoachLuaChonNhaThau.docx";
                    reportData = JsonConvert.DeserializeObject<BaoCaoLuaChonNhaThau>(data);
                    break;

                case "ThamDinhDieuChinhKeHoachLuaChonNhaThau":
                    templateName = "ThamDinh_DieuChinhKeHoachLuaChonNhaThau_Template.docx";
                    outputFileTemplate = "ThamDinhDieuChinhKeHoachLuaChonNhaThau.docx";
                    reportData = JsonConvert.DeserializeObject<BaoCaoDieuChinhLuaChonNhaThau>(data);
                    break;

                case "ThamDinhBaoCaoKinhTeKyThuat":
                    templateName = "ThamDinh_BaoCaoKinhTeKyThuat_Template.docx";
                    outputFileTemplate = "ThamDinhBaoCaoKinhTeKyThuat.docx";
                    reportData = JsonConvert.DeserializeObject<BaoCaoDeXuatChuTruongDauTu>(data);
                    break;

                case "ThamDinhDuAnDauTu":
                    templateName = "ThamDinh_DuAnDauTu_Template.docx";
                    outputFileTemplate = "ThamDinhDuAnDauTu.docx";
                    reportData = JsonConvert.DeserializeObject<BaoCaoDeXuatChuTruongDauTu>(data);
                    break;

                case "ThamDinhHoSoMoiThau":
                    templateName = "ThamDinh_HoSoMoiThau_Template.docx";
                    outputFileTemplate = "ThamDinhHoSoMoiThau.docx";
                    reportData = JsonConvert.DeserializeObject<BaoCaoDeXuatChuTruongDauTu>(data);
                    break;
            }
            var templatePath = Path.Combine(_env.ContentRootPath, "Template", templateName);
            Document doc = new Document(templatePath);

            ReportingEngine engine = new ReportingEngine();
            engine.BuildReport(doc, reportData, "reportData");
            var tmp = new TempFile();
            doc.Save(tmp.Path, SaveFormat.Docx);

            var memory = new MemoryStream();
            using (var stream = new FileStream(tmp.Path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return new FileContentResult(memory.ToArray(), "application/octet-stream")
            {
                FileDownloadName = outputFileTemplate
            };
        }

        public class Project
        {
            public string name { get; set; }
            public string ChuDauTu { get; set; }
            public string CoSoPhapLy { get; set; }
            public string ThanhPhanHoSo { get; set; }
        }

        public class ReportDataModel
        {
            public string Year { get; set; }

            public Project Project { get; set; }
        }
    }
}